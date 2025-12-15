using Rmc.Clases;
using Rmc.Clases.dsStageAreaTableAdapters;
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

namespace Rmc.Subidas
{
    public partial class frmSubidaPlan : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        string sql = "";

        dsStageArea dsa = new dsStageArea();
        ValidarCargaPlanTableAdapter vta = new ValidarCargaPlanTableAdapter();
        ValidadPlanGENTableAdapter vtgen = new ValidadPlanGENTableAdapter();
        bool flagValidar = false;
        bool flagEstado = false;
        public frmSubidaPlan()
        {
            InitializeComponent();
            GridViewPlan.Rows.AddNew();
        }

        #endregion

        #region DATOS

        private bool ValidarDatos()
        {
            try
            {
                if (GridViewPlan.RowCount > 0)
                {
                    // Se crean e inicializan las DataTables necesarias
                    DataTable dt = new DataTable();
                    DataTable dtErrores = new DataTable();
                    DataTable dtGen = new DataTable ();
                    string sqlDelete = "";
                    dt.Columns.Add("Semana", typeof(string));
                    dt.Columns.Add("Silueta", typeof(string));
                    dt.Columns.Add("Estilo", typeof(string));
                    dt.Columns.Add("Talla", typeof(string));
                    dt.Columns.Add("SACA", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(int));
                   

                    dt.Columns.Add("Item_Desv", typeof(string));
                    string SACA = "";
                    string Talla = "000";
                    string Estilo = "";

                    // llenado de DataTable dt
                    for (int r = 0; r < this.GridViewPlan.RowCount; r++)
                    {
                       
                        //Validar tamaño y campos correctos
                        #region VALIDAR COLUMNAS

                        if (GridViewPlan.Rows[r].Cells["Item_Desv"].Value == null)
                        {

                            if (GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim().Length > 8)
                            {
                                //MessageBox.Show(GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim().Substring(0, 8));
                                SACA = GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim().Substring(0, 8);
                            }
                            else
                            {
                                SACA = GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim();
                            }

                            if (GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim().Length > 4)
                            {
                                Estilo = GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim().Substring(0, 4);
                            }
                            else
                            {
                                Estilo = GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim();
                            }

                            if (GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim().Length > 3)
                            {
                                Talla = GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim().Substring(0, 3);
                            }
                            else
                            {
                                Talla = GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim();
                            }
                            dt.Rows.Add(CbxSemana.Text.Trim(), GridViewPlan.Rows[r].Cells["Silueta"].Value.ToString().Trim(),
                            Estilo, Talla, SACA.ToUpper(), GridViewPlan.Rows[r].Cells["Item"].Value.ToString().Trim(),
                           Convert.ToInt32(GridViewPlan.Rows[r].Cells["Cantidad"].Value.ToString().Trim()), null);

                        }
                        else
                        {


                            if (GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim().Length > 8)
                            {
                                //MessageBox.Show(GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim().Substring(0, 8));
                                SACA = GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim().Substring(0, 8);
                            }
                            else
                            {
                                SACA = GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim();
                            }

                            if (GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim().Length > 4)
                            {
                                Estilo = GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim().Substring(0, 4);
                            }
                            else
                            {
                                Estilo = GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim();
                            }

                            if (GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim().Length > 3)
                            {
                                Talla = GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim().Substring(0, 3);
                            }
                            else
                            {
                                Talla = GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim();
                            }
                            dt.Rows.Add(CbxSemana.Text.Trim(), GridViewPlan.Rows[r].Cells["Silueta"].Value.ToString().Trim(),
                                        Estilo, Talla,SACA.ToUpper (), GridViewPlan.Rows[r].Cells["Item"].Value.ToString().Trim(),
                                        Convert.ToInt32(GridViewPlan.Rows[r].Cells["Cantidad"].Value.ToString().Trim()), GridViewPlan.Rows[r].Cells["Item_Desv"].Value.ToString().Trim());

                        }
                        #endregion
                    }

                    sc.OpenConectionStg();

                    sqlDelete = "DELETE FROM PMC_stg_Plan";
                    sc.EjecutarQueryStg(sqlDelete);

                    sc.InsertSqlBulkCopyStg(dt, "PMC_stg_Plan");
                    sc.CloseConection();

                    // Se comprueba que datos proporcionandos existan en el BOM
                    vta.Fill(dsa.ValidarCargaPlan);
                    dtErrores = dsa.Tables["ValidarCargaPlan"];
                    vtgen.Fill(dsa.ValidadPlanGEN);
                    dtGen = dsa.Tables["ValidadPlanGEN"];
                    dt.Columns.Add("ESTADO", typeof(string));
                    dt.Columns.Remove("Semana");
                    #region if ERRORES SACA, ITEM EN BOM

                    if (dtErrores.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            int contador = 0;
                            foreach (DataRow item in dtErrores.Rows  )
                            {

                                if ( dr["SACA"].ToString() == item["SACA"].ToString() && dr["Item"].ToString() == item["ITEM"].ToString()) 
                                {

                                    dr["ESTADO"] = "ERROR";
                                    break;

                                }
                                else
                                {
                                    dr["ESTADO"] = "ENCONTRADO";

                                }
                                contador += 1;

                                if (contador == dt.Rows.Count)
                                {
                                    break;
                                }
                            }


                        }
                        flagEstado = true;
                       

                        GridViewPlan .DataSource = dt;

                       // var consulta = (from dx in dt.AsEnumerable()
                      //                  join dy in dtErrores.AsEnumerable()
                      //                          on
                      //               new
                      //               {
                      //                   SACA = dx.Field<string>("SACA"),
                      //                   item = dx.Field<string>("Item"),

                      //               }
                      //               equals new
                      //               {
                      //                   SACA = dy.Field<string>("SACA"),
                      //                   item = dy.Field<string>("ITEM"),
                      //               }

                      //                  select

                      //                  new
                      //                  {

                      //                      SACA = dx.Field<string>("SACA"),
                      //                      Item = dx.Field<string>("Item"),
                      //                      Cantidad = dx.Field<int>("Cantidad"),
                      //                      Silueta = dx.Field<string>("Silueta"),
                      //                      Estilo = dx.Field<string>("Estilo"),
                      //                      Talla = dx.Field<string>("Talla"),
                      //                      ESTADO = dy.Field<string>("ESTADO"),
                      //                      ORDEN = dy.Field<int>("ORDEN")
                      //                  }).ToList();



                      //  GridViewPlan.DataSource = consulta;


                      //// Se verifia si existen errores 
                      //  foreach (DataRow row in dtErrores.Rows)
                      //  {

                      //      if (row["ESTADO"].ToString().Equals("ERROR"))
                      //      {

                      //          flagEstado = true;

                      //          break;
                      //      }
                      //      else
                      //      {
                      //          flagEstado = false;
                      //      }
                      //  }
                    }
                    #endregion

                    #region if ERRORES ITEM EN BOM

                    if (dtGen.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            int contador = 0;
                            foreach (DataRow item in dtGen.Rows)
                            {

                                if (dr["Item"].ToString() == item["ITEM"].ToString()) 
                                {

                                    dr["ESTADO"] = "ERROR";
                                    break;

                                }
                                else
                                {
                                    if (dr["ESTADO"].ToString () != "ERROR")
                                    {
                                        dr["ESTADO"] = "ENCONTRADO";
                                    }
                                    

                                }
                                contador += 1;

                                if (contador == dt.Rows.Count)
                                {
                                    break;
                                }
                            }


                        }
                        flagEstado = true;
                        //dt.Columns.Remove("Semana");

                        GridViewPlan.DataSource = dt;

                    }
                    #endregion
                }

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                flagEstado = true;
                MessageBox.Show("Verificar datos ingresados;  " + sqlEx.Message);

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
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {


                GridViewPlan.DataSource = null;
                this.GridViewPlan.Rows.Clear();
                GridViewPlan.Rows.AddNew();
                LblError.Visible = false;
                BtnGuardar.Enabled = true;
                flagValidar = false;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmSubidaPlan_Load(object sender, EventArgs e)
        {
         
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    var semanas = (from x in db.pmc_Semanas
                                   where x.sem_estado == true
                                   orderby x.sem_ID descending
                                   select x).ToList();
                    CbxSemana.DataSource = semanas;
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
               // BtnGuardar.Enabled = false;
                LblError.Visible = false;
                flagValidar = false;
                flagEstado = false;
                if (CbxSemana.Text.Trim() == "" || CbxSemana.Text.Trim() == "0000-00")
                {
                    CbxSemana.BackColor = Color.MistyRose;
                }
                else
                {
                    #region VALIDAR CELDAS

                    for (int r = 0; r < GridViewPlan.RowCount; r++)
                    {
                        if (GridViewPlan.Rows[r].Cells["Silueta"].Value == null || GridViewPlan.Rows[r].Cells["Silueta"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Siluetas");
                            break;
                        }

                        else if (GridViewPlan.Rows[r].Cells["Estilo"].Value == null || GridViewPlan.Rows[r].Cells["Estilo"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Estilo");
                            break;
                        }
                        else if (GridViewPlan.Rows[r].Cells["Talla"].Value == null || GridViewPlan.Rows[r].Cells["Talla"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Talla");
                            break;
                        }
                        else if (GridViewPlan.Rows[r].Cells["SACA"].Value == null || GridViewPlan.Rows[r].Cells["SACA"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna SACA");
                            break;
                        }
                        else if (GridViewPlan.Rows[r].Cells["Item"].Value == null || GridViewPlan.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Producto");
                            break;
                        }
                        else if (GridViewPlan.Rows[r].Cells["Cantidad"].Value == null || GridViewPlan.Rows[r].Cells["Cantidad"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Cantidad");
                            break;
                        }
                        else if (Convert.ToInt32(GridViewPlan.Rows[r].Cells["Cantidad"].Value) <= 0)
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

                          


                            
                                sql = "EXEC usp_PMC_carga_plan";
                                sc.OpenConectionStg();

                                // Obtiene el resultado de la consulta
                                string resultado = sc.DevValorStringStg(sql);
                                if (resultado == "OK")
                                {

                                    GridViewPlan.DataSource = null;
                                    this.GridViewPlan.Rows.Clear();
                                    GridViewPlan.Rows.AddNew();
                                    CbxSemana.Text = "0000-00";
                                    BtnGuardar.Enabled = true;
                                    MessageBox.Show("\n Proceso Realizado \n con Éxito \n", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                }
                                else
                                {
                                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    GridViewPlan.DataSource = null;
                                    this.GridViewPlan.Rows.Clear();
                                    GridViewPlan.Rows.AddNew();
                                }
                                // sc.EjecutarQueryStg(sql);
                                sc.CloseConectionStg();
                            
                          
                        }
                    }


                }

            }
            catch (Exception ex)
            {

                RadMessageBox.Show("\n" + ex.Message);
            }
        }

        private void GridViewPlan_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (GridViewPlan.RowCount > 0)
                {



                    if (e.CellElement.ColumnInfo.HeaderText == "Silueta")
                    {
                        if (e.CellElement.RowInfo.Cells["Silueta"].Value == null || e.CellElement.RowInfo.Cells["Silueta"].Value.ToString().Trim() == "")
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
                    else if (e.CellElement.ColumnInfo.HeaderText == "Estilo")
                    {
                        if (e.CellElement.RowInfo.Cells["Estilo"].Value == null || e.CellElement.RowInfo.Cells["Estilo"].Value.ToString().Trim() == "")
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
                    else if (e.CellElement.ColumnInfo.HeaderText == "Talla")
                    {
                        if (e.CellElement.RowInfo.Cells["Talla"].Value == null || e.CellElement.RowInfo.Cells["Talla"].Value.ToString().Trim() == "")
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
                    else if (e.CellElement.ColumnInfo.HeaderText == "SACA")
                    {
                        if (e.CellElement.RowInfo.Cells["SACA"].Value == null || e.CellElement.RowInfo.Cells["SACA"].Value.ToString().Trim() == "")
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
                    else if (e.CellElement.ColumnInfo.HeaderText == "Producto")
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
                        if (e.CellElement.RowInfo.Cells["Cantidad"].Value == null || e.CellElement.RowInfo.Cells["Cantidad"].Value.ToString().Trim() == "")
                        {

                            e.CellElement.DrawFill = true;

                            e.CellElement.NumberOfColors = 1;
                            e.CellElement.BackColor = Color.MistyRose;
                            //Convert.ToInt32(e.CellElement.RowInfo.Cells["Cantidad"].Value.GetType().FullName;

                        }
                        else if (Convert.ToInt32(e.CellElement.RowInfo.Cells["Cantidad"].Value) <= 0)
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
                        if (e.RowElement.RowInfo.Cells["ESTADO"].Value != null)
                        {
                            
                            if (e.RowElement.RowInfo.Cells["ESTADO"].Value.ToString().Equals("ERROR"))
                            {
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.Tomato;
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

        private void CbxSemana_Click(object sender, EventArgs e)
        {
            CbxSemana.BackColor = Color.White;
        }


       

        private void GridViewPlan_PastingCellClipboardContent(object sender, GridViewCellValueEventArgs e)
        {
            if (e.Column.Name == "Cantidad")
            {
                int valor;
                var valid = int.TryParse(e.Value.ToString(), out valor);
                if (!valid)
                {
                    RadMessageBox.Show("Celda con formato incorrecto en columna Cantidad\n Ingresar valores enteros");
                  
                }
            }
        }

        private void FrmSubidaPlan_Enter(object sender, EventArgs e)
        {

            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    var semanas = (from x in db.pmc_Semanas
                                   where x.sem_estado == true
                                   orderby x.sem_ID descending
                                   select x).ToList();
                    CbxSemana.DataSource = semanas;
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
