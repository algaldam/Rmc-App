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
using Rmc.Clases;
using Telerik.WinControls.UI;

namespace Rmc.Subidas
{
    public partial class frmSobrantes : Telerik.WinControls.UI.RadForm
    {

        #region INICIALIZACION
        dsPMC dsp = new dsPMC();
        PlanSemanaTableAdapter plta = new PlanSemanaTableAdapter();
        DataTable dtPlan = new DataTable();
        bool flagValidar = false;
        bool flagEstado = false;
        public frmSobrantes()
        {
            InitializeComponent();
            GridViewSobrantes.Rows.AddNew();
        }
        #endregion


        #region DATOS

        public bool ValidarDatos()
        {
            try
            {
                if (GridViewSobrantes.RowCount > 0)
                {
                    //SE crean  y se inicializan  los DataTables necesarios 
                    DataTable dt = new DataTable();


                    flagEstado = false;
                    plta.Fill(dsp.PlanSemana, CbxSemana.Text.Trim());
                    dtPlan = dsp.Tables["PlanSemana"];
                    dt.Columns.Add("Semana", typeof(string));
                    dt.Columns.Add("pla_SACA", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(int));
                    dt.Columns.Add("ESTADO", typeof(string));

                   
                    //Llenado de DataTable dt
                    for (int r = 0; r < this.GridViewSobrantes.RowCount; r++)
                    {
                        object SACA =  GridViewSobrantes.Rows[r].Cells["pla_SACA"].Value;
                        string SA="";
                        if (SACA ==null){
                            SA="";
                        }else{
                           SA= GridViewSobrantes.Rows[r].Cells["pla_SACA"].Value.ToString ();
                        }

                        dt.Rows.Add(CbxSemana.Text.Trim(),SA,
                                    GridViewSobrantes.Rows[r].Cells["Item"].Value.ToString().Trim(),
                                    Convert.ToInt32(GridViewSobrantes.Rows[r].Cells["Cantidad"].Value.ToString().Trim()));



                    }
                    // Se valida si Item existe en el plan correspondinete a la semana seleccionada
                    if (dt.Rows.Count > 0)
                    {

                        var consulta = ((from x in dt.AsEnumerable()
                                         select new
                                         {
                                             Semana = x.Field<string>("Semana"),
                                             SACA = x.Field<string>("pla_SACA"),
                                             Producto = x.Field<string>("Item")
                                         }
                                            ).Except(from x in dtPlan.AsEnumerable()
                                                     select new
                                                     {
                                                         Semana = x.Field<string>("pla_semana"),
                                                         SACA = x.Field<string>("pla_SACA"),
                                                         Producto = x.Field<string>("pla_item")

                                                     })).ToList();
                                                    
                                                     
                                                     ;

                        if (consulta.Count ()> 0)
                        {
                            // SE asigna el estado a cada registro de la tabla temporal , el estado puede se ENCONTRADO O ERROR
                            foreach (DataRow dr in dt.Rows) 
                                    {
                               int contador =0;
                                foreach (var item in consulta)
                                {
                                    
                                    if (dr["Semana"].ToString() == item.Semana.ToString() && dr["pla_SACA"].ToString() == item.SACA.ToString() && dr["Item"].ToString()==item.Producto.ToString ()) // if id==2
                                    {
                                       
                                        dr["ESTADO"] = "ERROR";
                                        break;
                                       
                                    }
                                    else
                                    {
                                        dr["ESTADO"] = "ENCONTRADO";
                                       
                                    }
                                    contador += 1;

                                    if (contador == consulta.Count)
                                    {
                                        break;
                                    }
                                }

                           }

                            flagEstado = true;
                            dt.Columns.Remove("Semana");
                          
                            
                            GridViewSobrantes.DataSource = dt;

                        }
                    }
                    else
                    {
                     
                       
                        flagEstado = false;
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

        private void frmSobrantes_Load(object sender, EventArgs e)
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
            catch (Exception ex )
            {
                
                MessageBox.Show (ex.Message );
            }
           

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewSobrantes.DataSource = null;
                this.GridViewSobrantes.Rows.Clear();
                GridViewSobrantes.Rows.AddNew();
                GridViewSobrantes.Refresh();
                LblError.Visible = false;
                BtnGuardar.Enabled = true;
                flagValidar = false;

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
                BtnGuardar.Enabled = false;
                if (CbxSemana.Text.Trim() == "" || CbxSemana.Text.Trim() == "0000-00")
                {
                    CbxSemana.BackColor = Color.MistyRose;
                }
                else
                {
                    #region VALIDAR CELDAS
                    //SE VERIFICAN QUE LOS DATOS INGRESADOS SEAN LOS CORRECTOS Y NECESARIOS
                    for (int r = 0; r < GridViewSobrantes.RowCount; r++)
                    {
                        if (GridViewSobrantes.Rows[r].Cells["Item"].Value == null || GridViewSobrantes.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Producto");
                            break;
                        }
                        else if (GridViewSobrantes.Rows[r].Cells["Cantidad"].Value == null || GridViewSobrantes.Rows[r].Cells["Cantidad"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Cantidad");
                            break;
                        }
                        else if (Convert.ToInt32(GridViewSobrantes.Rows[r].Cells["Cantidad"].Value) <= 0)
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
                            //// Obtiene el resultado de la consulta
                            string resultado = "";
                            ////Se inserta en la tabla solicitudes utilizando el procedimiento almencenado
                            using (dcPmcDataContext db = new dcPmcDataContext())
              
                            {
                            //    // Loop para realizar actualizar fila por fila del grid a la base de datos
                                for (int r = 0; r < GridViewSobrantes.RowCount; r++)
                               {
                                   object objSA = GridViewSobrantes.Rows[r].Cells["pla_SACA"].Value;
                                    string SACA ="";
                                    if(objSA ==null){
                                        SACA ="";
                                    }else {
                                        SACA = GridViewSobrantes.Rows[r].Cells["pla_SACA"].Value.ToString();
                                    }
                                    var actualizar = (from x in db.pmc_Plan
                                                      where x.pla_semana == CbxSemana.Text.Trim()
                                                      && x.pla_SACA == SACA && x.pla_item == GridViewSobrantes.Rows[r].Cells["Item"].Value.ToString ()
                                                      select x).FirstOrDefault();

                                    actualizar.pla_sobrantes = Convert.ToInt32(GridViewSobrantes.Rows[r].Cells["Cantidad"].Value);
                                    actualizar.pla_usuario_mod = Environment.UserName.ToString ();
                                    actualizar.pla_FH_mod = DateTime.Now;
                                    db.SubmitChanges();
                                    resultado = "OK";
                          
                             }
                           }
                            if (resultado == "OK")
                            {

                                GridViewSobrantes.DataSource = null;
                                this.GridViewSobrantes.Rows.Clear();
                                GridViewSobrantes.Rows.AddNew();
                                CbxSemana.Text = "0000-00";
                                BtnGuardar.Enabled = true;
                                MessageBox.Show("\n Proceso Realizado \n con Éxito \n", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            }
                            else
                            {
                                MessageBox.Show("Error al cargar solicitudes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                GridViewSobrantes.DataSource = null;
                                this.GridViewSobrantes.Rows.Clear();
                                GridViewSobrantes.Rows.AddNew();
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

        private void GridViewSobrantes_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Index == -1)
            {
                return;
            }
            else
            {
                try
                {
                    if (GridViewSobrantes.RowCount > 0)
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

        

        private void GridViewSobrantes_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (GridViewSobrantes .RowCount > 0)
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
                    else if (e.CellElement.ColumnInfo.HeaderText == "Sobrante")
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
        #endregion
    }
}
