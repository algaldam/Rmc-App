using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rmc.Clases;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;

namespace Rmc.Subidas
{
    public partial class frmCargarPendientes : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        dsPMC ds = new dsPMC();
        bool flagValidar = false;
        bool flagEstado = false;
        List<pmc_Mov_Bodega> IPlanSemana = new List<pmc_Mov_Bodega>();
        List<string> Isemanas = new List<string>();
        int ValorDesv =0;
        public frmCargarPendientes()
        {
            InitializeComponent();
            GridViewApartado.Rows.AddNew();
        }
        #endregion


        #region DATOS
        public bool ValidarDatos()
        {
            try
            {
                if (GridViewApartado.RowCount > 0)
                {
                    //SE crean  y se inicializan  los DataTables necesarios 
                    DataTable dt = new DataTable();


                    flagEstado = false;
                  
                    // Se obtienen los movimientos por semana especifica
                    IPlanSemana = sc.PLAN_MOV_SEMANA(CbxSemana.Text.Trim());
                    
                    dt.Columns.Add("Semana", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("mov_det_desv", typeof(string));
                    dt.Columns.Add("mov_det_cant", typeof(int));
                    dt.Columns.Add("mov_det_cant_desv", typeof(string));                                                  
                    dt.Columns.Add("ESTADO", typeof(string));

                    string Articulo = "";
                    int CantidadDes = 0;
                    object Desviacion = "";
                    //Llenado de DataTable dt
                    for (int r = 0; r < this.GridViewApartado.RowCount; r++)
                    {
                       
                            Articulo = GridViewApartado.Rows[r].Cells["Item"].Value.ToString().Trim();
                        Desviacion = GridViewApartado.Rows[r].Cells["mov_det_desv"].Value;
                        //}
                        if (GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value ==null || GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value.ToString().Trim() == "")
                        {
                            CantidadDes = 0;
                        }else
                        {
                            CantidadDes = Convert.ToInt32(GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value);
                        }

                        dt.Rows.Add(CbxSemana.Text.Trim(), Articulo,Desviacion ,
                                    Convert.ToInt32(GridViewApartado.Rows[r].Cells["mov_det_cant"].Value), CantidadDes
                                 );                      
                    }
                    // Se valida si Item existe en el plan correspondiente a la semana seleccionada
                    if (IPlanSemana.Count > 0)
                    {

                        var consulta = (from x in dt.AsEnumerable()
                                        select new
                                        {
                                            Semana = x.Field<string>("Semana"),
                                            Item = x.Field<string>("Item")
                                        }
                                            ).Except(from x in IPlanSemana
                                                     select new
                                                     {
                                                         Semana = x.mov_semana,
                                                         Item = x.mov_item
                                                     }).ToList();

                        if (consulta.Count > 0)
                       {

                            foreach (DataRow dr in dt.Rows) // search whole table
                            {

                                foreach (var item in consulta)
                                {
                                    if (dr["Semana"].ToString() == item.Semana.ToString() && dr["Item"].ToString() == item.Item.ToString()) // if id==2
                                    {
                                        dr["ESTADO"] = "ENCONTRADO";
                                    }
                                }

                            }

                            flagEstado = true;

                            // GridViewSolicitud.DataSource = dt;

                        }

                        dt.Columns.Remove("Semana");
                       

                        GridViewApartado.DataSource = dt;




                    }
                    else
                    {
                        //dt.Columns.Remove("Item_Desv");
                        dt.Columns.Remove("Semana");
                        GridViewApartado.DataSource = dt;
                        flagEstado = true;
                        MessageBox.Show("El plan para la semana Seleccionada \n No contiene Registros; ");
                    }




                }

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                flagEstado = true;
                MessageBox.Show("Verificar dato Ingresados; " + sqlEx.Message);

            }
            catch (Exception ex)
            {
                flagEstado = true;
                MessageBox.Show(ex.Message);

            }

            return flagEstado;

        }

        #endregion


        #region EVENTOS
        private void FrmCargarPendientes_Enter(object sender, EventArgs e)
        {

            try
            {
                CbxSemana.DataSource = sc.SEMANAS_MOVIMIENTOS_YEARS();
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
                flagValidar = false;
                LblError.Visible = false;
                //BtnGuardar.Enabled = false;
                if (CbxSemana.Text.Trim() == "" || CbxSemana.Text.Trim() == "0000-00")
                {
                    CbxSemana.BackColor = Color.MistyRose;
                }
                else
                {
                    #region VALIDAR CELDAS

                    for (int r = 0; r < GridViewApartado.RowCount; r++)
                    {
                        if (GridViewApartado.Rows[r].Cells["Item"].Value == null || GridViewApartado.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Producto");
                            break;
                        }

                        else if (GridViewApartado.Rows[r].Cells["mov_det_desv"].Value == null || GridViewApartado.Rows[r].Cells["mov_det_desv"].Value.ToString().Trim() == "" || GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value == null || GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value.ToString().Trim() == "")
                        {
                               if (GridViewApartado.Rows[r].Cells["mov_det_cant"].Value == null || GridViewApartado.Rows[r].Cells["mov_det_cant"].Value.ToString().Trim() == "")
                            {
                                flagValidar = true;
                                MessageBox.Show("Verificar columna Cantidad Original  o Cantidad Desviación");
                                break;
                            }
                        }
                            
                      

                        else if (Convert.ToInt32(GridViewApartado.Rows[r].Cells["mov_det_cant"].Value) < 0)
                        {
                            flagValidar = true;
                            MessageBox.Show("Columna cantidad no puede contener \nvalores iguales o menores a Cero");
                            break;
                        }

                        else if (Convert.ToInt32(GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value) < 0)
                        {
                            flagValidar = true;
                            MessageBox.Show("Columna cantidad no puede contener \nvalores iguales o menores a Cero");
                            break;
                        }
                    }

                    #endregion

                    if (flagValidar == false)
                    {
                        if (ValidarDatos() == true)
                        {
                            LblError.Visible = true;

                        }
                        else
                        {
                            // Obtiene el resultado de la consulta
                            string resultado = "";

          

                            //Se inserta en la tabla  pmc_Mov_Bodega_Det Utilizando POO
                            using (dcPmcDataContext db = new dcPmcDataContext())
                            {

                                for (int r = 0; r < GridViewApartado.RowCount; r++)
                                {
                                    // REGISTRO DE DETALLE DE MOVIMIENTOS

                                    pmc_Mov_Bodega_Det Deliver = new pmc_Mov_Bodega_Det
                                    {

                                        mov_det_semana = CbxSemana.Text.Trim(),
                                        mov_det_item = GridViewApartado.Rows[r].Cells["Item"].Value.ToString().Trim(),
                                        mov_det_desv = GridViewApartado.Rows[r].Cells["mov_det_desv"].Value==null? null : GridViewApartado.Rows[r].Cells["mov_det_desv"].Value.ToString().Trim(),
                                        mov_det_cant = Convert.ToInt32(GridViewApartado.Rows[r].Cells["mov_det_cant"].Value),
                                        mov_det_FH_crea= DateTime.Now,
                                        mov_det_cant_desv = Convert.ToInt32(GridViewApartado.Rows[r].Cells["mov_det_cant_desv"].Value),
                                        mov_det_usuario =Environment.UserName

                                    };
                                    db.pmc_Mov_Bodega_Dets.InsertOnSubmit(Deliver);
                                    db.SubmitChanges();
                                }
                                resultado = "OK";
                                }
                            if (resultado == "OK")
                            {

                                GridViewApartado.DataSource = null;
                                this.GridViewApartado.Rows.Clear();
                                GridViewApartado.Rows.AddNew();
                                CbxSemana.Text = "0000-00";
                                BtnGuardar.Enabled = true;
                                MessageBox.Show("\n Proceso Realizado \n con Éxito \n", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            }
                            else
                            {
                                MessageBox.Show("Error al cargar Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                GridViewApartado.DataSource = null;
                                this.GridViewApartado.Rows.Clear();
                                GridViewApartado.Rows.AddNew();
                            }




                        }
                    }

                }

            }
            catch (Exception ex)
            {

                RadMessageBox.Show("\n" + ex.Message);
            }
        }

        private void GridViewApartado_PastingCellClipboardContent(object sender, Telerik.WinControls.UI.GridViewCellValueEventArgs e)
        {
            //Se validan datos antes de ser pegados en la Tabla de Carga
            try
            {
                if (e.Column.Name == "mov_det_cant")
                {
                    int valor;
                    var valid = int.TryParse(e.Value.ToString(), out valor);
                    if (!valid)
                    {
                        RadMessageBox.Show("Celda con formato incorrecto en columna Cantidad Original \n Ingresar valores enteros");

                    }
                }

                if (e.Column.Name == "mov_det_cant_desv")
                {
                    int valor;
                    object value = e.Value;

                    var valid = int.TryParse((value != null ? value.ToString() : "0"), out valor);
                    if (!valid)
                    {
                        RadMessageBox.Show("Celda con formato incorrecto en columna Cantidad Desviación \n Ingresar valores enteros");

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }

        private void GridViewApartado_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try
            {
                // Formato a celda según el valor contenido
                if (GridViewApartado.RowCount > 0)
                {

                    if (e.CellElement.ColumnInfo.HeaderText == "Producto")
                    {
                        if (e.CellElement.RowInfo.Cells["Item"].Value == null || e.CellElement.RowInfo.Cells["Item"].Value.ToString().Trim() == "")
                        {

                            e.CellElement.DrawFill = true;
                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.MistyRose;
                        }
                        else
                        {
                            e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        }
                    }
                  

                    else if (e.CellElement.ColumnInfo.HeaderText == "Cantidad Original")
                    {
                        if (e.CellElement.RowInfo.Cells["mov_det_cant"].Value == null || e.CellElement.RowInfo.Cells["mov_det_cant"].Value.ToString().Trim() == "")
                        {
                            
                            e.CellElement.DrawFill = true;
                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.MistyRose;


                        }
                        else if (Convert.ToInt32(e.CellElement.RowInfo.Cells["mov_det_cant"].Value) < 0)
                        {

                            e.CellElement.DrawFill = true;
                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.MistyRose;
                        }
                        else
                        {
                            e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        }
                    }


                    // Proceso  para verificar si  la columna Desviación contiene registros de ser asi habilita las celdas 
                    else if (e.CellElement.ColumnInfo.HeaderText == "Desviación")
                    {


                        if ((e.CellElement.RowInfo.Cells["Item"].Value != null) && (e.CellElement.RowInfo.Cells["mov_det_desv"].Value == null || e.CellElement.RowInfo.Cells["mov_det_desv"].Value.ToString().Trim() == ""))
                        {

                            ValorDesv = 1;

                        }
                        else
                        {

                            ValorDesv = 0;
                        }
                    }
                    else if (e.CellElement.ColumnInfo.HeaderText == "Cantidad Desviación")
                    {

                        if (ValorDesv == 1)
                        {
                            // e.CellElement.Value = 0;

                            e.CellElement.DrawFill = true;
                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.Green;
                            ValorDesv = 0;
                            e.CellElement.Enabled = false;
                        }
                        else
                        {
                            e.CellElement.Enabled = true;
                            e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        }
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewApartado_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            try
            {
                //Formato a filas según el estado
                if (GridViewApartado.RowCount > 0)
                {
                    if (e.RowElement.RowInfo.Cells["ESTADO"].Value != null)
                    {

                        if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("ENCONTRADO"))
                        {
                            e.RowElement.DrawFill = true;
                            e.RowElement.GradientStyle = GradientStyles.Solid;
                            e.RowElement.BackColor = Color.Red;
                        }
                        else if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("SOBRE"))
                        {
                            e.RowElement.DrawFill = true;
                            e.RowElement.GradientStyle = GradientStyles.Solid;
                            e.RowElement.BackColor = Color.Gold;
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {



                GridViewApartado.DataSource = null;
                this.GridViewApartado.Rows.Clear();
                GridViewApartado.Rows.AddNew();
                GridViewApartado.Refresh();
                LblError.Visible = false;
                BtnGuardar.Enabled = true;
                flagValidar = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion
    }
}
