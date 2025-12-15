using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    public partial class ReporteInventarioForm : RadForm
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;
        private bool cargandoDatos = false;
        private bool vistaActualEsSalidas = true;
        private int totalSalidas = 0;
        private int totalEntradas = 0;
        private int totalTransferencias = 0;

        // Nuevas constantes para optimización
        private const int TOP_INICIAL = 300;
        private bool filtrosFechaAplicados = false;

        public ReporteInventarioForm()
        {
            InitializeComponent();
            ConfigurarGrid();
            ConfigurarEstilos();
            ConfigurarFiltrosMovimientos();
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

        private void ReporteInventarioForm_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;

            CargarSalidasPorDefecto();
            ActualizarKPIs();
        }

        private void ConfigurarEstilos()
        {
            this.ThemeName = "Fluent";
            gridMovimientos.ThemeName = "Fluent";
            gridMovimientos.TableElement.RowHeight = 30;
        }

        private void ConfigurarFiltrosMovimientos()
        {
            cbFiltroMovimiento.Items.AddRange(new string[] { "TODOS", "SALIDAS", "ENTRADAS" });
            cbFiltroMovimiento.SelectedIndex = 0; // TODOS por defecto
            cbFiltroMovimiento.SelectedIndexChanged += CbFiltroMovimiento_SelectedIndexChanged;
        }

        private void CbFiltroMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos && vistaActualEsSalidas)
            {
                if (filtrosFechaAplicados)
                {
                    AplicarFiltrosMovimientos();
                }
                else
                {
                    CargarUltimosMovimientosConFiltro();
                }
            }
        }

        private void CargarUltimosMovimientosConFiltro()
        {
            MostrarProgreso("Cargando últimos movimientos...");

            string tipoMovimiento = null;
            if (cbFiltroMovimiento.SelectedIndex == 1)
                tipoMovimiento = "OUT";
            else if (cbFiltroMovimiento.SelectedIndex == 2)
                tipoMovimiento = "IN";

            string query = @"
                    SELECT DISTINCT TOP {0}
                        mov.MovementID,
                        mov.Code AS ItemCode,
                        sb.sub_descripcion,
                        CASE 
                            WHEN mov.MovementType = 'OUT' THEN 'Salida'
                            WHEN mov.MovementType = 'IN' THEN 'Entrada'
                            WHEN mov.MovementType = 'OUT_SOBRANTES' THEN 'Salida/Sobrantes'
                            ELSE 'Otro Movimiento'
                        END AS TipoMovimiento,
                        CASE 
                            WHEN mov.MovementType = 'OUT' THEN mov.Quantity
                            ELSE mov.Quantity
                        END AS Cantidad,
                        mov.Description AS Descripcion,
                        mov.Warehouse AS LocalidadCode,
                        wh.WarehouseName AS LocalidadName,
                        mov.CreatedBy AS Carnet,
                        LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                        LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                        FORMAT(mov.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS Fecha,
                        mov.CreatedDate
                    FROM pmc_InventoryMovements mov
                    LEFT JOIN pmc_InventoryPreparation inv 
                        ON mov.Code = inv.Code AND mov.Warehouse = inv.Location
                    LEFT JOIN pmc_Warehouse wh 
                        ON mov.Warehouse = wh.WarehouseCode
                    LEFT JOIN mst_Empleados emp 
                        ON mov.CreatedBy = emp.Emp_ID
                    LEFT JOIN pmc_Subida_BOM sb
                        ON mov.Code = sb.sub_producto
                    WHERE mov.MovementType IS NOT NULL";

            if (!string.IsNullOrEmpty(tipoMovimiento))
            {
                query += " AND mov.MovementType = @tipoMovimiento";
            }

            query += " ORDER BY mov.CreatedDate DESC";

            CargarDatos(string.Format(query, TOP_INICIAL), "Salidas", false, tipoMovimiento);
            filtrosFechaAplicados = false;
        }

        private void AplicarFiltrosMovimientos()
        {
            if (vistaActualEsSalidas)
            {
                if (cbFiltroMovimiento.SelectedIndex == 0)
                {
                    CargarSalidasConFiltros();
                }
                else if (cbFiltroMovimiento.SelectedIndex == 1)
                {
                    CargarSalidasConFiltros("OUT");
                }
                else if (cbFiltroMovimiento.SelectedIndex == 2)
                {
                    CargarSalidasConFiltros("IN");
                }
            }
        }

        private void CargarSalidasPorDefecto()
        {
            vistaActualEsSalidas = true;
            ActualizarEstadoBotones();
            ActualizarVisibilidadFiltrosMovimientos();
            CargarUltimosMovimientos();
        }

        private void ConfigurarGrid()
        {
            gridMovimientos.AutoGenerateColumns = false;
            gridMovimientos.AllowAddNewRow = false;
            gridMovimientos.AllowColumnReorder = true;
            gridMovimientos.ShowGroupPanel = true;
            gridMovimientos.EnableFiltering = true;
            gridMovimientos.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridMovimientos.TableElement.AlternatingRowColor = System.Drawing.Color.FromArgb(250, 250, 250);
        }

        private void ActualizarEstadoBotones()
        {
            if (vistaActualEsSalidas)
            {
                btnVerSalidas.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
                btnVerTransferencias.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
                btnVerSalidas.ForeColor = System.Drawing.Color.White;
                btnVerTransferencias.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            }
            else
            {
                btnVerSalidas.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
                btnVerTransferencias.BackColor = System.Drawing.Color.FromArgb(125, 60, 152);
                btnVerSalidas.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                btnVerTransferencias.ForeColor = System.Drawing.Color.White;
            }
        }

        private void ActualizarVisibilidadFiltrosMovimientos()
        {
            bool mostrarFiltrosMovimientos = vistaActualEsSalidas;

            lblFiltroMovimiento.Visible = mostrarFiltrosMovimientos;
            cbFiltroMovimiento.Visible = mostrarFiltrosMovimientos;

            if (!mostrarFiltrosMovimientos)
            {
                cbFiltroMovimiento.SelectedIndex = 0;
            }
        }

        private void btnVerSalidas_Click(object sender, EventArgs e)
        {
            vistaActualEsSalidas = true;
            ActualizarEstadoBotones();
            ActualizarVisibilidadFiltrosMovimientos();
            CargarUltimosMovimientos();
        }

        private void btnVerTransferencias_Click(object sender, EventArgs e)
        {
            vistaActualEsSalidas = false;
            ActualizarEstadoBotones();
            ActualizarVisibilidadFiltrosMovimientos();
            CargarTransferenciasSinFiltros();
        }

        private void CargarUltimosMovimientos()
        {
            MostrarProgreso("Cargando últimos movimientos...");

            string query = @"
                SELECT DISTINCT TOP {0}
                    mov.MovementID,
                    mov.Code AS ItemCode,
                    sb.sub_descripcion,
                    CASE 
                        WHEN mov.MovementType = 'OUT' THEN 'Salida'
                        WHEN mov.MovementType = 'IN' THEN 'Entrada'
                        WHEN mov.MovementType = 'OUT_SOBRANTES' THEN 'Salida/Sobrantes'
                        ELSE 'Otro Movimiento'
                    END AS TipoMovimiento,
                    CASE 
                        WHEN mov.MovementType = 'OUT' THEN mov.Quantity
                        ELSE mov.Quantity
                    END AS Cantidad,
                    mov.Description AS Descripcion,
                    mov.Warehouse AS LocalidadCode,
                    wh.WarehouseName AS LocalidadName,
                    mov.CreatedBy AS Carnet,
                    LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                    LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                    FORMAT(mov.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS Fecha,
                    mov.CreatedDate
                FROM pmc_InventoryMovements mov
                LEFT JOIN pmc_InventoryPreparation inv 
                    ON mov.Code = inv.Code AND mov.Warehouse = inv.Location
                LEFT JOIN pmc_Warehouse wh 
                    ON mov.Warehouse = wh.WarehouseCode
                LEFT JOIN mst_Empleados emp 
                    ON mov.CreatedBy = emp.Emp_ID
                LEFT JOIN pmc_Subida_BOM sb
                    ON mov.Code = sb.sub_producto
                WHERE mov.MovementType IS NOT NULL
                ORDER BY mov.CreatedDate DESC";

            CargarDatos(string.Format(query, TOP_INICIAL), "Salidas", false);
            filtrosFechaAplicados = false;
        }

        private void CargarTransferenciasSinFiltros()
        {
            MostrarProgreso("Cargando transferencias...");

            string query = @"
                SELECT DISTINCT
                    trans.TransferID,
                    trans.Code AS ItemCode,
                    sb.sub_descripcion,
                    'Transferencia' AS TipoMovimiento,
                    trans.Quantity AS Cantidad,
                    trans.Origin AS OrigenName,
                    trans.Destination AS DestinoName,
                    trans.Description AS Descripcion,
                    trans.CreatedBy AS Carnet,
                    LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                    LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                    FORMAT(trans.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS FechaFormateada,
                    trans.CreatedDate
                FROM pmc_InventoryTransfers trans
                LEFT JOIN pmc_Warehouse orig_wh 
                    ON trans.Origin = orig_wh.WarehouseCode
                LEFT JOIN pmc_Warehouse dest_wh 
                    ON trans.Destination = dest_wh.WarehouseCode
                LEFT JOIN mst_Empleados emp 
                    ON trans.CreatedBy = emp.Emp_ID
                LEFT JOIN pmc_Subida_BOM sb
                    ON trans.Code = sb.sub_producto
                WHERE trans.Quantity > 0
                ORDER BY trans.CreatedDate DESC";

            CargarDatos(query, "Transferencias", false);
            filtrosFechaAplicados = false;
        }

        private void CargarSalidasConFiltros(string tipoMovimiento = null)
        {
            MostrarProgreso("Aplicando filtros a movimientos...");

            DateTime fechaDesde = dtpDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
            DateTime fechaHasta = dtpHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

            string query = @"
                SELECT DISTINCT
                    mov.MovementID,
                    mov.Code AS ItemCode,
                    sb.sub_descripcion,
                    CASE 
                        WHEN mov.MovementType = 'OUT' THEN 'Salida'
                        WHEN mov.MovementType = 'IN' THEN 'Entrada'
                        WHEN mov.MovementType = 'OUT_SOBRANTES' THEN 'Salida/Sobrantes'
                        ELSE 'Otro Movimiento'
                    END AS TipoMovimiento,
                    CASE 
                        WHEN mov.MovementType = 'OUT' THEN mov.Quantity
                        ELSE mov.Quantity
                    END AS Cantidad,
                    mov.Description AS Descripcion,
                    mov.Warehouse AS LocalidadCode,
                    wh.WarehouseName AS LocalidadName,
                    mov.CreatedBy AS Carnet,
                    LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                    LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                    FORMAT(mov.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS Fecha,
                    mov.CreatedDate
                FROM pmc_InventoryMovements mov
                LEFT JOIN pmc_InventoryPreparation inv 
                    ON mov.Code = inv.Code AND mov.Warehouse = inv.Location
                LEFT JOIN pmc_Warehouse wh 
                    ON mov.Warehouse = wh.WarehouseCode
                LEFT JOIN mst_Empleados emp 
                    ON mov.CreatedBy = emp.Emp_ID
                LEFT JOIN pmc_Subida_BOM sb
                    ON mov.Code = sb.sub_producto
                WHERE mov.MovementType IS NOT NULL
                AND mov.CreatedDate BETWEEN @desde AND @hasta";

            if (!string.IsNullOrEmpty(tipoMovimiento))
            {
                query += " AND mov.MovementType = @tipoMovimiento";
            }

            query += " ORDER BY mov.CreatedDate DESC";

            CargarDatos(query, "Salidas", true, tipoMovimiento, fechaDesde, fechaHasta);
            filtrosFechaAplicados = true;
        }

        private void CargarTransferenciasConFiltros()
        {
            MostrarProgreso("Aplicando filtros a transferencias...");

            DateTime fechaDesde = dtpDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
            DateTime fechaHasta = dtpHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

            string query = @"
                SELECT DISTINCT
                    trans.TransferID,
                    trans.Code AS ItemCode,
                    sb.sub_descripcion,
                    'Transferencia' AS TipoMovimiento,
                    trans.Quantity AS Cantidad,
                    trans.Origin AS OrigenName,
                    trans.Destination AS DestinoName,
                    trans.Description AS Descripcion,
                    trans.CreatedBy AS Carnet,
                    LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                    LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                    FORMAT(trans.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS FechaFormateada,
                    trans.CreatedDate
                FROM pmc_InventoryTransfers trans
                LEFT JOIN pmc_Warehouse orig_wh 
                    ON trans.Origin = orig_wh.WarehouseCode
                LEFT JOIN pmc_Warehouse dest_wh 
                    ON trans.Destination = dest_wh.WarehouseCode
                LEFT JOIN mst_Empleados emp 
                    ON trans.CreatedBy = emp.Emp_ID
                LEFT JOIN pmc_Subida_BOM sb
                    ON trans.Code = sb.sub_producto
                WHERE trans.Quantity > 0
                AND trans.CreatedDate BETWEEN @desde AND @hasta
                ORDER BY trans.CreatedDate DESC";

            CargarDatos(query, "Transferencias", true, null, fechaDesde, fechaHasta);
            filtrosFechaAplicados = true;
        }

        private void CargarDatos(string query, string tipoVista, bool aplicarFiltrosFecha,
                               string tipoMovimiento = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
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

                        if (!string.IsNullOrEmpty(tipoMovimiento))
                        {
                            cmd.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gridMovimientos.DataSource = dt;

                        ConfigurarColumnasGrid(tipoVista);

                        ActualizarKPIs();

                        string estado = aplicarFiltrosFecha ? "filtrados" : "últimos";
                        MostrarInfoResultados(dt.Rows.Count, estado);
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                cargandoDatos = false;
                OcultarProgreso();
            }
        }

        private void ConfigurarColumnasGrid(string tipoVista)
        {
            gridMovimientos.Columns.Clear();

            if (tipoVista == "Salidas")
            {
                AgregarColumna("MovementID", "ID", 70);
                AgregarColumna("ItemCode", "CÓDIGO", 100);
                AgregarColumna("sub_descripcion", "DESCRIPCIÓN", 200);
                AgregarColumna("TipoMovimiento", "TIPO", 100);
                AgregarColumnaEntera("Cantidad", "CANTIDAD", 80);
                AgregarColumna("Descripcion", "DESCRIPCIÓN MOV.", 180);
                AgregarColumna("LocalidadName", "LOCALIDAD", 120);
                AgregarColumna("Carnet", "CARNET", 80);
                AgregarColumna("Nombre", "RESPONSABLE", 150);
                AgregarColumna("Fecha", "FECHA/HORA", 150);
            }
            else // Transferencias
            {
                AgregarColumna("TransferID", "ID", 70);
                AgregarColumna("ItemCode", "CÓDIGO", 100);
                AgregarColumna("sub_descripcion", "DESCRIPCIÓN", 200);
                AgregarColumna("TipoMovimiento", "TIPO", 100);
                AgregarColumnaEntera("Cantidad", "CANTIDAD", 80);
                AgregarColumna("OrigenName", "ORIGEN", 120);
                AgregarColumna("DestinoName", "DESTINO", 120);
                AgregarColumna("Descripcion", "DESCRIPCIÓN", 180);
                AgregarColumna("Carnet", "CARNET", 80);
                AgregarColumna("Nombre", "RESPONSABLE", 150);
                AgregarColumna("FechaFormateada", "FECHA/HORA", 150);
            }

            gridMovimientos.BestFitColumns();
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
            columna.FormatInfo = System.Globalization.CultureInfo.CurrentCulture;

            gridMovimientos.Columns.Add(columna);
        }

        private void AgregarColumna(string fieldName, string headerText, int width)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            if (fieldName == "Cantidad" || fieldName == "MovementID" || fieldName == "TransferID")
            {
                columna.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            }

            gridMovimientos.Columns.Add(columna);
        }

        private void MostrarInfoResultados(int cantidad, string estado)
        {
            string tipoVista = vistaActualEsSalidas ? "Movimientos" : "Transferencias";
            string prefijo = estado == "últimos" ? "últimos" : "registros";

            lblEstado.Text = $"{cantidad:N0} {prefijo} {estado} en {tipoVista}";
            lblEstado.Visible = true;

            lblUltimaActualizacion.Text = $"Última actualización: {DateTime.Now:HH:mm:ss}";
        }

        private async void ActualizarKPIs()
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    CargarEstadisticasSalidas();
                    CargarEstadisticasTransferencias();
                });

                this.Invoke(new Action(() =>
                {
                    lblValorTotalRegistros.Text = (totalSalidas + totalEntradas + totalTransferencias).ToString("N0");
                    lblValorSalidas.Text = totalSalidas.ToString("N0");
                    lblValorEntradas.Text = totalEntradas.ToString("N0");
                    lblValorTransferencias.Text = totalTransferencias.ToString("N0");
                }));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error actualizando KPIs: {ex.Message}");
            }
        }

        private void CargarEstadisticasSalidas()
        {
            try
            {
                string query = @"
                    SELECT 
                        COUNT(*) as Total,
                        SUM(CASE WHEN MovementType = 'OUT' THEN 1 ELSE 0 END) as Salidas,
                        SUM(CASE WHEN MovementType = 'IN' THEN 1 ELSE 0 END) as Entradas
                    FROM pmc_InventoryMovements 
                    WHERE MovementType IS NOT NULL";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalSalidas = reader.GetInt32(1);
                            totalEntradas = reader.GetInt32(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando estadísticas de salidas: {ex.Message}");
            }
        }

        private void CargarEstadisticasTransferencias()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM pmc_InventoryTransfers WHERE Quantity > 0";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    totalTransferencias = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando estadísticas de transferencias: {ex.Message}");
            }
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
                RadMessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'", "Error en fechas",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            if (dtpDesde.Value.Date == dtpHasta.Value.Date &&
                dtpHoraDesde.Value.TimeOfDay > dtpHoraHasta.Value.TimeOfDay)
            {
                RadMessageBox.Show("La hora 'Desde' no puede ser mayor que la hora 'Hasta' para el mismo día",
                    "Error en horas", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            if (vistaActualEsSalidas)
            {
                AplicarFiltrosMovimientos();
            }
            else
            {
                CargarTransferenciasConFiltros();
            }
        }

        private void btnUltimosMovimientos_Click(object sender, EventArgs e)
        {
            if (vistaActualEsSalidas)
            {
                CargarUltimosMovimientos();
            }
            else
            {
                CargarTransferenciasSinFiltros();
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;

            // Resetear horas
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);

            if (vistaActualEsSalidas)
            {
                cbFiltroMovimiento.SelectedIndex = 0;
            }

            gridMovimientos.FilterDescriptors.Clear();
            gridMovimientos.GroupDescriptors.Clear();

            if (vistaActualEsSalidas)
                CargarUltimosMovimientos();
            else
                CargarTransferenciasSinFiltros();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string tipoVista = vistaActualEsSalidas ? "Movimientos" : "Transferencias";
            ExportHelper.ExportToExcel(gridMovimientos, $"Reporte {tipoVista}");
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            if (gridMovimientos.Columns.Count > 0)
            {
                gridMovimientos.BestFitColumns();
            }
        }
    }
}