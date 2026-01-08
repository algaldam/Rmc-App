using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.MaterialEmpaque
{
    public partial class ReporteriaInventario : Telerik.WinControls.UI.RadForm
    {
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        SystemClass sc = new SystemClass();
        SqlCommand cm = null;
        public ReporteriaInventario()
        {
            InitializeComponent();
        }
        private void frm_Inventario_Por_Area_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable miDt = new DataTable();
                miDt.Columns.Add("ID", typeof(string));
                miDt.Columns.Add("Descripcion", typeof(String));
                miDt.Rows.Add("STK", "STICKERADO");
                miDt.Rows.Add("TBL", "MESAS");
                miDt.Rows.Add("BIN", "CAJAS BIN");
                miDt.Rows.Add("FINN", "FINISHING");
                miDt.Rows.Add("DEV", "DEVOLUCIONES");
                miDt.Rows.Add("TT", "TODAS LAS AREAS");
                this.lswAreas.DisplayMember = "Descripcion";
                this.lswAreas.ValueMember = "ID";
                this.lswAreas.DataSource = miDt;
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Llenado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LlenadoGrid()
        {
        }
        private void lswAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridInventario.Columns.Clear();
            if (lswAreas.SelectedItems.Count > 0)
            {
                String selectedVal = lswAreas.SelectedItems[0].Value.ToString();
                if (selectedVal == "STK")
                {
                    String Q = @"SELECT [Item]
                                ,[Descripción]
                                ,[Cantidad]
                                ,[Localidad]
                                ,[ID_Caja]
                                ,[Status]
                                ,[Devolucion]
                                ,[Usuario]
                                ,[Fecha]
                                ,[TraceID]
                            FROM [pmc_Inventario] WHERE STATUS= 'STK' ";
                    sc.OpenConectionTracer();
                    using (SqlCommand cmd = new SqlCommand(Q, sc.OpenConectionTracer()))
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            GridInventario.AutoGenerateColumns = true;
                            adp.Fill(ds);
                            Console.WriteLine("Número de filas en el conjunto de datos: " + ds.Tables[0].Rows.Count);
                            GridInventario.DataSource = ds.Tables[0];
                            GridInventario.Columns["Item"].HeaderText = "Item";
                            GridInventario.Columns["Descripción"].HeaderText = "Descripción";
                            GridInventario.Refresh();
                        }
                    }
                }
                else if (selectedVal == "TBL")
                {
                    String Q = @"SELECT [Item]
                                ,[Descripción]
                                ,[Cantidad]
                                ,[Localidad]
                                ,[ID_Caja]
                                ,[Status]
                                ,[Devolucion]
                                ,[Usuario]
                                ,[Fecha]
                                ,[TraceID]
                            FROM [pmc_Inventario] WHERE STATUS= 'TBL' ";
                    sc.OpenConectionTracer();
                    using (SqlCommand cmd = new SqlCommand(Q, sc.OpenConectionTracer()))
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            GridInventario.AutoGenerateColumns = true;
                            adp.Fill(ds);
                            Console.WriteLine("Número de filas en el conjunto de datos: " + ds.Tables[0].Rows.Count);
                            GridInventario.DataSource = ds.Tables[0];
                            GridInventario.Columns["Item"].HeaderText = "Item";
                            GridInventario.Columns["Descripción"].HeaderText = "Descripción";
                            GridInventario.Refresh();
                        }
                    }
                }
                else if (selectedVal == "BIN")
                {
                    String Q = @"SELECT [Item]
                                ,[Descripción]
                                ,[Cantidad]
                                ,[Localidad]
                                ,[ID_Caja]
                                ,[Status]
                                ,[Devolucion]
                                ,[Usuario]
                                ,[Fecha]
                                ,[TraceID]
                            FROM [pmc_Inventario] WHERE STATUS= 'BIN' ";
                    sc.OpenConectionTracer();
                    using (SqlCommand cmd = new SqlCommand(Q, sc.OpenConectionTracer()))
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            GridInventario.AutoGenerateColumns = true;
                            adp.Fill(ds);
                            Console.WriteLine("Número de filas en el conjunto de datos: " + ds.Tables[0].Rows.Count);
                            GridInventario.DataSource = ds.Tables[0];
                            GridInventario.Columns["Item"].HeaderText = "Item";
                            GridInventario.Columns["Descripción"].HeaderText = "Descripción";
                            GridInventario.Refresh();
                        }
                    }
                }
                else if (selectedVal == "FINN")
                {
                    String Q = @"SELECT [Item]
                                ,[Descripción]
                                ,[Cantidad]
                                ,[Localidad]
                                ,[ID_Caja]
                                ,[Status]
                                ,[Devolucion]
                                ,[Usuario]
                                ,[Fecha]
                                ,[TraceID]
                            FROM [pmc_Inventario] WHERE STATUS= 'FINN' ";
                    sc.OpenConectionTracer();
                    using (SqlCommand cmd = new SqlCommand(Q, sc.OpenConectionTracer()))
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            GridInventario.AutoGenerateColumns = true;
                            adp.Fill(ds);
                            Console.WriteLine("Número de filas en el conjunto de datos: " + ds.Tables[0].Rows.Count);
                            GridInventario.DataSource = ds.Tables[0];
                            GridInventario.Columns["Item"].HeaderText = "Item";
                            GridInventario.Columns["Descripción"].HeaderText = "Descripción";
                            GridInventario.Refresh();
                        }
                    }
                }
                else if (selectedVal == "DEV")
                {
                    String Q = @"SELECT [Item]
                                ,[Descripción]
                                ,[Cantidad]
                                ,[Localidad]
                                ,[ID_Caja]
                                ,[Status]
                                ,[Devolucion]
                                ,[Usuario]
                                ,[Fecha]
                                ,[TraceID]
                            FROM [pmc_Inventario] WHERE STATUS= 'DEV' ";
                    sc.OpenConectionTracer();
                    using (SqlCommand cmd = new SqlCommand(Q, sc.OpenConectionTracer()))
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            GridInventario.AutoGenerateColumns = true;
                            adp.Fill(ds);
                            Console.WriteLine("Número de filas en el conjunto de datos: " + ds.Tables[0].Rows.Count);
                            GridInventario.DataSource = ds.Tables[0];
                            GridInventario.Columns["Item"].HeaderText = "Item";
                            GridInventario.Columns["Descripción"].HeaderText = "Descripción";
                            GridInventario.Refresh();
                        }
                    }
                }
                else if (selectedVal == "TT")
                {
                    String Q = @"SELECT [Item]
                                ,[Descripción]
                                ,[Cantidad]
                                ,[Localidad]
                                ,[ID_Caja]
                                ,[Status]
                                ,[Devolucion]
                                ,[Usuario]
                                ,[Fecha]
                                ,[TraceID]
                            FROM [pmc_Inventario]";
                    sc.OpenConectionTracer();
                    using (SqlCommand cmd = new SqlCommand(Q, sc.OpenConectionTracer()))
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            GridInventario.AutoGenerateColumns = true;
                            adp.Fill(ds);
                            Console.WriteLine("Número de filas en el conjunto de datos: " + ds.Tables[0].Rows.Count);
                            GridInventario.DataSource = ds.Tables[0];                            
                            GridInventario.Columns["Item"].HeaderText = "Item";
                            GridInventario.Columns["Descripción"].HeaderText = "Descripción";
                            GridInventario.Refresh();
                        }
                    }
                }
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            sc.ExportarGrid2(this.GridInventario,"Inventario");
        }
    }
}


 