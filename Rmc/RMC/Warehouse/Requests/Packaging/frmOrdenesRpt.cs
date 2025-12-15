using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Rmc.Reportes;
using Rmc.Reportes.ReportesDesign;
using Rmc.Reportes.ReportesForm;
using System.Linq;
namespace Rmc.Reportes.ReportesForm
{
    public partial class frmOrdenesRpt : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        dsPMC ds = new dsPMC();
        AniosTableAdapter anio = new AniosTableAdapter();
        SemanasTableAdapter semana1 = new SemanasTableAdapter();

        RptSolicitudPorSemanaTableAdapter TaSemana = new RptSolicitudPorSemanaTableAdapter();
        RptSolicitudPorFechaTableAdapter TaFecha = new RptSolicitudPorFechaTableAdapter();
        RptEntregasTableAdapter TaEntrega = new RptEntregasTableAdapter();
        RptEntregaTableAdapter ImpEntrega = new RptEntregaTableAdapter();
        ReporteSolicitudSobreTableAdapter entrega = new  ReporteSolicitudSobreTableAdapter();
        ReportesSolicitudSobreFechaTableAdapter entregaFecha = new ReportesSolicitudSobreFechaTableAdapter();

        ExEntregaSemanaTableAdapter ExEntrega = new ExEntregaSemanaTableAdapter();
        string bandera = "";

        public frmOrdenesRpt()
        {
            InitializeComponent();
            DtFecha1.Value = DateTime.Now;
            DtFecha2.Value = DateTime.Now;
            BtnGenerar.RootElement.ToolTipText = "Presione F5 ";
            BtnImprimir.RootElement.ToolTipText = "Presione Ctrl+P ";

            GridViewExportar.SendToBack();
            ((GridTableElement)this.GridViewOrdenes.TableElement).AlternatingRowColor = Color.Azure;
            ((GridTableElement)this.GridViewExportar.TableElement).AlternatingRowColor = Color.Azure;

        }
        #endregion



        #region METODOS
        private void ReportepPorSemana()
        {
            try
            {
              
                    DataTable datos = new DataTable();
                    DataTable GenDatos = new DataTable();
                    DataTable Tfinal = new DataTable();
                    entrega.Fill(ds.ReporteSolicitudSobre, CbxSemana1.Text.Trim(), CbxSemana2.Text.Trim());
                    GenDatos = (DataTable)ds.Tables["ReporteSolicitudSobre"];
                    GenDatos.DefaultView.Sort = "sol_semana ASC";

                    GenDatos = GenDatos.DefaultView.ToTable();
                    var semanas = GenDatos.AsEnumerable().Select(x => x.Field<string>("sol_semana")).Distinct().ToList();
                    int contadorReporte = 0;
             
                    foreach (var item in semanas)
                    {
                        datos = (GenDatos.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());
                    datos.Columns.Add("TIPO_ENTREGA", typeof(String));

                        using (dcPmcDataContext db = new dcPmcDataContext())
                        {
                      

                        ExEntrega.Fill(ds.ExEntregaSemana, item.Trim());

                        var Entregas = ((DataTable)ds.Tables["ExEntregaSemana"]);//.AsEnumerable().Select(x => x.Field<int>("ent_ID")).ToList();

                     //  var Entregas = GenDatos.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).Select(j => j.Field<int>("ent_ID")).Distinct().ToList();

                      
                           

                        #region REGULARES
                        DataTable datosRegular = new DataTable();
                            DataTable datoscompleto = new DataTable();
                           entrega.Fill(ds.ReporteSolicitudSobre, CbxSemana1.Text.Trim(), CbxSemana2.Text.Trim());
                            datoscompleto = (DataTable)ds.Tables["ReporteSolicitudSobre"];
                            datoscompleto.DefaultView.Sort = "sol_semana ASC";
                            datoscompleto = datoscompleto.DefaultView.ToTable();

                      


                            datosRegular = (datoscompleto.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());
                            datosRegular.Columns.Add("TIPO_ENTREGA", typeof(String));
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
                                dr["TIPO_ENTREGA"] = "Regular";
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

                                    queda = sumItem - Convert.ToInt32(sumItemSol);
                                    quedaTotal = sumItem - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);
                                dr["TIPO_ENTREGA"] = "Regular";
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
                        foreach (DataRow IDE in Entregas.Rows)
                        {
                           
                            var DatosRegulares = datosRegular.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(IDE["ent_ID"]) && ss.Field<int>("sol_cant_entregada") > 0).ToList();

                            if (DatosRegulares.Count > 0)

                                Tfinal.Merge(DatosRegulares.CopyToDataTable());
                            {
                               
                            }
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
                                    dx["TIPO_ENTREGA"] = "Sobreconsumo";
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
                                      dx["TIPO_ENTREGA"] = "Sobreconsumo";
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
                        foreach (DataRow IDE in Entregas.Rows)
                        {

                            var DatosSobreconsumo = datos.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(IDE["ent_ID"]) && ss.Field<bool>("sol_sobreconsumo") == true);

                            if (DatosSobreconsumo.Count() > 0)
                            {


                                Tfinal.Merge(DatosSobreconsumo.CopyToDataTable());
                              
                            }
                            #endregion
                        }
                        }



                    

                    }
                Tfinal.DefaultView.Sort = "ent_ID ASC,sol_ID ASC";

