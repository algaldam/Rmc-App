
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
using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;


namespace Rmc.Subidas
{
    public partial class frmCargaSolicitudesEPC : Telerik.WinControls.UI.RadForm
    {

        # region INICIALIZACION
        SystemClass sc = new SystemClass();
        

        dsStageArea dsa = new dsStageArea();
        dsPMC dsp = new dsPMC();
        PlanSemanaTableAdapter plta = new PlanSemanaTableAdapter();
        DataTable dtPlan = new DataTable();
        bool flagValidar = false;
        bool flagEstado = false;
        public frmCargaSolicitudesEPC()
        {
            InitializeComponent();
            GridViewSolicitud.Rows.AddNew();
        }


        #endregion


        #region DATOS

        public bool ValidarDatos()
        {
            try
            {
                if (GridViewSolicitud.RowCount > 0)
                {
                    //SE crean  y se inicializan  los DataTables necesarios 
                    DataTable dt = new DataTable();


                    flagEstado = false;
                    plta.Fill(dsp.PlanSemana, CbxSemana.Text.Trim());
                    var datos = dsp.Tables["PlanSemana"];
                    dtPlan = (DataTable) datos;
                    dt.Columns.Add("Semana", typeof(string));
                    dt.Columns.Add("sol_SACA", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(int));
                    dt.Columns.Add("SOBRE_CONSUMO", typeof(bool));
                    dt.Columns.Add("ESTADO", typeof(string));

                   // string Articulo = "";
                    //Llenado de DataTable dt
                    for (int r = 0; r < this.GridViewSolicitud.RowCount; r++)
                    {

                        object obj = GridViewSolicitud.Rows[r].Cells["Item"].Value;
                        string Item = "";
                        if (obj != null)
                        {
                            Item = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                        }
                        dt.Rows.Add(CbxSemana.Text.Trim(), GridViewSolicitud.Rows[r].Cells["sol_SACA"].Value.ToString().ToUpper (), 
                                   Item,
                                    Convert.ToInt32(GridViewSolicitud.Rows[r].Cells["Cantidad"].Value.ToString().Trim()),
                                    Convert.ToBoolean( GridViewSolicitud.Rows[r].Cells["SOBRE_CONSUMO"].Value));



                    }
                    // Se valida si Item existe en el plan correspondinete a la semana seleccionada
                    if (dtPlan.Rows.Count > 0)
                    {

                        var consulta = (from x in dt.AsEnumerable()
                                        select new
                                        {
                                            Semana = x.Field<string>("Semana"),
                                            SACA = x.Field<string>("sol_SACA")
                                        }
                                            ).Except(from x in dtPlan.AsEnumerable()
                                                     select new
                                                     {
                                                         Semana = x.Field<string>("pla_semana"),
                                                         SACA = x.Field<string>("pla_SACA")
                                                     }).ToList();

                        if (consulta.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows) // search whole table
                            {

                                foreach (var item in consulta)
                                {
                                    if (dr["Semana"].ToString() == item.Semana.ToString() && dr["sol_SACA"].ToString() == item.SACA.ToString()) // if id==2
                                    {
                                        dr["ESTADO"] = "ENCONTRADO";
                                    }
                                }

                            }

                            flagEstado = true;
                           
                            //dt.Columns.Remove("Item_Desv");
                           // GridViewSolicitud.DataSource = dt;

                        }


                        using (dcPmcDataContext db = new dcPmcDataContext())
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Convert.ToBoolean(dr["SOBRE_CONSUMO"]) == false)
                                {
                                    var sumItem = dtPlan.AsEnumerable().Where(x => x.Field<string>("pla_SACA").Trim () == dr["sol_SACA"].ToString() && x.Field<string>("pla_estilo").Trim ()=="EPC" && x.Field<string>("pla_semana").Trim()==dr["Semana"].ToString()).Sum(pr => pr.Field<int>("pla_cantidad"));
                                    var sumItemSol = db.pmc_Solicitudes.Where(x => x.sol_SACA == dr["sol_SACA"].ToString().Trim () && x.sol_SACA != null  && x.sol_semana == dr["Semana"].ToString()).Sum(pr => pr.sol_cant_entregada);
                                    if (Convert.ToInt32(sumItem) > 0)
                                    {

                                        int queda = sumItem - Convert.ToInt32(sumItemSol);
                                        if (Convert.ToInt32(dr["Cantidad"]) > queda)
                                        {
                                            dr["ESTADO"] = "SOBRE";
                                            flagEstado = true;
                                        }
                                    }
                                }


                            }
                        }
                        dt.Columns.Remove("Semana");
                       // dt.Columns.Remove("Item_Desv");
                       // GridViewSolicitud.DataSource = null;
                        GridViewSolicitud.DataSource = dt;

                    }
                    else
                    {
                       // dt.Columns.Remove("Item_Desv");
                        GridViewSolicitud.DataSource = (from np in dt.AsEnumerable()
                                                        select new
                                                        {
                                                            Semana = np.Field<string>("Semana"),
                                                            SACA = np.Field<string>("sol_SACA"),
                                                            Item = np.Field<string>("Item"),
                                                            Cantidad = np.Field<int>("Cantidad"),
                                                            ESTADO = "ENCONTRADO"
                                                        }
                                                          ).ToList();
                        flagEstado = true;
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

        private void frmSolicitudesEPC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tracerDataSet.WeekPlan' table. You can move, or remove it, as needed.
            using (dcPmcDataContext db = new dcPmcDataContext())
            {
                var semanas = (from x in db.pmc_Semanas
                               where x.sem_estado == true
                               orderby x.sem_ID descending
                               select x).ToList();
                CbxSemana.DataSource = semanas;
            }

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewSolicitud.DataSource = null;
                this.GridViewSolicitud.Rows.Clear();
                GridViewSolicitud.Rows.AddNew();
                GridViewSolicitud.Refresh();
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
               // BtnGuardar.Enabled = false;
                LblError.Visible = false;
                if (CbxSemana.Text.Trim() == "" || CbxSemana.Text.Trim() == "0000-00")
                {
                    CbxSemana.BackColor = Color.MistyRose;
                }
                else
                {
                    #region VALIDAR CELDAS

                    for (int r = 0; r < GridViewSolicitud.RowCount; r++)
                    {
                        if (GridViewSolicitud.Rows[r].Cells["sol_SACA"].Value == null || GridViewSolicitud.Rows[r].Cells["sol_SACA"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna SACA");
                            break;
                        }
                        else if (GridViewSolicitud.Rows[r].Cells["Cantidad"].Value == null || GridViewSolicitud.Rows[r].Cells["Cantidad"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Cantidad");
                            break;
                        }
                        else if (Convert.ToInt32(GridViewSolicitud.Rows[r].Cells["Cantidad"].Value) <= 0)
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
                           
                            #region INSERCION
                            //Se inserta en la tabla solicitudes utilizando el procedimiento almencenado
                            using (dcPmcDataContext db = new dcPmcDataContext())
                            {

                                // Loop para realizar insertar fila por fila del grid a la base de datos
                                for (int r = 0; r < GridViewSolicitud.RowCount; r++)
                                {
                                    string Articulo = "";
                                    string desviado = null;
                                    // Se verifica si el usuario desea que el articulo sea desviado o no 
                                    if (GridViewSolicitud.Rows[r].Cells["Item"].Value == null || GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                                    {
                                        var valor = dtPlan.AsEnumerable().Where(x => x.Field<string>("pla_semana") == CbxSemana.Text.Trim()
                                              && x.Field<string>("pla_SACA").ToString ().Trim () == GridViewSolicitud.Rows[r].Cells["sol_SACA"].Value.ToString().Trim().ToUpper()
                                                                        && x.Field<string>("pla_estilo").ToString ().Trim ()=="EPC")                                                                       
                                                                     .Select(y => y.Field<string>("pla_item")).FirstOrDefault();

                                        if (valor!=null )
                                        {
                                            Articulo = valor.ToString().Trim();
                                           // desviado = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                                        }
                                           
                                        
                                    }
                                    else
                                    {
                                        Articulo = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                                    }

                                    var varEpc = dtPlan.AsEnumerable().Where(x => x.Field<string>("pla_semana") == CbxSemana.Text.Trim()
                                                                        && x.Field<string>("pla_SACA").ToString().Trim () == GridViewSolicitud.Rows[r].Cells["sol_SACA"].Value.ToString().Trim().ToUpper ()
                                                                        &&  x.Field<string>("pla_item").ToString().Trim ()==Articulo.ToUpper ())
                                                                     .Select(y => y.Field<string>("pla_estilo")).FirstOrDefault();
                                    if (varEpc != null)
                                    {
                                        if (varEpc.ToString().Trim() == "EPC")
                                        {
                                            //Se ejecuta el procedimiento almacenado
                                    
                                            var msg = db.usp_pmc_Solicitudes_CRUD(1, CbxSemana.Text.Trim(), GridViewSolicitud.Rows[r].Cells["sol_SACA"].Value.ToString().Trim().ToUpper(),
                                                                                            Articulo.ToUpper (), null, Convert.ToInt32(GridViewSolicitud.Rows[r].Cells["Cantidad"].Value),
                                                                                            false, Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["SOBRE_CONSUMO"].Value),"", 'C');
                                            // Se obtiene el Resultado de la ejecucion del procedimiento almacenado
                                            resultado = msg.Select(x => x.Column1).FirstOrDefault();
                                        }
                                        else
                                        {
                                           
                                            MessageBox.Show("SACA no Registrado como EPC ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("SACA no registrado como EPC \n En semana Seleccionada ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                    

                                }
                            }

#endregion

                            if (resultado == "OK")
                            {

                                GridViewSolicitud.DataSource = null;
                                this.GridViewSolicitud.Rows.Clear();
                                GridViewSolicitud.Rows.AddNew();
                                CbxSemana.Text = "0000-00";
                                BtnGuardar.Enabled = true;
                                MessageBox.Show("\n Proceso Realizado \n con Éxito \n", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            }
                            else
                            {
                                MessageBox.Show("Error al cargar solicitudes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                GridViewSolicitud.DataSource = null;
                                this.GridViewSolicitud.Rows.Clear();
                                GridViewSolicitud.Rows.AddNew();
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

        private void GridViewSolicitud_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            try
            {
                //Formato a filas según el estado
                if (GridViewSolicitud.RowCount > 0)
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

        private void CbxSemana_Click(object sender, EventArgs e)
        {
            CbxSemana.BackColor = Color.White;
        }
        
        private void GridViewSolicitud_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                // Formato a celda según el valor contenido
                if (GridViewSolicitud.RowCount > 0)
                {

                    if (e.CellElement.ColumnInfo.HeaderText == "SA/CA")
                    {
                        if (e.CellElement.RowInfo.Cells["sol_SACA"].Value == null || e.CellElement.RowInfo.Cells["sol_SACA"].Value.ToString().Trim() == "")
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
