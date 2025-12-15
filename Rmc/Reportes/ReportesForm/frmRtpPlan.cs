using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.Reportes.ReportesForm
{
    public partial class frmRtpPlan : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        AniosTableAdapter anio = new AniosTableAdapter();
        SemanasTableAdapter semana1 = new SemanasTableAdapter();
     RptPlanPorSemanaTableAdapter TaSemana = new RptPlanPorSemanaTableAdapter();
        public frmRtpPlan()
        {
            InitializeComponent();
            BtnGenerar.RootElement.ToolTipText = "Presione F5";
            ((GridTableElement)this.GridViewPlan.TableElement).AlternatingRowColor = Color.Honeydew;
            ((GridTableElement)this.GridViewExportar.TableElement).AlternatingRowColor = Color.Honeydew;
            GridViewExportar.SendToBack();
        }
        #endregion

        #region EVENTOS

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.F5)
                {
                    BtnGenerar.PerformClick();


                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmRtpPlan_Load(object sender, EventArgs e)
        {

            try
            {
               
                anio.Fill(ds.Anios);
                cbxAnio.DataSource = ds.Tables["Anios"];
            }
            catch (Exception ex)
            {
                
                MessageBox.Show (ex.Message );
            }
           

        }

        private void cbxAnio_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                semana1.Fill(ds.Semanas, cbxAnio.Text.Trim());


                var semanas = (DataTable)ds.Tables["Semanas"];
                CbxSemana1.DataSource = semanas;
                foreach (var item in CbxSemana1.Items)
                {
                    if (CbxSemana2.Items.Count == CbxSemana1.Items.Count)
                    {
                        break;
                    }
                    else
                    {
                        CbxSemana2.Items.Add(item.Text);
                    }

                }
                CbxSemana2.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
             try
            {
               
                
                    if (CbxSemana1.Text.Trim() != "" && CbxSemana2.Text.Trim() != "")
                    {
                        TaSemana.Fill(ds.RptPlanPorSemana, CbxSemana1.Text.Trim(), CbxSemana2.Text.Trim());
                        var datos = (DataTable)ds.Tables["RptPlanPorSemana"];
                        GridViewPlan.DataSource = datos;
                    }
                 
                
               
                

            }
            catch (Exception ex)
            {
                
                MessageBox.Show (ex.Message );
            }
        
        }

        private void GridViewPlan_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {

                RadMenuItem ItemExportar = new RadMenuItem("Exportar a Excel");
                // ItemExportar.ForeColor = Color.Red;
                ItemExportar.Click += new EventHandler(ItemExportar_Click);

                e.ContextMenu.Items.Add(ItemExportar);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ItemExportar_Click(object sender, EventArgs e)
        {
            try
            {

                if (GridViewPlan.RowCount > 0)
                {
                    GridViewPlan.SelectAll();
                    if (CbxSemana1.Text.Trim() != "" && CbxSemana2.Text.Trim() != "")
                        {
                            TaSemana.Fill(ds.RptPlanPorSemana, CbxSemana1.Text.Trim(), CbxSemana2.Text.Trim());
                            var datos = (DataTable)ds.Tables["RptPlanPorSemana"];
                            GridViewExportar.DataSource = datos;
                        }

                  


                    for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                    {
                        GridViewExportar.Columns[i].BestFit();
                        // GridViewExportar.Columns[i].Width = 180;
                        GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                        GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                    }
                    GridViewExportar.Columns["pla_semana"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                    GridViewExportar.Columns["pla_FH_crea"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;
                    GridViewExportar.Columns["pla_FH_mod"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;
                  


                    Telerik.WinControls.Export.GridViewSpreadExport spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(GridViewExportar);
                    Telerik.WinControls.Export.SpreadExportRenderer exportRenderer = new Telerik.WinControls.Export.SpreadExportRenderer();
                    spreadExporter.FreezeHeaderRow = true;
                    spreadExporter.FileExportMode = Telerik.WinControls.Export.FileExportMode.CreateOrOverrideFile;
                    spreadExporter.ExportVisualSettings = true;
                    spreadExporter.HiddenColumnOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;


                    string directorio = System.IO.Path.GetTempPath() + "\\PMC";
                    try
                    {
                        Directory.Delete(directorio, true);
                    }
                    catch { }

                    if (!Directory.Exists(directorio))
                        Directory.CreateDirectory(directorio);
                    Random random = new Random();
                    int numero = random.Next(20, 1000);
                    string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "PMC\\" + Guid.NewGuid() + numero + ".xlsx");
                    spreadExporter.RunExport(tempFile, exportRenderer);
                    System.Diagnostics.Process.Start(tempFile);

                    //POP_ALERT.CaptionText = "Exito";
                    //POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                    //POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                    //POP_ALERT.ThemeName = "Windows8";
                    //POP_ALERT.ContentText = "Exportación Realizada...";
                    //POP_ALERT.Show();






                }
                else
                {
                    MessageBox.Show("No es posible Exportar");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       

        private void GridViewPlan_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Index == -1)
            {
                return;
            }
            else
            {
                try
                {
                    if (GridViewPlan.RowCount > 0)
                    {
                       
                        if (e.RowElement.RowInfo.Cells["pla_estado"].Value != null && Convert.ToInt32(e.RowElement.RowInfo.Cells["pla_estado"].Value) ==0)
                        {
                           
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.MistyRose;
                               
                            
                           
                        }
                        else
                        {
                            e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                            e.RowElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                            e.RowElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                        }


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        #endregion
    }
}
