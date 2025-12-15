using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Inventario
{
    public partial class ItemDetailForm : RadForm
    {
        private ItemService _itemService;
        private string _currentUser;
        private ItemInv _item;
        private bool _isEditMode;
        private bool _isValidatingCode = false;
        private DataTable _bomDataTable;
        private int _warehouseId;
        private string _warehouseName; // CORREGIDO: de object a string

        // Constructor para nuevo item con bodega específica
        public ItemDetailForm(ItemService itemService, string currentUser, int warehouseId, string warehouseName)
        {
            InitializeComponent();
            _itemService = itemService;
            _currentUser = currentUser;
            _isEditMode = false;
            _warehouseId = warehouseId;
            _warehouseName = warehouseName;
            _item = null;

            InitializeForm();
            InitializeEvents();
        }

        // Constructor para edición
        public ItemDetailForm(ItemService itemService, string currentUser, ItemInv item)
        {
            InitializeComponent();
            _itemService = itemService;
            _currentUser = currentUser;
            _item = item;
            _isEditMode = item != null && item.ItemID > 0;

            if (_isEditMode && _item != null)
            {
                _warehouseId = _item.WarehouseID;
                _warehouseName = _item.WarehouseName;
            }

            InitializeForm();
            InitializeEvents();
        }

        private void InitializeForm()
        {
            this.Text = _isEditMode ? "Editar Item" : "Nuevo Item";
            this.lblTitulo.Text = _isEditMode ? "EDITAR ITEM" : "NUEVO ITEM";

            // Mostrar información de la bodega
            if (_isEditMode && _item != null)
            {
                lblBodegaInfo.Text = $"Bodega: {_item.WarehouseName}";
            }
            else if (!_isEditMode && _warehouseId > 0)
            {
                lblBodegaInfo.Text = $"Bodega: {_warehouseName}";
            }

            ConfigureMultiColumnComboBox();

            if (_isEditMode)
            {
                LoadItemData();
                SetEditModeControls();
            }
            else
            {
                txtCantidad.Value = 0;
            }

            ConfigureValidation();
        }

        private void SetEditModeControls()
        {
            cmbCodigo.Enabled = false;
            txtDescripcion.ReadOnly = true;
            cmbCodigo.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            txtDescripcion.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            var toolTip = new RadToolTip();
            toolTip.SetToolTip(cmbCodigo, "El código no se puede modificar en modo edición");
            toolTip.SetToolTip(txtDescripcion, "La descripción no se puede modificar en modo edición");

            txtCantidad.Focus();
        }

        private void ConfigureMultiColumnComboBox()
        {
            try
            {
                LoadBomData();

                cmbCodigo.DropDownStyle = RadDropDownStyle.DropDown;
                cmbCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                var gridView = cmbCodigo.EditorControl.MasterTemplate;
                gridView.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                gridView.EnableFiltering = true;
                gridView.ShowFilteringRow = true;
                gridView.EnableAlternatingRowColor = true;

                gridView.Columns.Clear();
                gridView.Columns.Add(new GridViewTextBoxColumn("Code")
                {
                    HeaderText = "Código",
                    Width = 120
                });
                gridView.Columns.Add(new GridViewTextBoxColumn("Description")
                {
                    HeaderText = "Descripción",
                    Width = 250
                });
                gridView.Columns.Add(new GridViewTextBoxColumn("MaterialType")
                {
                    HeaderText = "Material",
                    Width = 130
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error configurando combo: {ex.Message}");
                RadMessageBox.Show(this, "Error al cargar los códigos disponibles", "Error",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void LoadBomData()
        {
            try
            {
                _bomDataTable = new DataTable();

                using (var connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    connection.Open();

                    var query = @"
                        SELECT DISTINCT 
                            sub_producto AS Code,
                            sub_descripcion AS Description,
                            ISNULL(sub_TypeMaterials, 'No especificado') AS MaterialType
                        FROM pmc_Subida_BOM 
                        ORDER BY sub_producto";

                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(_bomDataTable);
                    }
                }

                cmbCodigo.DataSource = _bomDataTable;
                cmbCodigo.DisplayMember = "Code";
                cmbCodigo.ValueMember = "Code";

                System.Diagnostics.Debug.WriteLine($"Cargados {_bomDataTable.Rows.Count} registros BOM");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando datos BOM: {ex.Message}");
                throw;
            }
        }

        private void InitializeEvents()
        {
            this.cmbCodigo.SelectedIndexChanged += CmbCodigo_SelectedIndexChanged;
            this.cmbCodigo.Validating += CmbCodigo_Validating;
            this.cmbCodigo.KeyDown += CmbCodigo_KeyDown;

            this.txtDescripcion.Validating += TxtDescripcion_Validating;
            this.txtCantidad.Validating += TxtCantidad_Validating;
            this.txtUbicacion.Validating += TxtUbicacion_Validating;
            this.txtIdCaja.Validating += TxtIdCaja_Validating;
            this.txtCarnet.Validating += TxtCarnet_Validating;

            this.btnGuardar.Click += btnGuardar_Click;
            this.btnCancelar.Click += btnCancelar_Click;

            this.KeyPreview = true;
            this.KeyDown += ItemDetailForm_KeyDown;
        }

        private void ConfigureValidation()
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            txtDescripcion.MaxLength = 200;
            txtUbicacion.MaxLength = 10;
            txtIdCaja.MaxLength = 20;
            txtCarnet.MaxLength = 20;
        }

        private void CmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCodigo.SelectedItem != null && !_isEditMode)
            {
                var selectedRow = cmbCodigo.SelectedItem as GridViewDataRowInfo;
                if (selectedRow != null)
                {
                    txtDescripcion.Text = selectedRow.Cells["Description"].Value?.ToString() ?? "";
                }
            }
        }

        private void CmbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !_isEditMode)
            {
                if (!string.IsNullOrWhiteSpace(cmbCodigo.Text))
                {
                    SearchAndAutoComplete(cmbCodigo.Text);
                    e.Handled = true;
                }
            }
        }

        private void SearchAndAutoComplete(string searchText)
        {
            try
            {
                if (_bomDataTable != null && _bomDataTable.Rows.Count > 0 && !_isEditMode)
                {
                    var exactMatches = _bomDataTable.Select($"Code = '{searchText.Replace("'", "''")}'");
                    if (exactMatches.Length > 0)
                    {
                        cmbCodigo.Text = exactMatches[0]["Code"].ToString();
                        txtDescripcion.Text = exactMatches[0]["Description"].ToString();
                        ClearValidationError(cmbCodigo);
                        return;
                    }

                    var partialMatches = _bomDataTable.Select($"Code LIKE '%{searchText.Replace("'", "''")}%'");
                    if (partialMatches.Length > 0)
                    {
                        cmbCodigo.Text = partialMatches[0]["Code"].ToString();
                        txtDescripcion.Text = partialMatches[0]["Description"].ToString();
                        ClearValidationError(cmbCodigo);
                    }
                    else
                    {
                        ShowValidationError(cmbCodigo, "Código no encontrado. Seleccione uno de la lista.");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en búsqueda: {ex.Message}");
            }
        }

        private void LoadItemData()
        {
            if (_item != null)
            {
                cmbCodigo.Text = _item.Code;
                txtDescripcion.Text = _item.Description;
                txtCantidad.Value = _item.TotalQuantity;
                txtUbicacion.Text = _item.Location;
                txtIdCaja.Text = _item.BoxID;
                
            }
        }

        #region Event Handlers

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarItem();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ItemDetailForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 || (e.Control && e.KeyCode == Keys.S))
            {
                btnGuardar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Tab && e.Control)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
            }
        }

        #endregion

        #region Validation Events

        private void CmbCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isValidatingCode) return;

            if (_isEditMode)
            {
                ClearValidationError(cmbCodigo);
                return;
            }

            var error = ValidateCodeField();
            if (!string.IsNullOrEmpty(error))
            {
                ShowValidationError(cmbCodigo, error);
            }
            else
            {
                ClearValidationError(cmbCodigo);
            }
        }

        private void TxtDescripcion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isEditMode)
            {
                ClearValidationError(txtDescripcion);
                return;
            }

            var error = ValidateDescriptionField();
            if (!string.IsNullOrEmpty(error))
            {
                ShowValidationError(txtDescripcion, error);
            }
            else
            {
                ClearValidationError(txtDescripcion);
            }
        }

        private void TxtCantidad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var error = ValidateQuantityField();
            if (!string.IsNullOrEmpty(error))
            {
                ShowValidationError(txtCantidad, error);
            }
            else
            {
                ClearValidationError(txtCantidad);
            }
        }

        private void TxtUbicacion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var error = ValidateLocationField();
            if (!string.IsNullOrEmpty(error))
            {
                ShowValidationError(txtUbicacion, error);
            }
            else
            {
                ClearValidationError(txtUbicacion);
            }
        }

        private void TxtIdCaja_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var error = ValidateBoxIdField();
            if (!string.IsNullOrEmpty(error))
            {
                ShowValidationError(txtIdCaja, error);
            }
            else
            {
                ClearValidationError(txtIdCaja);
            }
        }

        private void TxtCarnet_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var error = ValidateCarnetField();
            if (!string.IsNullOrEmpty(error))
            {
                ShowValidationError(txtCarnet, error);
            }
            else
            {
                ClearValidationError(txtCarnet);
            }
        }

        #endregion

        #region Validation Methods

        private string ValidateCodeField()
        {
            if (string.IsNullOrWhiteSpace(cmbCodigo.Text))
                return "El código es requerido.";

            if (cmbCodigo.Text.Length > 50)
                return "El código no puede tener más de 50 caracteres.";

            if (_bomDataTable != null)
            {
                var exists = _bomDataTable.Select($"Code = '{cmbCodigo.Text.Replace("'", "''")}'").Length > 0;
                if (!exists)
                {
                    return "El código no existe en el sistema. Por favor, seleccione un código válido de la lista.";
                }
            }

            return string.Empty;
        }

        private string ValidateDescriptionField()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                return "La descripción es requerida.";

            if (txtDescripcion.Text.Length > 200)
                return "La descripción no puede tener más de 200 caracteres.";

            return string.Empty;
        }

        private string ValidateQuantityField()
        {
            if (txtCantidad.Value < 0)
                return "La cantidad no puede ser negativa.";

            if (txtCantidad.Value > 1000000)
                return "La cantidad excede el límite permitido.";

            return string.Empty;
        }

        private string ValidateLocationField()
        {
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
                return "La ubicación es requerida.";

            if (txtUbicacion.Text.Length > 10)
                return "La ubicación no puede tener más de 10 caracteres.";

            return string.Empty;
        }

        private string ValidateBoxIdField()
        {
            if (string.IsNullOrWhiteSpace(txtIdCaja.Text))
                return "El ID de la caja es requerido.";

            if (txtIdCaja.Text.Length > 20)
                return "El ID de la caja no puede tener más de 20 caracteres.";

            return string.Empty;
        }

        private string ValidateCarnetField()
        {
            if (string.IsNullOrWhiteSpace(txtCarnet.Text))
                return "El carnet es requerido.";

            if (txtCarnet.Text.Length > 20)
                return "El carnet no puede tener más de 20 caracteres.";

            return string.Empty;
        }

        #endregion

        #region Helper Methods

        private void GuardarItem()
        {
            try
            {
                var errors = ValidateAllFields();
                if (errors.Count > 0)
                {
                    ShowFieldErrors(errors);
                    return;
                }

                if (!ValidateCodeUniqueness())
                    return;

                var item = new ItemInv
                {
                    Code = cmbCodigo.Text.Trim().ToUpper(),
                    Description = txtDescripcion.Text.Trim(),
                    MaterialType = "",
                    TotalQuantity = txtCantidad.Value,
                    Location = txtUbicacion.Text.Trim().ToUpper(),
                    BoxID = txtIdCaja.Text.Trim().ToUpper(),
                    Carnet = txtCarnet.Text.Trim().ToUpper(),
                    WarehouseID = _warehouseId // ¡CORREGIDO: Esta línea faltaba!
                };

                if (_isEditMode)
                {
                    item.ItemID = _item.ItemID;
                    item.WarehouseID = _item.WarehouseID; // Mantener bodega original
                    _itemService.UpdateItem(item, txtCarnet.Text.Trim());
                }
                else
                {
                    _itemService.InsertItem(item, txtCarnet.Text.Trim());
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Error al guardar el item: {ex.Message}");
            }
        }

        private Dictionary<Control, string> ValidateAllFields()
        {
            var errors = new Dictionary<Control, string>();

            if (!_isEditMode)
            {
                var codeError = ValidateCodeField();
                if (!string.IsNullOrEmpty(codeError))
                    errors.Add(cmbCodigo, codeError);

                var descError = ValidateDescriptionField();
                if (!string.IsNullOrEmpty(descError))
                    errors.Add(txtDescripcion, descError);
            }

            var quantityError = ValidateQuantityField();
            if (!string.IsNullOrEmpty(quantityError))
                errors.Add(txtCantidad, quantityError);

            var locationError = ValidateLocationField();
            if (!string.IsNullOrEmpty(locationError))
                errors.Add(txtUbicacion, locationError);

            var boxIdError = ValidateBoxIdField();
            if (!string.IsNullOrEmpty(boxIdError))
                errors.Add(txtIdCaja, boxIdError);

            var carnetError = ValidateCarnetField();
            if (!string.IsNullOrEmpty(carnetError))
                errors.Add(txtCarnet, carnetError);

            return errors;
        }

        private bool ValidateCodeUniqueness()
        {
            try
            {
                _isValidatingCode = true;

                if (_isEditMode)
                {
                    if (_itemService.CodeExists(cmbCodigo.Text.Trim(), _warehouseId, _item.ItemID))
                    {
                        ShowValidationError(cmbCodigo, $"Este código ya existe en la bodega {_warehouseName}. Por favor, use un código diferente.");
                        cmbCodigo.Focus();
                        return false;
                    }
                }
                else
                {
                    if (_itemService.CodeExists(cmbCodigo.Text.Trim(), _warehouseId))
                    {
                        ShowValidationError(cmbCodigo, $"Este código ya existe en la bodega {_warehouseName}. Por favor, use un código diferente.");
                        cmbCodigo.Focus();
                        return false;
                    }
                }

                return true;
            }
            finally
            {
                _isValidatingCode = false;
            }
        }

        private void ShowFieldErrors(Dictionary<Control, string> errors)
        {
            foreach (var error in errors)
            {
                ShowValidationError(error.Key, error.Value);
            }

            foreach (var error in errors)
            {
                error.Key.Focus();
                break;
            }
        }

        private void ShowValidationError(Control control, string message)
        {
            var toolTip = new RadToolTip();
            toolTip.ToolTipTitle = "Validación";
            toolTip.Show(message, control, 9000);
        }

        private void ClearValidationError(Control control)
        {
            // Los tooltips se limpian automáticamente
        }

        private void ShowError(string message)
        {
            RadMessageBox.Show(this, message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
        }

        private void ShowInfo(string message)
        {
            RadMessageBox.Show(this, message, "Información", MessageBoxButtons.OK, RadMessageIcon.Info);
        }

        #endregion
    }
}