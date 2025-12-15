
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
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI.Export;
using System.IO;
namespace Rmc.Consultas
{
    public partial class frmTransaccionEPC : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        AniosTableAdapter anio = new AniosTableAdapter();
        SemanasTableAdapter semana = new SemanasTableAdapter();
        TransaccionEPCTableAdapter TrDt = new TransaccionEPCTableAdapter();
        SolicitudesProductoTableAdapter SlprDt = new SolicitudesProductoTableAdapter();
        public frmTransaccionEPC()
        {
            InitializeComponent();
            BtnTransacion.RootElement.ToolTipText = "Exportar Transacciones";
            BtnPendiente.RootElement.ToolTipText = "Exportar Pendiente";
            ((GridTableElement)this.GridViewTransaccion.TableElement).AlternatingRowColor = Color.MintCream;
            ((GridTableElement)this.GridViewExportar.TableElement).AlternatingRowColor = Color.MintCream;
            // ((GridTableElement)this.GridViewDetalle.TableElement).AlternatingRowColor = Color.SkyBlue;
        }
        #endregion


        #region DATOS
        private void DetalleMvimiento()
        {
            try
            {
                if (GridViewTransaccion.RowCount > 1)
                {
                    object SACA = GridViewTransaccion.CurrentRow.Cells["SACA"].Value;
                    if (SACA != null)
                    {
                        DataTable datos = new DataTable();
                        SlprDt.Fill(ds.SolicitudesProducto, "", SACA.ToString(), CbxSemana.Text.Trim());
                         datos = (DataTable)ds.Tables["SolicitudesProducto"];

                        GridViewDetalle.DataSource = datos;
                    }

                }
                else {
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

        private void frmTransaccionEPC_Load(object sender, EventArgs e)
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

        private void CbxSemana_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                TrDt.Fill(ds.TransaccionEPC, CbxSemana.Text.Trim());
                GridViewTransaccion.DataSource = (DataTable)ds.Tables["TransaccionEPC"];
                DetalleMvimiento();

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

        private void GridViewTransaccion_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {

            try
            {
                if (GridViewTransaccion.RowCount > 1)
                {
                    if (e.RowElement.RowInfo.Cells["ESTADO"].Value != null)
                    {

                        // if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Trim() != "")
                        //{


                        if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("0"))
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
                        //}
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
                DetalleMvimiento();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTransacion_Click(object sender, EventArgs e)
        {
            try
            {

                TrDt.Fill(ds.TransaccionEPC, CbxSemana.Text.Trim());
                var datos = (DataTable)ds.Tables["TransaccionEPC"];
                var valores = (from xP in datos.AsEnumerable()
                               select new
                               {
                                   Semana = xP.Field<string>("SEMANA"),
                                   SACA = xP.Field<string>("SACA"),
                                   Producto = xP.Field<string>("PRODUCTO"),
                                   Cantidad = xP.Field<int>("CANTIDAD_PLAN"),
                                   Entregado = xP.Field<int>("ENTREGADO"),
                                   Sobrante = xP.Field<int>("SOBRANTE"),
                                   Pendiente = xP.Field<int>("PENDIENTE"),
                                   Sobreconsumo = xP.Field<int>("SOBRE_CONSUMO"),
                                   DOMINGO_DIURNO = xP.Field<int>("DOMINGO_DIURNO"),
                                   DOMINGO_NOCTURNO = xP.Field<int>("DOMINGO_NOCTURNO"),
                                   LUNES_DIURNO = xP.Field<int>("LUNES_DIURNO"),
                                   LUNES_NOCTURNO = xP.Field<int>("LUNES_NOCTURNO"),
                                   MARTES_DIURNO = xP.Field<int>("MARTES_DIURNO"),
                                   MARTES_NOCTURNO = xP.Field<int>("MARTES_NOCTURNO"),
                                   MIERCOLES_DIURNO = xP.Field<int>("MIERCOLES_DIURNO"),
                                   MIERCOLES_NOCTURNO = xP.Field<int>("MIERCOLES_NOCTURNO"),
                                   JUEVES_DIURNO = xP.Field<int>("JUEVES_DIURNO"),
                                   JUEVES_NOCTURNO = xP.Field<int>("JUEVES_NOCTURNO"),
                                   VIERNES_DIURNO = xP.Field<int>("VIERNES_DIURNO"),
                                   VIERNES_NOCTURNO = xP.Field<int>("VIERNES_NOCTURNO"),
                                   SABADO_DIURNO = xP.Field<int>("SABADO_DIURNO"),
                                   SABADO_NOCTURNO = xP.Field<int>("SABADO_NOCTURNO"),
                               }).ToList();
                GridViewExportar.DataSource = valores;


                for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                {
                    GridViewExportar.Columns[i].BestFit();
                   // GridViewExportar.Columns[i].Width = 180;
                    GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                    GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                }

                GridViewExportar.BestFitColumns();
               
                
                GridViewExportar.Columns["SEMANA"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;

                GridViewSpreadExport spreadExporter = new GridViewSpreadExport(GridViewExportar);
                SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
                spreadExporter.FreezeHeaderRow = true;
                spreadExporter.FileExportMode = Telerik.WinControls.Export.FileExportMode.CreateOrOverrideFile;
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPendiente_Click(object sender, EventArgs e)
        {
            try
            {

                TrDt.Fill(ds.TransaccionEPC, CbxSemana.Text.Trim());
                var datos = (DataTable)ds.Tables["TransaccionEPC"];
                var valores = (from xP in datos.AsEnumerable()
                               where xP.Field<int>("PENDIENTE")>0 && xP.Field<int>("ESTADO")==1
                               select new
                               {
                                   Semana = xP.Field<string>("SEMANA"),
                                   SACA = xP.Field<string>("SACA"),
                                   Producto = xP.Field<string>("PRODUCTO"),
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

      

        private void GridViewTransaccion_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        #endregion
    }
}
