using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    public partial class InventoryOverviewForm : Telerik.WinControls.UI.RadForm
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;
        private bool cargandoDatos = false;
        private string localidadSeleccionada = "TODOS";

        public InventoryOverviewForm()
        {
            InitializeComponent();
            ConfigurarGrid();
            ConfigurarEstilos();
            ConfigurarBotonesLocalidad();
        }

        private void InventoryOverviewForm_Load(object sender, EventArgs e)
        {
            CargarInventarioGeneral();
        }

        private void ConfigurarEstilos()
        {
            this.ThemeName = "Fluent";
            gridInventario.ThemeName = "Fluent";
            gridInventario.TableElement.RowHeight = 30;
        }

        private void ConfigurarBotonesLocalidad()
        {
            // Marcar el botón TODOS como seleccionado inicialmente
            MarcarBotonSeleccionado(btnTodos);
        }

        private void ConfigurarGrid()
        {
            gridInventario.AutoGenerateColumns = false;
            gridInventario.AllowAddNewRow = false;
            gridInventario.AllowColumnReorder = true;
            gridInventario.ShowGroupPanel = true;
            gridInventario.EnableFiltering = true;

            // IMPORTANTE: Deshabilitar autoajuste automático de columnas
            gridInventario.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            gridInventario.TableElement.AlternatingRowColor = System.Drawing.Color.FromArgb(250, 250, 250);
        }

        private void MarcarBotonSeleccionado(RadButton boton)
        {
            // Resetear todos los botones
            ResetearBotones();

            // Marcar el botón seleccionado
            boton.BackColor = System.Drawing.Color.FromArgb(41, 128, 185); // Azul seleccionado
            boton.ForeColor = System.Drawing.Color.White;
            boton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        }

        private void ResetearBotones()
        {
            RadButton[] botones = {
                btnTodos, btnPreparacion, btnPrinthub, btnVentana,
                btnSobrantes, btnEnMesa, btnEnEstante
            };

            foreach (var boton in botones)
            {
                boton.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
                boton.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                boton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            }
        }

        private void CargarInventarioGeneral(string localidad = null)
        {
            MostrarProgreso("Cargando inventario...");

            string query;
            bool esSobrantes = (localidad == "SOBRANTES");
            bool esEnMesa = (localidad == "EN MESA");

            if (esSobrantes)
            {
                // Consulta especial para SOBRANTES con columna Saca
                query = @"
                    WITH Inventarios AS (
                        -- 1. PREPARACION
                        SELECT 
                            ip.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(ip.TotalQuantity) AS INT) AS Cantidad,
                            ip.Location AS Ubicacion,
                            ip.BoxID,
                            '--' AS BIN,
                            w.WarehouseName AS Localidad,
                            NULL AS Saca,
                            1 AS Orden
                        FROM pmc_InventoryPreparation ip
                        INNER JOIN pmc_Warehouse w ON ip.WarehouseID = w.WarehouseID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON ip.Code = SB.sub_producto AND SB.rn = 1
                        WHERE w.WarehouseCode = 'PREP'
                            AND ip.TotalQuantity > 0
                        GROUP BY ip.Code, w.WarehouseName, ip.Location, ip.BoxID
                        HAVING SUM(ip.TotalQuantity) > 0
                        
                        UNION ALL
                        
                        -- 2. PRINTHUB
                        SELECT 
                            ip.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(ip.TotalQuantity) AS INT) AS Cantidad,
                            ip.Location AS Ubicacion,
                            ip.BoxID,
                            '--' AS BIN,
                            w.WarehouseName AS Localidad,
                            NULL AS Saca,
                            2 AS Orden
                        FROM pmc_InventoryPreparation ip
                        INNER JOIN pmc_Warehouse w ON ip.WarehouseID = w.WarehouseID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON ip.Code = SB.sub_producto AND SB.rn = 1
                        WHERE w.WarehouseCode = 'PRINT'
                            AND ip.TotalQuantity > 0
                        GROUP BY ip.Code, w.WarehouseName, ip.Location, ip.BoxID
                        HAVING SUM(ip.TotalQuantity) > 0
                        
                        UNION ALL
                        
                        -- 3. VENTANA
                        SELECT 
                            ip.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(ip.TotalQuantity) AS INT) AS Cantidad,
                            ip.Location AS Ubicacion,
                            ip.BoxID,
                            '--' AS BIN,
                            w.WarehouseName AS Localidad,
                            NULL AS Saca,
                            3 AS Orden
                        FROM pmc_InventoryPreparation ip
                        INNER JOIN pmc_Warehouse w ON ip.WarehouseID = w.WarehouseID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON ip.Code = SB.sub_producto AND SB.rn = 1
                        WHERE w.WarehouseCode = 'VENT'
                            AND ip.TotalQuantity > 0
                        GROUP BY ip.Code, w.WarehouseName, ip.Location, ip.BoxID
                        HAVING SUM(ip.TotalQuantity) > 0
                        
                        UNION ALL
                        
                        -- 4. SOBRANTES (OVERSTOCK) - CON COLUMNA SACA
                        SELECT 
                            io.Item AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(io.Quantity) AS INT) AS Cantidad,
                            COALESCE(io.Location, 'N/A') AS Ubicacion,
                            'N/A' AS BoxID,
                            '--' AS BIN,
                            'SOBRANTES' AS Localidad,
                            io.Saca AS Saca,
                            4 AS Orden
                        FROM pmc_InventoryOverstock io
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON io.Item = SB.sub_producto AND SB.rn = 1
                        WHERE io.Quantity > 0
                        GROUP BY io.Item, io.Location, io.Saca
                        HAVING SUM(io.Quantity) > 0
                        
                        UNION ALL
                        
                        -- 5. EN MESA (versión para TODOS)
                        SELECT 
                            td.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(td.QuantityREAL) AS INT) AS Cantidad,
                            'N/A' AS Ubicacion,
                            'N/A' AS BoxID,
                            '--' AS BIN,
                            'EN MESA' AS Localidad,
                            NULL AS Saca,
                            5 AS Orden
                        FROM [Tracer].[dbo].[pmc_AsignacionTraceIDs] a
                        INNER JOIN pmc_Transactions t ON a.TraceId = t.TraceID
                        INNER JOIN pmc_TransactionDetails td ON t.ID = td.TransactionID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON td.Code = SB.sub_producto AND SB.rn = 1
                        WHERE a.Status IN ('Pendiente', 'EnProceso')
                            AND CAST(a.AssignmentDate AS DATE) = CAST(GETDATE() AS DATE)
                            AND td.QuantityREAL > 0
                        GROUP BY td.Code
                        HAVING SUM(td.QuantityREAL) > 0
                        
                        UNION ALL
                        
                        -- 6. EN ESTANTE
                        SELECT 
                            td.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(td.QuantityREAL) AS INT) AS Cantidad,
                            'N/A' AS Ubicacion,
                            'N/A' AS BoxID,
                            COALESCE(MAX(CT.Bin), 'N/A') AS BIN,
                            'EN ESTANTE' AS Localidad,
                            NULL AS Saca,
                            6 AS Orden
                        FROM pmc_Transactions t
                        INNER JOIN pmc_TransactionDetails td ON t.ID = td.TransactionID
                        LEFT JOIN Tracer.dbo.CheckPointTrans CT ON t.TraceID = CT.TraceID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON td.Code = SB.sub_producto AND SB.rn = 1
                        WHERE t.StatusID = 4 
                            AND td.QuantityREAL > 0
                        GROUP BY td.Code
                        HAVING SUM(td.QuantityREAL) > 0
                    )
                    SELECT 
                        Codigo,
                        Descripcion,
                        TipoMaterial,
                        Cantidad,
                        Ubicacion,
                        BoxID,
                        BIN,
                        Localidad,
                        Saca
                    FROM Inventarios
                    WHERE Localidad = 'SOBRANTES'
                    ORDER BY Codigo";
            }
            else if (esEnMesa)
            {
                query = @"
                    SELECT 
                        td.Code AS Codigo,
                        MAX(SB.sub_descripcion) AS Descripcion,
                        MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                        CAST(SUM(td.QuantityREAL) AS INT) AS Cantidad,
                        COALESCE('MESA ' + CAST(a.TableId AS VARCHAR), 'SIN MESA') AS Ubicacion,
                        'N/A' AS BoxID,
                        '--' AS BIN,
                        'EN MESA' AS Localidad
                    FROM [Tracer].[dbo].[pmc_AsignacionTraceIDs] a
                    INNER JOIN pmc_Transactions t ON a.TraceId = t.TraceID
                    INNER JOIN pmc_TransactionDetails td ON t.ID = td.TransactionID
                    LEFT JOIN (
                        SELECT 
                            sub_producto, 
                            sub_descripcion,
                            sub_TypeMaterials,
                            ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                        FROM pmc_Subida_BOM
                    ) SB ON td.Code = SB.sub_producto AND SB.rn = 1
                    WHERE a.Status IN ('Pendiente', 'EnProceso')
                        AND CAST(a.AssignmentDate AS DATE) = CAST(GETDATE() AS DATE)
                        AND td.QuantityREAL > 0
                    GROUP BY td.Code, a.TableId
                    HAVING SUM(td.QuantityREAL) > 0
                    ORDER BY td.Code";
            }
            else
            {
                query = @"
                    WITH Inventarios AS (
                        -- 1. PREPARACION
                        SELECT 
                            ip.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(ip.TotalQuantity) AS INT) AS Cantidad,
                            ip.Location AS Ubicacion,
                            ip.BoxID,
                            '--' AS BIN,
                            w.WarehouseName AS Localidad,
                            1 AS Orden
                        FROM pmc_InventoryPreparation ip
                        INNER JOIN pmc_Warehouse w ON ip.WarehouseID = w.WarehouseID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON ip.Code = SB.sub_producto AND SB.rn = 1
                        WHERE w.WarehouseCode = 'PREP'
                            AND ip.TotalQuantity > 0
                        GROUP BY ip.Code, w.WarehouseName, ip.Location, ip.BoxID
                        HAVING SUM(ip.TotalQuantity) > 0
                        
                        UNION ALL
                        
                        -- 2. PRINTHUB
                        SELECT 
                            ip.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(ip.TotalQuantity) AS INT) AS Cantidad,
                            ip.Location AS Ubicacion,
                            ip.BoxID,
                            '--' AS BIN,
                            w.WarehouseName AS Localidad,
                            2 AS Orden
                        FROM pmc_InventoryPreparation ip
                        INNER JOIN pmc_Warehouse w ON ip.WarehouseID = w.WarehouseID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON ip.Code = SB.sub_producto AND SB.rn = 1
                        WHERE w.WarehouseCode = 'PRINT'
                            AND ip.TotalQuantity > 0
                        GROUP BY ip.Code, w.WarehouseName, ip.Location, ip.BoxID
                        HAVING SUM(ip.TotalQuantity) > 0
                        
                        UNION ALL
                        
                        -- 3. VENTANA
                        SELECT 
                            ip.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(ip.TotalQuantity) AS INT) AS Cantidad,
                            ip.Location AS Ubicacion,
                            ip.BoxID,
                            '--' AS BIN,
                            w.WarehouseName AS Localidad,
                            3 AS Orden
                        FROM pmc_InventoryPreparation ip
                        INNER JOIN pmc_Warehouse w ON ip.WarehouseID = w.WarehouseID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON ip.Code = SB.sub_producto AND SB.rn = 1
                        WHERE w.WarehouseCode = 'VENT'
                            AND ip.TotalQuantity > 0
                        GROUP BY ip.Code, w.WarehouseName, ip.Location, ip.BoxID
                        HAVING SUM(ip.TotalQuantity) > 0
                        
                        UNION ALL
                        
                        -- 4. SOBRANTES (OVERSTOCK) - SIN COLUMNA SACA
                        SELECT 
                            io.Item AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(io.Quantity) AS INT) AS Cantidad,
                            COALESCE(io.Location, 'N/A') AS Ubicacion,
                            'N/A' AS BoxID,
                            '--' AS BIN,
                            'SOBRANTES' AS Localidad,
                            4 AS Orden
                        FROM pmc_InventoryOverstock io
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON io.Item = SB.sub_producto AND SB.rn = 1
                        WHERE io.Quantity > 0
                        GROUP BY io.Item, io.Location
                        HAVING SUM(io.Quantity) > 0
                        
                        UNION ALL
                        
                        -- 5. EN MESA (versión para TODOS)
                        SELECT 
                            td.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(td.QuantityREAL) AS INT) AS Cantidad,
                            'N/A' AS Ubicacion,
                            'N/A' AS BoxID,
                            '--' AS BIN,
                            'EN MESA' AS Localidad,
                            5 AS Orden
                        FROM [Tracer].[dbo].[pmc_AsignacionTraceIDs] a
                        INNER JOIN pmc_Transactions t ON a.TraceId = t.TraceID
                        INNER JOIN pmc_TransactionDetails td ON t.ID = td.TransactionID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON td.Code = SB.sub_producto AND SB.rn = 1
                        WHERE a.Status IN ('Pendiente', 'EnProceso')
                            AND CAST(a.AssignmentDate AS DATE) = CAST(GETDATE() AS DATE)
                            AND td.QuantityREAL > 0
                        GROUP BY td.Code
                        HAVING SUM(td.QuantityREAL) > 0
                        
                        UNION ALL
                        
                        -- 6. EN ESTANTE
                        SELECT 
                            td.Code AS Codigo,
                            MAX(SB.sub_descripcion) AS Descripcion,
                            MAX(SB.sub_TypeMaterials) AS TipoMaterial,
                            CAST(SUM(td.QuantityREAL) AS INT) AS Cantidad,
                            'N/A' AS Ubicacion,
                            'N/A' AS BoxID,
                            COALESCE(MAX(CT.Bin), 'N/A') AS BIN,
                            'EN ESTANTE' AS Localidad,
                            6 AS Orden
                        FROM pmc_Transactions t
                        INNER JOIN pmc_TransactionDetails td ON t.ID = td.TransactionID
                        LEFT JOIN Tracer.dbo.CheckPointTrans CT ON t.TraceID = CT.TraceID
                        LEFT JOIN (
                            SELECT 
                                sub_producto, 
                                sub_descripcion,
                                sub_TypeMaterials,
                                ROW_NUMBER() OVER (PARTITION BY sub_producto ORDER BY sub_id) as rn
                            FROM pmc_Subida_BOM
                        ) SB ON td.Code = SB.sub_producto AND SB.rn = 1
                        WHERE t.StatusID = 4 
                            AND td.QuantityREAL > 0
                        GROUP BY td.Code
                        HAVING SUM(td.QuantityREAL) > 0
                    )
                    SELECT 
                        Codigo,
                        Descripcion,
                        TipoMaterial,
                        Cantidad,
                        Ubicacion,
                        BoxID,
                        BIN,
                        Localidad";

                if (string.IsNullOrEmpty(localidad) || localidad == "TODOS")
                {
                    query += @" FROM Inventarios
                               ORDER BY Localidad, Codigo";
                }
                else
                {
                    query += @" FROM Inventarios
                               WHERE Localidad = @localidad
                               ORDER BY Codigo";
                }
            }

            CargarDatos(query, localidad, esSobrantes, esEnMesa);
        }

        private void CargarDatos(string query, string localidad, bool esSobrantes = false, bool esEnMesa = false)
        {
            try
            {
                cargandoDatos = true;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrEmpty(localidad) && localidad != "TODOS" && !esSobrantes && !esEnMesa)
                        {
                            cmd.Parameters.AddWithValue("@localidad", localidad);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gridInventario.DataSource = dt;


                        ConfigurarColumnasGrid(esSobrantes, esEnMesa);
                        MostrarInfoResultados(dt.Rows.Count, localidad);
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al cargar inventario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                cargandoDatos = false;
                OcultarProgreso();
            }
        }

        private void ConfigurarColumnasGrid(bool mostrarSaca = false, bool esEnMesa = false)
        {
            gridInventario.Columns.Clear();

            // Configurar columnas con tamaños fijos
            if (mostrarSaca)
            {
                AgregarColumnaFija("Saca", "SACA", 100);
            }

            // Columnas comunes
            AgregarColumnaFija("Codigo", "CÓDIGO", 150);

            // Columnas con tamaño inicial pero que pueden ajustarse
            AgregarColumnaVariable("Descripcion", "DESCRIPCIÓN", 250);
            AgregarColumnaVariable("TipoMaterial", "TIPO MATERIAL", 150);

            AgregarColumnaFija("Cantidad", "CANTIDAD", 120, true); // true = formato numérico
            if (esEnMesa)
            {
                AgregarColumnaVariable("Ubicacion", "MESA", 120);
            }
            else
            {
                AgregarColumnaVariable("Ubicacion", "UBICACIÓN", 130);
            }
            AgregarColumnaFija("BoxID", "CAJA", 120);
            AgregarColumnaFija("BIN", "BIN", 100);
            AgregarColumnaVariable("Localidad", "LOCALIDAD", 150);

        }

        private void AgregarColumnaFija(string fieldName, string headerText, int width, bool esNumerico = false)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.AllowResize = false;
            columna.AutoSizeMode = BestFitColumnMode.None;

            if (esNumerico)
            {
                columna.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
                columna.FormatString = "{0:N0}";
            }
            else
            {
                columna.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            }

            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridInventario.Columns.Add(columna);
        }

        private void AgregarColumnaVariable(string fieldName, string headerText, int width)
        {
            GridViewTextBoxColumn columna = new GridViewTextBoxColumn();
            columna.FieldName = fieldName;
            columna.HeaderText = headerText;
            columna.Width = width;
            columna.AllowResize = true;
            columna.AutoSizeMode = BestFitColumnMode.None;
            columna.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            columna.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            gridInventario.Columns.Add(columna);
        }

        private void MostrarInfoResultados(int cantidad, string localidad)
        {
            string textoLocalidad = localidad == "TODOS" ? "TODAS LAS LOCALIDADES" : localidad;
            lblEstado.Text = $"{cantidad:N0} registros en {textoLocalidad}";
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

        #region Eventos de botones

        private void btnTodos_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "TODOS";
            MarcarBotonSeleccionado(btnTodos);
            CargarInventarioGeneral();
        }

        private void btnPreparacion_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "PREPARACIÓN";
            MarcarBotonSeleccionado(btnPreparacion);
            CargarInventarioGeneral("PREPARACIÓN");
        }

        private void btnPrinthub_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "PRINTHUB";
            MarcarBotonSeleccionado(btnPrinthub);
            CargarInventarioGeneral("PRINTHUB");
        }

        private void btnVentana_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "VENTANA";
            MarcarBotonSeleccionado(btnVentana);
            CargarInventarioGeneral("VENTANA");
        }

        private void btnSobrantes_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "SOBRANTES";
            MarcarBotonSeleccionado(btnSobrantes);
            CargarInventarioGeneral("SOBRANTES");
        }

        private void btnEnMesa_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "EN MESA";
            MarcarBotonSeleccionado(btnEnMesa);
            CargarInventarioGeneral("EN MESA");
        }

        private void btnEnEstante_Click(object sender, EventArgs e)
        {
            localidadSeleccionada = "EN ESTANTE";
            MarcarBotonSeleccionado(btnEnEstante);
            CargarInventarioGeneral("EN ESTANTE");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Recargar según la localidad seleccionada actualmente
            if (string.IsNullOrEmpty(localidadSeleccionada) || localidadSeleccionada == "TODOS")
            {
                CargarInventarioGeneral();
            }
            else
            {
                CargarInventarioGeneral(localidadSeleccionada);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                string nombreLocalidad = localidadSeleccionada.Replace(" ", "_");
                saveDialog.FileName = $"Inventario_{nombreLocalidad}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    GridViewSpreadExport exporter = new GridViewSpreadExport(this.gridInventario);
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

        #endregion

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            // NO llamar a BestFitColumns() para mantener tamaños fijos
        }
    }
}