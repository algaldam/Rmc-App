using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque
{
    public partial class InventarioMaterial : Telerik.WinControls.UI.RadForm
    {
        private List<string> traceIds = new List<string>();

        public InventarioMaterial()
        {
            InitializeComponent();
            AssortmentsTID.Visible = false;
            radPanel1.Visible = true;
            checkBox1.Checked = true;
            radPanel2.Visible = false;
            radPanel5.Visible = false;
            radPanel6.Visible = false;
            BoxSumRest.Enabled = false;
            DiffText.Enabled = false;
            AddInventory.Enabled = false;
            RestInventory.Enabled = false;
            IDBoxDevTxt.Enabled = false;
            DiffDev.Enabled = false;
            DiffCheck.Enabled = false;
            Errorcheck.Enabled = false;
            IDBoxInTxt.Enabled = false;
            CodMatInTxt.Enabled = false;
            QttyInTxt.Enabled = false;
            LocationInTxt.Enabled = false;
            TraceIDOutTxt.Enabled = false;
            SacaOutTxt.Enabled = false;
            FiltradoOutTxt.Enabled = false;
            lblItemDev.Enabled = false;
            IDBoxDevTxt.Enabled = false;
            QttyDev.Enabled = false;
            DiffDev.Enabled = false;
            localidadDev.Enabled = false;

        }
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        SqlConnection cn1 = new SqlConnection(Properties.Settings.Default.ES_SOCKS_StagingAreaConnectionString);
        SystemClass sc = new SystemClass();

        private void CargarDatosEnGrid()
        {
            try
            {
                sc.OpenConection();
                string query = "SELECT [Item], [Descripción], [Cantidad], [Localidad], [ID_Caja],[Usuario],[Fecha] FROM [pmc_Inventario] where Status='STK'";
                GridOrden.Columns.Clear();
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Item" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Descripción", HeaderText = "Descripción" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID_Caja", HeaderText = "Caja" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Usuario", HeaderText = "Usuario" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                GridOrden.DataSource = dataTable;
                GridOrden.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sc.CloseConection();
            }
        }
        private void CargarDatosEnGrid2()
        {
            try
            {
                sc.OpenConection();
                string query = @"SELECT [Sob_SACA],[Sob_MillStyle],[Sob_Talla],[Sob_Color],[Sob_Devolucion],[Sob_Codigo],[Sob_Descripcion],[Sob_Cantidad],[Sob_Localidad],[Sob_Fecha] FROM [pmc_Sobrantes]";
                GridSobrantes.Columns.Clear();
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_SACA", HeaderText = "SACA" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_MillStyle", HeaderText = "MillStyle" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Talla", HeaderText = "Talla" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Color", HeaderText = "Color" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Devolucion", HeaderText = "Devolucion" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Codigo", HeaderText = "Codigo" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Descripcion", HeaderText = "Descripcion" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Cantidad", HeaderText = "Cantidad" });
                GridSobrantes.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Sob_Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                GridSobrantes.DataSource = dataTable;
                GridSobrantes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sc.CloseConection();
            }
        }
        private void CargarDatosEnGrid1()
        {
            try
            {
                sc.OpenConection();
                string query = "SELECT [Item], [Descripción], [Cantidad], [Localidad], [ID_Caja],[Usuario],[Fecha] FROM [pmc_Inventario] where Status='DEV'";
                GridOrden.Columns.Clear();
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Item" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Descripción", HeaderText = "Descripción" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID_Caja", HeaderText = "Caja" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Usuario", HeaderText = "Usuario" });
                GridOrden.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Fecha", HeaderText = "Fecha" });
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                GridOrden.DataSource = dataTable;
                GridOrden.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sc.CloseConection();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                CargarDatosEnGrid();
                CargarDatosEnGrid2();
                radPanel1.Visible = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            else
            {
                radPanel1.Visible = false;
                IDBoxInTxt.Clear();
                UsuarioTxtIn.Clear();
                CodMatInTxt.Clear();
                QttyInTxt.Clear();
                LocationInTxt.Clear();
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                CargarDatosEnGrid();
                radPanel2.Visible = true;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            else
            {
                radPanel2.Visible = false;
                usertxtOut.Clear();
                TraceIDOutTxt.Clear();
                SacaOutTxt.Clear();
                GridItemsOut.DataSource = null;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                CargarDatosEnGrid1();
                radPanel5.Visible = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
            else
            {
                radPanel5.Visible = false;
                usertxtdev.Clear();
                IDBoxDevTxt.Clear();
                DiffDev.Clear();
                localidadDev.Text = null;
                lblItemDev.Text = null;
                DiffCheck.Checked = false;
                QttyDev.Text = null;
                Errorcheck.Checked = false;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                CargarDatosEnGrid1();
                radPanel6.Visible = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                radPanel6.Visible = false;
                BoxSumRest.Text = null;
                DiffText.Text = null;
                UserTxt.Text = null;
                lblItem.Text = null;
                lblStock.Text = null;
                lblLocalidad.Text = null;
            }
        }

        private void Errorcheck_CheckedChanged(object sender, EventArgs e)
        {
            DiffCheck.Checked = false;
        }

        private void DiffCheck_CheckedChanged(object sender, EventArgs e)
        {
            Errorcheck.Checked = false;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IDBoxDevTxt.Text) || string.IsNullOrEmpty(DiffDev.Text) || string.IsNullOrEmpty(usertxtdev.Text))
            {
                MessageBox.Show("Complete los campos por favor...");
            }
            else
            {
                string Box = IDBoxDevTxt.Text;
                String Usr = usertxtdev.Text;
                String Dif = DiffDev.Text;
                string Item = lblItemDev.Text;
                string CodigoBox = IDBoxDevTxt.Text;
                string Loc = localidadDev.Text;
                string query = @"SELECT Item, Cantidad, Localidad FROM [pmc_Inventario] where id_caja= '" + Box + "' AND Status='STK' ";
                using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblItemDev.Text = reader["Item"].ToString();
                        QttyDev.Text = reader["Cantidad"].ToString();
                        localidadDev.Text = reader["Localidad"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron items de la caja con código: " + Box);
                    }
                    reader.Close();
                    string Q = @"UPDATE [pmc_Inventario] SET CANTIDAD = (Cantidad+'" + Dif + "') WHERE ID_Caja='" + Box + "' AND Status='STK'";
                    sc.EjecutarQueryTracer(Q);
                    string sql1 = "SELECT top 1  sub_descripcion FROM [ES_SOCKS].[dbo].[pmc_Subida_BOM] WHERE [sub_producto] = @CodMat";
                    string Val = string.Empty;
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                    {
                        using (SqlCommand cm = new SqlCommand(sql1, conn))
                        {
                            cm.Parameters.AddWithValue("@CodMat", Item);
                            conn.Open();
                            using (SqlDataReader r = cm.ExecuteReader())
                            {
                                if (r.HasRows)
                                {
                                    while (r.Read())
                                    {
                                        if (!r.IsDBNull(0))
                                        {
                                            Val = r.GetString(0);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Favor verificar datos cargados en Subida de BOM.");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El item no existe en la tabla");
                                    return;
                                }
                            }
                        }
                    }
                    bool itemExiste = CodigoBox != null;

                    if (itemExiste)
                    {
                        sc.OpenConectionTracer();

                        if (DiffCheck.Checked)
                        {
                            Errorcheck.Checked = false;
                            string Q2 = @"INSERT INTO [pmc_Inventario](Item,Descripción, Cantidad, ID_Caja, Localidad, Status,Devolucion,Usuario,Fecha) VALUES('" + Item + "', '" + Val + "','" + Dif + "', '" + Box + "', '" + Loc + "', 'DEV','Diferencia en Sobrantes','" + Usr + "',GETDATE())";
                            sc.EjecutarQueryTracer(Q2);
                        }
                        else {
                            string Q2 = @"INSERT INTO [pmc_Inventario](Item,Descripción, Cantidad, ID_Caja, Localidad, Status,Devolucion,Usuario, Fecha) VALUES('" + Item + "', '" + Val + "','" + Dif + "', '" + Box + "', '" + Loc + "', 'DEV','Error en Conteo','" + Usr + "',GETDATE())";
                            sc.EjecutarQueryTracer(Q2);
                        }
                        lblItem.Text = string.Empty;
                        QttyDev.Text = string.Empty;
                        localidadDev.Text = string.Empty;
                        lblItemDev.Text = string.Empty;
                        DiffCheck.Checked = false;
                        Errorcheck.Checked = false;
                        DiffDev.Clear();
                        usertxtdev.Clear();
                        IDBoxDevTxt.Clear();
                        GridOrden.Refresh();
                        CargarDatosEnGrid1();
                        MessageBox.Show("Materiales ajustados...");
                    }
                    else
                    {
                        MessageBox.Show("El item no existe en la tabla");
                    }
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IDBoxInTxt.Text))
            {
                MessageBox.Show("Ingrese el código de caja por favor...");
            }
            else
            {
                string Caja = IDBoxInTxt.Text.ToString();
                string User = UsuarioTxtIn.Text.ToString();
                string CodMat = CodMatInTxt.Text.ToString();
                string[] codMatParts = CodMat.Split(' '); 
                if (codMatParts.Length > 0)
                {
                    CodMat = codMatParts[0];
                }
                string Qtty = QttyInTxt.Text.ToString();
                string Location = LocationInTxt.Text.ToString();
                string sql1 = "SELECT top 1  sub_descripcion FROM [ES_SOCKS].[dbo].[pmc_Subida_BOM] WHERE [sub_producto] = @CodMat";
                string Val = string.Empty;
                string extractedUser = string.Empty;
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql1, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodMat", CodMat);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Val = reader.GetString(0);
                                }
                            }
                            else
                            {
                                IDBoxInTxt.Clear();
                                CodMatInTxt.Clear();
                                QttyInTxt.Clear();
                                LocationInTxt.Clear();
                                MessageBox.Show("El item no existe en la tabla");
                                return;
                            }
                        }
                    }
                    if (this.UsuarioTxtIn.TextLength >= 17 )
                    {                  
                            int posInicial = this.UsuarioTxtIn.Text.IndexOf('ñ') + 1;
                            int posFinal = this.UsuarioTxtIn.Text.IndexOf('_', posInicial);
                            if (posInicial > 0 && posFinal > posInicial)
                            {
                                string subcadena = this.UsuarioTxtIn.Text.Substring(posInicial, posFinal - posInicial);
                                string numeros = new string(subcadena.Where(char.IsDigit).ToArray());
                                extractedUser = new string(subcadena.Where(char.IsDigit).ToArray());
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
                        } 
                    }
                    else if (UsuarioTxtIn.TextLength == 5)
                    {
                        extractedUser = UsuarioTxtIn.Text;
                        string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User";
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
                    }
                }
                bool itemExiste = CodMat != null;

                if (itemExiste)
                {
                    sc.OpenConectionTracer();
                    string q = "INSERT INTO [pmc_Inventario](Item, Descripción, Cantidad, ID_Caja, Localidad, Status,Usuario,Fecha) VALUES('" + CodMat + "','" + Val + "', '" + Qtty + "', '" + Caja + "', '" + Location + "', 'STK' ,'" + extractedUser + "',GETDATE())";
                    sc.EjecutarQueryTracer(q);
                    GridOrden.Refresh();
                    CargarDatosEnGrid();
                    IDBoxInTxt.Clear();
                    CodMatInTxt.Clear();
                    UsuarioTxtIn.Clear();
                    QttyInTxt.Clear();
                    LocationInTxt.Clear();
                    sc.CloseConectionTracer();
                }
                else
                {
                    MessageBox.Show("El item no existe en la tabla");
                }
            }
        }

        private void DescontarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usertxtOut.Text))
            {
                MessageBox.Show("Ingrese su código por favor...");
            }
            bool isAnyRowSelected = false;
            foreach (GridViewRowInfo rowInfo in GridItemsOut.Rows)
            {
                if (rowInfo.Cells["Selected"].Value != null && (bool)rowInfo.Cells["Selected"].Value)
                {
                    isAnyRowSelected = true;
                    break; 
                }
            }

            if (!isAnyRowSelected)
            {
                MessageBox.Show("Por favor, seleccione al menos un item para descontar.");
                return;
            }
            else
            {
                string extractedUser = string.Empty;
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
                {
                    conn.Open();
                    if (this.usertxtOut.TextLength >= 17)
                    {
                        int posInicial = this.usertxtOut.Text.IndexOf('ñ') + 1;
                        int posFinal = this.usertxtOut.Text.IndexOf('_', posInicial);
                        if (posInicial > 0 && posFinal > posInicial)
                        {
                            string subcadena = this.usertxtOut.Text.Substring(posInicial, posFinal - posInicial);
                            extractedUser = new string(subcadena.Where(char.IsDigit).ToArray());
                            string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User";
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
                        }
                    }
                    else if (usertxtOut.TextLength == 5)
                    {
                        extractedUser = usertxtOut.Text;
                        string sql2 = "SELECT COUNT(1) FROM [pmc_Requester] WHERE [requester_id] = @User";
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
                    }
                    List<string> missingItems = new List<string>();
                    List<string> insufficientItems = new List<string>();

                    foreach (GridViewRowInfo rowInfo in GridItemsOut.Rows)
                    {
                        if (rowInfo.Cells["Selected"].Value != null && (bool)rowInfo.Cells["Selected"].Value)
                        {
                            string item = rowInfo.Cells["Item"].Value.ToString();
                            int cantidadDescontar = int.Parse(rowInfo.Cells["Cantidad"].Value.ToString());

                            string inventarioQuery = @"SELECT COUNT(1) FROM [pmc_Inventario] WHERE Item = @Item AND Status = 'STK'";
                            int itemCount = 0;
                            using (SqlCommand inventarioCmd = new SqlCommand(inventarioQuery, conn))
                            {
                                inventarioCmd.Parameters.AddWithValue("@Item", item);
                                itemCount = (int)inventarioCmd.ExecuteScalar();
                            }

                            if (itemCount == 0)
                            {
                                missingItems.Add(item);
                            }
                            else
                            {
                                // Verificar si hay suficiente cantidad en inventario
                                string cantidadQuery = @"SELECT SUM(Cantidad) FROM [pmc_Inventario] WHERE Item = @Item AND Status = 'STK'";
                                int cantidadInventario = 0;
                                using (SqlCommand cantidadCmd = new SqlCommand(cantidadQuery, conn))
                                {
                                    cantidadCmd.Parameters.AddWithValue("@Item", item);
                                    cantidadInventario = (int)cantidadCmd.ExecuteScalar();
                                }

                                if (cantidadInventario < cantidadDescontar)
                                {
                                    insufficientItems.Add(item);
                                }
                            }
                        }
                    }

                    // Mostrar artículos faltantes en inventario
                    if (missingItems.Count > 0)
                    {
                        string missingItemsMessage = "Los siguientes artículos no existen en inventario: \n" + string.Join("\n", missingItems);
                        MessageBox.Show(missingItemsMessage);
                        return;
                    }

                    // Mostrar artículos con cantidad insuficiente
                    if (insufficientItems.Count > 0)
                    {
                        string insufficientItemsMessage = "Los siguientes artículos tienen menos cantidad de la solicitada: \n" + string.Join("\n", insufficientItems);
                        MessageBox.Show(insufficientItemsMessage);
                        return;
                    }

                    // Descontar cada artículo seleccionado
                    foreach (GridViewRowInfo rowInfo in GridItemsOut.Rows)
                    {
                        if (rowInfo.Cells["Selected"].Value != null && (bool)rowInfo.Cells["Selected"].Value)
                        {
                            string item = rowInfo.Cells["Item"].Value.ToString();
                            string descripcionItem = string.Empty;
                            int cantidadDescontar = int.Parse(rowInfo.Cells["Cantidad"].Value.ToString());

                            // Obtener la descripción del artículo
                            string descripcionQuery = @"SELECT Descripción FROM [pmc_Inventario] WHERE Item = @Item";
                            using (SqlCommand descripcionCmd = new SqlCommand(descripcionQuery, conn))
                            {
                                descripcionCmd.Parameters.AddWithValue("@Item", item);
                                descripcionItem = (string)descripcionCmd.ExecuteScalar();
                            }

                            // Consultar sobrantes disponibles
                            string sobranteQuery = @"SELECT Sob_Codigo, Sob_Cantidad FROM [pmc_Sobrantes] WHERE Sob_Codigo = @Item AND Sob_Cantidad > 0 ORDER BY Sob_Codigo";
                            List<int> sobrantes = new List<int>();

                            using (SqlCommand sobranteCmd = new SqlCommand(sobranteQuery, conn))
                            {
                                sobranteCmd.Parameters.AddWithValue("@Item", item);
                                using (SqlDataReader reader = sobranteCmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        sobrantes.Add(reader.GetInt32(1));
                                    }
                                }
                            }

                            int cantidadRestante = cantidadDescontar;

                            // Descontar sobrantes
                            foreach (int sobrante in sobrantes)
                            {
                                if (cantidadRestante <= 0)
                                    break;

                                int cantidadADescontar = Math.Min(sobrante, cantidadRestante);

                                string descontarSobrantesQuery = @"UPDATE [pmc_Sobrantes] SET Sob_Cantidad = Sob_Cantidad - @Cantidad WHERE Sob_Codigo = @Item AND Sob_Cantidad = @Sobrante";
                                using (SqlCommand cmd = new SqlCommand(descontarSobrantesQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Cantidad", cantidadADescontar);
                                    cmd.Parameters.AddWithValue("@Item", item);
                                    cmd.Parameters.AddWithValue("@Sobrante", sobrante);
                                    cmd.ExecuteNonQuery();

                                    cantidadRestante -= cantidadADescontar;
                                }
                            }

                            // Si no hay suficientes sobrantes, descontar del inventario
                            if (cantidadRestante > 0)
                            {
                                string inventarioQuery = @"SELECT Item,Cantidad FROM [pmc_Inventario] WHERE Item = @Item AND Status = 'STK' AND Cantidad > 0 ORDER BY Item";
                                List<int> inventario = new List<int>();

                                using (SqlCommand inventarioCmd = new SqlCommand(inventarioQuery, conn))
                                {
                                    inventarioCmd.Parameters.AddWithValue("@Item", item);
                                    using (SqlDataReader reader = inventarioCmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            inventario.Add(reader.GetInt32(1));
                                        }
                                    }
                                }

                                foreach (int cantidadInventario in inventario)
                                {
                                    if (cantidadRestante <= 0)
                                        break;

                                    int cantidadADescontar = Math.Min(cantidadInventario, cantidadRestante);

                                    string descontarInventarioQuery = @"UPDATE [pmc_Inventario] SET Cantidad = Cantidad - @Cantidad WHERE Item = @Item AND Status = 'STK' AND Cantidad = @InventarioCantidad";
                                    using (SqlCommand cmd = new SqlCommand(descontarInventarioQuery, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@Cantidad", cantidadADescontar);
                                        cmd.Parameters.AddWithValue("@Item", item);
                                        cmd.Parameters.AddWithValue("@InventarioCantidad", cantidadInventario);
                                        cmd.ExecuteNonQuery();

                                        cantidadRestante -= cantidadADescontar;
                                    }
                                }
                            }

                            // Si aún hay cantidad restante, mostrar un error
                            if (cantidadRestante > 0)
                            {
                                MessageBox.Show("La cantidad a descontar excede el inventario disponible.");
                                return;
                            }

                            // Insertar el movimiento en inventario
                            string traceIdValue = rowInfo.Cells["ID"].Value.ToString();
                            if (!string.IsNullOrEmpty(traceIdValue))
                            {
                                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [pmc_Inventario](Item, Descripción, Cantidad, Status, Usuario, Fecha, TraceID) 
                        VALUES(@Item, @Descripcion, @Cantidad, 'TBL', @Usuario, GETDATE(), @TraceID)", conn))
                                {
                                    cmd.Parameters.AddWithValue("@Item", item);
                                    cmd.Parameters.AddWithValue("@Descripcion", descripcionItem);
                                    cmd.Parameters.AddWithValue("@Cantidad", cantidadDescontar);
                                    cmd.Parameters.AddWithValue("@Usuario", extractedUser);
                                    cmd.Parameters.AddWithValue("@TraceID", traceIdValue);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    GridOrden.Refresh();
                    CargarDatosEnGrid();
                    SacaOutTxt.Clear();
                    TraceIDOutTxt.Clear();
                    usertxtOut.Clear();
                    FiltradoOutTxt.Clear();
                    SacaOutTxt.Visible = true;
                    TraceIDOutTxt.Visible = true;
                    FiltradoOutTxt.Visible = true;
                    GridItemsOut.DataSource = null;
                    CargarDatosEnGrid2();
                    LimpiarCampos();
                    ClearTexbox();
                }
            }
        }


        private void TraceIDOutTxt_KeyDown(object sender, KeyEventArgs e)
        {
            string TraceID = TraceIDOutTxt.Text.ToString();
            SacaOutTxt.Visible = false;
            sc.OpenConectionTracer();
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (sc.IsNumeric(this.TraceIDOutTxt.Text) == false)
                    {
                        MessageBox.Show("Ingrese un código numérico");
                        TraceIDOutTxt.Clear();
                        this.TraceIDOutTxt.Focus();
                        return;
                    }
                    string sql = @"
                   SELECT DISTINCT
                   ss.sub_producto AS Item,

               ROUND(ROUND(k.Dozens, 0) / ss.sub_factor, 0) AS Cantidad,
               k.TraceID AS ID
            FROM
                   dbo.pmc_productmaster AS P
            INNER JOIN
                   dbo.pmc_consolidadoplanes AS c ON P.saca = c.sku
                   INNER JOIN
                   dbo.pmc_saca_1as_2das_3ras AS s ON P.saca = s.pmc_saca_1ra
                   INNER JOIN
                   dbo.pmc_doblado_irr AS d ON s.pmc_saca_2da = d.pmc_saca_irr
                   INNER JOIN
                   dbo.View_PreKiteo AS k ON P.saca = k.saca
                   INNER JOIN
                   es_socks.dbo.pmc_subida_bom AS ss ON P.saca = ss.sub_saca COLLATE SQL_Latin1_General_CP1_CI_AS
                   LEFT JOIN pmc_Inventario AS INV ON ss.sub_producto = INV.Item COLLATE SQL_Latin1_General_CP1_CI_AS
                   INNER JOIN
               [pmc_Bag_IRR] AS b ON b.pmc_SACA_IRR = s.pmc_saca_2da
                   LEFT JOIN
               [dbo].[pmc_UPC] AS u ON k.SACA = upc_SACA
                   LEFT JOIN
                   dbo.pmc_Desviaciones AS dev ON dev.desv_item = ss.sub_producto COLLATE SQL_Latin1_General_CP1_CI_AS
                   AND dev.desv_Week = k.WeekID COLLATE SQL_Latin1_General_CP1_CI_AS
                   LEFT JOIN
                   dbo.pmc_Stickers AS Stk ON Stk.Item = ss.sub_producto COLLATE SQL_Latin1_General_CP1_CI_AS
                   WHERE
                   k.TraceID IN('" + TraceID + @"')
            AND ChkID IN('BLEACHING', 'DYEING')
                   ";
                   // Cargar los datos en un DataTable
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
                    dataAdapter.Fill(dataTable);

                    // SQL para obtener los items en inventario
                    string inventorySql = "SELECT DISTINCT Item, Cantidad FROM [Tracer].[dbo].[pmc_Inventario] WHERE Status = 'STK'";

                    DataTable inventoryTable = new DataTable();
                    SqlDataAdapter inventoryAdapter = new SqlDataAdapter(inventorySql, cn);
                    inventoryAdapter.Fill(inventoryTable);

                    Dictionary<string, int> inventoryItems = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                    foreach (DataRow row in inventoryTable.Rows)
                    {
                        string item = row["Item"].ToString().Trim();
                        int quantity = Convert.ToInt32(row["Cantidad"]);
                        inventoryItems[item] = quantity;
                    }

                    List<string> missingItems = new List<string>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string item = row["Item"].ToString().Trim();
                        if (!inventoryItems.ContainsKey(item))
                        {
                            missingItems.Add(item);
                        }
                    }
                    GridItemsOut.Columns.Clear();
                    GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn
                    {
                        FieldName = "Selected",
                        HeaderText = "Selección",
                        Width = 40
                    };
                    GridItemsOut.Columns.Add(checkBoxColumn);
                    GridItemsOut.Columns.Add(new GridViewTextBoxColumn()
                    {
                        FieldName = "Item",
                        HeaderText = "Código",
                        ReadOnly = true,
                        
                       
                    }); ;
                    GridItemsOut.Columns.Add(new GridViewTextBoxColumn()
                    {
                        FieldName = "Cantidad",
                        HeaderText = "Cantidad",
                        Width = 35,
                        ReadOnly = true,

                    });
                    GridItemsOut.Columns.Add(new GridViewTextBoxColumn()
                    {
                        FieldName = "ID",
                        HeaderText = "TraceID",
                        Width = 35,
                        ReadOnly = true,
                    });
                    // Nueva columna para el indicador de disponibilidad
                    GridItemsOut.Columns.Add(new GridViewTextBoxColumn()
                    {
                        FieldName = "Disponibilidad",
                        HeaderText = "Existencia",
                        ReadOnly = true,
                        //IsVisible = false
                    });
                    // Nueva columna para la cantidad suficiente
                    GridItemsOut.Columns.Add(new GridViewTextBoxColumn()
                    {
                        FieldName = "Cantidad Suficiente",
                        HeaderText = "Stock",
                        ReadOnly = true,
                        //IsVisible = false
                    });

                    GridItemsOut.DataSource = dataTable;
                    //GridItemsOut.Refresh();

                    for (int i = 0; i < GridItemsOut.RowCount; i++)
                    {
                        GridItemsOut.Rows[i].Cells["Selected"].Value = true;
                    }
                    for (int i = 0; i < GridItemsOut.RowCount; i++)
                    {
                        GridItemsOut.Rows[i].Cells["Selected"].Value = true;

                        string item = GridItemsOut.Rows[i].Cells["Item"].Value.ToString().Trim();
                        int requestedQuantity = Convert.ToInt32(GridItemsOut.Rows[i].Cells["Cantidad"].Value);

                        if (inventoryItems.ContainsKey(item))
                        {
                            int availableQuantity = inventoryItems[item];

                            // Verificar si hay suficiente cantidad
                            if (availableQuantity >= requestedQuantity)
                            {
                                GridItemsOut.Rows[i].Cells["Disponibilidad"].Value = "Disponible";
                                GridItemsOut.Rows[i].Cells["Cantidad Suficiente"].Value = "Suficiente";
                                GridItemsOut.Rows[i].Cells["Item"].Style.BackColor = Color.Green; // Colorear en blanco si hay suficiente cantidad
                                
                            }
                            else
                            {
                                GridItemsOut.Rows[i].Cells["Disponibilidad"].Value = "Disponible";
                                GridItemsOut.Rows[i].Cells["Cantidad Suficiente"].Value = "Insuficiente"; // Cambiar a "No Suficiente"
                                                                                                          //GridItemsOut.Rows[i].Cells["Item"].Style.BackColor = Color.Yellow; // Colorear en amarillo si hay menos cantidad
                                foreach (var cell in GridItemsOut.Rows[i].Cells)
                                {
                                    cell.Style.ForeColor = Color.Red;
                                    cell.Style.BackColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            GridItemsOut.Rows[i].Cells["Disponibilidad"].Value = "No disponible";
                            GridItemsOut.Rows[i].Cells["Cantidad Suficiente"].Value = "Insuficiente";
                            //GridItemsOut.Rows[i].Cells["Item"].Style.ForeColor = Color.Red; // Colorear en rojo si no está en inventario
                            foreach (var cell in GridItemsOut.Rows[i].Cells)
                            {
                                cell.Style.ForeColor = Color.Red;
                                cell.Style.BackColor = Color.Red;
                            }
                        }
                    }
                  
                    GridItemsOut.MultiSelect = true;
                    GridItemsOut.SelectionMode = GridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SacaOutTxt_KeyDown(object sender, KeyEventArgs e)
           {
            TraceIDOutTxt.Visible = false;
            string SACA = SacaOutTxt.Text.ToString();
            sc.OpenConectionTracer();
            string sql = @"SELECT DISTINCT 
                            ss.sub_producto AS Item, 
                            ROUND(ROUND(K.Docenas, 0) / ss.sub_factor, 0) AS Cantidad,I.ID_Caja, I.Localidad,ID FROM dbo.pmc_ConsolidadoPlanes AS c 
                            INNER JOIN dbo.pmc_InventarioBySaca AS k ON c.sku = k.SACA
                            INNER JOIN ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON c.sku = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
                            INNER JOIN dbo.pmc_Inventario AS I ON I.Item = ss.sub_producto COLLATE SQL_Latin1_General_CP1_CI_AS
                            WHERE k.ID = '" + SACA + "'";

            GridItemsOut.Columns.Clear();
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID_Caja", HeaderText = "Caja" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID", HeaderText = "TraceID" });
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            GridItemsOut.MultiSelect = true;
            GridItemsOut.SelectionMode = GridViewSelectionMode.FullRowSelect;
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            checkBoxColumn.FieldName = "Selected";
            checkBoxColumn.HeaderText = "Selección";
            checkBoxColumn.Width = 40;
            GridItemsOut.Columns.Insert(0, checkBoxColumn);
            // Asignar el DataTable como origen de datos para el RadGridView
            GridItemsOut.DataSource = dataTable;
            GridItemsOut.Refresh();
        }

        private void FiltradoOutTxt_KeyDown(object sender, KeyEventArgs e)
        {
            TraceIDOutTxt.Visible = false;
            SacaOutTxt.Visible = false;
            string SB = FiltradoOutTxt.Text.ToString();
            sc.OpenConectionTracer();
            string Sql = @"Select DISTINCT Sobr_Codigo as Item, i.ID_Caja, Sobr_Cantidad as Cantidad, Sobr_Localidad as Localidad,ID from [pmc_Sobreconsumos]
                            INNER JOIN dbo.pmc_Inventario AS I ON I.Item = Sobr_Codigo
                            LEFT JOIN pmc_InventarioBySaca AS b ON B.SACA = Sobr_SACA WHERE ID='"+ SB+"'";
            GridItemsOut.Columns.Clear();
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID_Caja", HeaderText = "Caja" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
            GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID", HeaderText = "TraceID" });

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Sql, cn);
            dataAdapter.Fill(dataTable);
            Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
            GridItemsOut.MultiSelect = true;
            GridItemsOut.SelectionMode = GridViewSelectionMode.FullRowSelect;
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            checkBoxColumn.FieldName = "Selected";
            checkBoxColumn.HeaderText = "Selección";
            checkBoxColumn.Width = 40;
            GridItemsOut.Columns.Insert(0, checkBoxColumn);
            // Asignar el DataTable como origen de datos para el RadGridView
            GridItemsOut.DataSource = dataTable;
            GridItemsOut.Refresh();
        }

        private List<DataRow> GetSelectedRows()
        {
            List<DataRow> selectedRows = new List<DataRow>();
            foreach (GridViewRowInfo rowInfo in GridItemsOut.Rows)
            {
                if (rowInfo.Cells["Selected"].Value != null && (bool)rowInfo.Cells["Selected"].Value)
                {
                    selectedRows.Add(((DataRowView)rowInfo.DataBoundItem).Row);
                }
            }
            return selectedRows;
        }

        private void GridItemsOut_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (!this.GridItemsOut.CurrentRow.Cells["Selected"].IsSelected)
            {
                return;
            }
        }

        private void radTextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            String CAJA = BoxSumRest.Text;
            sc.OpenConection();
            if (e.KeyCode == Keys.Enter)
            {
                string query = @"SELECT Item, Cantidad, Localidad FROM [pmc_Inventario] where id_caja= '" + CAJA + "' AND Status='STK' ";
                using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblItem.Text = reader["Item"].ToString();
                        lblStock.Text = reader["Cantidad"].ToString();
                        lblLocalidad.Text = reader["Localidad"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron items de la caja con código: " + CAJA);
                    }
                    reader.Close();
                }
            }
        }

        private void AddInventory_CheckedChanged(object sender, EventArgs e)
        {
            RestInventory.Checked = false;
        }

        private void RestInventory_CheckedChanged(object sender, EventArgs e)
        {
            AddInventory.Checked = false;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(BoxSumRest.Text) || string.IsNullOrEmpty(DiffText.Text) || string.IsNullOrEmpty(UserTxt.Text))
            {
                MessageBox.Show("Complete los campos por favor...");
            }
            else
            {
                string InvBox = BoxSumRest.Text;
                string Dif = DiffText.Text;
                string User = UserTxt.Text;
                string CodMat = lblItem.Text;
                // Modificación para obtener solo el primer bloque de CodMat
                string[] codMatParts = CodMat.Split(' '); // Suponiendo que el delimitador es un espacio
                if (codMatParts.Length > 0)
                {
                    CodMat = codMatParts[0]; // Toma solo el primer bloque
                }
                string Inv = lblStock.Text;
                string Local = lblLocalidad.Text;

                if (AddInventory.Checked)
                {
                    RestInventory.Checked = false;
                    string Q2 = @"UPDATE [pmc_Inventario] SET CANTIDAD = (Cantidad+'" + Dif + "') WHERE ID_Caja='" + InvBox + "' AND Status='STK'";

                    sc.EjecutarQueryTracer(Q2);
                }
                else
                {
                    if (!decimal.TryParse(Dif, out decimal cantidadDif))
                    {
                        MessageBox.Show("La cantidad ingresada no es válida.");
                        return;
                    }
                    if (!decimal.TryParse(Inv, out decimal cantidadInv))
                    {
                        MessageBox.Show("El inventario actual no es válido.");
                        return;
                    }
                    if (cantidadDif > cantidadInv)
                    {
                        MessageBox.Show("La cantidad a remover es mayor que el inventario disponible. No se puede realizar el proceso.");
                        BoxSumRest.Clear();
                        lblItem.Text = string.Empty;
                        lblStock.Text = string.Empty;
                        lblLocalidad.Text = string.Empty;
                        DiffText.Clear();
                        UserTxt.Clear();
                        AddInventory.Checked = false;
                        RestInventory.Checked = false;
                        return;
                    }

                    string Q2 = @"UPDATE [pmc_Inventario] SET CANTIDAD = (Cantidad-'" + Dif + "') WHERE ID_Caja='" + InvBox + "' AND Status='STK'";
                    sc.EjecutarQueryTracer(Q2);
                }
                string query = "SELECT DISTINCT sub_descripcion FROM [ES_SOCKS].[dbo].[pmc_Subida_BOM] WHERE [sub_producto] = @CodMat";
                string Val = string.Empty;
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                {
                    using (SqlCommand cm = new SqlCommand(query, conn))
                    {
                        cm.Parameters.AddWithValue("@CodMat", CodMat);
                        conn.Open();
                        using (SqlDataReader r = cm.ExecuteReader())
                        {
                            if (r.HasRows)
                            {
                                while (r.Read())
                                {
                                    Val = r.GetString(0);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El item no existe en la tabla");
                                return;
                            }
                        }
                    }
                }
                bool itemExiste = InvBox != null;
                if (itemExiste)
                {
                    sc.OpenConectionTracer();

                    if (AddInventory.Checked)
                    {
                        RestInventory.Checked = false;
                        string Q2 = @"INSERT INTO [pmc_Inventario](Item,Descripción, Cantidad, ID_Caja, Localidad, Status,Devolucion,Usuario,Fecha) VALUES('" + CodMat + "', '" + Val + "','" + Dif + "', '" + InvBox + "', '" + Local + "', 'DEV','Adición de inventario','" + User + "',GETDATE())";
                        sc.EjecutarQueryTracer(Q2);
                    }
                    else
                    {
                        string Q2 = @"INSERT INTO [pmc_Inventario](Item,Descripción, Cantidad, ID_Caja, Localidad, Status,Devolucion,Usuario, Fecha) VALUES('" + CodMat + "', '" + Val + "','" + Dif + "', '" + InvBox + "', '" + Local + "', 'DEV','Inventario Removido','" + User + "',GETDATE())";
                        sc.EjecutarQueryTracer(Q2);
                    }
                    BoxSumRest.Clear();
                    lblItem.Text = string.Empty;
                    lblStock.Text = string.Empty;
                    lblLocalidad.Text = string.Empty;
                    AddInventory.Checked = false;
                    RestInventory.Checked = false;
                    DiffText.Clear();
                    UserTxt.Clear();
                    GridOrden.Refresh();
                    CargarDatosEnGrid1();
                    MessageBox.Show("Materiales ajustados...");
                }
                else
                {
                    MessageBox.Show("El item no existe en la tabla");
                }
            }
        }
        private void IDBoxDevTxt_KeyDown(object sender, KeyEventArgs e)
        {
            String CAJA = IDBoxDevTxt.Text;
            sc.OpenConection();
            if (e.KeyCode == Keys.Enter)
            {
                string query = @"SELECT Item, Cantidad, Localidad FROM [pmc_Inventario] where id_caja= '" + CAJA + "' AND Status='STK' ";
                using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblItemDev.Text = reader["Item"].ToString();
                        QttyDev.Text = reader["Cantidad"].ToString();
                        localidadDev.Text = reader["Localidad"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron items de la caja con código: " + CAJA);
                    }
                    reader.Close();
                }
            }
        }

        private void UserTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || string.IsNullOrEmpty(UserTxt.Text))
            {
                BoxSumRest.Enabled = true;
                DiffText.Enabled = true;
                AddInventory.Enabled = true;
                RestInventory.Enabled = true;
            }
        }

        private void UsuarioTxtIn_TextChanged(object sender, EventArgs e)
        {
            if (UsuarioTxtIn.Text.Length >= 4)
            {
                IDBoxInTxt.Enabled = true;
                CodMatInTxt.Enabled = true;
                QttyInTxt.Enabled = true;
                LocationInTxt.Enabled = true;
            }
            else
            {
                IDBoxInTxt.Enabled = false;
                CodMatInTxt.Enabled = false;
                QttyInTxt.Enabled = false;
                LocationInTxt.Enabled = false;
            }
        }


        private bool CheckIfUserExists(string userId)
        {
            bool exists = false;
            string connectionString = Properties.Settings.Default.TracerConnectionString; // Reemplaza con tu cadena de conexión

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM [dbo].[pmc_Requester] WHERE requester_id = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            exists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al verificar el usuario: " + ex.Message);
                    }
                }
            }

            return exists;
        }
    

    private void usertxtOut_TextChanged(object sender, EventArgs e)
        {
        }

        private void usertxtdev_TextChanged(object sender, EventArgs e)
        {
            if (usertxtdev.Text.Length >= 4)
            {
                IDBoxDevTxt.Enabled     = true;
                lblItemDev.Enabled      = true;
                QttyDev.Enabled         = true;
                DiffDev.Enabled         = true;
                localidadDev.Enabled    = true;
                DiffCheck.Enabled       = true;
                Errorcheck.Enabled      = true;
            }
            else
            {
                IDBoxDevTxt.Enabled     = false;
                lblItemDev.Enabled      = false;
                QttyDev.Enabled         = false;
                DiffDev.Enabled         = false;
                localidadDev.Enabled    = false;
                DiffCheck.Enabled       = false;
                Errorcheck.Enabled      = false;
            }
        }

        private void UserTxt_TextChanged(object sender, EventArgs e)
        {
            if(UserTxt.Text.Length >= 4)
            {
                BoxSumRest.Enabled       = true;
                lblItem.Enabled          = true;
                lblStock.Enabled         = true;
                DiffText.Enabled         = true;
                lblLocalidad.Enabled     = true;
                AddInventory.Enabled     = true;
                RestInventory.Enabled    = true;
            }
            else
            {
                BoxSumRest.Enabled      = false;
                lblItem.Enabled         = false;
                lblStock.Enabled        = false;
                DiffText.Enabled        = false;
                lblLocalidad.Enabled    = false;
                AddInventory.Enabled    = false;
                RestInventory.Enabled   = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (AssortTid.Checked)
            {
                AssortmentsTID.Visible = true;
                IDSobreconsumo.Visible = false;
                cbxFiltrado.Visible = false;
                cbxTraceID.Visible = false;
                AssortSACA.Checked = false;
                AssortSACA.Visible = false;
                usertxtOut.Visible = false;
                TraceIDOutTxt.Visible = false;
                SacaOutTxt.Visible = false;
                FiltradoOutTxt.Visible = false;
                label27.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label15.Visible = false;
                AssortmentsSA.Visible = false;
            }
            else
            {
                AssortTid.Checked = false;

            }
        }

        private void AssortSACA_CheckedChanged(object sender, EventArgs e)
        {
            AssortSACA.Visible = true;
            AssortmentsSA.Visible = true;
            AssortmentsTID.Visible = false;
            usertxtOut.Visible = false;
            TraceIDOutTxt.Visible = false;
            SacaOutTxt.Visible = false;
            FiltradoOutTxt.Visible = false;
            label27.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label15.Visible = false;
            AssortTid.Checked = false;
            AssortTid.Visible = false;
            IDSobreconsumo.Visible = false;
            cbxFiltrado.Visible = false;
            cbxTraceID.Visible = false;
        }

        private void CancelarAssort_Click(object sender, EventArgs e)
        {
            AssortmentsTID.Visible = false;
            AssortSACA.Visible = true;
            usertxtOut.Visible = true;
            TraceIDOutTxt.Visible = true;
            SacaOutTxt.Visible = true;
            FiltradoOutTxt.Visible = true;
            label27.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label15.Visible = true;
            AssortTid.Checked = false;
            AssortSACA.Checked = false;
            IDSobreconsumo.Visible = true;
            cbxFiltrado.Visible = true;
            cbxTraceID.Visible = true;
            LimpiarCampos();
        }

        private void GuardarAssortment_Click(object sender, EventArgs e)
        {
            sc.OpenConectionTracer();
            List<string> traceIds = new List<string>();
            if (!string.IsNullOrEmpty(TID1.Text)) traceIds.Add(TID1.Text);
            if (!string.IsNullOrEmpty(TID2.Text)) traceIds.Add(TID2.Text);
            if (!string.IsNullOrEmpty(TID3.Text)) traceIds.Add(TID3.Text);
            if (!string.IsNullOrEmpty(TID4.Text)) traceIds.Add(TID4.Text);
            if (!string.IsNullOrEmpty(TID5.Text)) traceIds.Add(TID5.Text);
            if (!string.IsNullOrEmpty(TID6.Text)) traceIds.Add(TID6.Text);
            if (!string.IsNullOrEmpty(TID7.Text)) traceIds.Add(TID7.Text);
            if (!string.IsNullOrEmpty(TID8.Text)) traceIds.Add(TID8.Text);
            if (!string.IsNullOrEmpty(TID9.Text)) traceIds.Add(TID9.Text);
            if (!string.IsNullOrEmpty(TID10.Text)) traceIds.Add(TID10.Text);
            if (!string.IsNullOrEmpty(TID11.Text)) traceIds.Add(TID11.Text);
            if (!string.IsNullOrEmpty(TID12.Text)) traceIds.Add(TID12.Text);

            if (traceIds.Count > 0)
            {
                string traceIdValues = string.Join(", ", traceIds.Select(id => $"'{id}'"));
                string query = $@"
                SELECT DISTINCT ss.sub_producto AS Item,
                ROUND(ROUND(c.dozens, 0) / ss.sub_factor, 0) AS Cantidad,I.ID_Caja, I.Localidad,id
                FROM dbo.pmc_ConsolidadoPlanes AS c 
                INNER JOIN dbo.pmc_InventarioByTraceID AS k ON c.sku = k.SACA
                INNER JOIN ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON c.sku = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
                INNER JOIN dbo.pmc_Inventario AS I ON I.Item = ss.sub_producto COLLATE SQL_Latin1_General_CP1_CI_AS
                WHERE Status='STK' AND k.id IN ({traceIdValues})";

                sc.EjecutarQueryTracer(query);

                GridItemsOut.Columns.Clear();
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código" });
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID_Caja", HeaderText = "Caja" });
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad" });
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad" });
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "id", HeaderText = "TraceID" });  // Columna para TraceID

                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);          
                GridItemsOut.MultiSelect = true;
                GridItemsOut.SelectionMode = GridViewSelectionMode.FullRowSelect;
                GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
                checkBoxColumn.FieldName = "Selected";
                checkBoxColumn.HeaderText = "Selección";
                checkBoxColumn.Width = 40;
                GridItemsOut.Columns.Insert(0, checkBoxColumn);
                GridItemsOut.DataSource = dataTable;
                //LimpiarCampos();
                GridItemsOut.Refresh();
            }
            else
            {
                MessageBox.Show("No se ha ingresado ningún valor en los inputs.");
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            sc.OpenConectionTracer();
            List<string> Ids = new List<string>();
            if (!string.IsNullOrEmpty(ID1.Text))  Ids.Add(ID1.Text);
            if (!string.IsNullOrEmpty(ID2.Text))  Ids.Add(ID2.Text);
            if (!string.IsNullOrEmpty(ID3.Text))  Ids.Add(ID3.Text);
            if (!string.IsNullOrEmpty(ID4.Text))  Ids.Add(ID4.Text);
            if (!string.IsNullOrEmpty(ID5.Text))  Ids.Add(ID5.Text);
            if (!string.IsNullOrEmpty(ID6.Text))  Ids.Add(ID6.Text);
            if (!string.IsNullOrEmpty(ID7.Text))  Ids.Add(ID7.Text);
            if (!string.IsNullOrEmpty(ID8.Text))  Ids.Add(ID8.Text);
            if (!string.IsNullOrEmpty(ID9.Text))  Ids.Add(ID9.Text);
            if (!string.IsNullOrEmpty(ID10.Text)) Ids.Add(ID10.Text);
            if (!string.IsNullOrEmpty(ID11.Text)) Ids.Add(ID11.Text);
            if (!string.IsNullOrEmpty(ID12.Text)) Ids.Add(ID12.Text);

            if (Ids.Count > 0)
            {
                string IdValues = string.Join(", ", Ids.Select(id => $"'{id}'"));
                string query = $@"
                SELECT DISTINCT 
                ss.sub_producto AS Item, 
                ROUND(ROUND(c.dozens, 0) / ss.sub_factor, 0) AS Cantidad,I.ID_Caja, I.Localidad,ID
                FROM dbo.pmc_ConsolidadoPlanes AS c 
                INNER JOIN dbo.pmc_InventarioBySACA AS k ON c.sku = k.SACA
                INNER JOIN ES_SOCKS.dbo.pmc_Subida_BOM AS ss ON c.sku = ss.sub_SACA COLLATE SQL_Latin1_General_CP1_CI_AS
                INNER JOIN dbo.pmc_Inventario AS I ON I.Item = ss.sub_producto COLLATE SQL_Latin1_General_CP1_CI_AS
                WHERE Status='STK' AND k.id IN ({IdValues})";
  
                sc.EjecutarQueryTracer(query);
                GridItemsOut.Columns.Clear();
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Item", HeaderText = "Código"});
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "ID_Caja", HeaderText = "Caja"});
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad"});
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad"});
                GridItemsOut.Columns.Add(new GridViewTextBoxColumn() { FieldName = "id", HeaderText = "TraceID" });

                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.Fill(dataTable);
                Console.WriteLine("Datos cargados en DataTable. Filas obtenidas: " + dataTable.Rows.Count);
                GridItemsOut.MultiSelect = true;
                GridItemsOut.SelectionMode = GridViewSelectionMode.FullRowSelect;
                GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
                checkBoxColumn.FieldName = "Selected";
                checkBoxColumn.HeaderText = "Selección";
                checkBoxColumn.Width = 40;
                GridItemsOut.Columns.Insert(0, checkBoxColumn);
                GridItemsOut.DataSource = dataTable;
                GridItemsOut.Refresh();
            }
            else
            {
                MessageBox.Show("No se ha ingresado ningún valor en los inputs.");
            }
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            usertxtOut.Clear();
            TraceIDOutTxt.Clear();
            SacaOutTxt.Clear();
            FiltradoOutTxt.Clear();
            GridItemsOut.DataSource = null;
            cbxTraceID.Checked = false;
            cbxFiltrado.Checked = false;
            IDSobreconsumo.Checked = false;
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            AssortmentsTID.Visible = false;
            AssortmentsSA.Visible = false;
            AssortSACA.Visible = true;
            usertxtOut.Visible = true;
            TraceIDOutTxt.Visible = true;
            SacaOutTxt.Visible = true;
            FiltradoOutTxt.Visible = true;
            label27.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label15.Visible = true;
            AssortTid.Checked = false;
            AssortSACA.Checked = false;
            AssortTid.Visible = true;
            IDSobreconsumo.Visible = true;
            cbxFiltrado.Visible = true;
            cbxTraceID.Visible = true;
            usertxtOut.Clear();
            TraceIDOutTxt.Clear();
            SacaOutTxt.Clear();
            FiltradoOutTxt.Clear();
            ClearTexbox();
        }
        private void cbxTraceID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTraceID.Checked)
            {
                TraceIDOutTxt.Enabled = true;
                cbxFiltrado.Checked = false;
                IDSobreconsumo.Checked = false;
            }
            else
            {
                cbxTraceID.Checked = false;
                TraceIDOutTxt.Enabled = false;
            }
        }
        private void cbxFiltrado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFiltrado.Checked)
            {
                SacaOutTxt.Enabled = true;
                cbxTraceID.Checked = false;
                IDSobreconsumo.Checked = false;
            }
            else
            {
                cbxFiltrado.Checked = false;
                SacaOutTxt.Enabled = false;
            }
        }
        private void IDSobreconsumo_CheckedChanged(object sender, EventArgs e)
        {
            if (IDSobreconsumo.Checked)
            {
                FiltradoOutTxt.Enabled = true;
                cbxTraceID.Checked = false;
                cbxFiltrado.Checked = false;
            }
            else
            {
                IDSobreconsumo.Checked = false;
                FiltradoOutTxt.Enabled = false;
            }
        }
        private void LimpiarCampos()
        {
            TID1.Clear();TID2.Clear();TID3.Clear();TID4.Clear();TID5.Clear();TID6.Clear();TID7.Clear(); TID8.Clear();TID9.Clear(); TID10.Clear(); TID11.Clear(); TID12.Clear();
        }
        private void ClearTexbox()
        {
            ID1.Clear(); ID2.Clear(); ID3.Clear(); ID4.Clear(); ID5.Clear(); ID6.Clear(); ID7.Clear(); ID8.Clear(); ID9.Clear(); ID10.Clear(); ID11.Clear(); ID12.Clear();
        }

        private void rbtnActualizar_Click(object sender, EventArgs e)
        {
            
            if (checkBox4.Checked)
            {
                CargarDatosEnGrid1();
            }
            else if (checkBox3.Checked)
            {
                CargarDatosEnGrid1();
            }
            else if (checkBox1.Checked)
            {
                CargarDatosEnGrid();
            }
            else if (checkBox2.Checked)
            {
                CargarDatosEnGrid();
            }
        }
    }
}
