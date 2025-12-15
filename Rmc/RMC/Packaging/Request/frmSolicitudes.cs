using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;
using Rmc.Clases;
using Rmc.Clases.dsPMCTableAdapters;
using System.Data.SqlClient;

namespace Rmc.Subidas
{
    public partial class frmSolicitudes : Telerik.WinControls.UI.RadForm
    {

        # region INICIALIZACION
        private readonly int bodegaID = 4;

        dsPMC dsp = new dsPMC();
        SqlConnection waiConn = new SqlConnection(Properties.Settings.Default.ESDEVSQL1V_ESSOCKS);
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        PlanSemanaTableAdapter plta = new PlanSemanaTableAdapter();
        ConsultasTableAdapter csl = new ConsultasTableAdapter();
        DataTable dtPlan = new DataTable();
        DataTable dtGrid = new DataTable();
        bool flagValidar = false;
        bool flagEstado = false;

        public frmSolicitudes()
        {
            InitializeComponent();
            GridViewSolicitud.Rows.AddNew();
            WainariDataBase();
            TxtItems.Visible = true;
            LblItem.Visible = true;
        }
        #endregion
        #region DATOS

        private void WainariDataBase()
        {
            DataTable dtSource = new DataTable();
            GridLocalidades.Columns.Clear();
            GridViewCheckBoxColumn chkColumn = new GridViewCheckBoxColumn();
            chkColumn.FieldName = "Seleccionado"; chkColumn.HeaderText = "Seleccionar";
            GridLocalidades.Columns.Add(chkColumn);
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Codigo", HeaderText = "Codigo",ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Producto", HeaderText = "Producto", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Cantidad", HeaderText = "Cantidad", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Localidad", HeaderText = "Localidad", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Num_lote", HeaderText = "Num. Lote", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Orden", HeaderText = "Orden", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Usuario", HeaderText = "Usuario", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "Recibido", HeaderText = "Recibido", ReadOnly = true });
            GridLocalidades.Columns.Add(new GridViewTextBoxColumn() { FieldName = "PERMANENCIA_EN_BODEGA", HeaderText = "Dias en Bodega", ReadOnly = true });

            string query = @"
                            SELECT 
                                I.ite_codigo AS Codigo,
	                            I.ite_descripcion AS Producto,
                                FD.facd_cantidad AS Cantidad,
                                L.loc_nombre AS Localidad,
                                FD.facd_lote AS Num_Lote,
	                            F.fac_numero AS Orden,
                                FD.facd_usuario_crea AS Usuario,
                                PL.pac_scan_whin AS Recibido,
                                DATEDIFF(DAY, PL.pac_scan_whin, GETDATE()) AS PERMANENCIA_EN_BODEGA
                            FROM wai_Factura_Detalle FD
                            INNER JOIN wai_Pack_List PL ON FD.facd_id = PL.pac_factura_detalle_id
                            INNER JOIN wai_Localidad L ON PL.pac_localidad_id = L.loc_id
                            INNER JOIN wai_Item I ON FD.facd_item_id = I.ite_id
                            INNER JOIN wai_Factura F ON FD.facd_fac_id = F.fac_id
                            WHERE I.ite_bodega_id = @bodega
                              AND FD.facd_cantidad > 0
                              AND PL.pac_scan_whin IS NOT NULL
                            ORDER BY PL.pac_scan_whin DESC";

            using (SqlCommand cmd = new SqlCommand(query, waiConn))
            {
                cmd.Parameters.AddWithValue("@bodega", bodegaID);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dtSource);
                    GridLocalidades.DataSource = new BindingSource { DataSource = dtSource };
                }
            }
            RefreshQueryBtn.Enabled = true;
            CargarReqBtn.Enabled = true;
            GridLocalidades.Enabled = true;
            GridViewSolicitud.Enabled = true;
            BtnGuardar.Enabled = true;
            BtnLimpiar.Enabled = true;
            TxtItems.Enabled = true;
            CbxSemana.Enabled = true;
        }

        private void TxtItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                string item = TxtItems.Text.Trim();
                if (!string.IsNullOrEmpty(item)) return;

                string query = @"
                                SELECT 
	                                I.ite_codigo AS Codigo,
	                                I.ite_descripcion AS Producto,
	                                FD.facd_cantidad AS Cantidad,
	                                L.loc_nombre AS Localidad,
	                                FD.facd_lote AS Num_Lote,
	                                F.fac_numero AS Orden,
	                                FD.facd_usuario_crea AS Usuario,
	                                PL.pac_scan_whin AS Recibido,
	                                DATEDIFF(DAY, PL.pac_scan_whin, GETDATE()) AS PERMANENCIA_EN_BODEGA
                                FROM wai_Factura_Detalle FD
	                                INNER JOIN wai_Pack_List PL ON FD.facd_id = PL.pac_factura_detalle_id
	                                INNER JOIN wai_Localidad L ON PL.pac_localidad_id = L.loc_id
	                                INNER JOIN wai_Item I ON FD.facd_item_id = I.ite_id
	                                INNER JOIN wai_Factura F ON FD.facd_fac_id = F.fac_id
                                WHERE I.ite_bodega_id = @bodega
	                                 AND FD.facd_cantidad > 0
	                                 AND PL.pac_scan_whin IS NOT NULL
	                                 AND I.ite_codigo = @codigo
                                ORDER BY PL.pac_scan_whin DESC";

                using (SqlCommand cmd = new SqlCommand(query, waiConn))
                {
                    cmd.Parameters.AddWithValue("@codigo", item);
                    cmd.Parameters.AddWithValue("@bodega", bodegaID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        GridLocalidades.DataSource = new BindingSource { DataSource = dt };
                    }
                }
            }
        }


        private void RefreshQueryBtn_Click(object sender, EventArgs e)
        {
            WainariDataBase();
            TxtItems.Clear();
        }

        private void CargarReqBtn_Click(object sender, EventArgs e)
        {
            DataTable dtSeleccionados = new DataTable();
            if (GridViewSolicitud.DataSource is DataTable existingTable)
            {
                dtSeleccionados = existingTable;
            }
            else
            {
                dtSeleccionados = new DataTable();
                dtSeleccionados.Columns.Add("Item", typeof(string));
                dtSeleccionados.Columns.Add("Cantidad", typeof(int));
                dtSeleccionados.Columns.Add("sol_localidad", typeof(string));
            }
            foreach (GridViewRowInfo row in GridLocalidades.Rows)
            {
                var selectedCell = row.Cells["Seleccionado"];
                if (selectedCell != null && selectedCell.Value != null && (bool)selectedCell.Value)
                {
                    string ltpart = row.Cells["Codigo"].Value.ToString();
                    int ltqty = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    string ltwh = row.Cells["Localidad"].Value.ToString(); 
                    dtSeleccionados.Rows.Add(ltpart, ltqty, ltwh);
                }
            }
            GridViewSolicitud.DataSource = dtSeleccionados;
            WainariDataBase();
            if (dtSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No se han seleccionado items.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool ValidarDatos()
        {
            try
            {
                if (GridViewSolicitud.RowCount > 0)
                {
                    DataTable dt = new DataTable();                  
                    flagEstado = false;
                    plta.Fill(dsp.PlanSemana, CbxSemana.Text.Trim());
                    dtPlan = dsp.Tables["PlanSemana"];
                    dt.Columns.Add("Semana", typeof(string));
                    dt.Columns.Add("Item", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(int));
                    dt.Columns.Add("Item_Desv", typeof(string));
                    dt.Columns.Add("SOBRE_CONSUMO", typeof(bool ));                 
                    dt.Columns.Add("sol_localidad", typeof(string));
                    dt.Columns.Add("ESTADO", typeof(string));

                    dtGrid.Reset();
                    dtGrid.Columns.Add("Semana", typeof(string));
                    dtGrid.Columns.Add("Item", typeof(string));
                    dtGrid.Columns.Add("Cantidad", typeof(int));
                    dtGrid.Columns.Add("Item_Desv", typeof(bool));
                    dtGrid.Columns.Add("SOBRE_CONSUMO", typeof(bool));                  
                    dtGrid.Columns.Add("sol_localidad", typeof(string));
                    dtGrid.Columns.Add("ESTADO", typeof(string));
                    string Articulo = "";
                    for (int r = 0; r < this.GridViewSolicitud.RowCount; r++)
                    {
                        bool desviacion = false;
                        bool itemDesv = false;
                        if (GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value == null)
                        {
                            itemDesv = false;
                        }
                          else  if (GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value.ToString () == "Off")
                        {
                            itemDesv = false;
                        }
                        else if(GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value.ToString() == "On")
                        {
                            itemDesv = true;
                        }else if(Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value) == true)
                        {
                            itemDesv = true;
                        }
                        else if (Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value) == false)
                        {
                            itemDesv = false;
                        }
                        if (itemDesv  == true )
                        {
                            var valor = (csl.ProductoQuery(CbxSemana.Text.Trim(), GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim()));
                            desviacion = true;
                       if (valor != null)
                       {
                           Articulo = valor.ToString().Trim();
                       }
                       else
                       {
                           MessageBox.Show("El item  " + GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim() + " no puede ser Desviado" );
                           flagEstado = true;
                                Articulo = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                        
                            }
                        }
                        else
                        {
                            Articulo = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                        }


                        dt.Rows.Add(CbxSemana.Text.Trim(),Articulo ,
                                    Convert.ToInt32(GridViewSolicitud.Rows[r].Cells["Cantidad"].Value.ToString().Trim()),
                                   desviacion, Convert.ToBoolean( GridViewSolicitud.Rows[r].Cells["SOBRE_CONSUMO"].Value),
                                   GridViewSolicitud.Rows[r].Cells["sol_localidad"].Value.ToString().Trim().ToUpper());
                      
                        dtGrid.Rows.Add(CbxSemana.Text.Trim(), GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim(),
                                    Convert.ToInt32(GridViewSolicitud.Rows[r].Cells["Cantidad"].Value.ToString().Trim()),
                                  desviacion, Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["SOBRE_CONSUMO"].Value),
                                   GridViewSolicitud.Rows[r].Cells["sol_localidad"].Value.ToString().Trim().ToUpper()); 
                    }
                    if (dtPlan.Rows.Count > 0)
                    {
                      
                        var consulta = (from x in dt.AsEnumerable()
                                        select new
                                        {
                                            Semana = x.Field<string>("Semana"),
                                            Item = x.Field<string>("Item")
                                        }
                                            ).Except(from x in dtPlan.AsEnumerable()
                                                     select new
                                                     {
                                                         Semana = x.Field<string>("pla_semana"),
                                                         Item = x.Field<string>("pla_item")
                                                     }).ToList();

                        if (consulta.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows) // search whole table
                            {

                                foreach (var item in consulta)
                                {
                                    if (dr["Semana"].ToString() == item.Semana.ToString() && dr["Item"].ToString() == item.Item.ToString()) // if id==2
                                    {
                                        dr["ESTADO"] = "ENCONTRADO";
                                    }
                                }
                            }
                            flagEstado = true;
                        }

                        using (dcPmcDataContext db = new dcPmcDataContext())
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Convert.ToBoolean(dr["SOBRE_CONSUMO"]) == false)
                                {
                                    var sumItem = dtPlan.AsEnumerable().Where(x => x.Field<string>("pla_item") == dr["Item"].ToString()).Sum(pr => pr.Field<int>("pla_cantidad"));
                                    var sumItemSol = db.pmc_Solicitudes.Where(x => x.sol_item == dr["Item"].ToString() && x.sol_semana == dr["Semana"].ToString()).Sum(pr => pr.sol_cant_entregada);
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
                            GridViewSolicitud.DataSource = dt;    
                    }
                    else
                    {
                        dt.Columns.Remove("Semana");
                        GridViewSolicitud.DataSource = dt;
                        flagEstado = true;
                        MessageBox.Show("El plan para la semana Seleccionada \n No contiene Registros; " );
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
        private void frmSolicitudes_Load(object sender, EventArgs e)
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CbxSemana_Click(object sender, EventArgs e)
        {
            CbxSemana.BackColor = Color.White;
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
                        if (GridViewSolicitud.Rows[r].Cells["Item"].Value == null || GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Producto");
                            break;
                        }
                        else if (GridViewSolicitud.Rows[r].Cells["Cantidad"].Value == null || GridViewSolicitud.Rows[r].Cells["Cantidad"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Cantidad");
                            break;
                        }
                        else if (GridViewSolicitud.Rows[r].Cells["sol_localidad"].Value == null || GridViewSolicitud.Rows[r].Cells["sol_localidad"].Value.ToString().Trim() == "")
                        {
                            flagValidar = true;
                            MessageBox.Show("Verificar columna Localidad");
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
                         
                            // Se convierte el DataTable a una lista
                            var final = (from x  in dtGrid.AsEnumerable()
                                         select new
                                         {
                                             Item= x.Field<string>("Item"),
                                             Cantidad= x.Field<int>("Cantidad"),
                                             Item_Desv = x.Field<bool>("Item_Desv"),
                                             SOBRE_CONSUMO = x.Field<bool>("SOBRE_CONSUMO"),
                                             sol_localidad = x.Field<string>("sol_localidad"),
                                             ESTADO = x.Field<string>("ESTADO"),

                                         }).ToList();
                            //Se pasa la lista a el RadGridview
                            GridViewSolicitud.DataSource = final;

                            //Se inserta en la tabla solicitudes utilizando el procedimiento almencenado
                            using (dcPmcDataContext db = new dcPmcDataContext())
                            {
                                //GridViewSolicitud.DataSource = dtGrid;
                              
                                // Loop para realizar insertar fila por fila del grid a la base de datos
                                for (int r = 0; r < GridViewSolicitud.RowCount; r++)
                                {
                                    string Articulo ="";
                                    string desviado = null;
                                    // Se verifica si el usuario desea que el articulo sea desviado o no 
                                    if (Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value) == true)
                                    {
                                       
                                        var valor = (csl.ProductoQuery(CbxSemana.Text.Trim(), GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim()));
                                        if (valor != null)
                                        {
                                            Articulo = valor.ToString().Trim();
                                            desviado = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                                        }
                                        else
                                        {
                                            MessageBox.Show("El item  " + GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim() + " no puede ser Desviado");
                                        }
                                    }
                                    else
                                    {
                                        Articulo = GridViewSolicitud.Rows[r].Cells["Item"].Value.ToString().Trim();
                                    }
                                    //Se ejecuta el procedimiento almacenado
                                    var msg = db.usp_pmc_Solicitudes_CRUD(1, CbxSemana.Text.Trim(),null,
                                                Articulo ,desviado , Convert.ToInt32(GridViewSolicitud.Rows[r].Cells["Cantidad"].Value),
                                                Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["Item_Desv"].Value),
                                                Convert.ToBoolean(GridViewSolicitud.Rows[r].Cells["SOBRE_CONSUMO"].Value), GridViewSolicitud.Rows[r].Cells["sol_localidad"].Value.ToString().Trim().ToUpper(), 'C');
                                    // Se obtiene el Resultado de la ejecucion del procedimiento almacenado
                                    resultado = msg.Select(x => x.Column1).FirstOrDefault();
                                  
                                }
                            }
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

        private void GridViewSolicitud_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            try
            {
                // Formato a celda según el valor contenido
                if (GridViewSolicitud.RowCount > 0)
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
                    else if (e.CellElement.ColumnInfo.HeaderText == "Localidad")
                    {
                        if (e.CellElement.RowInfo.Cells["sol_localidad"].Value == null || e.CellElement.RowInfo.Cells["sol_localidad"].Value.ToString().Trim() == "")
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

        private void GridViewSolicitud_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            try
            {
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


        #endregion


    }
}
