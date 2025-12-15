using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Rmc.MaterialEmpaque.Mesas;
using Telerik.WinControls;
using System.Linq;
using System.Drawing.Printing;
using Rmc.MaterialEmpaque.Impresion;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque
{
    public partial class BOMForm : Telerik.WinControls.UI.RadForm
    {
        // En el service se encuentra toda la logica para el manejo de las mesas
        private MesaService service = new MesaService(Properties.Settings.Default.TracerConnectionString);

        private bool isTraceIdAssigned = false;
        private bool isSacaAsssigned = false;
        SystemClass sc = new SystemClass();


        public BOMForm()
        {
            InitializeComponent();
            SetupPrintShortcut();
        }

        #region Imprimir

        private void SetupPrintShortcut()
        {
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                PrintReport();
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnReimprimir_Click(null, null);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (!ValidarTraceId(out string traceId, out int traceIdNumerico)) return;

            PrintReport();
        }


        private void PrintReport()
        {
            try
            {
                BOMReport.PrintReport();
                RadMessageBox.ThemeName = "Office2013Light";

                RadMessageBox.Show(
                    this,
                    "El documento ha sido enviado a la impresora\n\n" +
                    "   - Documento: BOM de Materiales\n" +
                    "   - Impresora: " + GetDefaultPrinterName(),
                    "Impresión Completada",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Info
                );
            }
            catch (Exception)
            {
                RadMessageBox.Show(
                    this,
                    "No se pudo completar la impresión\n\n" +
                    $"Detalles: Ocurrio un error",
                    "Error de Impresión",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
            }
        }

        private string GetDefaultPrinterName()
        {
            try
            {
                return new PrinterSettings().PrinterName;
            }
            catch
            {
                return "Predeterminada";
            }
        }
        #endregion


        /* -> Genera el BOM apartir del TraceID
        * 
        * - Parametros
        *  1. traceID
        *  2. sa/ca
        *  3. millStyle
        *  4. talla
        *  5. color
        *  6. dozens
        */
        private async void TxtTraceId_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string param = TxtTraceId.Text.Trim();

            if (param.Length >= 9 && long.TryParse(param, out _))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bool successSobreConsumo = await ProcessSobreConsumoAsync(param);
                    if (successSobreConsumo)
                    {
                        SafeClearRadTextBox(TxtTraceId);
                    }
                    else
                    {
                        SafeClearRadTextBox(TxtTraceId);
                        SafeFocusRadTextBox(TxtTraceId);
                    }
                }
            }
            else
            {
                if (e.KeyCode != Keys.Enter) return;

                bool successTracer = await ProcessTraceIdAsync();
                if (successTracer)
                {
                    SafeClearRadTextBox(TxtTraceId);
                }
            }
        }

        #region Métodos Helper para Invoke

        private void ShowMessageBox(string message, string caption, MessageBoxButtons buttons, RadMessageIcon icon)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string, MessageBoxButtons, RadMessageIcon>(ShowMessageBox),
                    message, caption, buttons, icon);
            }
            else
            {
                RadMessageBox.Show(this, message, caption, buttons, icon);
            }
        }

        private void SafeUpdateWaitingBar(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SafeUpdateWaitingBar), message);
            }
            else
            {
                UpdateWaitingBarMessage(message);
            }
        }

        private void SafeClearRadTextBox(RadTextBox textBox)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<RadTextBox>(SafeClearRadTextBox), textBox);
            }
            else
            {
                textBox.Clear();
            }
        }

        private void SafeFocusRadTextBox(RadTextBox textBox)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<RadTextBox>(SafeFocusRadTextBox), textBox);
            }
            else
            {
                textBox.Focus();
            }
        }

        private void SafeClearTextBox(TextBox textBox)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TextBox>(SafeClearTextBox), textBox);
            }
            else
            {
                textBox.Clear();
            }
        }

        private void SafeFocusTextBox(TextBox textBox)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<TextBox>(SafeFocusTextBox), textBox);
            }
            else
            {
                textBox.Focus();
            }
        }

        private void SafeClearTraceId()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SafeClearTraceId));
            }
            else
            {
                TxtTraceId.Clear();
            }
        }

        #endregion

        #region Procesar TraceIDs
        public async Task<bool> ProcessTraceIdAsync()
        {
            if (!ValidarTraceId(out string traceId, out int traceIdNumerico))
                return false;

            try
            {
                await EjecutarProcesoTraceIdConEspera(traceId);
                return true;
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error al procesar asignación:\n" + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return false;
            }
            finally
            {
                sc.CloseConectionTracer();
            }
        }

        private async Task EjecutarProcesoTraceIdConEspera(string traceId)
        {
            try
            {
                ShowWaitingBar("Procesando TraceID...");
                await Task.Run(() => EjecutarProcesoTraceId(traceId));
            }
            finally
            {
                HideWaitingBar();
            }
        }

        private void EjecutarProcesoTraceId(string traceId)
        {
            try
            {
                SafeUpdateWaitingBar("Obteniendo datos del TraceID...");
                var datosTrace = ObtenerDatosTraceSafe(traceId);

                if (datosTrace == null) return;

                SafeUpdateWaitingBar("Creando objeto de asignación...");
                var assignment = CrearObjetoAssignment(traceId, datosTrace);

                SafeUpdateWaitingBar("Asignando mesa y generando reporte...");
                AsignarMesaYGenerarReporteSafe(assignment, traceId);
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error al procesar TraceID:\n{ex.Message}", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void MostrarErrorProcesoTraceId(string mensaje)
        {
            ShowMessageBox($"Error al procesar TraceID:\n{mensaje}", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
        }

        private bool ValidarTraceId(out string traceId, out int traceIdNumerico)
        {
            traceId = TxtTraceId.Text.Trim();
            traceIdNumerico = 0;

            if (string.IsNullOrEmpty(traceId))
            {
                ShowMessageBox("El campo Trace ID está vacío.", "Validación", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }

            if (!int.TryParse(traceId, out traceIdNumerico))
            {
                ShowMessageBox("El valor ingresado no es un TraceID válido. Por favor, verifique el dato.", "Validación", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }

            if (!ValidarMesasActivas())
            {
                return false;
            }

            if (TraceIdYaIngresado(traceId))
            {
                return false;
            }

            var datosTrace = ObtenerDatosTrace(traceId);
            if (datosTrace == null)
            {
                return false;
            }

            if (!ValidarExistenciaSACA(datosTrace.Saca))
            {
                return false;
            }

            if (!ValidarDatosBOM(traceId))
            {
                return false;
            }

            return true;
        }

        private void clearTxt()
        {
            SafeClearRadTextBox(TxtTraceId);
            SafeClearRadTextBox(txtTraceIdReimpresion);
        }

        private bool ValidarMesasActivas()
        {
            if (!service.CheckActiveTables())
            {
                ShowMessageBox("No hay mesas activas configuradas en el modulo de Mesas",
                                "Error", MessageBoxButtons.OK, RadMessageIcon.Info);
                return false;
            }
            return true;
        }

        private bool TraceIdYaIngresado(string traceId)
        {
            if (service.CheckTraceIDs(traceId))
            {
                ShowMessageBox($"El siguiente traceID ->  {traceId}  ya fue ingresado",
                                "Informacion", MessageBoxButtons.OK, RadMessageIcon.Info);
                SafeClearTraceId();
                return true;
            }
            return false;
        }

        private dynamic ObtenerDatosTrace(string traceId)
        {
            try
            {
                string query_view = @"SELECT DISTINCT K.WeekID, K.Saca, K.Dozens AS Docenas_Por_Buggie,
                    LEFT(K.ColorMillStyle, 4) AS MillStyle,
                    RIGHT(K.ColorMillStyle, 4) AS Color,
                    MAX(ss.sub_factor) OVER () AS DZxCase,
                    K.Assort, dev.desv_item, dev.desv_Add, dev.desv_QtyToDesv, dev.desv_Week,
                    SUBSTRING(K.RawMillStyle, 5, 3) AS Talla
              FROM [View_Prekiteo] AS K
              LEFT JOIN es_socks.dbo.pmc_subida_bom AS ss
                  ON K.saca = ss.sub_saca COLLATE sql_latin1_general_cp1_ci_as
              LEFT JOIN dbo.pmc_Desviaciones AS dev
                  ON dev.desv_Week = K.WeekID COLLATE sql_latin1_general_cp1_ci_as
              WHERE K.TraceID = @TraceID;";

                using (SqlCommand cmd = new SqlCommand(query_view, sc.OpenConectionTracer()))
                {
                    cmd.Parameters.AddWithValue("@TraceID", traceId);
                    cmd.CommandTimeout = 60;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            ShowMessageBox("No se encontraron datos para el TraceID especificado.",
                                            "Error", MessageBoxButtons.OK, RadMessageIcon.Info);
                            SafeClearTraceId();
                            return null;
                        }

                        var datos = new
                        {
                            Semana = reader["WeekID"].ToString(),
                            Saca = reader["Saca"].ToString(),
                            Assort = reader["Assort"].ToString(),
                            MillStyle = reader["MillStyle"].ToString(),
                            Color = reader["Color"].ToString(),
                            Talla = reader["Talla"].ToString(),
                            Prod = reader["Docenas_Por_Buggie"].ToString(),
                            DzxCase = reader["DZxCase"].ToString(),
                            Desv = reader["desv_Add"].ToString(),
                            DesvMat = reader["desv_item"].ToString()
                        };

                        return datos;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                ShowMessageBox(
                    "La consulta está tomando más tiempo de lo esperado. Por favor, intente nuevamente.",
                    "Tiempo de espera agotado",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation
                );
                SafeClearTraceId();
                return null;
            }
            catch (SqlException ex)
            {
                ShowMessageBox(
                    $"Error de base de datos: {ex.Message}",
                    "Error de BD",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                SafeClearTraceId();
                return null;
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"Error inesperado: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                SafeClearTraceId();
                return null;
            }
        }

        private dynamic ObtenerDatosTraceSafe(string traceId)
        {
            try
            {
                string query_view = @"SELECT DISTINCT K.WeekID, K.Saca, K.Dozens AS Docenas_Por_Buggie,
                    LEFT(K.ColorMillStyle, 4) AS MillStyle,
                    RIGHT(K.ColorMillStyle, 4) AS Color,
                    MAX(ss.sub_factor) OVER () AS DZxCase,
                    K.Assort, dev.desv_item, dev.desv_Add, dev.desv_QtyToDesv, dev.desv_Week,
                    SUBSTRING(K.RawMillStyle, 5, 3) AS Talla
              FROM [View_Prekiteo] AS K
              INNER JOIN es_socks.dbo.pmc_subida_bom AS ss
                  ON K.saca = ss.sub_saca COLLATE sql_latin1_general_cp1_ci_as
              LEFT JOIN dbo.pmc_Desviaciones AS dev
                  ON dev.desv_Week = K.WeekID COLLATE sql_latin1_general_cp1_ci_as
              WHERE K.TraceID = @TraceID;";

                using (SqlCommand cmd = new SqlCommand(query_view, sc.OpenConectionTracer()))
                {
                    cmd.Parameters.AddWithValue("@TraceID", traceId);
                    cmd.CommandTimeout = 60;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            ShowMessageBox("No se encontraron datos para el TraceID especificado.",
                                            "Error", MessageBoxButtons.OK, RadMessageIcon.Info);
                            return null;
                        }

                        var datos = new
                        {
                            Semana = reader["WeekID"].ToString(),
                            Saca = reader["Saca"].ToString(),
                            Assort = reader["Assort"].ToString(),
                            MillStyle = reader["MillStyle"].ToString(),
                            Color = reader["Color"].ToString(),
                            Talla = reader["Talla"].ToString(),
                            Prod = reader["Docenas_Por_Buggie"].ToString(),
                            DzxCase = reader["DZxCase"].ToString(),
                            Desv = reader["desv_Add"].ToString(),
                            DesvMat = reader["desv_item"].ToString()
                        };

                        return datos;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                ShowMessageBox(
                    "La consulta está tomando más tiempo de lo esperado. Por favor, intente nuevamente.",
                    "Tiempo de espera agotado",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation
                );
                return null;
            }
            catch (SqlException ex)
            {
                ShowMessageBox(
                    $"Error de base de datos: {ex.Message}",
                    "Error de BD",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                return null;
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"Error inesperado: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                return null;
            }
        }

        private bool ValidarDatosBOM(string traceId)
        {
            try
            {
                string queryBOM = @"
                        SELECT TOP 1 1
                        FROM dbo.View_PreKiteo AS k
                        INNER JOIN es_socks.dbo.pmc_subida_bom AS ss 
                            ON k.saca = ss.sub_saca COLLATE SQL_Latin1_General_CP1_CI_AS
                        INNER JOIN dbo.pmc_consolidadoplanes AS c 
                            ON k.saca = c.sku
                        INNER JOIN dbo.pmc_saca_1as_2das_3ras AS s 
                            ON k.saca = s.pmc_saca_1ra
                        INNER JOIN dbo.pmc_doblado_irr AS d 
                            ON s.pmc_saca_2da = d.pmc_saca_irr
                        INNER JOIN dbo.pmc_productmaster AS P 
                            ON P.saca = k.saca
                        WHERE k.TraceID = @TraceID
                          AND k.ChkID IN ('BLEACHING','DYEING')";

                DataTable dtBOM = new DataTable();
                using (SqlCommand cmdBOM = new SqlCommand(queryBOM, sc.OpenConectionTracer()))
                {
                    cmdBOM.Parameters.AddWithValue("@TraceID", traceId);
                    cmdBOM.CommandTimeout = 60;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmdBOM))
                    {
                        da.Fill(dtBOM);
                    }
                }

                if (dtBOM.Rows.Count == 0)
                {
                    ShowMessageBox("El BOM no tiene datos completos para generarse. No se generará reporte ni se asignará mesa.",
                                    "Validacion BOM", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return false;
                }
                return true;
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                ShowMessageBox(
                    "La validación del BOM está tomando más tiempo de lo esperado. Por favor, intente nuevamente.",
                    "Tiempo de espera agotado",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation
                );
                return false;
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"Error durante la validación del BOM: {ex.Message}",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                return false;
            }
        }

        private AssignmentTracerIDs CrearObjetoAssignment(string traceId, dynamic datos)
        {
            return new AssignmentTracerIDs
            {
                traceId = traceId,
                saca = datos.Saca,
                millStyle = datos.MillStyle,
                size = int.TryParse(datos.Talla, out int t) ? t : 0,
                color = datos.Color,
                weekId = datos.Semana,
                dozens = datos.Prod,
                assortment = datos.Assort,
                deviation = datos.Desv,
                materialDeviation = datos.DesvMat,
            };
        }

        private void AsignarMesaYGenerarReporteSafe(AssignmentTracerIDs assignment, string traceId)
        {
            var (table, message) = service.AssignTable(assignment);

            if (table == 0)
            {
                ShowMessageBox(message, "Sin asignación", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            SafeUpdateWaitingBar("Creando transacción completa...");
            if (!EjecutarCrearTransaccionCompleta(traceId))
            {
                ShowMessageBox("Se generó el BOM pero hubo un error al crear la transacción.",
                    "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

            SafeUpdateWaitingBar("Generando reporte BOM...");
            GenerarReporteBOM(traceId, table);
        }

        private void GenerarReporteBOM(string traceId, int table)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, int>(GenerarReporteBOM), traceId, table);
                return;
            }

            try
            {
                var report = new Reportes.ReportesDesign.BOM();
                report.ReportParameters["TBL"].Value = table;
                report.ReportParameters["TraceID1"].Value = traceId;
                BOMReport.ReportSource = report;
                BOMReport.RefreshReport();
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error al generar reporte BOM:\n{ex.Message}",
                    "Error de Reporte", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private bool ValidarExistenciaSACA(string saca)
        {
            try
            {
                string query = @"
                    DECLARE @SACAs TABLE (SACA NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS);
                    INSERT INTO @SACAs (SACA) VALUES (@SACA);

                    SELECT 
                        s.SACA,
                        CASE WHEN EXISTS (SELECT 1 FROM pmc_productmaster WHERE saca COLLATE SQL_Latin1_General_CP1_CI_AS = 
                                            s.SACA COLLATE SQL_Latin1_General_CP1_CI_AS) THEN 'SUCCESS' ELSE 'FAIL' END AS En_ProductMaster,
                        CASE WHEN EXISTS (SELECT 1 FROM pmc_consolidadoplanes WHERE sku COLLATE SQL_Latin1_General_CP1_CI_AS = 
                                            s.SACA COLLATE SQL_Latin1_General_CP1_CI_AS) THEN 'SUCCESS' ELSE 'FAIL' END AS En_Consolidado,
                        CASE WHEN EXISTS (SELECT 1 FROM pmc_saca_1as_2das_3ras WHERE pmc_saca_1ra COLLATE SQL_Latin1_General_CP1_CI_AS = 
                                            s.SACA COLLATE SQL_Latin1_General_CP1_CI_AS) THEN 'SUCCESS' ELSE 'FAIL' END AS En_Saca_1ra,
                        CASE WHEN EXISTS (SELECT 1 FROM pmc_doblado_irr WHERE pmc_saca_irr COLLATE SQL_Latin1_General_CP1_CI_AS IN (
                                SELECT pmc_saca_2da COLLATE SQL_Latin1_General_CP1_CI_AS 
                                FROM pmc_saca_1as_2das_3ras 
                                WHERE pmc_saca_1ra COLLATE SQL_Latin1_General_CP1_CI_AS = s.SACA COLLATE SQL_Latin1_General_CP1_CI_AS
                            )
                        ) THEN 'SUCCESS' ELSE 'FAIL' END AS En_Doblado_IRR,
                        CASE WHEN EXISTS (SELECT 1 FROM es_socks.dbo.pmc_subida_bom WHERE sub_saca COLLATE SQL_Latin1_General_CP1_CI_AS = 
                                            s.SACA COLLATE SQL_Latin1_General_CP1_CI_AS) THEN 'SUCCESS' ELSE 'FAIL' END AS En_SubidaBOM,
                        CASE WHEN EXISTS (SELECT 1 FROM pmc_Bag_IRR WHERE pmc_SACA_IRR COLLATE SQL_Latin1_General_CP1_CI_AS IN (
                                SELECT pmc_saca_2da COLLATE SQL_Latin1_General_CP1_CI_AS 
                                FROM pmc_saca_1as_2das_3ras 
                                WHERE pmc_saca_1ra COLLATE SQL_Latin1_General_CP1_CI_AS = s.SACA COLLATE SQL_Latin1_General_CP1_CI_AS
                            )
                        ) THEN 'SUCCESS' ELSE 'FAIL' END AS En_Bag_IRR
                    FROM @SACAs s";

                using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                {
                    cmd.Parameters.AddWithValue("@SACA", saca);
                    cmd.CommandTimeout = 60;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0) return false;

                        DataRow row = dt.Rows[0];
                        List<string> fallos = new List<string>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "SACA") continue;
                            if (row[col].ToString() == "FAIL") fallos.Add(col.ColumnName);
                        }

                        if (fallos.Count > 0)
                        {
                            string mensaje = $"El siguiente SA/CA {saca} no existe en las siguientes tablas:\n\n" +
                                             string.Join("\n", fallos.Select(f => $"[-] {f}"));

                            ShowMessageBox(mensaje,
                                               "Validación de BOM",
                                               MessageBoxButtons.OK,
                                               RadMessageIcon.Info);
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                ShowMessageBox(
                    "La validación de SA/CA está tomando más tiempo de lo esperado. Por favor, intente nuevamente.",
                    "Tiempo de espera agotado",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation
                );
                return false;
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"Error durante la validación de SA/CA: {ex.Message}",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                return false;
            }
        }

        #endregion

        #region Reimprimir

        private async void BtnReimprimir_Click(object sender, EventArgs e)
        {
            string trace = txtTraceIdReimpresion.Text.Trim();

            if (long.TryParse(trace, out long traceNumber))
            {
                if (traceNumber >= 900000000 && traceNumber <= 999999999)
                {
                    await ReimprimirBOMSCAsync();
                }
                else if (traceNumber >= 800000000 && traceNumber <= 899999999)
                {
                    await ReimprimirBOMFDAsync();
                }
                else
                {
                    await ReimprimirBOMAsync();
                }
            }
            else
            {
                ShowMessageBox("Trace ID no válido", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private async void txtTraceIdReimpresion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await ReimprimirBOMAsync();
            }
        }

        private async Task ReimprimirBOMAsync()
        {
            string traceId = txtTraceIdReimpresion.Text.Trim();
            if (string.IsNullOrEmpty(traceId)) return;

            try
            {
                ShowWaitingBar("Reimprimiendo BOM...");
                await Task.Run(() => EjecutarReimpresionBOM(traceId));
            }
            finally
            {
                HideWaitingBar();
            }
        }

        private async Task ReimprimirBOMFDAsync()
        {
            string traceId = txtTraceIdReimpresion.Text.Trim();
            if (string.IsNullOrEmpty(traceId)) return;

            try
            {
                ShowWaitingBar("Reimprimiendo BOM Sobre Consumo...");
                long filtradoID = Convert.ToInt64(traceId);
                await Task.Run(() => GenerarReporteBOMFD(filtradoID));
            }
            finally
            {
                HideWaitingBar();
            }
        }

        private void EjecutarReimpresionBOM(string traceId)
        {
            try
            {
                SafeUpdateWaitingBar("Buscando mesa asignada...");
                int mesaAsignada = ObtenerMesaPorTraceId(traceId);

                if (mesaAsignada == 0)
                {
                    ShowMessageBox($"El siguiente TraceID '{traceId}' aun no tiene una mesa asignada.\n\n Importante: Solo puedes reimprimir BOM que ya fueron asignados",
                        "Info", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return;
                }

                SafeUpdateWaitingBar("Generando reporte...");
                GenerarReporteBOM(traceId, mesaAsignada);
                SafeClearRadTextBox(txtTraceIdReimpresion);
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error al reimprimir:\n" + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private async Task ReimprimirBOMSCAsync()
        {
            string traceId = txtTraceIdReimpresion.Text.Trim();
            if (string.IsNullOrEmpty(traceId)) return;

            try
            {
                ShowWaitingBar("Reimprimiendo BOM Sobre Consumo...");
                await Task.Run(() => EjecutarReimpresionBOMSC(traceId));
            }
            finally
            {
                HideWaitingBar();
            }
        }

        private void EjecutarReimpresionBOMSC(string traceId)
        {
            try
            {
                SafeUpdateWaitingBar("Generando reporte de sobre consumo...");
                long sobreConsumoId = Convert.ToInt64(traceId);

                if (InvokeRequired)
                {
                    Invoke(new Action<long>(GenerarReporteBOMSC), sobreConsumoId);
                }
                else
                {
                    GenerarReporteBOMSC(sobreConsumoId);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error al reimprimir:\n" + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void GenerarReporteBOMSC(long sobreConsumoId)
        {
            try
            {
                var report = new Reportes.ReportesDesign.BOMSC();
                report.ReportParameters["SobreConsumoID"].Value = sobreConsumoId;

                BOMReport.ReportSource = report;
                BOMReport.RefreshReport();
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error al generar reporte BOMSC:\n{ex.Message}",
                    "Error de Reporte", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private int ObtenerMesaPorTraceId(string traceId)
        {
            string query = "SELECT TableId FROM pmc_AsignacionTraceIDs WHERE TraceId = @TraceId";
            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                cmd.Parameters.AddWithValue("@TraceId", traceId);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private bool EjecutarCrearTransaccionCompleta(int traceID)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_CreateCompleteTransaction", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TraceID", traceID);
                    command.Parameters.AddWithValue("@Badge", Environment.UserName);

                    int result = command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException sqlEx)
            {
                ShowMessageBox($"Error de base de datos al crear la transacción:\n{sqlEx.Message}",
                    "Error de Base de Datos", MessageBoxButtons.OK, RadMessageIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error al crear la transacción:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return false;
            }
            finally
            {
                connection?.Close();
                connection?.Dispose();
            }
        }

        private bool EjecutarCrearTransaccionCompleta(string traceID)
        {
            if (int.TryParse(traceID, out int traceIdNumerico))
            {
                return EjecutarCrearTransaccionCompleta(traceIdNumerico);
            }
            else
            {
                ShowMessageBox("El TraceID no es válido",
                    "Error de Validación", MessageBoxButtons.OK, RadMessageIcon.Error);
                return false;
            }
        }

        #endregion

        #region Impresion de SobreconsumosIDs
        private async void txtSobreConsumoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool success = await ProcessSobreConsumoAsync(txtSobreConsumoId.Text);
                if (success)
                {
                    SafeClearRadTextBox(txtSobreConsumoId);
                }
                else
                {
                    SafeClearRadTextBox(txtSobreConsumoId);
                    SafeFocusRadTextBox(txtSobreConsumoId);
                }
            }
        }

        public async Task<bool> ProcessSobreConsumoAsync(string sobreConsumoIdInput)
        {
            if (!long.TryParse(sobreConsumoIdInput.Trim(), out long sobreConsumoId) ||
                sobreConsumoIdInput.Trim().Length != 9)
            {
                ShowMessageBox("El Sobre Consumo ID debe ser un número entero de 9 dígitos.",
                                   "Error de Validación",
                                   MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return false;
            }

            try
            {
                await EjecutarProcesoSobreConsumoConEspera(sobreConsumoId);
                return true;
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error en el proceso: {ex.Message}",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return false;
            }
        }

        private async Task EjecutarProcesoSobreConsumoConEspera(long sobreConsumoId)
        {
            try
            {
                ShowWaitingBar("Procesando sobre consumo...");
                await Task.Run(() => EjecutarProcesoSobreConsumo(sobreConsumoId));
            }
            finally
            {
                HideWaitingBar();
            }
        }

        private void EjecutarProcesoSobreConsumo(long sobreConsumoId)
        {
            try
            {
                SafeUpdateWaitingBar("Obteniendo datos de asignación...");
                var assignment = ObtenerDatosAsignacion(sobreConsumoId);

                if (assignment == null)
                {
                    ShowMessageBox($"No se encontraron datos para el Sobre Consumo ID: {sobreConsumoId}",
                        "Datos No Encontrados", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                SafeUpdateWaitingBar("Asignando mesa...");
                var (assignedTable, message) = service.AssignTable(assignment);

                if (assignedTable == 0)
                {
                    ShowMessageBox($"Error al asignar mesa: {message}",
                        "Error en Asignación", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }

                SafeUpdateWaitingBar("Actualizando tablas...");
                ActualizarMesaEnTablas(sobreConsumoId, assignedTable);

                SafeUpdateWaitingBar("Generando reporte...");
                GenerarReporte(sobreConsumoId);
                ShowMessageBox($"Mesa asignada exitosamente: {assignedTable}\n{message}",
                               "Proceso Completado",
                               MessageBoxButtons.OK,
                               RadMessageIcon.Info);
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error en el proceso: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               RadMessageIcon.Error);
            }
        }

        private AssignmentTracerIDs ObtenerDatosAsignacion(long traceId)
        {
            AssignmentTracerIDs assignment = null;

            string query = @"
        SELECT AT.Saca, AT.MillStyle, AT.Size, AT.Color, AT.WeekId, AT.Deviation, AT.MaterialDeviation, AT.Dozens, AT.Assortment 
        FROM dbo.pmc_AsignacionTraceIDs AT 
        INNER JOIN ES_SOCKS.dbo.pmc_Transactions T ON AT.TraceId = T.TraceIDBase 
        WHERE T.TraceId = @TraceId";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TraceId", traceId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        assignment = new AssignmentTracerIDs
                        {
                            traceId = traceId.ToString(),
                            saca = reader["Saca"] != DBNull.Value ? reader["Saca"].ToString() : null,
                            millStyle = reader["MillStyle"] != DBNull.Value ? reader["MillStyle"].ToString() : null,
                            size = reader["Size"] != DBNull.Value ? Convert.ToInt32(reader["Size"]) : (int?)null,
                            color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : null,
                            weekId = reader["WeekId"] != DBNull.Value ? reader["WeekId"].ToString() : null,
                            deviation = reader["Deviation"] != DBNull.Value ? reader["Deviation"].ToString() : null,
                            materialDeviation = reader["MaterialDeviation"] != DBNull.Value ? reader["MaterialDeviation"].ToString() : null,
                            dozens = reader["Dozens"] != DBNull.Value ? reader["Dozens"].ToString() : null,
                            assortment = reader["Assortment"] != DBNull.Value ? reader["Assortment"].ToString() : null
                        };
                    }
                }
            }

            return assignment;
        }

        private void ActualizarMesaEnTablas(long traceId, int mesa)
        {
            string updateQuery = @"
                -- Declarar variables
                DECLARE @Dozens NVARCHAR(50);
                DECLARE @Saca NVARCHAR(50);
                DECLARE @CantidadStickers INT = 0;

                -- Obtener docenas y saca desde pmc_Transactions
                SELECT 
                    @Dozens = Dozens,
                    @Saca = SACA
                FROM ES_SOCKS.dbo.pmc_Transactions 
                WHERE TraceID = @TraceId;

                -- Calcular cantidad de stickers si tenemos los datos
                IF @Dozens IS NOT NULL AND @Saca IS NOT NULL
                BEGIN
                    SELECT 
                        @CantidadStickers = ROUND(SUM(CAST(@Dozens AS FLOAT) / NULLIF(CAST(B.sub_factor AS FLOAT), 0)), 0)
                    FROM ES_SOCKS.dbo.pmc_Subida_BOM B WITH (NOLOCK)
                    INNER JOIN dbo.pmc_Stickers S WITH (NOLOCK)
                        ON LTRIM(RTRIM(S.Item)) COLLATE SQL_Latin1_General_CP1_CI_AS = 
                           LTRIM(RTRIM(B.sub_producto)) COLLATE SQL_Latin1_General_CP1_CI_AS
                    WHERE LTRIM(RTRIM(B.sub_SACA)) COLLATE SQL_Latin1_General_CP1_CI_AS = 
                          LTRIM(RTRIM(@Saca)) COLLATE SQL_Latin1_General_CP1_CI_AS;
                END

                -- Actualizar primera tabla
                UPDATE dbo.pmc_AsignacionTraceIDs 
                SET TableId = @Mesa, 
                    CantidadStickers = @CantidadStickers
                WHERE TraceId = @TraceId;

                -- Actualizar segunda tabla
                UPDATE ES_SOCKS.dbo.pmc_Transactions 
                SET TableNumber = @Mesa 
                WHERE TraceID = @TraceId;";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Mesa", mesa);
                cmd.Parameters.AddWithValue("@TraceId", traceId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void GenerarReporte(long sobreConsumoId)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<long>(GenerarReporte), sobreConsumoId);
                    return;
                }

                var report = new Reportes.ReportesDesign.BOMSC();
                report.ReportParameters["SobreConsumoID"].Value = sobreConsumoId;

                BOMReport.ReportSource = report;
                BOMReport.RefreshReport();

                ShowMessageBox($"Reporte generado para Sobre Consumo ID: {sobreConsumoId}",
                                   "Reporte Generado",
                                   MessageBoxButtons.OK,
                                   RadMessageIcon.Info);
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error al generar el reporte: {ex.Message}",
                                   "Error en Reporte",
                                   MessageBoxButtons.OK,
                                   RadMessageIcon.Exclamation);
            }
        }
        #endregion

        #region Proceso de Filtrados
        private async void btnProcesarFiltrado_Click(object sender, EventArgs e)
        {
            ProcesarFiltradoForm form = new ProcesarFiltradoForm();
            form.StartPosition = FormStartPosition.CenterScreen;

            form.ShowDialog();

            if (form.DatosValidos)
            {
                if (ValidarExistenciaSACA(form.Saca))
                {
                    await EjecutarProcesoFiltradoConEspera(form.Saca, form.Docenas, form.Carnet);
                }
                return;
            }

            form.Dispose();
        }

        private async Task EjecutarProcesoFiltradoConEspera(string saca, int docenas, string carnet)
        {
            try
            {
                ShowWaitingBar("Procesando filtrado...");

                await Task.Run(() => ExecSPFiltrado(saca, docenas, carnet));
            }
            finally
            {
                HideWaitingBar();
            }
        }

        private void ShowWaitingBar(string message = "Procesando...")
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowWaitingBar), message);
                return;
            }

            lblWaitingText.Text = message;

            lblTitulo.Visible = false;
            lblWaitingText.Visible = true;

            this.Enabled = false;
            Application.DoEvents();
        }

        private void HideWaitingBar()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(HideWaitingBar));
                return;
            }

            lblWaitingText.Visible = false;
            lblTitulo.Visible = true;

            this.Enabled = true;
            Application.DoEvents();
        }

        private void UpdateWaitingBarMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateWaitingBarMessage), message);
                return;
            }

            lblWaitingText.Text = message;
            Application.DoEvents();
        }

        private void ExecSPFiltrado(string saca, int docenas, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_CreateFiltradoTransaction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Saca", saca);
                        command.Parameters.AddWithValue("@Dozens", docenas);
                        command.Parameters.AddWithValue("@Badge", carnet);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long newTraceID = Convert.ToInt64(reader["TraceID"]);
                                string sacaRetornada = reader["SACA"].ToString();
                                int docenasRetornadas = Convert.ToInt32(reader["Dozens"]);
                                string message = reader["Message"].ToString();

                                // Actualizar mensaje de la barra de espera
                                SafeUpdateWaitingBar("Obteniendo datos para asignación...");

                                AssignmentTracerIDs assignment = ObtenerDatosParaAsignacion(newTraceID);

                                if (assignment != null)
                                {
                                    // Actualizar mensaje de la barra de espera
                                    SafeUpdateWaitingBar("Asignando mesa...");

                                    var (table, messageAsignacion) = service.AssignTable(assignment);

                                    if (table > 0)
                                    {
                                        // Actualizar mensaje de la barra de espera
                                        SafeUpdateWaitingBar("Actualizando transacción...");

                                        ActualizarMesaEnTransaccion(newTraceID, table);

                                        // Actualizar mensaje de la barra de espera
                                        SafeUpdateWaitingBar("Generando reporte...");

                                        // Usar Invoke para operaciones de UI
                                        if (InvokeRequired)
                                        {
                                            Invoke(new Action<long>(GenerarReporteBOMFD), newTraceID);
                                            Invoke(new Action<string, string, int, int, string>(MostrarMensajeExitoso),
                                                newTraceID.ToString(), sacaRetornada, docenasRetornadas, table, messageAsignacion);
                                        }
                                        else
                                        {
                                            GenerarReporteBOMFD(newTraceID);
                                            MostrarMensajeExitoso(newTraceID.ToString(), sacaRetornada, docenasRetornadas, table, messageAsignacion);
                                        }
                                    }
                                    else
                                    {
                                        ShowMessageBox($"El filtrado se procesó pero no se pudo asignar mesa:\n{messageAsignacion}\n\nTraceID: {newTraceID}",
                                            "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Error);
                                    }
                                }
                                else
                                {
                                    ShowMessageBox($"El filtrado se procesó pero no se pudieron obtener los datos para asignar mesa.\n\nTraceID: {newTraceID}",
                                        "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Error);
                                }
                            }
                            else
                            {
                                ShowMessageBox("El stored procedure no retornó resultados",
                                    "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (TimeoutException)
            {
                string message = "La operación está tomando más tiempo de lo normal. " +
                                       "Esto puede deberse a carga temporal del servidor o volumen alto de datos. " +
                                       "Por favor, espere unos minutos e intente nuevamente.";

                ShowMessageBox(message, "Tiempo de espera agotado", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
            catch (SqlException sqlEx)
            {
                ShowMessageBox($"Error de base de datos:\n{sqlEx.Message}",
                    "Error SQL", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessageBox($"Error al ejecutar stored procedure:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void MostrarMensajeExitoso(string traceID, string saca, int docenas, int mesa, string mensaje)
        {
            ShowMessageBox(
                $"Proceso completado exitosamente:\n\n" +
                $"FiltradoID: {traceID}\n" +
                $"Mesa Asignada: {mesa}\n" +
                $"SACA: {saca}\n" +
                $"Docenas: {docenas}\n" +
                $"Mensaje: {mensaje}",
                "Proceso Completado",
                MessageBoxButtons.OK,
                RadMessageIcon.Info
            );
        }

        private AssignmentTracerIDs ObtenerDatosParaAsignacion(long newTraceID)
        {
            AssignmentTracerIDs assignment = null;

            string query = @"
                SELECT 
                    T.TraceID,
                    T.saca,
                    PM.millstyle,
                    PM.size,
                    PM.color,
                    CT.WeekID,
                    NULL AS deviation,
                    NULL AS MaterialDeviation,
                    T.Dozens,
                    NULL AS assortment
                FROM ES_SOCKS.dbo.pmc_Transactions T
                INNER JOIN dbo.pmc_productmaster PM ON T.saca = PM.saca COLLATE SQL_Latin1_General_CP1_CI_AS
                OUTER APPLY (
                    SELECT TOP 1 WeekID
                    FROM CheckPointTrans 
                    WHERE saca = T.saca COLLATE SQL_Latin1_General_CP1_CI_AS
                      AND ChkID = 'FIN-KIT'
                    ORDER BY dt DESC
                ) CT
                WHERE T.TraceID = @NewTraceID;";

            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewTraceID", newTraceID);
                    // Aumentar el timeout a 5 minutos (300 segundos)
                    cmd.CommandTimeout = 300;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            assignment = new AssignmentTracerIDs
                            {
                                traceId = reader["TraceID"] != DBNull.Value ? reader["TraceID"].ToString() : null,
                                saca = reader["saca"] != DBNull.Value ? reader["saca"].ToString() : null,
                                millStyle = reader["millstyle"] != DBNull.Value ? reader["millstyle"].ToString() : null,
                                size = reader["size"] != DBNull.Value ? Convert.ToInt32(reader["size"]) : (int?)null,
                                color = reader["color"] != DBNull.Value ? reader["color"].ToString() : null,
                                weekId = reader["WeekID"] != DBNull.Value ? reader["WeekID"].ToString() : null,
                                deviation = reader["deviation"] != DBNull.Value ? reader["deviation"].ToString() : null,
                                materialDeviation = reader["MaterialDeviation"] != DBNull.Value ? reader["MaterialDeviation"].ToString() : null,
                                dozens = reader["Dozens"] != DBNull.Value ? reader["Dozens"].ToString() : null,
                                assortment = reader["assortment"] != DBNull.Value ? reader["assortment"].ToString() : null
                            };
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == -2)
                {
                    throw new TimeoutException("La consulta está tomando más tiempo de lo esperado. Por favor, intente nuevamente.", sqlEx);
                }
                throw;
            }

            return assignment;
        }

        private void ActualizarMesaEnTransaccion(long newTraceID, int mesa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE ES_SOCKS.dbo.pmc_Transactions SET TableNumber = @Mesa WHERE TraceID = @NewTraceID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Mesa", mesa);
                        command.Parameters.AddWithValue("@NewTraceID", newTraceID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Mesa {mesa} actualizada exitosamente para TraceID: {newTraceID}");
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró el TraceID {newTraceID} para actualizar la mesa");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar mesa en transacción: {ex.Message}");
            }
        }

        private void GenerarReporteBOMFD(long filtradoId)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<long>(GenerarReporteBOMFD), filtradoId);
                return;
            }

            try
            {
                var report = new Reportes.ReportesDesign.BOMFD();
                report.ReportParameters["FiltradoID"].Value = filtradoId;

                BOMReport.ReportSource = report;
                BOMReport.RefreshReport();
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"Error al generar reporte BOMFD:\n{ex.Message}",
                    "Error de Reporte",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
            }
        }

        #endregion

    }
}