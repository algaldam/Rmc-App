using Rmc.Clases;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Documents.Spreadsheet.Model.Protection;

namespace Rmc.Subidas
{
    public partial class SubBOMExcel : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sqlBom = "SELECT sub_SACA, sub_producto, sub_descripcion, sub_factor, sub_TypeMaterials FROM pmc_Subida_BOM";
        string sql;
        Timer timer;

        public SubBOMExcel()
        {
            InitializeComponent();
            if (BrowseBOM.DialogType == Telerik.WinControls.UI.BrowseEditorDialogType.OpenFileDialog)
            {
                OpenFileDialog dialog = (OpenFileDialog)BrowseBOM.Dialog;
                dialog.Filter = "XLSX|*.xlsx|XLS|*.xls";
            }

            //Lleno el Grid con los datos actuales
            sc.OpenConection();
            sc.LlenarGrid(this.GridBOM, sqlBom, "x", "x");
            sc.CloseConection();


            this.GridBOM.MasterTemplate.ShowTotals = true;
            GridViewSummaryItem summaryItem = new GridViewSummaryItem("bom_SACA", "{0} Registros", GridAggregateFunction.Count);

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);
            this.GridBOM.SummaryRowsBottom.Add(summaryRowItem);

            this.GridBOM.MasterView.SummaryRows[0].IsPinned = true;
            this.GridBOM.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;

            GridViewBottomPinnedRowsMode pinnerRow = new GridViewBottomPinnedRowsMode();
            pinnerRow = GridViewBottomPinnedRowsMode.Fixed;
            this.GridBOM.MasterTemplate.BottomPinnedRowsMode = pinnerRow;

            radWaitingBar1.AssociatedControl = this.radSpreadsheet1;
            radWaitingBar1.Size = new System.Drawing.Size(70, 70);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (this.radSpreadsheet1.SpreadsheetElement.Workbook.ActiveWorksheet.Name != "Sheet1")
            {
                this.timer.Stop();
                BrowseBOM.Value = "";
                return;
            }
            this.radWaitingBar1.StopWaiting();
            this.radWaitingBar1.ResetWaiting();

