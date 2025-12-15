using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Documents.Spreadsheet.Model.Protection;

namespace Rmc.Subidas
{
    public partial class Subida_de_Stickers : Telerik.WinControls.UI.RadForm
    {
        private string connectionString = Properties.Settings.Default.TracerConnectionString;
        string sqlQuery = "SELECT [Item] as Producto ,[Description] as Descripcion FROM [pmc_Stickers]";
        private Timer timer;
        private DataTable excelDataTable = null;

        public Subida_de_Stickers()
        {
            InitializeComponent();

            radWaitingBar1.Visible = false;
            radWaitingBar2.Visible = false;

            timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += TimerTick;

            radWaitingBar2.AssociatedControl = radSpreadsheet1;
            radWaitingBar2.Size = new System.Drawing.Size(70, 70);

            CargarDatosEnGrid();
        }

        private void CargarDatosEnGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        if (ValidarEstructura(dt))
                        {
                            GridStickers.DataSource = dt;
                            lblNumRegistrosOrden.Text = GridStickers.RowCount.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private bool ValidarEstructura(DataTable dt)
        {
            string[] columnasEsperadas = { "Producto", "Descripcion" };

            if (dt.Columns.Count != 2)
            {
                RadMessageBox.Show($"Cantidad de columnas incorrecta. Esperadas: 2, Encontradas: {dt.Columns.Count}",
                    "Error de Estructura", MessageBoxButtons.OK, RadMessageIcon.Error);
                return false;
            }

            foreach (DataColumn columna in dt.Columns)
            {
                if (!columnasEsperadas.Contains(columna.ColumnName))
                {
                    RadMessageBox.Show($"Columna no reconocida: {columna.ColumnName}",
                        "Error de Estructura", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            radWaitingBar2.StopWaiting();
            radWaitingBar2.ResetWaiting();

            try
            {
                if (string.IsNullOrEmpty(BrowseStickers.Text))
                {
                    timer.Stop();
                    return;
                }

                byte[] bytes = File.ReadAllBytes(BrowseStickers.Text);
                var provider = WorkbookFormatProvidersManager.GetProviderByName("XlsxFormatProvider") as XlsxFormatProvider;
                if (provider == null)
                    throw new InvalidOperationException("No se encontró el proveedor XlsxFormatProvider.");

                radSpreadsheet1.SpreadsheetElement.Workbook = provider.Import(bytes);
                radSpreadsheet1.SpreadsheetElement.ActiveWorksheet.Protect("telerik", WorksheetProtectionOptions.Default);
                Telerik.WinForms.Controls.Spreadsheet.Worksheets.RadWorksheetEditor worksheetEditor = radSpreadsheet1.SpreadsheetElement.ActiveWorksheetEditor;
                worksheetEditor.FreezePanes(new Telerik.Windows.Documents.Spreadsheet.Model.CellIndex(1, 1));
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"No se puede acceder al archivo: {ex.Message}", "Error de Archivo", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                timer.Stop();
            }
        }

        private async void CargaMaquinas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BrowseStickers.Text))
            {
                RadMessageBox.Show("Debe seleccionar un archivo.", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            if (excelDataTable == null || excelDataTable.Rows.Count == 0)
            {
                RadMessageBox.Show("No hay datos para procesar en el archivo seleccionado.", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            if (!ValidarEstructura(excelDataTable))
            {
                return;
            }

            int recordCount = excelDataTable.Rows.Count;

            DialogResult confirmacion1 = RadMessageBox.Show(
                this,
                $"¿Está seguro de procesar estos {recordCount} registros?",
                "Confirmación de Procesamiento",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question);

            if (confirmacion1 != DialogResult.Yes) return;

            DialogResult confirmacion2 = RadMessageBox.Show(
                this,
                "¿Está totalmente seguro? Se eliminarán todos los registros existentes.",
                "Confirmación Final",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Exclamation);

            if (confirmacion2 != DialogResult.Yes) return;

            try
            {
                radWaitingBar1.Visible = true;
                radWaitingBar1.BringToFront();
                radWaitingBar1.StartWaiting();
                CargaMaquinas.Enabled = false;
                BrowseStickers.Enabled = false;

                await Task.Run(() =>
                {
                    ProcesarArchivoExcel();
                });
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Error general: {ex.Message}", "Error de Procesamiento", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                radWaitingBar1.StopWaiting();
                radWaitingBar1.Visible = false;
                CargaMaquinas.Enabled = true;
                BrowseStickers.Enabled = true;
            }
        }

        private void ProcesarArchivoExcel()
        {
            try
            {
                if (!ValidarEstructura(excelDataTable))
                {
                    this.Invoke(new Action(() =>
                    {
                        RadMessageBox.Show("La estructura del archivo Excel no es válida.", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }));
                    return;
                }

                int filasEnExcel = excelDataTable.Rows.Count;
                Console.WriteLine($"Filas a procesar: {filasEnExcel}");

                if (!LimpiarTabla())
                {
                    this.Invoke(new Action(() =>
                    {
                        RadMessageBox.Show("Error al limpiar la tabla existente.", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }));
                    return;
                }

                int filasInsertadas = InsertarDatos(excelDataTable);
                int totalEnBD = ContarRegistrosEnBD();

                this.Invoke(new Action(() =>
                {
                    if (filasInsertadas > 0 && totalEnBD > 0)
                    {
                        RadMessageBox.Show($"¡ÉXITO! \n Se procesaron {filasEnExcel} registros. \nInsertados: {filasInsertadas}. \nVerificado: {totalEnBD} registros en el Servidor.",
                            "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);

                        CargarDatosEnGrid();
                        LimpiarInterfaz();
                    }
                    else
                    {
                        RadMessageBox.Show($"Problema: Se intentaron procesar {filasEnExcel} filas, pero hay {totalEnBD} registros en BD.",
                            "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    RadMessageBox.Show($"Error durante el procesamiento: {ex.Message}", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }));
            }
        }

        private bool LimpiarTabla()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM pmc_Stickers", conn))
                    {
                        int filasEliminadas = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Tabla limpiada. Filas eliminadas: {filasEliminadas}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al limpiar tabla: {ex.Message}");
                return false;
            }
        }

        private int InsertarDatos(DataTable dt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = "pmc_Stickers";

                        bulkCopy.ColumnMappings.Add("Producto", "Item");
                        bulkCopy.ColumnMappings.Add("Descripcion", "Description");

                        bulkCopy.WriteToServer(dt);
                    }
                }

                Console.WriteLine($"BulkCopy exitoso: {dt.Rows.Count} filas insertadas");
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en BulkCopy: {ex.Message}");
                return 0;
            }
        }

        private int ContarRegistrosEnBD()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM pmc_Stickers", conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al contar registros: {ex.Message}");
                return 0;
            }
        }

        private void LimpiarInterfaz()
        {
            this.Invoke(new Action(() =>
            {
                var newWorkbook = new Workbook();
                newWorkbook.Worksheets.Add();
                newWorkbook.Worksheets[0].Name = "Sheet1";
                this.radSpreadsheet1.SpreadsheetElement.Workbook = newWorkbook;

                BrowseStickers.Text = "";
                BrowseStickers.Value = null;
                excelDataTable = null;
            }));
        }

        private void BrowseStickers_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            f.Title = "Seleccione el archivo de excel";
            f.FileName = string.Empty;

            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BrowseStickers.Text = f.FileName;
                    BrowseStickers.Value = f.FileName;

                    excelDataTable = LeerDatosExcel(f.FileName);

                    if (excelDataTable != null && excelDataTable.Rows.Count > 0)
                    {
                        lblNumRegistrosOrden.Text = excelDataTable.Rows.Count.ToString() + " (en archivo)";

                        if (timer.Enabled)
                        {
                            timer.Stop();
                        }

                        radWaitingBar2.Visible = true;
                        radWaitingBar2.BringToFront();
                        radWaitingBar2.StartWaiting();

                        timer.Start();
                    }
                    else
                    {
                        RadMessageBox.Show("No se pudieron leer datos del archivo Excel.", "Advertencia", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private DataTable LeerDatosExcel(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();

                byte[] bytes = File.ReadAllBytes(filePath);
                Workbook workbook = (WorkbookFormatProvidersManager.GetProviderByName("XlsxFormatProvider") as XlsxFormatProvider).Import(bytes);
                Worksheet worksheet = workbook.ActiveWorksheet;

                dt.Columns.Add("Producto", typeof(string));
                dt.Columns.Add("Descripcion", typeof(string));

                int rowCount = worksheet.UsedCellRange.RowCount;
                int colCount = worksheet.UsedCellRange.ColumnCount;

                Console.WriteLine($"Leyendo Excel - Filas: {rowCount}, Columnas: {colCount}");

                int startRow = (rowCount > 1 && !string.IsNullOrEmpty(worksheet.Cells[0, 0].GetValue().Value?.RawValue?.ToString())) ? 1 : 0;

                for (int i = startRow; i < rowCount; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool filaConDatos = false;

                    for (int j = 0; j < colCount && j < dt.Columns.Count; j++)
                    {
                        var cellValue = worksheet.Cells[i, j].GetValue().Value?.RawValue ?? "";
                        string valor = cellValue.ToString().Trim();

                        if (!string.IsNullOrEmpty(valor))
                            filaConDatos = true;

                        dr[j] = valor;

                        if (i < startRow + 2)
                        {
                            Console.WriteLine($"Fila {i}, Col {j}: '{valor}'");
                        }
                    }

                    if (filaConDatos)
                        dt.Rows.Add(dr);
                }

                Console.WriteLine($"Total filas leídas del Excel: {dt.Rows.Count}");
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer Excel: {ex.Message}");
                return null;
            }
        }

        private void Subida_de_Stickers_Load(object sender, EventArgs e)
        {
        }
    }
}