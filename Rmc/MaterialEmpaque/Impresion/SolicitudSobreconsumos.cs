using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Impresion
{
    public partial class SolicitudSobreconsumos : RadForm
    {
        private string connectionString = Properties.Settings.Default.TracerConnectionString;

        public SolicitudSobreconsumos()
        {
            InitializeComponent();
            this.Shown += (s, e) => CargarSolicitudes();
        }

        private void SolicitudSobreconsumos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            timerAutoRefresh.Start();
        }

        private void ConfigurarGrid()
        {
            gridSolicitudes.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridSolicitudes.MasterTemplate.EnableAlternatingRowColor = true;
            gridSolicitudes.MasterTemplate.EnableFiltering = true;
            gridSolicitudes.MasterTemplate.ShowFilteringRow = true;

            // Configurar estilo moderno
            gridSolicitudes.ThemeName = "Fluent";
        }

        private void CargarSolicitudes()
        {
            try
            {
                string query = @"
                    SELECT 
                        T.TraceID AS SobreConsumoID,
                        CAST(T.Dozens AS INT) AS Docenas,
                        CONCAT(T.TraceIDBase, '-', T.SobreconsumoNumber) AS TraceID,
                        T.SACA,
                        T.SACASeg,
                        T.MachineCode AS CodigoMaquina,
                        T.Celula,
                        LEFT(E.Emp_Nombres, CHARINDEX(' ', E.Emp_Nombres + ' ') - 1) + ' ' + 
                        LEFT(E.Emp_Apellidos, CHARINDEX(' ', E.Emp_Apellidos + ' ') - 1) AS Nombre,
                        T.Badge AS Carnet,
                        FORMAT(T.CreatedDate, 'hh:mm tt', 'en-US') AS Hora,
                        FORMAT(T.CreatedDate, 'dd MMM yyyy', 'en-US') AS Fecha,
                        'Pendiente de Impresion' AS Estado
                    FROM ES_SOCKS.dbo.pmc_Transactions T
                    INNER JOIN ES_SOCKS.dbo.pmc_Status S ON T.StatusID = S.StatusID
                    LEFT JOIN ES_SOCKS.dbo.mst_Empleados E ON T.Badge = E.Emp_ID
                    WHERE T.IsSobreconsumo = 1
                      AND T.StatusID = 1
                      AND NOT EXISTS (
                          SELECT 1  
                          FROM dbo.pmc_AsignacionTraceIDs A 
                          WHERE A.TraceId = T.TraceID
                      )
                    ORDER BY 
                        T.CreatedDate DESC,
                        T.TraceIDBase,
                        T.SobreconsumoNumber;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gridSolicitudes.DataSource = dt;
                    ActualizarContador(dt.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Error al cargar solicitudes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void ActualizarContador(int cantidad)
        {
            lblContador.Text = $"{cantidad} solicitud{(cantidad != 1 ? "es" : "")} pendientes";

            if (cantidad == 0)
                lblContador.ForeColor = Color.Gray;
            else if (cantidad <= 5)
                lblContador.ForeColor = Color.Green;
            else if (cantidad <= 10)
                lblContador.ForeColor = Color.Orange;
            else
                lblContador.ForeColor = Color.Red;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarSolicitudes();
            lblEstado.Text = "Última actualización: " + DateTime.Now.ToString("hh:mm tt");
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            CargarSolicitudes();
            lblEstado.Text = "Última actualización: " + DateTime.Now.ToString("hh:mm tt");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerAutoRefresh.Stop();
            base.OnFormClosing(e);
        }
    }
}