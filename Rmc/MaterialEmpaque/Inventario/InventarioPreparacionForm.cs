using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using GridViewAutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode;

namespace Rmc.MaterialEmpaque.Inventario
{
    public partial class InventarioPreparacionForm : RadForm
    {
        private ItemService _itemService;
        private TransferService _transferService;
        private string _currentUser;
        private int _warehouseId;
        private string _warehouseName;
        private Timer _searchTimer;
        private bool _isInitialLoad = true;
        private bool _isEditing = false;
        private DateTime _lastScanTime = DateTime.Now;

        private Color _primaryColor = Color.FromArgb(44, 62, 80);
        private Color _secondaryColor = Color.FromArgb(52, 152, 219);
        private Color _accentColor = Color.FromArgb(46, 204, 113);
        private Color _warningColor = Color.FromArgb(230, 126, 34);
        private Color _dangerColor = Color.FromArgb(231, 76, 60);
        private Color _lightGray = Color.FromArgb(248, 249, 250);
        private Color _darkGray = Color.FromArgb(108, 117, 125);

        public InventarioPreparacionForm(string currentUser, int warehouseId, string warehouseName)
        {
            InitializeComponent();
            _itemService = new ItemService();
            _transferService = new TransferService();
            _currentUser = currentUser;
            _warehouseId = warehouseId;
            _warehouseName = warehouseName;

            _searchTimer = new Timer();
            _searchTimer.Interval = 500;
            _searchTimer.Tick += SearchTimer_Tick;

            GridViewData.CommandCellClick += GridViewData_CommandCellClick;
            GridViewData.CellClick += GridViewData_CellClick;
            GridViewData.CellFormatting += GridViewData_CellFormatting;

            ApplyModernTheme();
            ConfigureGridView();
            ConfigureTransferControls();
            UpdateFormTitle();
            LoadData();
        }

        private void ConfigureTransferControls()
        {
            LoadDestinationWarehouses();

            txtBuscar.Focus();
            txtItem.KeyDown += TxtItem_KeyDown;
            txtCantidadTransfer.KeyDown += TxtCantidadTransfer_KeyDown;
            txtCarnetTransfer.KeyDown += TxtCarnetTransfer_KeyDown;

            txtCantidadTransfer.Value = 0;

            lblInfoItem.Text = "Ingrese código de item";

            // Configurar autocompletado
            ConfigurarAutocompletadoItem();
            txtItem.TextChanged += TxtItem_TextChanged;
        }

        private void ConfigurarAutocompletadoItem()
        {
            try
            {
                var itemCodes = _itemService.GetAllItemCodesForWarehouse(_warehouseId);

                var autoCompleteSource = new AutoCompleteStringCollection();
                autoCompleteSource.AddRange(itemCodes.ToArray());

                txtItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtItem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtItem.AutoCompleteCustomSource = autoCompleteSource;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error configurando autocompletado: {ex.Message}");
            }
        }

        // Si necesitas una clase auxiliar para el autocompletado
        public class AutoCompleteTextBox
        {
            public AutoCompleteStringCollection AutoCompleteCustomSource { get; set; }
            public AutoCompleteMode AutoCompleteMode { get; set; }
            public AutoCompleteSource AutoCompleteSource { get; set; }

            public AutoCompleteTextBox()
            {
                AutoCompleteCustomSource = new AutoCompleteStringCollection();
            }
        }

        private void TxtItem_TextChanged(object sender, EventArgs e)
        {
            string texto = txtItem.Text.Trim();
            _lastScanTime = DateTime.Now;

            if (EsCodigoEscaneado(texto))
            {
                Timer processTimer = new Timer();
                processTimer.Interval = 150;
                processTimer.Tick += (s, args) =>
                {
                    processTimer.Stop();
                    processTimer.Dispose();
                    ProcesarCodigoEscaneado();
                };
                processTimer.Start();
            }
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

        private void ProcesarCodigoEscaneado()
        {
            string entrada = txtItem.Text.Trim();

            string codigoLimpio = LimpiarCodigoEscaneado(entrada);

            txtItem.Text = codigoLimpio;
            txtItem.SelectionStart = txtItem.Text.Length;

            lblInfoItem.Text = $"Código escaneado: {codigoLimpio}";
            lblInfoItem.ForeColor = Color.FromArgb(0, 123, 255);

            // Usar el código limpio para validar
            ValidarItemConCodigoLimpio(codigoLimpio);
        }

        private void ValidarItemConCodigoLimpio(string codigoLimpio)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoLimpio))
                {
                    ShowValidationError(txtItem, "Ingrese un código de item");
                    return;
                }

