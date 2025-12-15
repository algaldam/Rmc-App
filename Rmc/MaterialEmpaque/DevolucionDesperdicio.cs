using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
// CREADO POR DAVID AYALA
namespace Rmc.MaterialEmpaque
{
    
    public partial class DevolucionDesperdicio : Telerik.WinControls.UI.RadForm
    {
        public DevolucionDesperdicio()
        {
            InitializeComponent();
            sc.formarDatedMyHms(this.rdtpInicio);
            sc.formarDatedMyHms(this.rdtpFin);
            Devoluciones.Visible = true;
            Dev.Checked = true;
            DespStk.Visible = false;
            DespFinn.Visible = false;
            Sobreconsumos.Visible = false;
            ErrorDev.Enabled = false;
            DespStk1.Enabled = false;
            DespStk2.Enabled = false;
            DespStk3.Enabled = false;
            DespFin1.Enabled = false;
            DespFin2.Enabled = false;
            DespFin3.Enabled = false;
            DespFin4.Enabled = false;
            Entrega1.Enabled = false;
            Entrega2.Enabled = false;
            TraceIDFinDev.Enabled = false;
            TraceIDStk.Enabled = false;
            TraceIDFin.Enabled = false;
            TraceIDSobreConsumo.Enabled = false;
            MachSC.Enabled = false;
            CelulaSC.Enabled = false;
            MachFin.Enabled = false;
            CelulaFin.Enabled = false;
            MachDev.Enabled = false;
            CelulaDev.Enabled = false;
            CelulaStk.Enabled = false;
            MaquinaStk.Enabled = false;
            // Configura el TextBox para autocompletar
            CelulaSC.AutoCompleteMode = AutoCompleteMode.Suggest;
            CelulaSC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CelulaSC.TextChanged += CelulaSC_TextChanged;
            MachSC.AutoCompleteMode = AutoCompleteMode.Suggest;
            MachSC.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MachSC.TextChanged += MachSC_TextChanged;

            CelulaFin.AutoCompleteMode = AutoCompleteMode.Suggest;
            CelulaFin.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CelulaFin.TextChanged += CelulaFin_TextChanged;
            MachFin.AutoCompleteMode = AutoCompleteMode.Suggest;
            MachFin.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MachFin.TextChanged += MachFin_TextChanged;

            CelulaStk.AutoCompleteMode = AutoCompleteMode.Suggest;
            CelulaStk.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CelulaStk.TextChanged += CelulaStk_TextChanged;
            MaquinaStk.AutoCompleteMode = AutoCompleteMode.Suggest;
            MaquinaStk.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MaquinaStk.TextChanged += MaquinaStk_TextChanged;

            CelulaDev.AutoCompleteMode = AutoCompleteMode.Suggest;
            CelulaDev.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CelulaDev.TextChanged += CelulaDev_TextChanged;
            MachDev.AutoCompleteMode = AutoCompleteMode.Suggest;
            MachDev.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MachDev.TextChanged += MachDev_TextChanged;
        }
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        SqlConnection cn1 = new SqlConnection(Properties.Settings.Default.ES_SOCKS_StagingAreaConnectionString);
        SystemClass sc = new SystemClass();

