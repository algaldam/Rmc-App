using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Security.Principal;

namespace Rmc.MaterialEmpaque.Ventana
{
    public partial class VentanaForm : Telerik.WinControls.UI.RadForm
    {
        private DataTable itemsDataTable;
        private DataTable itemsDesperdicioTable;
        private int currentTransactionId = 0;
        private int currentTraceId = 0;
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;
        private string tracerConnectionString = Properties.Settings.Default.TracerConnectionString;

        // Colores para mensajes de estado
        private readonly Color YellowAlertColor = Color.FromArgb(255, 255, 204);
        private readonly Color GreenSuccessColor = Color.FromArgb(204, 255, 204);
        private readonly Color RedErrorColor = Color.FromArgb(255, 204, 204);

        private DesperdicioData datosDesperdicio;
        private bool moduloDesperdiciosActivo = false;
        private bool buscarPorTraceID = true;
       
        public VentanaForm()
        {
            InitializeComponent();
            ConfigureInitialState();
        }

        private void ConfigureInitialState()
        {
            this.KeyPreview = true;
            ConfigureGridEvents();
            ConfigurarComboBoxAreas();

            if (checkID != null)
            {
                checkID.Checked = true;
                checkID.CheckedChanged += CheckID_CheckedChanged;
                checkID.Text = "Buscar por TraceID Knitting/Dye";

                checkID.CheckStateChanged += (s, e) =>
                {
                    checkID.Text = checkID.Checked ? "Buscar por TraceID Knitting/Dye" : "Buscar por TraceID Finishing";
                };
            }

            txtDespTraceID.KeyDown += TxtDespTraceID_KeyDown;
            txtDespOperador.KeyDown += TxtDespOperador_KeyDown;
            cmbDespArea.SelectedIndexChanged += CmbDespArea_SelectedIndexChanged;

            OcultarModuloDesperdicios();
        }

        private void CheckID_CheckedChanged(object sender, EventArgs e)
        {
            buscarPorTraceID = checkID.Checked;
            string modoBusqueda = buscarPorTraceID ? "TraceID Knitting/Dye" : "TraceID Finishing";
            ShowStatusMessage($"Modo de búsqueda: {modoBusqueda}");
            txtTraceID.Focus();
            txtTraceID.SelectAll();
        }

        private void ControlarCamposDesperdicio(bool habilitar)
        {
            txtDespTraceID.Enabled = habilitar;
            //txtDespSaca.Enabled = habilitar;
            cmbDespArea.Enabled = habilitar;
            cmbDespMotivo.Enabled = habilitar;
            txtDespOperador.Enabled = habilitar;

            if (GridItemsDesperdicioOut.Visible)
            {
                GridItemsDesperdicioOut.Enabled = habilitar;
            }

            Color colorFondo = habilitar ? SystemColors.Window : SystemColors.Control;
            Color colorTexto = habilitar ? SystemColors.WindowText : SystemColors.GrayText;

            txtDespTraceID.BackColor = colorFondo;
            //txtDespSaca.BackColor = colorFondo;
            cmbDespArea.BackColor = colorFondo;

            cmbDespMotivo.BackColor = colorFondo;
            txtDespOperador.BackColor = colorFondo;

            txtDespTraceID.ForeColor = colorTexto;
            //txtDespSaca.ForeColor = colorTexto;
            cmbDespArea.ForeColor = colorTexto;
            cmbDespMotivo.ForeColor = colorTexto;
            txtDespOperador.ForeColor = colorTexto;

            if (!habilitar)
            {
                ShowStatusMessage("Módulo de desperdicio deshabilitado mientras procesa consumo", false, true);
            }
        }

        private void OcultarModuloDesperdicios()
        {
            GridItemsOut.Visible = true;
            txtTraceID.Visible = true;
            txtSACA.Visible = true;
            txtSACAseg.Visible = true;
            txtDocenas.Visible = true;
            txtMesaAsignada.Visible = true;
            txtCarnetDescontar.Visible = true;
            txtTraceIdSalida.Visible = true;

            GridItemsDesperdicioOut.Visible = false;
            txtDespTraceID.Visible = true;
            txtDespSaca.Visible = true;
            cmbDespArea.Visible = true;
            cmbDespMotivo.Visible = true;
            txtDespOperador.Visible = true;

            radLabel11.Visible = true;
            radLabel7.Visible = true;
            radLabel6.Visible = true;
            radLabel10.Visible = true;
            radLabel8.Visible = true;
            radLabel9.Visible = true;

            txtDespTraceID.Text = "";
            txtDespSaca.Text = "";
            txtDespOperador.Text = "";
            cmbDespArea.SelectedIndex = -1;
            cmbDespMotivo.SelectedIndex = -1;

            ControlarCamposDesperdicio(true);

            moduloDesperdiciosActivo = false;
        }

        private void MostrarModuloDesperdicios()
        {
            // Verificar si hay un proceso de consumo activo
            if (currentTraceId > 0 && itemsDataTable != null)
            {
                ShowStatusMessage("No puede activar desperdicio mientras procesa un consumo", true);
                return;
            }

            GridItemsOut.Visible = false;
            txtTraceID.Visible = false;
            txtSACA.Visible = false;
            txtSACAseg.Visible = false;
            txtDocenas.Visible = false;
            txtMesaAsignada.Visible = false;
            txtCarnetDescontar.Visible = false;
            txtTraceIdSalida.Visible = false;

            GridItemsDesperdicioOut.Visible = true;
            txtDespTraceID.Visible = true;
            txtDespSaca.Visible = true;
            cmbDespArea.Visible = true;
            cmbDespMotivo.Visible = true;
            txtDespOperador.Visible = true;

            radLabel11.Visible = true;
            radLabel7.Visible = true;
            radLabel6.Visible = true;
            radLabel10.Visible = true;
            radLabel8.Visible = true;
            radLabel9.Visible = true;

            moduloDesperdiciosActivo = true;
        }

        private void ConfigureGridEvents()
        {
            GridItemsOut.CellEndEdit += GridItemsOut_CellEndEdit;
            GridItemsOut.KeyDown += GridItemsOut_KeyDown;
            GridItemsOut.CellFormatting += GridItemsOut_CellFormatting;
            GridItemsOut.CellBeginEdit += GridItemsOut_CellBeginEdit;
            GridItemsOut.CellValidating += GridItemsOut_CellValidating;
            GridItemsOut.RowFormatting += GridItemsOut_RowFormatting;

            GridItemsDesperdicioOut.CellValidating += GridItemsDesperdicioOut_CellValidating;
            GridItemsDesperdicioOut.KeyDown += GridItemsDesperdicioOut_KeyDown;
            GridItemsDesperdicioOut.CellEndEdit += GridItemsDesperdicioOut_CellEndEdit;
        }

        #region Módulo de Desperdicios (GridItemsDesperdicioOut)

        private void ConfigurarComboBoxAreas()
        {
            cmbDespArea.Items.Clear();
            cmbDespArea.Items.AddRange(new string[] { "Stickerado", "Acabados" });
            cmbDespArea.SelectedIndex = -1;
            cmbDespMotivo.Items.Clear();
            cmbDespMotivo.Enabled = false;
        }

        private void GridItemsDesperdicioOut_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "CantidadDesperdicio" && e.Row is GridViewDataRowInfo row)
            {
                try
                {
                    var cellValue = row.Cells["CantidadDesperdicio"].Value;
                    if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        if (decimal.TryParse(cellValue.ToString(), out decimal cantidad))
                        {
                            UpdateDataTableDesperdicio(row, cantidad);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Error al procesar la cantidad: {ex.Message}", true);
                }
            }
        }