                var item = _transferService.GetItemByCodeAndWarehouse(codigoLimpio, _warehouseId);
                if (item == null)
                {
                    ShowValidationError(txtItem, $"El item '{codigoLimpio}' no existe en esta bodega");
                    return;
                }

                if (item.Description == "SIN DESCRIPCIÓN" || string.IsNullOrWhiteSpace(item.Description))
                {
                    ShowValidationError(txtItem, $"El código '{codigoLimpio}' no es un item válido del sistema");
                    return;
                }

                int stockDisponible = (int)Math.Round(item.TotalQuantity);
                lblInfoItem.Text = $"{item.Description} - Stock disponible: {stockDisponible:N0}";
                lblInfoItem.ForeColor = Color.FromArgb(0, 123, 255);
                ClearValidationError(txtItem);

                txtCantidadTransfer.Focus();
            }
            catch (Exception ex)
            {
                ShowValidationError(txtItem, $"Error: {ex.Message}");
                lblInfoItem.Text = "Error al validar item";
                lblInfoItem.ForeColor = _dangerColor;
            }
        }

        private void LoadDestinationWarehouses()
        {
            try
            {
                var destinations = _transferService.GetAvailableDestinations(_warehouseId);

                var destinationList = new List<DestinationItem>();
                destinationList.Add(new DestinationItem { WarehouseID = 0, WarehouseName = "Seleccione el destino" });

                foreach (var dest in destinations)
                {
                    destinationList.Add(new DestinationItem
                    {
                        WarehouseID = dest.WarehouseID,
                        WarehouseName = dest.WarehouseName
                    });
                }

                cmbDestinos.DataSource = destinationList;
                cmbDestinos.DisplayMember = "WarehouseName";
                cmbDestinos.ValueMember = "WarehouseID";
                cmbDestinos.SelectedIndex = 0;

                if (destinations.Count == 0)
                {
                    cmbDestinos.Enabled = false;
                    ShowInfo("No hay bodegas de destino disponibles");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al cargar bodegas de destino: {ex.Message}");
            }
        }

        private void TxtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if ((DateTime.Now - _lastScanTime).TotalMilliseconds < 500)
                {
                    DiscardPendingInput();
                }

                if (!string.IsNullOrWhiteSpace(txtItem.Text))
                {
                    ValidarItemOrigen();
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

        private void TxtCantidadTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidarCantidad())
                {
                    cmbDestinos.Focus();
                    e.Handled = true;
                }
            }
        }

        private void TxtCarnetTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RealizarTransferencia();
                e.Handled = true;
            }
        }

        private bool ValidarCantidad()
        {
            if (txtCantidadTransfer.Value == 0)
            {
                ShowValidationError(txtCantidadTransfer, "Ingrese una cantidad");
                return false;
            }

            int cantidad = (int)txtCantidadTransfer.Value;

            if (cantidad <= 0)
            {
                ShowValidationError(txtCantidadTransfer, "La cantidad debe ser mayor a cero");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtItem.Text))
            {
                string itemCode = txtItem.Text.Trim().ToUpper();
                var item = _transferService.GetItemByCodeAndWarehouse(itemCode, _warehouseId);
                if (item != null)
                {
                    int stockDisponible = (int)Math.Round(item.TotalQuantity);
                    if (cantidad > stockDisponible)
                    {
                        ShowValidationError(txtCantidadTransfer,
                            $"Stock insuficiente. Disponible: {stockDisponible:N0}, Solicitado: {cantidad:N0}");
                        return false;
                    }
                }
            }

            ClearValidationError(txtCantidadTransfer);
            return true;
        }

        private void ValidarItemOrigen()
        {
            try
            {
                string itemCode = txtItem.Text.Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(itemCode))
                {
                    ShowValidationError(txtItem, "Ingrese un código de item");
                    return;
                }

                if (EsCodigoEscaneado(itemCode))
                {
                    itemCode = LimpiarCodigoEscaneado(itemCode);
                }

                var item = _transferService.GetItemByCodeAndWarehouse(itemCode, _warehouseId);
                if (item == null)
                {
                    ShowValidationError(txtItem, $"El item '{itemCode}' no existe en esta bodega");
                    txtItem.SelectAll();    
                    return;
                }

                if (item.Description == "SIN DESCRIPCIÓN" || string.IsNullOrWhiteSpace(item.Description))
                {
                    ShowValidationError(txtItem, $"El código '{itemCode}' no es un item válido del sistema");
                    txtItem.SelectAll();
                    return;
                }

                int stockDisponible = (int)Math.Round(item.TotalQuantity);
                lblInfoItem.Text = $"{item.Description} - Stock disponible: {stockDisponible:N0}";
                lblInfoItem.ForeColor = Color.FromArgb(0, 123, 255);
                ClearValidationError(txtItem);

                txtCantidadTransfer.Focus();
            }
            catch (Exception ex)
            {
                ShowValidationError(txtItem, $"Error: {ex.Message}");
                lblInfoItem.Text = "Error al validar item";
                lblInfoItem.ForeColor = _dangerColor;
            }
        }

        private void RealizarTransferencia()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtItem.Text.Trim()))
                {
                    ShowValidationError(txtItem, "Ingrese un código de item");
                    return;
                }

                if (!ValidarCantidad())
                {
                    return;
                }

                if (cmbDestinos.SelectedValue == null)
                {
                    ShowValidationError(cmbDestinos, "Seleccione una bodega de destino");
                    return;
                }

                string selectedValueStr = cmbDestinos.SelectedValue.ToString();
                if (!int.TryParse(selectedValueStr, out int destinoId) || destinoId == 0)
                {
                    ShowValidationError(cmbDestinos, "Seleccione una bodega de destino válida");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCarnetTransfer.Text.Trim()))
                {
                    ShowValidationError(txtCarnetTransfer, "Ingrese su carnet");
                    return;
                }

                string itemCode = txtItem.Text.Trim().ToUpper();
                int cantidad = (int)txtCantidadTransfer.Value;
                string carnet = txtCarnetTransfer.Text.Trim().ToUpper();
                string destinoNombre = cmbDestinos.Text;

                var itemOrigen = _transferService.GetItemByCodeAndWarehouse(itemCode, _warehouseId);
                if (itemOrigen == null)
                {
                    ShowError($"El item '{itemCode}' ya no existe en esta bodega");
                    return;
                }

                int stockDisponible = (int)Math.Round(itemOrigen.TotalQuantity);
                if (cantidad > stockDisponible)
                {
                    ShowError($"Stock insuficiente. Disponible: {stockDisponible:N0}, Solicitado: {cantidad:N0}");
                    return;
                }

                var result = RadMessageBox.Show(
                    this,
                    $"¿Confirmar transferencia?\n\n" +
                    $"Item: {itemCode}\n" +
                    $"Cantidad: {cantidad:N0}\n" +
                    $"Origen: {_warehouseName}\n" +
                    $"Destino: {destinoNombre}\n" +
                    $"Responsable: {carnet}",
                    "Confirmar Transferencia",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    decimal cantidadDecimal = cantidad;

                    _transferService.TransferItem(
                        itemCode,
                        cantidadDecimal,
                        _warehouseId,
                        destinoId,
                        carnet,
                        $"Detalle de transferencia: Se movieron {cantidad:N0} unidades de '{itemCode}' desde {_warehouseName.ToUpperInvariant()} hacia {destinoNombre.ToUpperInvariant()}");

                    LimpiarControlesTransferencia();

                    LoadData();

                    ShowSuccess($"Transferencia realizada correctamente: {cantidad:N0} unidades de '{itemCode}' a {destinoNombre}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al realizar transferencia: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LimpiarControlesTransferencia()
        {
            txtItem.Text = "";
            txtCantidadTransfer.Value = 0;
            txtCarnetTransfer.Text = "";
            lblInfoItem.Text = "Ingrese código de item";
            lblInfoItem.ForeColor = _darkGray;

            ClearValidationError(txtItem);
            ClearValidationError(txtCantidadTransfer);
            ClearValidationError(txtCarnetTransfer);
            ClearValidationError(cmbDestinos);

            if (cmbDestinos.Items.Count > 0)
            {
                cmbDestinos.SelectedIndex = 0;
            }

            txtItem.Focus();
        }

        private void ShowValidationError(Control control, string message)
        {
            var toolTip = new RadToolTip();
            toolTip.ToolTipTitle = "Validación";
            toolTip.Show(message, control, 5000);
            control.Focus();
        }

        private void ClearValidationError(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.BackColor = Color.White;
            }
            else if (control is RadDropDownList dropDown)
            {
                dropDown.BackColor = Color.White;
            }
        }

        private void UpdateFormTitle()
        {
            lblTitulo.Text = $"INVENTARIO - {_warehouseName.ToUpper()}";
            this.Text = $"Inventario - {_warehouseName}";
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            PanelHeader.BackColor = _primaryColor;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 16f, FontStyle.Bold);

            StyleModernButton(btnRefrescar, _secondaryColor);
            StyleModernButton(btnNuevo, _accentColor);
            StyleModernButton(btnExportarExcel, _warningColor);
            txtBuscar.BackColor = Color.White;
        }

        private void StyleModernButton(RadButton button, Color color)
        {
            button.BackColor = color;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            button.Margin = new Padding(5);
        }

        private void ConfigureGridView()
        {
            this.GridViewData.MasterTemplate.Columns.Clear();

            this.GridViewData.MasterTemplate.AutoGenerateColumns = false;
            this.GridViewData.MasterTemplate.AllowAddNewRow = false;
            this.GridViewData.MasterTemplate.AllowDeleteRow = false;
            this.GridViewData.MasterTemplate.AllowEditRow = false;
            this.GridViewData.MasterTemplate.EnableFiltering = true;
            this.GridViewData.MasterTemplate.EnableGrouping = true;
            this.GridViewData.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridViewData.MasterTemplate.EnablePaging = false;
            this.GridViewData.MasterTemplate.ShowFilteringRow = true;

            this.GridViewData.EnableGestures = true;
            this.GridViewData.AllowCellContextMenu = false;
            this.GridViewData.MasterTemplate.AllowColumnReorder = false;

            this.GridViewData.TableElement.RowHeight = 36;
            this.GridViewData.TableElement.CellSpacing = 1;

            this.GridViewData.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            AddGridColumn("ItemID", "ID", false, 60);
            AddGridColumn("Code", "CÓDIGO", true, 300);
            AddGridColumn("Description", "DESCRIPCIÓN", true, 350);
            AddGridColumn("MaterialType", "TIPO MATERIAL", true, 150);
            AddGridColumn("TotalQuantity", "CANTIDAD", true, 120);
            AddGridColumn("Location", "UBICACIÓN", true, 125);
            AddGridColumn("BoxID", "CAJA", true, 120);
            AddGridColumn("CreatedDate", "FECHA REGISTRO", true, 210);
            AddGridColumn("ModifiedBy", "CARNET", true, 110);
            AddGridColumn("Name", "REGISTRADO POR", true, 200);
            AddGridColumn("ModifiedDate", "ÚLTIMA MODIFICACIÓN", true, 210);

            AddActionColumns();

            foreach (GridViewColumn column in GridViewData.MasterTemplate.Columns)
            {
                column.HeaderTextAlignment = ContentAlignment.MiddleCenter;
                if (column is GridViewTextBoxColumn textColumn)
                {
                    textColumn.TextAlignment = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void AddGridColumn(string fieldName, string headerText, bool visible, int width)
        {
            var column = new GridViewTextBoxColumn
            {
                FieldName = fieldName,
                HeaderText = headerText,
                IsVisible = visible,
                Width = width,
                TextAlignment = ContentAlignment.MiddleLeft,
                HeaderTextAlignment = ContentAlignment.MiddleCenter
            };

            if (fieldName == "TotalQuantity")
            {
                column.FormatString = "{0:N0}";
                column.TextAlignment = ContentAlignment.MiddleRight;
            }
            else if (fieldName.Contains("Date"))
            {
                column.FormatString = "{0:dd/MM/yyyy HH:mm}";
                column.TextAlignment = ContentAlignment.MiddleCenter;
            }

            this.GridViewData.MasterTemplate.Columns.Add(column);
        }

        private void AddActionColumns()
        {
            var editColumn = new GridViewCommandColumn
            {
                Name = "EditColumn",
                HeaderText = "EDITAR",
                UseDefaultText = true,
                DefaultText = "Editar",
                Width = 110,
                TextAlignment = ContentAlignment.MiddleCenter,
                HeaderTextAlignment = ContentAlignment.MiddleCenter
            };

            var deleteColumn = new GridViewCommandColumn
            {
                Name = "DeleteColumn",
                HeaderText = "ELIMINAR",
                UseDefaultText = true,
                DefaultText = "Eliminar",
                Width = 100,
                TextAlignment = ContentAlignment.MiddleCenter,
                HeaderTextAlignment = ContentAlignment.MiddleCenter
            };

            this.GridViewData.MasterTemplate.Columns.Add(editColumn);
            this.GridViewData.MasterTemplate.Columns.Add(deleteColumn);
        }

        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var items = _itemService.GetAllItems(_warehouseId);

                GridViewData.DataSource = items;
                UpdateStatistics(items);

                GridViewData.Refresh();
                Application.DoEvents();

                if (_isInitialLoad)
                {
                    _isInitialLoad = false;
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al cargar los datos: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateStatistics(List<ItemInv> items)
        {
            int totalItems = items.Count;
            decimal totalQuantity = items.Sum(item => item.TotalQuantity);
            int totalQuantityInt = (int)Math.Round(totalQuantity);
            int ubicacionesUnicas = items.Select(item => item.Location).Distinct().Count();
            int cajasUnicas = items.Select(item => item.BoxID).Distinct().Count();

            lblTotalItems.Text = totalItems.ToString("N0");
            lblTotalQuantity.Text = totalQuantityInt.ToString("N0");
            lblUbicaciones.Text = ubicacionesUnicas.ToString("N0");
            lblCajas.Text = cajasUnicas.ToString("N0");
        }

        private void GridViewData_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (_isEditing)
                return;

            try
            {
                _isEditing = true;

                if (e.Row is GridViewDataRowInfo dataRow && dataRow.IsCurrent)
                {
                    var itemIdCell = dataRow.Cells["ItemID"];
                    if (itemIdCell?.Value == null || itemIdCell.Value == DBNull.Value)
                    {
                        ShowError("No se puede identificar el item seleccionado.");
                        return;
                    }

                    int itemId = Convert.ToInt32(itemIdCell.Value);

                    if (e.Column != null)
                    {
                        if (e.Column.Name == "EditColumn")
                        {
                            EditarItem(itemId);
                        }
                        else if (e.Column.Name == "DeleteColumn")
                        {
                            EliminarItem(itemId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al procesar comando: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Error en CommandCellClick: {ex}");
            }
            finally
            {
                _isEditing = false;
            }
        }

        private void GridViewData_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (_isEditing || e.Row == null)
                return;

            try
            {
                _isEditing = true;
                if (e.Column is GridViewCommandColumn commandColumn)
                {
                    if (e.Row is GridViewDataRowInfo dataRow)
                    {
                        var itemIdCell = dataRow.Cells["ItemID"];
                        if (itemIdCell?.Value != null && itemIdCell.Value != DBNull.Value)
                        {
                            int itemId = Convert.ToInt32(itemIdCell.Value);

                            if (commandColumn.Name == "EditColumn")
                            {
                                EditarItem(itemId);
                            }
                            else if (commandColumn.Name == "DeleteColumn")
                            {
                                EliminarItem(itemId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error: {ex.Message}");
            }
            finally
            {
                _isEditing = false;
            }
        }

        private void GridViewData_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is GridCommandCellElement commandCell)
            {
                commandCell.DrawFill = true;
                commandCell.GradientStyle = GradientStyles.Solid;
                commandCell.BorderColor = _lightGray;
                commandCell.BorderWidth = 1;
                commandCell.NumberOfColors = 1;

                if (commandCell.ColumnInfo.Name == "EditColumn")
                {
                    commandCell.BackColor = _secondaryColor;
                    commandCell.ForeColor = Color.White;
                    commandCell.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
                }
                else if (commandCell.ColumnInfo.Name == "DeleteColumn")
                {
                    commandCell.BackColor = _dangerColor;
                    commandCell.ForeColor = Color.White;
                    commandCell.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
                }

                commandCell.TextAlignment = ContentAlignment.MiddleCenter;
            }

            if (e.CellElement is GridDataCellElement dataCell)
            {
                if (dataCell.ColumnInfo.Name == "TotalQuantity")
                {
                    if (decimal.TryParse(e.CellElement.Value?.ToString(), out decimal quantity))
                    {
                        int quantityInt = (int)Math.Round(quantity);

                        e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Bold);

                        if (quantityInt == 0)
                        {
                            e.CellElement.BackColor = Color.FromArgb(255, 235, 238);
                            e.CellElement.ForeColor = _dangerColor;
                            e.CellElement.Text = "SIN STOCK";
                        }
                        else if (quantityInt < 50)
                        {
                            e.CellElement.BackColor = Color.FromArgb(255, 243, 224);
                            e.CellElement.ForeColor = _warningColor;
                        }
                        else if (quantityInt < 100)
                        {
                            e.CellElement.BackColor = Color.FromArgb(255, 249, 196);
                            e.CellElement.ForeColor = Color.FromArgb(102, 102, 0);
                        }
                        else
                        {
                            e.CellElement.BackColor = Color.FromArgb(232, 245, 233);
                            e.CellElement.ForeColor = _accentColor;
                        }
                    }
                }

                else if (dataCell.ColumnInfo.Name == "Location")
                {
                    var location = e.CellElement.Value?.ToString();
                    if (string.IsNullOrEmpty(location))
                    {
                        e.CellElement.BackColor = Color.FromArgb(255, 243, 224);
                        e.CellElement.ForeColor = _warningColor;
                        e.CellElement.Text = "SIN UBICACIÓN";
                        e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Italic);
                    }
                }
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => LoadData();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new ItemDetailForm(_itemService, _currentUser, _warehouseId, _warehouseName))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        ShowSuccess("Item agregado correctamente al inventario.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al agregar item: {ex.Message}");
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportToExcel(GridViewData, $"Inventario de {_warehouseName}");
        }

        private void EditarItem(int itemId)
        {
            try
            {
                var item = _itemService.GetItemById(itemId);
                if (item != null)
                {
                    using (var form = new ItemDetailForm(_itemService, _currentUser, item))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                            ShowSuccess("Item actualizado correctamente.");
                        }
                    }
                }
                else
                {
                    ShowError("No se encontró el item seleccionado.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al editar item: {ex.Message}");
            }
        }

        private void EliminarItem(int itemId)
        {
            try
            {
                var item = _itemService.GetItemById(itemId);
                if (item == null)
                {
                    ShowError("No se encontró el item seleccionado.");
                    return;
                }

                var result = RadMessageBox.Show(
                    this,
                    $"¿Está seguro de eliminar el item?\n\nCódigo: {item.Code}\nDescripción: {item.Description}\nCantidad: {item.TotalQuantity:N0}\nBodega: {item.WarehouseName}",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (_itemService.DeleteItem(itemId))
                    {
                        LoadData();
                        ShowSuccess("Item eliminado correctamente.");
                    }
                    else
                    {
                        ShowError("No se pudo eliminar el item.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al eliminar item: {ex.Message}");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            PerformSearch();
        }

        private void PerformSearch()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrWhiteSpace(txtBuscar.Text.Trim()))
                {
                    LoadData();
                }
                else
                {
                    var items = _itemService.SearchItems(txtBuscar.Text.Trim(), _warehouseId);

                    GridViewData.DataSource = items;
                    UpdateStatistics(items);

                    GridViewData.Refresh();
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error al buscar: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void InventarioPreparacionForm_Load(object sender, EventArgs e)
        {
            this.GridViewData.ThemeName = "Fluent";
        }

        private void ShowError(string message) =>
            RadMessageBox.Show(this, message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);

        private void ShowSuccess(string message) =>
            RadMessageBox.Show(this, message, "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);

        private void ShowInfo(string message) =>
            RadMessageBox.Show(this, message, "Información", MessageBoxButtons.OK, RadMessageIcon.Info);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _searchTimer?.Stop();
            _searchTimer?.Dispose();
            base.OnFormClosing(e);
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            RealizarTransferencia();
        }

        public class DestinationItem
        {
            public int WarehouseID { get; set; }
            public string WarehouseName { get; set; }
        }

        private void txtItem_Click(object sender, EventArgs e)
        {
            txtItem.SelectAll();
        }
    }
}