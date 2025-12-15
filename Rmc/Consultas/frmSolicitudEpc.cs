
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;
using System.IO;
using System.Diagnostics;
using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
using Telerik.WinControls.UI.Export;

namespace Rmc.Consultas
{
    public partial class frmSolicitudEpc : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        SystemClass sc = new SystemClass();
        ListadoSolicitudTableAdapter LsTa = new ListadoSolicitudTableAdapter();
        ConsultasTableAdapter sdt = new ConsultasTableAdapter();
        DataTable data = new DataTable();
        public frmSolicitudEpc()
        {
            InitializeComponent();

            btnRecargar.RootElement.ToolTipText = "Presione F5";
            btnExcel.RootElement.ToolTipText = "Presione Ctrl+E";
            ((GridTableElement)this.GridViewListado.TableElement).AlternatingRowColor = Color.Lavender ;
            ((GridTableElement)this.GridViewExportar.TableElement).AlternatingRowColor = Color.Lavender;
        }
        #endregion


        #region DATOS

        private void Suma()
        {
            try
            {

                // Se crean los totales de las columnas Items, Cantidad pedida , devoluciones y Cantidad de entregados

                this.GridViewListado.MasterTemplate.SummaryRowsTop.Clear();
                GridViewSummaryItem summaryItemTO = new GridViewSummaryItem();
                GridViewSummaryItem summaryItemIT = new GridViewSummaryItem();
                GridViewSummaryItem summaryItemCA = new GridViewSummaryItem();
                GridViewSummaryItem summaryItemDev = new GridViewSummaryItem();
                GridViewSummaryItem summaryItemCEN = new GridViewSummaryItem();

                summaryItemTO.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Var;
                summaryItemTO.AggregateExpression = null;
                summaryItemTO.FormatString = "Totales";
                summaryItemTO.Name = "sol_semana";

                summaryItemIT.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Count;
                summaryItemIT.AggregateExpression = null;
                summaryItemIT.FormatString = " {0}";
                summaryItemIT.Name = "sol_SACA";

                summaryItemCA.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
                summaryItemCA.AggregateExpression = null;
                summaryItemCA.FormatString = "{0}";
                summaryItemCA.Name = "sol_cant";


                summaryItemDev.Name = "sol_desv";
                summaryItemDev.AggregateExpression = "Sum(DESVIADO)";
                summaryItemDev.FormatString = "{0}";


                summaryItemCEN.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
                summaryItemCEN.AggregateExpression = null;
                summaryItemCEN.FormatString = "{0}";
                summaryItemCEN.Name = "sol_cant_entregada";

                this.GridViewListado.MasterTemplate.SummaryRowsTop.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                summaryItemIT,
                summaryItemTO,
                summaryItemCA,
                summaryItemDev,
                summaryItemCEN
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llenarTabla()
        {
            try
            {


                LsTa.Fill(ds.ListadoSolicitud);
                // data.Reset();
                data = (DataTable)ds.Tables["ListadoSolicitud"];
               
                var datos =  (from x  in data.AsEnumerable()
                              where x.Field<int>("sol_cant_entregada") <= 0 && x.Field<string>("sol_SACA") != null && x.Field<string>("sol_SACA").StartsWith("E") 
                                  select x);
                if (datos.ToList().Count > 0)
                {
                    
                    bs.DataSource = (DataTable)datos.CopyToDataTable ();
                    // radBindingNavigator1.BindingSource = bs;
                    GridViewListado.DataSource = bs;

                    Suma();
                    Unbinding();
                    Binding();

                }
                else
                {
                    Unbinding();
                    //Binding();
                    GridViewListado.DataSource = datos;
                }
               
                //  ID= Convert.ToInt32 (TxtID.Text) ;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion


        #region BINDEO

        private void limpiar()
        {
            try
            {
                  lb_ID.Text ="";
                lbSemana.Text ="";
                lbCantidadSol.Text ="";
                lbtItem.Text ="";
                LbSACA.Text ="";
                lbUsuarioEn.Text ="";
                lbUsuarioCrea.Text ="";
                lbFHC.Text ="";
               
            }
            catch (Exception ex)
            {
                
                MessageBox.Show (ex.Message );
            }
        }
        private void Binding()
        {
            try
            {



                lb_ID.DataBindings.Add("Text", bs, "sol_ID", false, DataSourceUpdateMode.Never);
                lbSemana.DataBindings.Add("Text", bs, "sol_semana", false, DataSourceUpdateMode.Never);
                lbtItem.DataBindings.Add("Text", bs, "sol_item", false, DataSourceUpdateMode.Never);
                lbCantidadSol.DataBindings.Add("Text", bs, "sol_cant", false, DataSourceUpdateMode.Never);
                lbUsuarioCrea.DataBindings.Add("Text", bs, "USUARIO_CREA", false, DataSourceUpdateMode.Never);
                LbSACA.DataBindings.Add("Text", bs, "sol_SACA", false, DataSourceUpdateMode.Never);
                lbFHC.DataBindings.Add("Text", bs, "sol_FH_crea", false, DataSourceUpdateMode.Never);
                lbUsuarioEn.DataBindings.Add("Text", bs, "USUARIO_ENTREGA", false, DataSourceUpdateMode.Never);
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Unbinding()
        {
            try
            {

                lb_ID.DataBindings.Clear();
                lbSemana.DataBindings.Clear();
                lbCantidadSol.DataBindings.Clear();
                lbtItem.DataBindings.Clear();
                LbSACA.DataBindings.Clear();
                lbUsuarioEn.DataBindings.Clear();
                lbUsuarioCrea.DataBindings.Clear();
                lbFHC.DataBindings.Clear();
             
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region EVENTOS

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.F5)
                {
                    btnRecargar.PerformClick();


                }
                else if (keyData == (Keys.Control | Keys.E))
                {
                    btnExcel.PerformClick();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmSolicitudEpc_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    GridViewExportar.SendToBack();
            //    llenarTabla();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void GridViewListado_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {





                if (e.CellElement is GridSummaryCellElement)
                {


                    //e.CellElement.DrawBorder = true;
                    //e.CellElement.BorderBoxStyle = BorderBoxStyle.FourBorders; 

                    e.CellElement.BorderTopWidth = 1;
                    // e.CellElement.BorderTopColor = Color.Blue;
                    e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                    e.CellElement.BackColor = Color.White;
                    e.CellElement.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
                    // e.CellElement.ForeColor = Color.SaddleBrown;
                    e.CellElement.BackColor = Color.LightGray;
                }

                if (e.CellElement is GridHeaderCellElement)
                {
                    e.CellElement.Font = new Font("Segoe UI", 11.0f, FontStyle.Bold);
                    // e.CellElement.ForeColor = Color.Green;
                    // e.CellElement.BackColor = Color.Black;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewListado.RowCount > 0)
                {
                    //EXPORTAR A EXCEL CON FORMATO DE TABLA
                   
                    LsTa.Fill(ds.ListadoSolicitud);
                        data = (DataTable)ds.Tables["ListadoSolicitud"];

                        var datos = (from x in data.AsEnumerable()
                                     where x.Field<int>("sol_cant_entregada") <= 0 && x.Field<string>("sol_SACA") != null && x.Field<string>("sol_SACA").StartsWith("E") 
                                     select x);
                        var valores = (from xP in datos.AsEnumerable()
                                       select new
                                       {


                                           Solicitud = xP.Field<int>("sol_ID"),
                                           Semana = xP.Field<string>("sol_semana"),
                                         SACA = xP.Field<string>("sol_SACA"),
                                           Producto = xP.Field<string>("sol_item"),
                                           //Desviacion = xP.Field<string>("sol_item_desv"),
                                           Solicitado= xP.Field<int>("sol_cant"),
                                          // Entregado = xP.Field<int>("sol_cant_entregada")
                                       }).ToList();
                        GridViewExportar.DataSource = valores;
                        for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                        {
                            GridViewExportar.Columns[i].BestFit();
                            GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                            GridViewExportar.Columns[i].ExcelExportType = DisplayFormatType.None;
                        }
                    GridViewExportar.Columns["Semana"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                    Telerik.WinControls.Export.GridViewSpreadExport spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(this.GridViewExportar);
                        Telerik.WinControls.Export.SpreadExportRenderer exportRenderer = new Telerik.WinControls.Export.SpreadExportRenderer();
                        spreadExporter.ExportVisualSettings = true;
                        
                spreadExporter.HiddenColumnOption = HiddenOption.DoNotExport;


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
                        POP_ALERT.CaptionText = "Exito";
                        POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                        POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                        POP_ALERT.ThemeName = "Windows8";
                        POP_ALERT.ContentText = "Exportación Realizada...";
                        POP_ALERT.Show();



                    

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

        private void GridViewListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridViewListado.SelectAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
      

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                llenarTabla();
                POP_ALERT.CaptionText = "Exito";
                POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                POP_ALERT.ThemeName = "Windows8";
                POP_ALERT.ContentText = "Listado Actualizado";
                POP_ALERT.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        

        private void FrmSolicitudEpc_Enter(object sender, EventArgs e)
        {
            try
            {
                GridViewExportar.SendToBack();
                llenarTabla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
