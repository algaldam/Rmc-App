using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI.Export;
using System.IO;

namespace Rmc.Consultas
{
    public partial class frmMovInventario : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        dsPMC ds = new dsPMC();
        AniosTableAdapter anio = new AniosTableAdapter();
        SemanasTableAdapter semana = new SemanasTableAdapter();
       List<string> Isemanas = new List<string>();
        MovimientosTableAdapter TA_MOV = new MovimientosTableAdapter();
        DetalleMovimientoTableAdapter DTA_MOV = new DetalleMovimientoTableAdapter();
        MovGeneralTableAdapter TA_MGEN = new MovGeneralTableAdapter();
        bool FlagInicio = false;
        bool flagDetalle = false;
        public frmMovInventario()
        {
            InitializeComponent();

            BtnConsolidado.RootElement.ToolTipText = "Exportar Consolidado de Movimientos";
            BtnDetalle.RootElement.ToolTipText = "Exportar Detalle de Movimientos";
            BtnRefrescar.RootElement.ToolTipText = "Refrescar Registros";
            ((GridTableElement)this.VIEW_MOVIMIENTO.TableElement).AlternatingRowColor = Color.Azure;
            ((GridTableElement)this.GridViewExportar.TableElement).AlternatingRowColor = Color.Azure;
            ;
        }



        #endregion