                Tfinal = Tfinal.DefaultView.ToTable();
                Tfinal.Columns.Remove("ent_sol_ID");
                Tfinal.Columns.Remove("sol_sobreconsumo");
                GridViewExportar.DataSource = Tfinal;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message );
            }
        }




        private void ReportepPorFecha()
        {
            try
            {

                DataTable datos = new DataTable();
                DataTable GenDatos = new DataTable();
                DataTable Tfinal = new DataTable();
                entregaFecha.Fill(ds.ReportesSolicitudSobreFecha, DtFecha1.Value, DtFecha2.Value);
                GenDatos = (DataTable)ds.Tables["ReportesSolicitudSobreFecha"];
                GenDatos.DefaultView.Sort = "sol_semana ASC";

                GenDatos = GenDatos.DefaultView.ToTable();
                var semanas = GenDatos.AsEnumerable().Select(x => x.Field<string>("sol_semana")).Distinct().ToList();
                int contadorReporte = 0;

                foreach (var item in semanas)
                {
                    datos = (GenDatos.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());
                    datos.Columns.Add("TIPO_ENTREGA", typeof(String));

                    using (dcPmcDataContext db = new dcPmcDataContext())
                    {


                        ExEntrega.Fill(ds.ExEntregaSemana, item.Trim());

                        var Entregas = ((DataTable)ds.Tables["ExEntregaSemana"]);
                      //  var Entregas = GenDatos.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).Select(j => j.Field<int>("ent_ID")).Distinct().ToList();




                        #region REGULARES
                        DataTable datosRegular = new DataTable();
                        DataTable datoscompleto = new DataTable();
                        entregaFecha.Fill(ds.ReportesSolicitudSobreFecha, DtFecha1.Value, DtFecha2.Value);
                        datoscompleto = (DataTable)ds.Tables["ReportesSolicitudSobreFecha"];
                        datoscompleto.DefaultView.Sort = "sol_semana ASC";
                        datoscompleto = datoscompleto.DefaultView.ToTable();




                        datosRegular = (datoscompleto.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());
                        datosRegular.Columns.Add("TIPO_ENTREGA", typeof(String));
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
                                dr["TIPO_ENTREGA"] = "Regular";
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

                                queda = sumItem - Convert.ToInt32(sumItemSol);
                                quedaTotal = sumItem - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);
                                dr["TIPO_ENTREGA"] = "Regular";
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
                        foreach (DataRow  ID_ENTREGA in Entregas.Rows)
                        {

                            var DatosRegulares = datosRegular.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(ID_ENTREGA["ent_ID"]) && ss.Field<int>("sol_cant_entregada") > 0).ToList();

                            if (DatosRegulares.Count > 0)

                                Tfinal.Merge(DatosRegulares.CopyToDataTable());
                            {

                            }
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
                                    dx["TIPO_ENTREGA"] = "Sobreconsumo";
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
                                    dx["TIPO_ENTREGA"] = "Sobreconsumo";
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
                        foreach (DataRow ID_ENTREGA in Entregas.Rows)
                        {

                            var DatosSobreconsumo = datos.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(ID_ENTREGA["ent_ID"]) && ss.Field<bool>("sol_sobreconsumo") == true);

                            if (DatosSobreconsumo.Count() > 0)
                            {


                                Tfinal.Merge(DatosSobreconsumo.CopyToDataTable());

                            }
                            #endregion
                        }
                    }





                }
                Tfinal.DefaultView.Sort = "ent_ID ASC,sol_ID ASC";

                Tfinal = Tfinal.DefaultView.ToTable();
                Tfinal.Columns.Remove("ent_sol_ID");
                Tfinal.Columns.Remove("sol_sobreconsumo");
                GridViewExportar.DataSource = Tfinal;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion


        #region EVENTOS
        private void ItemExportar_Click(object sender, EventArgs e)
        {
            try
            {

                if (GridViewOrdenes.RowCount > 0)
                {
                    GridViewExportar.Columns["TIPO_ENTREGA"].IsVisible = false;
                    GridViewOrdenes.SelectAll();
                    // Semana
                    if (RdoSemana.IsChecked == true)
                    {
                        if (CbxSemana1.Text.Trim() != "" && CbxSemana2.Text.Trim() != "")
                        {

                            
                            TaSemana.Fill(ds.RptSolicitudPorSemana, CbxSemana1.Text.Trim(), CbxSemana2.Text.Trim());
                            var datos = (DataTable)ds.Tables["RptSolicitudPorSemana"];
                           GridViewExportar.DataSource = datos;
                        }

                    }
                    // Fechas
                    else if (RdoFecha.IsChecked == true)
                    {
                        if (DtFecha1.Text.Trim() != "" && DtFecha2.Text.Trim() != "")
                        {
                            TaFecha.Fill(ds.RptSolicitudPorFecha, DtFecha1.Value, DtFecha2.Value);
                            var datos = (DataTable)ds.Tables["RptSolicitudPorFecha"];
                            GridViewExportar.DataSource = datos;
                        }
                    }
                    // Entregas
                    else if (RdoEntrega.IsChecked == true)
                    {
                        if (DtFecha1.Text.Trim() != "" && DtFecha2.Text.Trim() != "")
                        {
                            TaFecha.Fill(ds.RptSolicitudPorFecha, DtFecha1.Value, DtFecha2.Value);
                            var datos = (DataTable)ds.Tables["RptEntregas"];
                            GridViewExportar.DataSource = datos;
                        }
                    }

                    for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                    {
                        GridViewExportar.Columns[i].BestFit();
                        // GridViewExportar.Columns[i].Width = 180;
                        GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                        GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                    }
                    GridViewExportar.Columns["sol_semana"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                    GridViewExportar.Columns["sol_FH_crea"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;
                    GridViewExportar.Columns["sol_FH_modifica"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;
                    GridViewExportar.Columns["sol_FH_entrega"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;


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



        private void ItemDetExportar_Click(object sender, EventArgs e)
        {
            try
            {

                if (GridViewOrdenes.RowCount > 0)
                {

                    this.Enabled = false;
                    GridViewExportar.Columns["TIPO_ENTREGA"].IsVisible = true;

                    GridViewOrdenes.SelectAll();
                    // Semana
                    if (RdoSemana.IsChecked == true)
                    {
                        if (CbxSemana1.Text.Trim() != "" && CbxSemana2.Text.Trim() != "")
                        {


                            ReportepPorSemana();
                            //Waiting.StopWaiting();

                        }

                    }
                    // Fechas
                    else if (RdoFecha.IsChecked == true)
                    {
                        if (DtFecha1.Text.Trim() != "" && DtFecha2.Text.Trim() != "")
                        {
                            ReportepPorFecha();
                        }
                    }
                   

                    for (int i = 0; i < GridViewExportar.Columns.Count; i++)
                    {
                        GridViewExportar.Columns[i].BestFit();
                        // GridViewExportar.Columns[i].Width = 180;
                        GridViewExportar.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                        GridViewExportar.Columns[i].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.None;
                    }
                    GridViewExportar.Columns["sol_semana"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Text;
                    GridViewExportar.Columns["sol_FH_crea"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;
                    GridViewExportar.Columns["sol_FH_modifica"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;
                    GridViewExportar.Columns["sol_FH_entrega"].ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDateTime;


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

                    POP_ALERT.CaptionText = "Exito";
                    POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                    POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                    POP_ALERT.ThemeName = "Windows8";
                    POP_ALERT.ContentText = "Exportación Realizada...";
                    POP_ALERT.Show();
                    this.Enabled = true;

                }
                else
                {
                    MessageBox.Show("No es posible Exportar");
                    this.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void RdoSemana_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (RdoSemana.IsChecked == true)
                {
                    PanelFecha.Visible = false;
                    PanelSemana.Visible = true;
                    PanelFecha.SendToBack();
                    PanelSemana.BringToFront();
                    bandera = "SEMANA";
                    PanelEntrega.Visible = false;
                    PanelEntrega.SendToBack();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RdoFecha_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (RdoFecha.IsChecked == true)
                {
                    // PanelFecha.Location = new Point(55, 85);
                    PanelFecha.Visible = true;
                    PanelSemana.Visible = false;
                    PanelEntrega.Visible = false;
                    PanelEntrega.SendToBack();
                    PanelFecha.BringToFront();
                    PanelSemana.SendToBack();
                    bandera = "FECHA";

                }
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
              
                // backgroundWorker1.RunWorkerAsync();
               
                GridViewExportar.Columns["TIPO_ENTREGA"].IsVisible = false;
                if (RdoSemana.IsChecked == true)
                {
                    if (CbxSemana1.Text.Trim() != "" && CbxSemana2.Text.Trim() != "")
                    {
                        TaSemana.Fill(ds.RptSolicitudPorSemana, CbxSemana1.Text.Trim(), CbxSemana2.Text.Trim());
                        var datos = (DataTable)ds.Tables["RptSolicitudPorSemana"];
                        GridViewOrdenes.DataSource = datos;
                    }

                }
                else if (RdoFecha.IsChecked == true)
                {
                    if (DtFecha1.Text.Trim() != "" && DtFecha2.Text.Trim() != "")
                    {
                        TaFecha.Fill(ds.RptSolicitudPorFecha, DtFecha1.Value, DtFecha2.Value);
                        var datos = (DataTable)ds.Tables["RptSolicitudPorFecha"];
                        GridViewOrdenes.DataSource = datos;
                    }
                }
                else if (RdoEntrega.IsChecked == true)
                {
                    if (TxtEntrega.Text.Trim() != "" && TxtEntrega.Text.Trim() != "0")
                    {
                        TaEntrega.Fill(ds.RptEntregas, Convert.ToInt32(TxtEntrega.Text.Trim()));
                        var datos = (DataTable)ds.Tables["RptEntregas"];

                        GridViewOrdenes.DataSource = datos;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmOrdenesRpt_Load(object sender, EventArgs e)
        {


            try
            {
               // Waiting.SendToBack();
                GridViewExportar.SendToBack();
                anio.Fill(ds.Anios);
                cbxAnio.DataSource = ds.Tables["Anios"];


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DdlAnio_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                semana1.Fill(ds.Semanas, cbxAnio.Text.Trim());


                var semanas = (DataTable)ds.Tables["Semanas"];
                CbxSemana1.DataSource = semanas;
                foreach (var item in CbxSemana1.Items)
                {
                    if (CbxSemana2.Items.Count == CbxSemana1.Items.Count)
                    {
                        break;
                    }
                    else
                    {
                        CbxSemana2.Items.Add(item.Text);
                    }

                }
                CbxSemana2.SelectedIndex = 0;

                //  CbxSemana2.DataSource = semanas2;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewOrdenes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (GridViewOrdenes.RowCount > 0)
                {
                    GridViewOrdenes.SelectAll();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GridViewOrdenes_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            try
            {

                RadMenuItem ItemExportar = new RadMenuItem("Exportar a Excel");
                // ItemExportar.ForeColor = Color.Red;
                ItemExportar.Click += new EventHandler(ItemExportar_Click);
                e.ContextMenu.Items.Add(ItemExportar);
                if (RdoEntrega.IsChecked == false)
                {


                    RadMenuItem ItemExportarDet = new RadMenuItem("Exportar Detallado a Excel");
                    //ItemExportarDet.ForeColor = Color.Red;
                    ItemExportarDet.Click += new EventHandler(ItemDetExportar_Click);
                    e.ContextMenu.Items.Add(ItemExportarDet);
                }
                if (RdoEntrega.IsChecked == true)
                {
                    RadMenuItem ItemImprimir = new RadMenuItem("Imprimir");
                    e.ContextMenu.Items.Add(ItemImprimir);
                    ItemImprimir.Click += new EventHandler(BtnImprimir_Click);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

      
        private void RdoEntrega_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                if (RdoEntrega.IsChecked == true)
                {
                    // PanelFecha.Location = new Point(55, 85);
                    TxtEntrega.Focus();
                    PanelFecha.Visible = false;
                    PanelSemana.Visible = false;
                    PanelEntrega.Visible = true;
                    PanelEntrega.BringToFront();
                    PanelFecha.SendToBack();
                    PanelSemana.SendToBack();
                    bandera = "ENTREGA";

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtEntrega_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (RdoEntrega.IsChecked == true)
                        {
                            if (TxtEntrega.Text.Trim() != "" && TxtEntrega.Text.Trim() != "0")
                            {
                                TaEntrega.Fill(ds.RptEntregas, Convert.ToInt32(TxtEntrega.Text.Trim()));
                                var datos = (DataTable)ds.Tables["RptEntregas"];
                                GridViewOrdenes.DataSource = datos;
                            }
                        }
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
                if (keyData == Keys.F5)
                {
                    BtnGenerar.PerformClick();

                }
                else if (keyData == (Keys.Control | Keys.P))
                {
                    BtnImprimir.PerformClick();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (RdoEntrega.IsChecked == true)
                {
                    if (TxtEntrega.Text.Trim() != "" && TxtEntrega.Text.Trim() != "0")
                    {
                        DataTable datos = new DataTable();
                        DataTable GenDatos = new DataTable();

                        ImpEntrega.Fill(ds.RptEntrega, Convert.ToInt32(TxtEntrega.Text.Trim()));
                        GenDatos = (DataTable)ds.Tables["RptEntrega"];
                        GenDatos.DefaultView.Sort = "sol_semana ASC";
                        GenDatos = GenDatos.DefaultView.ToTable();
                        var semanas = GenDatos.AsEnumerable().Select(x => x.Field<string>("sol_semana")).Distinct().ToList();
                        int contadorReporte = 0;
                        foreach (var item in semanas)
                        {
                            datos = (GenDatos.AsEnumerable().Where(x => x.Field<string>("sol_semana").Trim() == item.Trim()).CopyToDataTable());


                            using (dcPmcDataContext db = new dcPmcDataContext())
                            {


                                #region REGULARES
                                DataTable datosRegular = new DataTable();
                                DataTable datoscompleto = new DataTable();
                                ImpEntrega.Fill(ds.RptEntrega, Convert.ToInt32(TxtEntrega.Text.Trim()));
                                datoscompleto = (DataTable)ds.Tables["RptEntrega"];
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

                                        queda = sumItem - Convert.ToInt32(sumItemSol);
                                        quedaTotal = sumItem - Convert.ToInt32(sumItemSol) - Convert.ToInt32(sumItemActual);
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
                                var DatosRegulares = datosRegular.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(TxtEntrega.Text.Trim()) && ss.Field<int>("sol_cant_entregada") > 0).ToList();

                                if (DatosRegulares.Count > 0)
                                {
                                    contadorReporte += 1;
                                    RptEntregaConsumo r1 = new RptEntregaConsumo();
                                    r1.DataSource = DatosRegulares;
                                    r1.ReportParameters["consumo"].Value = "";
                                    r1.ReportParameters["reporte"].Value = "R" + contadorReporte;
                                    frmReportViewer np = new frmReportViewer();
                                    np.reportViewer1.ReportSource = r1;
                                    // np.reportViewer1.RefreshReport();

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
                                var DatosSobreconsumo = datos.AsEnumerable().Where(ss => ss.Field<int>("ent_ID") == Convert.ToInt32(TxtEntrega.Text.Trim()) && ss.Field<bool>("sol_sobreconsumo") == true);

                                if (DatosSobreconsumo.Count() > 0)
                                {
                                    contadorReporte += 1;
                                    RptEntregaConsumo r1 = new RptEntregaConsumo();
                                    r1.DataSource = DatosSobreconsumo.CopyToDataTable();
                                    r1.ReportParameters["consumo"].Value = "SOBRECONSUMO";
                                    r1.ReportParameters["reporte"].Value = "R" + contadorReporte;
                                    frmReportViewer np = new frmReportViewer();
                                    np.reportViewer1.ReportSource = r1;
                                    // np.reportViewer1.RefreshReport();
                                    np.StartPosition = FormStartPosition.WindowsDefaultLocation;

                                    np.Show();


                                }
                                #endregion





                            }

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
