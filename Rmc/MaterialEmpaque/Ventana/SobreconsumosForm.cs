using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Ventana
{
    public partial class SobreconsumosForm : Telerik.WinControls.UI.RadForm
    {
        private string connectionString = Properties.Settings.Default.TracerConnectionString;
        private Timer timerRefresco;

        public SobreconsumosForm()
        {
            InitializeComponent();
            ConfigurarTimer();
            ConfigurarGrid();
            CargarCombos();
            CargarSolicitudes();
            CargarUltimoSobreconsumo();
            ConfigurarEventosFormulario();
        }

        private void ConfigurarTimer()
        {
            timerRefresco = new Timer();
            timerRefresco.Interval = 60000;
            timerRefresco.Tick += TimerRefresco_Tick;
            timerRefresco.Start();
        }

        private void TimerRefresco_Tick(object sender, EventArgs e)
        {
            CargarSolicitudes();
            CargarUltimoSobreconsumo();
        }

        private void CargarUltimoSobreconsumo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                   SELECT TOP(1)
	                    T.TraceID AS SobreconsumoID,
                        CONCAT(T.TraceIDBase, '-', T.SobreconsumoNumber) AS TraceID,
                        T.SACA,
                        T.MachineCode AS Maquina,
                        T.Celula,
                        FORMAT(K.StartDate, 'hh:mm tt', 'en-US') AS Hora,
                        FORMAT(k.StartDate, 'dd MMM yyyy', 'en-US') AS Fecha
                    FROM ES_SOCKS.dbo.pmc_Transactions T
                    INNER JOIN ES_SOCKS.dbo.pmc_Status S ON T.StatusID = S.StatusID
                    LEFT JOIN es_socks.dbo.mst_Empleados E ON T.Badge = E.Emp_ID
                    LEFT JOIN ES_SOCKS.dbo.pmc_StatusTracking K ON T.ID = K.TransactionID
                    WHERE T.IsSobreconsumo = 1
                      AND T.StatusID IN (5)
                    ORDER BY 
                        K.StartDate DESC,
	                    K.StatusID DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUltimoSobreconsumo.Text = reader["SobreconsumoID"].ToString();
                                txtUltimoTraceId.Text = reader["TraceID"].ToString();
                                txtUltimoSaca.Text = reader["SACA"].ToString();
                                txtUltimaMaquina.Text = reader["Maquina"].ToString();
                                txtUltimaCelula.Text = reader["Celula"].ToString();
                                txtUltimaHora.Text = reader["Hora"].ToString() + " - " + reader["Fecha"].ToString();
                            }
                            else
                            {
                                LimpiarCamposUltimoSobreconsumo();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LimpiarCamposUltimoSobreconsumo();
                Console.WriteLine($"Error al cargar último sobreconsumo: {ex.Message}");
            }
        }

        private void LimpiarCamposUltimoSobreconsumo()
        {
            txtUltimoSobreconsumo.Text = "No hay datos";
            txtUltimoTraceId.Text = "No hay datos";
            txtUltimoSaca.Text = "No hay datos";
            txtUltimaMaquina.Text = "No hay datos";
            txtUltimaCelula.Text = "No hay datos";
            txtUltimaHora.Text = "No hay datos";
        }

        private void ConfigurarEventosFormulario()
        {
            btnEnviar.Click += btnEnviar_Click;
            btnCancelar.Click += btnCancelar_Click;

            txtDocenas.KeyPress += txtDocenas_KeyPress;
            txtCarnet.KeyPress += txtCarnet_KeyPress;
            txtTraceID.KeyPress += txtTraceID_KeyPress;

            txtTraceID.KeyDown += Control_KeyDown;
            cmbMaquinas.KeyDown += Control_KeyDown;
            cmbCelulas.KeyDown += Control_KeyDown;
            txtDocenas.KeyDown += Control_KeyDown;
            txtCarnet.KeyDown += Control_KeyDown;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar el sonido del sistema

                Control control = sender as Control;
                if (control != null)
                {
                    SeleccionarSiguienteControl(control);
                }
            }
        }

        private void SeleccionarSiguienteControl(Control controlActual)
        {
            switch (controlActual.Name)
            {
                case "txtTraceID":
                    if (cmbMaquinas.Items.Count > 0)
                        cmbMaquinas.Focus();
                    else
                        cmbCelulas.Focus();
                    break;

                case "cmbMaquinas":
                    if (cmbCelulas.Items.Count > 0)
                        cmbCelulas.Focus();
                    else
                        txtDocenas.Focus();
                    break;

                case "cmbCelulas":
                    txtDocenas.Focus();
                    break;

                case "txtDocenas":
                    txtCarnet.Focus();
                    break;

                case "txtCarnet":
                    if (ValidarFormulario())
                    {
                        btnEnviar_Click(btnEnviar, EventArgs.Empty);
                    }
                    else
                    {
                        ValidarFormulario();
                    }
                    break;
            }
        }

        private void CargarCombos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Cargar máquinas
                    string queryMaquinas = "SELECT MachID FROM pmc_Maquinas ORDER BY MachID";
                    using (SqlCommand cmd = new SqlCommand(queryMaquinas, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbMaquinas.Items.Clear();
                        while (reader.Read())
                        {
                            cmbMaquinas.Items.Add(reader["MachID"].ToString());
                        }
                    }

                    // Cargar células
                    string queryCelulas = "SELECT CelulaID FROM pmc_Celulas ORDER BY CelulaID";
                    using (SqlCommand cmd = new SqlCommand(queryCelulas, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbCelulas.Items.Clear();
                        while (reader.Read())
                        {
                            cmbCelulas.Items.Add(reader["CelulaID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void txtDocenas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as RadTextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTraceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarFormulario()
        {
            // Validar TraceID
            if (string.IsNullOrWhiteSpace(txtTraceID.Text))
            {
                MostrarMensaje("El TraceID es requerido", false);
                txtTraceID.Focus();
                return false;
            }

            if (!long.TryParse(txtTraceID.Text, out long traceID) || traceID <= 0)
            {
                MostrarMensaje("El TraceID no es válido", false);
                txtTraceID.Focus();
                return false;
            }

            // Validar que el TraceID exista en la base de datos
            if (!ValidarTraceIDEnBaseDatos(traceID))
            {
                MostrarMensaje("El TraceID no existe", false);
                txtTraceID.Focus();
                return false;
            }

            // Validar Máquina
            if (cmbMaquinas.SelectedItem == null)
            {
                MostrarMensaje("Debe seleccionar una máquina", false);
                cmbMaquinas.Focus();
                return false;
            }

            // Validar Célula
            if (cmbCelulas.SelectedItem == null)
            {
                MostrarMensaje("Debe seleccionar una célula", false);
                cmbCelulas.Focus();
                return false;
            }

            // Validar Docenas
            if (string.IsNullOrWhiteSpace(txtDocenas.Text))
            {
                MostrarMensaje("Las docenas son requeridas", false);
                txtDocenas.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDocenas.Text, out decimal docenas) || docenas <= 0)
            {
                MostrarMensaje("Las docenas no son válida", false);
                txtDocenas.Focus();
                return false;
            }

            // Validar Carnet
            if (string.IsNullOrWhiteSpace(txtCarnet.Text))
            {
                MostrarMensaje("El carnet es requerido", false);
                txtCarnet.Focus();
                return false;
            }

            // Validar que el carnet exista en la base de datos
            if (!ValidarCarnetEnBaseDatos(txtCarnet.Text))
            {
                MostrarMensaje("El carnet no es valido", false);
                txtCarnet.Focus();
                return false;
            }

            if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
            {
                MostrarMensaje("El carnet no es válido", false);
                txtCarnet.Focus();
                return false;
            }

            return true;
        }

        private void MostrarMensaje(string mensaje, bool esExito = true)
        {
            lblMensaje.Text = mensaje;
            if (esExito)
            {
                lblMensaje.ForeColor = Color.FromArgb(0, 102, 51); // Verde oscuro
                lblMensaje.BackColor = Color.FromArgb(230, 245, 230); // Verde claro
            }
            else
            {
                lblMensaje.ForeColor = Color.FromArgb(139, 0, 0); // Rojo oscuro
                lblMensaje.BackColor = Color.FromArgb(255, 230, 230); // Rojo claro
            }
        }

        private void LimpiarFormulario()
        {
            txtTraceID.Clear();
            cmbMaquinas.SelectedIndex = -1;
            cmbCelulas.SelectedIndex = -1;
            txtDocenas.Clear();
            txtCarnet.Clear();
            lblMensaje.Text = string.Empty;
            txtTraceID.Focus();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                // Obtener valores del formulario
                long traceIDBase = long.Parse(txtTraceID.Text);

                decimal dozens = decimal.Parse(txtDocenas.Text);
                string badge = txtCarnet.Text;
                string machineCode = cmbMaquinas.SelectedItem.ToString();
                string celula = cmbCelulas.SelectedItem.ToString();

                // Ejecutar stored procedure
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("dbo.sp_CreateSobreconsumoTransaction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TraceIDBase", traceIDBase);
                        command.Parameters.AddWithValue("@Dozens", dozens);
                        command.Parameters.AddWithValue("@Badge", badge);
                        command.Parameters.AddWithValue("@MachineCode", machineCode);
                        command.Parameters.AddWithValue("@Celula", celula);

                        command.ExecuteNonQuery();
                    }
                }

                // Mostrar mensaje de éxito
                MostrarMensaje("Solicitud creada exitosamente", true);

                LimpiarFormulario();
                CargarSolicitudes();
                CargarUltimoSobreconsumo();

                RadMessageBox.Show("Solicitud de sobreconsumo creada exitosamente", "Éxito",
                    MessageBoxButtons.OK, RadMessageIcon.Info);

            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627) // Violación de unique key
                {
                    MostrarMensaje("El TraceID ya existe en el sistema", false);
                }
                else if (sqlEx.Number == 547) // Violación de FK
                {
                    MostrarMensaje("Error de referencia: verifique los datos ingresados", false);
                }
                else if (sqlEx.Number == 50000) // Error personalizado del stored procedure
                {
                    MostrarMensaje(sqlEx.Message, false);
                }
                else
                {
                    MostrarMensaje($"Error de base de datos: {sqlEx.Message}", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al crear solicitud: {ex.Message}", false);
            }
        }

        private bool ExisteSobreconsumoParaTraceID(long traceIDBase)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    string query = @"
                SELECT COUNT(*) 
                FROM ES_SOCKS.dbo.pmc_Transactions 
                WHERE TraceIDBase = @TraceIDBase 
                AND IsSobreconsumo = 1
                AND StatusID IN (1, 2, 3)"; // Solo contar los activos

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TraceIDBase", traceIDBase);
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar sobreconsumo existente: {ex.Message}");
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            MostrarMensaje("Formulario limpiado", true);
        }

        private void ConfigurarGrid()
        {
            gridSolicitudes.MasterTemplate.Columns.Clear();

            gridSolicitudes.AutoGenerateColumns = false;
            gridSolicitudes.AllowAddNewRow = false;
            gridSolicitudes.AllowEditRow = false;

            gridSolicitudes.EnableAlternatingRowColor = true;
            gridSolicitudes.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            gridSolicitudes.TableElement.RowHeight = 35;

            gridSolicitudes.ThemeName = "Fluent";

            gridSolicitudes.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridSolicitudes.MasterTemplate.AllowAutoSizeColumns = false;

            GridViewTextBoxColumn sobreConsumoIDColumn = new GridViewTextBoxColumn();
            sobreConsumoIDColumn.Name = "SobreConsumoID";
            sobreConsumoIDColumn.FieldName = "SobreConsumoID";
            sobreConsumoIDColumn.HeaderText = "SOBRECONSUMO ID";
            sobreConsumoIDColumn.Width = 170;
            sobreConsumoIDColumn.TextAlignment = ContentAlignment.MiddleCenter;
            sobreConsumoIDColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;
            sobreConsumoIDColumn.IsVisible = true;

            GridViewTextBoxColumn docenasColumn = new GridViewTextBoxColumn();
            docenasColumn.Name = "Dozens";
            docenasColumn.FieldName = "Dozens";
            docenasColumn.HeaderText = "DOCENAS";
            docenasColumn.Width = 80;
            docenasColumn.TextAlignment = ContentAlignment.MiddleCenter;
            docenasColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn traceIDColumn = new GridViewTextBoxColumn();
            traceIDColumn.Name = "TraceID";
            traceIDColumn.FieldName = "TraceID";
            traceIDColumn.HeaderText = "TRACE ID";
            traceIDColumn.Width = 130;
            traceIDColumn.TextAlignment = ContentAlignment.MiddleCenter;
            traceIDColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn sacaColumn = new GridViewTextBoxColumn();
            sacaColumn.Name = "SACA";
            sacaColumn.FieldName = "SACA";
            sacaColumn.HeaderText = "SA/CA";
            sacaColumn.Width = 80;
            sacaColumn.TextAlignment = ContentAlignment.MiddleCenter;
            sacaColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn sacaSegColumn = new GridViewTextBoxColumn();
            sacaSegColumn.Name = "SACASeg";
            sacaSegColumn.FieldName = "SACASeg";
            sacaSegColumn.HeaderText = "SA/CA SEG";
            sacaSegColumn.Width = 90;
            sacaSegColumn.TextAlignment = ContentAlignment.MiddleCenter;
            sacaSegColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn maquinaColumn = new GridViewTextBoxColumn();
            maquinaColumn.Name = "CodigoMaquina";
            maquinaColumn.FieldName = "CodigoMaquina";
            maquinaColumn.HeaderText = "MÁQUINA";
            maquinaColumn.Width = 90;
            maquinaColumn.TextAlignment = ContentAlignment.MiddleCenter;
            maquinaColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn celulaColumn = new GridViewTextBoxColumn();
            celulaColumn.Name = "Celula";
            celulaColumn.FieldName = "Celula";
            celulaColumn.HeaderText = "CÉLULA";
            celulaColumn.Width = 80;
            celulaColumn.TextAlignment = ContentAlignment.MiddleCenter;
            celulaColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn carnetColumn = new GridViewTextBoxColumn();
            carnetColumn.Name = "Carnet";
            carnetColumn.FieldName = "Carnet";
            carnetColumn.HeaderText = "CARNET";
            carnetColumn.Width = 80;
            carnetColumn.TextAlignment = ContentAlignment.MiddleCenter;
            carnetColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn nombreColumn = new GridViewTextBoxColumn();
            nombreColumn.Name = "Nombre";
            nombreColumn.FieldName = "Nombre";
            nombreColumn.HeaderText = "OPERADOR";
            nombreColumn.Width = 150;
            nombreColumn.TextAlignment = ContentAlignment.MiddleLeft;
            nombreColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn horaColumn = new GridViewTextBoxColumn();
            horaColumn.Name = "Hora";
            horaColumn.FieldName = "Hora";
            horaColumn.HeaderText = "HORA";
            horaColumn.Width = 80;
            horaColumn.TextAlignment = ContentAlignment.MiddleCenter;
            horaColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn fechaColumn = new GridViewTextBoxColumn();
            fechaColumn.Name = "Fecha";
            fechaColumn.FieldName = "Fecha";
            fechaColumn.HeaderText = "FECHA";
            fechaColumn.Width = 100;
            fechaColumn.TextAlignment = ContentAlignment.MiddleCenter;
            fechaColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            GridViewTextBoxColumn estadoColumn = new GridViewTextBoxColumn();
            estadoColumn.Name = "Estado";
            estadoColumn.FieldName = "Estado";
            estadoColumn.HeaderText = "ESTADO";
            estadoColumn.Width = 100;
            estadoColumn.TextAlignment = ContentAlignment.MiddleCenter;
            estadoColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            // Columna de Acción con botón - CON ESTILO MEJORADO
            GridViewCommandColumn accionColumn = new GridViewCommandColumn();
            accionColumn.Name = "Accion";
            accionColumn.HeaderText = "CERRAR";
            accionColumn.Width = 80;
            accionColumn.UseDefaultText = true;
            accionColumn.DefaultText = "Cerrar";
            accionColumn.TextAlignment = ContentAlignment.MiddleCenter;
            accionColumn.HeaderTextAlignment = ContentAlignment.MiddleCenter;

            gridSolicitudes.MasterTemplate.Columns.AddRange(
                sobreConsumoIDColumn, docenasColumn, traceIDColumn, sacaColumn, sacaSegColumn,
                maquinaColumn, celulaColumn, carnetColumn, nombreColumn, horaColumn, fechaColumn,
                estadoColumn, accionColumn
            );

            gridSolicitudes.MasterTemplate.EnableFiltering = true;
            gridSolicitudes.MasterTemplate.ShowHeaderCellButtons = true;
            gridSolicitudes.MasterTemplate.ShowFilteringRow = false;

            gridSolicitudes.MasterTemplate.Columns["Estado"].HeaderText = "ESTADO";
            gridSolicitudes.MasterTemplate.Columns["Accion"].HeaderText = "ACCIÓN";

            // Configurar el estilo del botón de acción en el grid
            ConfigurarEstiloBotonGrid();

            gridSolicitudes.CommandCellClick += GridSolicitudes_CommandCellClick;
            gridSolicitudes.CellFormatting += GridSolicitudes_CellFormatting;
        }

        private void ConfigurarEstiloBotonGrid()
        {
            // Configurar el estilo de los botones en la columna de acción
            gridSolicitudes.CellFormatting += (sender, e) =>
            {
                if (e.CellElement is GridCommandCellElement commandCell)
                {
                    // Aplicar estilo al botón de la columna Acción
                    if (commandCell.CommandButton != null)
                    {
                        // Color azul profesional elegante
                        commandCell.CommandButton.BackColor = Color.FromArgb(41, 128, 185); // Azul elegante
                        commandCell.CommandButton.ForeColor = Color.White;
                        commandCell.CommandButton.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                        commandCell.CommandButton.TextAlignment = ContentAlignment.MiddleCenter;
                        commandCell.CommandButton.FocusBorderColor = Color.FromArgb(31, 97, 141);
                        commandCell.CommandButton.FocusBorderWidth = 1;

                        // Configurar el elemento de relleno del botón
                        commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(41, 128, 185);
                        commandCell.CommandButton.ButtonFillElement.GradientStyle = GradientStyles.Solid;
                        commandCell.CommandButton.ButtonFillElement.BackColor2 = Color.FromArgb(52, 152, 219);
                        commandCell.CommandButton.ButtonFillElement.BackColor3 = Color.FromArgb(41, 128, 185);
                        commandCell.CommandButton.ButtonFillElement.BackColor4 = Color.FromArgb(31, 97, 141);

                        // Efectos hover mejorados
                        commandCell.CommandButton.MouseEnter += (s, args) =>
                        {
                            commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(52, 152, 219);
                            commandCell.CommandButton.ButtonFillElement.BackColor2 = Color.FromArgb(41, 128, 185);
                            commandCell.CommandButton.FocusBorderColor = Color.FromArgb(22, 160, 133);
                        };
                        commandCell.CommandButton.MouseLeave += (s, args) =>
                        {
                            commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(41, 128, 185);
                            commandCell.CommandButton.ButtonFillElement.BackColor2 = Color.FromArgb(52, 152, 219);
                            commandCell.CommandButton.FocusBorderColor = Color.FromArgb(31, 97, 141);
                        };

                        // Efecto cuando está presionado
                        commandCell.CommandButton.MouseDown += (s, args) =>
                        {
                            commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(31, 97, 141);
                        };
                        commandCell.CommandButton.MouseUp += (s, args) =>
                        {
                            commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(52, 152, 219);
                        };
                    }
                }
            };
        }

        private void GridSolicitudes_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "Estado")
            {
                string estado = e.CellElement.Value?.ToString() ?? "";
                int statusID = ObtenerStatusIDDeFila(e.Row);

                switch (statusID)
                {
                    case 1: // Impresión - Azul
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.FromArgb(220, 235, 255);
                        e.CellElement.ForeColor = Color.FromArgb(0, 78, 156);
                        e.CellElement.GradientStyle = GradientStyles.Solid;
                        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                        e.CellElement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case 2: // Preparación - Amarillo
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.FromArgb(255, 235, 205);
                        e.CellElement.ForeColor = Color.FromArgb(160, 100, 0);
                        e.CellElement.GradientStyle = GradientStyles.Solid;
                        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                        e.CellElement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case 3: // Mesa - Verde
                        e.CellElement.DrawFill = true;
                        e.CellElement.BackColor = Color.FromArgb(230, 245, 230);
                        e.CellElement.ForeColor = Color.FromArgb(0, 102, 51);
                        e.CellElement.GradientStyle = GradientStyles.Solid;
                        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                        e.CellElement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                }

                e.CellElement.BorderColor = Color.FromArgb(240, 240, 240);
                e.CellElement.BorderWidth = 1;
                e.CellElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;
            }

            if (e.CellElement.ColumnInfo.Name == "Accion")
            {
                int statusID = ObtenerStatusIDDeFila(e.Row);

                if (statusID == 3)
                {
                    e.CellElement.Enabled = true;
                    e.CellElement.Visibility = ElementVisibility.Visible;

                    // Aplicar estilo al botón cuando está visible
                    if (e.CellElement is GridCommandCellElement commandCell && commandCell.CommandButton != null)
                    {
                        commandCell.CommandButton.BackColor = Color.FromArgb(33, 150, 243);
                        commandCell.CommandButton.ForeColor = Color.White;
                        commandCell.CommandButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                        commandCell.CommandButton.ButtonFillElement.BackColor = Color.FromArgb(33, 150, 243);
                        commandCell.CommandButton.ButtonFillElement.GradientStyle = GradientStyles.Solid;
                    }
                }
                else
                {
                    e.CellElement.Enabled = false;
                    e.CellElement.Visibility = ElementVisibility.Hidden;
                }
            }
        }

        private void CargarSolicitudes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                    SELECT 
                        T.TraceID AS SobreConsumoID,
                        FORMAT(T.Dozens, '#.##') AS Dozens,
                        CONCAT(T.TraceIDBase, '-', T.SobreconsumoNumber) AS TraceID,
                        T.SACA,
                        T.SACASeg,
                        T.MachineCode AS CodigoMaquina,
                        T.Celula,
                        T.Badge AS Carnet,
                        LEFT(E.Emp_Nombres, CHARINDEX(' ', E.Emp_Nombres + ' ') - 1) + ' ' + 
                        LEFT(E.Emp_Apellidos, CHARINDEX(' ', E.Emp_Apellidos + ' ') - 1) AS Nombre,
                        FORMAT(T.CreatedDate, 'hh:mm tt', 'en-US') AS Hora,
                        FORMAT(T.CreatedDate, 'dd MMM yyyy', 'en-US') AS Fecha,
                        S.statusName AS Estado,
                        T.StatusID
                    FROM ES_SOCKS.dbo.pmc_Transactions T
                    INNER JOIN ES_SOCKS.dbo.pmc_Status S ON T.StatusID = S.StatusID
                    LEFT JOIN es_socks.dbo.mst_Empleados E ON T.Badge = E.Emp_ID
                    WHERE T.IsSobreconsumo = 1
                      AND T.StatusID IN (1, 2, 3)
                    ORDER BY 
                        CASE WHEN T.StatusID = 3 THEN 0 ELSE 1 END,
                        T.CreatedDate DESC,
                        T.TraceIDBase,
                        T.SobreconsumoNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gridSolicitudes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Error al cargar solicitudes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private int ObtenerStatusIDDeFila(GridViewRowInfo row)
        {
            try
            {
                if (row.DataBoundItem != null)
                {
                    if (row.DataBoundItem is DataRowView dataRowView)
                    {
                        return Convert.ToInt32(dataRowView["StatusID"]);
                    }
                    else if (row.DataBoundItem is DataRow dataRow)
                    {
                        return Convert.ToInt32(dataRow["StatusID"]);
                    }
                }

                var statusIDCell = row.Cells["StatusID"];
                if (statusIDCell != null && statusIDCell.Value != null)
                {
                    return Convert.ToInt32(statusIDCell.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener StatusID: {ex.Message}");
            }
            return 0;
        }

        private void GridSolicitudes_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Accion" && e.Row != null)
            {
                int statusID = ObtenerStatusIDDeFila(e.Row);

                if (statusID != 3)
                {
                    RadMessageBox.Show("Solo se pueden cerrar solicitudes en 'Mesa'", "Acción no permitida",
                        MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                int sobreConsumoID = Convert.ToInt32(e.Row.Cells["SobreConsumoID"].Value);
                string traceID = e.Row.Cells["TraceID"].Value?.ToString() ?? "N/A";

                DialogResult result = RadMessageBox.Show(
                    $"¿Está seguro que desea cerrar la solicitud {traceID}?",
                    "Confirmar Cierre",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    CerrarSolicitud(sobreConsumoID, traceID);
                }
            }
        }

        private void CerrarSolicitud(int sobreConsumoID, string traceID)
        {
            try
            {
                string badge = Environment.UserName;

                using (SqlConnection connectionES_SOCKS = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    connectionES_SOCKS.Open();
                    using (SqlCommand command = new SqlCommand("sp_ChangeTransactionStatus", connectionES_SOCKS))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TraceID", sobreConsumoID);
                        command.Parameters.AddWithValue("@NewStatusID", 5);
                        command.Parameters.AddWithValue("@Badge", badge);

                        command.ExecuteNonQuery();
                    }
                }

                using (SqlConnection connectionTracer = new SqlConnection(connectionString))
                {
                    connectionTracer.Open();
                    string updateQuery = @"
                        UPDATE pmc_AsignacionTraceIDs 
                        SET Status = 'Completado', 
                            EndDate = GETDATE() 
                        WHERE TraceId = @SobreconsumoID";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connectionTracer))
                    {
                        updateCommand.Parameters.AddWithValue("@SobreconsumoID", sobreConsumoID);
                        updateCommand.ExecuteNonQuery();
                    }
                }

                CargarSolicitudes();
                CargarUltimoSobreconsumo(); // Actualizar el último sobreconsumo después de cerrar

                RadMessageBox.Show($"Solicitud {traceID} cerrada exitosamente", "Éxito",
                    MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Error al cerrar solicitud: {ex.Message}", "Error",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarSolicitudes();
            CargarUltimoSobreconsumo();
        }

        private void SobreconsumosForm_Load(object sender, EventArgs e)
        {
            ConfigurarAutocompletado();
        }

        private void ConfigurarAutocompletado()
        {
            cmbMaquinas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMaquinas.AutoCompleteDataSource = AutoCompleteSource.ListItems;
            cmbCelulas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCelulas.AutoCompleteDataSource = AutoCompleteSource.ListItems;
        }

        private bool ValidarTraceIDEnBaseDatos(long traceID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    string query = @"
                SELECT COUNT(*) 
                FROM ES_SOCKS.dbo.pmc_Transactions 
                WHERE TraceID = @TraceIDBase 
                AND IsSobreconsumo = 0";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TraceIDBase", traceID);
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al validar TraceID: {ex.Message}");
                return false;
            }
        }

        private bool ValidarCarnetEnBaseDatos(string badge)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    string query = @"
                SELECT COUNT(*) 
                FROM es_socks.dbo.mst_Empleados 
                WHERE Emp_ID = @Badge";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Badge", badge);
                        connection.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al validar carnet: {ex.Message}");
                return false;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (timerRefresco != null)
            {
                timerRefresco.Stop();
                timerRefresco.Dispose();
            }
            base.OnFormClosed(e);
        }
    }
}