        #region DATOS
        private void DetalleMvimiento()
        {
            try
            {
                if (VIEW_MOVIMIENTO.RowCount > 1)
                {
                    object PRODUCTO = VIEW_MOVIMIENTO.CurrentRow.Cells["PRODUCTO"].Value;
                    if (PRODUCTO != null) { 
                        DataTable datos = new DataTable();
                        DTA_MOV.Fill (ds.DetalleMovimiento, CbxSemanaMov.Text.Trim(),PRODUCTO.ToString());
                        datos = (DataTable)ds.Tables["DetalleMovimiento"];

                       VIEW_DETALLE.DataSource = datos;
                    }

                }
                else
                {
                    //DataTable datos = new DataTable();
                    //SlprDt.Fill(ds.SolicitudesProducto, "", "", CbxSemana.Text.Trim());
                    //datos = (DataTable)ds.Tables["SolicitudesProducto"];

                    //GridViewDetalle.DataSource = datos;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region EVENTOS
        private void FrmMovInventario_Load(object sender, EventArgs e)
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

        private void CbxAnio_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {

                semana.Fill(ds.Semanas, cbxAnio.Text.Trim());
                CbxSemana.DataSource = (DataTable)ds.Tables["Semanas"];
              
                CbxSemanaMov.DataSource = sc.SEMANAS_MOVIMIENTOS(cbxAnio.Text.Trim(),"");

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

               // Se Genera los pendientes de la semana seleccionada
                if (sc.SEMANAS_MOVIMIENTOS(cbxAnio.Text.Trim(), CbxSemana.Text.Trim()).AsEnumerable().Count() > 0)
                {
                    DialogResult result = MessageBox.Show("Datos ya fueron generados\n ¿ Desea realizar nuevamente la operación?", "Confirmación", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {


                        var respuesta = sc.ACTUALIZAR_PENDIENTES(CbxSemana.Text.Trim());

                        if (respuesta == "OK")
                        {
                            int indice = CbxSemanaMov.SelectedIndex;
                            CbxSemanaMov.DataSource = sc.SEMANAS_MOVIMIENTOS(cbxAnio.Text.Trim(), "");
                            CbxSemanaMov.SelectedIndex = indice;
                            POP_ALERT.CaptionText = "Exito";
                            POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                            POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                            POP_ALERT.ThemeName = "Windows8";
                            POP_ALERT.ContentText = "Datos Generados";
                            POP_ALERT.Show();
                        }
                        else
                        {
                            MessageBox.Show(respuesta);
                        }

                    }
                }
                else
                {
                    sc.AGREGAR_MOVIMIENTOS(CbxSemana.Text.Trim());
                    CbxSemanaMov.DataSource = sc.SEMANAS_MOVIMIENTOS(cbxAnio.Text.Trim(), "");
                    POP_ALERT.CaptionText = "Exito";
                    POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                    POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                    POP_ALERT.ThemeName = "Windows8";
                    POP_ALERT.ContentText = "Datos Generados";
                    POP_ALERT.Show();
               }




                //Alerta
               
            }
            catch (Exception ex)
            {

                MessageBox.Show( "Error "+ ex.Message);
            }
        }

        private void CbxSemanaMov_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                
                TA_MOV.Fill(ds.Movimientos, CbxSemanaMov.Text.Trim());
                VIEW_MOVIMIENTO.DataSource = (DataTable)ds.Tables["Movimientos"];
                if (flagDetalle == false)
                {
                    DetalleMvimiento();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
  

        private void VIEW_MOVIMIENTO_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                DetalleMvimiento();
                GroupDetalle.IsExpanded = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void VIEW_MOVIMIENTO_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            try
            {
                if (VIEW_MOVIMIENTO.RowCount > 1)
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

        private void BtnConsolidado_Click(object sender, EventArgs e)
        {
            try
            {

                TA_MOV.Fill(ds.Movimientos, CbxSemanaMov.Text.Trim());
                var datos = (DataTable)ds.Tables["Movimientos"];
                var valores = (from xP in datos.AsEnumerable()
                               select new
                               {
                                   Semana = xP.Field<string>("SEMANA"),                                
                                   Producto = xP.Field<string>("PRODUCTO"),
                                   Desviacion = xP.Field<string>("DESVIACION"),
                                   Cantidad = xP.Field<int?>("CANTIDAD_PLAN"),
                                   Cantidad_Vieja = xP.Field<int?>("CANTIDAD_VIEJA"),
                                   Cantidad_Vieja_desviacion = xP.Field<int?>("CANTIDAD_VIEJA_DESVIACION"),
                                   Movido = xP.Field<int?>("TOTAL"),
                                   Pendiente = xP.Field<int?>("MOV_PENDIENTE"),
                                   VIERNES_DIURNO = xP.Field<int?>("VIERNES_DIURNO"),
                                   VIERNES_NOCTURNO = xP.Field<int?>("VIERNES_NOCTURNO"),
                                   SABADO_DIURNO = xP.Field<int?>("SABADO_DIURNO"),
                                   SABADO_NOCTURNO = xP.Field<int?>("SABADO_NOCTURNO"),
                                   DOMINGO_DIURNO = xP.Field<int?>("DOMINGO_DIURNO"),
                                   DOMINGO_NOCTURNO = xP.Field<int?>("DOMINGO_NOCTURNO"),
                                   LUNES_DIURNO = xP.Field<int?>("LUNES_DIURNO"),
                                   LUNES_NOCTURNO = xP.Field<int?>("LUNES_NOCTURNO"),
                                   MARTES_DIURNO = xP.Field<int?>("MARTES_DIURNO"),
                                   MARTES_NOCTURNO = xP.Field<int?>("MARTES_NOCTURNO"),
                                   MIERCOLES_DIURNO = xP.Field<int?>("MIERCOLES_DIURNO"),
                                   MIERCOLES_NOCTURNO = xP.Field<int?>("MIERCOLES_NOCTURNO"),
                                   JUEVES_DIURNO = xP.Field<int?>("JUEVES_DIURNO"),
                                   JUEVES_NOCTURNO = xP.Field<int?>("JUEVES_NOCTURNO"),
                                   ESTADO = xP.Field<int?>("ESTADO")
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
                GridViewExportar.Columns["PRODUCTO"].Width = 140;
                GridViewExportar.Columns["DESVIACION"].Width = 140;

                GridViewExportar.Columns["CANTIDAD_VIEJA"].Width = 180;
                GridViewExportar.Columns["CANTIDAD_VIEJA_DESVIACION"].Width = 180;
               

                GridViewExportar.Columns["CANTIDAD_VIEJA"].HeaderText = "Cantidad Vieja Original";
                GridViewExportar.Columns["CANTIDAD_VIEJA_DESVIACION"].HeaderText = "Cantidad Vieja Desviación";
               

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

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                

                GridViewExportar.DataSource = sc.OBTENER_DETALLE_SEMANA(CbxSemanaMov.Text.Trim());


                for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                {
                    GridViewExportar.Columns[i].BestFit();
                    // GridViewExportar.Columns[i].Width = 180;
                    GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                    GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                }


                GridViewExportar.BestFitColumns();


                GridViewExportar.Columns["Semana"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                GridViewExportar.Columns["Producto"].Width = 140;
                GridViewExportar.Columns["Desviacion"].Width = 140;
                GridViewExportar.Columns["UsuarioModifica"].Width = 170;
                GridViewExportar.Columns["FechaModificacion"].Width = 170;
                GridViewExportar.Columns["Usuario"].Width = 170;
                

                GridViewExportar.Columns["UsuarioModifica"].HeaderText = "Usuario de Modificación";
                GridViewExportar.Columns["FechaModificacion"].HeaderText = "Fecha de Modificación";

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

                MessageBox.Show(ex.Message );
            }
        }

        private void VIEW_DETALLE_CellClick(object sender, GridViewCellEventArgs e)
        {
           
        }

        private void VIEW_DETALLE_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (VIEW_DETALLE.RowCount > 0)

                {

                    object PRODUCTO = VIEW_DETALLE.CurrentRow.Cells["mov_det_ID"].Value;
                    int indice = CbxSemanaMov.SelectedIndex;
                    int fila = VIEW_MOVIMIENTO.Rows.IndexOf(this.VIEW_MOVIMIENTO.CurrentRow);
                    frmActualizarDetalle FrmDet = new frmActualizarDetalle();
                    FrmDet.ID_DET = PRODUCTO;
                    FrmDet.ShowDialog();


                    flagDetalle = true;

                    
                    CbxSemanaMov.DataSource = sc.SEMANAS_MOVIMIENTOS(cbxAnio.Text.Trim(), "");
                    CbxSemanaMov.SelectedIndex = indice;
                    VIEW_MOVIMIENTO.Rows[fila].IsSelected = true;
                    VIEW_MOVIMIENTO.Rows[fila].IsCurrent = true;
                    flagDetalle = false;
                    DetalleMvimiento();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


       

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = CbxSemanaMov.SelectedIndex;
                CbxSemanaMov.DataSource = sc.SEMANAS_MOVIMIENTOS(cbxAnio.Text.Trim(), "");
                CbxSemanaMov.SelectedIndex = indice;

                POP_ALERT.CaptionText = "Exito";
                POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                POP_ALERT.ThemeName = "Windows8";
                POP_ALERT.ContentText = "Semana Actualizada";
                POP_ALERT.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    

        private void BtnGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                TA_MGEN.Fill(ds.MovGeneral, CbxSemanaMov.Text.Trim());
                var datos = (DataTable)ds.Tables["MovGeneral"];

                GridViewExportar.DataSource = datos;


                for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                {
                    GridViewExportar.Columns[i].BestFit();
                    // GridViewExportar.Columns[i].Width = 180;
                    GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                    GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                }


                GridViewExportar.BestFitColumns();


                GridViewExportar.Columns["Semana"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                GridViewExportar.Columns["Producto"].Width = 140;
                GridViewExportar.Columns["Cantidad"].Width = 140;
                GridViewExportar.Columns["Desviacion"].Width = 140;
                GridViewExportar.Columns["Cantidad_Vieja"].Width = 180;
                GridViewExportar.Columns["Cantidad_Vieja_Desviacion"].Width = 180;
                GridViewExportar.Columns["Usuario_Modifica"].Width = 180;
                GridViewExportar.Columns["Fecha_Modifica"].Width =180;

                GridViewExportar.Columns["Cantidad_Vieja"].HeaderText="Cantidad Vieja Original";
                GridViewExportar.Columns["Cantidad_Vieja_Desviacion"].HeaderText = "Cantidad Vieja Desviación";
                GridViewExportar.Columns["Usuario_Modifica"].HeaderText = "Usuario de Modificación";
                GridViewExportar.Columns["Fecha_Modifica"].HeaderText = "Fecha de Modificación";
                

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
        #endregion

    }
}
