using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        private const int TOP_INICIAL = 10000;
        private const int TOP_FILTRADO = 20000;
        private bool filtrosFechaAplicados = false;

        // Clase para cache de descripciones
        private static class DescripcionCache
        {
            private static ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();
            private static DateTime _ultimaActualizacion = DateTime.MinValue;
            private static readonly TimeSpan _tiempoVidaCache = TimeSpan.FromHours(4);
            private static readonly object _lock = new object();

            public static string ObtenerDescripcion(string codigo, string connectionString)
            {
                if (string.IsNullOrEmpty(codigo))
                    return string.Empty;

                // Limpiar cache si está expirado
                if (DateTime.Now - _ultimaActualizacion > _tiempoVidaCache)
                {
                    lock (_lock)
                    {
                        if (DateTime.Now - _ultimaActualizacion > _tiempoVidaCache)
                        {
                            _cache.Clear();
                            _ultimaActualizacion = DateTime.Now;
                        }
                    }
                }

                if (_cache.TryGetValue(codigo, out string descripcion))
                    return descripcion;

                descripcion = ObtenerDeBD(codigo, connectionString);
                _cache[codigo] = descripcion ?? string.Empty;

                return descripcion;
            }

            private static string ObtenerDeBD(string codigo, string connectionString)
            {
                try
                {
                    string query = @"
                        SELECT TOP 1 sub_descripcion 
                        FROM pmc_Subida_BOM WITH (NOLOCK) 
                        WHERE sub_producto = @codigo";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        con.Open();
                        return cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }

            public static void PrecargarDescripciones(IEnumerable<string> codigos, string connectionString)
            {
                Parallel.ForEach(codigos, codigo =>
                {
                    if (!string.IsNullOrEmpty(codigo) && !_cache.ContainsKey(codigo))
                    {
                        ObtenerDescripcion(codigo, connectionString);
                    }
                });
            }

            public static void LimpiarCache()
            {
                _cache.Clear();
                _ultimaActualizacion = DateTime.MinValue;
            }
        }

        public ReporteInventarioForm()
        {
            InitializeComponent();
            ConfigurarGrid();
            ConfigurarEstilos();
            ConfigurarFiltrosMovimientos();
            ConfigurarFiltrosHora();

            Task.Run(() => PrecargarCacheInicial());
        }

        private async void PrecargarCacheInicial()
        {
            try
            {
                string query = @"
                    SELECT DISTINCT TOP 1000 Code 
                    FROM pmc_InventoryMovements WITH (NOLOCK)
                    WHERE CreatedDate >= DATEADD(MONTH, -1, GETDATE())
                    UNION
                    SELECT DISTINCT TOP 1000 Code 
                    FROM pmc_InventoryTransfers WITH (NOLOCK)
                    WHERE CreatedDate >= DATEADD(MONTH, -1, GETDATE())";

                List<string> codigos = new List<string>();

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            codigos.Add(reader["Code"].ToString());
                        }
                    }
                }

                Task.Run(() => DescripcionCache.PrecargarDescripciones(codigos, connectionString));
            }
            catch { /* Ignorar errores en precarga */ }
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
            cbFiltroMovimiento.SelectedIndex = 0;
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
                SELECT TOP {0}
                    MovementID,
                    ItemCode,
                    TipoMovimiento,
                    Cantidad,
                    Descripcion,
                    LocalidadCode,
                    LocalidadName,
                    Carnet,
                    Nombre,
                    Fecha,
                    CreatedDate
                FROM (
                    SELECT 
                        mov.MovementID,
                        mov.Code AS ItemCode,
                        CASE 
                            WHEN mov.MovementType = 'OUT' THEN 'Salida'
                            WHEN mov.MovementType = 'IN' THEN 'Entrada'
                            WHEN mov.MovementType = 'OUT_SOBRANTES' THEN 'Salida/Sobrantes'
                            ELSE 'Otro Movimiento'
                        END AS TipoMovimiento,
                        mov.Quantity AS Cantidad,
                        mov.Description AS Descripcion,
                        mov.Warehouse AS LocalidadCode,
                        wh.WarehouseName AS LocalidadName,
                        mov.CreatedBy AS Carnet,
                        LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                        LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                        FORMAT(mov.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS Fecha,
                        mov.CreatedDate,
                        ROW_NUMBER() OVER (
                            PARTITION BY mov.Code, mov.CreatedDate, mov.MovementType, mov.Warehouse, mov.CreatedBy
                            ORDER BY mov.MovementID DESC
                        ) as rn
                    FROM pmc_InventoryMovements mov WITH (NOLOCK)
                    LEFT JOIN pmc_Warehouse wh WITH (NOLOCK)
                        ON mov.Warehouse = wh.WarehouseCode
                    LEFT JOIN mst_Empleados emp WITH (NOLOCK)
                        ON mov.CreatedBy = emp.Emp_ID
                    WHERE mov.MovementType IS NOT NULL
                        AND (@tipoMovimiento IS NULL OR mov.MovementType = @tipoMovimiento)
                ) as ranked
                WHERE rn = 1
                ORDER BY CreatedDate DESC";

            CargarDatosConCache(string.Format(query, TOP_INICIAL), "Salidas", false, tipoMovimiento);
            filtrosFechaAplicados = false;
        }

        private void AplicarFiltrosMovimientos()
        {
            if (vistaActualEsSalidas)
            {
                string tipoMovimiento = null;
                if (cbFiltroMovimiento.SelectedIndex == 1)
                    tipoMovimiento = "OUT";
                else if (cbFiltroMovimiento.SelectedIndex == 2)
                    tipoMovimiento = "IN";

                CargarSalidasConFiltros(tipoMovimiento);
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
                SELECT TOP {0}
                    MovementID,
                    ItemCode,
                    TipoMovimiento,
                    Cantidad,
                    Descripcion,
                    LocalidadCode,
                    LocalidadName,
                    Carnet,
                    Nombre,
                    Fecha,
                    CreatedDate
                FROM (
                    SELECT 
                        mov.MovementID,
                        mov.Code AS ItemCode,
                        CASE 
                            WHEN mov.MovementType = 'OUT' THEN 'Salida'
                            WHEN mov.MovementType = 'IN' THEN 'Entrada'
                            WHEN mov.MovementType = 'OUT_SOBRANTES' THEN 'Salida/Sobrantes'
                            ELSE 'Otro Movimiento'
                        END AS TipoMovimiento,
                        mov.Quantity AS Cantidad,
                        mov.Description AS Descripcion,
                        mov.Warehouse AS LocalidadCode,
                        wh.WarehouseName AS LocalidadName,
                        mov.CreatedBy AS Carnet,
                        LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                        LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                        FORMAT(mov.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS Fecha,
                        mov.CreatedDate,
                        ROW_NUMBER() OVER (
                            PARTITION BY mov.Code, mov.CreatedDate, mov.MovementType, mov.Warehouse, mov.CreatedBy
                            ORDER BY mov.MovementID DESC
                        ) as rn
                    FROM pmc_InventoryMovements mov WITH (NOLOCK)
                    LEFT JOIN pmc_Warehouse wh WITH (NOLOCK)
                        ON mov.Warehouse = wh.WarehouseCode
                    LEFT JOIN mst_Empleados emp WITH (NOLOCK)
                        ON mov.CreatedBy = emp.Emp_ID
                    WHERE mov.MovementType IS NOT NULL
                ) as ranked
                WHERE rn = 1
                ORDER BY CreatedDate DESC";

            CargarDatosConCache(string.Format(query, TOP_INICIAL), "Salidas", false);
            filtrosFechaAplicados = false;
        }

        private void CargarTransferenciasSinFiltros()
        {
            MostrarProgreso("Cargando transferencias...");

            string query = @"
                SELECT TOP {0}
                    TransferID,
                    ItemCode,
                    TipoMovimiento,
                    Cantidad,
                    OrigenName,
                    DestinoName,
                    Descripcion,
                    Carnet,
                    Nombre,
                    FechaFormateada,
                    CreatedDate
                FROM (
                    SELECT 
                        trans.TransferID,
                        trans.Code AS ItemCode,
                        'Transferencia' AS TipoMovimiento,
                        trans.Quantity AS Cantidad,
                        trans.Origin AS OrigenName,
                        trans.Destination AS DestinoName,
                        trans.Description AS Descripcion,
                        trans.CreatedBy AS Carnet,
                        LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                        LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                        FORMAT(trans.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS FechaFormateada,
                        trans.CreatedDate,
                        ROW_NUMBER() OVER (
                            PARTITION BY trans.Code, trans.CreatedDate, trans.Origin, trans.Destination, trans.CreatedBy
                            ORDER BY trans.TransferID DESC
                        ) as rn
                    FROM pmc_InventoryTransfers trans WITH (NOLOCK)
                    LEFT JOIN pmc_Warehouse orig_wh WITH (NOLOCK)
                        ON trans.Origin = orig_wh.WarehouseCode
                    LEFT JOIN pmc_Warehouse dest_wh WITH (NOLOCK)
                        ON trans.Destination = dest_wh.WarehouseCode
                    LEFT JOIN mst_Empleados emp WITH (NOLOCK)
                        ON trans.CreatedBy = emp.Emp_ID
                    WHERE trans.Quantity > 0
                ) as ranked
                WHERE rn = 1
                ORDER BY CreatedDate DESC";

            CargarDatosConCache(string.Format(query, TOP_INICIAL), "Transferencias", false);
            filtrosFechaAplicados = false;
        }

        private async void CargarDatosConCache(string query, string tipoVista, bool aplicarFiltrosFecha,
                                             string tipoMovimiento = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                cargandoDatos = true;

                MostrarProgreso("Cargando datos...");

                DataTable dt = await Task.Run(() =>
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 120;

                        if (aplicarFiltrosFecha && fechaDesde.HasValue && fechaHasta.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@desde", fechaDesde.Value);
                            cmd.Parameters.AddWithValue("@hasta", fechaHasta.Value);
                        }

                        if (!string.IsNullOrEmpty(tipoMovimiento))
                        {
                            cmd.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);
                        }
                        else
                        {
                            cmd.Parameters.Add("@tipoMovimiento", SqlDbType.VarChar, 20).Value = DBNull.Value;
                        }

                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);
                        return dataTable;
                    }
                });

                if (!dt.Columns.Contains("sub_descripcion"))
                {
                    dt.Columns.Add("sub_descripcion", typeof(string));
                }

                MostrarProgreso("Obteniendo descripciones...");

                var codigosUnicos = new HashSet<string>();
                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["ItemCode"]?.ToString();
                    if (!string.IsNullOrEmpty(codigo))
                        codigosUnicos.Add(codigo);
                }

                await Task.Run(() =>
                {
                    DescripcionCache.PrecargarDescripciones(codigosUnicos, connectionString);
                });

                foreach (DataRow row in dt.Rows)
                {
                    string codigo = row["ItemCode"]?.ToString();
                    if (!string.IsNullOrEmpty(codigo))
                    {
                        row["sub_descripcion"] = DescripcionCache.ObtenerDescripcion(codigo, connectionString);
                    }
                }

                this.Invoke(new Action(() =>
                {
                    gridMovimientos.DataSource = dt;
                    ConfigurarColumnasGrid(tipoVista);
                    ActualizarKPIs();

                    string estado = aplicarFiltrosFecha ? "filtrados" : "últimos";
                    MostrarInfoResultados(dt.Rows.Count, estado);
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    RadMessageBox.Show("Error al cargar datos: " + ex.Message, "Error",
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                }));
            }
            finally
            {
                cargandoDatos = false;
                OcultarProgreso();
            }
        }

        private void CargarSalidasConFiltros(string tipoMovimiento = null)
        {
            try
            {
                MostrarProgreso("Aplicando filtros a movimientos...");

                DateTime fechaDesde = dtpDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
                DateTime fechaHasta = dtpHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

                string query = @"
                    SELECT TOP {0}
                        MovementID,
                        ItemCode,
                        TipoMovimiento,
                        Cantidad,
                        Descripcion,
                        LocalidadCode,
                        LocalidadName,
                        Carnet,
                        Nombre,
                        Fecha,
                        CreatedDate
                    FROM (
                        SELECT 
                            mov.MovementID,
                            mov.Code AS ItemCode,
                            CASE 
                                WHEN mov.MovementType = 'OUT' THEN 'Salida'
                                WHEN mov.MovementType = 'IN' THEN 'Entrada'
                                WHEN mov.MovementType = 'OUT_SOBRANTES' THEN 'Salida/Sobrantes'
                                ELSE 'Otro Movimiento'
                            END AS TipoMovimiento,
                            mov.Quantity AS Cantidad,
                            mov.Description AS Descripcion,
                            mov.Warehouse AS LocalidadCode,
                            wh.WarehouseName AS LocalidadName,
                            mov.CreatedBy AS Carnet,
                            LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                            LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                            FORMAT(mov.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS Fecha,
                            mov.CreatedDate,
                            ROW_NUMBER() OVER (
                                PARTITION BY mov.Code, mov.CreatedDate, mov.MovementType, mov.Warehouse, mov.CreatedBy
                                ORDER BY mov.MovementID DESC
                            ) as rn
                        FROM pmc_InventoryMovements mov WITH (NOLOCK)
                        LEFT JOIN pmc_Warehouse wh WITH (NOLOCK)
                            ON mov.Warehouse = wh.WarehouseCode
                        LEFT JOIN mst_Empleados emp WITH (NOLOCK)
                            ON mov.CreatedBy = emp.Emp_ID
                        WHERE mov.MovementType IS NOT NULL
                            AND mov.CreatedDate BETWEEN @desde AND @hasta
                            AND (@tipoMovimiento IS NULL OR mov.MovementType = @tipoMovimiento)
                    ) as ranked
                    WHERE rn = 1
                    ORDER BY CreatedDate DESC";

                CargarDatosConCache(string.Format(query, TOP_FILTRADO), "Salidas", true, tipoMovimiento, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                OcultarProgreso();
            }
        }

        private void CargarTransferenciasConFiltros()
        {
            try
            {
                MostrarProgreso("Aplicando filtros a transferencias...");

                DateTime fechaDesde = dtpDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
                DateTime fechaHasta = dtpHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

                string query = @"
                    SELECT TOP {0}
                        TransferID,
                        ItemCode,
                        TipoMovimiento,
                        Cantidad,
                        OrigenName,
                        DestinoName,
                        Descripcion,
                        Carnet,
                        Nombre,
                        FechaFormateada,
                        CreatedDate
                    FROM (
                        SELECT 
                            trans.TransferID,
                            trans.Code AS ItemCode,
                            'Transferencia' AS TipoMovimiento,
                            trans.Quantity AS Cantidad,
                            trans.Origin AS OrigenName,
                            trans.Destination AS DestinoName,
                            trans.Description AS Descripcion,
                            trans.CreatedBy AS Carnet,
                            LEFT(emp.Emp_Nombres, CHARINDEX(' ', emp.Emp_Nombres + ' ') - 1) + ' ' + 
                            LEFT(emp.Emp_Apellidos, CHARINDEX(' ', emp.Emp_Apellidos + ' ') - 1) AS Nombre,
                            FORMAT(trans.CreatedDate, 'dd-MMM-yyyy hh:mm tt') AS FechaFormateada,
                            trans.CreatedDate,
                            ROW_NUMBER() OVER (
                                PARTITION BY trans.Code, trans.CreatedDate, trans.Origin, trans.Destination, trans.CreatedBy
                                ORDER BY trans.TransferID DESC
                            ) as rn
                        FROM pmc_InventoryTransfers trans WITH (NOLOCK)
                        LEFT JOIN pmc_Warehouse orig_wh WITH (NOLOCK)
                            ON trans.Origin = orig_wh.WarehouseCode
                        LEFT JOIN pmc_Warehouse dest_wh WITH (NOLOCK)
                            ON trans.Destination = dest_wh.WarehouseCode
                        LEFT JOIN mst_Empleados emp WITH (NOLOCK)
                            ON trans.CreatedBy = emp.Emp_ID
                        WHERE trans.Quantity > 0
                            AND trans.CreatedDate BETWEEN @desde AND @hasta
                    ) as ranked
                    WHERE rn = 1
                    ORDER BY CreatedDate DESC";

                CargarDatosConCache(string.Format(query, TOP_FILTRADO), "Transferencias", true, null, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
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
                await Task.Run(() =>
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
            catch { }
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
                    FROM pmc_InventoryMovements WITH (NOLOCK)
                    WHERE MovementType IS NOT NULL
                        AND YEAR(CreatedDate) = YEAR(GETDATE())";

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
            catch { }
        }

        private void CargarEstadisticasTransferencias()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM pmc_InventoryTransfers WITH (NOLOCK) WHERE Quantity > 0 AND YEAR(CreatedDate) = YEAR(GETDATE())";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    totalTransferencias = (int)cmd.ExecuteScalar();
                }
            }
            catch { }
        }

        private void MostrarProgreso(string mensaje)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => MostrarProgreso(mensaje)));
                return;
            }

            progressCarga.Visible = true;
            lblEstado.Text = mensaje;
            lblEstado.Visible = true;
            btnFiltrar.Enabled = false;
            btnUltimosMovimientos.Enabled = false;
            btnLimpiarFiltros.Enabled = false;
            btnVerSalidas.Enabled = false;
            btnVerTransferencias.Enabled = false;
            cbFiltroMovimiento.Enabled = false;
        }

        private void OcultarProgreso()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OcultarProgreso()));
                return;
            }

            progressCarga.Visible = false;
            btnFiltrar.Enabled = true;
            btnUltimosMovimientos.Enabled = true;
            btnLimpiarFiltros.Enabled = true;
            btnVerSalidas.Enabled = true;
            btnVerTransferencias.Enabled = true;
            cbFiltroMovimiento.Enabled = vistaActualEsSalidas;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            TimeSpan diferencia = dtpHasta.Value - dtpDesde.Value;

            if (diferencia.TotalDays > 60)
            {
                DialogResult result = RadMessageBox.Show(
                    $"Está solicitando {diferencia.TotalDays:N0} días de datos. " +
                    "Esto puede tomar mucho tiempo y mostrará solo los primeros 20,000 registros. ¿Desea continuar?",
                    "Advertencia",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Exclamation);

                if (result == DialogResult.No)
                    return;
            }

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

            bool esSalidas = vistaActualEsSalidas;
            string tipoMovimiento = null;

            if (esSalidas)
            {
                if (cbFiltroMovimiento.SelectedIndex == 1)
                    tipoMovimiento = "OUT";
                else if (cbFiltroMovimiento.SelectedIndex == 2)
                    tipoMovimiento = "IN";
            }

            DateTime fechaDesde = dtpDesde.Value.Date + dtpHoraDesde.Value.TimeOfDay;
            DateTime fechaHasta = dtpHasta.Value.Date + dtpHoraHasta.Value.TimeOfDay;

            Task.Run(() =>
            {
                if (esSalidas)
                    CargarSalidasConFiltros(tipoMovimiento);
                else
                    CargarTransferenciasConFiltros();
            });
        }

        private void btnUltimosMovimientos_Click(object sender, EventArgs e)
        {
            if (vistaActualEsSalidas)
                CargarUltimosMovimientos();
            else
                CargarTransferenciasSinFiltros();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            dtpHoraDesde.Value = DateTime.Today;
            dtpHoraHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59);

            if (vistaActualEsSalidas)
                cbFiltroMovimiento.SelectedIndex = 0;

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
                gridMovimientos.BestFitColumns();
        }
    }
}