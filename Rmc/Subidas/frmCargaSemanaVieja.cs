using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rmc.Clases;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;

namespace Rmc.Subidas
{
    public partial class frmCargaSemanaVieja : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        dsPMC ds = new dsPMC();
        bool flagValidar = false;
        bool flagEstado = false;
        List<pmc_Mov_Bodega> IPlanSemana = new List<pmc_Mov_Bodega>();
        List<string> Isemanas = new List<string>();
        int ValorDesv = 0;
        public frmCargaSemanaVieja()
        {
            InitializeComponent();
            GridViewAntiguo.Rows.AddNew();
        }
        #endregion


        #region DATOS

        public bool ValidarDatos()
        {
            try
            {
                if (GridViewAntiguo.RowCount > 0)
                {
                    //SE crean  y se inicializan  los DataTables necesarios 
                    DataTable dt = new DataTable();


                    flagEstado = false;

                    // Se obtienen los movimientos por semana especifica
                    IPlanSemana = sc.PLAN_MOV_SEMANA(CbxSemana.Text.Trim());

                    dt.Columns.Add("Semana", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("mov_item_desv", typeof(string));
                    dt.Columns.Add("mov_cantidad_vieja", typeof(int));
                   
                    dt.Columns.Add("mov_cantidad_vieja_desc", typeof(string));
                    dt.Columns.Add("ESTADO", typeof(string));

                    string Articulo = "";
                    int CantidadDes = 0;
                    object Desviacion = "";
                    //Llenado de DataTable dt
                    for (int r = 0; r < this.GridViewAntiguo.RowCount; r++)
                    {

                        Articulo = GridViewAntiguo.Rows[r].Cells["Item"].Value.ToString().Trim();
                        Desviacion = GridViewAntiguo.Rows[r].Cells["mov_item_desv"].Value;
                        //}
                        if (GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value == null || GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value.ToString().Trim() == "")
                        {
                            CantidadDes = 0;
                        }
                        else
                        {
                            CantidadDes = Convert.ToInt32(GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value);
                        }

                        dt.Rows.Add(CbxSemana.Text.Trim(), Articulo,Desviacion,
                                    Convert.ToInt32(GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja"].Value), CantidadDes
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


                        GridViewAntiguo.DataSource = dt;




                    }
                    else
                    {
                        //dt.Columns.Remove("Item_Desv");
                        dt.Columns.Remove("Semana");
                        GridViewAntiguo.DataSource = dt;
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
        private void FrmCargaSemanaVieja_Load(object sender, EventArgs e)
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

        private void FrmCargaSemanaVieja_Enter(object sender, EventArgs e)
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewAntiguo.DataSource = null;
                this.GridViewAntiguo.Rows.Clear();
                GridViewAntiguo.Rows.AddNew();
                GridViewAntiguo.Refresh();
                LblError.Visible = false;
                BtnGuardar.Enabled = true;
                flagValidar = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewAntiguo_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {

            try
            {
                // Formato a celda según el valor contenido
                if (GridViewAntiguo.RowCount > 0)
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


                    else if (e.CellElement.ColumnInfo.HeaderText == "Cantidad")
                    {
                        if (e.CellElement.RowInfo.Cells["mov_cantidad_vieja"].Value == null || e.CellElement.RowInfo.Cells["mov_cantidad_vieja"].Value.ToString().Trim() == "")
                        {

                            e.CellElement.DrawFill = true;
                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.MistyRose;


                        }
                        else if (Convert.ToInt32(e.CellElement.RowInfo.Cells["mov_cantidad_vieja"].Value) < 0)
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


                        if ((e.CellElement.RowInfo.Cells["Item"].Value != null) && (e.CellElement.RowInfo.Cells["mov_item_desv"].Value == null || e.CellElement.RowInfo.Cells["mov_item_desv"].Value.ToString().Trim() == ""))
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

        private void GridViewAntiguo_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            try
            {
                //Formato a filas según el estado
                if (GridViewAntiguo.RowCount > 0)
                {
                    if (e.RowElement.RowInfo.Cells["ESTADO"].Value != null)
                    {

                        if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("ENCONTRADO"))
                        {
                            e.RowElement.DrawFill = true;
                            e.RowElement.GradientStyle = GradientStyles.Solid;
                            e.RowElement.BackColor = Color.Red;
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

                    for (int r = 0; r < GridViewAntiguo.RowCount; r++)
                    {
                        if (GridViewAntiguo.Rows[r].Cells["Item"].Value == null || GridViewAntiguo.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Producto");
                            break;
                        }

                        else if (GridViewAntiguo.Rows[r].Cells["mov_item_desv"].Value == null || GridViewAntiguo.Rows[r].Cells["mov_item_desv"].Value.ToString().Trim() == "" || GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value == null || GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value.ToString().Trim() == "")
                        {

                              if (GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja"].Value == null || GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja"].Value.ToString().Trim() == "")
                            {
                                flagValidar = true;
                                MessageBox.Show("Verificar columna Cantidad Original o Cantidad Desviación");
                                break;
                            }
                        }

                       
                        else if (Convert.ToInt32(GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja"].Value) < 0)
                        {
                            flagValidar = true;
                            MessageBox.Show("Columna cantidad no puede contener \nvalores iguales o menores a Cero");
                            break;
                        }

                        else if (Convert.ToInt32(GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value) < 0)
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

                                for (int r = 0; r < GridViewAntiguo.RowCount; r++)
                                {
                                    // ACTUALIZACION DE CANTIDAD DE SEMANA VIEJA PARA MOVIMIENTO EN BODEGA
                                    var ActMovimientos = (from x in db.pmc_Mov_Bodegas
                                                          where x.mov_semana == CbxSemana.Text.Trim() && x.mov_item == GridViewAntiguo.Rows[r].Cells["Item"].Value.ToString().Trim()
                                                          select x).FirstOrDefault();

                                    ActMovimientos.mov_cantidad_vieja = Convert.ToInt32(GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja"].Value);
                                    ActMovimientos.mov_cantidad_vieja_desc= Convert.ToInt32(GridViewAntiguo.Rows[r].Cells["mov_cantidad_vieja_desc"].Value);
                                    ActMovimientos.mov_FH_modificacion = DateTime.Now;
                                    ActMovimientos.mov_usuario_modificacion = Environment.UserName;
                                    db.SubmitChanges();

                                }
                                resultado = "OK";
                            }
                            if (resultado == "OK")
                            {

                                GridViewAntiguo.DataSource = null;
                                this.GridViewAntiguo.Rows.Clear();
                                GridViewAntiguo.Rows.AddNew();
                                CbxSemana.Text = "0000-00";
                                BtnGuardar.Enabled = true;
                                MessageBox.Show("\n Proceso Realizado \n con Éxito \n", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            }
                            else
                            {
                                MessageBox.Show("Error al cargar Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                GridViewAntiguo.DataSource = null;
                                this.GridViewAntiguo.Rows.Clear();
                                GridViewAntiguo.Rows.AddNew();
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


        #endregion
    }
}
