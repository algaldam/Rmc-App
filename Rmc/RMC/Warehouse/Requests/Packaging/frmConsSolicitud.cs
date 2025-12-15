using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
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
using System.Diagnostics;
using System.IO;
using Telerik.WinControls.UI.Export;


namespace Rmc.Consultas
{
    public partial class frmConsSolicitud : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        SystemClass sc = new SystemClass();
        Pmc_SolicitudesTableAdapter PmTa = new Pmc_SolicitudesTableAdapter();
        ConsultasTableAdapter sdt = new ConsultasTableAdapter();
        DataTable data = new DataTable();
        pmc_SemanasTableAdapter dtsem = new pmc_SemanasTableAdapter();
        public frmConsSolicitud()
        {
            InitializeComponent();
            BtnBuscar.RootElement.ToolTipText = "Presione F1";
            BtnGuardar.RootElement.ToolTipText = "Presione F4";
            BtnEliminar.RootElement.ToolTipText = "Presione End";
            btnExcel.RootElement.ToolTipText = "Presione Ctrl+E";
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
                summaryItemTO.Name = "sol_ID";

                summaryItemIT.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Count;
                summaryItemIT.AggregateExpression = null;
                summaryItemIT.FormatString = " {0}";
                summaryItemIT.Name = "sol_item";

                summaryItemCA.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
                summaryItemCA.AggregateExpression = null;
                summaryItemCA.FormatString = "{0}";
                summaryItemCA.Name = "sol_cant";


                summaryItemDev.Name = "sol_item_desv";
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


                PmTa.Fill(ds.Pmc_Solicitudes, CbxSemana.Text.Trim());
                // data.Reset();
                data = (DataTable)ds.Tables["pmc_Solicitudes"];
                bs.DataSource = data;
                // radBindingNavigator1.BindingSource = bs;
                GridViewListado.DataSource = bs;
                if (GridViewListado.RowCount > 0)
                {
                    ckbSalida.Enabled = true;
                    BtnEliminar.Enabled = true;
                    BtnGuardar.Enabled = true;
                    btnExcel.Enabled = true; 
                }
                else
                {
                    BtnEliminar.Enabled = false;
                    ckbSalida.Enabled = false;
                  
                    BtnGuardar.Enabled = false;
                    btnExcel.Enabled = false; 
                }
               
                Suma();
                Unbinding();
                Binding();

                //  ID= Convert.ToInt32 (TxtID.Text) ;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Guardar()
        {
            try
            {

                if (GridViewListado.RowCount > 0)
                {

               
                if (TxtCantidadEn.Text.Trim() != "0" && Convert.ToInt32(TxtCantidadEn.Text.Replace(',', ' ')) > 0)
                {
                    int fila = GridViewListado.Rows.IndexOf(this.GridViewListado.CurrentRow);
                    using (dcPmcDataContext db = new dcPmcDataContext())
                    {



                        var Actualizar = db.pmc_Solicitudes.Where(id => id.sol_ID == Convert.ToInt32(lb_ID.Text.Trim())).FirstOrDefault();
                        if (Actualizar.sol_cant_entregada != null)
                        {
                            if (Actualizar.sol_cant_entregada > 0)
                            {
                                Actualizar.sol_cant_entregada = Convert.ToInt32(TxtCantidadEn.Text);
                                Actualizar.sol_usuario_modifica = Environment.UserName;
                                Actualizar.sol_FH_modifica = DateTime.Now;
                               // Actualizar.sol_salida = ckbSalida.IsChecked;
                                db.SubmitChanges();
                            }
                            else
                            {
                                Actualizar.sol_cant_entregada = Convert.ToInt32(TxtCantidadEn.Text);
                                Actualizar.sol_usuario_entrega = Environment.UserName;
                                Actualizar.sol_FH_entrega = DateTime.Now;
                               // Actualizar.sol_salida = ckbSalida.IsChecked;
                                db.SubmitChanges();
                            }


                        }

                        POP_ALERT.CaptionText = "Exito";
                        POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                        POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                        POP_ALERT.ThemeName = "Windows8";
                        POP_ALERT.ContentText = "Actualización correcta...";
                        POP_ALERT.Show();
                        llenarTabla();
                        GridViewListado.Rows[fila].IsSelected = true;
                        GridViewListado.Rows[fila].IsCurrent = true;
                    }

                }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region BINDEO

        private void Binding()
        {
            try
            {



                lb_ID.DataBindings.Add("Text", bs, "sol_ID", false, DataSourceUpdateMode.Never);
                lbSemana.DataBindings.Add("Text", bs, "sol_semana", false, DataSourceUpdateMode.Never);
                lbtItem.DataBindings.Add("Text", bs, "sol_item", false, DataSourceUpdateMode.Never);
                lbCantidadSol.DataBindings.Add("Text", bs, "sol_cant", false, DataSourceUpdateMode.Never);
                lbUsuarioCrea.DataBindings.Add("Text", bs, "USUARIO_CREA", false, DataSourceUpdateMode.Never);
                ChkDesviacion.DataBindings.Add("IsChecked", bs, "sol_desv", false, DataSourceUpdateMode.Never);
                lbFHC.DataBindings.Add("Text", bs, "sol_FH_crea", false, DataSourceUpdateMode.Never);
                lbUsuarioEn.DataBindings.Add("Text", bs, "USUARIO_ENTREGA", false, DataSourceUpdateMode.Never);
                lbFechaEn.DataBindings.Add("Text", bs, "sol_FH_entrega", false, DataSourceUpdateMode.Never);
                ckbSalida.DataBindings.Add("IsChecked", bs, "sol_salida", false, DataSourceUpdateMode.Never);
                TxtCantidadEn.DataBindings.Add("Text", bs, "sol_cant_entregada", false, DataSourceUpdateMode.Never);
                
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
                ChkDesviacion.DataBindings.Clear();
                lbUsuarioEn.DataBindings.Clear();
                lbUsuarioCrea.DataBindings.Clear();
                lbFHC.DataBindings.Clear();
                lbFechaEn.DataBindings.Clear();
                TxtCantidadEn.DataBindings.Clear();
                ckbSalida.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region EVENTOS



        private void frmConsSolicitud_Load(object sender, EventArgs e)
        {
            try
            {

                //dtsem.Fill(ds.pmc_Semanas);
                //var datos = (DataTable)ds.Tables["pmc_Semanas"];
                // var semanas =(from x in datos.AsEnumerable ()
                //                   where x.Field<>)
                using (dcPmcDataContext db = new dcPmcDataContext ())
                {
                    var semanas = (from x in db.pmc_Semanas
                                   where x.sem_estado == true
                                   orderby x.sem_ID descending
                                   select x).ToList();
                    CbxSemana.DataSource = semanas;
                }

              
                GridViewExportar.SendToBack();
                lb_ID.SendToBack();
                BtnEliminar.Enabled = false;
                BtnGuardar.Enabled = false;
                ckbSalida.Enabled = false;
                btnExcel.Enabled = false;
                //llenarTabla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewListado_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
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

        private void GridViewListado_DoubleClick(object sender, EventArgs e)
        {
         
            GridViewListado.SelectAll();
           

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                llenarTabla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtCantidadEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar == (char)13)
                    {
                        Guardar();
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿ Realmente desea Eliminar Solicitud?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (dcPmcDataContext dbe = new dcPmcDataContext())
                    {
                        dbe.usp_pmc_Solicitudes_CRUD(Convert.ToInt32(lb_ID.Text.Trim()),null, "", "", null, 1, false,false,"", 'D');
                        MessageBox.Show("Solicitiud Eliminada");
                        llenarTabla();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.End)
                {
                    BtnGuardar.Focus();
                    BtnEliminar.PerformClick();

                }
                else if (keyData == Keys.F4)
                {
                    BtnGuardar.PerformClick();
                }
                else if (keyData == Keys.F1)
                {
                    BtnBuscar.PerformClick();
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

        private void GridViewListado_Click(object sender, EventArgs e)
        {

        }
   
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewListado.RowCount >0)
                {
                    //EXPORTAR A EXCEL CON FORMATO DE TABLA
                   

                        PmTa.Fill(ds.Pmc_Solicitudes, CbxSemana.Text.Trim());
                        // data.Reset();
                        var datos = (DataTable)ds.Tables["pmc_Solicitudes"];

                        
                        var valores = (from xP in datos.AsEnumerable()
                                       select new
                                       {

                                          Solicitud = xP.Field<int>("sol_ID"),
                                           SACA = xP.Field<string>("sol_SACA"),
                                           Producto = xP.Field<string>("sol_item"),
                                           Desviacion = xP.Field<string>("sol_item_desv"),
                                           Solicitado = xP.Field<int>("sol_cant"),
                                           Entregado = xP.Field<int>("sol_cant_entregada")
                                         
                                       }).ToList();
                        GridViewExportar.DataSource = valores;
                        for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                        {
                            GridViewExportar.Columns[i].BestFit();
                            GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                            GridViewExportar.Columns[i].ExcelExportType = DisplayFormatType.None;
                        }
                        Telerik.WinControls.Export.GridViewSpreadExport spreadExporter = new Telerik.WinControls.Export.GridViewSpreadExport(this.GridViewExportar);
                        Telerik.WinControls.Export.SpreadExportRenderer exportRenderer = new Telerik.WinControls.Export.SpreadExportRenderer();
                        spreadExporter.HiddenColumnOption = HiddenOption.DoNotExport;
                        spreadExporter.ExportVisualSettings = true;

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
       
        private void GridViewListado_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Index == -1)
            {
                return;
            }
            else
            {
                try
                {
                    if (GridViewListado.RowCount > 0)
                    {
                        if (e.RowElement.RowInfo.Cells["sol_salida"].Value != null)
                        {

                            //if (e.RowElement.RowInfo.Cells["sol_salida"].Value.Equals(true))
                            //{
                            //    e.RowElement.DrawFill = true;
                            //    e.RowElement.GradientStyle = GradientStyles.Solid;
                            //    e.RowElement.BackColor = Color.Wheat;
                            //}

                            //else
                            //{
                            //    e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            //    e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                            //    e.RowElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                            //    e.RowElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            //}
                        } 
                        if (e.RowElement.RowInfo.Cells["sol_cant_entregada"].Value != null && e.RowElement.RowInfo.Cells["sol_cant"].Value != null)
                        {
                            if (Convert.ToInt32 (e.RowElement.RowInfo.Cells["sol_cant_entregada"].Value) < Convert.ToInt32 (e.RowElement.RowInfo.Cells["sol_cant"].Value))
                            {
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.Wheat;
                                e.RowElement.ToolTipText = "La Cantidad Entregada es inferior a la Cantidad Solicitada";
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
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }
     
        private void GridViewListado_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            try
            {
                if (GridViewListado.RowCount > 0)
                {



                    if (e.CellElement.ColumnInfo.Name  == "sol_item_desv")
                    {


                        if (e.CellElement.RowInfo.Cells["sol_item_desv"].Value != null && e.CellElement.RowInfo.Cells["sol_item_desv"].Value.ToString().Trim() != "")
                        {

                            e.CellElement.DrawFill = true;

                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.DarkSeaGreen;

                        }
                        else
                        {
                            e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        }


                    }
                  
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