        private void Dev_CheckedChanged(object sender, EventArgs e)
        {
            if (Dev.Checked)
            {
                sc.OpenConection();
                string query = @"SELECT 
                                [Sob_TraceID]
                                ,[Sob_SACA]
                                ,[Sob_MillStyle]
                                ,[Sob_Talla]
                                ,[Sob_Color]
                                ,[Sob_Maquina]
                                ,[Sob_Celula]
                                ,[Sob_Devolucion]
                                ,[Sob_Codigo]
                                ,[Sob_Descripcion] 
                                ,[Sob_Localidad]
                                ,[Sob_Cantidad]
                                ,[Sob_Usuario]
                                ,[Sob_Fecha]
                                FROM [pmc_Sobrantes] ORDER BY Sob_Fecha DESC";
                GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Maquina", HeaderText = "Máquina" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Celula", HeaderText = "Célula" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Devolucion", HeaderText = "Devolución" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Codigo", HeaderText = "Item" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Descripcion", HeaderText = "Descripción" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                // Calcula la suma de la columna DespStk_Cantidad
                int sumaCantidad = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Sob_Cantidad"] != DBNull.Value)
                    {
                        sumaCantidad += Convert.ToInt32(row["Sob_Cantidad"]);
                    }
                }
                // Muestra la suma en el contador de ítems
                ContadorItems.Text = sumaCantidad.ToString();
                GridDesperdicioStk.DataSource = dataTable;
                GridDesperdicioStk.Refresh();
                Devoluciones.Visible = true;
                Despstick.Checked = false;
                Despfin.Checked = false;
                Sbrconsumos.Checked = false;
            }
            else
            {
                Devoluciones.Visible = false;
                TraceIDFinDev.Clear();
                UserDevolucion.Clear();
                SacaDev.Text = string.Empty;
                TallaDev.Text = string.Empty;
                ColorDev.Text = string.Empty;
                MillStyleDev.Text = string.Empty;
                MachDev.Clear();
                CelulaDev.Clear();
                GridItems.DataSource = null;
                ErrorDev.Checked = false;
            }
        }
        private void CargaDatosDev()
        {
            string FechaInicio = rdtpInicio.Value.ToString();
            string FechaFin = rdtpFin.Value.ToString();
            sc.OpenConection();
            string query = @"SELECT 
                                [Sob_TraceID]
                                ,[Sob_SACA]
                                ,[Sob_MillStyle]
                                ,[Sob_Talla]
                                ,[Sob_Color]
                                ,[Sob_Maquina]
                                ,[Sob_Celula]
                                ,[Sob_Devolucion]
                                ,[Sob_Codigo]
                                ,[Sob_Descripcion]
                                ,[Sob_Cantidad]
                                ,[Sob_Localidad]
                                ,[Sob_Usuario]
                                ,[Sob_Fecha]
                                FROM [pmc_Sobrantes]  Where [Sob_Fecha] Between '" + sc.FormatSQLDate(rdtpInicio.Value) + "' and '" + sc.FormatSQLDate(rdtpFin.Value) + "'";
            GridDesperdicioStk.Columns.Clear();
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_TraceID", HeaderText = "TraceID" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_SACA", HeaderText = "SACA" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_MillStyle", HeaderText = "MillStyle" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Talla", HeaderText = "Talla" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Color", HeaderText = "Color" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Maquina", HeaderText = "Máquina" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Celula", HeaderText = "Célula" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Devolucion", HeaderText = "Devolución" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Codigo", HeaderText = "Item" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Descripcion", HeaderText = "Descripción" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Cantidad", HeaderText = "Cantidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Localidad", HeaderText = "Localidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Usuario", HeaderText = "Usuario" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Fecha", HeaderText = "Fecha" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            // Calcula la suma de la columna DespStk_Cantidad
            int sumaCantidad = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Sob_Cantidad"] != DBNull.Value)
                {
                    sumaCantidad += Convert.ToInt32(row["Sob_Cantidad"]);
                }
            }
            // Muestra la suma en el contador de ítems
            ContadorItems.Text = sumaCantidad.ToString();
            GridDesperdicioStk.DataSource = dataTable;
            GridDesperdicioStk.Refresh();
            Dev.Visible = true;
            Despstick.Checked = false;
            Despfin.Checked = false;
            Sbrconsumos.Checked = false;
        }
        private void Devolucion()
        {
            if (Dev.Checked)
            {
                sc.OpenConection();
                string query = @"SELECT [Sob_TraceID],[Sob_SACA],[Sob_MillStyle],[Sob_Talla],[Sob_Color],[Sob_Maquina],[Sob_Celula],[Sob_Devolucion],[Sob_Codigo],[Sob_Descripcion],[Sob_Localidad],[Sob_Cantidad],[Sob_Usuario],[Sob_Fecha] FROM [pmc_Sobrantes] ORDER BY Sob_Fecha DESC";
                GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Maquina", HeaderText = "Máquina" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Celula", HeaderText = "Célula" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Devolucion", HeaderText = "Devolución" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Codigo", HeaderText = "Item" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Descripcion", HeaderText = "Descripción" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                // Calcula la suma de la columna DespStk_Cantidad
                int sumaCantidad = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Sob_Cantidad"] != DBNull.Value)
                    {
                        sumaCantidad += Convert.ToInt32(row["Sob_Cantidad"]);
                    }
                }
                // Muestra la suma en el contador de ítems
                ContadorItems.Text = sumaCantidad.ToString();
                GridDesperdicioStk.DataSource = dataTable;
                GridDesperdicioStk.Refresh();
                Devoluciones.Visible = true;
                Despstick.Checked = false;
                Despfin.Checked = false;
                Sbrconsumos.Checked = false;
            }
            else
            {
                Devoluciones.Visible = false;
            }
        }

        private void Despstick_CheckedChanged(object sender, EventArgs e)
        {
            if (Despstick.Checked)
            {
                sc.OpenConection();
                string query = @"SELECT 
                                [DespStk_TraceID]
                                ,[DespStk_SACA]
                                ,[DespStk_MillStyle]
                                ,[DespStk_Talla]
                                ,[DespStk_Color]
                                ,[DespStk_Devolucion]
                                ,[DespStk_Codigo]
                                ,[DespStk_Descripcion]  
                                ,[DespStk_Localidad]
                                ,[DespStk_Usuario]
                                ,[DespStk_Cantidad]
                                ,[DespStk_Fecha]
                                FROM [pmc_DesperdicioStickerado] ORDER BY DespStk_Fecha DESC";
                GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Devolucion", HeaderText = "Devolución" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Codigo", HeaderText = "Código" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Descripcion", HeaderText = "Descripción" }); 
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                // Calcula la suma de la columna DespStk_Cantidad
                int sumaCantidad = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DespStk_Cantidad"] != DBNull.Value)
                    {
                        sumaCantidad += Convert.ToInt32(row["DespStk_Cantidad"]);
                    }
                }
                // Muestra la suma en el contador de ítems
                ContadorItems.Text = sumaCantidad.ToString();
                GridDesperdicioStk.DataSource = dataTable;
                GridDesperdicioStk.Refresh();
                DespStk.Visible = true;
                Dev.Checked = false;
                Despfin.Checked = false;
                Sbrconsumos.Checked = false;
            }
            else
            {
                DespStk.Visible = false;
                userSTK.Clear();
                TraceIDStk.Clear();
                SacaStk.Text = string.Empty;
                TallaStk.Text = string.Empty;
                ColorStk.Text = string.Empty;
                MillStyleStk.Text = string.Empty;
                GridItems.DataSource = null;
                DespStk1.Checked = false;
                DespStk2.Checked = false;
                DespStk3.Checked = false;

            }
        }
        private void CargaDatosStickerado()
        {    
            string FechaInicio = rdtpInicio.Value.ToString();
            string FechaFin = rdtpFin.Value.ToString();
            sc.OpenConection();
            string query = @"SELECT 
                                [DespStk_TraceID]
                                ,[DespStk_SACA]
                                ,[DespStk_MillStyle]
                                ,[DespStk_Talla]
                                ,[DespStk_Color]
                                ,[DespStk_Devolucion]
                                ,[DespStk_Codigo]
                                ,[DespStk_Descripcion]
                                ,[DespStk_Localidad]
                                ,[DespStk_Usuario]
                                ,[DespStk_Cantidad]
                                ,[DespStk_Fecha]
                                FROM [pmc_DesperdicioStickerado] Where [DespStk_Fecha] Between '" + sc.FormatSQLDate( rdtpInicio.Value) + "' and '" + sc.FormatSQLDate(rdtpFin.Value) + "'";
            GridDesperdicioStk.Columns.Clear();
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_TraceID", HeaderText = "TraceID" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_SACA", HeaderText = "SACA" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_MillStyle", HeaderText = "MillStyle" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Talla", HeaderText = "Talla" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Color", HeaderText = "Color" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Devolucion", HeaderText = "Devolución" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Codigo", HeaderText = "Código" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Descripcion", HeaderText = "Descripción" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Localidad", HeaderText = "Localidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Usuario", HeaderText = "Usuario" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Cantidad", HeaderText = "Cantidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Fecha", HeaderText = "Fecha" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            // Calcula la suma de la columna DespStk_Cantidad
            int sumaCantidad = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["DespStk_Cantidad"] != DBNull.Value)
                {
                    sumaCantidad += Convert.ToInt32(row["DespStk_Cantidad"]);
                }
            }
            // Muestra la suma en el contador de ítems
            ContadorItems.Text = sumaCantidad.ToString();
            GridDesperdicioStk.DataSource = dataTable;
            GridDesperdicioStk.Refresh();
            DespStk.Visible = true;
            Dev.Checked = false;
            Despfin.Checked = false;
            Sbrconsumos.Checked = false;
        }
        private void Stickerado()
        {
            sc.OpenConection();
            string query = @"SELECT 
                                [DespStk_TraceID]
                                ,[DespStk_SACA]
                                ,[DespStk_MillStyle]
                                ,[DespStk_Talla]
                                ,[DespStk_Color]
                                ,[DespStk_Devolucion]
                                ,[DespStk_Codigo]
                                ,[DespStk_Descripcion]
                                ,[DespStk_Localidad]
                                ,[DespStk_Usuario]
                                ,[DespStk_Cantidad]
                                ,[DespStk_Fecha]
                                FROM [pmc_DesperdicioStickerado] ORDER BY DespStk_Fecha DESC ";
            GridDesperdicioStk.Columns.Clear();
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_TraceID", HeaderText = "TraceID" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_SACA", HeaderText = "SACA" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_MillStyle", HeaderText = "MillStyle" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Talla", HeaderText = "Talla" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Color", HeaderText = "Color" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Devolucion", HeaderText = "Devolución" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Codigo", HeaderText = "Código" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Descripcion", HeaderText = "Descripción" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Localidad", HeaderText = "Localidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Usuario", HeaderText = "Usuario" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Cantidad", HeaderText = "Cantidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespStk_Fecha", HeaderText = "Fecha" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            // Calcula la suma de la columna DespStk_Cantidad
            int sumaCantidad = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["DespStk_Cantidad"] != DBNull.Value)
                {
                    sumaCantidad += Convert.ToInt32(row["DespStk_Cantidad"]);
                }
            }
            // Muestra la suma en el contador de ítems
            ContadorItems.Text = sumaCantidad.ToString();
            GridDesperdicioStk.DataSource = dataTable;
            GridDesperdicioStk.Refresh();
            DespStk.Visible = true;
            Dev.Checked = false;
            Despfin.Checked = false;
            Sbrconsumos.Checked = false;
        }

        private void Despfin_CheckedChanged(object sender, EventArgs e)
        {
            if (Despfin.Checked)
            {
                sc.OpenConection();
                string query = @"SELECT 
                                [DespFin_TraceID]
                                ,[DespFin_SACA]
                                ,[DespFin_MillStyle]
                                ,[DespFin_Talla]
                                ,[DespFin_Color]
                                ,[DespFin_Maquina]
                                ,[DespFin_Celula]
                                ,[DespFin_Devolucion]
                                ,[DespFin_Codigo]
                                ,[DespFin_Descripcion]                               
                                ,[DespFin_Localidad]
                                ,[DespFin_Usuario]
                                ,[DespFin_Cantidad]
                                ,[DespFin_Fecha]
                            FROM [pmc_DesperdicioFinishing] ORDER BY DespFin_Fecha DESC";
                GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Maquina", HeaderText = "Máquina" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Celula", HeaderText = "Célula" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Devolucion", HeaderText = "Devolución" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Codigo", HeaderText = "Código" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Descripcion", HeaderText = "Descripción" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                // Calcula la suma de la columna DespStk_Cantidad
                int sumaCantidad = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DespFin_Cantidad"] != DBNull.Value)
                    {
                        sumaCantidad += Convert.ToInt32(row["DespFin_Cantidad"]);
                    }
                }
                // Muestra la suma en el contador de ítems
                ContadorItems.Text = sumaCantidad.ToString();
                GridDesperdicioStk.DataSource = dataTable;
                GridDesperdicioStk.Refresh();
                DespFinn.Visible = true;
                Despstick.Checked = false;
                Dev.Checked = false;
                Sbrconsumos.Checked = false;
            }
            else
            {
                DespFinn.Visible = false;
                UserFin.Clear();
                TraceIDFin.Clear();
                SacaFin.Text = string.Empty;
                TallaFin.Text = string.Empty;
                ColorFin.Text = string.Empty;
                MillStyleFin.Text = string.Empty;
                GridItems.DataSource = null;
                DespFin1.Checked = false;
                DespFin2.Checked = false;
                DespFin3.Checked = false;
                DespFin4.Checked = false;
                MachFin.Clear();
                CelulaFin.Clear();
            }
        }
        private void CargaDatosFinishing()
        {
            //Despfin.Checked = true;
            string FechaInicio = rdtpInicio.Value.ToString();
            string FechaFin = rdtpFin.Value.ToString();
            sc.OpenConection();
            string query = @"SELECT 
                                [DespFin_TraceID]
                                ,[DespFin_SACA]
                                ,[DespFin_MillStyle]
                                ,[DespFin_Talla]
                                ,[DespFin_Color]
                                ,[DespFin_Devolucion]
                                ,[DespFin_Codigo]
                                ,[DespFin_Descripcion]
                                ,[DespFin_Localidad]
                                ,[DespFin_Usuario]
                                ,[DespFin_Cantidad]
                                ,[DespFin_Fecha]
                                FROM [pmc_DesperdicioFinishing] Where [DespFin_Fecha] Between '" + sc.FormatSQLDate(rdtpInicio.Value) + "' and '" + sc.FormatSQLDate(rdtpFin.Value) + "'";
            GridDesperdicioStk.Columns.Clear();
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_TraceID", HeaderText = "TraceID" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_SACA", HeaderText = "SACA" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_MillStyle", HeaderText = "MillStyle" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Talla", HeaderText = "Talla" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Color", HeaderText = "Color" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Devolucion", HeaderText = "Devolución" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Codigo", HeaderText = "Código" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Descripcion", HeaderText = "Descripción" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Localidad", HeaderText = "Localidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Usuario", HeaderText = "Usuario" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Cantidad", HeaderText = "Cantidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Fecha", HeaderText = "Fecha" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            // Calcula la suma de la columna DespStk_Cantidad
            int sumaCantidad = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["DespFin_Cantidad"] != DBNull.Value)
                {
                    sumaCantidad += Convert.ToInt32(row["DespFin_Cantidad"]);
                }
            }
            // Muestra la suma en el contador de ítems
            ContadorItems.Text = sumaCantidad.ToString();
            GridDesperdicioStk.DataSource = dataTable;
            GridDesperdicioStk.Refresh();
            Despfin.Visible = true;
            Dev.Checked = false;
            Despstick.Checked = false;
            Sbrconsumos.Checked = false;
        }
        private void Finishing()
        {
            if (Despfin.Checked)
            {
                sc.OpenConection();
                string query = @"SELECT 
                                [DespFin_TraceID]
                                ,[DespFin_SACA]
                                ,[DespFin_MillStyle]
                                ,[DespFin_Talla]
                                ,[DespFin_Color]
                                ,[DespFin_Maquina]
                                ,[DespFin_Celula]
                                ,[DespFin_Devolucion]
                                ,[DespFin_Codigo]
                                ,[DespFin_Descripcion]                               
                                ,[DespFin_Localidad]
                                ,[DespFin_Usuario]
                                ,[DespFin_Cantidad]
                                ,[DespFin_Fecha]
                            FROM [pmc_DesperdicioFinishing] ORDER BY DespFin_Fecha DESC";
                GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Maquina", HeaderText = "Máquina" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Celula", HeaderText = "Célula" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Devolucion", HeaderText = "Devolución" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Codigo", HeaderText = "Código" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Descripcion", HeaderText = "Descripción" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                // Calcula la suma de la columna DespStk_Cantidad
                int sumaCantidad = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["DespFin_Cantidad"] != DBNull.Value)
                    {
                        sumaCantidad += Convert.ToInt32(row["DespFin_Cantidad"]);
                    }
                }
                // Muestra la suma en el contador de ítems
                ContadorItems.Text = sumaCantidad.ToString();
                GridDesperdicioStk.DataSource = dataTable;
                GridDesperdicioStk.Refresh();
                DespFinn.Visible = true;
                Despstick.Checked = false;
                Dev.Checked = false;
                Sbrconsumos.Checked = false;
            }
            else
            {
                DespFinn.Visible = false;
            }
        }

        private void Sbrconsumos_CheckedChanged(object sender, EventArgs e)
        {
            if (Sbrconsumos.Checked)
            {
                sc.OpenConection();
                string query = @"SELECT
                                 [Sobr_TraceID]
                                ,[Sobr_SACA]
                                ,[Sobr_MillStyle]
                                ,[Sobr_Talla]
                                ,[Sobr_Color]
                                ,[Sobr_Maquina]
                                ,[Sobr_Celula]
                                ,[Sobr_Entrega]
                                ,[Sobr_Codigo]
                                ,[Sobr_Descripcion]
                                ,[Sobr_Localidad]
                                ,[Sobr_Usuario]
                                ,[Sobr_Cantidad]
                                ,[Sobr_Fecha]
                            FROM [pmc_Sobreconsumos] ORDER BY Sobr_Fecha DESC";
                GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Maquina", HeaderText = "Máquina" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Celula", HeaderText = "Célula" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Entrega", HeaderText = "Entrega" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Codigo", HeaderText = "Código" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Descripcion", HeaderText = "Descripción" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                // Calcula la suma de la columna DespStk_Cantidad
                int sumaCantidad = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Sobr_Cantidad"] != DBNull.Value)
                    {
                        sumaCantidad += Convert.ToInt32(row["Sobr_Cantidad"]);
                    }
                }
                // Muestra la suma en el contador de ítems
                ContadorItems.Text = sumaCantidad.ToString();
                GridDesperdicioStk.DataSource = dataTable;
                GridDesperdicioStk.Refresh();
                Sobreconsumos.Visible = true;
                Despstick.Checked = false;
                Despfin.Checked = false;
                Dev.Checked = false;
            }
            else
            {
                Sobreconsumos.Visible = false;
                UserSC.Clear();
                TraceIDSobreConsumo.Clear();
                SacaSC.Text = string.Empty;
                TallaSC.Text = string.Empty;
                ColorSC.Text = string.Empty;
                MillStyleSC.Text = string.Empty;
                MachSC.Clear();
                CelulaSC.Clear();
                GridItems.DataSource = null;
                Entrega1.Checked = false;
                Entrega2.Checked = false;
            }
        }
        private void CargaDatosSobreConsumos()
        {
            Despfin.Checked = true;
            string FechaInicio = rdtpInicio.Value.ToString();
            string FechaFin = rdtpFin.Value.ToString();
            sc.OpenConection();
            string query = @"SELECT
                                 [Sobr_TraceID]
                                ,[Sobr_SACA]
                                ,[Sobr_MillStyle]
                                ,[Sobr_Talla]
                                ,[Sobr_Color]
                                ,[Sobr_Maquina]
                                ,[Sobr_Celula]
                                ,[Sobr_Entrega]
                                ,[Sobr_Codigo]
                                ,[Sobr_Descripcion]
                                ,[Sobr_Localidad]
                                ,[Sobr_Usuario]
                                ,[Sobr_Cantidad]
                                ,[Sobr_Fecha]
                            FROM [pmc_Sobreconsumos] Where [Sobr_Fecha] Between '" + sc.FormatSQLDate(rdtpInicio.Value) + "' and '" + sc.FormatSQLDate(rdtpFin.Value) + "'";
            GridDesperdicioStk.Columns.Clear();
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_TraceID", HeaderText = "TraceID" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_SACA", HeaderText = "SACA" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_MillStyle", HeaderText = "MillStyle" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Talla", HeaderText = "Talla" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Color", HeaderText = "Color" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Maquina", HeaderText = "Máquina" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Celula", HeaderText = "Célula" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Entrega", HeaderText = "Entrega" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Codigo", HeaderText = "Código" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Descripcion", HeaderText = "Descripción" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Localidad", HeaderText = "Localidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Usuario", HeaderText = "Usuario" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Cantidad", HeaderText = "Cantidad" });
                GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Fecha", HeaderText = "Fecha" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            // Calcula la suma de la columna DespStk_Cantidad
            int sumaCantidad = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Sobr_Cantidad"] != DBNull.Value)
                {
                    sumaCantidad += Convert.ToInt32(row["Sobr_Cantidad"]);
                }
            }
            // Muestra la suma en el contador de ítems
            ContadorItems.Text = sumaCantidad.ToString();
            GridDesperdicioStk.DataSource = dataTable;
            GridDesperdicioStk.Refresh();
            Sobreconsumos.Visible = true;
            Dev.Checked = false;
            Despstick.Checked = false;
            Despfin.Checked = false;
        }
        private void SobreConsumos()
        {
            Sbrconsumos.Checked = true;
            
            sc.OpenConection();
            string query = @"SELECT
                                 [Sobr_TraceID]
                                ,[Sobr_SACA]
                                ,[Sobr_MillStyle]
                                ,[Sobr_Talla]
                                ,[Sobr_Color]
                                ,[Sobr_Maquina]
                                ,[Sobr_Celula]
                                ,[Sobr_Entrega]
                                ,[Sobr_Codigo]
                                ,[Sobr_Descripcion]
                                ,[Sobr_Localidad]
                                ,[Sobr_Usuario]
                                ,[Sobr_Cantidad]
                                ,[Sobr_Fecha]
                            FROM [pmc_Sobreconsumos] ORDER BY Sobr_Fecha DESC";
            GridDesperdicioStk.Columns.Clear();
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_TraceID", HeaderText = "TraceID" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_SACA", HeaderText = "SACA" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_MillStyle", HeaderText = "MillStyle" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Talla", HeaderText = "Talla" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Color", HeaderText = "Color" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Maquina", HeaderText = "Máquina" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Celula", HeaderText = "Célula" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Entrega", HeaderText = "Entrega" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Codigo", HeaderText = "Código" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Descripcion", HeaderText = "Descripción" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Localidad", HeaderText = "Localidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Usuario", HeaderText = "Usuario" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Cantidad", HeaderText = "Cantidad" });
            GridDesperdicioStk.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Fecha", HeaderText = "Fecha" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            // Calcula la suma de la columna DespStk_Cantidad
            int sumaCantidad = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Sobr_Cantidad"] != DBNull.Value)
                {
                    sumaCantidad += Convert.ToInt32(row["Sobr_Cantidad"]);
                }
            }
            // Muestra la suma en el contador de ítems
            ContadorItems.Text = sumaCantidad.ToString();
            GridDesperdicioStk.DataSource = dataTable;
            GridDesperdicioStk.Refresh();
            Sobreconsumos.Visible = true;
            Dev.Checked = false;
            Despstick.Checked = false;
            Despfin.Checked = false;
        }

        private void radTextBox30_TextChanged(object sender, EventArgs e)
        {
            if (UserDevolucion.Text.Length >= 4)
            {
                TraceIDFinDev.Enabled      = true;
                SacaDev.Enabled         = true;
                MillStyleDev.Enabled    = true;
                TallaDev.Enabled        = true;
                ColorDev.Enabled        = true;
                MachDev.Enabled         = true;
                CelulaDev.Enabled       = true;
                ErrorDev.Enabled        = true;
            }
            else
            {
                TraceIDFinDev.Enabled   = false;
                SacaDev.Enabled         = false;
                MillStyleDev.Enabled    = false;
                TallaDev.Enabled        = false;
                ColorDev.Enabled        = false;
                MachDev.Enabled         = false;
                CelulaDev.Enabled       = false;
                ErrorDev.Enabled        = false;

            }
        }

        private void radTextBox31_TextChanged(object sender, EventArgs e)
        {
            if (userSTK.Text.Length >= 4)
            {
                TraceIDStk.Enabled = true;
                SacaStk.Enabled = true;
                MillStyleStk.Enabled = true;
                TallaStk.Enabled = true;
                ColorStk.Enabled = true;
                MaquinaStk.Enabled = true;
                CelulaStk.Enabled = true;
                DespStk1.Enabled = true;
                DespStk2.Enabled = true;
                DespStk3.Enabled = true;          
            }
            else
            {
                TraceIDStk.Enabled = false;
                SacaStk.Enabled = false;
                MillStyleStk.Enabled = false;
                TallaStk.Enabled = false;
                ColorStk.Enabled = false;
                MaquinaStk.Enabled = false;
                CelulaStk.Enabled = false;
                DespStk1.Enabled = false;
                DespStk2.Enabled = false;
                DespStk3.Enabled = false;           
            }
        }

        private void DespStk1_CheckedChanged(object sender, EventArgs e)
        {
            DespStk2.Checked = false;
            DespStk3.Checked = false;
        }

        private void DespStk2_CheckedChanged(object sender, EventArgs e)
        {
            DespStk1.Checked = false;
            DespStk3.Checked = false;
        }

        private void DespStk3_CheckedChanged(object sender, EventArgs e)
        {
            DespStk1.Checked = false;
            DespStk2.Checked = false;
        }

        private void radTextBox32_TextChanged(object sender, EventArgs e)
        {
            if (UserFin.Text.Length >= 4)
            {
                TraceIDFin.Enabled = true;
                SacaFin.Enabled = true;
                MillStyleFin.Enabled = true;
                TallaFin.Enabled = true;
                ColorFin.Enabled = true;
                MachFin.Enabled = true;
                CelulaFin.Enabled = true;
                DespFin1.Enabled = true;
                DespFin2.Enabled = true;
                DespFin3.Enabled = true;
                DespFin4.Enabled = true;
            }
            else
            {
                TraceIDFin.Enabled = false;
                SacaFin.Enabled = false;
                MillStyleFin.Enabled = false;
                TallaFin.Enabled = false;
                ColorFin.Enabled = false;
                MachFin.Enabled = false;
                CelulaFin.Enabled = true;
                DespFin1.Enabled = false;
                DespFin2.Enabled = false;
                DespFin3.Enabled = false;
                DespFin4.Enabled = false;
                
            }
        }

        private void radTextBox33_TextChanged(object sender, EventArgs e)
        {
            if (UserSC.Text.Length >= 4)
            {
                TraceIDSobreConsumo.Enabled = true;
                SacaSC.Enabled = true;
                MillStyleSC.Enabled = true;
                TallaSC.Enabled = true;
                ColorSC.Enabled = true;
                MachSC.Enabled = true;
                CelulaSC.Enabled = true;
                Entrega1.Enabled = true;
                Entrega2.Enabled = true;          
            }
            else
            {
                TraceIDSobreConsumo.Enabled = false;
                SacaSC.Enabled = false;
                MillStyleSC.Enabled = false;
                TallaSC.Enabled = false;
                ColorSC.Enabled = false;
                MachSC.Enabled = false;
                CelulaSC.Enabled = false;
                Entrega1.Enabled = false;
                Entrega2.Enabled = false;
            }
        }

        private void DespFin1_CheckedChanged(object sender, EventArgs e)
        {
            DespFin2.Checked = false;
            DespFin3.Checked = false;
            DespFin4.Checked = false;
        }

        private void DespFin2_CheckedChanged(object sender, EventArgs e)
        {
            DespFin1.Checked = false;
            DespFin3.Checked = false;
            DespFin4.Checked = false;
        }

        private void DespFin3_CheckedChanged(object sender, EventArgs e)
        {
            DespFin1.Checked = false;
            DespFin2.Checked = false;
            DespFin4.Checked = false;
        }

        private void DespFin4_CheckedChanged(object sender, EventArgs e)
        {
            DespFin2.Checked = false;
            DespFin3.Checked = false;
            DespFin1.Checked = false;
        }

        private void Entrega1_CheckedChanged(object sender, EventArgs e)
        {
            Entrega2.Checked = false;
        }

        private void Entrega2_CheckedChanged(object sender, EventArgs e)
        {
            Entrega1.Checked = false;
        }

        private void TraceIDStk_KeyDown(object sender, KeyEventArgs e)
        {
            String TID = TraceIDStk.Text;
            sc.OpenConection();
            if (e.KeyCode == Keys.Enter)
            {
                try
                { //Veamos que sea numerico el codigo
                    if (sc.IsNumeric(this.TraceIDStk.Text) == false)
                    {
                        MessageBox.Show("Ingrese un código numérico");
                        TraceIDStk.Clear();
                        this.TraceIDStk.Focus();
                        return;
                    }
                    string query = @"SELECT DISTINCT K.WeekID,K.Saca,K.Dozens as Docenas_Por_Buggie,
                                 LEFT(ColorMillStyle, 4) AS MillStyle,
                                 RIGHT(ColorMillStyle, 4) AS Color,
								 MAX(ss.sub_factor) OVER () AS DZxCase,
                                 SUBSTRING(RawMillStyle, 5, 3) AS Talla FROM [View_PreKiteo] AS K
								 INNER JOIN es_socks.dbo.pmc_subida_bom AS ss
                                 ON K.saca = ss.sub_saca COLLATE sql_latin1_general_cp1_ci_as WHERE TraceID= '" + TID + "'";
                    using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                    {
                        cmd.CommandTimeout = 120; // 2 minutos (valor en segundos)
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SacaStk.Text = reader["SACA"].ToString();
                            ColorStk.Text = reader["Color"].ToString();
                            TallaStk.Text = reader["Talla"].ToString();
                            MillStyleStk.Text = reader["MillStyle"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para: " + TID);
                            TraceIDStk.Clear();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            sc.OpenConectionTracer();
            string sql = @"SELECT DISTINCT 
                                    ss.sub_producto AS Item, 
                                    ss.sub_descripcion,
				                    ROUND(ROUND(c.dozens, 0) / ss.sub_factor, 0) AS Cantidad,
				                    I.Localidad            
                                    FROM            dbo.pmc_ProductMaster AS P INNER JOIN
                                    dbo.pmc_ConsolidadoPlanes AS c ON P.saca = c.sku INNER JOIN
                                    dbo.pmc_SACA_1as_2das_3ras AS s ON P.saca = s.pmc_SACA_1ra INNER JOIN
                                    dbo.pmc_Doblado_IRR AS d ON s.pmc_SACA_2da = d.pmc_SACA_IRR INNER JOIN
                                    dbo.View_PreKiteo AS k ON P.saca = k.SACA INNER JOIN
                                    ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON P.saca = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
						            INNER JOIN dbo.pmc_Inventario AS I
						            ON I.Item = ss.sub_producto  COLLATE SQL_Latin1_General_CP1_CI_AS
                                    WHERE     Status='STK' AND k.TraceID = '" + TID + "'";
            GridItems.Columns.Clear();
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            checkBoxColumn.FieldName = "Selected";
            checkBoxColumn.HeaderText = "Selección";
            checkBoxColumn.Width = 40;
            GridItems.Columns.Add(checkBoxColumn);
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "sub_descripcion", HeaderText = "Descripción" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            GridItems.MultiSelect = true;
            GridItems.SelectionMode = GridViewSelectionMode.FullRowSelect;
            GridItems.DataSource = dataTable;
            GridItems.Refresh();


        }
        private void TraceIDFinDev_KeyDown(object sender, KeyEventArgs e)
        {
            String TID = TraceIDFinDev.Text;
            sc.OpenConection();
            if (e.KeyCode == Keys.Enter)
            {
                try
                { //Veamos que sea numerico el codigo
                    if (sc.IsNumeric(this.TraceIDFinDev.Text) == false)
                    {
                        MessageBox.Show("Ingrese un código numérico");
                        TraceIDFinDev.Clear();
                        this.TraceIDFinDev.Focus();
                        return;
                    }
                    string query = @"SELECT DISTINCT K.WeekID,K.Saca,K.Dozens as Docenas_Por_Buggie,
                                 LEFT(ColorMillStyle, 4) AS MillStyle,
                                 RIGHT(ColorMillStyle, 4) AS Color,
								 MAX(ss.sub_factor) OVER () AS DZxCase,
                                 SUBSTRING(RawMillStyle, 5, 3) AS Talla FROM [View_PreKiteo] AS K
								 INNER JOIN es_socks.dbo.pmc_subida_bom AS ss
                                 ON K.saca = ss.sub_saca COLLATE sql_latin1_general_cp1_ci_as WHERE TraceID= '" + TID + "'";
                    using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                    {
                        //SqlCommand command = new SqlCommand(query, sc.OpenConectionTracer());
                        cmd.CommandTimeout = 120; // 2 minutos (valor en segundos)
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SacaDev.Text = reader["SACA"].ToString();
                            ColorDev.Text = reader["Color"].ToString();
                            TallaDev.Text = reader["Talla"].ToString();
                            MillStyleDev.Text = reader["MillStyle"].ToString();
                            //MachDev.Text = reader["Maquina"].ToString();
                            //CelulaDev.Text = reader["Celula"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para: " + TID);
                            TraceIDStk.Clear();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            sc.OpenConectionTracer();
            string sql = @"SELECT DISTINCT 
                                    ss.sub_producto AS Item, 
                                    ss.sub_descripcion,
				                    ROUND(ROUND(c.dozens, 0) / ss.sub_factor, 0) AS Cantidad,
				                    I.Localidad            
                                    FROM            dbo.pmc_ProductMaster AS P INNER JOIN
                                    dbo.pmc_ConsolidadoPlanes AS c ON P.saca = c.sku INNER JOIN
                                    dbo.pmc_SACA_1as_2das_3ras AS s ON P.saca = s.pmc_SACA_1ra INNER JOIN
                                    dbo.pmc_Doblado_IRR AS d ON s.pmc_SACA_2da = d.pmc_SACA_IRR INNER JOIN
                                    dbo.View_TRANSACTIONS AS k ON P.saca = k.SACA INNER JOIN
                                    ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON P.saca = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
						            INNER JOIN dbo.pmc_Inventario AS I
						            ON I.Item = ss.sub_producto  COLLATE SQL_Latin1_General_CP1_CI_AS
                                    WHERE     Status='STK' AND k.TraceID = '" + TID + "'";
            GridItems.Columns.Clear();
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            checkBoxColumn.FieldName = "Selected";
            checkBoxColumn.HeaderText = "Selección";
            checkBoxColumn.Width = 40;
            GridItems.Columns.Add(checkBoxColumn);
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "sub_descripcion", HeaderText = "Descripción" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            GridItems.MultiSelect = true;
            GridItems.SelectionMode = GridViewSelectionMode.FullRowSelect;
            GridItems.DataSource = dataTable;
            GridItems.Refresh();
        }
        private void TraceIDFin_KeyDown(object sender, KeyEventArgs e)
        {
            String TID = TraceIDFin.Text;
            sc.OpenConection();
            if (e.KeyCode == Keys.Enter)
            {
                try
                { //Veamos que sea numerico el codigo
                    if (sc.IsNumeric(this.TraceIDFin.Text) == false)
                    {
                        MessageBox.Show("Ingrese un código numérico");
                        TraceIDFin.Clear();
                        this.TraceIDFin.Focus();
                        return;
                    }
                    string query = @"SELECT DISTINCT K.WeekID,K.Saca,K.Dozens as Docenas_Por_Buggie,
                                 LEFT(ColorMillStyle, 4) AS MillStyle,
                                 RIGHT(ColorMillStyle, 4) AS Color,
								 MAX(ss.sub_factor) OVER () AS DZxCase,
                                 SUBSTRING(RawMillStyle, 5, 3) AS Talla FROM [View_Transactions] AS K
								 INNER JOIN es_socks.dbo.pmc_subida_bom AS ss
                                 ON K.saca = ss.sub_saca COLLATE sql_latin1_general_cp1_ci_as WHERE TraceID= '" + TID + "'";
                    using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                    {
                        //SqlCommand command = new SqlCommand(query, sc.OpenConectionTracer());
                        cmd.CommandTimeout = 120; // 2 minutos (valor en segundos)
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SacaFin.Text = reader["SACA"].ToString();
                            ColorFin.Text = reader["Color"].ToString();
                            TallaFin.Text = reader["Talla"].ToString();
                            MillStyleFin.Text = reader["MillStyle"].ToString();
                            //MachDev.Text = reader["Maquina"].ToString();
                            //CelulaDev.Text = reader["Celula"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para: " + TID);
                            TraceIDFin.Clear();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            sc.OpenConectionTracer();
            string sql = @"SELECT DISTINCT 
                                    ss.sub_producto AS Item, 
                                    ss.sub_descripcion,
				                    ROUND(ROUND(c.dozens, 0) / ss.sub_factor, 0) AS Cantidad,
				                    I.Localidad            
                                    FROM            dbo.pmc_ProductMaster AS P INNER JOIN
                                    dbo.pmc_ConsolidadoPlanes AS c ON P.saca = c.sku INNER JOIN
                                    dbo.pmc_SACA_1as_2das_3ras AS s ON P.saca = s.pmc_SACA_1ra INNER JOIN
                                    dbo.pmc_Doblado_IRR AS d ON s.pmc_SACA_2da = d.pmc_SACA_IRR INNER JOIN
                                    dbo.View_Transactions AS k ON P.saca = k.SACA INNER JOIN
                                    ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON P.saca = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
						            INNER JOIN dbo.pmc_Inventario AS I
						            ON I.Item = ss.sub_producto  COLLATE SQL_Latin1_General_CP1_CI_AS
                                    WHERE     Status='STK' AND k.TraceID = '" + TID + "'";
            GridItems.Columns.Clear();
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            checkBoxColumn.FieldName = "Selected";
            checkBoxColumn.HeaderText = "Selección";
            checkBoxColumn.Width = 40;
            GridItems.Columns.Add(checkBoxColumn);
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "sub_descripcion", HeaderText = "Descripción" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            GridItems.MultiSelect = true;
            GridItems.SelectionMode = GridViewSelectionMode.FullRowSelect;
            GridItems.DataSource = dataTable;
            GridItems.Refresh();
        }

        private void TraceIDSobreConsumo_KeyDown(object sender, KeyEventArgs e)
        {
            String TID = TraceIDSobreConsumo.Text;
            sc.OpenConection();
            if (e.KeyCode == Keys.Enter)
            {
                try
                { //Veamos que sea numerico el codigo
                    if (sc.IsNumeric(this.TraceIDSobreConsumo.Text) == false)
                    {
                        MessageBox.Show("Ingrese un código numérico");
                        TraceIDSobreConsumo.Clear();
                        this.TraceIDSobreConsumo.Focus();
                        return;
                    }
                    string query = @"SELECT DISTINCT K.WeekID,K.Saca,K.Docenas as Docenas_Por_Buggie,
                                  MillStyle,
                                 Color,
								 MAX(ss.sub_factor) OVER () AS DZxCase,
                                  Talla FROM pmc_InventarioByTraceID AS K
								 INNER JOIN es_socks.dbo.pmc_subida_bom AS ss
                                 ON K.saca = ss.sub_saca COLLATE sql_latin1_general_cp1_ci_as WHERE ID= '" + TID + "'";
                    using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                    {
                        //SqlCommand command = new SqlCommand(query, sc.OpenConectionTracer());
                        cmd.CommandTimeout = 120; // 2 minutos (valor en segundos)
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SacaSC.Text = reader["SACA"].ToString();
                            ColorSC.Text = reader["Color"].ToString();
                            TallaSC.Text = reader["Talla"].ToString();
                            MillStyleSC.Text = reader["MillStyle"].ToString();
                            //MachDev.Text = reader["Maquina"].ToString();
                            //CelulaDev.Text = reader["Celula"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para: " + TID);
                            TraceIDSobreConsumo.Clear();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            sc.OpenConectionTracer();
            string sql = @"SELECT DISTINCT 
                                    ss.sub_producto AS Item, 
                                    ss.sub_descripcion,
				                    ROUND(ROUND(c.dozens, 0) / ss.sub_factor, 0) AS Cantidad,
				                    I.Localidad            
                                    FROM            dbo.pmc_ProductMaster AS P INNER JOIN
                                    dbo.pmc_ConsolidadoPlanes AS c ON P.saca = c.sku INNER JOIN
                                    dbo.pmc_SACA_1as_2das_3ras AS s ON P.saca = s.pmc_SACA_1ra INNER JOIN
                                    dbo.pmc_Doblado_IRR AS d ON s.pmc_SACA_2da = d.pmc_SACA_IRR INNER JOIN
                                    dbo.View_Transactions AS k ON P.saca = k.SACA INNER JOIN
                                    ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON P.saca = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
						            INNER JOIN dbo.pmc_Inventario AS I
						            ON I.Item = ss.sub_producto  COLLATE SQL_Latin1_General_CP1_CI_AS
                                    WHERE     Status='STK' AND k.TraceID = '" + TID + "'";
            GridItems.Columns.Clear();
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            checkBoxColumn.FieldName = "Selected";
            checkBoxColumn.HeaderText = "Selección";
            checkBoxColumn.Width = 40;
            GridItems.Columns.Add(checkBoxColumn);
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "sub_descripcion", HeaderText = "Descripción" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
            GridItems.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            GridItems.MultiSelect = true;
            GridItems.SelectionMode = GridViewSelectionMode.FullRowSelect;
            GridItems.DataSource = dataTable;
            GridItems.Refresh();
        }
        private void GridItems_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if(!this.GridItems.CurrentRow.Cells["Selected"].IsSelected)
            {
                return;
            }
        }
        private List<DataRow> GetSelectedRows()
        {
            List<DataRow> selectedRows = new List<DataRow>();

            foreach (GridViewRowInfo rowInfo in GridItems.Rows)
            {
                // Verifica si la celda de CheckBox está marcada
                if (rowInfo.Cells["Selected"].Value != null && (bool)rowInfo.Cells["Selected"].Value)
                {
                    selectedRows.Add(((DataRowView)rowInfo.DataBoundItem).Row);
                }
            }

            return selectedRows;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        { 
            if (Despstick.Checked)
            {
                if (string.IsNullOrEmpty(userSTK.Text))
                {
                    MessageBox.Show("Ingrese su código por favor...");
                }
                else
                {
                    List<DataRow> selectedRows = GetSelectedRows();
                    if (selectedRows.Count > 0)
                    {
                        if (!DespStk1.Checked && !DespStk2.Checked && !DespStk3.Checked)
                        {
                            MessageBox.Show("Debe seleccionar el motivo de devolución.");
                            return;
                        }
                        foreach (DataRow row in selectedRows)
                        {
                            string item = row["Item"].ToString();
                            string desc = row["sub_descripcion"].ToString();
                            string cantidad = row["Cantidad"].ToString();
                            string localidad = row["Localidad"].ToString();
                            string Traceid = TraceIDStk.Text;
                            string User = userSTK.Text.ToString();
                            string Saca = SacaStk.Text.ToString();
                            string Talla = TallaStk.Text.ToString();
                            string Color = ColorStk.Text.ToString();
                            string MillStyle = MillStyleStk.Text.ToString();
                            string Celulastk = CelulaStk.Text;
                            string extractedUser = string.Empty;

                            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                            {
                                conn.Open(); // Open the connection here
                                if (this.userSTK.TextLength >= 17)
                                {
                                    // Obtenemos la posición de la 'ñ' y el siguiente guion bajo '_'
                                    int posInicial = this.userSTK.Text.IndexOf('ñ') + 1; // +1 para movernos después de la 'ñ'
                                    int posFinal = this.userSTK.Text.IndexOf('_', posInicial);
                                    if (posInicial > 0 && posFinal > posInicial)
                                    {
                                        // Extraemos la subcadena
                                        string subcadena = this.userSTK.Text.Substring(posInicial, posFinal - posInicial);
                                        string numeros = new string(subcadena.Where(char.IsDigit).ToArray());
                                        extractedUser = new string(subcadena.Where(char.IsDigit).ToArray());
                                        //vamos a traernos a pantalla el nombre 
                                        sc.OpenConectionTracer();
                                        string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User"; ;
                                        using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                        {
                                            cmd2.Parameters.AddWithValue("@User", extractedUser);
                                            int userCount = (int)cmd2.ExecuteScalar();
                                            if (userCount == 0)
                                            {
                                                MessageBox.Show("El usuario no tiene permisos de solicitante");
                                                return;
                                            }
                                        }
                                        //sc.CloseConectionTracer();
                                    }
                                }
                                else if (userSTK.TextLength == 5)
                                {
                                    // Process for manually entered input
                                    extractedUser = userSTK.Text;

                                    string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User";
                                    using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                    {
                                        sc.OpenConectionTracer();
                                        cmd2.Parameters.AddWithValue("@User", extractedUser);
                                        int userCount = (int)cmd2.ExecuteScalar();
                                        if (userCount == 0)
                                        {
                                            MessageBox.Show("El usuario no tiene permisos de solicitante");
                                            return;
                                        }
                                    }
                                }
                            }

                            sc.OpenConectionTracer();
                            if (DespStk1.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioStickerado] ([DespStk_TraceID],[DespStk_SACA],[DespStk_MillStyle],[DespStk_Talla]
                                    ,[DespStk_Color],[DespStk_Devolucion],[DespStk_Codigo],[DespStk_Descripcion] ,[DespStk_Cantidad] 
                                    ,[DespStk_Localidad] ,[DespStk_Usuario] ,[DespStk_Fecha]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','Desperdicio de impresor','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE())";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                            else if (DespStk2.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioStickerado] ([DespStk_TraceID],[DespStk_SACA],[DespStk_MillStyle],[DespStk_Talla]
                                    ,[DespStk_Color],[DespStk_Devolucion],[DespStk_Codigo],[DespStk_Descripcion] ,[DespStk_Cantidad] 
                                    ,[DespStk_Localidad] ,[DespStk_Usuario] ,[DespStk_Fecha]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','Desperdicio de proveedor','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE())";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                            else if (DespStk3.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioStickerado] ([DespStk_TraceID],[DespStk_SACA],[DespStk_MillStyle],[DespStk_Talla]
                                    ,[DespStk_Color],[DespStk_Devolucion],[DespStk_Codigo],[DespStk_Descripcion] ,[DespStk_Cantidad] 
                                    ,[DespStk_Localidad] ,[DespStk_Usuario] ,[DespStk_Fecha]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','Desperdicio de proceso','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE())";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                        }
                        userSTK.Clear();
                        TraceIDStk.Clear();
                        SacaStk.Text = string.Empty;
                        TallaStk.Text = string.Empty;
                        ColorStk.Text = string.Empty;
                        MillStyleStk.Text = string.Empty;
                        GridItems.DataSource = null;
                        DespStk1.Checked = false;
                        DespStk2.Checked = false;
                        DespStk3.Checked = false;
                        Stickerado();
                    }
                    else
                    {
                        MessageBox.Show("No hay elementos seleccionados.");
                    }
                }
            }
        else if (Dev.Checked)
            {
                if (string.IsNullOrEmpty(UserDevolucion.Text))
                {
                    MessageBox.Show("Ingrese su código por favor...");
                }
                else
                {
                    List<DataRow> selectedRows = GetSelectedRows();
                    if (selectedRows.Count > 0)
                    {
                        if (!ErrorDev.Checked)
                        {
                            MessageBox.Show("Debe seleccionar el motivo de devolución.");
                            return;
                        }
                        foreach (DataRow row in selectedRows)
                        {
                            string item = row["Item"].ToString();
                            string desc = row["sub_descripcion"].ToString();
                            string cantidad = row["Cantidad"].ToString();
                            string localidad = row["Localidad"].ToString();
                            string Traceid = TraceIDFinDev.Text;
                            string User = UserDevolucion.Text.ToString();
                            string Saca = SacaDev.Text.ToString();
                            string Talla = TallaDev.Text.ToString();
                            string Color = ColorDev.Text.ToString();
                            string MillStyle = MillStyleDev.Text.ToString();
                            string Machine = MachDev.Text.ToString();
                            string Celula = CelulaDev.Text.ToString();
                            string extractedUser = string.Empty;

                            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                            {
                                conn.Open(); // Open the connection here
                                if (this.UserDevolucion.TextLength >= 17)
                                {
                                    // Obtenemos la posición de la 'ñ' y el siguiente guion bajo '_'
                                    int posInicial = this.UserDevolucion.Text.IndexOf('ñ') + 1; // +1 para movernos después de la 'ñ'
                                    int posFinal = this.UserDevolucion.Text.IndexOf('_', posInicial);
                                    if (posInicial > 0 && posFinal > posInicial)
                                    {
                                        // Extraemos la subcadena
                                        string subcadena = this.UserDevolucion.Text.Substring(posInicial, posFinal - posInicial);
                                        string numeros = new string(subcadena.Where(char.IsDigit).ToArray());
                                        extractedUser = new string(subcadena.Where(char.IsDigit).ToArray());
                                        //vamos a traernos a pantalla el nombre 
                                        sc.OpenConectionTracer();
                                        string sql2 = "SELECT COUNT(1) FROM [dbo].[pmc_Requester] WHERE [requester_id] = @User"; ;
                                        using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                        {
                                            cmd2.Parameters.AddWithValue("@User", extractedUser);
                                            int userCount = (int)cmd2.ExecuteScalar();
                                            if (userCount == 0)
                                            {
                                                MessageBox.Show("El usuario no tiene permisos de solicitante");
                                                return;
                                            }
                                        }
                                        //sc.CloseConectionTracer();
                                    }
                                }
                                else if (UserDevolucion.TextLength == 5)
                                {
                                    // Process for manually entered input
                                    extractedUser = UserDevolucion.Text;

                                    string sql2 = "SELECT COUNT(1) FROM [dbo].[pmc_Requester] WHERE [requester_id] = @User";
                                    using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                    {
                                        sc.OpenConectionTracer();
                                        cmd2.Parameters.AddWithValue("@User", extractedUser);
                                        int userCount = (int)cmd2.ExecuteScalar();
                                        if (userCount == 0)
                                        {
                                            MessageBox.Show("El usuario no tiene permisos de solicitante");
                                            return;
                                        }
                                    }
                                }
                            } 
                            sc.OpenConectionTracer();
                            if (ErrorDev.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_Sobrantes] ([Sob_TraceID],[Sob_SACA],[Sob_MillStyle] ,[Sob_Talla],[Sob_Color],[Sob_Maquina] ,[Sob_Celula],[Sob_Devolucion],[Sob_Codigo],[Sob_Descripcion],[Sob_Cantidad],[Sob_Localidad],[Sob_Usuario],[Sob_Fecha]) 
                                               VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','Error en Cantidad','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE())";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                        }
                        UserDevolucion.Clear();
                        TraceIDFinDev.Clear();
                        SacaDev.Text = string.Empty;
                        TallaDev.Text = string.Empty;
                        ColorDev.Text = string.Empty;
                        MillStyleDev.Text = string.Empty;
                        GridItems.DataSource = null;
                        ErrorDev.Checked = false;
                        Devolucion();
                    }
                    else
                    {
                        MessageBox.Show("No hay elementos seleccionados.");
                    }
                }
            }
        else if (Despfin.Checked)
            {
                if (string.IsNullOrEmpty(UserFin.Text))
                {
                    MessageBox.Show("Ingrese su código por favor...");
                }
                else
                {
                    List<DataRow> selectedRows = GetSelectedRows();
                    if (selectedRows.Count > 0)
                    {
                        if (!DespFin1.Checked && !DespFin2.Checked && !DespFin3.Checked && !DespFin4.Checked)
                        {
                            MessageBox.Show("Debe seleccionar el motivo de devolución.");
                            return;
                        }
                        foreach (DataRow row in selectedRows)
                        {
                            string item = row["Item"].ToString();
                            string desc = row["sub_descripcion"].ToString();
                            string cantidad = row["Cantidad"].ToString();
                            string localidad = row["Localidad"].ToString();
                            string Traceid = TraceIDFin.Text;
                            string User = UserFin.Text.ToString();
                            string Saca = SacaFin.Text.ToString();
                            string Talla = TallaFin.Text.ToString();
                            string Color = ColorFin.Text.ToString();
                            string MillStyle = MillStyleFin.Text.ToString();
                            string Machine = MachFin.Text.ToString();
                            string Celula = CelulaFin.Text.ToString();
                            string extractedUser = string.Empty;

                            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                            {
                                conn.Open(); // Open the connection here
                                if (this.UserFin.TextLength >= 17)
                                {
                                    // Obtenemos la posición de la 'ñ' y el siguiente guion bajo '_'
                                    int posInicial = this.UserFin.Text.IndexOf('ñ') + 1; // +1 para movernos después de la 'ñ'
                                    int posFinal = this.UserFin.Text.IndexOf('_', posInicial);
                                    if (posInicial > 0 && posFinal > posInicial)
                                    {
                                        // Extraemos la subcadena
                                        string subcadena = this.UserFin.Text.Substring(posInicial, posFinal - posInicial);
                                        string numeros = new string(subcadena.Where(char.IsDigit).ToArray());
                                        extractedUser = new string(subcadena.Where(char.IsDigit).ToArray());
                                        //vamos a traernos a pantalla el nombre 
                                        sc.OpenConectionTracer();
                                        string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User"; ;
                                        using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                        {
                                            cmd2.Parameters.AddWithValue("@User", extractedUser);
                                            int userCount = (int)cmd2.ExecuteScalar();
                                            if (userCount == 0)
                                            {
                                                MessageBox.Show("El usuario no tiene permisos de solicitante");
                                                return;
                                            }
                                        }
                                        //sc.CloseConectionTracer();
                                    }
                                }
                                else if (UserFin.TextLength == 5)
                                {
                                    // Process for manually entered input
                                    extractedUser = UserFin.Text;

                                    string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User";
                                    using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                    {
                                        sc.OpenConectionTracer();
                                        cmd2.Parameters.AddWithValue("@User", extractedUser);
                                        int userCount = (int)cmd2.ExecuteScalar();
                                        if (userCount == 0)
                                        {
                                            MessageBox.Show("El usuario no tiene permisos de solicitante");
                                            return;
                                        }
                                    }
                                }
                            }

                            //MessageBox.Show($"Item: {item}, Descripcion: {desc}, Cantidad: {cantidad}, Localidad: {localidad}, Traceid: {Traceid},Usuario: {User},Saca: {Saca},Talla: {Talla},Color: {Color},MillStyle: {MillStyle}");
                            sc.OpenConectionTracer();
                            if (DespFin1.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioFinishing] ([DespFin_TraceID],[DespFin_SACA],[DespFin_MillStyle],[DespFin_Talla],[DespFin_Color],[DespFin_Maquina],[DespFin_Celula],[DespFin_Devolucion],[DespFin_Codigo],[DespFin_Descripcion] ,[DespFin_Cantidad] 
                                    ,[DespFin_Localidad] ,[DespFin_Usuario] ,[DespFin_Fecha],[Status]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','Desperdicio de Calidad','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE(),'P')";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                            else if (DespFin2.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioFinishing] ([DespFin_TraceID],[DespFin_SACA],[DespFin_MillStyle],[DespFin_Talla],[DespFin_Color],[DespFin_Maquina],[DespFin_Celula],[DespFin_Devolucion],[DespFin_Codigo],[DespFin_Descripcion] ,[DespFin_Cantidad] 
                                    ,[DespFin_Localidad] ,[DespFin_Usuario] ,[DespFin_Fecha],[Status]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','Desperdicio de Selladora','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE(),'P')";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                            else if (DespFin3.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioFinishing] ([DespFin_TraceID],[DespFin_SACA],[DespFin_MillStyle],[DespFin_Talla],[DespFin_Color],[DespFin_Maquina],[DespFin_Celula],[DespFin_Devolucion],[DespFin_Codigo],[DespFin_Descripcion] ,[DespFin_Cantidad] 
                                    ,[DespFin_Localidad] ,[DespFin_Usuario] ,[DespFin_Fecha],[Status]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','Desperdicio de Procesos','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE(),'P')";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                            else if(DespFin4.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_DesperdicioFinishing] ([DespFin_TraceID],[DespFin_SACA],[DespFin_MillStyle],[DespFin_Talla],[DespFin_Color],[DespFin_Maquina],[DespFin_Celula],[DespFin_Devolucion],[DespFin_Codigo],[DespFin_Descripcion] ,[DespFin_Cantidad] 
                                    ,[DespFin_Localidad] ,[DespFin_Usuario] ,[DespFin_Fecha],[Status]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','Desperdicio de Proveedor','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE(),'P')";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                        }
                        UserFin.Clear();
                        TraceIDFin.Clear();
                        SacaFin.Text = string.Empty;
                        TallaFin.Text = string.Empty;
                        ColorFin.Text = string.Empty;
                        MillStyleFin.Text = string.Empty;
                        GridItems.DataSource = null;
                        DespFin1.Checked = false;
                        DespFin2.Checked = false;
                        DespFin3.Checked = false;
                        DespFin4.Checked = false;
                        Finishing();
                    }
                    else
                    {
                        MessageBox.Show("No hay elementos seleccionados.");
                    }
                }

            }
            else if (Sbrconsumos.Checked)
            {
                if (string.IsNullOrEmpty(UserSC.Text))
                {
                    MessageBox.Show("Ingrese su código por favor...");
                }
                else
                {
                    List<DataRow> selectedRows = GetSelectedRows();
                    if (selectedRows.Count > 0)
                    {
                        if (!Entrega1.Checked && !Entrega2.Checked)
                        {
                            MessageBox.Show("Debe seleccionar el motivo de devolución.");
                            return;
                        }
                        foreach (DataRow row in selectedRows)
                        {
                            string item = row["Item"].ToString();
                            string desc = row["sub_descripcion"].ToString();
                            string cantidad = row["Cantidad"].ToString();
                            string localidad = row["Localidad"].ToString();
                            string Traceid = TraceIDSobreConsumo.Text;
                            string User = UserSC.Text.ToString();
                            string Saca = SacaSC.Text.ToString();
                            string Talla = TallaSC.Text.ToString();
                            string Color = ColorSC.Text.ToString();
                            string MillStyle = MillStyleSC.Text.ToString();
                            string Machine = MachSC.Text.ToString();
                            string Celula = CelulaSC.Text.ToString();
                            string extractedUser = string.Empty;

                            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                            {
                                conn.Open(); // Open the connection here,
                                if (this.UserSC.TextLength >= 17)
                                {
                                    // Obtenemos la posición de la 'ñ' y el siguiente guion bajo '_'
                                    int posInicial = this.UserSC.Text.IndexOf('ñ') + 1; // +1 para movernos después de la 'ñ'
                                    int posFinal = this.UserSC.Text.IndexOf('_', posInicial);
                                    if (posInicial > 0 && posFinal > posInicial)
                                    {
                                        // Extraemos la subcadena
                                        string subcadena = this.UserSC.Text.Substring(posInicial, posFinal - posInicial);
                                        string numeros = new string(subcadena.Where(char.IsDigit).ToArray());
                                        extractedUser = new string(subcadena.Where(char.IsDigit).ToArray());
                                        //vamos a traernos a pantalla el nombre 
                                        sc.OpenConectionTracer();
                                        string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User"; ;
                                        using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                        {
                                            cmd2.Parameters.AddWithValue("@User", extractedUser);
                                            int userCount = (int)cmd2.ExecuteScalar();
                                            if (userCount == 0)
                                            {
                                                MessageBox.Show("El usuario no tiene permisos de solicitante");
                                                return;
                                            }
                                        }
                                        //sc.CloseConectionTracer();
                                    }
                                }
                                else if (UserSC.TextLength == 5)
                                {
                                    // Process for manually entered input
                                    extractedUser = UserSC.Text;

                                    string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User";

                                    using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                                    {
                                        sc.OpenConectionTracer();
                                        cmd2.Parameters.AddWithValue("@User", extractedUser);
                                        int userCount = (int)cmd2.ExecuteScalar();
                                        if (userCount == 0)
                                        {
                                            MessageBox.Show("El usuario no tiene permisos de solicitante");
                                            return;
                                        }
                                    }
                                }
                            }
                            sc.OpenConectionTracer();
                            if (Entrega1.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_Sobreconsumos] ([Sobr_TraceID],[Sobr_SACA],[Sobr_MillStyle],[Sobr_Talla],[Sobr_Color],[Sobr_Maquina],[Sobr_Celula],[Sobr_Entrega],[Sobr_Codigo],[Sobr_Descripcion] ,[Sobr_Cantidad]
                                    ,[Sobr_Localidad] ,[Sobr_Usuario] ,[Sobr_Fecha],[Status]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','Inmediata','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE(),'P')";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                            else if (Entrega2.Checked)
                            {
                                string Q = @"INSERT INTO [dbo].[pmc_Sobreconsumos] ([Sobr_TraceID],[Sobr_SACA],[Sobr_MillStyle],[Sobr_Talla],[Sobr_Color],[Sobr_Maquina],[Sobr_Celula],[Sobr_Entrega],[Sobr_Codigo],[Sobr_Descripcion] ,[Sobr_Cantidad]
                                    ,[Sobr_Localidad] ,[Sobr_Usuario] ,[Sobr_Fecha],[Status]) VALUES ('" + Traceid + "','" + Saca + "','" + MillStyle + "','" + Talla + "','" + Color + "','" + Machine + "','" + Celula + "','No Inmediata','" + item + "','" + desc + "','" + cantidad + "','" + localidad + "','" + extractedUser + "',GETDATE(),'P')";
                                sc.EjecutarQueryTracer(Q);
                                GridDesperdicioStk.Refresh();
                            }
                        }
                        UserSC.Clear();
                        TraceIDSobreConsumo.Clear();
                        SacaSC.Text = string.Empty;
                        TallaSC.Text = string.Empty;
                        ColorSC.Text = string.Empty;
                        MillStyleSC.Text = string.Empty;
                        MachSC.Clear();
                        CelulaSC.Clear();
                        GridItems.DataSource = null;
                        Entrega1.Checked = false;
                        Entrega2.Checked = false;

                        SobreConsumos();
                    }
                    else
                    {
                        MessageBox.Show("No hay elementos seleccionados.");
                    }
                }
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (Dev.Checked)
            {
                sc.ExportarGrid(this.GridDesperdicioStk);
                
                MessageBox.Show("No hay elementos seleccionados.");
            }
            else if (Despstick.Checked)
            {
                sc.ExportarGrid(this.GridDesperdicioStk);
            }
            else if (Despfin.Checked)
            {
                sc.ExportarGrid(this.GridDesperdicioStk);
            }
            else if (Sbrconsumos.Checked)
            {
                sc.ExportarGrid(this.GridDesperdicioStk);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (Dev.Checked)
            {
                CargaDatosDev();
            }
            else if (Despstick.Checked)
            {
                CargaDatosStickerado();
            }
            else if (Despfin.Checked)
            {
                CargaDatosFinishing();
            }
            else if (Sbrconsumos.Checked)
            {
                CargaDatosSobreConsumos();
            }    
        }

        private void CelulaSC_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT Celula FROM pmc_Celulas WHERE Celula LIKE @celula + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@celula", CelulaSC.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["Celula"].ToString());
                    }

                    CelulaSC.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void MachSC_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT MachID FROM pmc_Maquinas WHERE MachID LIKE @Machine + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Machine",MachSC.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["MachID"].ToString());
                    }

                    MachSC.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void MachFin_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT MachID FROM pmc_Maquinas WHERE MachID LIKE @Machine + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Machine", MachFin.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["MachID"].ToString());
                    }

                    MachFin.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void CelulaFin_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT Celula FROM pmc_Celulas WHERE Celula LIKE @celula + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@celula", CelulaFin.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["Celula"].ToString());
                    }

                    CelulaFin.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void MaquinaStk_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT MachID FROM pmc_Maquinas WHERE MachID LIKE @Machine + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Machine", MaquinaStk.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["MachID"].ToString());
                    }

                    MaquinaStk.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void CelulaStk_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT Celula FROM pmc_Celulas WHERE Celula LIKE @celula + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@celula", CelulaStk.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["Celula"].ToString());
                    }

                    CelulaStk.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void MachDev_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT MachID FROM pmc_Maquinas WHERE MachID LIKE @Machine + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Machine", MachDev.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["MachID"].ToString());
                    }

                    MachDev.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void CelulaDev_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT Celula FROM pmc_Celulas WHERE Celula LIKE @celula + '%'";

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@celula", CelulaDev.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        autoCompleteCollection.Add(reader["Celula"].ToString());
                    }

                    CelulaDev.AutoCompleteCustomSource = autoCompleteCollection;
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex.Message);
                }
            }
        }

        private void rbtnActualizar_Click(object sender, EventArgs e)
        {
            //if(chec)
        }
    }
}
