using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using GridViewAutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode;

namespace Rmc.MaterialEmpaque.Inventario
{
    public partial class InventarioSobrantesForm : Telerik.WinControls.UI.RadForm
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;
        private int currentEditId = -1;
        private bool isEditMode = false;

        public InventarioSobrantesForm()
        {
            InitializeComponent();
            this.Shown += (s, e) => cmbSaca.Focus();
        }

        private void InventarioSobrantesForm_Load(object sender, EventArgs e)
        {
            CargarSacas();
            ConfigurarAutocompletado();
            ConfigurarGrid();
            LimpiarFormulario();
            CargarSobrantes();
        }

        private void ConfigurarAutocompletado()
        {
            cmbSaca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSaca.AutoCompleteDataSource = AutoCompleteSource.ListItems;
            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbItem.AutoCompleteDataSource = AutoCompleteSource.ListItems;
        }

        private void CargarSacas()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT DISTINCT sub_SACA AS Saca 
                        FROM pmc_Subida_BOM 
                        ORDER BY sub_SACA", connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        cmbSaca.Items.Clear();
                        while (reader.Read())
                        {
                            cmbSaca.Items.Add(reader["Saca"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error cargando sacas: {ex.Message}", true);
            }
        }

        private void cmbSaca_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cmbSaca.SelectedItem != null && !isEditMode)
            {
                string sacaSeleccionada = cmbSaca.SelectedItem.Text;
                CargarItemsPorSaca(sacaSeleccionada);
            }
        }

        private void CargarItemsPorSaca(string saca)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT DISTINCT sub_producto AS Item 
                        FROM pmc_Subida_BOM 
                        WHERE sub_SACA = @Saca
                        ORDER BY sub_producto", connection))
                    {
                        command.Parameters.AddWithValue("@Saca", saca);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        cmbItem.Items.Clear();
                        while (reader.Read())
                        {
                            cmbItem.Items.Add(reader["Item"].ToString());
                        }

                        cmbItem.Enabled = cmbItem.Items.Count > 0;
                        if (cmbItem.Enabled)
                            cmbItem.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error cargando items: {ex.Message}", true);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                string saca = cmbSaca.SelectedItem.Text;
                string item = cmbItem.SelectedItem.Text;
                decimal cantidad = decimal.Parse(txtCantidad.Text);
                string localidad = string.IsNullOrWhiteSpace(txtLocalidad.Text) ? "N/A" : txtLocalidad.Text;
                string carnet = txtCarnet.Text.Trim();

                if (!ValidarCarnet(carnet))
                {
                    MostrarMensaje("Carnet no válido", true);
                    return;
                }

                if (currentEditId == -1 && ExisteRegistro(saca, item))
                {
                    string ubicacionExistente = ObtenerUbicacionExistente(saca, item);
                    if (ubicacionExistente != localidad && !string.IsNullOrEmpty(ubicacionExistente))
                    {
                        MostrarMensaje($"Este ítem ya tiene ubicación", false);
                    }

                    SumarCantidadExistente(saca, item, cantidad, carnet, ubicacionExistente);
                }
                else if (currentEditId > 0)
                {
                    // En modo edición, permitir cambiar la ubicación
                    ActualizarRegistro(currentEditId, cantidad, localidad, carnet);
                }
                else
                {
                    // Insertar nuevo registro
                    InsertarNuevoRegistro(saca, item, localidad, cantidad, carnet);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al procesar: {ex.Message}", true);
            }
        }

        private bool ExisteRegistro(string saca, string item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT COUNT(*) FROM dbo.pmc_InventoryOverstock 
                        WHERE Saca = @Saca AND Item = @Item", connection))
                    {
                        command.Parameters.AddWithValue("@Saca", saca);
                        command.Parameters.AddWithValue("@Item", item);

                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error verificando registro: {ex.Message}", true);
                return false;
            }
        }

        private string ObtenerUbicacionExistente(string saca, string item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT Location FROM dbo.pmc_InventoryOverstock 
                        WHERE Saca = @Saca AND Item = @Item", connection))
                    {
                        command.Parameters.AddWithValue("@Saca", saca);
                        command.Parameters.AddWithValue("@Item", item);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        return result != null ? result.ToString() : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error obteniendo ubicación: {ex.Message}", true);
                return string.Empty;
            }
        }

        private void SumarCantidadExistente(string saca, string item, decimal cantidad, string carnet, string ubicacionExistente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        UPDATE dbo.pmc_InventoryOverstock 
                        SET Quantity = Quantity + @Cantidad,
                            UpdatedBy = @UpdatedBy,
                            UpdatedAt = GETDATE()
                        WHERE Saca = @Saca AND Item = @Item", connection))
                    {
                        command.Parameters.AddWithValue("@Cantidad", cantidad);
                        command.Parameters.AddWithValue("@Saca", saca);
                        command.Parameters.AddWithValue("@Item", item);
                        command.Parameters.AddWithValue("@UpdatedBy", carnet);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MostrarMensaje($"Cantidad agregada (+{cantidad})");
                            LimpiarFormulario();
                            CargarSobrantes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al sumar cantidad: {ex.Message}", true);
            }
        }

        private void InsertarNuevoRegistro(string saca, string item, string localidad, decimal cantidad, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        INSERT INTO dbo.pmc_InventoryOverstock 
                        (Saca, Item, Code, Location, Quantity, CreatedBy, UpdatedBy)
                        VALUES 
                        (@Saca, @Item, NULL, @Location, @Quantity, @CreatedBy, @UpdatedBy)", connection))
                    {
                        command.Parameters.AddWithValue("@Saca", saca);
                        command.Parameters.AddWithValue("@Item", item);
                        command.Parameters.AddWithValue("@Location", localidad);
                        command.Parameters.AddWithValue("@Quantity", cantidad);
                        command.Parameters.AddWithValue("@CreatedBy", carnet);
                        command.Parameters.AddWithValue("@UpdatedBy", carnet);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MostrarMensaje($"Sobrante agregado exitosamente en ubicación: {localidad}");
                            LimpiarFormulario();
                            CargarSobrantes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al agregar: {ex.Message}", true);
            }
        }

        private void ActualizarRegistro(int id, decimal cantidad, string localidad, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        UPDATE dbo.pmc_InventoryOverstock 
                        SET Quantity = @Quantity,
                            Location = @Location,
                            UpdatedBy = @UpdatedBy,
                            UpdatedAt = GETDATE()
                        WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Quantity", cantidad);
                        command.Parameters.AddWithValue("@Location", localidad);
                        command.Parameters.AddWithValue("@UpdatedBy", carnet);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MostrarMensaje("Registro actualizado exitosamente");
                            LimpiarFormulario();
                            CargarSobrantes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al actualizar: {ex.Message}", true);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridSobrantes.CurrentRow != null && gridSobrantes.CurrentRow is GridViewDataRowInfo row)
            {
                currentEditId = Convert.ToInt32(row.Cells["Id"].Value);

                string saca = row.Cells["Saca"].Value.ToString();
                string item = row.Cells["Item"].Value.ToString();

                cmbSaca.SelectedItem = cmbSaca.Items
                    .FirstOrDefault(x => x.Text == saca);

                CargarItemsPorSaca(saca);

                cmbItem.SelectedItem = cmbItem.Items
                    .FirstOrDefault(x => x.Text == item);

                txtCantidad.Text = row.Cells["Quantity"].Value.ToString();
                txtLocalidad.Text = row.Cells["Location"].Value.ToString();

                isEditMode = true;
                cmbSaca.Enabled = false;
                cmbItem.Enabled = false;
                btnAgregar.Text = "Actualizar";
                btnCancelar.Visible = true;

                MostrarMensaje(" - Editando registro (puede cambiar ubicación)");

                txtCantidad.Focus();
            }
            else
            {
                MostrarMensaje("Seleccione un registro para editar", true);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridSobrantes.CurrentRow != null && gridSobrantes.CurrentRow is GridViewDataRowInfo row)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string saca = row.Cells["Saca"].Value.ToString();
                string item = row.Cells["Item"].Value.ToString();

                DialogResult result = RadMessageBox.Show(
                    this,
                    $"¿Está seguro de eliminar el registro?\nSaca: {saca}\nItem: {item}",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    EliminarRegistro(id);
                }
            }
            else
            {
                MostrarMensaje("Seleccione un registro para eliminar", true);
            }
        }

        private void EliminarRegistro(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM dbo.pmc_InventoryOverstock WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MostrarMensaje("Registro eliminado exitosamente");
                            CargarSobrantes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al eliminar: {ex.Message}", true);
            }
        }

        private bool ValidarCarnet(string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT COUNT(*) FROM mst_Empleados WHERE Emp_ID = @Carnet", connection))
                    {
                        command.Parameters.AddWithValue("@Carnet", carnet);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error validando carnet: {ex.Message}", true);
                return false;
            }
        }

        private bool ValidarFormulario()
        {
            if (cmbSaca.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSaca.Text))
            {
                MostrarMensaje("Seleccione un Saca", true);
                cmbSaca.Focus();
                return false;
            }

            if (cmbItem.SelectedItem == null || string.IsNullOrWhiteSpace(cmbItem.Text))
            {
                MostrarMensaje("Seleccione un Item", true);
                cmbItem.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MostrarMensaje("Ingrese una cantidad válida mayor a 0", true);
                txtCantidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCarnet.Text))
            {
                MostrarMensaje("Ingrese su carnet", true);
                txtCarnet.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            currentEditId = -1;
            isEditMode = false;
            cmbSaca.SelectedIndex = -1;
            cmbSaca.Text = "";
            cmbSaca.Enabled = true;
            cmbItem.SelectedIndex = -1;
            cmbItem.Text = "";
            cmbItem.Enabled = false;
            txtCantidad.Text = "";
            txtLocalidad.Text = "";
            txtCarnet.Text = "";

            btnAgregar.Text = "Agregar";
            btnCancelar.Visible = false;

            if (cmbSaca.Items.Count > 0)
                cmbSaca.Focus();
        }

        private void CargarSobrantes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(@"
                        SELECT
                            ov.Id,
                            ov.Saca,
                            ov.Item,
                            sb.Description,
                            sb.TypeMaterial,
                            ov.Location,
                            CAST(ov.Quantity AS INT) AS Quantity,
                            ov.CreatedBy AS Carnet,
                            CONCAT(
                                LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1), ' ',
                                LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1)
                            ) AS Responsable,
                            FORMAT(ov.CreatedAt, 'hh:mm tt') AS Hora,
                            FORMAT(ov.CreatedAt, 'dd MMM yyyy', 'en-us') AS Fecha,
                            FORMAT(ov.UpdatedAt, 'dd MMM yyyy hh:mm tt', 'en-us') AS Actualizado
                        FROM dbo.pmc_InventoryOverstock ov
                        LEFT JOIN mst_Empleados emp 
                            ON ov.CreatedBy = emp.Emp_ID
                        LEFT JOIN (
                                SELECT 
                                    sub_producto,
                                    sub_descripcion AS Description,
                                    sub_TypeMaterials AS TypeMaterial,
                                    ROW_NUMBER() OVER(PARTITION BY sub_producto ORDER BY sub_producto) AS rn
                                FROM pmc_Subida_BOM
                            ) sb
                            ON ov.Item = sb.sub_producto AND sb.rn = 1
                        ORDER BY ov.CreatedAt DESC", connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        gridSobrantes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error cargando sobrantes: {ex.Message}", true);
            }
        }

        private void ConfigurarGrid()
        {
            gridSobrantes.MasterTemplate.AllowAddNewRow = false;
            gridSobrantes.MasterTemplate.AllowDeleteRow = false;
            gridSobrantes.MasterTemplate.AllowEditRow = false;
            gridSobrantes.MasterTemplate.EnableFiltering = true;
            gridSobrantes.MasterTemplate.EnableGrouping = true;
            gridSobrantes.MasterTemplate.EnableAlternatingRowColor = true;
            gridSobrantes.AutoGenerateColumns = false;

            gridSobrantes.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            gridSobrantes.MasterTemplate.ShowRowHeaderColumn = false;

            CrearColumnasGrid();
        }

        private void CrearColumnasGrid()
        {
            gridSobrantes.Columns.Clear();

            AgregarColumna("Saca", "SACA", 150);
            AgregarColumna("Item", "ITEM", 150);
            AgregarColumna("Description", "DESCRIPCIÓN", 350);
            AgregarColumna("TypeMaterial", "TIPO MATERIAL", 150);
            AgregarColumna("Location", "UBICACIÓN", 120);
            AgregarColumnaDecimal("Quantity", "CANTIDAD", 100);
            AgregarColumna("Carnet", "CARNET", 80);
            AgregarColumna("Responsable", "RESPONSABLE", 150);
            AgregarColumna("Hora", "HORA", 80);
            AgregarColumna("Fecha", "FECHA", 100);

            GridViewTextBoxColumn columnaId = new GridViewTextBoxColumn();
            columnaId.FieldName = "Id";
            columnaId.HeaderText = "ID";
            columnaId.Width = 50;
            columnaId.IsVisible = false;
            gridSobrantes.Columns.Add(columnaId);
        }

        private void AgregarColumna(string fieldName, string headerText, int width)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            columna.AllowResize = true;
            columna.AutoSizeMode = BestFitColumnMode.None;

            gridSobrantes.Columns.Add(columna);
        }

        private void AgregarColumnaDecimal(string fieldName, string headerText, int width)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            columna.AllowResize = true;
            columna.AutoSizeMode = BestFitColumnMode.None;
            columna.FormatString = "{0:N0}";

            gridSobrantes.Columns.Add(columna);
        }

        private void MostrarMensaje(string mensaje, bool esError = false)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = esError ? Color.Red : Color.Green;
            lblMensaje.Font = new Font(lblMensaje.Font, FontStyle.Bold);

            Timer timer = new Timer();
            timer.Interval = esError ? 7000 : 5000;
            timer.Tick += (s, e) => {
                lblMensaje.Text = "";
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarSobrantes();
            CargarSacas();
            MostrarMensaje("Datos actualizados");
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCarnet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ValidarFormulario())
            {
                btnAgregar_Click(sender, e);
            }
        }

        private void ActualizarDatos()
        {
            try
            {
                MostrarMensaje("Actualizando datos...");
                CargarSobrantes();
                MostrarMensaje("Datos actualizados correctamente");
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al actualizar datos: {ex.Message}", true);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }


        private void cmbSaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Navegar al siguiente control
                if (cmbItem.Enabled)
                {
                    cmbItem.Focus();
                }
                else
                {
                    txtCantidad.Focus();
                }
            }
        }

        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Navegar al siguiente control
                txtLocalidad.Focus();
            }
        }

        private void txtLocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Navegar al siguiente control
                txtCarnet.Focus();
            }
        }

    }
}