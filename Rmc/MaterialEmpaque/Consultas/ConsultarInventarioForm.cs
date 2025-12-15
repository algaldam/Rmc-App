using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    public partial class ConsultarInventarioForm : Telerik.WinControls.UI.RadForm
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;
        private bool cargandoDatos = false;
        private int estadoSeleccionado = 0;

        public ConsultarInventarioForm()
        {
            InitializeComponent();
            ConfigurarEstilos();
            ConfigurarFiltrosHora();
            ConfigurarBotonesEstados();
        }

        private void ConfigurarEstilos()
        {
            this.ThemeName = "Fluent";
            gridResultados.ThemeName = "Fluent";
            gridResultados.TableElement.RowHeight = 30;

            gridResultados.AutoGenerateColumns = false;
            gridResultados.AllowAddNewRow = false;
            gridResultados.EnableFiltering = true;
            gridResultados.ShowGroupPanel = true;
        }

        private void ConfigurarFiltrosHora()
        {
            dtpHoraDesde.Format = DateTimePickerFormat.Time;
            dtpHoraDesde.ShowUpDown = true;
            dtpHoraDesde.Value = DateTime.Today;

            dtpHoraHasta.Format = DateTimePickerFormat.Time;
            dtpHoraHasta.ShowUpDown = true;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);
        }

        private void ConfigurarBotonesEstados()
        {
            btnMesa.Click += (s, e) => SeleccionarEstado(3, btnMesa);
            btnEstante.Click += (s, e) => SeleccionarEstado(4, btnEstante);
            btnFinishing.Click += (s, e) => SeleccionarEstado(5, btnFinishing);
        }

        private void SeleccionarEstado(int estado, RadButton boton)
        {
            ResetearBotones();

            boton.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            boton.ForeColor = System.Drawing.Color.White;
            boton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            estadoSeleccionado = estado;

            btnConsultar.Enabled = true;
        }

        private void ResetearBotones()
        {
            Color colorNormal = System.Drawing.Color.FromArgb(200, 200, 200);
            Color textoNormal = System.Drawing.Color.FromArgb(100, 100, 100);

            btnMesa.BackColor = colorNormal;
            btnEstante.BackColor = colorNormal;
            btnFinishing.BackColor = colorNormal;

            btnMesa.ForeColor = textoNormal;
            btnEstante.ForeColor = textoNormal;
            btnFinishing.ForeColor = textoNormal;

            btnMesa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            btnEstante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            btnFinishing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (estadoSeleccionado == 0)
            {
                RadMessageBox.Show("Por favor seleccione un estado primero.", "Estado Requerido",
                    MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                RadMessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'",
                    "Error en fechas", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            if (dtpFechaDesde.Value.Date == dtpFechaHasta.Value.Date &&
                dtpHoraDesde.Value.TimeOfDay > dtpHoraHasta.Value.TimeOfDay)
            {
                RadMessageBox.Show("La hora 'Desde' no puede ser mayor que la hora 'Hasta' para el mismo día",
                    "Error en horas", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            ConsultarInventario();
        }

        private void ConsultarInventario()
        {
            MostrarProgreso("Consultando inventario...");

            DateTime fechaDesde = dtpFechaDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
            DateTime fechaHasta = dtpFechaHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

            string query = @"
                WITH CantidadesPorItem AS (
                    SELECT 
                        t.TraceID,
                        td.Code AS ItemCode,
                        SUM(td.QuantityBOM) AS TotalQuantityBOM,
                        SUM(td.QuantityREAL) AS TotalQuantityREAL
                    FROM ES_SOCKS.dbo.pmc_Transactions t
                    INNER JOIN ES_SOCKS.dbo.pmc_TransactionDetails td ON t.ID = td.TransactionID
                    GROUP BY t.TraceID, td.Code
                )
                SELECT 
                    ci.ItemCode,
                    MAX(SB.sub_descripcion) AS ItemDescription,
                    MAX(SB.sub_TypeMaterials) AS TypeMaterials,
                    s.statusName AS Estado,
                    CAST(SUM(ci.TotalQuantityREAL) AS INT) AS Quantity,
                    COUNT(DISTINCT t.TraceID) AS TotalTransactions,
                    FORMAT(MIN(st.StartDate), 'dd-MMM-yyyy - hh:mm tt') AS FirstDateTime,
                    FORMAT(MAX(st.StartDate), 'dd-MMM-yyyy - hh:mm tt') AS LastDateTime
                FROM ES_SOCKS.dbo.pmc_Transactions t
                INNER JOIN ES_SOCKS.dbo.pmc_StatusTracking st ON t.ID = st.TransactionID
                INNER JOIN ES_SOCKS.dbo.pmc_Status s ON st.StatusID = s.statusId
                INNER JOIN CantidadesPorItem ci ON t.TraceID = ci.TraceID
                INNER JOIN (
                    SELECT 
                        sub_producto, 
                        sub_descripcion,
                        sub_TypeMaterials,
                        ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                    FROM dbo.pmc_Subida_BOM
                ) SB ON ci.ItemCode = SB.sub_producto AND SB.rn = 1
                WHERE s.statusId = @estadoId
                    AND st.StartDate BETWEEN @fechaDesde AND @fechaHasta
                    AND ci.TotalQuantityREAL IS NOT NULL
                GROUP BY ci.ItemCode, s.statusName, s.statusOrder
                HAVING SUM(ci.TotalQuantityREAL) > 0
                ORDER BY MAX(st.StartDate), ci.ItemCode";

            try
            {
                cargandoDatos = true;

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@estadoId", estadoSeleccionado);
                    cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridResultados.DataSource = dt;
                    ConfigurarColumnasGrid();

                    MostrarResultados(dt.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al consultar inventario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                cargandoDatos = false;
                OcultarProgreso();
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (gridResultados.Columns.Count == 0)
            {
                AgregarColumna("ItemCode", "CÓDIGO", 120);
                AgregarColumna("ItemDescription", "DESCRIPCIÓN", 350);
                AgregarColumna("TypeMaterials", "TIPO DE MATERIAL", 160);
                AgregarColumna("Estado", "ESTADO", 140);
                AgregarColumnaEntera("Quantity", "CANTIDAD", 80);
                AgregarColumnaEntera("TotalTransactions", "#TRACEIDs", 100);
                AgregarColumna("FirstDateTime", "PRIMERA TRANSACCIÓN", 180);
                AgregarColumna("LastDateTime", "ÚLTIMA TRANSACCIÓN", 180);
            }

        }

        private void AgregarColumnaEntera(string fieldName, string headerText, int width)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            columna.FormatString = "{0:N0}";

            columna.AllowResize = true;

            gridResultados.Columns.Add(columna);
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

            gridResultados.Columns.Add(columna);
        }

        private void MostrarResultados(int cantidad)
        {
            lblResultados.Text = $"{cantidad:N0} productos encontrados";
            lblResultados.Visible = true;
            lblUltimaActualizacion.Text = $"Última consulta: {DateTime.Now:HH:mm:ss}";
        }

        private void MostrarProgreso(string mensaje)
        {
            progressBar.Visible = true;
            progressBar.Value1 = 0;
            lblEstado.Text = mensaje;
            lblEstado.Visible = true;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += (s, e) =>
            {
                if (progressBar.Value1 < 80)
                    progressBar.Value1 += 5;
                else
                    timer.Stop();
            };
            timer.Start();
        }

        private void OcultarProgreso()
        {
            progressBar.Value1 = 100;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 300;
            timer.Tick += (s, e) =>
            {
                progressBar.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            // Resetear fechas
            dtpFechaDesde.Value = DateTime.Now.AddDays(-7);
            dtpFechaHasta.Value = DateTime.Now;
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);

            estadoSeleccionado = 0;
            ResetearBotones();
            btnConsultar.Enabled = false;

            gridResultados.DataSource = null;

            lblResultados.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string nombreEstado = "";
            switch (estadoSeleccionado)
            {
                case 3: nombreEstado = "MESA"; break;
                case 4: nombreEstado = "ESTANTE"; break;
                case 5: nombreEstado = "FINISHING"; break;
            }

            ExportHelper.ExportToExcel(gridResultados, $"Inventario_{nombreEstado}");
        }

        private void ConsultarInventarioForm_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Now.AddDays(-7);
            dtpFechaHasta.Value = DateTime.Now;

            btnConsultar.Enabled = false;

            ConfigurarColumnasGrid();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
        }
    }
}