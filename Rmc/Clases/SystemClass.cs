using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using static Rmc.Modelo.Utilidades;

namespace Rmc.Clases
{
    class SystemClass
    {
        int appID = Properties.Settings.Default.appID;
        readonly SqlConnection conn = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString);
        //readonly SqlConnection conn = new SqlConnection(Properties.Settings.Default.ESSOCKS);
        SqlConnection connStg = new SqlConnection(Properties.Settings.Default.ES_SOCKS_StagingAreaConnectionString);
        //readonly SqlConnection conn = new SqlConnection("integrated security=SSPI;data source=ESDEVSQL1V;persist security info=False;initial catalog=ES_SOCKS");
        SqlConnection connTracer = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        string usuario;

        //integrated security=SSPI;data source=ESDEVSQL1V;persist security info=False;initial catalog=ES_SOCKS
        //integrated security=SSPI;data source=ESPRDSQL1V;persist security info=False;initial catalog=ES_SOCKS

        public int AppID
        {
            get
            {
                return this.appID;
            }
            set
            {
                this.appID = value;
            }
        }

        public string Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }
        }

        public int MesaActivaId { get; set; }

        public SystemClass()
        {
            Usuario = Environment.UserName.ToString();
        }

        public SqlConnection OpenConection()
        {
            try
            {
                if(conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source." + ex);
            }

            return conn;
        }

        public SqlConnection OpenConectionTracer()
        {
            try
            {
                if (connTracer.State != ConnectionState.Open)
                    connTracer.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source." + ex);
            }

            return connTracer;
        }

        public void ApplyComparer(RadDropDownList rdd)
        {
            rdd.AutoCompleteMode = AutoCompleteMode.Suggest;
            rdd.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(rdd.DropDownListElement);
            rdd.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
        }


        public DataTable devDataTable(String sql)
        {
            try
            {   
                SqlCommand micm = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(micm.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al devolver datatable: " + ex.Message + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt1 = new DataTable();
                return dt1;
            }

        }
        internal DataTable DevDataTable(string sql)
        {
            throw new NotImplementedException();
        }

        public SqlConnection OpenConectionStg()
        {
            try
            {
                if(connStg.State != ConnectionState.Open)
                    connStg.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source." + ex);
            }

            return connStg;
        }
        public String DevValor(String Sql)
        {
            try
            {
                SqlCommand miCm = new SqlCommand(Sql, connTracer);
                return Convert.ToString(miCm.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return "Fail";
            }

        }

        public class CustomAutoCompleteSuggestHelper : AutoCompleteSuggestHelper
        {
            public CustomAutoCompleteSuggestHelper(RadDropDownListElement owner)
                : base(owner)
            {
            }

            public override void ApplyFilterToDropDown(string filter)
            {
                base.ApplyFilterToDropDown(filter);
                this.DropDownList.ListElement.DataLayer.DataView.Comparer = new CustomComparer();
            }
        }

        public String InsertDataWithParam(String sqlQuery, SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = connTracer;

            //Vamos a ingresar los parametros al query
            foreach (SqlParameter pp in p)
            {
                cmd.Parameters.Add(pp);
            }

            try
            {
                //Ejecutamos
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "InsertDataWithParam");
                return null;
            }


        }

        public DataTable DevDataTable2(String sql)
        {
            try
            {
                SqlCommand micm = new SqlCommand(sql);
                DataTable dt = new DataTable();
                dt.Load(micm.ExecuteReader());
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CloseConection()
        {
            conn.Close();
        }

            public void CloseConectionStg()
        {
            connStg.Close();
        }

        public void CloseConectionTracer()
        {
            connTracer.Close();
        }
        public Boolean StatusAd(String Usuario)
        {
            try
            {
                // Create the context for the principal object. 
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

                UserPrincipal u = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, Usuario);
                return Convert.ToBoolean(u.Enabled.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        public void formarDatedMyHms(RadDateTimePicker DatePicker)
        {
            DatePicker.Value = DateTime.Now;
            DatePicker.DateTimePickerElement.ShowTimePicker = true;
            DatePicker.Format = DateTimePickerFormat.Custom;
            DatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            (DatePicker.DateTimePickerElement.CurrentBehavior as RadDateTimePickerCalendar).DropDownMinSize = new System.Drawing.Size(330, 250);
        }
        public string FormatSQLDate(DateTime fecha)
        {
            return fecha.Year.ToString() + "-" + Formato_00(fecha.Month.ToString()) + "-" + Formato_00(fecha.Day.ToString())
                + " " + Formato_00(fecha.Hour.ToString()) + ":" + Formato_00(fecha.Minute.ToString()) + ":" + Formato_00(fecha.Second.ToString());
        }

        public string Formato_00(string valor)
        {
            try
            {
                if (valor.Length == 1)
                    return "0" + valor;
                else
                    return valor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddButtonCerrar(RadForm form)
        {
            RadButton salir = new RadButton();
            //MessageBox.Show(form.Height.ToString());
            salir.Location = new System.Drawing.Point((form.Width), (form.Height) - 88);
            salir.Text = "Cerrar";
            salir.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            salir.Width = 125;
            salir.Height = 30;
            salir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            salir.ThemeClassName = "Telerik.WinControls.UI.RadButton";
            salir.ThemeName = "TelerikMetroBlue";
            salir.Click += salir_Click;
            form.Controls.Add(salir);
        }

        public void salir_Click(object sender, EventArgs e)
        {
            RadButton button = (RadButton)sender;
            //MessageBox.Show(button.Text.ToString());
            RadForm form = (RadForm)button.Parent;
            form.Close();
        }

        #region MOVIMIENTOS DE INVENTARIO
        public class Detalle
        {
            public int IdDetalle { get; set; }
            public string Semana { get; set; }
            public string Producto { get; set; }
            public string Desviacion { get; set; }
            public int? Original { get; set; }
            public int? Desviado { get; set; }
            public string Dia { get; set; }
            public string Turno { get; set; }
            public string Usuario { get; set; }
            public DateTime? Fecha { get; set; }
            public string UsuarioModifica { get; set; }
            public DateTime? FechaModificacion { get; set; }
        }
        public List<Detalle> OBTENER_DETALLE_SEMANA(string semana)
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    var detalle = db.ExecuteQuery<Detalle>("	SELECT mov_det_ID as IdDetalle, mov_det_semana as Semana, mov_det_item as Producto, mov_det_desv Desviacion ,mov_det_cant as Original ,mov_det_cant_desv  as Desviado" +
"		 ," +
"		 UPPER(FORMAT( (CASE" +
"                                     WHEN CONVERT(TIME,mov_det_FH_crea) BETWEEN '07:00:01' AND '18:00:00' THEN mov_det_FH_crea" +
"									 WHEN CONVERT(TIME,mov_det_FH_crea) >='18:00:01' AND CONVERT(TIME,mov_det_FH_crea) <= '23:59:00' THEN mov_det_FH_crea" +
"                                     WHEN CONVERT(TIME,mov_det_FH_crea-1) >='18:00:01' AND CONVERT(TIME,mov_det_FH_crea) <= '07:00:00' THEN mov_det_FH_crea-1" +
"                                     ELSE DATEADD(D, -1, mov_det_FH_crea)" +
"                                     END), 'dddd', 'es-es')) AS Dia ," +
"									 " +
"									 (CASE WHEN mov_det_FH_crea IS NOT NULL THEN (CASE WHEN (DATEPART(HOUR, mov_det_FH_crea) >= 7 AND " +
" DATEPART(HOUR,mov_det_FH_crea) < 18) THEN 'DIURNO' ELSE 'NOCTURNO' END) ELSE ' 'END)AS Turno," +
" (SELECT Usr_Name FROM mst_Users WHERE Usr_Login = mov_det_usuario) AS Usuario, mov_det_FH_crea as Fecha,(SELECT Usr_Name FROM mst_Users WHERE Usr_Login = mov_det_usuario_mod)  as UsuarioModifica ,mov_det_FH_mod as FechaModificacion FROM pmc_Mov_Bodega_Det" +
" WHERE mov_det_semana= '" + semana +"'"+
" order by FECHA asc").ToList<Detalle>();

                    return detalle;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<pmc_Mov_Bodega> PLAN_MOV_SEMANA(string semana)
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    var movSem = db.ExecuteQuery<pmc_Mov_Bodega>("SELECT mov_semana, mov_item, mov_item_desv, mov_cantidad, mov_cantidad_vieja, mov_FH_crea, mov_usuario_crea, mov_orden FROM pmc_Mov_Bodega WHERE mov_semana = '"+semana+"'ORDER BY mov_orden, mov_cantidad DESC").ToList<pmc_Mov_Bodega>();
                    return movSem;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ACTUALIZAR_PENDIENTES(string semana)
        {

            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                  

                 var cadena=   db.ExecuteQuery<string>("BEGIN TRY" +
"	BEGIN TRANSACTION " +

"	    UPDATE pmc_Mov_Bodega SET mov_estado =0 " +
"		                          WHERE mov_semana =  '" + semana + "'" +
"	     MERGE pmc_Mov_Bodega AS TARGET" +
"              USING (SELECT        SEMANA, PRODUCTO, DESVIACION, PENDIENTE, GETDATE() AS fecha, RTRIM(SUBSTRING(SUSER_NAME(), 8, 20)) AS USUARIO, ORDEN" +
" FROM            (SELECT        1 AS ORDEN, '"+semana+"' AS SEMANA, pla_item AS PRODUCTO, DESVIACION, CANTIDAD_PLAN, SOBRANTES, CANTIDAD_ENTREGADA, ENTREGA_ORIGINAL, " +
"                                                    ENTREGA_DESVIACION, (CASE WHEN (CC.CANTIDAD_PLAN ) " +
"                                                    - CC.SOBRANTES <= 0 THEN 0 ELSE (CC.CANTIDAD_PLAN ) - CC.SOBRANTES END) AS PENDIENTE, " +
"                                                    (CASE WHEN (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) - CC.SOBRANTES <= 0 THEN (CC.ENTREGA_ORIGINAL + CC.ENTREGA_DESVIACION + CC.SOBRANTES) " +
"                                                    - CC.CANTIDAD_PLAN ELSE 0 END) AS SOBRE_CONSUMO" +
"                          FROM            (SELECT        pla_item, ISNULL(pla_item_desv, '') AS DESVIACION, ISNULL(SUM(pla_sobrantes), 0) AS SOBRANTES, ISNULL(SUM(pla_cantidad), 0) AS CANTIDAD_PLAN," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            dbo.pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_item = dbo.pmc_Plan.pla_item) AND (sol_semana = '"+semana+"')) AS CANTIDAD_ENTREGADA," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            dbo.pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 0) AND (sol_item = dbo.pmc_Plan.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_ORIGINAL," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            dbo.pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 1) AND (sol_item = dbo.pmc_Plan.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_DESVIACION" +
"                                                    FROM            dbo.pmc_Plan" +
"                                                    WHERE        (pla_semana = '"+semana+"') AND (pla_estilo <> 'EPC') AND (pla_estado = 1) AND (LTRIM(RTRIM(pla_silueta)) <> 'PROMOCIONAL') AND " +
"                                                                              (LTRIM(RTRIM(pla_silueta)) <> 'GN')" +
"                                                    GROUP BY pla_item, ISNULL(pla_item_desv, '')) AS CC" +
"                          WHERE        ((CASE WHEN (CC.CANTIDAD_PLAN ) - CC.SOBRANTES <= 0 THEN 0 ELSE (CC.CANTIDAD_PLAN ) " +
"                                                    - CC.SOBRANTES END) > 0)" +
"                          UNION ALL" +
"                          SELECT        2 AS ORDEN, '"+semana+"' AS SEMANA, pla_item AS PRODUCTO, DESVIACION, CANTIDAD_PLAN, SOBRANTES, CANTIDAD_ENTREGADA, ENTREGA_ORIGINAL, " +
"                                                   ENTREGA_DESVIACION, (CASE WHEN (GNP.CANTIDAD_PLAN ) " +
"                                                   - GNP.SOBRANTES <= 0 THEN 0 ELSE (GNP.CANTIDAD_PLAN ) - GNP.SOBRANTES END) AS PENDIENTE, " +
"                                                   (CASE WHEN (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) - GNP.SOBRANTES <= 0 THEN (GNP.ENTREGA_ORIGINAL + GNP.ENTREGA_DESVIACION + GNP.SOBRANTES) " +
"                                                   - GNP.CANTIDAD_PLAN ELSE 0 END) AS SOBRE_CONSUMO" +
"                          FROM            (SELECT        pla_item, ISNULL(pla_item_desv, '') AS DESVIACION, ISNULL(SUM(pla_sobrantes), 0) AS SOBRANTES, ISNULL(SUM(pla_cantidad), 0) AS CANTIDAD_PLAN," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            dbo.pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '"+semana+"')) AS CANTIDAD_ENTREGADA," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            dbo.pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 0) AND (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_ORIGINAL," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            dbo.pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 1) AND (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_DESVIACION" +
"                                                    FROM            dbo.pmc_Plan AS pmc_Plan_1" +
"                                                    WHERE        (pla_semana = '"+semana+"') AND (pla_estilo <> 'EPC') AND (pla_estado = 1) AND (LTRIM(RTRIM(pla_silueta)) = 'PROMOCIONAL' OR" +
"                                                                              LTRIM(RTRIM(pla_silueta)) = 'GN')" +
"                                                    GROUP BY pla_item, ISNULL(pla_item_desv, '')) AS GNP" +
"                          WHERE        ((CASE WHEN (GNP.CANTIDAD_PLAN ) " +
"                                                   - GNP.SOBRANTES <= 0 THEN 0 ELSE (GNP.CANTIDAD_PLAN ) - GNP.SOBRANTES END) > 0)) AS ORDERNADO" +
" ) AS SOURCE" +
"                  ON (TARGET.mov_semana = SOURCE.SEMANA ) AND (TARGET.mov_item= SOURCE.PRODUCTO) " +
"                  WHEN MATCHED THEN  " +
"                   UPDATE SET TARGET.mov_cantidad = SOURCE.PENDIENTE ,TARGET.mov_item_desv =SOURCE.desviacion" +				              
"                  WHEN NOT MATCHED THEN  " +
"                      INSERT  (mov_semana,mov_item ,mov_item_desv ,mov_cantidad,mov_FH_crea,mov_usuario_crea,mov_orden)" +
"				      VALUES (SOURCE.SEMANA,SOURCE.PRODUCTO,SOURCE.DESVIACION,SOURCE.PENDIENTE,GETDATE(), RTRIM(SUBSTRING(SUSER_NAME(), 8, 20)),SOURCE.ORDEN   );" +
"		" +
" UPDATE  pmc_Mov_Bodega  set mov_estado=1 where mov_semana ='"+semana+"' and mov_item in(SELECT       PRODUCTO" +
" FROM            (SELECT        1 AS ORDEN, '"+semana+"' AS SEMANA, pla_item AS PRODUCTO, DESVIACION, CANTIDAD_PLAN, SOBRANTES, CANTIDAD_ENTREGADA, ENTREGA_ORIGINAL, ENTREGA_DESVIACION, " +
"                                                    (CASE WHEN (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) - CC.SOBRANTES <= 0 THEN 0 ELSE (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) " +
"                                                    - CC.SOBRANTES END) AS PENDIENTE, (CASE WHEN (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) " +
"                                                    - CC.SOBRANTES <= 0 THEN (CC.ENTREGA_ORIGINAL + CC.ENTREGA_DESVIACION + CC.SOBRANTES) - CC.CANTIDAD_PLAN ELSE 0 END) AS SOBRE_CONSUMO" +
"                          FROM            (SELECT        pla_item, ISNULL(pla_item_desv, '') AS DESVIACION, ISNULL(SUM(pla_sobrantes), 0) AS SOBRANTES, ISNULL(SUM(pla_cantidad), 0) AS CANTIDAD_PLAN," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_item = pmc_Plan.pla_item) AND (sol_semana = '"+semana+"')) AS CANTIDAD_ENTREGADA," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 0) AND (sol_item = pmc_Plan.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_ORIGINAL," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 1) AND (sol_item = pmc_Plan.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_DESVIACION" +
"                                                    FROM            pmc_Plan" +
"                                                    WHERE        (pla_semana = '"+semana+"') AND (pla_estilo <> 'EPC') AND (pla_estado = 1) AND (LTRIM(RTRIM(pla_silueta)) <> 'PROMOCIONAL') AND (LTRIM(RTRIM(pla_silueta)) <> 'GN')" +
"                                                    GROUP BY pla_item, ISNULL(pla_item_desv, '')) AS CC" +
"                          WHERE        ((CASE WHEN (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) - CC.SOBRANTES <= 0 THEN 0 ELSE (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) " +
"                                                    - CC.SOBRANTES END) > 0)" +
"                          UNION ALL" +
"                          SELECT        2 AS ORDEN, '"+semana+"' AS SEMANA, pla_item AS PRODUCTO, DESVIACION, CANTIDAD_PLAN, SOBRANTES, CANTIDAD_ENTREGADA, ENTREGA_ORIGINAL, ENTREGA_DESVIACION, " +
"                                                   (CASE WHEN (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) " +
"                                                   - GNP.SOBRANTES <= 0 THEN 0 ELSE (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) - GNP.SOBRANTES END) AS PENDIENTE, " +
"                                                   (CASE WHEN (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) - GNP.SOBRANTES <= 0 THEN (GNP.ENTREGA_ORIGINAL + GNP.ENTREGA_DESVIACION + GNP.SOBRANTES) " +
"                                                   - GNP.CANTIDAD_PLAN ELSE 0 END) AS SOBRE_CONSUMO" +
"                          FROM            (SELECT        pla_item, ISNULL(pla_item_desv, '') AS DESVIACION, ISNULL(SUM(pla_sobrantes), 0) AS SOBRANTES, ISNULL(SUM(pla_cantidad), 0) AS CANTIDAD_PLAN," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '"+semana+"')) AS CANTIDAD_ENTREGADA," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 0) AND (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_ORIGINAL," +
"                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
"                                                                                    FROM            pmc_Solicitudes AS slin" +
"                                                                                    WHERE        (sol_desv = 1) AND (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '"+semana+"')) AS ENTREGA_DESVIACION" +
"                                                    FROM            pmc_Plan AS pmc_Plan_1" +
"                                                    WHERE        (pla_semana = '"+semana+"') AND (pla_estilo <> 'EPC') AND (pla_estado = 1) AND (LTRIM(RTRIM(pla_silueta)) = 'PROMOCIONAL' OR" +
"                                                                              LTRIM(RTRIM(pla_silueta)) = 'GN')" +
"                                                    GROUP BY pla_item, ISNULL(pla_item_desv, '')) AS GNP" +
"                          WHERE        ((CASE WHEN (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) " +
"                                                   - GNP.SOBRANTES <= 0 THEN 0 ELSE (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) - GNP.SOBRANTES END) > 0)) AS ORDERNADO" +
" )" +
"					SELECT 'OK' as Resultado" +
"	COMMIT TRANSACTION " +
"	END TRY" +
"	BEGIN CATCH" +
"		ROLLBACK TRANSACTION " +
"		 SELECT ERROR_MESSAGE() AS MSG" +
"	END CATCH ");

                    return cadena.FirstOrDefault().ToString();
                }
            }
           

            
                
            catch (Exception )
            {

                throw;
            }
        }
        public List<string> SEMANAS_MOVIMIENTOS(string anio,string semana)
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    if (semana.Trim() == "")
                    {
                        var semanas = db.ExecuteQuery<string>("SELECT DISTINCT mov_semana  FROM pmc_Mov_Bodega WHERE mov_semana LIKE '%'+'" + anio + "'+'%' order by mov_semana DESC").ToList<string>();
                        return semanas;
                    }
                    else
                    {
                        var semanas = db.ExecuteQuery<string>("SELECT DISTINCT mov_semana  FROM pmc_Mov_Bodega WHERE mov_semana LIKE '%'+'" + anio + "'+'%' and mov_semana = '"+semana +"' order by mov_semana DESC").ToList<string>();
                        return semanas;
                    }
                  
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> SEMANAS_MOVIMIENTOS_YEARS()
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                   
                        var semanas = db.ExecuteQuery<string>("SELECT DISTINCT mov_semana  FROM pmc_Mov_Bodega  order by mov_semana DESC").ToList<string>();
                        return semanas;
                    
                    

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void AGREGAR_MOVIMIENTOS(string semana)
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    //   string cadena =
                    db.ExecuteCommand(

                  "INSERT INTO pmc_Mov_Bodega (mov_semana,mov_item ,mov_item_desv ,mov_cantidad,mov_FH_crea,mov_usuario_crea,mov_orden)     " +
 " SELECT       SEMANA, PRODUCTO, DESVIACION, PENDIENTE,GETDATE() as fecha,rtrim(substring(SUSER_NAME(),8, 20)) as USUARIO,ORDEN" +
 " FROM            (SELECT        1 AS ORDEN, '" + semana + "' AS SEMANA, pla_item AS PRODUCTO, DESVIACION, CANTIDAD_PLAN, SOBRANTES, CANTIDAD_ENTREGADA, ENTREGA_ORIGINAL, ENTREGA_DESVIACION, " +
 "                                                    (CASE WHEN (CC.CANTIDAD_PLAN) - CC.SOBRANTES <= 0 THEN 0 ELSE (CC.CANTIDAD_PLAN ) " +
 "                                                    - CC.SOBRANTES END) AS PENDIENTE, (CASE WHEN (CC.CANTIDAD_PLAN - CC.ENTREGA_ORIGINAL - CC.ENTREGA_DESVIACION) " +
 "                                                    - CC.SOBRANTES <= 0 THEN (CC.ENTREGA_ORIGINAL + CC.ENTREGA_DESVIACION + CC.SOBRANTES) - CC.CANTIDAD_PLAN ELSE 0 END) AS SOBRE_CONSUMO" +
 "                          FROM            (SELECT        pla_item, ISNULL(pla_item_desv, '') AS DESVIACION, ISNULL(SUM(pla_sobrantes), 0) AS SOBRANTES, ISNULL(SUM(pla_cantidad), 0) AS CANTIDAD_PLAN," +
 "                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
 "                                                                                    FROM            pmc_Solicitudes AS slin" +
 "                                                                                    WHERE        (sol_item = pmc_Plan.pla_item) AND (sol_semana = '" + semana + "' )) AS CANTIDAD_ENTREGADA," +
 "                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
 "                                                                                    FROM            pmc_Solicitudes AS slin" +
 "                                                                                    WHERE        (sol_desv = 0) AND (sol_item = pmc_Plan.pla_item) AND (sol_semana = '" + semana + "' )) AS ENTREGA_ORIGINAL," +
 "                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
 "                                                                                    FROM            pmc_Solicitudes AS slin" +
 "                                                                                    WHERE        (sol_desv = 1) AND (sol_item = pmc_Plan.pla_item) AND (sol_semana = '" + semana + "' )) AS ENTREGA_DESVIACION" +
 "                                                    FROM            pmc_Plan" +
 "                                                    WHERE        (pla_semana = '" + semana + "') AND (pla_estilo <> 'EPC') AND (pla_estado = 1) AND (LTRIM(RTRIM(pla_silueta)) <> 'PROMOCIONAL') AND (LTRIM(RTRIM(pla_silueta)) <> 'GN')" +
 "                                                    GROUP BY pla_item, ISNULL(pla_item_desv, '')) AS CC" +
 "                          WHERE        ((CASE WHEN (CC.CANTIDAD_PLAN ) - CC.SOBRANTES <= 0 THEN 0 ELSE (CC.CANTIDAD_PLAN ) " +
 "                                                    - CC.SOBRANTES END) > 0)" +
 "                          UNION ALL " +
 "                          SELECT        2 AS ORDEN, '" + semana + "' AS SEMANA, pla_item AS PRODUCTO, DESVIACION, CANTIDAD_PLAN, SOBRANTES, CANTIDAD_ENTREGADA, ENTREGA_ORIGINAL, ENTREGA_DESVIACION, " +
 "                                                   (CASE WHEN (GNP.CANTIDAD_PLAN ) " +
 "                                                   - GNP.SOBRANTES <= 0 THEN 0 ELSE (GNP.CANTIDAD_PLAN ) - GNP.SOBRANTES END) AS PENDIENTE, " +
 "                                                   (CASE WHEN (GNP.CANTIDAD_PLAN - GNP.ENTREGA_ORIGINAL - GNP.ENTREGA_DESVIACION) - GNP.SOBRANTES <= 0 THEN (GNP.ENTREGA_ORIGINAL + GNP.ENTREGA_DESVIACION + GNP.SOBRANTES) " +
 "                                                   - GNP.CANTIDAD_PLAN ELSE 0 END) AS SOBRE_CONSUMO" +
 "                          FROM            (SELECT        pla_item, ISNULL(pla_item_desv, '') AS DESVIACION, ISNULL(SUM(pla_sobrantes), 0) AS SOBRANTES, ISNULL(SUM(pla_cantidad), 0) AS CANTIDAD_PLAN," +
 "                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
 "                                                                                    FROM            pmc_Solicitudes AS slin" +
 "                                                                                    WHERE        (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '" + semana + "' )) AS CANTIDAD_ENTREGADA," +
 "                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
 "                                                                                    FROM            pmc_Solicitudes AS slin" +
 "                                                                                    WHERE        (sol_desv = 0) AND (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '" + semana + "' )) AS ENTREGA_ORIGINAL," +
 "                                                                                  (SELECT        ISNULL(SUM(sol_cant_entregada), 0) AS Expr1" +
 "                                                                                    FROM            pmc_Solicitudes AS slin" +
 "                                                                                    WHERE        (sol_desv = 1) AND (sol_item = pmc_Plan_1.pla_item) AND (sol_semana = '" + semana + "' )) AS ENTREGA_DESVIACION" +
 "                                                    FROM            pmc_Plan AS pmc_Plan_1" +
 "                                                    WHERE        (pla_semana = '" + semana + "' ) AND (pla_estilo <> 'EPC') AND (pla_estado = 1) AND (LTRIM(RTRIM(pla_silueta)) = 'PROMOCIONAL' OR" +
 "                                                                              LTRIM(RTRIM(pla_silueta)) = 'GN')" +
 "                                                    GROUP BY pla_item, ISNULL(pla_item_desv, '')) AS GNP" +
 "                          WHERE        ((CASE WHEN (GNP.CANTIDAD_PLAN) " +
 "                                                   - GNP.SOBRANTES <= 0 THEN 0 ELSE (GNP.CANTIDAD_PLAN ) - GNP.SOBRANTES END) > 0)) AS ORDERNADO" +
 " ORDER BY ORDEN, PENDIENTE DESC");
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        public void LlenarList(RadListView rc, String query, String dm, String vm)
        {
            try
            {
                SqlDataReader miReader;
                DataTable miDt = new DataTable();
                SqlCommand miCm = new SqlCommand(query, conn);
                miReader = miCm.ExecuteReader();
                rc.DataSource = miReader;
                rc.DisplayMember = dm;
                rc.ValueMember = vm;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }


        }

        public bool EjecutarQuery(String query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
                return false;
            }
        }
        public bool EjecutarQueryTracer(String query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = connTracer;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Error " + e);
                return false;
            }
        }

        public bool EjecutarQueryStg(String query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = connStg;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
                return false;
            }
        }
        public bool EjecutarSP(SqlCommand execQuery)
        {
            try
            {
                execQuery.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
                return false;
            }
        }

        public String DevValorString(string query)
        {
            String valueDB;
            SqlCommand miCm = new SqlCommand(query, conn);

            try
            {
                valueDB = Convert.ToString(miCm.ExecuteScalar());
            }
            catch
            {
                valueDB = "";
            }
            return valueDB;

        }

        public String DevValorStringStg(string query)
        {
            String valueDB;
            SqlCommand miCm = new SqlCommand(query, connStg);

            try
            {
                valueDB = Convert.ToString(miCm.ExecuteScalar());
            }
            catch
            {
                valueDB = "";
            }
            return valueDB;

        }
        public string[] DevArray(string query)
        {
            string[] valores = null;
            try
            {
                SqlCommand miCm = new SqlCommand(query, conn);
                SqlDataReader reader = miCm.ExecuteReader();
                List<string> str = new List<string>();

                int conteo = reader.FieldCount;
                while (reader.Read())
                {
                    for (int i = 0; i < conteo; i++ )
                        str.Add(reader.GetValue(i).ToString());
                }
                reader.Close();
                valores = str.ToArray();
                return valores;
            }
            catch(Exception ex)
            {
                MessageBox.Show("OUT"+ex.Message);
                return valores;
            }

        }


        public bool IsNumeric(object expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return Convert.ToBoolean(isNum);
        }

        public void CargarFormulario(RadForm hijo, RadRibbonForm padre, RadDock rd)
        {
            hijo.MdiParent = padre;
            hijo.Show();
            rd.ActivateMdiChild(hijo);
        }

        public void LlenarGridUser(RadGridView rg, string sql, string tabla, string dm)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connTracer);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, tabla);
                rg.DataSource = ds;
                rg.DataMember = dm;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during LlenarGrid execution: " + e.Message);
            }
            finally
            {
                ds.Dispose();
            }
        }
        public void LlenarGrid(RadGridView rg, String sql, String tabla, String dm)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();

            try
            {
                da.Fill(ds, tabla);
                rg.DataSource = ds;
                rg.DataMember = dm;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }

            ds.Dispose();
        }

        public RadGridView LlenarGridExport(RadGridView rg, String sql, String tabla, String dm)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                da.Fill(ds, tabla);
                rg.DataSource = ds;
                rg.DataMember = dm;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }

            ds.Dispose();

            return rg;
        }

        public void LlenarGridSP(RadGridView rg, SqlCommand execQuery, string tabla, String dm)
        {
            SqlDataAdapter da = new SqlDataAdapter(execQuery);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, tabla);
                rg.DataSource = ds;
                rg.DataMember = dm;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }

            ds.Dispose();
        }

        public SqlDataReader DevDataReader(String sql)
        {

            SqlDataReader registros;
            try
            {
                SqlCommand datos = new SqlCommand(sql, conn);
                registros = datos.ExecuteReader();
                return registros;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener el DataReader " + e);
                SqlCommand datos = new SqlCommand(sql, conn);
                registros = datos.ExecuteReader();
                return registros;
            }

        }

        public void PermisosPestanias(RibbonTab nombre, bool sino)
        {
            //Primero nos vamos a traer todos los objetos relacionados al rol
            if (sino == false)
            {
                nombre.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }
            else
            {
                nombre.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }

        }

        public void Permisos(RadButtonElement nombre, bool sino)
        {
            //Primero nos vamos a traer todos los objetos relacionados al rol
            if (sino == false)
            {
                nombre.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            }
            else
            {
                nombre.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }

        }
        public void PermisosBotoneria(RadButton btnUpdate, RadButton btnDelete, String usuario, int appId, String opcion, Char action)
        {
            //la funcion retorna la suma de todos los permisos asignados para el usuario
            //Podria ser que en un rol lea una opcion, pero en otra no, entonces sumamos y tenemos nuestro dato.
            DataTable dt = new DataTable();
            OpenConection();
            string permisos="Select * from [fn_mst.GetFormPermissions]('" + opcion + "'," + appId + ",'" + usuario + "')";
            //MessageBox.Show(permisos);
            dt = DevDataTable(permisos);
            CloseConection();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["PermisosEliminar"].ToString()) > 0)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (Convert.ToInt32(row["PermisosActualizar"].ToString()) > 0)
                {
                    btnUpdate.Enabled = true;
                }
                else
                {
                    btnUpdate.Enabled = false;
                }
            }
            switch (action)
            {
                case 'L':
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }



        public void PermisosBotoneria(RadButton btnCreate, RadButton btnUpdate, RadButton btnDelete, String usuario, int appId, String opcion, Char action)
        {
            //la funcion retorna la suma de todos los permisos asignados para el usuario
            //Podria ser que en un rol lea una opcion, pero en otra no, entonces sumamos y tenemos nuestro dato.
            DataTable dt = new DataTable();
            OpenConection();
            dt = devDataTable("Select * from [fn_mst.GetFormPermissions]('" + opcion + "'," + appId + ",'" + usuario + "')");
            CloseConection();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["PermisosCrear"].ToString()) > 0)
                {
                    btnCreate.Enabled = true;
                }
                else
                {
                    btnCreate.Enabled = false;
                }
                if (Convert.ToInt32(row["PermisosEliminar"].ToString()) > 0)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (Convert.ToInt32(row["PermisosActualizar"].ToString()) > 0)
                {
                    btnUpdate.Enabled = true;
                }
                else
                {
                    btnUpdate.Enabled = false;
                }
            }
            switch(action)
            {
                case 'L':
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;

                case 'C':
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case 'U':
                    btnCreate.Enabled = false;
                    break;

            }
        }

        public void PermisosBotoneria(RadButton btn1, RadButton btn2, RadButton btn3, RadButton btn4, String usuario, int appId, String formulario)
        {
            //la funcion retorna la suma de todos los permisos asignados para el usuario
            //Podria ser que en un rol lea una opcion, pero en otra no, entonces sumamos y tenemos nuestro dato.
            DataTable dt = new DataTable();
            OpenConection();
            dt = DevDataTable("Select * from [fn_mst.GetFormPermissions]('" + formulario + "'," + appId + ",'" + usuario + "')");
            CloseConection();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["PermisosLeer"].ToString()) > 0)
                {
                    btn1.Enabled = true;
                }
                else
                {
                    btn1.Enabled = false;
                }
                if (Convert.ToInt32(row["PermisosCrear"].ToString()) > 0)
                {
                    btn2.Enabled = true;
                }
                else
                {
                    btn2.Enabled = false;
                }
                if (Convert.ToInt32(row["PermisosEliminar"].ToString()) > 0)
                {
                    btn3.Enabled = true;
                }
                else
                {
                    btn3.Enabled = false;
                }
                if (Convert.ToInt32(row["PermisosActualizar"].ToString()) > 0)
                {
                    btn4.Enabled = true;
                }
                else
                {
                    btn4.Enabled = false;
                }

            }
            btn1.Enabled = false;
        }

        public DataTable DevDataTable(String sql, SqlConnection cn)
        {
            try
            {
                SqlCommand micm = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                dt.Load(micm.ExecuteReader());
                return dt;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                DataTable dt1 = new DataTable();
                return dt1;
            }

        }

        public bool RadControlNotNull(RadForm rf, string[] campos)
        {
            bool validar = true;
            foreach (string c in campos)
            {
                foreach (RadControl control in rf.Controls)
                {
                    if (control is RadTextBox)
                        if (control.Name == c)
                            if (String.IsNullOrWhiteSpace(control.Text.ToString()))
                            {
                                validar = false;
                                control.BackColor = Color.FromArgb(249, 158, 158);
                            }
                            else
                                control.BackColor = Color.White;
                    /*if (control is ComboBox)
                        if (control.Name == c)
                            if (String.IsNullOrWhiteSpace(control.Text.ToString()))
                                validar = false;*/
                }
            }
            return validar;
        }

        public void LlenarComboAutocompletar(ComboBox cb, String sql, String Dm, String Vm, String tb, SqlConnection cn)
        {
            SqlDataAdapter miAdapter = new SqlDataAdapter(sql, cn);
            System.Data.DataSet miDataset = new System.Data.DataSet();

            DataTable dt = new DataTable();

            try
            {
                miAdapter.Fill(miDataset, tb);
                miAdapter.Fill(dt);
                AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    datos.Add(Convert.ToString(row[0]));
                }

                cb.DataSource = miDataset.Tables[0];
                cb.DisplayMember = Dm;
                cb.ValueMember = Vm;


                cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cb.AutoCompleteCustomSource = datos;
                // cb.SelectedItem = null;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);

            }

        }
        public void LlenarComboBox(ComboBox Cbx, String Dt, String Vm, String tabla, String Dm, String query, SqlConnection cn)
        {
            SqlDataAdapter Mida = new SqlDataAdapter(query, cn);
            DataSet Midt = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Mida.Fill(Midt, tabla);

            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }


            Cbx.DataSource = Midt.Tables[0];
            Cbx.ValueMember = Vm;
            Cbx.DisplayMember = Dm;
        }

        public void LlenarMultiCombo(RadMultiColumnComboBox rcb, String sql, String dm, String vm, String tb)
        {
            SqlDataAdapter miAdapter = new SqlDataAdapter(sql, conn);
            DataSet miDataSet = new DataSet();
            AutoCompleteStringCollection miColeccion = new AutoCompleteStringCollection();
            DataTable miDataTabla = new DataTable();

            try
            {
                foreach (DataRow row in miDataTabla.Rows)
                {
                    miColeccion.Add(Convert.ToString(row[1]));
                }
                miAdapter.Fill(miDataSet, tb);
                miAdapter.Fill(miDataTabla);
                rcb.DataSource = miDataSet.Tables[0];
                rcb.ValueMember = vm;
                rcb.DisplayMember = dm;
                rcb.AutoCompleteMode = AutoCompleteMode.Append;
                rcb.AutoFilter = true;


            }
            catch (Exception e)
            {
                MessageBox.Show("Error al llenar Multicombobox: " + e);

            }
        }

        public void LlenarDropDownList(RadDropDownList ddl, string sql, string displayMember, string valueMember)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable links = new DataTable();

                adapter.Fill(links);

                ddl.DisplayMember = displayMember;
                ddl.ValueMember = valueMember;
                ddl.DataSource = links;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el campo " + ddl.Name.ToString() + "\n" + ex.ToString());
            }
        }


        public void InsertSqlBulkCopy(DataTable tabla, String tDestino)
        {
            SqlBulkCopy miSqlBulk = new SqlBulkCopy(conn);
            try
            {
                miSqlBulk.DestinationTableName = tDestino;
                miSqlBulk.WriteToServer(tabla);

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al insertar tabla " + e);
            }


        }

        
        public void InsertSqlBulkCopyStg(DataTable tabla, String tDestino)
        {
            SqlBulkCopy miSqlBulk = new SqlBulkCopy(connStg);
            try
            {
                miSqlBulk.DestinationTableName = tDestino;
                miSqlBulk.WriteToServer(tabla);

            }
            catch (Exception)
            {
                throw;
            }


        }

        public void ExportarGrid(RadGridView rgv)
        {
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(rgv);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                spreadExporter.RunExport(" " + saveFileDialog1.FileName + ".xlsx", exportRenderer);
                MessageBox.Show("Datos Exportados");
            }
        }
        


        // 97-2003
        private readonly string excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1};IMEX=1;'";
        // 2007 - actual
        private readonly string excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1};IMEX=1;'";

        public bool CargarExcelToDG(RadBrowseEditor searchFile, RadGridView excelGrid, string sql) 
        {
            
            String filePath = searchFile.Value;
            DataSet dt = new DataSet();
            string extension = Path.GetExtension(filePath);
            string conStr, sheetName;
            conStr = string.Empty;
            
            try
            {
                switch (extension) //cambiar a minuscula
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(excel03ConString, filePath, "YES");
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(excel07ConString, filePath, "YES");
                        break;
                }

                OleDbConnection con = new OleDbConnection(conStr);
                
                //Get the name of the First Sheet.
                con.Open();
                DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString(); //Verificar que solo sea una hoja
                con.Close();

                // Agrego el nombre de la hoja
                sql += " From [" + sheetName + "]";

                con.Open();
                OleDbDataAdapter oda = new OleDbDataAdapter(sql,con);
                oda.Fill(dt,"x");
                //excelGrid.Columns.Clear();
                excelGrid.DataSource = dt;
                excelGrid.DataMember = "x";
                con.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Carga de Archivos Excel a SQL Server
        /// </summary>
        /// <param name="searchFile">The search file.</param>
        /// <param name="sqlExcel">Consulta para busqueda de campos en archivos Excel.</param>
        /// <param name="campos">Campos de la tabla destino SQL Server.</param>
        /// <param name="tipos">Tipos de datos para los campos de la tabla destino SQL Server.</param>
        /// <param name="tabla">Tabla destino de la carga Excel.</param>
        /// <param name="aux">Indice que debe ser actualizado con otro valor.</param>
        /// <param name="sqlAux">Consulta para actualizar el registro.</param>
        /// <returns></returns>
        public bool CargarExcelToDB(RadBrowseEditor searchFile, string sqlExcel, string[] campos, string[] tipos, string tabla, int aux, string sqlAux)
        {
            String filePath = searchFile.Value;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string extension = Path.GetExtension(filePath);
            string conStr, sheetName;
            conStr = string.Empty;
            int contador = campos.Length;

            for(int i=0; i < contador; i++) {
                dt.Columns.Add(campos[i],Type.GetType(tipos[i]));
            }

            try
            {
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = string.Format(excel03ConString, filePath, "YES");
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(excel07ConString, filePath, "YES");
                        break;
                }

                OleDbConnection con = new OleDbConnection(conStr);

                //Get the name of the First Sheet.
                con.Open();
                DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                con.Close();

                // Agrego el nombre de la hoja
                sqlExcel += " From [" + sheetName + "]";

                con.Open();
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlExcel, con);

                
                oda.Fill(ds, "x");
                ds.Tables[0].Columns.Add(campos[0]).SetOrdinal(0);
                dt = ds.Tables[0];
                con.Close();

                if (aux != -1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        conn.Open();
                        dt.Rows[i][aux] = this.DevValorString(sqlAux + dt.Rows[i][aux].ToString() + "%'");
                        conn.Close();
                    }
                }

                conn.Open();
                this.InsertSqlBulkCopy(dt, tabla); //Limpiar data antes de enviar la informacion, SA mayuscula, limpiar espacios
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //Obtiene Embbed Resources y los copia a una carpeta seleccionada        
        public void ExtractEmbeddedResource(string outputDir, string file)
        {

            System.IO.Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Rmc.Resources." + file);

            System.IO.FileStream fileStream = new System.IO.FileStream(outputDir, System.IO.FileMode.Create);
            for (int i = 0; i < stream.Length; i++)
            {
                fileStream.WriteByte((byte)stream.ReadByte());
            }
            fileStream.Close();
        }
        public void ExportarGrid2(RadGridView rgv, String NombreHoja)
        {
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(rgv);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();


            // spreadExporter.SheetName = NombreHoja;

            spreadExporter.HiddenColumnOption = Telerik.WinControls.UI.Export.HiddenOption.DoNotExport;
            spreadExporter.ExportVisualSettings = true;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.Filter = "Excel Files | *.xlsx";
            saveFileDialog1.RestoreDirectory = true;

            spreadExporter.FileExportMode = FileExportMode.CreateOrOverrideFile;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string direccion = saveFileDialog1.FileName;
                    //if (System.IO.File.Exists(direccion))
                    //{
                    //    System.IO.File.Delete(direccion);
                    //}
                    direccion = direccion.Replace(".xlsx", "");
                    direccion = direccion.Replace(".xls", "");



                    spreadExporter.RunExport(" " + direccion + ".xlsx", exportRenderer, NombreHoja);
                    MessageBox.Show("Datos Exportados", "Confirmación");
                    //ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "EXCEL.EXE";
                    //startInfo.Arguments = saveFileDialog1.FileName.ToString() + ".xlsx ";

                    Process.Start("EXCEL.EXE", "\"" + saveFileDialog1.FileName + "\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar los datos, ¿Tiene abierto el archivo a sustituir?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
    }
}
