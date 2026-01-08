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
    public partial class PreKiteoSACA : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        dsPMC ds = new dsPMC();

        public PreKiteoSACA()
        {
            InitializeComponent();
        }

        private void PreKiteoSACA_Load(object sender, EventArgs e)
        {
            CargarDatos();
            this.rDPTDesde.Value = DateTime.Now;
            this.rdptHasta.Value = DateTime.Now;
            this.lblcountTrans.Text = this.rgvDatos.RowCount.ToString();
            this.rgvDatos.CellFormatting += rgvDatos_CellFormatting;
        }

        private void rgvDatos_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Bin")
            {
                if (e.CellElement.Value != null && e.CellElement.Value.ToString() == "0")
                {
                    e.CellElement.Text = "";
                }
                else
                {
                    e.CellElement.Text = e.CellElement.Value.ToString();
                }
            }
        }

        private void CargarDatos()
        {
            sc.OpenConection();
            string query = "SELECT ID,SACA,MillStyle,Color,Talla,WeekID,Desviacion, DesvMaterial, Docenas,dt,bin,codigo, BOM, Materiales, DT_Processed  FROM [dbo].[pmc_InventarioBySACA] ";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    rgvDatos.DataSource = dataTable;
                    foreach (GridViewRowInfo row in rgvDatos.Rows)
                    {
                        ApplyRowFormatting(row);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
            this.lblcountTrans.Text = this.rgvDatos.RowCount.ToString();
        }

        private void ApplyRowFormatting(GridViewRowInfo row)
        {
            for (int j = 0; j < rgvDatos.ColumnCount; j++)
            {
                if (Convert.ToInt32(row.Cells["BOM"].Value) == 1 && Convert.ToInt32(row.Cells["Materiales"].Value) == 1)
                {
                    row.Cells[j].Style.CustomizeFill = true;
                    row.Cells[j].Style.BackColor = Color.FromArgb(46, 204, 113);  // Verde
                }
                else if (Convert.ToInt32(row.Cells["BOM"].Value) == 1 && Convert.ToInt32(row.Cells["Materiales"].Value) == 0)
                {
                    row.Cells[j].Style.CustomizeFill = true;
                    row.Cells[j].Style.BackColor = Color.FromArgb(255, 255, 0);  // Amarillo
                }
                else if (Convert.ToInt32(row.Cells["BOM"].Value) == 0 && Convert.ToInt32(row.Cells["Materiales"].Value) == 1)
                {
                    row.Cells[j].Style.CustomizeFill = true;
                    row.Cells[j].Style.BackColor = Color.FromArgb(255, 165, 0);  // Naranja
                }
                else
                {
                    row.Cells[j].Style.CustomizeFill = true;
                    row.Cells[j].Style.BackColor = Color.FromArgb(255, 255, 255);  // Blanco
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            sc.ExportarGrid2(this.rgvDatos, "Datos");
        }

        private void btnConsultarPreKiteo_Click(object sender, EventArgs e)
        {     
            string query = "SELECT ID, SACA, MillStyle, Color, Talla, WeekID, Desviacion, DesvMaterial, Docenas,BOM,Materiales, dt, bin, codigo, DT_Processed " +
                           "FROM [pmc_InventarioBySACA] " +
                           "WHERE dt BETWEEN @FechaDesde AND @FechaHasta";
            DataTable Dt = new DataTable();
            string fechaDesde = this.rDPTDesde.Value.ToString("yyyy-MM-dd HH:mm:ss.000");
            string fechaHasta = this.rdptHasta.Value.ToString("yyyy-MM-dd HH:mm:ss.000");
            sc.OpenConectionTracer();
            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(Dt);
                }
            }
            rgvDatos.DataSource = Dt;
            sc.CloseConectionTracer();
        }

        private void txtIDPreKiteo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                try
                {
                    this.TxtDesv.Focus();
                }
                catch
                {
                }
            }
        }

        private void TxtDesv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                try
                {
                    this.txtCodigo.Focus();
                }
                catch
                {
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                this.TxtBin.Focus();
            }
        }

        private void TxtBin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                if (string.IsNullOrWhiteSpace(txtIDPreKiteo.Text))
                {
                    MessageBox.Show("Debe ingresar un ID en el campo TraceID.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDPreKiteo.Focus();
                    return;
                }
                try
                {
                    string idPreKiteo = txtIDPreKiteo.Text;
                    string traceID = idPreKiteo;
                    string selectQuery = @"SELECT [ItemID], [Item], [Descripción], [Cantidad], [Localidad], [ID_Caja], [Status], [Devolucion], [Usuario], [Fecha], [TraceID] FROM [dbo].[pmc_Inventario] WHERE Status='tbl' AND TraceID = @ItemID";
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ItemID", idPreKiteo);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Close(); 
                                string updateQuery = "UPDATE [pmc_InventarioBySaca] SET Bin = @Bin, Codigo = @Codigo, DT_Processed = @DT_Processed WHERE ID = @ID";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                                {
                                    updateCmd.Parameters.AddWithValue("@Bin", TxtBin.Text);
                                    updateCmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                                    updateCmd.Parameters.AddWithValue("@DT_Processed", DateTime.Now);
                                    updateCmd.Parameters.AddWithValue("@ID", idPreKiteo);
                                    int rowsAffected = updateCmd.ExecuteNonQuery();
                                    MessageBox.Show($"{rowsAffected} registro(s) actualizado(s) correctamente.");



                                    string insertQuery = @"INSERT INTO [dbo].[pmc_Inventario] 
                                                   ([Item], [Descripción], [Cantidad], [Localidad], [ID_Caja], [Status], [Devolucion], [Usuario], [Fecha], [TraceID])
                                                   SELECT  [Item], [Descripción], [Cantidad], [Localidad], [ID_Caja], 'C-BIN', [Devolucion], [Usuario], GETDATE(), @traceID
                                                   FROM [dbo].[pmc_Inventario]
                                                   WHERE TRACEID = @ItemID AND Status = 'TBL'";
                                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                                    {
                                        insertCmd.Parameters.AddWithValue("@ItemID", idPreKiteo);
                                        insertCmd.Parameters.AddWithValue("@traceID", traceID);
                                        int insertRowsAffected = insertCmd.ExecuteNonQuery();
                                        MessageBox.Show("Validación correcta!");
                                    }
                                    CargarDatos();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe procesar el ID en Salidas de Materiales.");
                            }
                        }
                        connection.Close();
                    }
                    this.TxtBin.Clear();
                    this.txtCodigo.Clear();
                    this.TxtDesv.Clear();
                    this.txtIDPreKiteo.Clear();
                    this.txtIDPreKiteo.Focus();
                    this.txtIDPreKiteo.SelectAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }

        private void rgvDatos_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < rgvDatos.ColumnCount; j++)
            {
                if (Convert.ToInt32(rgvDatos.CurrentRow.Cells["BOM"].Value) == 1 && Convert.ToInt32(rgvDatos.CurrentRow.Cells["Materiales"].Value) == 1)
                {
                    rgvDatos.CurrentRow.Cells[j].Style.CustomizeFill = true;
                    rgvDatos.CurrentRow.Cells[j].Style.BackColor = Color.FromArgb(46, 204, 113);
                }
                else if (Convert.ToInt32(rgvDatos.CurrentRow.Cells["BOM"].Value) == 1 && Convert.ToInt32(rgvDatos.CurrentRow.Cells["Materiales"].Value) == 0)
                {
                    rgvDatos.CurrentRow.Cells[j].Style.CustomizeFill = true;
                    rgvDatos.CurrentRow.Cells[j].Style.BackColor = Color.FromArgb(255, 255, 0);
                }
                else if (Convert.ToInt32(rgvDatos.CurrentRow.Cells["BOM"].Value) == 0 && Convert.ToInt32(rgvDatos.CurrentRow.Cells["Materiales"].Value) == 1)
                {
                    rgvDatos.CurrentRow.Cells[j].Style.CustomizeFill = true;
                    rgvDatos.CurrentRow.Cells[j].Style.BackColor = Color.FromArgb(255, 165, 0);
                }
                else
                {
                    rgvDatos.CurrentRow.Cells[j].Style.CustomizeFill = true;
                    rgvDatos.CurrentRow.Cells[j].Style.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        private void rgvDatos_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
        }

        private void rgvDatos_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row != null && e.Column.Name == "BOM" || e.Column.Name == "Materiales")
            {
                string id = e.Row.Cells["ID"].Value.ToString();
                bool bomChecked = Convert.ToBoolean(e.Row.Cells["BOM"].Value);
                bool materialesChecked = Convert.ToBoolean(e.Row.Cells["Materiales"].Value);

                // Actualiza la base de datos
                string query = "UPDATE pmc_InventarioBySaca SET BOM = @BOM, MATERIALES = @MATERIALES WHERE ID = @ID";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@BOM", bomChecked ? 1 : 0);
                            cmd.Parameters.AddWithValue("@MATERIALES", materialesChecked ? 1 : 0);
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el estado: " + ex.Message);
                    }
                }
            }
        }
    }
}
