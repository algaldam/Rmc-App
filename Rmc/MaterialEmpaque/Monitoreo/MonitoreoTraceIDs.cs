using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Monitoreo
{
    public partial class MonitoreoTraceIDs : RadForm
    {
        private const string CompletedStatus = "Completado (M)";
        private readonly MonitoreoService _service;
        private string _filtroTraceId = string.Empty;

        public MonitoreoTraceIDs()
        {
            InitializeComponent();

            _service = new MonitoreoService(dataGridViewTareas);

            flpCards.FlowDirection = FlowDirection.TopDown;
            flpCards.WrapContents = false;
            flpCards.AutoScroll = true;
            _service.ConfigurarGrid();
            _service.CargarTareas();
        }

        private void TxtTraceIDs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string filtro = txtTraceIDs.Text.Trim();

                // Deshabilitar otros filtros cuando se busca por traceID
                rdDpListEstados.Enabled = string.IsNullOrEmpty(filtro);
                dtpFechaInicio.Enabled = string.IsNullOrEmpty(filtro);
                dtpFechaFin.Enabled = string.IsNullOrEmpty(filtro);

                AplicarFiltros(traceIdFiltro: filtro);
            }
        }

        private void dataGridViewTareas_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is Telerik.WinControls.UI.GridHeaderCellElement)
            {
                e.CellElement.BackColor = Color.FromArgb(44, 62, 80);
                e.CellElement.ForeColor = Color.White;
                e.CellElement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellElement.DrawFill = true;
            }
        }

        #region Tareas Retrasadas
        private void MonitoreoTraceIDs_Load(object sender, EventArgs e)
        {
            lblResumen.Text = "0";
            timerUi.Enabled = true;
            Task.Run(() => CargarTarjetasAsync());
        }

        private void TimerUi_Tick(object sender, EventArgs e)
        {
            foreach (TraceIdCard card in flpCards.Controls.OfType<TraceIdCard>())
                card.UpdateElapsedAndSeverity();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            _service.CargarTareas();
            Task.Run(() => CargarTarjetasAsync());
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            AplicarFiltros();
        }

        private void LimpiarFiltros()
        {
            txtTraceIDs.Text = string.Empty;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Value = DateTime.Now;
            dtpFechaFin.Checked = false;
            rdDpListEstados.SelectedIndex = 0;

            // Rehabilitar todos los filtros
            rdDpListEstados.Enabled = true;
            dtpFechaInicio.Enabled = true;
            dtpFechaFin.Enabled = true;
            bool esEstadoCompletado = rdDpListEstados.SelectedIndex == 0 || rdDpListEstados.SelectedIndex == 1;
            dtpFechaInicio.Enabled = esEstadoCompletado;
            dtpFechaFin.Enabled = esEstadoCompletado;
        }

        private async Task CargarTarjetasAsync()
        {
            try
            {
                DataTable data = await ObtenerTraceIdsRetrasadosAsync();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => ActualizarUI(data)));
                }
                else
                {
                    ActualizarUI(data);
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => RadMessageBox.Show(this, "Error al cargar: " + ex.Message, "Monitoreo", MessageBoxButtons.OK, RadMessageIcon.Error)));
                else
                    RadMessageBox.Show(this, "Error al cargar: " + ex.Message, "Monitoreo", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void ActualizarUI(DataTable data)
        {
            flpCards.SuspendLayout();
            flpCards.Controls.Clear();

            foreach (DataRow row in data.Rows)
            {
                var traceId = row["TraceId"].ToString();
                var saca = row["Saca"].ToString();
                var mesa = row["Mesa"].ToString();
                var assort = row["Assortment"].ToString();
                var dozens = row["Docenas"] != DBNull.Value ? row["Docenas"].ToString() : "0";
                var stickers = row["TotalStickers"] != DBNull.Value ? row["TotalStickers"].ToString() : "0";
                var startDate = row.Field<DateTime>("StartDate");

                var card = new TraceIdCard(traceId, saca, mesa, assort, dozens, stickers, startDate);
                card.Dock = DockStyle.None;
                card.CompleteClicked += Card_CompleteClicked;

                flpCards.Controls.Add(card);
            }
            lblResumen.Text = data.Rows.Count.ToString("N0");
            lblResumen.ForeColor = data.Rows.Count > 0 ? Color.Red : Color.Black;
            lblIndicadorTareasCompletadas.Text = _service.ObtenerIndicadores().ToString("N0");
            flpCards.ResumeLayout();
            _service.AplicarColoresPorEstado();
        }

        private void Card_CompleteClicked(object sender, string traceId)
        {
            Task.Run(() => CompletarTraceIdAsync(traceId));
        }

        private async Task<DataTable> ObtenerTraceIdsRetrasadosAsync()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandText = @"SELECT
                                    TraceId,
                                    Saca,
                                    TableId AS Mesa,
                                    Assortment,
                                    Dozens AS Docenas,
                                    CantidadStickers AS TotalStickers,
                                    StartDate
                                FROM pmc_AsignacionTraceIDs
                                WHERE Status IN ('EnProceso', 'Pendiente')
                                  AND StartDate IS NOT NULL
                                  AND DATEDIFF(MINUTE, StartDate, GETDATE()) >= 240
                                ORDER BY StartDate ASC";
                await conn.OpenAsync();
                da.Fill(table);
            }

            return table;
        }

        private async Task CompletarTraceIdAsync(string traceId)
        {
            DialogResult confirm = DialogResult.No;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    confirm = RadMessageBox.Show(this,
                        $"¿{Environment.UserName.ToUpper()} estas seguro de marcar el TraceID {traceId} como {CompletedStatus}?",
                        "Confirmar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                }));
            }
            else
            {
                confirm = RadMessageBox.Show(this,
                    $"¿Marcar TraceID {traceId} como {CompletedStatus}?",
                    "Confirmar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            }

            if (confirm != DialogResult.Yes) return;

            string usuario = Environment.UserName; // Guardamos el usuario que completa

            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE pmc_AsignacionTraceIDs
                        SET Status = @done,
                            EndDate = GETDATE(),
                            Usuario = @usuario
                        WHERE TraceId = @tid 
                        AND Status IN ('EnProceso', 'Pendiente');";

                    cmd.Parameters.Add("@done", SqlDbType.NVarChar, 50).Value = CompletedStatus;
                    cmd.Parameters.Add("@tid", SqlDbType.NVarChar, 100).Value = traceId;
                    cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 50).Value = usuario;

                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();

                    if (rows > 0)
                    {
                        await CargarTarjetasAsync();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() => {
                                _service.CargarTareas();
                                MessageBox.Show($"TraceID {traceId} completado por {usuario}",
                                                "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                        }
                        else
                        {
                            _service.CargarTareas();
                            MessageBox.Show($"TraceID {traceId} completado por {usuario}",
                                            "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => MessageBox.Show("Error al completar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                else
                    MessageBox.Show("Error al completar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void rdDpListEstados_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rdDpListEstados.SelectedItem != null)
            {
                string estadoSeleccionado = rdDpListEstados.SelectedItem.Text;

                bool esEstadoCompletado = estadoSeleccionado == "Completado";
                dtpFechaInicio.Enabled = esEstadoCompletado;
                dtpFechaFin.Enabled = esEstadoCompletado;

                if (!esEstadoCompletado)
                {
                    dtpFechaInicio.Checked = false;
                    dtpFechaFin.Checked = false;
                }

                AplicarFiltros(estadoFiltro: estadoSeleccionado);
            }
        }

        private void AplicarFiltros(string traceIdFiltro = null, string estadoFiltro = null)
        {
            DateTime? fechaInicio = dtpFechaInicio.Checked ? dtpFechaInicio.Value : (DateTime?)null;
            DateTime? fechaFin = dtpFechaFin.Checked ? dtpFechaFin.Value : (DateTime?)null;

            if (estadoFiltro == null && rdDpListEstados.SelectedItem != null)
            {
                estadoFiltro = rdDpListEstados.SelectedItem.Text;
            }

            bool encontroResultados = _service.CargarTareas(traceIdFiltro, fechaInicio, fechaFin, estadoFiltro);

            if (!string.IsNullOrEmpty(traceIdFiltro) && !encontroResultados)
            {
                RadMessageBox.Show(this,
                    $"No se encontró el TraceID: {traceIdFiltro}",
                    "Búsqueda sin resultados",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Info);
            }
        }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Solo filtrar si los DatePickers están checked (seleccionados)
            if (dtpFechaInicio.Checked || dtpFechaFin.Checked)
            {
                System.Threading.Thread.Sleep(100);
                AplicarFiltros();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(dataGridViewTareas);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog1.Title = "Exportar a Excel";
                saveFileDialog1.FileName = "RegistroMonitoreo.xlsx";
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                string fileName = saveFileDialog1.FileName;

                if (!fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    fileName += ".xlsx";

                try
                {
                    // Verificar si el archivo está bloqueado
                    if (IsFileLocked(fileName))
                    {
                        MessageBox.Show("El archivo está abierto en otra aplicación. Ciérralo e intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Sobrescribir si ya existe
                    if (File.Exists(fileName))
                    {
                        var result = MessageBox.Show("El archivo ya existe. ¿Desea sobrescribirlo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            File.Delete(fileName);
                        }
                        else
                        {
                            return;
                        }
                    }

                    // Ejecutar exportación
                    spreadExporter.RunExport(fileName, exportRenderer);

                    MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("No se puede acceder al archivo: " + ioEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsFileLocked(string filePath)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }

    }
}