            try
            {
                byte[] bytes = File.ReadAllBytes(this.BrowseBOM.Value.ToString());
                this.radSpreadsheet1.SpreadsheetElement.Workbook = (WorkbookFormatProvidersManager.GetProviderByName("XlsxFormatProvider") as XlsxFormatProvider).Import(bytes);
                this.radSpreadsheet1.SpreadsheetElement.ActiveWorksheet.Protect("telerik", WorksheetProtectionOptions.Default);
                Telerik.WinForms.Controls.Spreadsheet.Worksheets.RadWorksheetEditor worksheetEditor = this.radSpreadsheet1.SpreadsheetElement.ActiveWorksheetEditor;
                worksheetEditor.FreezePanes(new Telerik.Windows.Documents.Spreadsheet.Model.CellIndex(1, 1));
            }
            catch
            {
                MessageBox.Show("No se puede acceder al archivo, verifique que no esté abierto por otro aplicativo", "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.radSpreadsheet1.SpreadsheetElement.Workbook.ActiveWorksheet.Name != "Sheet1")
            {
                this.timer.Stop();
                BrowseBOM.Value = "";
                return;
            }
        }

        private void BrowseBomValueChanged(object sender, EventArgs e)
        {
            if (this.BrowseBOM.Value != null)
            {
                Workbook wb = this.radSpreadsheet1.SpreadsheetElement.Workbook;
                this.timer = new Timer();
                this.timer.Interval = 8000;
                this.timer.Tick += TimerTick;


                try
                {
                    this.timer.Stop();
                    if (wb.Worksheets[0].Name != "Sheet1")
                    {
                        wb.Worksheets.Add();
                        wb.Worksheets[1].Name = "Sheet1";

                        wb.Worksheets.RemoveAt(0); // Removed Sheet0
                    }

                    if (this.radWaitingBar1.IsWaiting)
                    {
                        this.radWaitingBar1.StopWaiting();
                        this.radWaitingBar1.ResetWaiting();
                    }
                    this.radWaitingBar1.StartWaiting();
                    this.timer.Start();

                }
                catch
                {
                    MessageBox.Show("Error al abrir el documento, verifique que no esté abierto por otro aplicativo.", "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ProcesarBomClick(object sender, EventArgs e)
        {
            DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de sobrescribir el BOM?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacion1 != DialogResult.OK) return;

            DialogResult confirmacion2 = MessageBox.Show("¿Está totalmente seguro de sobrescribir el BOM?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacion2 != DialogResult.OK) return;

            try
            {
                // 🔹 Inicia la barra de espera
                radWaitingBar1.StartWaiting();
                radWaitingBar1.Visible = true;
                ProcesarBOM.Enabled = false;
                BrowseBOM.Enabled = false;

                // 🔹 Ejecuta todo el proceso en otro hilo (sin trabar el UI)
                await Task.Run(() =>
                {
                    //Truncado de datos del calendario
                    sql = "DELETE FROM pmc_Subida_BOM";
                    sc.OpenConection();
                    sc.EjecutarQuery(sql);
                    sc.CloseConection();

                    DataTable dtComplete = new DataTable("dataTable");
                    dtComplete.Reset();

                    Workbook wb = null;
                    Worksheet ws = null;

                    this.Invoke(new Action(() =>
                    {
                        wb = this.radSpreadsheet1.SpreadsheetElement.Workbook;
                        ws = wb.ActiveWorksheet;
                    }));

                    dtComplete.Columns.Add("sub_id", typeof(int));
                    dtComplete.Columns.Add("sub_SACA", typeof(string));
                    dtComplete.Columns.Add("sub_producto", typeof(string));
                    dtComplete.Columns.Add("sub_descripcion", typeof(string));
                    dtComplete.Columns.Add("sub_factor", typeof(string));
                    dtComplete.Columns.Add("sub_TypeMaterials", typeof(string));

                    for (int i = 1; i < ws.UsedCellRange.RowCount; i++)
                    {
                        DataRow dr = dtComplete.NewRow();
                        for (int j = 0; j < ws.UsedCellRange.ColumnCount; j++)
                        {
                            var cellValue = ws.Cells[i, j].GetValue().Value?.RawValue ?? "";
                            dr[j + 1] = cellValue.ToString().ToUpper();
                        }
                        dtComplete.Rows.Add(dr);
                    }
                    dtComplete.AcceptChanges();

                    sc.OpenConection();
                    sc.InsertSqlBulkCopy(dtComplete, "pmc_Subida_BOM");
                    sc.CloseConection();

                    sc.OpenConection();
                    sql = "EXEC usp_pmc_BOM " + sc.Usuario + ", 'U' ";
                    string result = sc.DevValorString(sql);
                    sc.CloseConection();

                    this.Invoke(new Action(() =>
                    {
                        if (result == "OK")
                        {
                            MessageBox.Show("BOM Actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GridBOM.DataSource = null;
                            sc.LlenarGrid(this.GridBOM, sqlBom, "x", "x");
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el BOM", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Limpieza de Excel
                        wb.Worksheets.Add();
                        wb.Worksheets[1].Name = "Sheet1";
                        wb.Worksheets.RemoveAt(0);
                        BrowseBOM.Text = "";
                    }));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante el proceso:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                radWaitingBar1.StopWaiting();
                radWaitingBar1.ResetWaiting();
                radWaitingBar1.Visible = false;
                ProcesarBOM.Enabled = true;
                BrowseBOM.Enabled = true;
            }
        }


        private void dotsRingWaitingBarIndicatorElement3_Click(object sender, EventArgs e)
        {

        }

        private void SubBOMExcel_Load(object sender, EventArgs e)
        {

        }
    }
}
