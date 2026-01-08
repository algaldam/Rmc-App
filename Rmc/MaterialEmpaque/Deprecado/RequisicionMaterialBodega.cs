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
    public partial class RequisicionMaterialBodega : Telerik.WinControls.UI.RadForm
    {
        public RequisicionMaterialBodega()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        SqlConnection cn1 = new SqlConnection(Properties.Settings.Default.ES_SOCKS_StagingAreaConnectionString);
        SystemClass sc = new SystemClass();

        private void CargaDatosDesperdicioFinishing()
        {
            sc.OpenConection();
            string query = @"SELECT DISTINCT 
                            	[DespFin_TraceID],
                                [DespFin_SACA],
                            	[DespFin_Maquina],
                            	[DespFin_Celula],
                                SUM(TRY_CAST([DespFin_Cantidad] AS DECIMAL(18, 0))) AS Cantidad
                            FROM [pmc_DesperdicioFinishing] Where Status='P'
                            GROUP BY [DespFin_SACA],[DespFin_TraceID],[DespFin_Maquina],[DespFin_Celula]";
            GridSolicitudes.Columns.Clear();
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_TraceID", HeaderText = "TraceID" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_SACA", HeaderText = "SACA" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Maquina", HeaderText = "Maquina" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Celula", HeaderText = "Célula" });         
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Qtty.", Width = 30 });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            GridSolicitudes.DataSource = dataTable;
            GridSolicitudes.RowFormatting += GridSolicitudes_RowFormatting;
            GridSolicitudes.CurrentRowChanged += GridSolicitudes_CurrentRowChanged;
        }
        private void CargaDatosSobreconsumos()
        {
            sc.OpenConection();
            string query = @"SELECT DISTINCT
                                 [Sobr_TraceID]
                                 ,[Sobr_SACA]
                                 ,[Sobr_Maquina]
                                 ,[Sobr_Celula]                             
                                  ,SUM(TRY_CAST([Sobr_Cantidad] AS DECIMAL(18, 0))) AS Cantidad
                             FROM [pmc_Sobreconsumos]  WHERE Status='P'GROUP BY  
                                  [Sobr_SACA],[Sobr_TraceID],[Sobr_Maquina],[Sobr_Celula] ";
            GridSolicitudes.Columns.Clear();
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_TraceID", HeaderText = "TraceID" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_SACA", HeaderText = "SACA" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Maquina", HeaderText = "Maquina" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Celula", HeaderText = "Célula" });
            GridSolicitudes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Qtty." });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            dataAdapter.Fill(dataTable);
            GridSolicitudes.DataSource = dataTable;
            GridSolicitudes.RowFormatting += GridSolicitudes_RowFormatting;
            GridSolicitudes.CurrentRowChanged += GridSolicitudes_CurrentRowChanged;
        }
        private void GridSolicitudes_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            e.RowElement.DrawFill = true;
            e.RowElement.GradientStyle = GradientStyles.Solid;
            e.RowElement.BackColor = Color.LightGoldenrodYellow;
            e.RowElement.ForeColor = Color.Black;
        }

        private void chkboxSobreconsumo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxSobreconsumo.Checked)
            {
                CargaDatosSobreconsumos();
                chkboxDesperdicioFinishing.Checked = false;
            }
            else
            {
                chkboxSobreconsumo.Checked = false;
            }
        }
        private void chkboxDesperdicioFinishing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxDesperdicioFinishing.Checked)
            {
                chkboxDesperdicioFinishing.Checked = true;
                chkboxSobreconsumo.Checked = false;
                CargaDatosDesperdicioFinishing();       
            }
            else
            {
                chkboxDesperdicioFinishing.Checked = false;
            }
        }

        private void GridSolicitudes_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (chkboxSobreconsumo.Checked)
            {
                chkboxDesperdicioFinishing.Checked = false;
                if (e.OldRow is GridViewDataRowInfo oldDataRow)
                {
                    foreach (GridViewCellInfo cell in oldDataRow.Cells)
                    {
                        cell.Style.Reset();
                    }
                }
                if (e.CurrentRow is GridViewDataRowInfo newDataRow)
                {
                    foreach (GridViewCellInfo cell in newDataRow.Cells)
                    {
                        cell.Style.CustomizeFill = true;
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.Black;
                    }
                    if (newDataRow.Cells["Sobr_TraceID"] != null)
                    {
                        string SCCodigo = newDataRow.Cells["Sobr_TraceID"].Value?.ToString();
                        if (!string.IsNullOrEmpty(SCCodigo))
                        {
                            CargarDatosRelacionados1(SCCodigo);
                        }
                    }
                }
            }
            else if (chkboxDesperdicioFinishing.Checked)
            {
                chkboxSobreconsumo.Checked = false;
                SobreConsumosReport.ReportSource = null;
                SobreConsumosReport.RefreshReport();
                if (e.OldRow is GridViewDataRowInfo oldDataRow)
                {
                    foreach (GridViewCellInfo cell in oldDataRow.Cells)
                    {
                        cell.Style.Reset();
                    }
                }
                if (e.CurrentRow is GridViewDataRowInfo newDataRow)
                {
                    foreach (GridViewCellInfo cell in newDataRow.Cells)
                    {
                        cell.Style.CustomizeFill = true;
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.Black;
                    }
                    if (newDataRow.Cells["DespFin_TraceID"] != null)
                    {
                        string DesFinCodigo = newDataRow.Cells["DespFin_TraceID"].Value?.ToString();
                        if (!string.IsNullOrEmpty(DesFinCodigo))
                        {
                            CargarDatosRelacionados(DesFinCodigo);
                        }
                    }
                }
            }
        }

        private void GenerarReporteSobreconsumo(string sobrTraceID, int mesaID, int insertedId)
        {
            try
            {
                Reportes.ReportesDesign.Sobreconsumos report = new Reportes.ReportesDesign.Sobreconsumos();
                report.ReportParameters["SobrTraceID"].Value = sobrTraceID;
                report.ReportParameters["InsertedID"].Value = insertedId;
                report.ReportParameters["MesaID"].Value = mesaID;
                SobreConsumosReport.ReportSource = report;
                SobreConsumosReport.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }


        private void CargarDatosRelacionados(string despFinCodigo)
        {
            string query = @"SELECT  [DespFin_id],
                                [DespFin_TraceID],
                            	 [DespFin_SACA],
                            	 [DespFin_Maquina],
                            	 [DespFin_Celula],
                                 [DespFin_Codigo],
                                 [DespFin_Cantidad],
                            	 [DespFin_Devolucion]
                              FROM [pmc_DesperdicioFinishing] where Status='P' AND DespFin_TraceID=@DespFin_Codigo";
            rdgvDetalles.Columns.Clear();
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_TraceID", HeaderText = "TraceID" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_SACA", HeaderText = "SACA" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Maquina", HeaderText = "Maquina" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Celula", HeaderText = "Célula" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Codigo", HeaderText = "Item" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Cantidad", HeaderText = "Qtty.", Width = 30 });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_Devolucion", HeaderText = "Motivo", Width = 80 });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "DespFin_id", IsVisible = false });

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {            
                cmd.Parameters.AddWithValue("@DespFin_Codigo", despFinCodigo);
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                rdgvDetalles.DataSource = dataTable;
            }
        }
        private void CargarDatosRelacionados1(string SCCodigo)
        {
            string query = @"SELECT 
                               [Sobr_id],
                               [Sobr_TraceID],
                               [Sobr_SACA],
                               [Sobr_Maquina],
                               [Sobr_Celula],
                               [Sobr_Codigo],             
                               [Sobr_Cantidad],           
                               [Sobr_Entrega]
                          FROM [pmc_Sobreconsumos] WHERE  Status='P' AND Sobr_TraceID = @Sobr_Codigo";
            rdgvDetalles.Columns.Clear();
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_TraceID", HeaderText = "ID" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_SACA", HeaderText = "SACA" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Maquina", HeaderText = "Maquina" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Celula", HeaderText = "Célula" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Codigo", HeaderText = "Item" });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Cantidad", HeaderText = "Qtty.", Width = 30 });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_Entrega", HeaderText = "Entrega", Width = 80 });
            rdgvDetalles.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sobr_id", IsVisible = false });
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Sobr_Codigo", SCCodigo);
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
                rdgvDetalles.DataSource = dataTable;
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            if (rdgvDetalles.Rows.Count > 0)
            {
                bool columnaExiste = false;
                string columnName = string.Empty;
                if (chkboxDesperdicioFinishing.Checked)
                {
                    columnName = "DespFin_Cantidad";
                }
                else if (chkboxSobreconsumo.Checked)
                {
                    columnName = "Sobr_Cantidad";
                }
                if (!string.IsNullOrEmpty(columnName))
                {
                    foreach (GridViewColumn col in rdgvDetalles.Columns)
                    {
                        if (col.Name == columnName)
                        {
                            col.ReadOnly = false;
                            columnaExiste = true;
                        }
                        else
                        {
                            col.ReadOnly = true;
                        }
                    }
                    if (columnaExiste)
                    {
                        rdgvDetalles.ReadOnly = false;
                    }
                    else
                    {
                        MessageBox.Show($"La columna '{columnName}' no existe en el DataGridView.");
                    }
                }
                else
                {
                    MessageBox.Show("No hay ningún checkbox seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("No hay filas en el DataGridView.");
            }
        }

        private List<int> ObtenerMesasActivas()
        {
            List<int> mesasActivas = new List<int>();
            string query = "SELECT mesa FROM [dbo].[pmc_Mesas] WHERE Enable = 1";
            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object mesaObj = reader["mesa"];
                        int mesa;

                        if (mesaObj is int)
                        {
                            mesa = (int)mesaObj;
                        }
                        else if (mesaObj is short)
                        {
                            mesa = (short)mesaObj;
                        }
                        else if (mesaObj is long)
                        {
                            mesa = (int)(long)mesaObj;
                        }
                        else if (mesaObj is string)
                        {
                            if (!int.TryParse((string)mesaObj, out mesa))
                            {
                                throw new InvalidCastException("No se pudo convertir el valor de la columna 'mesa' a int");
                            }
                        }
                        else
                        {
                            throw new InvalidCastException("Tipo de datos inesperado para la columna 'mesa'");
                        }

                        mesasActivas.Add(mesa);
                    }
                }
            }
            return mesasActivas;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            int insertedId = 0;
            if (rdgvDetalles.Rows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(cn.ConnectionString + ";MultipleActiveResultSets=True"))
                {
                    try
                    {
                        conn.Open();
                        List<int> mesasActivas = ObtenerMesasActivas();
                        if (mesasActivas.Count == 0)
                        {
                            MessageBox.Show("No hay mesas activas disponibles.");
                            return;
                        }
                        if (chkboxDesperdicioFinishing.Checked)
                        {
                            List<string> despFinCodigos = new List<string>();
                            foreach (var row in rdgvDetalles.Rows)
                            {
                                if (row is GridViewDataRowInfo dataRow)
                                {
                                    string despFinCodigo = dataRow.Cells["DespFin_TraceID"].Value.ToString();
                                    string cantidad = dataRow.Cells["DespFin_Cantidad"].Value.ToString();
                                    int id = Convert.ToInt32(dataRow.Cells["DespFin_id"].Value.ToString());
                                    string query = @"UPDATE [pmc_DesperdicioFinishing] 
                                         SET Status='C', DespFin_Cantidad=@Cantidad 
                                         WHERE DespFin_TraceID=@DespFin_Codigo AND DespFin_id=@ID";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@DespFin_Codigo", despFinCodigo);
                                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                                        cmd.Parameters.AddWithValue("@ID", id);
                                        cmd.ExecuteNonQuery();
                                    } 
                                    if (!despFinCodigos.Contains(despFinCodigo))
                                    {
                                        despFinCodigos.Add(despFinCodigo);
                                    }
                                }
                            }
                            foreach (string codigo in despFinCodigos)
                            {
                                string queryUpdateStatus = @"UPDATE [pmc_DesperdicioFinishing] 
                                                            SET Status='C' 
                                                            WHERE DespFin_TraceID=@DespFin_Codigo";
                                using (SqlCommand cmd = new SqlCommand(queryUpdateStatus, conn))
                                {
                                    cmd.Parameters.AddWithValue("@DespFin_Codigo", codigo);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (chkboxSobreconsumo.Checked)
                        {
                            List<string> sobreconsumoCodigos = new List<string>();
                            foreach (var row in rdgvDetalles.Rows)
                            {
                                if (row is GridViewDataRowInfo dataRow)
                                {
                                    string sobreconsumoCodigo = dataRow.Cells["Sobr_TraceID"].Value.ToString();
                                    string cantidad = dataRow.Cells["Sobr_Cantidad"].Value.ToString();
                                    int id = Convert.ToInt32(dataRow.Cells["Sobr_id"].Value.ToString());
                                    string query = @"UPDATE [pmc_Sobreconsumos] 
                                                             SET Status='C', Sobr_Cantidad=@Cantidad 
                                                             WHERE Sobr_TraceID = @Sobr_Codigo AND Sobr_id = @ID";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@Sobr_Codigo", sobreconsumoCodigo);
                                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                                        cmd.Parameters.AddWithValue("@ID", id);
                                        cmd.ExecuteNonQuery();
                                    }
                                    if (!sobreconsumoCodigos.Contains(sobreconsumoCodigo))
                                    {
                                        sobreconsumoCodigos.Add(sobreconsumoCodigo);
                                    }
                                }
                            }
                            foreach (string codigo in sobreconsumoCodigos)
                            {
                                string querySelect = @"SELECT DISTINCT
                                P.saca,
                                Sobr_MillStyle AS MillStyle,
                                Sobr_Talla AS Talla, 
                                Sobr_Color AS Color,
                                CASE
                                    WHEN (SELECT lblDzByBuggie FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID) IS NOT NULL 
                                    THEN (SELECT lblDzByBuggie FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID)
                                    ELSE (SELECT lblDzByBuggie FROM pmc_InventarioBySaca WHERE id = k.Sobr_TraceID)
                                END AS lblDzByBuggie,
                                CASE 
                                    WHEN (SELECT WEEKID FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID) IS NOT NULL 
                                    THEN (SELECT WEEKID FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID)
                                    ELSE (SELECT WEEKID FROM pmc_InventarioBySaca WHERE id = k.Sobr_TraceID)
                                END AS WeekID,
                                CASE
                                    WHEN (SELECT Desviacion FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID) IS NOT NULL 
                                    THEN (SELECT Desviacion FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID)
                                    ELSE (SELECT Desviacion FROM pmc_InventarioBySaca WHERE id = k.Sobr_TraceID)
                                END AS Desviacion,
                                CASE
                                    WHEN (SELECT DesvMaterial FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID) IS NOT NULL 
                                    THEN (SELECT DesvMaterial FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID)
                                    ELSE (SELECT DesvMaterial FROM pmc_InventarioBySaca WHERE id = k.Sobr_TraceID)
                                END AS DesvMaterial,
                                CASE
                                    WHEN (SELECT DOCENAS FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID) IS NOT NULL 
                                    THEN (SELECT DOCENAS FROM pmc_InventarioByTraceID WHERE id = k.Sobr_TraceID)
                                    ELSE (SELECT DOCENAS FROM pmc_InventarioBySaca WHERE id = k.Sobr_TraceID)
                                END AS Docenas
                            FROM dbo.pmc_ProductMaster AS P
                            INNER JOIN dbo.pmc_ConsolidadoPlanes AS c ON P.saca = c.sku
                            INNER JOIN dbo.pmc_SACA_1as_2das_3ras AS s ON P.saca = s.pmc_SACA_1ra
                            INNER JOIN dbo.pmc_Doblado_IRR AS d ON s.pmc_SACA_2da = d.pmc_SACA_IRR
                            INNER JOIN dbo.pmc_Sobreconsumos AS k ON P.saca = k.Sobr_SACA
                            INNER JOIN dbo.pmc_UPC AS u ON k.sobr_SACA = u.upc_SACA
                            INNER JOIN ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON P.saca = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS 
                                AND ss.sub_producto = k.Sobr_Codigo COLLATE SQL_Latin1_General_CP1_CI_AS
                            WHERE k.Sobr_TraceID = @ID";
                                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                                {
                                    cmd.Parameters.AddWithValue("@ID", codigo);
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            string saca = reader["saca"].ToString();
                                            string millStyle = reader["MillStyle"].ToString();
                                            string talla = reader["Talla"].ToString();
                                            string color = reader["Color"].ToString();
                                            string lblDzByBuggie = reader["lblDzByBuggie"].ToString();
                                            string weekID = reader["WeekID"].ToString();
                                            string desviacion = reader["Desviacion"].ToString();
                                            string desvMaterial = reader["DesvMaterial"].ToString();
                                            string docenas = reader["Docenas"].ToString();
                                            int mesaAsignada = ObtenerMesaParaAsignarBySaca(mesasActivas);
                                            string queryInsert = @"INSERT INTO [pmc_InventarioBySACA] 
                                            ([SACA], [MillStyle], [Talla], [Color], [lblDzByBuggie], [WeekID], [Desviacion], [DesvMaterial], [Docenas],[mesaid], [DT],[BOM],[Materiales]) 
                                            VALUES (@Saca, @MillStyle, @Talla, @Color, @LblDzByBuggie, @WeekID, @Desviacion, @DesvMaterial, @Docenas,@MesaID, GETDATE(),0,0)
                                             SELECT SCOPE_IDENTITY()";
                                            using (SqlCommand insertCmd = new SqlCommand(queryInsert, conn))
                                            {
                                                insertCmd.Parameters.AddWithValue("@Saca", saca);
                                                insertCmd.Parameters.AddWithValue("@MillStyle", millStyle);
                                                insertCmd.Parameters.AddWithValue("@Talla", talla);
                                                insertCmd.Parameters.AddWithValue("@Color", color);
                                                insertCmd.Parameters.AddWithValue("@LblDzByBuggie", lblDzByBuggie);
                                                insertCmd.Parameters.AddWithValue("@WeekID", weekID);
                                                insertCmd.Parameters.AddWithValue("@Desviacion", desviacion);
                                                insertCmd.Parameters.AddWithValue("@DesvMaterial", desvMaterial);
                                                insertCmd.Parameters.AddWithValue("@Docenas", docenas);
                                                insertCmd.Parameters.AddWithValue("@MesaID", mesaAsignada);
                                                object result = insertCmd.ExecuteScalar();                                              
                                                if (result != null && int.TryParse(result.ToString(), out insertedId))
                                                {
                                                    MessageBox.Show($"El ID insertado es: {insertedId}");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se pudo obtener el ID insertado.");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (string codigo in sobreconsumoCodigos)
                            {
                                string queryUpdateStatus = @"UPDATE [pmc_Sobreconsumos] SET Status='C' WHERE Sobr_TraceID=@Sobr_Codigo";
                                using (SqlCommand cmd = new SqlCommand(queryUpdateStatus, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Sobr_Codigo", codigo);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            if (rdgvDetalles.Rows.Count > 0)
                            {
                                int mesaAsignada = ObtenerMesaParaAsignarBySaca(mesasActivas);
                                GenerarReporteSobreconsumo(sobreconsumoCodigos[0], mesaAsignada, insertedId);
                            }
                        }
                        rdgvDetalles.DataSource = null;
                        GridSolicitudes.DataSource = null;
                        rdgvDetalles.ReadOnly = true;
                        if (chkboxDesperdicioFinishing.Checked)
                        {
                            CargaDatosDesperdicioFinishing();
                            chkboxSobreconsumo.Checked = false;
                        }
                        else if (chkboxSobreconsumo.Checked)
                        {
                            CargaDatosSobreconsumos();
                            chkboxDesperdicioFinishing.Checked = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al actualizar los registros: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione al menos una fila del tablero.");
            }
        }

        private int ObtenerMesaParaAsignarBySaca(List<int> mesasActivas)
        {
            if (mesasActivas == null || mesasActivas.Count == 0)
            {
                throw new ArgumentException("La lista de mesas activas está vacía o es nula.");
            }
            string Q = "SELECT MESAID FROM [pmc_InventarioBySaca] WHERE DT = (SELECT MAX(DT) FROM [pmc_InventarioBySaca])";
            int mesaID = 0;
            int ultima = mesasActivas[mesasActivas.Count - 1];
            try
            {
                using (SqlCommand command = new SqlCommand(Q, sc.OpenConectionTracer()))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out mesaID))
                    {
                        foreach (int mesaId in mesasActivas)
                        {
                            if (mesaId > mesaID)
                            {
                                return mesaId;
                            }
                            else if (ultima == mesaId)
                            {
                                return mesasActivas[0];
                            }
                        }
                    }
                    else
                    {
                        return mesasActivas[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al obtener el MESAID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return mesasActivas[0];
            }
            return mesasActivas[0];
        }
    }
}
