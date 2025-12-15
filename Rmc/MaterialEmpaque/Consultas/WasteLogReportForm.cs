using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    public partial class WasteLogReportForm : RadForm
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;
        private bool cargandoDatos = false;
        private const int TOP_INICIAL = 300;
        private bool filtrosFechaAplicados = false;
        private int totalRegistros = 0;

        public WasteLogReportForm()
        {
            InitializeComponent();
            ConfigurarGrid();
            ConfigurarEstilos();
            ConfigurarFiltrosHora();
        }

        private void ConfigurarFiltrosHora()
        {
            // Configurar DateTimePickers para horas
            dtpHoraDesde.Format = DateTimePickerFormat.Time;
            dtpHoraDesde.ShowUpDown = true;
            dtpHoraDesde.Value = DateTime.Today;

            dtpHoraHasta.Format = DateTimePickerFormat.Time;
            dtpHoraHasta.ShowUpDown = true;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);
        }

        private void WasteLogReportForm_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;

            CargarUltimosRegistros();
        }

        private void ConfigurarEstilos()
        {
            this.ThemeName = "Fluent";
            gridWasteLog.ThemeName = "Fluent";
            gridWasteLog.TableElement.RowHeight = 30;
        }

        private void ConfigurarGrid()
        {
            gridWasteLog.AutoGenerateColumns = false;
            gridWasteLog.AllowAddNewRow = false;
            gridWasteLog.AllowColumnReorder = true;
            gridWasteLog.ShowGroupPanel = true;
            gridWasteLog.EnableFiltering = true;
            gridWasteLog.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridWasteLog.TableElement.AlternatingRowColor = System.Drawing.Color.FromArgb(250, 250, 250);
        }

        private void CargarUltimosRegistros()
        {
            MostrarProgreso("Cargando últimos registros...");

            string query = @"
                SELECT TOP {0}
                    wl.TraceId AS Id,
                    wl.Saca,
                    wl.MillStyle,
                    wl.Size,
                    wl.Color,
                    wl.Reason,
                    wl.Area,
                    wl.Item,
                    sb.Description,
                    sb.TypeMaterial,
                    wl.Machine,
                    wl.Cell,
                    wl.TableNumber,
                    CAST(wl.Quantity AS INT) AS Quantity,
                    wl.Operador AS Carnet,
                    CONCAT(
                        LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1), ' ',
                        LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1)
                    ) AS Responsable,
                    FORMAT(wl.LogDate, 'dd MMM yyyy hh:mm tt', 'en-us') AS FechaHora
                FROM pmc_WasteLog wl
                LEFT JOIN mst_Empleados emp 
                    ON wl.Operador = emp.Emp_ID
                LEFT JOIN (
                    SELECT 
                        sub_producto,
                        sub_descripcion AS Description,
                        sub_TypeMaterials AS TypeMaterial,
                        ROW_NUMBER() OVER(PARTITION BY sub_producto ORDER BY sub_producto) AS rn
                    FROM pmc_Subida_BOM
                ) sb
                    ON wl.Item = sb.sub_producto AND sb.rn = 1
                ORDER BY wl.LogDate DESC";

            CargarDatos(string.Format(query, TOP_INICIAL), false);
            filtrosFechaAplicados = false;
        }

        private void CargarRegistrosConFiltros()
        {
            MostrarProgreso("Aplicando filtros a registros...");

            DateTime fechaDesde = dtpDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
            DateTime fechaHasta = dtpHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

            string query = @"
                SELECT
                    wl.TraceId AS Id,
                    wl.Saca,
                    wl.MillStyle,
                    wl.Size,
                    wl.Color,
                    wl.Reason,
                    wl.Area,
                    wl.Item,
                    sb.Description,
                    sb.TypeMaterial,
                    wl.Machine,
                    wl.Cell,
                    wl.TableNumber,
                    CAST(wl.Quantity AS INT) AS Quantity,
                    wl.Operador AS Carnet,
                    CONCAT(
                        LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1), ' ',
                        LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1)
                    ) AS Responsable,
                    FORMAT(wl.LogDate, 'dd MMM yyyy hh:mm tt', 'en-us') AS FechaHora
                FROM pmc_WasteLog wl
                LEFT JOIN mst_Empleados emp 
                    ON wl.Operador = emp.Emp_ID
                LEFT JOIN (
                    SELECT 
                        sub_producto,
                        sub_descripcion AS Description,
                        sub_TypeMaterials AS TypeMaterial,
                        ROW_NUMBER() OVER(PARTITION BY sub_producto ORDER BY sub_producto) AS rn
                    FROM pmc_Subida_BOM
                ) sb
                    ON wl.Item = sb.sub_producto AND sb.rn = 1
                WHERE wl.LogDate BETWEEN @desde AND @hasta
                ORDER BY wl.LogDate DESC";

            CargarDatos(query, true, fechaDesde, fechaHasta);
            filtrosFechaAplicados = true;
        }

        private void CargarDatos(string query, bool aplicarFiltrosFecha,
                               DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                cargandoDatos = true;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (aplicarFiltrosFecha && fechaDesde.HasValue && fechaHasta.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@desde", fechaDesde.Value);
                            cmd.Parameters.AddWithValue("@hasta", fechaHasta.Value);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gridWasteLog.DataSource = dt;
                        totalRegistros = dt.Rows.Count;

                        ConfigurarColumnasGrid();

                        string estado = aplicarFiltrosFecha ? "filtrados" : "últimos";
                        MostrarInfoResultados(dt.Rows.Count, estado);
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al cargar datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                cargandoDatos = false;
                OcultarProgreso();
            }
        }

        private void ConfigurarColumnasGrid()
        {
            gridWasteLog.Columns.Clear();

            AgregarColumna("Id", "ID", 70);
            AgregarColumna("Saca", "SACA", 80);
            AgregarColumna("MillStyle", "MILL STYLE", 100);
            AgregarColumna("Size", "TALLA", 80);
            AgregarColumna("Color", "COLOR", 100);
            AgregarColumna("Reason", "RAZÓN", 150);
            AgregarColumna("Area", "ÁREA", 100);
            AgregarColumna("Item", "ITEM", 100);
            AgregarColumna("Description", "DESCRIPCIÓN", 200);
            AgregarColumna("TypeMaterial", "TIPO MATERIAL", 120);
            AgregarColumna("Machine", "MÁQUINA", 100);
            AgregarColumna("Cell", "CELULA", 80);
            AgregarColumna("TableNumber", "MESA", 80);
            AgregarColumnaEntera("Quantity", "CANTIDAD", 80);
            AgregarColumna("Carnet", "CARNET", 80);
            AgregarColumna("Responsable", "RESPONSABLE", 150);
            AgregarColumna("FechaHora", "FECHA/HORA", 150);

            gridWasteLog.BestFitColumns();
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

            gridWasteLog.Columns.Add(columna);
        }

        private void AgregarColumna(string fieldName, string headerText, int width)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            if (fieldName == "Id" || fieldName == "Quantity")
            {
                columna.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            }

            gridWasteLog.Columns.Add(columna);
        }

        private void MostrarInfoResultados(int cantidad, string estado)
        {
            string prefijo = estado == "últimos" ? "últimos" : "registros";

            lblEstado.Text = $"{cantidad:N0} {prefijo} {estado}";
            lblEstado.Visible = true;

            lblValorTotalRegistros.Text = cantidad.ToString("N0");
        }

        private void MostrarProgreso(string mensaje)
        {
            progressCarga.Visible = true;
            progressCarga.Value1 = 0;
            lblEstado.Text = mensaje;
            lblEstado.Visible = true;

            // Simular progreso
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += (s, e) =>
            {
                if (progressCarga.Value1 < 80)
                    progressCarga.Value1 += 5;
                else
                    timer.Stop();
            };
            timer.Start();
        }

        private void OcultarProgreso()
        {
            progressCarga.Value1 = 100;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 300;
            timer.Tick += (s, e) =>
            {
                progressCarga.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                RadMessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'",
                    "Error en fechas", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            if (dtpDesde.Value.Date == dtpHasta.Value.Date &&
                dtpHoraDesde.Value.TimeOfDay > dtpHoraHasta.Value.TimeOfDay)
            {
                RadMessageBox.Show("La hora 'Desde' no puede ser mayor que la hora 'Hasta' para el mismo día",
                    "Error en horas", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            CargarRegistrosConFiltros();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;

            // Resetear horas
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);

            gridWasteLog.FilterDescriptors.Clear();
            gridWasteLog.GroupDescriptors.Clear();

            CargarUltimosRegistros();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.FileName = $"Reporte_Desperdicio_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    GridViewSpreadExport exporter = new GridViewSpreadExport(this.gridWasteLog);
                    SpreadExportRenderer exportRenderer = new SpreadExportRenderer();

                    exporter.RunExport(saveDialog.FileName, exportRenderer);

                    RadMessageBox.Show("Archivo exportado exitosamente!",
                        "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al exportar a Excel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnUltimosRegistros_Click(object sender, EventArgs e)
        {
            CargarUltimosRegistros();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            if (gridWasteLog.Columns.Count > 0)
            {
                gridWasteLog.BestFitColumns();
            }
        }
    }
}