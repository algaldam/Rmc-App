using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Mesas
{
    public partial class ReasignarForm : Telerik.WinControls.UI.RadForm
    {
        private string _traceId;
        private string _mesaActual;
        private int _cargaMesaActual = 0;

        public ReasignarForm(string traceId, string mesaActual)
        {
            InitializeComponent();
            _traceId = traceId;
            _mesaActual = mesaActual;

            // Configurar estilo inicial
            this.ThemeName = "Fluent";
            btnReasignar.Enabled = false;
        }

        private void ReasignarForm_Load(object sender, EventArgs e)
        {
            lblTraceId.Text = $"Trace ID: {_traceId}";
            lblMesaActual.Text = $"Mesa Actual: {_mesaActual}";

            CargarMesasDisponibles();
        }

        private void CargarMesasDisponibles()
        {
            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                {
                    string query = @"
                        SELECT
                            ms.TableId,
                            ISNULL(cm.TotalStickers, 0) AS TotalStickers
                        FROM pmc_MesasEstikerado ms
                        LEFT JOIN View_CargaStickersPorMesa cm
                            ON cm.TableId = ms.TableId
                        WHERE ms.Enable <> 0
                        ORDER BY ms.TableId";

                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbMesas.Items.Clear();
                        bool mesaActualEncontrada = false;
                        int totalMesas = 0;

                        while (reader.Read())
                        {
                            int tableId = Convert.ToInt32(reader["TableId"]);
                            int totalStickers = Convert.ToInt32(reader["TotalStickers"]);

                            // Crear item con información de carga
                            string itemText = $"Mesa {tableId}";

                            // Agregar información de stickers
                            if (totalStickers == 0)
                            {
                                itemText += " (Vacía)";
                            }

                            var item = new RadListDataItem(itemText, tableId);

                            // Guardar el total de stickers como tag
                            item.Tag = totalStickers;

                            cmbMesas.Items.Add(item);
                            totalMesas++;

                            // Verificar si esta es la mesa actual
                            if (!string.IsNullOrEmpty(_mesaActual) &&
                                int.TryParse(_mesaActual, out int mesaId) &&
                                mesaId == tableId)
                            {
                                mesaActualEncontrada = true;
                                // Marcar la mesa actual visualmente
                                item.Text += " ← Actual";
                                item.ForeColor = Color.DarkGray;

                                // Guardar la carga de la mesa actual para referencia
                                _cargaMesaActual = totalStickers;
                            }
                        }

                        // Seleccionar el primer elemento si hay mesas disponibles
                        if (cmbMesas.Items.Count > 0)
                        {
                            // Intentar seleccionar una mesa vacía o con baja carga primero
                            RadListDataItem mejorOpcion = null;

                            foreach (RadListDataItem item in cmbMesas.Items)
                            {
                                if (item.Value.ToString() == _mesaActual)
                                    continue; // Saltar la mesa actual

                                int stickers = (int)(item.Tag ?? 0);

                                // Preferir mesas vacías
                                if (stickers == 0)
                                {
                                    mejorOpcion = item;
                                    break;
                                }

                                // Si no hay vacías, tomar la primera con menor carga
                                if (mejorOpcion == null || stickers < (int)(mejorOpcion.Tag ?? 0))
                                {
                                    mejorOpcion = item;
                                }
                            }

                            if (mejorOpcion != null)
                            {
                                cmbMesas.SelectedItem = mejorOpcion;
                            }
                            else if (!mesaActualEncontrada && cmbMesas.Items.Count > 0)
                            {
                                cmbMesas.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            RadMessageBox.Show(this,
                                "No hay mesas disponibles para reasignación.",
                                "Información",
                                MessageBoxButtons.OK,
                                RadMessageIcon.Info);
                            btnReasignar.Enabled = false;
                        }

                        // Mostrar resumen
                        lblResumen.Text = $"{totalMesas} mesas disponibles";
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this,
                    $"Error al cargar mesas:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error);
                btnReasignar.Enabled = false;
            }
        }

        private void btnReasignar_Click(object sender, EventArgs e)
        {
            if (cmbMesas.SelectedItem == null)
            {
                RadMessageBox.Show(this,
                    "Seleccione una mesa para la reasignación.",
                    "Validación",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation);
                return;
            }

            var nuevaMesa = cmbMesas.SelectedItem.Value.ToString();

            var displayText = cmbMesas.SelectedItem.Text;
            var mesaNumero = nuevaMesa;

            if (!string.IsNullOrEmpty(_mesaActual) && nuevaMesa == _mesaActual)
            {
                RadMessageBox.Show(this,
                    "No puede reasignar a la misma mesa actual.",
                    "Validación",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation);
                return;
            }

            // Confirmar reasignación
            var result = RadMessageBox.Show(this,
                $"¿Está seguro de reasignar el Trace ID {_traceId}?\n\n" +
                $"De: Mesa {_mesaActual}\n" +
                $"A: Mesa {nuevaMesa}",
                "Confirmar Reasignación",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                ReasignarMesa(nuevaMesa);
            }
        }

        private void ReasignarMesa(string nuevaMesa)
        {
            Cursor.Current = Cursors.WaitCursor;
            btnReasignar.Enabled = false;
            btnCancelar.Enabled = false;

            SqlConnection connection = null;
            SqlTransaction transaction = null;

            try
            {
                connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();

                string query1 = @"
                    UPDATE pmc_AsignacionTraceIDs 
                    SET 
                        TableId = @TABLE, 
                        Status = 'Pendiente', 
                        AssignmentDate = GETDATE(), 
                        StartDate = NULL, 
                        EndDate = NULL 
                    WHERE TraceId = @TRACEID";

                using (var cmd1 = new SqlCommand(query1, connection, transaction))
                {
                    cmd1.Parameters.AddWithValue("@TABLE", nuevaMesa);
                    cmd1.Parameters.AddWithValue("@TRACEID", _traceId);
                    int rowsAffected = cmd1.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"No se encontró el Trace ID {_traceId} en pmc_AsignacionTraceIDs");
                    }
                }

                try
                {
                    string query2 = @"
                        UPDATE ES_SOCKS.dbo.pmc_Transactions 
                        SET TableNumber = @TABLE 
                        WHERE TraceID = @TRACEID";

                    using (var cmd2 = new SqlCommand(query2, connection, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@TABLE", nuevaMesa);
                        cmd2.Parameters.AddWithValue("@TRACEID", _traceId);
                        int rowsUpdated = cmd2.ExecuteNonQuery();

                        // No lanzar error si no encuentra en esta tabla (puede ser normal)
                        if (rowsUpdated == 0)
                        {
                            System.Diagnostics.Debug.WriteLine($"Trace ID {_traceId} no encontrado en pmc_Transactions");
                        }
                    }
                }
                catch (Exception transEx)
                {
                    System.Diagnostics.Debug.WriteLine($"Advertencia en pmc_Transactions: {transEx.Message}");
                }

                transaction.Commit();
                this.Close();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();

                RadMessageBox.Show(this,
                    $"Error al reasignar mesa:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error);

                btnReasignar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            finally
            {
                connection?.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbMesas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
{
    // Habilitar botón solo si hay una mesa seleccionada y no es la mesa actual
    if (cmbMesas.SelectedItem != null)
    {
        var selectedItem = cmbMesas.SelectedItem as RadListDataItem;
        var selectedValue = selectedItem.Value.ToString();
        var isCurrentTable = (!string.IsNullOrEmpty(_mesaActual) && selectedValue == _mesaActual);
        
        btnReasignar.Enabled = !isCurrentTable;
        
        // Mostrar información detallada de la mesa seleccionada
        if (selectedItem.Tag != null)
        {
            int totalStickers = (int)selectedItem.Tag;
            
            
            // Comparar con la mesa actual
            if (_cargaMesaActual > 0 && !isCurrentTable)
            {
                int diferencia = totalStickers - _cargaMesaActual;
                if (diferencia < 0)
                {
                    lblResumen.Text += $"\n▼ {Math.Abs(diferencia):N0} stickers menos que la actual";
                }
                else if (diferencia > 0)
                {
                    lblResumen.Text += $"\n▲ {diferencia:N0} stickers más que la actual";
                }
                else
                {
                    lblResumen.Text += $"\n= Misma carga que la actual";
                }
            }
            
            btnReasignar.ButtonElement.ForeColor = Color.White;
        }
        else
        {
            btnReasignar.ButtonElement.ResetValue(LightVisualElement.BackColorProperty, 
                Telerik.WinControls.ValueResetFlags.Local);
            btnReasignar.ButtonElement.ResetValue(LightVisualElement.ForeColorProperty, 
                Telerik.WinControls.ValueResetFlags.Local);
        }
    }
    else
    {
        btnReasignar.Enabled = false;
        btnReasignar.ButtonElement.ResetValue(LightVisualElement.BackColorProperty, 
            Telerik.WinControls.ValueResetFlags.Local);
        btnReasignar.ButtonElement.ResetValue(LightVisualElement.ForeColorProperty, 
            Telerik.WinControls.ValueResetFlags.Local);
        lblResumen.Text = "Seleccione una mesa";
    }
}
    }
}