        private void CmbDespArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDespArea.SelectedItem == null)
            {
                cmbDespMotivo.Items.Clear();
                cmbDespMotivo.Enabled = false;
                return;
            }

            cmbDespMotivo.Items.Clear();
            cmbDespMotivo.Enabled = true;
            string areaSeleccionada = cmbDespArea.SelectedItem.ToString();

            if (areaSeleccionada == "Stickerado")
            {
                cmbDespMotivo.Items.AddRange(new string[] {
                    "Desp. Impresora",
                    "Desp. Proveedor",
                    "Desp. Manipulacion"
                });
            }
            else if (areaSeleccionada == "Acabados")
            {
                cmbDespMotivo.Items.AddRange(new string[] {
                    "Desp. Calidad",
                    "Desp. Selladora",
                    "Desp. Procesos",
                    "Desp. Proveedor"
                });
            }
            cmbDespMotivo.SelectedIndex = -1;
        }

        private void TxtDespTraceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (currentTraceId > 0 && itemsDataTable != null)
                {
                    ShowStatusMessage("Complete o cancele el proceso de consumo actual primero", true);
                    return;
                }

                string traceIdInput = txtDespTraceID.Text.Trim();

                if (string.IsNullOrEmpty(traceIdInput))
                {
                    ShowStatusMessage("Ingrese un ID para desperdicio", true);
                    return;
                }

                if (!int.TryParse(traceIdInput, out int idBuscado))
                {
                    ShowStatusMessage("El ID no es válido", true);
                    return;
                }

                if (!VerificarIDExistenteEnCheckPoint(idBuscado, buscarPorTraceID))
                {
                    string tipoID = buscarPorTraceID ? "TraceID Knitting/Dye" : "TraceID Finishing";
                    ShowStatusMessage($"El {tipoID} ingresado sigue en stikerado", true);
                    txtDespTraceID.SelectAll();
                    txtDespTraceID.Focus();
                    return;
                }

                int traceIdReal = 0;

                if (buscarPorTraceID)
                {
                    traceIdReal = idBuscado;
                    ShowStatusMessage($"Desperdicio - Búsqueda por TraceID: {traceIdReal}");
                }
                else
                {
                    traceIdReal = ObtenerTraceIDDesdeRelatedID(idBuscado);

                    if (traceIdReal == 0)
                    {
                        ShowStatusMessage($"No se encontró un TraceID relacionado -> {idBuscado}", true);
                        txtDespTraceID.SelectAll();
                        txtDespTraceID.Focus();
                        return;
                    }

                    ShowStatusMessage($"Desperdicio - FinishingID {idBuscado} → TraceID {traceIdReal}");
                }

                if (!VerificarTraceIDEnAsignaciones(traceIdReal.ToString()))
                {
                    ShowStatusMessage($"TraceID {traceIdReal} no encontrado en asignaciones", true);
                    txtDespTraceID.SelectAll();
                    txtDespTraceID.Focus();
                    return;
                }

                if (!moduloDesperdiciosActivo)
                {
                    MostrarModuloDesperdicios();
                    txtDespTraceID.Focus();
                }

                txtDespTraceID.Text = traceIdReal.ToString();

                CargarDatosParaDesperdicio(traceIdReal.ToString());
            }
        }

        private bool VerificarIDExistenteEnCheckPoint(int idBuscado, bool esTraceIDMode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(tracerConnectionString))
                {
                    connection.Open();

                    string query;

                    if (esTraceIDMode)
                    {
                        query = @"
                    SELECT COUNT(*) 
                    FROM CheckPointTrans 
                    WHERE TraceId = @ID
                    AND ChkID = 'FIN-BASC'";
                    }
                    else
                    {
                        query = @"
                    SELECT COUNT(*) 
                    FROM CheckPointTrans 
                    WHERE RelatedID = @ID
                    AND ChkID = 'FIN-BASC'";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", idBuscado);
                        int count = (int)command.ExecuteScalar();

                        string tipoID = esTraceIDMode ? "TraceID Knitting/Dye" : "TraceID Finishing";
                        string resultado = count > 0 ? "EXISTE" : "NO existe";
                        ShowStatusMessage($"Verificado {tipoID} {idBuscado}");

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error verificando ID: {ex.Message}", true);
                return false;
            }
        }

        private bool VerificarTraceIDEnAsignaciones(string traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(tracerConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT COUNT(*) FROM pmc_AsignacionTraceIDs WHERE TraceId = @TraceID", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error verificando TraceID en asignaciones: {ex.Message}", true);
                return false;
            }
        }

        private void CargarDatosParaDesperdicio(string traceId)
        {
            try
            {
                using (SqlConnection tracerConnection = new SqlConnection(tracerConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT TraceId, Saca, MillStyle, Size, Color, TableId
                        FROM pmc_AsignacionTraceIDs 
                        WHERE TraceId = @TraceID", tracerConnection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        tracerConnection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                datosDesperdicio = new DesperdicioData
                                {
                                    TraceId = traceId,
                                    Saca = reader["Saca"]?.ToString() ?? "",
                                    MillStyle = reader["MillStyle"]?.ToString() ?? "",
                                    Size = reader["Size"]?.ToString() ?? "",
                                    Color = reader["Color"]?.ToString() ?? "",
                                    TableNumber = reader["TableId"] != DBNull.Value ? Convert.ToInt32(reader["TableId"]) : (int?)null
                                };
                                txtDespSaca.Text = datosDesperdicio.Saca;
                                reader.Close();
                                CargarItemsDesperdicioEnGrid(traceId);
                            }
                            else
                            {
                                ShowStatusMessage($"TraceID {traceId} no encontrado en asignaciones", true);
                                txtDespTraceID.SelectAll();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error cargando datos: {ex.Message}", true);
            }
        }

        private void CargarItemsDesperdicioEnGrid(string traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT DISTINCT
                            D.DetailID,
                            D.Code AS Item,
                            SB.sub_descripcion AS Description,
                            SB.sub_TypeMaterials AS TypeMaterial,
                            0 AS CantidadDesperdicio,
                            ISNULL(WH.WarehouseCode, 'No Disp.') AS Codigo,
                            CASE 
                                WHEN IP.WarehouseID = 3 THEN IP.Location
                                ELSE 'No Disp.'
                            END AS Localidad
                        FROM pmc_TransactionDetails D
                        LEFT JOIN pmc_Subida_BOM SB 
                            ON SB.sub_producto = D.Code
                        LEFT JOIN pmc_InventoryPreparation IP 
                            ON IP.Code = D.Code
                            AND IP.WarehouseID = 3
                        LEFT JOIN pmc_Warehouse WH 
                            ON IP.WarehouseID = WH.WarehouseID
                        INNER JOIN pmc_Transactions T 
                            ON T.ID = D.TransactionID
                        WHERE T.TraceID = @TraceID
                        ORDER BY D.Code;", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        connection.Open();

                        if (itemsDesperdicioTable != null)
                        {
                            itemsDesperdicioTable.Dispose();
                        }
                        itemsDesperdicioTable = new DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(itemsDesperdicioTable);
                        }

                        if (itemsDesperdicioTable.Rows.Count == 0)
                        {
                            ShowStatusMessage($"No se encontraron items para el TraceID {traceId}", true);
                            return;
                        }

                        if (!itemsDesperdicioTable.Columns.Contains("CantidadDesperdicio"))
                        {
                            DataColumn col = itemsDesperdicioTable.Columns.Add("CantidadDesperdicio", typeof(int));
                            col.DefaultValue = 0;
                            col.ReadOnly = false;
                        }
                        else
                        {
                            itemsDesperdicioTable.Columns["CantidadDesperdicio"].ReadOnly = false;
                        }

                        foreach (DataRow row in itemsDesperdicioTable.Rows)
                        {
                            row["CantidadDesperdicio"] = 0;
                        }

                        ConfigurarGridParaDesperdicios();
                        ShowStatusMessage($"Cargados {itemsDesperdicioTable.Rows.Count} items para registrar desperdicio");
                        cmbDespArea.Enabled = true;
                        PosicionarEnPrimeraFilaEditable();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error cargando items: {ex.Message}", true);
            }
        }

        private void ConfigurarGridParaDesperdicios()
        {
            if (GridItemsDesperdicioOut.InvokeRequired)
            {
                GridItemsDesperdicioOut.Invoke(new Action(ConfigurarGridParaDesperdicios));
                return;
            }

            try
            {
                if (GridItemsDesperdicioOut.IsInEditMode)
                {
                    GridItemsDesperdicioOut.EndEdit();
                }

                GridItemsDesperdicioOut.BeginUpdate();
                GridItemsDesperdicioOut.DataSource = null;
                GridItemsDesperdicioOut.Rows.Clear();
                GridItemsDesperdicioOut.MasterTemplate.Columns.Clear();
                GridItemsDesperdicioOut.ClearSelection();
                GridItemsDesperdicioOut.CurrentRow = null;
                GridItemsDesperdicioOut.CurrentColumn = null;

                var bindingSource = new BindingSource();
                bindingSource.DataSource = itemsDesperdicioTable;
                GridItemsDesperdicioOut.DataSource = bindingSource;

                GridItemsDesperdicioOut.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                // Columnas del grid de desperdicios
                var detailIdColumn = new GridViewTextBoxColumn();
                detailIdColumn.FieldName = "DetailID";
                detailIdColumn.HeaderText = "ID";
                detailIdColumn.Name = "DetailID";
                detailIdColumn.Width = 60;
                detailIdColumn.IsVisible = false;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(detailIdColumn);

                var itemCodeColumn = new GridViewTextBoxColumn();
                itemCodeColumn.FieldName = "Item";
                itemCodeColumn.HeaderText = "Código del Item";
                itemCodeColumn.Name = "Item";
                itemCodeColumn.Width = 150;
                itemCodeColumn.ReadOnly = true;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(itemCodeColumn);

                var descriptionColumn = new GridViewTextBoxColumn();
                descriptionColumn.FieldName = "Description";
                descriptionColumn.HeaderText = "Descripción";
                descriptionColumn.Name = "Description";
                descriptionColumn.Width = 200;
                descriptionColumn.ReadOnly = true;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(descriptionColumn);

                var typeMaterialColumn = new GridViewTextBoxColumn();
                typeMaterialColumn.FieldName = "TypeMaterial";
                typeMaterialColumn.HeaderText = "Tipo Material";
                typeMaterialColumn.Name = "TypeMaterial";
                typeMaterialColumn.Width = 120;
                typeMaterialColumn.ReadOnly = true;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(typeMaterialColumn);

                var cantidadDesperdicioColumn = new GridViewTextBoxColumn();
                cantidadDesperdicioColumn.FieldName = "CantidadDesperdicio";
                cantidadDesperdicioColumn.HeaderText = "Cantidad Desperdicio";
                cantidadDesperdicioColumn.Name = "CantidadDesperdicio";
                cantidadDesperdicioColumn.Width = 150;
                cantidadDesperdicioColumn.ReadOnly = false;
                cantidadDesperdicioColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(cantidadDesperdicioColumn);

                var codigoColumn = new GridViewTextBoxColumn();
                codigoColumn.FieldName = "Codigo";
                codigoColumn.HeaderText = "Código Almacén";
                codigoColumn.Name = "Codigo";
                codigoColumn.Width = 120;
                codigoColumn.ReadOnly = true;
                codigoColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(codigoColumn);

                var locationColumn = new GridViewTextBoxColumn();
                locationColumn.FieldName = "Localidad";
                locationColumn.HeaderText = "Localidad";
                locationColumn.Name = "Localidad";
                locationColumn.Width = 150;
                locationColumn.ReadOnly = true;
                GridItemsDesperdicioOut.MasterTemplate.Columns.Add(locationColumn);

                GridItemsDesperdicioOut.MasterTemplate.AllowAddNewRow = false;
                GridItemsDesperdicioOut.MasterTemplate.AllowDeleteRow = false;
                GridItemsDesperdicioOut.MasterTemplate.EnableAlternatingRowColor = true;
                GridItemsDesperdicioOut.MasterTemplate.EnableFiltering = true;
                GridItemsDesperdicioOut.MasterTemplate.ShowFilteringRow = false;
                GridItemsDesperdicioOut.ShowGroupPanel = false;
                GridItemsDesperdicioOut.EndUpdate();
                GridItemsDesperdicioOut.Refresh();
                GridItemsDesperdicioOut.TableElement.UpdateLayout();
            }
            catch (Exception ex)
            {
                GridItemsDesperdicioOut.EndUpdate();
                ShowStatusMessage($"Error configurando grid: {ex.Message}", true);
            }
        }

        private void GridItemsDesperdicioOut_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "CantidadDesperdicio" && e.Row is GridViewDataRowInfo row)
            {
                if (e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    string input = e.Value.ToString();
                    if (!int.TryParse(input, out int result))
                    {
                        e.Cancel = true;
                        ShowStatusMessage("Formato inválido - Solo se permiten números enteros", true);
                        return;
                    }
                    if (result < 0)
                    {
                        e.Cancel = true;
                        ShowStatusMessage("No se permiten valores negativos", true);
                        return;
                    }
                }
            }
        }

        private void GridItemsDesperdicioOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                var currentCell = GridItemsDesperdicioOut.CurrentCell;
                if (currentCell != null && currentCell.ColumnInfo?.Name == "CantidadDesperdicio")
                {
                    if (GridItemsDesperdicioOut.IsInEditMode)
                    {
                        GridItemsDesperdicioOut.EndEdit();

                        Application.DoEvents();
                        System.Threading.Thread.Sleep(30);
                    }

                    int currentIndex = GridItemsDesperdicioOut.CurrentRow?.Index ?? -1;

                    int nextIndex = currentIndex + 1;

                    if (nextIndex < GridItemsDesperdicioOut.Rows.Count)
                    {
                        GridItemsDesperdicioOut.CurrentRow = GridItemsDesperdicioOut.Rows[nextIndex];
                        GridItemsDesperdicioOut.CurrentColumn = GridItemsDesperdicioOut.MasterTemplate.Columns["CantidadDesperdicio"];

                        GridItemsDesperdicioOut.TableElement.ScrollToRow(nextIndex);
                        GridItemsDesperdicioOut.Focus();
                        GridItemsDesperdicioOut.BeginEdit();
                    }
                    else
                    {
                        cmbDespArea.Focus();
                    }
                }
            }
        }

        private void UpdateDataTableDesperdicio(GridViewDataRowInfo row, decimal cantidad)
        {
            if (itemsDesperdicioTable != null)
            {
                var detailId = Convert.ToInt32(row.Cells["DetailID"].Value);
                var foundRows = itemsDesperdicioTable.Select($"DetailID = {detailId}");
                if (foundRows.Length > 0)
                {
                    foundRows[0]["CantidadDesperdicio"] = cantidad;
                }
            }
        }

        private void PosicionarEnPrimeraFilaEditable()
        {
            try
            {
                if (GridItemsDesperdicioOut.Rows.Count == 0) return;

                GridItemsDesperdicioOut.Refresh();
                Application.DoEvents();

                Timer positionTimer = new Timer();
                positionTimer.Interval = 200;
                positionTimer.Tick += (s, e) =>
                {
                    positionTimer.Stop();
                    positionTimer.Dispose();

                    try
                    {
                        if (GridItemsDesperdicioOut.IsDisposed || !GridItemsDesperdicioOut.IsHandleCreated) return;

                        var cantidadDesperdicioColumn = GridItemsDesperdicioOut.MasterTemplate.Columns["CantidadDesperdicio"];
                        if (cantidadDesperdicioColumn != null)
                        {
                            GridItemsDesperdicioOut.ClearSelection();

                            GridItemsDesperdicioOut.Rows[0].IsSelected = true;
                            GridItemsDesperdicioOut.CurrentRow = GridItemsDesperdicioOut.Rows[0];
                            GridItemsDesperdicioOut.CurrentColumn = cantidadDesperdicioColumn;

                            if (GridItemsDesperdicioOut.TableElement.VScrollBar != null)
                            {
                                GridItemsDesperdicioOut.TableElement.ScrollToRow(0);
                            }

                            GridItemsDesperdicioOut.Focus();

                            Timer editTimer = new Timer();
                            editTimer.Interval = 100;
                            editTimer.Tick += (editSender, editArgs) =>
                            {
                                editTimer.Stop();
                                editTimer.Dispose();

                                if (!GridItemsDesperdicioOut.IsDisposed && GridItemsDesperdicioOut.IsHandleCreated)
                                {
                                    GridItemsDesperdicioOut.BeginEdit();
                                    ShowStatusMessage("→ Ingrese las cantidades de desperdicio.");
                                }
                            };
                            editTimer.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowStatusMessage($"Error al posicionar: {ex.Message}", true);
                    }
                };
                positionTimer.Start();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al posicionar en el grid: {ex.Message}", true);
            }
        }

        private void TxtDespOperador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                GuardarDesperdicio();
            }
        }

        private void GuardarDesperdicio()
        {
            if (datosDesperdicio == null || itemsDesperdicioTable == null)
            {
                ShowStatusMessage("Primero verifique un TraceID y cargue los items", true);
                return;
            }

            if (GridItemsDesperdicioOut.IsInEditMode)
            {
                GridItemsDesperdicioOut.EndEdit();
            }

            if (cmbDespArea.SelectedIndex == -1)
            {
                ShowStatusMessage("Seleccione un área", true);
                cmbDespArea.Focus();
                return;
            }

            if (cmbDespMotivo.SelectedIndex == -1)
            {
                ShowStatusMessage("Seleccione un motivo", true);
                cmbDespMotivo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDespOperador.Text))
            {
                ShowStatusMessage("Ingrese el operador", true);
                txtDespOperador.Focus();
                return;
            }

            bool hayDesperdicios = false;
            int totalDesperdicio = 0;
            List<string> itemsConDesperdicio = new List<string>();

            foreach (DataRow row in itemsDesperdicioTable.Rows)
            {
                int cantidad = Convert.ToInt32(row["CantidadDesperdicio"]);
                if (cantidad > 0)
                {
                    hayDesperdicios = true;
                    totalDesperdicio += cantidad;
                    itemsConDesperdicio.Add($"{row["Item"]}: {cantidad}");
                }
            }

            if (!hayDesperdicios)
            {
                ShowStatusMessage("Ingrese al menos una cantidad de desperdicio", true);
                PosicionarEnPrimeraFilaEditable();
                return;
            }

            string areaSeleccionada = cmbDespArea.SelectedItem.ToString();
            string mensajeConfirmacion = $"¿Desea registrar {totalDesperdicio} unidades de desperdicio en {itemsConDesperdicio.Count} items?\n\n" +
                                         $"TraceID: {datosDesperdicio.TraceId}\n" +
                                         $"Saca: {datosDesperdicio.Saca}\n" +
                                         $"Área: {areaSeleccionada}\n" +
                                         $"Motivo: {cmbDespMotivo.SelectedItem}\n" +
                                         $"Operador: {txtDespOperador.Text}";

            DialogResult confirm = MessageBox.Show(
                mensajeConfirmacion,
                "Confirmar Registro de Desperdicio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string traceId = datosDesperdicio.TraceId;
                string saca = datosDesperdicio.Saca;
                string millStyle = datosDesperdicio.MillStyle;
                string size = datosDesperdicio.Size;
                string color = datosDesperdicio.Color;
                object machineCode = DBNull.Value;
                object celulaId = DBNull.Value;
                object tableId = DBNull.Value;

                if (areaSeleccionada == "Stickerado")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(tracerConnectionString))
                        {
                            string query = @"
                        SELECT TraceId, Saca, MillStyle, Size, Color, TableId
                        FROM dbo.pmc_AsignacionTraceIDs 
                        WHERE TraceId = @TraceID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@TraceID", traceId);
                                connection.Open();

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        traceId = reader["TraceId"].ToString();
                                        saca = reader["Saca"]?.ToString() ?? "";
                                        millStyle = reader["MillStyle"]?.ToString() ?? "";
                                        size = reader["Size"]?.ToString() ?? "";
                                        color = reader["Color"]?.ToString() ?? "";
                                        tableId = reader["TableId"] != DBNull.Value ? (object)reader["TableId"] : DBNull.Value;
                                    }
                                }
                            }
                        }
                        machineCode = DBNull.Value;
                        celulaId = DBNull.Value;
                    }
                    catch (Exception ex)
                    {
                        ShowStatusMessage($"Error obteniendo datos de Stickerado: {ex.Message}", false);
                        tableId = datosDesperdicio.TableNumber != null ? (object)datosDesperdicio.TableNumber : DBNull.Value;
                        machineCode = DBNull.Value;
                        celulaId = DBNull.Value;
                    }
                }
                else if (areaSeleccionada == "Acabados")
                {
                    object tempMachineCode = DBNull.Value;
                    object tempCelulaId = DBNull.Value;

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(tracerConnectionString))
                        {
                            connection.Open();

                            string queryTransaccion = @"
                        SELECT t.TraceIDBase, a.Saca, a.MillStyle, a.Size, a.Color, 
                               t.machineCode, t.celula
                        FROM dbo.pmc_AsignacionTraceIDs a
                        INNER JOIN ES_SOCKS.dbo.pmc_Transactions t ON a.TraceID = t.TraceID
                        WHERE t.TraceIDBase = @TraceID";

                            string nombreCelula = null;

                            using (SqlCommand commandTrans = new SqlCommand(queryTransaccion, connection))
                            {
                                commandTrans.Parameters.AddWithValue("@TraceID", traceId);

                                using (SqlDataReader reader = commandTrans.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Usar los valores de la consulta
                                        traceId = reader["TraceIDBase"].ToString();
                                        saca = reader["Saca"]?.ToString() ?? "";
                                        millStyle = reader["MillStyle"]?.ToString() ?? "";
                                        size = reader["Size"]?.ToString() ?? "";
                                        color = reader["Color"]?.ToString() ?? "";

                                        // Manejar machineCode
                                        var machineCodeValue = reader["machineCode"];
                                        if (machineCodeValue != null && machineCodeValue != DBNull.Value)
                                        {
                                            string machineCodeStr = machineCodeValue.ToString();

                                            if (!string.IsNullOrWhiteSpace(machineCodeStr))
                                            {
                                                if (int.TryParse(machineCodeStr, out int machineCodeInt))
                                                {
                                                    tempMachineCode = machineCodeInt;
                                                }
                                            }
                                        }

                                        // Obtener nombre de la celula
                                        var celulaValue = reader["celula"];
                                        if (celulaValue != null && celulaValue != DBNull.Value)
                                        {
                                            nombreCelula = celulaValue.ToString();
                                        }

                                        tableId = DBNull.Value;
                                    }
                                }

                                machineCode = tempMachineCode;

                                if (!string.IsNullOrEmpty(nombreCelula))
                                {
                                    try
                                    {
                                        string queryCelulaId = @"
                                    SELECT TOP 1 CelulaID 
                                    FROM dbo.pmc_Celulas 
                                    WHERE Celula LIKE @CelulaNombre";

                                        using (SqlCommand commandCelula = new SqlCommand(queryCelulaId, connection))
                                        {
                                            commandCelula.Parameters.AddWithValue("@CelulaNombre", "%" + nombreCelula + "%");

                                            object result = commandCelula.ExecuteScalar();
                                            if (result != null && result != DBNull.Value)
                                            {
                                                tempCelulaId = result;
                                            }
                                        }
                                    }
                                    catch (SqlException)
                                    {
                                        // No es un error critico
                                    }
                                }

                                celulaId = tempCelulaId;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowStatusMessage($"Error obteniendo datos de Acabados: {ex.Message}", false);
                        tableId = DBNull.Value;
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int registrosGuardados = 0;

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataRow row in itemsDesperdicioTable.Rows)
                            {
                                int cantidad = Convert.ToInt32(row["CantidadDesperdicio"]);
                                if (cantidad > 0)
                                {
                                    string item = row["Item"].ToString();
                                    string descripcion = row["Description"]?.ToString() ?? "";
                                    string typeMaterial = row["TypeMaterial"]?.ToString() ?? "";

                                    using (SqlCommand command = new SqlCommand(@"
                                INSERT INTO dbo.pmc_WasteLog (
                                    TraceId, Saca, MillStyle, Size, Color, Item, Quantity,
                                    Machine, Cell, TableNumber, Area, Reason, Operador, LogDate
                                ) VALUES (
                                    @TraceId, @Saca, @MillStyle, @Size, @Color, @Item, @Quantity,
                                    @Machine, @Cell, @TableNumber, @Area, @Reason, @Operador, GETDATE()
                                )", connection, transaction))
                                    {
                                        command.Parameters.AddWithValue("@TraceId", traceId);
                                        command.Parameters.AddWithValue("@Saca", saca);
                                        command.Parameters.AddWithValue("@MillStyle", !string.IsNullOrEmpty(millStyle) ? (object)millStyle : DBNull.Value);
                                        command.Parameters.AddWithValue("@Size", !string.IsNullOrEmpty(size) ? (object)size : DBNull.Value);
                                        command.Parameters.AddWithValue("@Color", !string.IsNullOrEmpty(color) ? (object)color : DBNull.Value);
                                        command.Parameters.AddWithValue("@Item", item);
                                        command.Parameters.AddWithValue("@Quantity", cantidad);
                                        command.Parameters.AddWithValue("@Machine", machineCode);
                                        command.Parameters.AddWithValue("@Cell", celulaId);
                                        command.Parameters.AddWithValue("@TableNumber", tableId);
                                        command.Parameters.AddWithValue("@Area", areaSeleccionada);
                                        command.Parameters.AddWithValue("@Reason", cmbDespMotivo.SelectedItem.ToString());
                                        command.Parameters.AddWithValue("@Operador", txtDespOperador.Text.Trim());

                                        command.ExecuteNonQuery();
                                        registrosGuardados++;
                                    }
                                }
                            }
                            transaction.Commit();
                            ShowStatusMessage($"✓ Desperdicios registrados exitosamente: {registrosGuardados} items, {totalDesperdicio} unidades");
                            LimpiarFormularioDesperdicioCompleto();

                            // Volver al módulo principal
                            OcultarModuloDesperdicios();
                            txtTraceID.Focus();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error en transacción: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"✗ Error guardando desperdicios: {ex.Message}", true);
            }
        }

        private void LimpiarFormularioDesperdicioCompleto()
        {
            txtDespTraceID.Text = "";
            txtDespSaca.Text = "";
            cmbDespArea.SelectedIndex = -1;
            cmbDespMotivo.Items.Clear();
            cmbDespMotivo.SelectedIndex = -1;
            txtDespOperador.Text = "";
            GridItemsDesperdicioOut.DataSource = null;
            GridItemsDesperdicioOut.MasterTemplate.Columns.Clear();
            datosDesperdicio = null;
            itemsDesperdicioTable = null;

            ControlarCamposDesperdicio(true);

            txtDespTraceID.Focus();
            ShowStatusMessage("Listo para nuevo registro de desperdicio");
        }

        private class DesperdicioData
        {
            public string TraceId { get; set; }
            public string Saca { get; set; }
            public string MillStyle { get; set; }
            public string Size { get; set; }
            public string Color { get; set; }
            public int? TableNumber { get; set; }
        }

        #endregion

        #region Módulo Principal (GridItemsOut)

        private void VentanaForm_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                txtTraceID.Focus();
                txtTraceID.Select();
                txtTraceID.SelectAll();
                ShowStatusMessage("[+] - Ventana Lista!");
            }));
        }

        private void TxtCarnetDescontar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ConfirmTransaction();
            }
        }

        private void TxtTraceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txtTraceID.Text) && long.TryParse(txtTraceID.Text, out long traceId))
                {
                    //UpdateTraceIDLabel(txtTraceID.Text);
                    LoadTransactionData();
                }
                else
                {
                    ShowStatusMessage("Por favor ingrese un ID válido", true);
                }
            }
        }

        #region Validación de Carnet
        private bool ValidarCarnetEmpleado(string carnet)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(carnet))
                {
                    ShowStatusMessage("El carnet no puede estar vacío", true);
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM mst_Empleados WHERE Emp_ID = @Carnet", connection))
                    {
                        command.Parameters.AddWithValue("@Carnet", carnet.Trim());
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            ShowStatusMessage($"Carnet '{carnet}' no es válido", true);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error validando carnet", true);
                return false;
            }
        }

        private bool ValidarCarnetAntesDeConfirmar(string carnet, Control controlParaFocus = null)
        {
            if (!ValidarCarnetEmpleado(carnet))
            {
                if (controlParaFocus != null && !controlParaFocus.IsDisposed)
                {
                    controlParaFocus.Focus();
                    controlParaFocus.Select();
                }
                return false;
            }
            return true;
        }
        #endregion

        private string GetWindowsUser()
        {
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                string userName = currentUser.Name;

                if (userName.Contains('\\'))
                {
                    userName = userName.Split('\\')[1];
                }

                return userName.ToLower();
            }
            catch (Exception ex)
            {
                return "unknown";
            }
        }

        private bool TransactionExists(int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT COUNT(*) FROM ES_SOCKS.dbo.pmc_Transactions WHERE TraceID = @TraceID", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error verificando transacción: {ex.Message}", true);
                return false;
            }
        }

        private void UpdateTransactionStatusToVentana(int traceId)
        {
            try
            {
                string windowsUser = GetWindowsUser();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_ChangeTransactionStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        command.Parameters.AddWithValue("@NewStatusID", 6);
                        command.Parameters.AddWithValue("@Badge", windowsUser);

                        connection.Open();
                        command.ExecuteNonQuery();

                        ShowStatusMessage($"Estado actualizado - Usuario: {windowsUser}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar estado a Ventana: {ex.Message}");
            }
        }

        private void LoadTransactionData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTraceID.Text))
                {
                    ShowStatusMessage("Por favor ingrese un ID válido", false, true);
                    return;
                }

                if (!int.TryParse(txtTraceID.Text, out int idBuscado))
                {
                    ShowStatusMessage("El ID no es válido", false, true);
                    return;
                }

                if (!VerificarIDExistenteEnCheckPoint(idBuscado, buscarPorTraceID))
                {
                    string tipoID = buscarPorTraceID ? "TraceID Knitting/Dye" : "TraceID Finishing";
                    ShowStatusMessage($"El {tipoID} ingresado no encontrado", true);
                    txtTraceID.SelectAll();
                    txtTraceID.Focus();
                    currentTraceId = 0;
                    return;
                }

                int traceIdReal = 0;

                if (buscarPorTraceID)
                {
                    traceIdReal = idBuscado;

                    if (!TransactionExists(traceIdReal))
                    {
                        ShowStatusMessage("El TraceID ingresado no existe en transacciones", true);
                        txtTraceID.SelectAll();
                        txtTraceID.Focus();
                        currentTraceId = 0;
                        return;
                    }
                }
                else
                {
                    traceIdReal = ObtenerTraceIDDesdeRelatedID(idBuscado);

                    if (traceIdReal == 0)
                    {
                        ShowStatusMessage($"No se encontró un TraceID relacionado", true);
                        txtTraceID.SelectAll();
                        txtTraceID.Focus();
                        currentTraceId = 0;
                        return;
                    }

                    ShowStatusMessage($"TraceID Finishing {idBuscado} → TraceID {traceIdReal}");
                }

                ControlarCamposDesperdicio(false);

                currentTraceId = traceIdReal;
                //UpdateTransactionStatusToVentana(traceIdReal);
                LoadTransactionDetails(traceIdReal);

                if (GridItemsOut.Rows.Count > 0)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        SaltarAlGridInmediatamente();
                    }));
                }

                ShowStatusMessage("- Listo para procesar");

            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al cargar los datos: {ex.Message}", true);
            }
        }

        private int ObtenerTraceIDDesdeRelatedID(int relatedID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(tracerConnectionString))
                {
                    connection.Open();

                    // ESCENARIO 1: El usuario ingresó un RelatedID (Finishing) - Buscar el TraceID
                    string query = @"
                        SELECT TOP 1 TraceID 
                        FROM CheckPointTrans 
                        WHERE RelatedID = @RelatedID
                        AND ChkID = 'FIN-BASC'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RelatedID", relatedID);
                        var result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int traceID = Convert.ToInt32(result);
                            if (traceID > 0)
                            {
                                ShowStatusMessage($"✓ RelatedID {relatedID} → TraceID {traceID} (FIN-BASC)");
                                return traceID;
                            }
                        }
                    }

                    // ESCENARIO 2: El usuario ingresó un TraceID (Knitting/Dye) - Buscar el RelatedID
                    query = @"
                        SELECT TOP 1 RelatedID 
                        FROM CheckPointTrans 
                        WHERE TraceID = @RelatedID
                        AND ChkID = 'FIN-BASC'
                        AND RelatedID IS NOT NULL
                        AND RelatedID > 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RelatedID", relatedID);
                        var result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int traceID = Convert.ToInt32(result);
                            if (traceID > 0)
                            {
                                //ShowStatusMessage($"TraceID {relatedID} → RelatedID {traceID} (modo inverso)");
                                return traceID;
                            }
                        }
                    }

                    ShowStatusMessage($"✗ No se encontró relación para ID {relatedID}", true);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al obtener TraceID desde FinishingID: {ex.Message}", true);
                return 0;
            }
        }

        private void LoadTransactionDetails(int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetTransaction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TraceID", traceId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            txtSACA.Text = reader["SACA"]?.ToString() ?? "";
                            txtSACAseg.Text = reader["SACASeg"]?.ToString() ?? "";
                            txtDocenas.Text = reader["Dozens"]?.ToString() ?? "";
                            txtMesaAsignada.Text = reader["TableNumber"]?.ToString() ?? "";
                            currentTransactionId = Convert.ToInt32(reader["TransactionID"]);
                        }
                        else
                        {
                            throw new Exception("No se encontraron datos para el ID proporcionado.");
                        }

                        reader.NextResult();

                        itemsDataTable = new DataTable();

                        if (!itemsDataTable.Columns.Contains("SobrantesDisponibles"))
                            itemsDataTable.Columns.Add("SobrantesDisponibles", typeof(string));

                        if (!itemsDataTable.Columns.Contains("DescontarSobrantes"))
                            itemsDataTable.Columns.Add("DescontarSobrantes", typeof(decimal));

                        if (!itemsDataTable.Columns.Contains("ConfirmationStatus"))
                        {
                            var statusColumn = itemsDataTable.Columns.Add("ConfirmationStatus", typeof(string));
                            statusColumn.ReadOnly = false;
                            statusColumn.MaxLength = 50;
                            statusColumn.DefaultValue = "Pendiente";
                        }

                        itemsDataTable.Load(reader);

                        foreach (DataRow row in itemsDataTable.Rows)
                        {
                            row["QuantityREAL"] = 0m;

                            if (row["SobrantesDisponibles"] == DBNull.Value)
                                row["SobrantesDisponibles"] = "0";

                            if (row["DescontarSobrantes"] == DBNull.Value)
                                row["DescontarSobrantes"] = 0m;
                        }

                        LoadVentanaInventoryData();
                        LoadSobrantesData();
                        ConfigureGridColumns();

                        var bindingSource = new BindingSource();
                        bindingSource.DataSource = itemsDataTable;
                        GridItemsOut.DataSource = bindingSource;

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar detalles: {ex.Message}");
            }
        }

        private void LoadVentanaInventoryData()
        {
            if (itemsDataTable == null) return;

            if (!itemsDataTable.Columns.Contains("Inventory"))
                itemsDataTable.Columns.Add("Inventory", typeof(decimal));

            if (!itemsDataTable.Columns.Contains("Location"))
                itemsDataTable.Columns.Add("Location", typeof(string));

            if (!itemsDataTable.Columns.Contains("InventoryDisplay"))
                itemsDataTable.Columns.Add("InventoryDisplay", typeof(string));

            if (!itemsDataTable.Columns.Contains("Existencia"))
                itemsDataTable.Columns.Add("Existencia", typeof(string));

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        string itemCode = row["ItemCode"].ToString().Trim();

                        string inventoryQuery = @"
                            SELECT
                                IP.Code,
                                SB.sub_descripcion AS Description,
                                IP.TotalQuantity,
                                IP.Location
                            FROM ES_SOCKS.dbo.pmc_InventoryPreparation IP
                            INNER JOIN ES_SOCKS.dbo.pmc_Warehouse W ON IP.WarehouseID = W.WarehouseID
                            OUTER APPLY (
                                SELECT TOP 1 sub_descripcion
                                FROM ES_SOCKS.dbo.pmc_Subida_BOM SB
                                WHERE SB.sub_producto = IP.Code
                            ) SB
                            WHERE IP.Code = @ItemCode
                            AND W.WarehouseCode = 'VENT'";

                        using (SqlCommand inventoryCommand = new SqlCommand(inventoryQuery, connection))
                        {
                            inventoryCommand.Parameters.AddWithValue("@ItemCode", itemCode);

                            using (SqlDataReader inventoryReader = inventoryCommand.ExecuteReader())
                            {
                                if (inventoryReader.Read())
                                {
                                    decimal inventoryQuantity = 0;
                                    if (inventoryReader["TotalQuantity"] != DBNull.Value)
                                    {
                                        inventoryQuantity = Convert.ToDecimal(inventoryReader["TotalQuantity"]);
                                    }

                                    decimal quantityBOM = Convert.ToDecimal(row["QuantityBOM"]);

                                    row["Inventory"] = inventoryQuantity;
                                    row["Location"] = inventoryReader["Location"]?.ToString() ?? "No ubicado";

                                    string descripcion = inventoryReader["Description"]?.ToString();
                                    if (string.IsNullOrEmpty(descripcion))
                                    {
                                        row["Existencia"] = "No Disponible";
                                        row["InventoryDisplay"] = "No Disponible";
                                    }
                                    else
                                    {
                                        row["Existencia"] = "Disponible";

                                        if (inventoryQuantity <= 0)
                                        {
                                            row["Existencia"] = "No Disponible";
                                            row["InventoryDisplay"] = "No Disponible";
                                        }
                                        else if (inventoryQuantity < quantityBOM)
                                        {
                                            row["InventoryDisplay"] = $"Insuficiente ({Math.Round(inventoryQuantity):N0})";
                                        }
                                        else
                                        {
                                            row["InventoryDisplay"] = Math.Round(inventoryQuantity).ToString("N0");
                                        }
                                    }
                                }
                                else
                                {
                                    row["Inventory"] = 0;
                                    row["Location"] = "No en ventana";
                                    row["InventoryDisplay"] = "No Disponible";
                                    row["Existencia"] = "No Disponible";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error cargando inventario VENTANA: {ex.Message}", true);
            }
        }

        private void LoadSobrantesData()
        {
            if (itemsDataTable == null) return;

            try
            {
                string sacaActual = txtSACA.Text.Trim();

                if (string.IsNullOrEmpty(sacaActual))
                {
                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        row["SobrantesDisponibles"] = "No Disponible";
                        row["DescontarSobrantes"] = 0m;
                    }
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        string itemCode = row["ItemCode"].ToString().Trim();

                        string query = @"
                            SELECT ISNULL(SUM(Quantity), 0) as TotalSobrantes
                            FROM dbo.pmc_InventoryOverstock 
                            WHERE Saca = @Saca 
                            AND Item = @Item";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Saca", sacaActual);
                            command.Parameters.AddWithValue("@Item", itemCode);

                            object result = command.ExecuteScalar();
                            decimal totalSobrantes = result != null ? Convert.ToDecimal(result) : 0m;

                            if (totalSobrantes > 0)
                            {
                                row["SobrantesDisponibles"] = Math.Round(totalSobrantes).ToString("N0");
                            }
                            else
                            {
                                row["SobrantesDisponibles"] = "No Disponible";
                            }
                            row["DescontarSobrantes"] = 0m;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error cargando sobrantes: {ex.Message}", true);
                foreach (DataRow row in itemsDataTable.Rows)
                {
                    row["SobrantesDisponibles"] = "No Disponible";
                    row["DescontarSobrantes"] = 0m;
                }
            }
        }

        private void ConfigureGridColumns()
        {
            if (GridItemsOut.InvokeRequired)
            {
                if (!GridItemsOut.IsDisposed && GridItemsOut.IsHandleCreated)
                {
                    GridItemsOut.Invoke(new Action(ConfigureGridColumns));
                }
                return;
            }

            GridItemsOut.MasterTemplate.Columns.Clear();

            // COLUMNA ID (oculta)
            var detailIdColumn = new GridViewTextBoxColumn();
            detailIdColumn.FieldName = "DetailID";
            detailIdColumn.HeaderText = "ID";
            detailIdColumn.Name = "DetailID";
            detailIdColumn.Width = 60;
            detailIdColumn.IsVisible = false;
            GridItemsOut.MasterTemplate.Columns.Add(detailIdColumn);

            // COLUMNA CÓDIGO DE ITEM
            var itemCodeColumn = new GridViewTextBoxColumn();
            itemCodeColumn.FieldName = "ItemCode";
            itemCodeColumn.HeaderText = "Código de Item";
            itemCodeColumn.Name = "ItemCode";
            itemCodeColumn.Width = 150;
            itemCodeColumn.ReadOnly = true;
            GridItemsOut.MasterTemplate.Columns.Add(itemCodeColumn);

            // COLUMNA DESCRIPCIÓN
            var descriptionColumn = new GridViewTextBoxColumn();
            descriptionColumn.FieldName = "Description";
            descriptionColumn.HeaderText = "Descripción";
            descriptionColumn.Name = "Description";
            descriptionColumn.Width = 200;
            descriptionColumn.ReadOnly = true;
            GridItemsOut.MasterTemplate.Columns.Add(descriptionColumn);

            // COLUMNA CANTIDAD BOM
            var quantityBOMColumn = new GridViewTextBoxColumn();
            quantityBOMColumn.FieldName = "QuantityBOM";
            quantityBOMColumn.HeaderText = "Cantidad BOM";
            quantityBOMColumn.Name = "QuantityBOM";
            quantityBOMColumn.Width = 120;
            quantityBOMColumn.ReadOnly = true;
            quantityBOMColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(quantityBOMColumn);

            // COLUMNA CANTIDAD REAL
            var quantityREALColumn = new GridViewTextBoxColumn();
            quantityREALColumn.FieldName = "QuantityREAL";
            quantityREALColumn.HeaderText = "Cantidad Real";
            quantityREALColumn.Name = "QuantityREAL";
            quantityREALColumn.Width = 120;
            quantityREALColumn.ReadOnly = false;
            quantityREALColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(quantityREALColumn);

            // COLUMNA EXISTENCIA
            var existenciaColumn = new GridViewTextBoxColumn();
            existenciaColumn.FieldName = "Existencia";
            existenciaColumn.HeaderText = "Existencia";
            existenciaColumn.Name = "Existencia";
            existenciaColumn.Width = 100;
            existenciaColumn.ReadOnly = true;
            existenciaColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            GridItemsOut.MasterTemplate.Columns.Add(existenciaColumn);

            // COLUMNA INVENTARIO
            var inventoryColumn = new GridViewTextBoxColumn();
            inventoryColumn.FieldName = "InventoryDisplay";
            inventoryColumn.HeaderText = "Inventario VENT";
            inventoryColumn.Name = "Inventory";
            inventoryColumn.Width = 100;
            inventoryColumn.ReadOnly = true;
            inventoryColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(inventoryColumn);

            // COLUMNA LOCALIDAD
            var locationColumn = new GridViewTextBoxColumn();
            locationColumn.FieldName = "Location";
            locationColumn.HeaderText = "Localidad";
            locationColumn.Name = "Location";
            locationColumn.Width = 100;
            locationColumn.ReadOnly = true;
            GridItemsOut.MasterTemplate.Columns.Add(locationColumn);

            // COLUMNA ESTADO
            var confirmationStatusColumn = new GridViewTextBoxColumn();
            confirmationStatusColumn.FieldName = "ConfirmationStatus";
            confirmationStatusColumn.HeaderText = "Estado";
            confirmationStatusColumn.Name = "ConfirmationStatus";
            confirmationStatusColumn.Width = 120;
            confirmationStatusColumn.ReadOnly = true;
            confirmationStatusColumn.IsVisible = false;
            GridItemsOut.MasterTemplate.Columns.Add(confirmationStatusColumn);

            // COLUMNA: USAR SOBRANTES
            var descontarSobrantesColumn = new GridViewTextBoxColumn();
            descontarSobrantesColumn.FieldName = "DescontarSobrantes";
            descontarSobrantesColumn.HeaderText = "Sobrantes";
            descontarSobrantesColumn.Name = "DescontarSobrantes";
            descontarSobrantesColumn.Width = 100;
            descontarSobrantesColumn.ReadOnly = false;
            descontarSobrantesColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(descontarSobrantesColumn);

            // COLUMNA: SOBRANTES DISPONIBLES
            var sobrantesDisponiblesColumn = new GridViewTextBoxColumn();
            sobrantesDisponiblesColumn.FieldName = "SobrantesDisponibles";
            sobrantesDisponiblesColumn.HeaderText = "Sobrantes Disp.";
            sobrantesDisponiblesColumn.Name = "SobrantesDisponibles";
            sobrantesDisponiblesColumn.Width = 100;
            sobrantesDisponiblesColumn.ReadOnly = true;
            sobrantesDisponiblesColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(sobrantesDisponiblesColumn);

            // Configurar propiedades del grid
            GridItemsOut.MasterTemplate.AllowAddNewRow = false;
            GridItemsOut.MasterTemplate.AllowDeleteRow = false;
            GridItemsOut.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            GridItemsOut.MasterTemplate.EnableAlternatingRowColor = true;
            GridItemsOut.MasterTemplate.EnableFiltering = true;
            GridItemsOut.MasterTemplate.ShowFilteringRow = false;
            GridItemsOut.ShowGroupPanel = false;
        }

        #region Eventos del Grid (GridItemsOut)
        private void GridItemsOut_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "QuantityREAL" && e.Row is GridViewDataRowInfo row)
            {
                if (e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    string input = e.Value.ToString();

                    if (!decimal.TryParse(input, out decimal result))
                    {
                        e.Cancel = true;
                        ShowStatusMessage("Formato inválido - Solo se permiten números", true);

                        this.BeginInvoke(new Action(() =>
                        {
                            row.Cells["QuantityREAL"].Value = 0;
                            GridItemsOut.CurrentRow = row;
                            GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["QuantityREAL"];
                            GridItemsOut.BeginEdit();
                        }));
                        return;
                    }

                    if (result < 0)
                    {
                        e.Cancel = true;
                        ShowStatusMessage("No se permiten valores negativos", true);

                        this.BeginInvoke(new Action(() =>
                        {
                            row.Cells["QuantityREAL"].Value = 0;
                            GridItemsOut.CurrentRow = row;
                            GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["QuantityREAL"];
                            GridItemsOut.BeginEdit();
                        }));
                        return;
                    }

                    var inventoryValue = row.Cells["Inventory"].Value;
                    if (inventoryValue != null && decimal.TryParse(inventoryValue.ToString(), out decimal inventory))
                    {
                        if (result > inventory)
                        {
                            e.Cancel = true;
                            ShowStatusMessage($"No puede descontar más del stock disponible. Disponible: {Math.Round(inventory)} unidades", true);

                            this.BeginInvoke(new Action(() =>
                            {
                                row.Cells["QuantityREAL"].Value = 0;
                                GridItemsOut.CurrentRow = row;
                                GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["QuantityREAL"];
                                GridItemsOut.BeginEdit();
                            }));
                            return;
                        }
                    }
                }
            }

            if (e.Column != null && e.Column.Name == "DescontarSobrantes" && e.Row is GridViewDataRowInfo rowSobrantes)
            {
                if (e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    string input = e.Value.ToString().Trim();

                    if (!decimal.TryParse(input, out decimal result))
                    {
                        e.Cancel = true;
                        ShowStatusMessage("Formato inválido en sobrantes - Solo se permiten números", true);

                        this.BeginInvoke(new Action(() =>
                        {
                            rowSobrantes.Cells["DescontarSobrantes"].Value = 0m;
                            GridItemsOut.CurrentRow = rowSobrantes;
                            GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];
                            GridItemsOut.BeginEdit();
                        }));
                        return;
                    }

                    if (result < 0)
                    {
                        e.Cancel = true;
                        ShowStatusMessage("No se permiten valores negativos en sobrantes", true);

                        this.BeginInvoke(new Action(() =>
                        {
                            rowSobrantes.Cells["DescontarSobrantes"].Value = 0m;
                            GridItemsOut.CurrentRow = rowSobrantes;
                            GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];
                            GridItemsOut.BeginEdit();
                        }));
                        return;
                    }

                    var sobrantesDisponiblesValue = rowSobrantes.Cells["SobrantesDisponibles"].Value;
                    if (sobrantesDisponiblesValue != null && sobrantesDisponiblesValue != DBNull.Value &&
                        sobrantesDisponiblesValue.ToString() != "No Disponible")
                    {
                        if (decimal.TryParse(sobrantesDisponiblesValue.ToString().Replace(",", ""), out decimal sobrantesDisponibles))
                        {
                            if (result > sobrantesDisponibles)
                            {
                                e.Cancel = true;
                                ShowStatusMessage($"No puede usar más de {Math.Round(sobrantesDisponibles)} sobrantes disponibles", true);

                                this.BeginInvoke(new Action(() =>
                                {
                                    rowSobrantes.Cells["DescontarSobrantes"].Value = 0m;
                                    GridItemsOut.CurrentRow = rowSobrantes;
                                    GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];
                                    GridItemsOut.BeginEdit();
                                }));
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void GridItemsOut_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "QuantityREAL" && e.Row is GridViewDataRowInfo row)
            {
                var existenciaCell = row.Cells["Existencia"];
                var inventoryCell = row.Cells["InventoryDisplay"];

                if (existenciaCell != null && existenciaCell.Value != null &&
                    existenciaCell.Value.ToString() == "No Disponible")
                {
                    e.Cancel = true;
                    ShowStatusMessage("No se puede editar - Item sin inventario disponible en VENTANA", true);
                    return;
                }

                if (inventoryCell != null && inventoryCell.Value != null &&
                    inventoryCell.Value.ToString() == "Insuficiente")
                {
                    ShowStatusMessage("Inventario insuficiente, pero puede usar sobrantes si están disponibles", false, true);
                }
            }

            if (e.Column != null && e.Column.Name == "DescontarSobrantes" && e.Row is GridViewDataRowInfo rowSobrantes)
            {
                var sobrantesDisponiblesValue = rowSobrantes.Cells["SobrantesDisponibles"].Value;

                if (sobrantesDisponiblesValue == null || sobrantesDisponiblesValue == DBNull.Value ||
                    sobrantesDisponiblesValue.ToString() == "No Disponible")
                {
                    e.Cancel = true;
                    ShowStatusMessage("No hay sobrantes disponibles para este item", true);
                    return;
                }

                if (decimal.TryParse(sobrantesDisponiblesValue.ToString().Replace(",", ""), out decimal sobrantesDisponibles))
                {
                    ShowStatusMessage($"Sobrantes disponibles: {Math.Round(sobrantesDisponibles)} unidades", false, false);
                }
            }
        }

        private void GridItemsOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridItemsOut.CurrentCell != null)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                var currentCell = GridItemsOut.CurrentCell;

                if (currentCell.ColumnInfo.Name == "QuantityREAL" || currentCell.ColumnInfo.Name == "DescontarSobrantes")
                {
                    GridItemsOut.EndEdit();
                }
            }
        }

        private void GridItemsOut_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "QuantityBOM" ||
                e.CellElement.ColumnInfo.Name == "QuantityREAL" ||
                e.CellElement.ColumnInfo.Name == "Inventory")
            {
                if (e.CellElement.Value != null)
                {
                    if (e.CellElement.Value.ToString() == "Insuficiente" ||
                        e.CellElement.Value.ToString() == "No encontrado" ||
                        e.CellElement.Value.ToString() == "No Disponible")
                    {
                        e.CellElement.Text = e.CellElement.Value.ToString();
                    }
                    else if (decimal.TryParse(e.CellElement.Value.ToString(), out decimal value))
                    {
                        e.CellElement.Text = Math.Round(value).ToString("N0");
                    }
                }
            }

            if (e.CellElement.ColumnInfo.Name == "SobrantesDisponibles")
            {
                if (e.CellElement.Value != null)
                {
                    if (e.CellElement.Value.ToString() == "No Disponible")
                    {
                        e.CellElement.Text = "No Disponible";
                    }
                    else if (decimal.TryParse(e.CellElement.Value.ToString(), out decimal value))
                    {
                        e.CellElement.Text = Math.Round(value).ToString("N0");
                    }
                }
            }

            if (e.CellElement.ColumnInfo.Name == "DescontarSobrantes")
            {
                if (e.CellElement.Value != null && decimal.TryParse(e.CellElement.Value.ToString(), out decimal value))
                {
                    e.CellElement.Text = Math.Round(value).ToString("N0");
                }
            }
        }

        private void GridItemsOut_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "QuantityREAL" && e.Row is GridViewDataRowInfo row)
            {
                try
                {
                    var existenciaCell = row.Cells["Existencia"];
                    if (existenciaCell != null && existenciaCell.Value != null &&
                        existenciaCell.Value.ToString() == "No Disponible")
                    {
                        ShowStatusMessage("Item no disponible en Ventana - No se puede procesar", true);
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    var newQuantity = row.Cells["QuantityREAL"].Value;

                    if (newQuantity == null || string.IsNullOrWhiteSpace(newQuantity.ToString()))
                    {
                        ShowStatusMessage("Ingrese una cantidad válida", true);
                        row.Cells["QuantityREAL"].Value = 0;
                        UpdateDataTableQuantity(row, 0);
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    if (!decimal.TryParse(newQuantity.ToString(), out decimal quantityReal))
                    {
                        ShowStatusMessage("Formato inválido - Solo se permiten números", true);
                        row.Cells["QuantityREAL"].Value = 0;
                        UpdateDataTableQuantity(row, 0);
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    if (quantityReal < 0)
                    {
                        ShowStatusMessage("Cantidad inválida - No se permiten valores negativos", true);
                        row.Cells["QuantityREAL"].Value = 0;
                        UpdateDataTableQuantity(row, 0);
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    var inventoryValue = row.Cells["Inventory"].Value;
                    if (inventoryValue != null && decimal.TryParse(inventoryValue.ToString(), out decimal inventory))
                    {
                        if (quantityReal > inventory)
                        {
                            ShowStatusMessage($"No puede descontar más del stock disponible. Disponible: {Math.Round(inventory)} unidades", true);
                            row.Cells["QuantityREAL"].Value = 0;
                            UpdateDataTableQuantity(row, 0);
                            GridItemsOut.CancelEdit();
                            return;
                        }
                    }

                    UpdateDataTableQuantity(row, quantityReal);

                    if (quantityReal > 0)
                    {
                        ShowStatusMessage($"Cantidad establecida: {Math.Round(quantityReal)} unidades");
                    }
                    else
                    {
                        ShowStatusMessage("Cantidad establecida en 0");
                    }

                    if (e.Column != null && e.Column.Name == "QuantityREAL")
                    {
                        NavegarASiguienteFila(row.Index);
                    }

                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Error al procesar la cantidad: {ex.Message}", true);
                    GridItemsOut.CancelEdit();
                }
            }
            else if (e.Column != null && e.Column.Name == "DescontarSobrantes" && e.Row is GridViewDataRowInfo rows)
            {
                try
                {
                    var sobrantesDisponiblesValue = rows.Cells["SobrantesDisponibles"].Value;

                    if (sobrantesDisponiblesValue == null || sobrantesDisponiblesValue == DBNull.Value || sobrantesDisponiblesValue.ToString() == "No Disponible")
                    {
                        ShowStatusMessage("No hay sobrantes disponibles para este item", true);
                        rows.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(rows, 0m);
                        return;
                    }

                    decimal sobrantesDisponibles = 0m;
                    if (sobrantesDisponiblesValue != null && sobrantesDisponiblesValue != DBNull.Value &&
                        decimal.TryParse(sobrantesDisponiblesValue.ToString().Replace(",", ""), out decimal disponible))
                    {
                        sobrantesDisponibles = disponible;
                    }

                    var newSobrantesValue = rows.Cells["DescontarSobrantes"].Value;

                    if (newSobrantesValue == null || newSobrantesValue == DBNull.Value || string.IsNullOrWhiteSpace(newSobrantesValue.ToString()))
                    {
                        rows.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(rows, 0m);
                        return;
                    }

                    if (!decimal.TryParse(newSobrantesValue.ToString(), out decimal sobrantesUsar))
                    {
                        ShowStatusMessage("Formato inválido - Solo se permiten números", true);
                        rows.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(rows, 0m);
                        return;
                    }

                    if (sobrantesUsar < 0)
                    {
                        ShowStatusMessage("No se permiten valores negativos", true);
                        rows.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(rows, 0m);
                        return;
                    }

                    if (sobrantesUsar > sobrantesDisponibles)
                    {
                        ShowStatusMessage($"Excede sobrantes disponibles. Máximo: {Math.Round(sobrantesDisponibles)} unidades", false, true);
                        rows.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(rows, 0m);
                        return;
                    }

                    UpdateDataTableSobrantes(rows, sobrantesUsar);

                    if (sobrantesUsar > 0)
                    {
                        ShowStatusMessage($"Sobrantes: {Math.Round(sobrantesUsar)} unidades");
                    }

                    NavegarDesdeSobrantes(rows.Index);

                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Error al procesar sobrantes: {ex.Message}", true);
                    rows.Cells["DescontarSobrantes"].Value = 0m;
                    UpdateDataTableSobrantes(rows, 0m);
                }
            }
        }

        private void UpdateDataTableQuantity(GridViewDataRowInfo row, decimal quantity)
        {
            if (itemsDataTable != null)
            {
                var detailId = Convert.ToInt32(row.Cells["DetailID"].Value);
                var foundRows = itemsDataTable.Select($"DetailID = {detailId}");
                if (foundRows.Length > 0)
                {
                    foundRows[0]["QuantityREAL"] = quantity;
                }
            }
        }

        private void UpdateDataTableSobrantes(GridViewDataRowInfo row, decimal sobrantes)
        {
            if (itemsDataTable != null && itemsDataTable.Columns.Contains("DescontarSobrantes"))
            {
                var detailId = 0;
                if (row.Cells["DetailID"].Value != null && row.Cells["DetailID"].Value != DBNull.Value)
                {
                    detailId = Convert.ToInt32(row.Cells["DetailID"].Value);
                }

                var foundRows = itemsDataTable.Select($"DetailID = {detailId}");
                if (foundRows.Length > 0)
                {
                    foundRows[0]["DescontarSobrantes"] = sobrantes;
                }
            }
        }

        private void NavegarASiguienteFila(int currentRowIndex)
        {
            try
            {
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();

                int nextRowIndex = currentRowIndex + 1;

                for (int i = nextRowIndex; i < GridItemsOut.Rows.Count; i++)
                {
                    var nextRow = GridItemsOut.Rows[i] as GridViewDataRowInfo;
                    if (nextRow != null && EsFilaEditable(nextRow))
                    {
                        GridItemsOut.CurrentRow = nextRow;
                        GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["QuantityREAL"];

                        GridItemsOut.TableElement.ScrollToRow(i);
                        GridItemsOut.Focus();

                        GridItemsOut.BeginEdit();
                        return;
                    }
                }

                for (int i = 0; i < GridItemsOut.Rows.Count; i++)
                {
                    var nextRow = GridItemsOut.Rows[i] as GridViewDataRowInfo;
                    if (nextRow != null && TieneSobrantesDisponibles(nextRow))
                    {
                        GridItemsOut.CurrentRow = nextRow;
                        GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];

                        GridItemsOut.TableElement.ScrollToRow(i);
                        GridItemsOut.Focus();

                        GridItemsOut.BeginEdit();

                        ShowStatusMessage("→ Sobrantes");
                        return;
                    }
                }

                ShowStatusMessage("→ No hay sobrantes disponibles.");
                txtCarnetDescontar.Focus();
                txtCarnetDescontar.SelectAll();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error en navegación: {ex.Message}", true);
            }
        }

        private void NavegarDesdeSobrantes(int currentRowIndex)
        {
            try
            {
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();

                int nextRowIndex = currentRowIndex + 1;

                for (int i = nextRowIndex; i < GridItemsOut.Rows.Count; i++)
                {
                    var nextRow = GridItemsOut.Rows[i] as GridViewDataRowInfo;
                    if (nextRow != null && TieneSobrantesDisponibles(nextRow))
                    {
                        GridItemsOut.CurrentRow = nextRow;
                        GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];

                        GridItemsOut.TableElement.ScrollToRow(i);
                        GridItemsOut.Focus();

                        GridItemsOut.BeginEdit();
                        return;
                    }
                }

                ShowStatusMessage("→ Confirme la transacción con su carnet");
                txtCarnetDescontar.Focus();
                txtCarnetDescontar.SelectAll();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error en navegación: {ex.Message}", true);
            }
        }

        private bool TieneSobrantesDisponibles(GridViewDataRowInfo row)
        {
            try
            {
                var sobrantesCell = row.Cells["SobrantesDisponibles"];
                if (sobrantesCell == null || sobrantesCell.Value == null || sobrantesCell.Value == DBNull.Value)
                    return false;

                string sobrantesValue = sobrantesCell.Value.ToString();

                if (sobrantesValue == "No Disponible")
                    return false;

                if (decimal.TryParse(sobrantesValue.Replace(",", ""), out decimal sobrantes))
                {
                    return sobrantes > 0;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        private void UpdateTraceIDLabel(string traceIDText)
        {
            if (Controls.Find("lblNameID", true).FirstOrDefault() is Control lblNameID)
            {
                string tipoID = buscarPorTraceID ? "TRACE ID" : "RELATED ID";
                lblNameID.Text = $"{tipoID}: {traceIDText}";

                if (!buscarPorTraceID && currentTraceId > 0)
                {
                    lblNameID.Text += $" (TraceID: {currentTraceId})";
                }
            }
        }

        private void ShowStatusMessage(string message, bool isError = false, bool isWarning = false)
        {
            if (this.InvokeRequired)
            {
                if (!this.IsDisposed && this.IsHandleCreated)
                {
                    this.Invoke(new Action<string, bool, bool>(ShowStatusMessage), message, isError, isWarning);
                }
                return;
            }

            if (infoToolStrip == null || infoToolStrip.IsDisposed ||
                rmcStripStatus == null || rmcStripStatus.IsDisposed)
                return;

            infoToolStrip.Text = $"{DateTime.Now:hh:mm:ss tt} - {message}";

            if (isError)
            {
                infoToolStrip.ForeColor = Color.Black;
                rmcStripStatus.BackColor = RedErrorColor;
                rmcStripStatus.ForeColor = Color.Black;
            }
            else if (isWarning)
            {
                infoToolStrip.ForeColor = Color.Black;
                rmcStripStatus.BackColor = YellowAlertColor;
                rmcStripStatus.ForeColor = Color.Black;
            }
            else
            {
                rmcStripStatus.BackColor = GreenSuccessColor;
                infoToolStrip.ForeColor = Color.Black;
            }

            Timer timer = new Timer();
            timer.Interval = 30000;
            timer.Tick += (s, e) => {
                if (!infoToolStrip.IsDisposed && infoToolStrip != null)
                {
                    infoToolStrip.Text = "";
                    if (!rmcStripStatus.IsDisposed && rmcStripStatus != null)
                    {
                        rmcStripStatus.ForeColor = SystemColors.ControlText;
                        rmcStripStatus.BackColor = SystemColors.Control;
                    }
                }
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void SaltarAlGridInmediatamente()
        {
            try
            {
                if (GridItemsOut.Rows.Count == 0) return;

                var quantityRealColumn = GridItemsOut.MasterTemplate.Columns["QuantityREAL"];
                if (quantityRealColumn != null)
                {
                    int firstEditableRow = -1;
                    for (int i = 0; i < GridItemsOut.Rows.Count; i++)
                    {
                        var row = GridItemsOut.Rows[i] as GridViewDataRowInfo;
                        if (row != null && EsFilaEditable(row))
                        {
                            firstEditableRow = i;
                            break;
                        }
                    }

                    if (firstEditableRow >= 0)
                    {
                        GridItemsOut.ClearSelection();
                        GridItemsOut.Rows[firstEditableRow].IsSelected = true;
                        GridItemsOut.CurrentRow = GridItemsOut.Rows[firstEditableRow];
                        GridItemsOut.CurrentColumn = quantityRealColumn;
                        GridItemsOut.TableElement.ScrollToRow(firstEditableRow);
                        GridItemsOut.Focus();

                        Timer editTimer = new Timer();
                        editTimer.Interval = 100;
                        editTimer.Tick += (s, e) =>
                        {
                            editTimer.Stop();
                            editTimer.Dispose();

                            if (!GridItemsOut.IsDisposed && GridItemsOut.IsHandleCreated)
                            {
                                GridItemsOut.BeginEdit();
                                ShowStatusMessage("→ Listo para ingresar cantidades");
                            }
                        };
                        editTimer.Start();
                    }
                    else
                    {
                        ShowStatusMessage("No hay items disponibles con inventario suficiente", false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al saltar al grid: {ex.Message}", true);
            }
        }

        private bool EsFilaEditable(GridViewDataRowInfo row)
        {
            var existenciaCell = row.Cells["Existencia"];
            var inventoryCell = row.Cells["InventoryDisplay"];
            var sobrantesCell = row.Cells["SobrantesDisponibles"];

            if (existenciaCell != null && existenciaCell.Value != null &&
                existenciaCell.Value.ToString() == "No Disponible")
            {
                return false;
            }

            bool tieneSobrantes = false;
            if (sobrantesCell != null && sobrantesCell.Value != null &&
                sobrantesCell.Value.ToString() != "No Disponible")
            {
                if (decimal.TryParse(sobrantesCell.Value.ToString().Replace(",", ""), out decimal sobrantes) && sobrantes > 0)
                {
                    tieneSobrantes = true;
                }
            }

            if (inventoryCell != null && inventoryCell.Value != null &&
                inventoryCell.Value.ToString() == "Insuficiente" && tieneSobrantes)
            {
                return true;
            }

            if (inventoryCell != null && inventoryCell.Value != null &&
                inventoryCell.Value.ToString() == "Insuficiente" && !tieneSobrantes)
            {
                return false;
            }

            return true;
        }

        private void ProcessVentanaInventoryDiscount(string carnet)
        {
            if (itemsDataTable == null) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        decimal quantityREAL = row["QuantityREAL"] == DBNull.Value ? 0m : Convert.ToDecimal(row["QuantityREAL"]);

                        if (quantityREAL > 0)
                        {
                            string itemCode = row["ItemCode"].ToString().Trim();

                            // Actualizar inventario de VENTANA
                            string updateQuery = @"
                                UPDATE IP
                                SET IP.TotalQuantity = IP.TotalQuantity - @Cantidad,
                                    IP.ModifiedDate = SYSDATETIME(),
                                    IP.ModifiedBy = @Carnet
                                FROM ES_SOCKS.dbo.pmc_InventoryPreparation IP
                                INNER JOIN ES_SOCKS.dbo.pmc_Warehouse W ON IP.WarehouseID = W.WarehouseID
                                WHERE IP.Code = @ItemCode
                                AND W.WarehouseCode = 'VENT'";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@ItemCode", itemCode);
                                updateCommand.Parameters.AddWithValue("@Cantidad", quantityREAL);
                                updateCommand.Parameters.AddWithValue("@Carnet", carnet);

                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    RegistrarMovimientoVentana(itemCode, quantityREAL, carnet, currentTraceId);
                                    ShowStatusMessage($"Descontados {quantityREAL} unidades del item {itemCode} en VENTANA");
                                }
                                else
                                {
                                    ShowStatusMessage($"Error: No se pudo descontar del inventario VENTANA para el item {itemCode}", true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error procesando descuento de inventario VENTANA: {ex.Message}");
            }
        }

        private void RegistrarMovimientoVentana(string itemCode, decimal cantidad, string carnet, int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                INSERT INTO dbo.pmc_InventoryMovements (
                    Code, 
                    MovementType, 
                    Quantity, 
                    Warehouse, 
                    Description, 
                    CreatedBy
                ) 
                VALUES (
                    @Code,
                    'OUT',
                    @Quantity,
                    'VENT',
                    @Description,
                    @CreatedBy
                )", connection))
                    {
                        string descripcion = $"- Descuento por TraceID {traceId}";

                        command.Parameters.AddWithValue("@Code", itemCode);
                        command.Parameters.AddWithValue("@Quantity", cantidad);
                        command.Parameters.AddWithValue("@Description", descripcion);
                        command.Parameters.AddWithValue("@CreatedBy", carnet);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error registrando movimiento de VENTANA: {ex.Message}", true);
            }
        }

        private void ProcessSobrantesDiscount(int traceId, string carnet)
        {
            if (itemsDataTable == null) return;

            try
            {
                string sacaActual = txtSACA.Text.Trim();

                if (string.IsNullOrEmpty(sacaActual))
                {
                    ShowStatusMessage("No se puede procesar sobrantes", true);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        decimal descontarSobrantes = row["DescontarSobrantes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DescontarSobrantes"]);

                        if (descontarSobrantes > 0)
                        {
                            string itemCode = row["ItemCode"].ToString().Trim();

                            string checkQuery = @"
                                SELECT Id, Quantity 
                                FROM dbo.pmc_InventoryOverstock 
                                WHERE Saca = @Saca 
                                AND Item = @Item 
                                AND Quantity >= @Cantidad";

                            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@Saca", sacaActual);
                                checkCommand.Parameters.AddWithValue("@Item", itemCode);
                                checkCommand.Parameters.AddWithValue("@Cantidad", descontarSobrantes);

                                using (SqlDataReader reader = checkCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int overstockId = Convert.ToInt32(reader["Id"]);
                                        decimal currentQuantity = Convert.ToDecimal(reader["Quantity"]);
                                        reader.Close();

                                        string updateQuery = @"
                                            UPDATE dbo.pmc_InventoryOverstock 
                                            SET Quantity = Quantity - @Cantidad,
                                                UpdatedAt = SYSDATETIME(),
                                                UpdatedBy = @Carnet
                                            WHERE Id = @Id";

                                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                        {
                                            updateCommand.Parameters.AddWithValue("@Id", overstockId);
                                            updateCommand.Parameters.AddWithValue("@Cantidad", descontarSobrantes);
                                            updateCommand.Parameters.AddWithValue("@Carnet", carnet);

                                            int rowsAffected = updateCommand.ExecuteNonQuery();

                                            if (rowsAffected > 0)
                                            {
                                                RegistrarMovimientoSobrantes(itemCode, descontarSobrantes, carnet, traceId, sacaActual);
                                                ShowStatusMessage($"Descontados {descontarSobrantes} sobrantes del item {itemCode}");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                        ShowStatusMessage($"No hay suficientes sobrantes para el item {itemCode}", true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error procesando descuento de sobrantes: {ex.Message}");
            }
        }

        private void RegistrarMovimientoSobrantes(string itemCode, decimal cantidad, string carnet, int traceId, string saca)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                INSERT INTO dbo.pmc_InventoryMovements (
                    Code, 
                    MovementType, 
                    Quantity, 
                    Warehouse, 
                    Description, 
                    CreatedBy
                ) 
                VALUES (
                    @Code,
                    'OUT_SOBRANTES',
                    @Quantity,
                    'VENT',
                    @Description,
                    @CreatedBy
                )", connection))
                    {
                        string descripcion = $"- Sobrantes usados para el TraceID {traceId} - Saca {saca} - cantidad {cantidad}";

                        command.Parameters.AddWithValue("@Code", itemCode);
                        command.Parameters.AddWithValue("@Quantity", cantidad);
                        command.Parameters.AddWithValue("@Description", descripcion);
                        command.Parameters.AddWithValue("@CreatedBy", carnet);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error registrando movimiento de sobrantes VENTANA: {ex.Message}", true);
            }
        }

        private void ClearForm()
        {
            txtTraceID.Text = "";
            txtSACA.Text = "";
            txtSACAseg.Text = "";
            txtDocenas.Text = "";
            txtMesaAsignada.Text = "";
            txtCarnetDescontar.Text = "";
            GridItemsOut.DataSource = null;
            itemsDataTable = null;
            currentTransactionId = 0;
            currentTraceId = 0;

            // RE-HABILITAR CAMPOS DE DESPERDICIO
            ControlarCamposDesperdicio(true);

            txtTraceID.Focus();
            if (Controls.Find("lblNameID", true).FirstOrDefault() is Control lblNameID)
                lblNameID.Text = "TRACER ID";
            ShowStatusMessage("- Listo para nueva transacción");
        }

        private void VentanaForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Capturar Ctrl+X para navegar al carnet
            if (e.Control && e.KeyCode == Keys.X)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                try
                {
                    if (GridItemsOut.IsInEditMode)
                    {
                        GridItemsOut.EndEdit();
                    }

                    Timer navTimer = new Timer();
                    navTimer.Interval = 50;
                    navTimer.Tick += (s, args) =>
                    {
                        navTimer.Stop();
                        navTimer.Dispose();

                        if (txtCarnetDescontar != null && !txtCarnetDescontar.IsDisposed)
                        {
                            txtCarnetDescontar.Focus();
                            txtCarnetDescontar.Select();
                            txtCarnetDescontar.SelectAll();
                            ShowStatusMessage("→ Navegado al campo carnet VENTANA");
                        }
                    };
                    navTimer.Start();
                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Error con atajo Ctrl+X: {ex.Message}", true);
                }
            }
        }

        private void GridItemsOut_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo is GridViewDataRowInfo row)
            {
                string existencia = row.Cells["Existencia"]?.Value?.ToString();
                decimal quantityREAL = 0;
                decimal inventory = 0;

                var quantityCell = row.Cells["QuantityBOM"]?.Value;
                if (quantityCell != null)
                    decimal.TryParse(quantityCell.ToString(), out quantityREAL);

                var inventoryCell = row.Cells["Inventory"]?.Value;
                if (inventoryCell != null)
                    decimal.TryParse(inventoryCell.ToString(), out inventory);

                if (existencia == "No Disponible")
                {
                    e.RowElement.BackColor = Color.FromArgb(255, 255, 204, 204); // Rojo
                    e.RowElement.ForeColor = Color.Black;
                }
                else if (inventory < quantityREAL)
                {
                    e.RowElement.BackColor = Color.FromArgb(255, 255, 255, 204); // Amarillo
                    e.RowElement.ForeColor = Color.Black;
                }
                e.RowElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
                e.RowElement.DrawFill = true;
            }
        }

        private void ConfirmTransaction()
        {
            try
            {
                if (currentTransactionId == 0)
                {
                    ShowStatusMessage("No hay una transacción activa para confirmar", true);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCarnetDescontar.Text))
                {
                    ShowStatusMessage("Confirme la transacción con su carnet.", true);
                    txtCarnetDescontar.Focus();
                    return;
                }

                string carnet = txtCarnetDescontar.Text.Trim();

                if (!ValidarCarnetAntesDeConfirmar(carnet, txtCarnetDescontar))
                {
                    return;
                }

                bool hayCantidadesParaProcesar = false;
                if (itemsDataTable != null)
                {
                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        decimal quantityREAL = row["QuantityREAL"] == DBNull.Value ? 0m : Convert.ToDecimal(row["QuantityREAL"]);
                        decimal descontarSobrantes = row["DescontarSobrantes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DescontarSobrantes"]);

                        if (quantityREAL > 0 || descontarSobrantes > 0)
                        {
                            hayCantidadesParaProcesar = true;
                            break;
                        }
                    }
                }

                if (!hayCantidadesParaProcesar)
                {
                    ShowStatusMessage("No hay cantidades para procesar. Ingrese al menos una cantidad en 'Cantidad Real' o 'Sobrantes'", true);
                    return;
                }

                if (!ValidarInventariosAntesDeProcesar())
                {
                    return;
                }

                UpdateQuantityRealInDatabase(carnet);

                ProcessVentanaInventoryDiscount(carnet);
                ProcessSobrantesDiscount(currentTraceId, carnet);

                ShowStatusMessage("Transacción completada");
                ClearForm();

            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al confirmar la transacción: {ex.Message}", true);
            }
        }

        private bool ValidarInventariosAntesDeProcesar()
        {
            if (itemsDataTable == null) return true;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        decimal quantityREAL = row["QuantityREAL"] == DBNull.Value ? 0m : Convert.ToDecimal(row["QuantityREAL"]);
                        decimal descontarSobrantes = row["DescontarSobrantes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DescontarSobrantes"]);

                        if (quantityREAL > 0)
                        {
                            string itemCode = row["ItemCode"].ToString().Trim();

                            // Verificar stock actual en VENTANA
                            string checkQuery = @"
                                SELECT IP.TotalQuantity
                                FROM ES_SOCKS.dbo.pmc_InventoryPreparation IP
                                INNER JOIN ES_SOCKS.dbo.pmc_Warehouse W ON IP.WarehouseID = W.WarehouseID
                                WHERE IP.Code = @ItemCode
                                AND W.WarehouseCode = 'VENT'";

                            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@ItemCode", itemCode);
                                object result = checkCommand.ExecuteScalar();
                                decimal stockActual = result != null ? Convert.ToDecimal(result) : 0m;

                                if (stockActual < quantityREAL)
                                {
                                    ShowStatusMessage($"Stock insuficiente para el item {itemCode}. Disponible: {Math.Round(stockActual)}, Solicitado: {Math.Round(quantityREAL)}", true);
                                    return false;
                                }
                            }
                        }

                        if (descontarSobrantes > 0)
                        {
                            string itemCode = row["ItemCode"].ToString().Trim();
                            string sacaActual = txtSACA.Text.Trim();

                            // Verificar sobrantes actuales
                            string checkSobrantesQuery = @"
                                SELECT ISNULL(SUM(Quantity), 0) as TotalSobrantes
                                FROM dbo.pmc_InventoryOverstock 
                                WHERE Saca = @Saca 
                                AND Item = @Item";

                            using (SqlCommand checkCommand = new SqlCommand(checkSobrantesQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@Saca", sacaActual);
                                checkCommand.Parameters.AddWithValue("@Item", itemCode);
                                object result = checkCommand.ExecuteScalar();
                                decimal sobrantesActuales = result != null ? Convert.ToDecimal(result) : 0m;

                                if (sobrantesActuales < descontarSobrantes)
                                {
                                    ShowStatusMessage($"Sobrantes insuficientes para el item {itemCode}. Disponible: {Math.Round(sobrantesActuales)}, Solicitado: {Math.Round(descontarSobrantes)}", true);
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error validando inventarios: {ex.Message}", true);
                return false;
            }
        }

        private void TxtTraceIdSalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!string.IsNullOrWhiteSpace(txtTraceIdSalida.Text))
                {
                    ConfirmTransactionStatusToConsumido();
                }
            }
        }

        private void ConfirmTransactionStatusToConsumido()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTraceIdSalida.Text))
                {
                    ShowStatusMessage("Por favor ingrese un ID válido", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                if (!int.TryParse(txtTraceIdSalida.Text, out int traceId))
                {
                    ShowStatusMessage("El ID no es válido", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Validar que el TraceID existe
                if (!TransactionExists(traceId))
                {
                    ShowStatusMessage("El ID ingresado no encontrado", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Validar que no esté ya en estado 7 (Consumido)
                if (IsTransactionInStatus(traceId, 7))
                {
                    ShowStatusMessage("- No puede procesarse nuevamente", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Validar que esté en estado 6 (Ventana) antes de pasar a Consumido
                if (!IsTransactionInStatus(traceId, 6))
                {
                    ShowStatusMessage("No está en Ventana", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Obtener el carnet que se usó para descontar en Ventana
                string carnetVentana = GetBadgeForTransaction(traceId, 6);
                if (string.IsNullOrEmpty(carnetVentana))
                {
                    ShowStatusMessage($"No se puede dar salida - no fue procesado en ventana", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Cambiar estado a Consumido (7)
                //UpdateTransactionStatus(traceId, 7, carnetVentana);
                ShowStatusMessage($"Salida de Ventana - Carnet: {carnetVentana}");

                txtTraceIdSalida.Text = "";
                txtTraceIdSalida.Focus();

            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al actualizar el estado: {ex.Message}", true);
            }
        }

        private bool IsTransactionInStatus(int traceId, int statusId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM pmc_Transactions TS
                        INNER JOIN pmc_StatusTracking ST ON TS.ID = ST.TransactionID 
                        WHERE TraceID = @TraceID
                        AND ST.StatusID = @StatusID", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        command.Parameters.AddWithValue("@StatusID", statusId);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error verificando estado: {ex.Message}", true);
                return false;
            }
        }

        private string GetBadgeForTransaction(int traceId, int statusId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT ST.Badge
                        FROM pmc_Transactions TS
                        INNER JOIN pmc_StatusTracking ST ON TS.ID = ST.TransactionID 
                        WHERE TS.TraceID = @TraceID
                        AND ST.StatusID = @StatusID", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        command.Parameters.AddWithValue("@StatusID", statusId);
                        connection.Open();

                        var result = command.ExecuteScalar();
                        return result?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error obteniendo carnet: {ex.Message}", true);
                return "";
            }
        }

        private void UpdateTransactionStatus(int traceId, int statusId, string badge)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_ChangeTransactionStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        command.Parameters.AddWithValue("@NewStatusID", statusId);
                        command.Parameters.AddWithValue("@Badge", badge);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar estado: {ex.Message}");
            }
        }

        private void UpdateQuantityRealInDatabase(string carnet)
        {
            if (itemsDataTable == null) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        int detailId = Convert.ToInt32(row["DetailID"]);
                        decimal quantityREAL = row["QuantityREAL"] == DBNull.Value ? 0m : Convert.ToDecimal(row["QuantityREAL"]);

                        string updateQuery = @"
                            UPDATE dbo.pmc_TransactionDetails 
                            SET QuantityREAL = @QuantityREAL,
                                ConfirmationDate = SYSDATETIME()
                            WHERE DetailID = @DetailID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@DetailID", detailId);
                            updateCommand.Parameters.AddWithValue("@QuantityREAL", quantityREAL);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error actualizando QuantityREAL en base de datos: {ex.Message}");
            }
        }
        #endregion

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                bool modoBusquedaOriginal = buscarPorTraceID;

                txtTraceID.Text = "";
                txtSACA.Text = "";
                txtSACAseg.Text = "";
                txtDocenas.Text = "";
                txtMesaAsignada.Text = "";
                txtCarnetDescontar.Text = "";
                txtTraceIdSalida.Text = "";

                txtDespTraceID.Text = "";
                txtDespSaca.Text = "";
                txtDespOperador.Text = "";
                cmbDespArea.SelectedIndex = -1;
                cmbDespMotivo.Items.Clear();
                cmbDespMotivo.SelectedIndex = -1;
                cmbDespMotivo.Enabled = false;

                if (itemsDataTable != null)
                {
                    itemsDataTable.Dispose();
                    itemsDataTable = null;
                }
                currentTransactionId = 0;
                currentTraceId = 0;

                datosDesperdicio = null;
                if (itemsDesperdicioTable != null)
                {
                    itemsDesperdicioTable.Dispose();
                    itemsDesperdicioTable = null;
                }

                if (moduloDesperdiciosActivo)
                {
                    OcultarModuloDesperdicios();
                }

                LimpiarGridConColumnas();

                if (checkID != null)
                {
                    checkID.Checked = modoBusquedaOriginal;
                    buscarPorTraceID = modoBusquedaOriginal;
                    checkID.Text = buscarPorTraceID ? "Buscar por TraceID Knitting/Dye" : "Buscar por TraceID Finishing";
                }

                ConfigurarComboBoxAreas();
                ControlarCamposDesperdicio(true);
                if (Controls.Find("lblNameID", true).FirstOrDefault() is Control lblNameID)
                {
                    string tipoID = buscarPorTraceID ? "TRACE ID" : "RELATED ID";
                    lblNameID.Text = $"{tipoID}:";
                }

                ShowStatusMessage("Formulario reiniciado completamente", false, false);
                txtTraceID.Focus();
                txtTraceID.SelectAll();

                this.Refresh();

            }
            catch (Exception ex)
            {
                ShowStatusMessage($"✗ Error al reiniciar formulario: {ex.Message}", true);
            }
        }

        private void LimpiarGridConColumnas()
        {
            try
            {
                if (GridItemsOut != null && !GridItemsOut.IsDisposed)
                {
                    GridItemsOut.BeginUpdate();

                    GridItemsOut.DataSource = null;

                    if (GridItemsOut.MasterTemplate.Columns.Count == 0)
                    {
                        ConfigureGridColumns();
                    }
                    else
                    {
                        GridItemsOut.Rows.Clear();
                    }

                    GridItemsOut.ClearSelection();
                    GridItemsOut.CurrentRow = null;
                    GridItemsOut.CurrentColumn = null;

                    GridItemsOut.EndUpdate();
                    GridItemsOut.Refresh();
                }

                if (GridItemsDesperdicioOut != null && !GridItemsDesperdicioOut.IsDisposed)
                {
                    GridItemsDesperdicioOut.BeginUpdate();

                    GridItemsDesperdicioOut.DataSource = null;

                    if (GridItemsDesperdicioOut.Visible)
                    {
                        if (GridItemsDesperdicioOut.MasterTemplate.Columns.Count == 0)
                        {
                            DataTable dtEmpty = new DataTable();
                            dtEmpty.Columns.Add("DetailID", typeof(int));
                            dtEmpty.Columns.Add("Item", typeof(string));
                            dtEmpty.Columns.Add("Description", typeof(string));
                            dtEmpty.Columns.Add("TypeMaterial", typeof(string));
                            dtEmpty.Columns.Add("CantidadDesperdicio", typeof(int));
                            dtEmpty.Columns.Add("Codigo", typeof(string));
                            dtEmpty.Columns.Add("Localidad", typeof(string));

                            var bindingSource = new BindingSource();
                            bindingSource.DataSource = dtEmpty;
                            GridItemsDesperdicioOut.DataSource = bindingSource;

                            ConfigurarGridParaDesperdicios();
                        }
                    }
                    else
                    {
                        GridItemsDesperdicioOut.Rows.Clear();
                    }

                    GridItemsDesperdicioOut.ClearSelection();
                    GridItemsDesperdicioOut.CurrentRow = null;
                    GridItemsDesperdicioOut.CurrentColumn = null;

                    GridItemsDesperdicioOut.EndUpdate();
                    GridItemsDesperdicioOut.Refresh();
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error limpiando grids: {ex.Message}", true);
            }
        }
    }
}