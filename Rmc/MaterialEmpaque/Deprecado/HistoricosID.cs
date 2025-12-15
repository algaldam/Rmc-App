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
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque
{
    public partial class HistoricosID : Telerik.WinControls.UI.RadForm
    {
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        SystemClass sc = new SystemClass();
        SqlCommand cm = null;

        public HistoricosID()
        {
            InitializeComponent();
            sc.formarDatedMyHms(this.rdtpInicio);
            sc.formarDatedMyHms(this.rdtpFin);
        }

        private void HistoricosID_Load(object sender, EventArgs e)
        {
            cbxTID.Checked = true;
            LlenarDatos();
        }
        private void LlenarDatos()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string q = @"SELECT [ID]
                        ,[SACA]
                        ,[MillStyle]
                        ,[Talla]
                        ,[Color]
                        ,[WeekID]
                        ,[Desviacion]
                        ,[DesvMaterial]
                        ,[Docenas]
                        ,[MesaID]
                        ,[DT]
                        FROM [pmc_InventarioByTraceID]";
                HistoricoGrid.Columns.Clear();
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID", HeaderText = "ID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "SACA", HeaderText = "SACA" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MillStyle", HeaderText = "MillStyle" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Talla", HeaderText = "Talla" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Color", HeaderText = "Color" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "WeekID", HeaderText = "WeekID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Desviacion", HeaderText = "Desviacion" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DesvMaterial", HeaderText = "DesvMaterial" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Docenas", HeaderText = "Docenas" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MesaID", HeaderText = "Mesa Asignada" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DT", HeaderText = "DT" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
                HistoricoGrid.DataSource = dataTable;
                int numeroRegistros = dataTable.Rows.Count;
                ContadorItems.Text = numeroRegistros.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                 if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
        private void LlenarDatosConFiltros()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string q = @"SELECT [ID]
                        ,[SACA]
                        ,[MillStyle]
                        ,[Talla]
                        ,[Color]
                        ,[WeekID]
                        ,[Desviacion]
                        ,[DesvMaterial]
                        ,[Docenas]
                        ,[MesaID]
                        ,[DT]
                        FROM [pmc_InventarioByTraceID] where DT Between '" + sc.FormatSQLDate(rdtpInicio.Value) + "' and '" + sc.FormatSQLDate(rdtpFin.Value) + "'";
                HistoricoGrid.Columns.Clear();
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID", HeaderText = "ID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "SACA", HeaderText = "SACA" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MillStyle", HeaderText = "MillStyle" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Talla", HeaderText = "Talla" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Color", HeaderText = "Color" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "WeekID", HeaderText = "WeekID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Desviacion", HeaderText = "Desviacion" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DesvMaterial", HeaderText = "DesvMaterial" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Docenas", HeaderText = "Docenas" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MesaID", HeaderText = "Mesa Asignada" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DT", HeaderText = "DT" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
                HistoricoGrid.DataSource = dataTable;
                int numeroRegistros = dataTable.Rows.Count;
                ContadorItems.Text = numeroRegistros.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
        private void LlenarDatosFiltrados()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string query = @"SELECT [ID]
                        ,[SACA]
                        ,[MillStyle]
                        ,[Talla]
                        ,[Color]
                        ,[WeekID]
                        ,[Desviacion]
                        ,[DesvMaterial]
                        ,[Docenas]
                        ,[MesaID]
                        ,[DT]
                        FROM [pmc_InventarioBySaca]";
                HistoricoGrid.Columns.Clear();
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID", HeaderText = "ID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "SACA", HeaderText = "SACA" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MillStyle", HeaderText = "MillStyle" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Talla", HeaderText = "Talla" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Color", HeaderText = "Color" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "WeekID", HeaderText = "WeekID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Desviacion", HeaderText = "Desviacion" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DesvMaterial", HeaderText = "Desv. Material" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Docenas", HeaderText = "Docenas" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MesaID", HeaderText = "Mesa Asignada" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DT", HeaderText = "DT" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                HistoricoGrid.DataSource = dataTable;
                int numeroRegistros = dataTable.Rows.Count;
                ContadorItems.Text = numeroRegistros.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos filtrados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
        private void LlenarDatosFiltradosConFiltro()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string query = @"SELECT [ID]
                        ,[SACA]
                        ,[MillStyle]
                        ,[Talla]
                        ,[Color]
                        ,[WeekID]
                        ,[Desviacion]
                        ,[DesvMaterial]
                        ,[Docenas]
                        ,[MesaID]
                        ,[DT]
                        FROM [pmc_InventarioBySaca] where DT Between '" + sc.FormatSQLDate(rdtpInicio.Value) + "' and '" + sc.FormatSQLDate(rdtpFin.Value) + "'";
                HistoricoGrid.Columns.Clear();
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID", HeaderText = "ID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "SACA", HeaderText = "SACA" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MillStyle", HeaderText = "MillStyle" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Talla", HeaderText = "Talla" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Color", HeaderText = "Color" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "WeekID", HeaderText = "WeekID" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Desviacion", HeaderText = "Desviacion" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DesvMaterial", HeaderText = "Desv. Material" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Docenas", HeaderText = "Docenas" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "MesaID", HeaderText = "Mesa Asignada" });
                HistoricoGrid.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DT", HeaderText = "DT" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                HistoricoGrid.DataSource = dataTable;
                int numeroRegistros = dataTable.Rows.Count;
                ContadorItems.Text = numeroRegistros.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos filtrados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        private void cbxTID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTID.Checked)
            {
                LlenarDatos();               
                cbxFiltrado.Checked = false;
            }
            else
            {
                cbxTID.Checked = false;
            }
        }

        private void cbxFiltrado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFiltrado.Checked)
            {
                LlenarDatosFiltrados();
                cbxTID.Checked = false;
            }
            else
            {
                cbxFiltrado.Checked = false;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (cbxTID.Checked)
            {
                LlenarDatosConFiltros();
            }
            else if (cbxFiltrado.Checked)
            {
                LlenarDatosFiltradosConFiltro();
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            sc.ExportarGrid2(this.HistoricoGrid, "Datos");
        }
    }
}
