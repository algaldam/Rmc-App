

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

using System.IO;

namespace Rmc.Consultas
{
    public partial class frmTransacciones : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        AniosTableAdapter anio = new AniosTableAdapter();
        SemanasTableAdapter semana = new SemanasTableAdapter();
        TransaccionTableAdapter TrDt = new TransaccionTableAdapter();
        SolicitudesProductoTableAdapter SlprDt = new SolicitudesProductoTableAdapter();
        PendientesTableAdapter pd = new PendientesTableAdapter();
        PendienteOrdenTableAdapter pdo = new PendienteOrdenTableAdapter();
        public frmTransacciones()
        {
            InitializeComponent();
            BtnTransaccion.RootElement.ToolTipText = "Exportar Transacciones";
            BtnPendiente.RootElement.ToolTipText = "Exportar Pendiente";
            BtnPendienteFL.RootElement.ToolTipText = "Exportar Pendientes por Silueta";
            BtnPendienteFull.RootElement.ToolTipText = "Exportar Pendiente Full";
            ((GridTableElement)this.GridViewTransaccion.TableElement).AlternatingRowColor = Color.AliceBlue;
            ((GridTableElement)this.GridViewExportar.TableElement).AlternatingRowColor = Color.AliceBlue;
        }

        #endregion

        #region DATOS   
        private void DetalleMovimiento()
        {
            try
            {
                if (GridViewTransaccion.RowCount > 1)
                {

                    object ITEM = GridViewTransaccion.CurrentRow.Cells["pla_item"].Value;
                    if (ITEM != null)
                    {
                        DataTable datos = new DataTable();
                        SlprDt.Fill(ds.SolicitudesProducto, ITEM.ToString(), "", CbxSemana.Text.Trim());
                        datos = (DataTable)ds.Tables["SolicitudesProducto"];

                        GridViewDetalle.DataSource = datos;
                    }


                }
                else
                {
                    DataTable datos = new DataTable();
                    SlprDt.Fill(ds.SolicitudesProducto, "", "", CbxSemana.Text.Trim());
                    datos = (DataTable)ds.Tables["SolicitudesProducto"];

                    GridViewDetalle.DataSource = datos;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region EVENTOS

        private void frmTransacciones_Load(object sender, EventArgs e)
        {
            try
            {
                GridViewExportar.SendToBack();
                anio.Fill(ds.Anios);
                cbxAnio.DataSource = ds.Tables["Anios"];


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cbxAnio_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            try
            {
                semana.Fill(ds.Semanas, cbxAnio.Text.Trim());
                CbxSemana.DataSource = (DataTable)ds.Tables["Semanas"];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CbxSemana_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                TrDt.Fill(ds.Transaccion, CbxSemana.Text.Trim());
                GridViewTransaccion.DataSource = (DataTable)ds.Tables["Transaccion"];

                DetalleMovimiento();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewTransaccion_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try
            {
                if (GridViewDetalle.RowCount > 0)
                {



                    if (e.CellElement.ColumnInfo.HeaderText == "Desviación")
                    {
                        if (e.CellElement.RowInfo.Cells["DESVIACION"].Value != null && e.CellElement.RowInfo.Cells["DESVIACION"].Value.ToString().Trim() != "")
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

        private void GridViewDetalle_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            try
            {
                if (GridViewDetalle.RowCount > 0)
                {



                    if (e.CellElement.ColumnInfo.HeaderText == "Desviación")
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
        
        private void GridViewTransaccion_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                DetalleMovimiento();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       
        private void BtnTransaccion_Click(object sender, EventArgs e)
        {

        }

        private void BtnPendiente_Click(object sender, EventArgs e)
        {
            try
            {
                 
                   TrDt.Fill(ds.Transaccion, CbxSemana.Text.Trim());
                var datos =(DataTable)ds.Tables["Transaccion"];
                var valores = (from xP in  datos.AsEnumerable ()
                               where xP.Field<int>("PENDIENTE")>0
                               select new {

                                   Semana = xP.Field<string>("SEMANA"),
                                   Producto = xP.Field<string>("pla_item"),
                                   Desviacion = xP.Field<string>("DESVIACION"),
                                   Pendiente = xP.Field<int>("PENDIENTE")
                               }).ToList();
               GridViewExportar.DataSource = valores;


               for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                {
                    GridViewExportar.Columns[i].BestFit();
                   // GridViewExportar.Columns[i].Width = 180;
                    GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                    GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                }
               GridViewExportar.Columns["SEMANA"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                



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
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPendienteFull_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable DtCompeto = new DataTable();
                foreach (var item in CbxSemana.Items)
                {
                    TrDt.Fill(ds.Transaccion, item.Text.Trim());
                    var datos = (DataTable)ds.Tables["Transaccion"];
                    DtCompeto.Merge(datos);
                  
                    
                }
              
                var valores = (from xP in DtCompeto.AsEnumerable()
                               where xP.Field<int>("PENDIENTE") > 0
                                   select new
                                   {
                                      Semana  = xP.Field<string>("SEMANA"),
                                       Producto = xP.Field<string>("pla_item"),
                                      Desviacion = xP.Field<string>("DESVIACION"), 
                                       Pendiente = xP.Field<int>("PENDIENTE")
                                    
                                   }).ToList();

                GridViewExportar.DataSource = valores;
                for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                {
                    GridViewExportar.Columns[i].BestFit();
                   // GridViewExportar.Columns[i].Width = 180;
                    GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                    GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                }
                GridViewExportar.Columns["SEMANA"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                TrDt.Fill(ds.Transaccion, CbxSemana.Text.Trim());
                GridViewTransaccion.DataSource = (DataTable)ds.Tables["Transaccion"];


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
                
               
            }
            catch (Exception ex )
            {
                
                MessageBox.Show (ex.Message );
            }
        }

  

        private void BtnPendienteFL_Click(object sender, EventArgs e)
        {
            try
            {

                //pd.Fill(ds.Pendientes, CbxSemana.Text.Trim());
                //var datos = (DataTable)ds.Tables["Pendientes"];
                //var valores = (from xP in datos.AsEnumerable()
                //               where xP.Field<int>("PENDIENTE") > 0
                //               select new
                //               {

                //                   Semana = xP.Field<string>("SEMANA"),
                //                   Producto = xP.Field<string>("pla_item"),
                //                   Desviacion = xP.Field<string>("DESVIACION"),                                 
                //                   Silueta = xP.Field<string>("SILUETA"),
                //                   Pendiente = xP.Field<int>("PENDIENTE")
                //               }).ToList();

                pdo.Fill(ds.PendienteOrden, CbxSemana.Text.Trim());
                var datos = (DataTable)ds.Tables["PendienteOrden"];
                var valores = (from xP in datos.AsEnumerable()
                               where xP.Field<int>("PENDIENTE") > 0
                               select new
                               {

                                   Semana = xP.Field<string>("SEMANA"),
                                   Producto = xP.Field<string>("PRODUCTO"),
                                   Desviacion = xP.Field<string>("DESVIACION"),
                                   Pendiente = xP.Field<int>("PENDIENTE")
                               }).ToList();
                GridViewExportar.DataSource = valores;


                for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                {
                    GridViewExportar.Columns[i].BestFit();
                    // GridViewExportar.Columns[i].Width = 180;
                    GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                    GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                }
                GridViewExportar.Columns["SEMANA"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;




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

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
