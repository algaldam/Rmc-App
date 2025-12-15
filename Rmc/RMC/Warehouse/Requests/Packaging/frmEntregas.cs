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

using Rmc.Clases.dsPMCTableAdapters;
using Rmc.Reportes;
using Rmc.Reportes.ReportesDesign;
using Rmc.Reportes.ReportesForm;

namespace Rmc.Subidas
{
    public partial class frmEntregas : Telerik.WinControls.UI.RadForm
    {

        # region INICIALIZACION
        SystemClass sc = new SystemClass();


        dsPMC dsp = new dsPMC();
        ListadoSolicitudTableAdapter sol = new ListadoSolicitudTableAdapter();
        RptEntregaTableAdapter TaAdapEntrega = new RptEntregaTableAdapter();
        DataTable dtsol = new DataTable();
        DataTable DTVAL = new DataTable();
        bool flagValidar = false;
        bool flagEstado = false;

        public frmEntregas()
        {
            InitializeComponent();
            GridViewEntrega.Rows.AddNew();
        }
        #endregion


        #region DATOS

        public bool ValidarDatos()
        {
            try
            {
                if (GridViewEntrega.RowCount > 0)
                {

                    //SE crean  y se inicializan  los DataTables necesarios 
                    DataTable dt = new DataTable();
                    flagEstado = false;
                    sol.Fill(dsp.ListadoSolicitud);
                    dtsol = dsp.Tables["ListadoSolicitud"];

                    //dt.Columns.Remove("sol_ID");
                    //dt.Columns.Remove("sol_SACA");
                    //dt.Columns.Remove("Item");
                    //dt.Columns.Remove("Cantidad");
                    //dt.Columns.Remove("ESTADO");
                    dt.Columns.Add("sol_ID", typeof(int));
                    dt.Columns.Add("sol_SACA", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(int));
                    dt.Columns.Add("ESTADO", typeof(string));

                    string Articulo = "";
                    string SACA = "";
                    // Llenado de DataTable dt
                    for (int r = 0; r < this.GridViewEntrega.RowCount; r++)
                    {
                        //Verificacion de campos 
                        if (GridViewEntrega.Rows[r].Cells["sol_SACA"].Value == null || GridViewEntrega.Rows[r].Cells["sol_SACA"].Value.ToString().Trim() == "")
                        {
                            SACA = null;
                        }
                        else
                        {

                            SACA = GridViewEntrega.Rows[r].Cells["sol_SACA"].Value.ToString().Trim();

                        }
                        if (GridViewEntrega.Rows[r].Cells["Item"].Value == null || GridViewEntrega.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                        {
                            Articulo = null;
                        }
                        else
                        {

                            Articulo = GridViewEntrega.Rows[r].Cells["Item"].Value.ToString().Trim();
                        }

                        //Se agregan campos al DataTable
                        dt.Rows.Add(Convert.ToInt32(GridViewEntrega.Rows[r].Cells["sol_ID"].Value), SACA, Articulo,
                                   Convert.ToInt32(GridViewEntrega.Rows[r].Cells["Cantidad"].Value)
                                   );



                    }
                    // Se valida si ID existe en solicitudes
                    if (dtsol.Rows.Count > 0)
                    {

                        var consulta = (from x in dt.AsEnumerable()
                                        select new
                                        {
                                            ID = x.Field<int>("sol_ID")
                                        }
                                            ).Except(from x in dtsol.AsEnumerable()
                                                     select new
                                                     {
                                                         ID = x.Field<int>("sol_ID")

                                                     }).ToList();

                        if (consulta.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows) // 
                            {

                                foreach (var item in consulta)
                                {
                                    if (dr["sol_ID"].ToString() == item.ID.ToString())
                                    {
                                        dr["ESTADO"] = "ERROR";
                                    }
                                }

                            }

                            flagEstado = true;
                            // dt.Columns.Remove("Semana");
                            //dt.Columns.Remove("Item_Desv");
                            GridViewEntrega.DataSource = dt;

                        }
                    }
                    else
                    {
                        // dt.Columns.Remove("Item_Desv");
                        GridViewEntrega.DataSource = (from np in dt.AsEnumerable()
                                                      select new
                                                      {
                                                          ID = np.Field<int>("sol_ID"),
                                                          SACA = np.Field<string>("sol_SACA"),
                                                          item = np.Field<string>("Item"),
                                                          Cantidad = np.Field<int>("Cantidad"),
                                                          ESTADO = "ENCONTRADO"
                                                      }
                                                          ).ToList();
                        flagEstado = true;
                    }

                    if (dtsol.Rows.Count > 0)
                    {

                        foreach (DataRow fila in dt.Rows)
                        {
                            var Identificador = dtsol.AsEnumerable().Where(id => id.Field<int>("sol_ID") == Convert.ToInt32(fila["sol_ID"].ToString())).FirstOrDefault();


                        }


                    }
                    DTVAL = dt;
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

        private void frmEntregas_Load(object sender, EventArgs e)
        {


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // BtnGuardar.Enabled = false;


                #region VALIDAR CELDAS

                for (int r = 0; r < GridViewEntrega.RowCount; r++)
                {
                    if (GridViewEntrega.Rows[r].Cells["sol_ID"].Value == null || GridViewEntrega.Rows[r].Cells["sol_ID"].Value.ToString().Trim() == "")
                    {
                        flagValidar = true;
                        MessageBox.Show("Verificar columna Producto");
                        break;
                    }
                    else if (Convert.ToInt32(GridViewEntrega.Rows[r].Cells["sol_ID"].Value) <= 0)
                    {
                        flagValidar = true;
                        MessageBox.Show("Columna ID no puede contener \nvalores iguales o menores a Cero");
                        break;
                    }
                    else if (GridViewEntrega.Rows[r].Cells["Cantidad"].Value == null || GridViewEntrega.Rows[r].Cells["Cantidad"].Value.ToString().Trim() == "")
                    {
                        flagValidar = true;
                        MessageBox.Show("Verificar columna Cantidad");
                        break;
                    }
                    else if (Convert.ToInt32(GridViewEntrega.Rows[r].Cells["Cantidad"].Value) <= 0)
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
                        //Se actualiza tabla Solicitudes







                        using (dcPmcDataContext db = new dcPmcDataContext())
                        {
                            int NEntrega = 0;
                            int contadorReporte = 0;

                            // USING TRANSACCION 

                            db.Connection.Open();
                            using (var dbTrans = db.Connection.BeginTransaction())
                            {
                                db.Transaction = dbTrans;
                               
                                try
                                {
                                  
                                    #region ACTUALIZAR DATOS DE SOLICITUD ENTREGADA
                                    // Loop para realizar actualizar fila por fila
                                    for (int r = 0; r < GridViewEntrega.RowCount; r++)
                                    {




                                        var Actualizar = db.pmc_Solicitudes.Where(id => id.sol_ID == Convert.ToInt32(GridViewEntrega.Rows[r].Cells["sol_ID"].Value)).FirstOrDefault();
                                        if (Actualizar.sol_cant_entregada != null)
                                        {
                                            if (Actualizar.sol_estado == 1)
                                            {
                                                foreach (DataRow dr in DTVAL.Rows) // 
                                                {


                                                    if (dr["sol_ID"].ToString() == Actualizar.sol_ID.ToString())
                                                    {
                                                        dr["ESTADO"] = "ERROR";
                                                    }

                                                    LblError.Text = "Existe solicitudes que ya fueron entregadas";
                                                }
                                                resultado = "ERROR";
                                            }
                                            else
                                            {

                                                Actualizar.sol_cant_entregada = Convert.ToInt32(GridViewEntrega.Rows[r].Cells["Cantidad"].Value);
                                                Actualizar.sol_usuario_entrega = Environment.UserName;
                                                Actualizar.sol_FH_entrega = DateTime.Now;
                                                Actualizar.sol_estado = 1;
                                                db.SubmitChanges();

                                                var entrega = db.pmc_Entregas.Select(z => z.ent_ID).ToList();
                                                if (entrega.Count() == 0)
                                                {
                                                    NEntrega = 0 + 1;
                                                }
                                                else
                                                {
                                                    if (r > 0)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        NEntrega = Convert.ToInt32(db.pmc_Entregas.Select(z => z.ent_ID).Max()) + 1;

                                                    }

                                                }
                                                // REGISTRO DE ENTREGAS

                                                pmc_Entregas Deliver = new pmc_Entregas
                                                {
                                                    ent_ID = NEntrega,
                                                    ent_sol_ID = Convert.ToInt32(GridViewEntrega.Rows[r].Cells["sol_ID"].Value),
                                                    ent_FH_crea = DateTime.Now,
                                                    ent_usuario_crea = Environment.UserName

                                                };
                                                db.pmc_Entregas.InsertOnSubmit(Deliver);
                                                db.SubmitChanges();
                                            }




                                        }



                                    }

                                    #endregion

                                    dbTrans.Commit();
                                }
                                catch (Exception)
                                {
                                    // Rollback transaction
                                    if (dbTrans != null)
                                        dbTrans.Rollback();
                                    MessageBox.Show("Transaccion no ha podido completarse");
                                    return;
                                }

                            }// END USING TRANSACCION

                          
                            if (resultado == "ERROR")
                                    {
                                        LblError.Visible = true;
                                        BtnGuardar.Enabled = false;
                                        GridViewEntrega.DataSource = DTVAL;
                                    }
                                    else
                                    {
                                        //REPORTE NORMAL Y SOBRECONSUMO

                                        DataTable datos = new DataTable();
                                        DataTable GenDatos = new DataTable();
                                         
                                        TaAdapEntrega.Fill(dsp.RptEntrega, Convert.ToInt32(NEntrega));
                                        GenDatos = (DataTable)dsp.Tables["RptEntrega"];
                                        GenDatos.DefaultView.Sort = "sol_semana ASC";
                                        GenDatos = GenDatos.DefaultView.ToTable();

                                        var semanas = GenDatos.AsEnumerable().Select(x => x.Field<string>("sol_semana")).Distinct().ToList();

                                        foreach (var item in semanas)
                                        {
                                            datos = (GenDatos.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());

                                            #region REGULARES
                                            DataTable datosRegular = new DataTable();
                                            DataTable datoscompleto = new DataTable();

                                            TaAdapEntrega.Fill(dsp.RptEntrega, Convert.ToInt32(NEntrega));

                                            datoscompleto = (DataTable)dsp.Tables["RptEntrega"];
                                            datoscompleto.DefaultView.Sort = "sol_semana ASC";
                                            datoscompleto = datoscompleto.DefaultView.ToTable();



                                            datosRegular = (datoscompleto.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());
                                            foreach (DataRow dr in datosRegular.Rows)
                                            {

                                                int queda;
                                                int quedaTotal;
                                                // REGULARES
                                                if (dr["sol_SACA"] == null || dr["sol_SACA"].ToString().Trim() == "")
                                                {
                                                    var sumItem = db.pmc_Plan.Where(x => x.pla_item == dr["sol_item"].ToString() && x.pla_semana == dr["sol_semana"]).Sum(pr => pr.pla_cantidad);
                                                    var sumItemSol = db.pmc_Solicitudes.Where(x => x.sol_item == dr["sol_item"].ToString() && x.sol_semana == dr["sol_semana"].ToString() && x.sol_ID < Convert.ToInt32(dr["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);
                                                    var sumItemActual = db.pmc_Solicitudes.Where(x => x.sol_item == dr["sol_item"].ToString() && x.sol_semana == dr["sol_semana"].ToString() && x.sol_ID == Convert.ToInt32(dr["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);


                                                    queda = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol);
                                                    quedaTotal = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);
                                                    if (quedaTotal < 0)
                                                    {
                                                        if (queda > 0)
                                                        {
                                                            dr["sol_cant_entregada"] = Convert.ToInt32(dr["sol_cant_entregada"]) - (Math.Abs(quedaTotal));
                                                        }
                                                        else
                                                        {
                                                            dr["sol_cant_entregada"] = 0;
                                                        }

                                                    }

                                                }
                                                // EPC REGULARES
                                                else if (dr["sol_SACA"] != null && dr["sol_SACA"].ToString().Trim() != "")
                                                {
                                                    var sumItem = db.pmc_Plan.Where(x => x.pla_SACA.Trim() == dr["sol_SACA"].ToString() && x.pla_estilo.Trim() == "EPC" && x.pla_semana.Trim() == dr["sol_semana"].ToString()).Sum(pr => pr.pla_cantidad);
                                                    var sumItemSol = db.pmc_Solicitudes.Where(x => x.sol_SACA == dr["sol_SACA"].ToString().Trim() && x.sol_SACA != null && x.sol_semana == dr["sol_semana"].ToString() && x.sol_ID < Convert.ToInt32(dr["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);
                                                    var sumItemActual = db.pmc_Solicitudes.Where(x => x.sol_SACA == dr["sol_SACA"].ToString().Trim() && x.sol_SACA != null && x.sol_semana == dr["sol_semana"].ToString() && x.sol_ID == Convert.ToInt32(dr["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);

                                                    queda = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol);
                                                    quedaTotal = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);
                                                    if (quedaTotal < 0)
                                                    {

                                                        if (queda > 0)
                                                        {
                                                            dr["sol_cant_entregada"] = Convert.ToInt32(dr["sol_cant_entregada"]) - (Math.Abs(quedaTotal));
                                                        }
                                                        else
                                                        {
                                                            dr["sol_cant_entregada"] = 0;
                                                        }
                                                    }


                                                }


                                            }
                                            var DatosRegulares = datosRegular.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(NEntrega) && ss.Field<int>("sol_cant_entregada") > 0).ToList();

                                            if (DatosRegulares.Count > 0)
                                            {
                                                contadorReporte += 1;
                                                RptEntregaConsumo r1 = new RptEntregaConsumo();
                                                r1.DataSource = DatosRegulares;
                                                r1.ReportParameters["consumo"].Value = "";
                                                r1.ReportParameters["reporte"].Value = "R" + contadorReporte;
                                                frmReportViewer np = new frmReportViewer();
                                                np.reportViewer1.ReportSource = r1;
                                                np.Show();
                                            }

                                            #endregion

                                            #region SOBRECONSUMOS
                                            foreach (DataRow dx in datos.Rows)
                                            {

                                                int queda;
                                                int quedaTotal;
                                                // SE VERIFICA PARA REPORTES REGULARES SI CONTIENEN CANTIDADES DE SOBRECONSUMO
                                                if (dx["sol_SACA"] == null || dx["sol_SACA"].ToString().Trim() == "")
                                                {
                                                    var sumItem = db.pmc_Plan.Where(x => x.pla_item.Trim() == dx["sol_item"].ToString().Trim() && x.pla_semana.Trim() == dx["sol_semana"].ToString().Trim()).Sum(pr => pr.pla_cantidad);
                                                    var sumItemSol = db.pmc_Solicitudes.Where(x => x.sol_item.Trim() == dx["sol_item"].ToString().Trim() && x.sol_semana == dx["sol_semana"].ToString() && x.sol_ID < Convert.ToInt32(dx["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);
                                                    var sumItemActual = db.pmc_Solicitudes.Where(x => x.sol_item.Trim() == dx["sol_item"].ToString().Trim() && x.sol_semana == dx["sol_semana"].ToString() && x.sol_ID == Convert.ToInt32(dx["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);

                                                    queda = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol);
                                                    quedaTotal = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);

                                                    if (quedaTotal < 0)
                                                    {
                                                        dx["sol_sobreconsumo"] = true;
                                                        if (queda < 0)
                                                        {
                                                            dx["sol_cant_entregada"] = Convert.ToInt32(sumItemActual);
                                                        }
                                                        else if (queda < Convert.ToInt32(sumItemActual))
                                                        {
                                                            dx["sol_cant_entregada"] = Convert.ToInt32(sumItemActual) + Convert.ToInt32(sumItemSol) - Math.Abs(sumItem);
                                                        }
                                                        else
                                                        {
                                                            dx["sol_cant_entregada"] = Convert.ToInt32(sumItemSol) - Math.Abs(sumItem);
                                                        }


                                                    }
                                                    else
                                                    {
                                                        dx["sol_sobreconsumo"] = false;
                                                    }

                                                }
                                                // SE VERIFICA PARA REPORTES DE EPC SI CONTIENEN CANTIDADES DE SOBRECONSUMO
                                                else if (dx["sol_SACA"] != null && dx["sol_SACA"].ToString().Trim() != "")
                                                {
                                                    var sumItem = db.pmc_Plan.Where(x => x.pla_SACA.Trim() == dx["sol_SACA"].ToString() && x.pla_estilo.Trim() == "EPC" && x.pla_semana.Trim() == dx["sol_semana"].ToString()).Sum(pr => pr.pla_cantidad);
                                                    var sumItemActual = db.pmc_Solicitudes.Where(x => x.sol_SACA == dx["sol_SACA"].ToString().Trim() && x.sol_SACA != null && x.sol_semana == dx["sol_semana"].ToString() && x.sol_ID == Convert.ToInt32(dx["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);
                                                    var sumItemSol = db.pmc_Solicitudes.Where(x => x.sol_SACA == dx["sol_SACA"].ToString().Trim() && x.sol_SACA != null && x.sol_semana == dx["sol_semana"].ToString() && x.sol_ID < Convert.ToInt32(dx["ent_sol_ID"])).Sum(pr => pr.sol_cant_entregada);
                                                    queda = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol);
                                                    quedaTotal = Convert.ToInt32(sumItem) - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);

                                                    if (quedaTotal < 0)
                                                    {
                                                        dx["sol_sobreconsumo"] = true;
                                                        if (queda < 0)
                                                        {
                                                            dx["sol_cant_entregada"] = Convert.ToInt32(sumItemActual);
                                                        }
                                                        else if (queda < Convert.ToInt32(sumItemActual))
                                                        {
                                                            dx["sol_cant_entregada"] = Convert.ToInt32(sumItemActual) + Convert.ToInt32(sumItemSol) - Math.Abs(sumItem);
                                                        }
                                                        else
                                                        {
                                                            dx["sol_cant_entregada"] = Convert.ToInt32(sumItemSol) - Math.Abs(sumItem);
                                                        }


                                                    }
                                                    else
                                                    {
                                                        dx["sol_sobreconsumo"] = false;
                                                    }

                                                }


                                            }
                                            var DatosSobreconsumo = datos.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(NEntrega) && ss.Field<bool>("sol_sobreconsumo") == true);

                                            if (DatosSobreconsumo.Count() > 0)
                                            {
                                                contadorReporte += 1;
                                                RptEntregaConsumo r1 = new RptEntregaConsumo();
                                                r1.DataSource = DatosSobreconsumo.CopyToDataTable();
                                                r1.ReportParameters["consumo"].Value = "SOBRECONSUMO";
                                                r1.ReportParameters["reporte"].Value = "R" + contadorReporte;
                                                frmReportViewer np = new frmReportViewer();
                                                np.reportViewer1.ReportSource = r1;
                                                np.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                                np.Show();
                                            }
                                            #endregion



                                        }

                                        POP_ALERT.CaptionText = "Exito";
                                        POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                                        POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                                        POP_ALERT.ThemeName = "Breeze";
                                        POP_ALERT.ContentText = "Proceso Correcto...";
                                        POP_ALERT.Show();
                                        GridViewEntrega.DataSource = null;
                                        this.GridViewEntrega.Rows.Clear();
                                        GridViewEntrega.Rows.AddNew();

                                     // Actualizar numero de reportes
                                        using (dcPmcDataContext bde = new dcPmcDataContext())
                                        {

                                            foreach (var Actualizarentrega in bde.pmc_Entregas.Where(id => id.ent_ID == NEntrega).ToList())
                                            {
                                                Actualizarentrega.ent_num_reporte = contadorReporte;
                                            }
                                            bde.SubmitChanges();
                                            //  var Actualizarentrega = bde.pmc_Entregas.Where(id => id.ent_ID== NEntrega).FirstOrDefault();


                                        }
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {

                GridViewEntrega.DataSource = null;
                this.GridViewEntrega.Rows.Clear();
                GridViewEntrega.Rows.AddNew();
                GridViewEntrega.Refresh();
                LblError.Visible = false;
                BtnGuardar.Enabled = true;
                flagValidar = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewEntrega_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (e.RowElement.RowInfo.Index == -1)
            {
                return;
            }
            else
            {
                try
                {
                    if (GridViewEntrega.RowCount > 0)
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

        private void GridViewEntrega_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            try
            {
                if (GridViewEntrega.RowCount > 0)
                {
                    if (e.CellElement.ColumnInfo.HeaderText == "Solicitud")
                    {
                        if (e.CellElement.RowInfo.Cells["sol_ID"].Value == null || e.CellElement.RowInfo.Cells["sol_ID"].Value.ToString().Trim() == "")
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
