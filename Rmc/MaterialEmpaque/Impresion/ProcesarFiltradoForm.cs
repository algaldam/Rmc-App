using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls;

namespace Rmc.MaterialEmpaque.Impresion
{
    public partial class ProcesarFiltradoForm : Telerik.WinControls.UI.RadForm
    {
        public string Saca { get; private set; }
        public int Docenas { get; private set; }
        public string Carnet { get; private set; }
        public bool DatosValidos { get; private set; }

        private ToolTip toolTip;
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString; // Ajusta con tu connection string

        public ProcesarFiltradoForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += ProcesarFiltradoForm_KeyDown;
            this.DatosValidos = false;

            // Inicializar el ToolTip
            toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Warning;
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;

            // Suscribir eventos para limpiar el tooltip cuando el usuario empiece a escribir
            txtSaca.TextChanged += (s, e) => LimpiarToolTip(txtSaca);
            txtDocenas.TextChanged += (s, e) => LimpiarToolTip(txtDocenas);
            txtCarnet.TextChanged += (s, e) => LimpiarToolTip(txtCarnet);
        }

        private void ProcesarFiltradoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter && txtCarnet.Focused)
            {
                ProcesarDatos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DatosValidos = false;
            this.Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            ProcesarDatos();
        }

        private void ProcesarDatos()
        {
            if (ValidarDatos())
            {
                // Guardar los datos en las propiedades
                this.Saca = txtSaca.Text.Trim().ToUpper();
                this.Docenas = int.Parse(txtDocenas.Text.Trim());
                this.Carnet = txtCarnet.Text.Trim();
                this.DatosValidos = true;

                // CERRAR el formulario
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            bool esValido = true;

            // Limpiar todos los tooltips primero
            LimpiarTodosLosToolTips();

            // Validar SACA
            if (string.IsNullOrWhiteSpace(txtSaca.Text))
            {
                MostrarError("El campo SA/CA es obligatorio", txtSaca);
                esValido = false;
            }

            // Validar Docenas
            if (string.IsNullOrWhiteSpace(txtDocenas.Text))
            {
                MostrarError("Las docenas son obligatorias", txtDocenas);
                esValido = false;
            }
            else if (!int.TryParse(txtDocenas.Text, out int docenas) || docenas <= 0)
            {
                MostrarError("Las docenas deben ser un número mayor a 0", txtDocenas);
                esValido = false;
            }

            // Validar Carnet
            if (string.IsNullOrWhiteSpace(txtCarnet.Text))
            {
                MostrarError("El campo Carnet es obligatorio", txtCarnet);
                esValido = false;
            }
            else if (!ValidarCarnetEnBaseDeDatos(txtCarnet.Text.Trim()))
            {
                MostrarError("El carnet no existe o no es válido", txtCarnet);
                esValido = false;
            }

            return esValido;
        }

        private bool ValidarCarnetEnBaseDeDatos(string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM ES_SOCKS.dbo.mst_Empleados WHERE Emp_ID = @Carnet";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Carnet", carnet);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al validar carnet: {ex.Message}", txtCarnet);
                return false;
            }
        }

        private void MostrarError(string mensaje, Control control)
        {
            toolTip.Show(mensaje, control, 0, -20, 3000);

            control.Focus();

            if (control is Telerik.WinControls.UI.RadTextBox radTextBox)
            {
                radTextBox.TextBoxElement.Border.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LimpiarToolTip(Control control)
        {
            // Ocultar el tooltip
            toolTip.Hide(control);
        }

        private void LimpiarTodosLosToolTips()
        {
            toolTip.Hide(txtSaca);
            toolTip.Hide(txtDocenas);
            toolTip.Hide(txtCarnet);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            toolTip?.Dispose();
        }
    }
}