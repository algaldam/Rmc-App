using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Inventario
{
    public partial class PreparacionForm : Telerik.WinControls.UI.RadForm
    {
        private DataTable itemsDataTable;
        private int currentTransactionId = 0;
        private int currentTraceId = 0;
        private DateTime lastScanTime = DateTime.MinValue;
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;

        private readonly Color YellowAlertColor = Color.FromArgb(255, 255, 204);
        private readonly Color GreenSuccessColor = Color.FromArgb(204, 255, 204);
        private readonly Color RedErrorColor = Color.FromArgb(255, 204, 204);

        public PreparacionForm()
        {
            InitializeComponent();
            ConfigureGrid();

            this.KeyPreview = true;
            //txtTraceID.TextChanged += TxtTraceID_TextChanged;
        }

        private void PreparacionForm_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                txtTraceID.Focus();
                txtTraceID.Select();
                txtTraceID.SelectAll();
                ShowStatusMessage("[+] - Todo Listo!");
            }));
        }

        private void TxtTraceID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTraceID.Text) && long.TryParse(txtTraceID.Text, out long traceId))
            {
                UpdateTraceIDLabel(txtTraceID.Text);
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => lblNameID.Text = "TRACER ID"));
                }
                else
                {
                    lblNameID.Text = "TRACER ID";
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

        private void ConfigureGrid()
        {
            GridItemsOut.MasterTemplate.AllowAddNewRow = false;
            GridItemsOut.MasterTemplate.AllowDeleteRow = false;
            GridItemsOut.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            GridItemsOut.MasterTemplate.EnableAlternatingRowColor = true;
            GridItemsOut.MasterTemplate.EnableFiltering = true;
            GridItemsOut.MasterTemplate.ShowFilteringRow = false;
            GridItemsOut.ShowGroupPanel = false;

            GridItemsOut.CellEndEdit += GridItemsOut_CellEndEdit;
            GridItemsOut.KeyDown += GridItemsOut_KeyDown;
            GridItemsOut.CellFormatting += GridItemsOut_CellFormatting;
            GridItemsOut.CellBeginEdit += GridItemsOut_CellBeginEdit;
            GridItemsOut.CellValidating += GridItemsOut_CellValidating;

            GridItemsOut.CellEndEdit += GridItemsOut_CellEndEdit_Sobrantes;
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

        private void PreparacionForm_KeyDown(object sender, KeyEventArgs e)
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
                            ShowStatusMessage("→ Navegado para ingresar carnet");
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

        #region Validación de Estado de Transacción

        private bool ValidateTransactionForPreparation(int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT 
                            TS.ID,
                            ST.StatusID,
                            S.statusName
                        FROM pmc_Transactions TS
                        INNER JOIN pmc_StatusTracking ST ON TS.ID = ST.TransactionID 
                        INNER JOIN pmc_Status S ON ST.StatusID = S.statusId
                        WHERE TS.TraceID = @TraceID
                        AND ST.StatusID = (SELECT MAX(StatusID) FROM pmc_StatusTracking WHERE TransactionID = TS.ID)", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ShowStatusMessage("No válido - Debe estar en estado 'Impresión'", true);
                                return false;
                            }

                            int currentStatusId = Convert.ToInt32(reader["StatusID"]);
                            string statusName = reader["statusName"].ToString();

                            if (currentStatusId == 1) // Impresión
                            {
                                return true;
                            }
                            else if (currentStatusId == 2) // Preparación
                            {
                                ShowStatusMessage("Ya está en proceso de preparación", false, true);
                                return true;
                            }
                            else if (currentStatusId > 2)
                            {
                                ShowStatusMessage($"Ya en estado '{statusName}' - No se puede procesar en preparación", true);
                                return false;
                            }
                            else
                            {
                                ShowStatusMessage($"Estado no válido para preparación: {statusName}", true);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error validando estado de transacción: {ex.Message}", true);
                return false;
            }
        }

        /// <summary>
        /// Crea la transacción si no existe y valida que esté en estado correcto
        /// </summary>
        private bool EnsureTransactionForPreparation(int traceId, string badge)
        {
            if (!TransactionExists(traceId))
            {
                ShowStatusMessage("No tiene una transacción creada. Debe generarse primero el BOM.", true);
                return false;
            }
            return ValidateTransactionForPreparation(traceId);
        }

        #endregion

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
                    ShowStatusMessage("No se puede editar - Item sin inventario disponible", true);
                    return;
                }

                if (inventoryCell != null && inventoryCell.Value != null &&
                    inventoryCell.Value.ToString() == "Insuficiente")
                {
                    ShowStatusMessage("Inventario insuficiente, pero puede usar sobrantes si están disponibles", false, true);
                }

                var inventoryValueCell = row.Cells["Inventory"];
                if (inventoryValueCell != null && inventoryValueCell.Value != null)
                {
                    if (decimal.TryParse(inventoryValueCell.Value.ToString(), out decimal inventoryValue) && inventoryValue == 0)
                    {
                        ShowStatusMessage("Sin stock, pero puede usar sobrantes si están disponibles", false, true);
                    }
                }
            }

            // Validación para DescontarSobrantes
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

                // Mostrar mensaje informativo
                if (decimal.TryParse(sobrantesDisponiblesValue.ToString().Replace(",", ""), out decimal sobrantesDisponibles))
                {
                    ShowStatusMessage($"Sobrantes disponibles: {Math.Round(sobrantesDisponibles)} unidades", false, false);
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
                    e.RowElement.BackColor = Color.FromArgb(255, 255, 204, 204); // Rojo pastel
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

        private bool EsFilaEditable(GridViewDataRowInfo row)
        {
            var existenciaCell = row.Cells["Existencia"];
            var inventoryCell = row.Cells["InventoryDisplay"];
            var sobrantesCell = row.Cells["SobrantesDisponibles"];

            // No editable si el item no existe
            if (existenciaCell != null && existenciaCell.Value != null &&
                existenciaCell.Value.ToString() == "No Disponible")
            {
                return false;
            }

            // Verificar si hay sobrantes disponibles
            bool tieneSobrantes = false;
            if (sobrantesCell != null && sobrantesCell.Value != null &&
                sobrantesCell.Value.ToString() != "No Disponible")
            {
                if (decimal.TryParse(sobrantesCell.Value.ToString().Replace(",", ""), out decimal sobrantes) && sobrantes > 0)
                {
                    tieneSobrantes = true;
                }
            }

            // Si no tiene inventario pero tiene sobrantes, PERMITIR edición
            if (inventoryCell != null && inventoryCell.Value != null &&
                inventoryCell.Value.ToString() == "Insuficiente" && tieneSobrantes)
            {
                return true;
            }

            // Si no tiene inventario y tampoco sobrantes, NO permitir
            if (inventoryCell != null && inventoryCell.Value != null &&
                inventoryCell.Value.ToString() == "Insuficiente" && !tieneSobrantes)
            {
                return false;
            }

            return true;
        }

        private void TxtTraceIdSalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!string.IsNullOrWhiteSpace(txtTraceIdSalida.Text))
                {
                    ConfirmTransactionStatusToMesa();
                }
            }
        }

        private void ConfirmTransactionStatusToMesa()
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
                    ShowStatusMessage("El ID ingresado no existe", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Validar que no esté ya en estado 3 (Mesa)
                if (IsTransactionInStatus(traceId, 3))
                {
                    ShowStatusMessage("Ya asignado a mesa - No puede procesarse nuevamente", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                // Validar que esté en estado 2 (Preparación) antes de pasar a Mesa
                if (!IsTransactionInStatus(traceId, 2))
                {
                    ShowStatusMessage("No está en estado de Preparación", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                string carnetMesa = GetBadgeForTransaction(traceId, 2);
                if (string.IsNullOrEmpty(carnetMesa))
                {
                    ShowStatusMessage($"No se puede dar salida - ID no fue preparado aun", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                if (!AreAllQuantitiesConfirmed(traceId))
                {
                    int pendientes = GetPendingItemsCount(traceId);
                    ShowStatusMessage($"No se puede dar salida - {pendientes} items pendientes de confirmar", false, true);
                    txtTraceIdSalida.SelectAll();
                    txtTraceIdSalida.Focus();
                    return;
                }

                UpdateTransactionStatus(traceId, 3, carnetMesa);
                ShowStatusMessage($"Enviado a mesa exitosamente - Carnet: {carnetMesa}");

                txtTraceIdSalida.Text = "";
                txtTraceIdSalida.Focus();

            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al actualizar el estado: {ex.Message}", true);
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

        private void UpdateBadgeForStatus(int traceId, int statusId, string badge)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        UPDATE ST
                        SET ST.Badge = @Badge
                        FROM pmc_StatusTracking ST
                        INNER JOIN pmc_Transactions TS ON ST.TransactionID = TS.ID
                        WHERE TS.TraceID = @TraceID
                        AND ST.StatusID = @StatusID", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        command.Parameters.AddWithValue("@StatusID", statusId);
                        command.Parameters.AddWithValue("@Badge", badge);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("No se pudo actualizar el badge - Registro no encontrado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar badge: {ex.Message}");
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
                        ShowStatusMessage("Item no disponible - No se puede procesar", true);
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    var newQuantity = row.Cells["QuantityREAL"].Value;

                    if (newQuantity == null || string.IsNullOrWhiteSpace(newQuantity.ToString()))
                    {
                        ShowStatusMessage("Ingrese una cantidad válida", true);
                        row.Cells["QuantityREAL"].Value = 0;
                        UpdateDataTableQuantity(row, 0);
                        UpdateConfirmationStatusForRowByDetailId(Convert.ToInt32(row.Cells["DetailID"].Value));
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    // VALIDACIÓN: Debe ser un número válido
                    if (!decimal.TryParse(newQuantity.ToString(), out decimal quantityReal))
                    {
                        ShowStatusMessage("Formato inválido - Solo se permiten números", true);
                        row.Cells["QuantityREAL"].Value = 0;
                        UpdateDataTableQuantity(row, 0);
                        UpdateConfirmationStatusForRowByDetailId(Convert.ToInt32(row.Cells["DetailID"].Value));
                        GridItemsOut.CancelEdit();
                        return;
                    }

                    if (quantityReal < 0)
                    {
                        ShowStatusMessage("Cantidad inválida - No se permiten valores negativos", true);
                        row.Cells["QuantityREAL"].Value = 0;
                        UpdateDataTableQuantity(row, 0);
                        UpdateConfirmationStatusForRowByDetailId(Convert.ToInt32(row.Cells["DetailID"].Value));
                        GridItemsOut.CancelEdit();
                        return;
                    }



                    decimal quantityBOM = 0;
                    decimal inventory = 0;
                    decimal sobrantesDisponibles = 0;
                    decimal sobrantesUsar = 0;


                    if (itemsDataTable != null)
                    {
                        var detailId = Convert.ToInt32(row.Cells["DetailID"].Value);
                        var foundRows = itemsDataTable.Select($"DetailID = {detailId}");
                        if (foundRows.Length > 0)
                        {
                            var dataRow = foundRows[0];

                            quantityBOM = Convert.ToDecimal(dataRow["QuantityBOM"]);
                            inventory = Convert.ToDecimal(dataRow["Inventory"]);

                            // Obtener sobrantes disponibles
                            var sobrantesValue = dataRow["SobrantesDisponibles"];
                            if (sobrantesValue != null && sobrantesValue != DBNull.Value &&
                                sobrantesValue.ToString() != "No Disponible")
                            {
                                decimal.TryParse(sobrantesValue.ToString().Replace(",", ""), out sobrantesDisponibles);
                            }

                            // Obtener sobrantes en uso
                            var sobrantesUsarValue = dataRow["DescontarSobrantes"];
                            if (sobrantesUsarValue != null && sobrantesUsarValue != DBNull.Value)
                            {
                                sobrantesUsar = Convert.ToDecimal(sobrantesUsarValue);
                            }

                            // NUEVA VALIDACIÓN: Permitir si hay suficiente inventario O sobrantes
                            if (quantityReal > inventory)
                            {
                                ShowStatusMessage($"No puede descontar más del stock disponible. Disponible: {Math.Round(inventory)} unidades", true);
                                row.Cells["QuantityREAL"].Value = 0;
                                UpdateDataTableQuantity(row, 0);
                                UpdateConfirmationStatusForRowByDetailId(detailId);
                                GridItemsOut.CancelEdit();
                                return;
                            }

                            // En GridItemsOut_CellEndEdit, después de las validaciones existentes:
                            if (quantityBOM > 0 && quantityReal == 0 && inventory <= 0 && sobrantesDisponibles <= 0)
                            {
                                ShowStatusMessage($"No hay recursos disponibles para cumplir con el BOM de {Math.Round(quantityBOM)} unidades", true);
                                row.Cells["QuantityREAL"].Value = 0;
                                UpdateDataTableQuantity(row, 0);
                                UpdateConfirmationStatusForRowByDetailId(detailId);
                                GridItemsOut.CancelEdit();
                                return;
                            }

                            UpdateDataTableQuantity(row, quantityReal);
                            UpdateConfirmationStatusForRowByDetailId(detailId);

                            // Navegar a la siguiente fila
                            int currentIndex = GridItemsOut.CurrentRow != null ? GridItemsOut.CurrentRow.Index : row.Index;
                            NavegarASiguienteFila(currentIndex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Error al procesar la cantidad: {ex.Message}", true);
                    GridItemsOut.CancelEdit();

                    try
                    {
                        row.Cells["QuantityREAL"].Value = 0;
                        var detailId = Convert.ToInt32(row.Cells["DetailID"].Value);
                        UpdateDataTableQuantity(row, 0);
                        UpdateConfirmationStatusForRowByDetailId(detailId);
                    }
                    catch
                    {
                        // Si falla el restablecimiento
                    }
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
                        // Seleccionar la fila en QuantityREAL
                        GridItemsOut.CurrentRow = nextRow;
                        GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["QuantityREAL"];

                        // Scroll y focus
                        GridItemsOut.TableElement.ScrollToRow(i);
                        GridItemsOut.Focus();

                        // Iniciar edición
                        GridItemsOut.BeginEdit();
                        return;
                    }
                }

                for (int i = 0; i < GridItemsOut.Rows.Count; i++)
                {
                    var nextRow = GridItemsOut.Rows[i] as GridViewDataRowInfo;
                    if (nextRow != null && TieneSobrantesDisponibles(nextRow))
                    {
                        // Seleccionar la fila en DescontarSobrantes
                        GridItemsOut.CurrentRow = nextRow;
                        GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];

                        // Scroll y focus
                        GridItemsOut.TableElement.ScrollToRow(i);
                        GridItemsOut.Focus();

                        // Iniciar edición
                        GridItemsOut.BeginEdit();

                        ShowStatusMessage("→ Sobrantes");
                        return;
                    }
                }

                ShowStatusMessage("→ Confirme la transacción con su carnet.");
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
                // Pequeña pausa para asegurar que la edición anterior terminó completamente
                System.Threading.Thread.Sleep(50);
                Application.DoEvents();

                int nextRowIndex = currentRowIndex + 1;

                // Buscar siguiente fila con sobrantes disponibles para DescontarSobrantes
                for (int i = nextRowIndex; i < GridItemsOut.Rows.Count; i++)
                {
                    var nextRow = GridItemsOut.Rows[i] as GridViewDataRowInfo;
                    if (nextRow != null && TieneSobrantesDisponibles(nextRow))
                    {
                        // Seleccionar la fila en DescontarSobrantes
                        GridItemsOut.CurrentRow = nextRow;
                        GridItemsOut.CurrentColumn = GridItemsOut.MasterTemplate.Columns["DescontarSobrantes"];

                        // Scroll y focus
                        GridItemsOut.TableElement.ScrollToRow(i);
                        GridItemsOut.Focus();

                        // Iniciar edición
                        GridItemsOut.BeginEdit();
                        return;
                    }
                }

                ShowStatusMessage("→ Confirme la transacción con su carnet.");
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

        private void UpdateConfirmationStatusForRowByDetailId(int detailId)
        {
            if (itemsDataTable != null)
            {
                var foundRows = itemsDataTable.Select($"DetailID = {detailId}");
                if (foundRows.Length > 0)
                {
                    UpdateConfirmationStatusForRow(foundRows[0]);
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

        private void UpdateConfirmationStatusForRow(DataRow row)
        {
            if (!itemsDataTable.Columns.Contains("ConfirmationStatus"))
            {
                var statusColumn = itemsDataTable.Columns.Add("ConfirmationStatus", typeof(string));
                statusColumn.ReadOnly = false;
                statusColumn.MaxLength = 50;
            }
            else if (itemsDataTable.Columns["ConfirmationStatus"].ReadOnly)
            {
                itemsDataTable.Columns["ConfirmationStatus"].ReadOnly = false;
            }

            string statusText;
            decimal quantityBOM = Convert.ToDecimal(row["QuantityBOM"]);
            decimal quantityReal = row["QuantityREAL"] == DBNull.Value ? 0 : Convert.ToDecimal(row["QuantityREAL"]);
            decimal descontarSobrantes = row["DescontarSobrantes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DescontarSobrantes"]);

            decimal total = quantityReal + descontarSobrantes;

            if (quantityBOM == 0)
            {
                statusText = "Listo";
            }
            else if (total > 0)
            {
                statusText = "Correct";
            }
            else
            {
                statusText = "Pending";
            }

            int maxLength = itemsDataTable.Columns["ConfirmationStatus"].MaxLength;
            if (maxLength > 0 && statusText.Length > maxLength)
            {
                statusText = statusText.Substring(0, maxLength);
            }

            row["ConfirmationStatus"] = statusText;

            var bindingSource = GridItemsOut.DataSource as BindingSource;
            bindingSource?.ResetBindings(false);
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
                    UpdateTraceIDLabel(txtTraceID.Text);
                }

                LoadTransactionData();
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

                if (!int.TryParse(txtTraceID.Text, out int traceId))
                {
                    ShowStatusMessage("El ID no es válido", false, true);
                    return;
                }

                UpdateTraceIDLabel(txtTraceID.Text);

                if (!EnsureTransactionForPreparation(traceId, ""))
                {
                    txtTraceID.SelectAll();
                    txtTraceID.Focus();
                    currentTraceId = 0;
                    return;
                }

                currentTraceId = traceId;

                if (IsTransactionInStatus(traceId, 3))
                {
                    ShowStatusMessage("Ya asignado a mesa - No puede procesarse nuevamente", true);
                    txtTraceID.SelectAll();
                    txtTraceID.Focus();
                    return;
                }

                if (IsTransactionInStatus(traceId, 2) && IsTransactionFullyConfirmed(traceId))
                {
                    ShowStatusMessage("Ya se descontaron los items del inventario", false, true);
                    txtTraceID.SelectAll();
                    txtTraceID.Focus();
                    return;
                }

                LoadTransactionDetails(traceId);

                if (!IsTransactionInStatus(traceId, 2))
                {
                    UpdateTransactionStatus(traceId, 2, "");
                }

                txtCarnetDescontar.Text = "";

                if (GridItemsOut.Rows.Count > 0)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        SaltarAlGridInmediatamente();
                    }));
                }
                else
                {
                    txtCarnetDescontar.Focus();
                }
                ShowStatusMessage("Preparación iniciada - Ingrese cantidades");
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al cargar los datos: {ex.Message}", true);
            }
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
                        txtCarnetDescontar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al saltar al grid: {ex.Message}", true);
                txtCarnetDescontar.Focus();
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

        private bool IsTransactionFullyConfirmed(int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM pmc_TransactionDetails TD
                        INNER JOIN pmc_Transactions T ON TD.TransactionID = T.ID
                        WHERE T.TraceID = @TraceID
                        AND TD.QuantityREAL > 0", connection))
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
                ShowStatusMessage($"Error verificando confirmación: {ex.Message}", true);
                return false;
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
                            if (row["SobrantesDisponibles"] == DBNull.Value)
                                row["SobrantesDisponibles"] = "0";

                            if (row["DescontarSobrantes"] == DBNull.Value)
                                row["DescontarSobrantes"] = 0m;

                        }

                        LoadInventoryAndLocationData();
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


        private void UpdateTraceIDLabel(string traceIDText)
        {
            /*if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateTraceIDLabel), traceIDText);
                return;
            }

            if (string.IsNullOrWhiteSpace(traceIDText))
            {
                lblNameID.Text = "TraceID";
                return;
            }

            if (long.TryParse(traceIDText, out long traceId))
            {
                if (traceId >= 900000000L && traceId <= 999999999L)
                {
                    lblNameID.Text = "SOBRECONSUMO ID";
                }
                else if (traceId >= 800000000L && traceId <= 899999999L)
                {
                    lblNameID.Text = "FILTRADO ID";
                }
                else
                {
                    lblNameID.Text = "TRACER ID";
                }
            }
            else
            {
                lblNameID.Text = "TRACER ID";
            }*/
        }

        private void LoadInventoryAndLocationData()
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
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                {
                    // Primero identificamos qué items son stickers
                    DataTable stickersTable = new DataTable();
                    string stickersQuery = @"
                SELECT DISTINCT LTRIM(RTRIM(s.Item)) COLLATE SQL_Latin1_General_CP1_CI_AS as StickerItem
                FROM dbo.pmc_Stickers s";

                    using (SqlCommand stickersCommand = new SqlCommand(stickersQuery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader stickersReader = stickersCommand.ExecuteReader())
                        {
                            stickersTable.Load(stickersReader);
                        }
                    }

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        string itemCode = row["ItemCode"].ToString().Trim();

                        bool esSticker = false;
                        var stickerRows = stickersTable.Select($"StickerItem = '{itemCode.Replace("'", "''")}'");
                        if (stickerRows.Length > 0)
                        {
                            esSticker = true;
                        }

                        string warehouseCode = esSticker ? "PRINT" : "PREP";

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
                            AND W.WarehouseCode = @WarehouseCode";

                        using (SqlCommand inventoryCommand = new SqlCommand(inventoryQuery, connection))
                        {
                            inventoryCommand.Parameters.AddWithValue("@ItemCode", itemCode);
                            inventoryCommand.Parameters.AddWithValue("@WarehouseCode", warehouseCode);

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
                                    row["Location"] = inventoryReader["Location"];

                                    string descripcion = inventoryReader["Description"]?.ToString();
                                    if (string.IsNullOrEmpty(descripcion))
                                    {
                                        row["Existencia"] = "No Disponible";
                                        row["InventoryDisplay"] = "No Disponible";
                                        if (row["QuantityREAL"] == DBNull.Value || row["QuantityREAL"] == null)
                                        {
                                            row["QuantityREAL"] = 0m;
                                        }
                                    }
                                    else
                                    {
                                        row["Existencia"] = "Disponible";

                                        if (inventoryQuantity <= 0)
                                        {
                                            row["Existencia"] = "No Disponible";
                                            row["InventoryDisplay"] = "No Disponible";
                                            if (row["QuantityREAL"] == DBNull.Value || row["QuantityREAL"] == null)
                                            {
                                                row["QuantityREAL"] = 0m;
                                            }
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

                                    if (esSticker)
                                    {
                                        row["Location"] = $"PrintHub";
                                    }
                                }
                                else
                                {
                                    row["Inventory"] = 0;
                                    row["Location"] = esSticker ?
                                        $"Sticker no registrado" :
                                        $"Item no resgistrado";
                                    row["InventoryDisplay"] = "No Disponible";
                                    row["Existencia"] = "No Disponible";
                                    row["QuantityREAL"] = 0m;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error cargando inventario: {ex.Message}", true);
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

        private void GridItemsOut_CellEndEdit_Sobrantes(object sender, GridViewCellEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "DescontarSobrantes" && e.Row is GridViewDataRowInfo row)
            {
                try
                {
                    var sobrantesDisponiblesValue = row.Cells["SobrantesDisponibles"].Value;

                    if (sobrantesDisponiblesValue == null || sobrantesDisponiblesValue == DBNull.Value || sobrantesDisponiblesValue.ToString() == "No Disponible")
                    {
                        ShowStatusMessage("No hay sobrantes disponibles para este item", true);
                        row.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(row, 0m);
                        return;
                    }

                    decimal sobrantesDisponibles = 0m;
                    if (sobrantesDisponiblesValue != null && sobrantesDisponiblesValue != DBNull.Value &&
                        decimal.TryParse(sobrantesDisponiblesValue.ToString().Replace(",", ""), out decimal disponible))
                    {
                        sobrantesDisponibles = disponible;
                    }

                    var newSobrantesValue = row.Cells["DescontarSobrantes"].Value;

                    if (newSobrantesValue == null || newSobrantesValue == DBNull.Value || string.IsNullOrWhiteSpace(newSobrantesValue.ToString()))
                    {
                        row.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(row, 0m);
                        return;
                    }

                    if (!decimal.TryParse(newSobrantesValue.ToString(), out decimal sobrantesUsar))
                    {
                        ShowStatusMessage("Formato inválido - Solo se permiten números", true);
                        row.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(row, 0m);
                        return;
                    }

                    if (sobrantesUsar < 0)
                    {
                        ShowStatusMessage("No se permiten valores negativos", true);
                        row.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(row, 0m);
                        return;
                    }

                    if (sobrantesUsar > sobrantesDisponibles)
                    {
                        ShowStatusMessage($"Excede sobrantes disponibles. Máximo: {Math.Round(sobrantesDisponibles)} unidades", false, true);
                        row.Cells["DescontarSobrantes"].Value = 0m;
                        UpdateDataTableSobrantes(row, 0m);
                        return;
                    }

                    UpdateDataTableSobrantes(row, sobrantesUsar);

                    if (sobrantesUsar > 0)
                    {
                        ShowStatusMessage($"Sobrantes establecidos: {Math.Round(sobrantesUsar)} unidades");
                    }
                    else
                    {
                        ShowStatusMessage("Sobrantes establecidos en 0");
                    }

                    NavegarDesdeSobrantes(row.Index);

                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Error al procesar sobrantes: {ex.Message}", true);
                    row.Cells["DescontarSobrantes"].Value = 0m;
                    UpdateDataTableSobrantes(row, 0m);
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

        private void ProcessSobrantesDiscount(int traceId, string carnet)
        {
            if (itemsDataTable == null) return;

            try
            {
                string sacaActual = txtSACA.Text.Trim();

                if (string.IsNullOrEmpty(sacaActual))
                {
                    ShowStatusMessage("No se puede procesar sobrantes - SACA no disponible", true);
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

                                        // Actualizar el registro de sobrantes
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
                                                // Registrar el movimiento de sobrantes
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
                    'PREP',
                    @Description,
                    @CreatedBy
                )", connection))
                    {
                        string descripcion = $"- Sobrantes usados para el TraceID - {traceId} - Saca {saca} - cantidad {cantidad}";

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
                ShowStatusMessage($"Error registrando movimiento de sobrantes: {ex.Message}", true);
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
            inventoryColumn.HeaderText = "Inventario";
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

            // NUEVA COLUMNA: USAR SOBRANTES
            var descontarSobrantesColumn = new GridViewTextBoxColumn();
            descontarSobrantesColumn.FieldName = "DescontarSobrantes";
            descontarSobrantesColumn.HeaderText = "Usar Sobrantes";
            descontarSobrantesColumn.Name = "DescontarSobrantes";
            descontarSobrantesColumn.Width = 100;
            descontarSobrantesColumn.ReadOnly = false;
            descontarSobrantesColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(descontarSobrantesColumn);

            // NUEVA COLUMNA: SOBRANTES DISPONIBLES
            var sobrantesDisponiblesColumn = new GridViewTextBoxColumn();
            sobrantesDisponiblesColumn.FieldName = "SobrantesDisponibles";
            sobrantesDisponiblesColumn.HeaderText = "Sobrantes Disp.";
            sobrantesDisponiblesColumn.Name = "SobrantesDisponibles";
            sobrantesDisponiblesColumn.Width = 100;
            sobrantesDisponiblesColumn.ReadOnly = true;
            sobrantesDisponiblesColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            GridItemsOut.MasterTemplate.Columns.Add(sobrantesDisponiblesColumn);
        }

        #region SPs
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
                    ShowStatusMessage("Ingrese su carnet para confirmar la transacción", true);
                    txtCarnetDescontar.Focus();
                    return;
                }

                string carnet = txtCarnetDescontar.Text.Trim();

                // VALIDAR CARNET
                if (!ValidarCarnetAntesDeConfirmar(carnet, txtCarnetDescontar))
                {
                    return;
                }

                ForceZeroForNoStockItems();

                if (itemsDataTable != null)
                {
                    var pendientes = itemsDataTable.AsEnumerable()
                        .Where(row => row["QuantityREAL"] == DBNull.Value ||
                                     row["QuantityREAL"] == null ||
                                     string.IsNullOrEmpty(row["QuantityREAL"].ToString()) ||
                                     !decimal.TryParse(row["QuantityREAL"].ToString(), out _))
                        .Count();

                    if (pendientes > 0)
                    {
                        ShowStatusMessage($"Error al confirmar la transacción, {pendientes} items pendientes de confirmar", true);
                        return;
                    }

                    // VALIDACIONES MANTENIDAS (solo quitar la de BOM vs cantidad)
                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        decimal quantityREAL = Convert.ToDecimal(row["QuantityREAL"]);
                        decimal inventory = Convert.ToDecimal(row["Inventory"]);
                        decimal descontarSobrantes = row["DescontarSobrantes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["DescontarSobrantes"]);

                        string sobrantesDisponiblesValue = row["SobrantesDisponibles"]?.ToString();
                        decimal sobrantesDisponibles = 0m;

                        if (sobrantesDisponiblesValue != null && sobrantesDisponiblesValue != "No Disponible")
                        {
                            decimal.TryParse(sobrantesDisponiblesValue.Replace(",", ""), out sobrantesDisponibles);
                        }

                        // MANTENER: No puede usar más del inventario disponible
                        if (quantityREAL > inventory)
                        {
                            ShowStatusMessage($"No hay suficiente stock para el item {row["ItemCode"]}. Stock disponible: {Math.Round(inventory)}, Solicitado: {Math.Round(quantityREAL)}", true);
                            return;
                        }

                        // MANTENER: No puede usar más sobrantes de los disponibles
                        if (descontarSobrantes > sobrantesDisponibles)
                        {
                            string itemCode = row["ItemCode"].ToString();
                            ShowStatusMessage($"No se puede confirmar - Item {itemCode} usa {Math.Round(descontarSobrantes)} sobrantes pero solo hay {Math.Round(sobrantesDisponibles)} disponibles", true);
                            return;
                        }
                    }
                }

                UpdateAllRealQuantities();
                UpdateBadgeForStatus(currentTraceId, 2, carnet);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_ConfirmTransaction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TraceID", int.Parse(txtTraceID.Text));
                        command.Parameters.AddWithValue("@Badge", carnet);

                        connection.Open();
                        command.ExecuteNonQuery();

                        ProcessSobrantesDiscount(currentTraceId, carnet);
                        ShowStatusMessage("Transacción completada - Inventario actualizado exitosamente");
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al confirmar la transacción: {ex.Message}", true);
            }
        }

        private void ForceZeroForNoStockItems()
        {
            if (itemsDataTable == null) return;

            foreach (DataRow row in itemsDataTable.Rows)
            {
                var existencia = row["Existencia"]?.ToString();
                var inventoryDisplay = row["InventoryDisplay"]?.ToString();

                bool noTieneStock = (existencia == "No Disponible") ||
                                   (inventoryDisplay == "No Disponible") ||
                                   (row["Inventory"] != DBNull.Value && Convert.ToDecimal(row["Inventory"]) <= 0);

                if (noTieneStock && (row["QuantityREAL"] == DBNull.Value || row["QuantityREAL"] == null))
                {
                    row["QuantityREAL"] = 0m;
                }
            }
        }

        private void UpdateAllRealQuantities()
        {
            if (itemsDataTable == null) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in itemsDataTable.Rows)
                    {
                        if (row["QuantityREAL"] != DBNull.Value && decimal.TryParse(row["QuantityREAL"].ToString(), out decimal quantityReal))
                        {
                            using (SqlCommand command = new SqlCommand("sp_UpdateRealQuantity", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@DetailID", row["DetailID"]);
                                command.Parameters.AddWithValue("@QuantityREAL", quantityReal);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error actualizando cantidades: {ex.Message}");
            }
        }

        #endregion

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
            txtTraceID.Focus();
            lblNameID.Text = "TRACER ID";
        }

        private void TxtItemCodigo_TextChanged(object sender, EventArgs e)
        {
            string texto = txtItemCodigo.Text.Trim();
            lastScanTime = DateTime.Now;

            if (EsCodigoEscaneado(texto))
            {
                Timer processTimer = new Timer();
                processTimer.Interval = 150;
                processTimer.Tick += (s, args) =>
                {
                    processTimer.Stop();
                    processTimer.Dispose();
                    ProcessItemCodeFinal();
                };
                processTimer.Start();
            }
            else
            {
                Timer searchTimer = new Timer();
                searchTimer.Interval = 500;
                searchTimer.Tick += (s, args) =>
                {
                    searchTimer.Stop();
                    searchTimer.Dispose();
                    if (!string.IsNullOrWhiteSpace(txtItemCodigo.Text))
                    {
                        SearchAndAutoCompleteItem(txtItemCodigo.Text.Trim());
                    }
                    else
                    {
                        ClearItemFields();
                    }
                };
                searchTimer.Start();
            }
        }

        private void TxtItemCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if ((DateTime.Now - lastScanTime).TotalMilliseconds < 500)
                {
                    DiscardPendingInput();
                }

                ProcessItemCodeFinal();
            }
        }

        private void ProcessItemCodeFinal()
        {
            string texto = txtItemCodigo.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                string codigoLimpio = LimpiarCodigoEscaneado(texto);

                if (texto != codigoLimpio)
                {
                    txtItemCodigo.Text = codigoLimpio;
                }

                bool itemExiste = SearchAndAutoCompleteItem(codigoLimpio);

                if (itemExiste)
                {
                    DiscardPendingInput();

                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
                else
                {
                    txtItemCodigo.Focus();
                    txtItemCodigo.SelectAll();
                }
            }
        }

        private void DiscardPendingInput()
        {
            try
            {
                Application.DoEvents();

                System.Threading.Thread.Sleep(10);
            }
            catch
            {
            }
        }

        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txtCantidad.Text) && decimal.TryParse(txtCantidad.Text, out decimal cantidad))
                {
                    if (cantidad > 0)
                    {
                        txtCarnetItem.Focus();
                        txtCarnetItem.SelectAll();
                    }
                    else
                    {
                        ShowStatusMessage("La cantidad debe ser mayor a 0", true);
                        txtCantidad.Focus();
                        txtCantidad.SelectAll();
                    }
                }
                else
                {
                    ShowStatusMessage("Ingrese una cantidad válida", true);
                    txtCantidad.Focus();
                    txtCantidad.SelectAll();
                }
            }
        }

        private bool SearchAndAutoCompleteItem(string itemCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(itemCode))
                {
                    ClearItemFields();
                    return false;
                }

                ShowStatusMessage($"Buscando: '{itemCode}'");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT DISTINCT 
                            IP.Code, 
                            SB.sub_descripcion AS Description, 
                            IP.TotalQuantity, 
                            IP.Location, 
                            IP.BoxID,
                            W.WarehouseCode
                        FROM dbo.pmc_InventoryPreparation IP
                        INNER JOIN pmc_Warehouse W ON IP.WarehouseID = W.WarehouseID
                        INNER JOIN pmc_Subida_BOM SB ON SB.sub_producto = IP.Code
                        WHERE IP.Code = @ItemCode", connection))
                    {
                        command.Parameters.AddWithValue("@ItemCode", itemCode);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            txtIdCaja.Text = reader["BoxID"]?.ToString() ?? "";
                            txtLocalidad.Text = reader["Location"]?.ToString() ?? "";

                            string descripcion = reader["Description"]?.ToString() ?? "";
                            decimal stockActual = Convert.ToDecimal(reader["TotalQuantity"]);

                            ShowStatusMessage($"Item encontrado: {descripcion} - Stock actual: {stockActual}");
                            reader.Close();
                            return true;
                        }
                        else
                        {
                            ClearItemFields();
                            ShowStatusMessage($"Item '{itemCode}' no existe", true);
                            reader.Close();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error buscando item: {ex.Message}", true);
                ClearItemFields();
                return false;
            }
        }

        private void ClearItemFields()
        {
            txtIdCaja.Text = "";
            txtLocalidad.Text = "";
        }

        private void TxtCarnetItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ProcessItemEntry();
            }
        }

        private void ProcessItemEntry()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtItemCodigo.Text))
                {
                    ShowStatusMessage("Ingrese el código del item", true);
                    txtItemCodigo.Focus();
                    return;
                }

                string codigoLimpio = LimpiarCodigoEscaneado(txtItemCodigo.Text.Trim());

                if (string.IsNullOrWhiteSpace(txtCarnetItem.Text))
                {
                    ShowStatusMessage("Ingrese su carnet", true);
                    txtCarnetItem.Focus();
                    return;
                }

                if (!ValidarCarnetAntesDeConfirmar(txtCarnetItem.Text.Trim(), txtCarnetItem))
                {
                    return;
                }

                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
                {
                    ShowStatusMessage("Ingrese una cantidad válida mayor a 0", true);
                    txtCantidad.Focus();
                    return;
                }

                if (!ValidateItemExists(codigoLimpio))
                {
                    ShowStatusMessage($"El item '{codigoLimpio}' no existe en la base de datos", true);
                    txtItemCodigo.Focus();
                    return;
                }

                RegistrarEntradaInventario(codigoLimpio, cantidad, txtCarnetItem.Text.Trim());

                UpdateItemStock(codigoLimpio, cantidad, txtCarnetItem.Text.Trim());

                ShowStatusMessage($"Entrada procesada exitosamente - Se agregaron {cantidad} unidades al item {codigoLimpio}");

                ClearEntryForm();
                txtItemCodigo.Focus();

                if (currentTraceId > 0)
                {
                    RefreshMaterialsGrid();
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error procesando entrada: {ex.Message}", true);
            }
        }

        private void RegistrarEntradaInventario(string itemCode, decimal cantidad, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                INSERT INTO ES_SOCKS.dbo.pmc_InventoryMovements (
                    Code, 
                    MovementType, 
                    Quantity, 
                    Warehouse, 
                    Description, 
                    CreatedBy
                ) 
                VALUES (
                    @Code,
                    'IN',
                    @Quantity,
                    'PREP',
                    @Description,
                    @CreatedBy
                )", connection))
                    {
                        string descripcion = $"+ Entrada Material {itemCode} - cantidad {cantidad}";

                        command.Parameters.AddWithValue("@Code", itemCode);
                        command.Parameters.AddWithValue("@Quantity", cantidad);
                        command.Parameters.AddWithValue("@Description", descripcion);
                        command.Parameters.AddWithValue("@CreatedBy", carnet);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Entrada registrada: {descripcion}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error registrando entrada en movimientos: {ex.Message}", true);
            }
        }

        private bool ValidateItemExists(string itemCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT COUNT(*) FROM dbo.pmc_InventoryPreparation WHERE Code = @ItemCode", connection))
                    {
                        command.Parameters.AddWithValue("@ItemCode", itemCode);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error validando item: {ex.Message}", true);
                return false;
            }
        }

        private void UpdateItemStock(string itemCode, decimal cantidad, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        UPDATE dbo.pmc_InventoryPreparation 
                        SET 
                            TotalQuantity = TotalQuantity + @Cantidad,
                            ModifiedDate = SYSDATETIME(),
                            ModifiedBy = @Carnet
                        WHERE Code = @ItemCode", connection))
                    {
                        command.Parameters.AddWithValue("@ItemCode", itemCode);
                        command.Parameters.AddWithValue("@Cantidad", cantidad);
                        command.Parameters.AddWithValue("@Carnet", carnet);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("No se pudo actualizar el stock - Item no encontrado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error actualizando stock: {ex.Message}");
            }
        }

        private void ClearEntryForm()
        {
            txtItemCodigo.Text = "";
            txtCantidad.Text = "";
            txtCarnetItem.Text = "";
            ClearItemFields();
        }

        private void RefreshMaterialsGrid()
        {
            try
            {
                if (currentTraceId > 0 && itemsDataTable != null)
                {
                    LoadInventoryAndLocationData();

                    var bindingSource = GridItemsOut.DataSource as BindingSource;
                    if (bindingSource != null)
                    {
                        bindingSource.ResetBindings(false);
                    }

                    GridItemsOut.Refresh();
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error al actualizar el grid: {ex.Message}", true);
            }
        }

        private bool AreAllQuantitiesConfirmed(int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT COUNT(*) as Pendientes
                        FROM pmc_TransactionDetails TD
                        INNER JOIN pmc_Transactions T ON TD.TransactionID = T.ID
                        WHERE T.TraceID = @TraceID
                        AND (TD.QuantityREAL IS NULL OR TD.ConfirmationDate IS NULL)", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        connection.Open();

                        int pendientes = (int)command.ExecuteScalar();
                        return pendientes == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error validando confirmaciones: {ex.Message}", true);
                return false;
            }
        }

        private int GetPendingItemsCount(int traceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT COUNT(*) as Pendientes
                        FROM pmc_TransactionDetails TD
                        INNER JOIN pmc_Transactions T ON TD.TransactionID = T.ID
                        WHERE T.TraceID = @TraceID
                        AND (TD.QuantityREAL IS NULL OR TD.ConfirmationDate IS NULL)", connection))
                    {
                        command.Parameters.AddWithValue("@TraceID", traceId);
                        connection.Open();
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Error contando pendientes: {ex.Message}", true);
                return -1;
            }
        }


        private string LimpiarCodigoEscaneado(string textoEscaneado)
        {
            if (string.IsNullOrEmpty(textoEscaneado))
                return textoEscaneado;

            textoEscaneado = textoEscaneado.Trim();
            string[] partes = textoEscaneado.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length > 0)
            {
                return partes[0].ToUpper().Trim();
            }

            return textoEscaneado.ToUpper().Trim();
        }

        private bool EsCodigoEscaneado(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return false;

            if (texto.Contains(" "))
            {
                string[] partes = texto.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                return partes.Length >= 2;
            }

            return false;
        }

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

    }
}