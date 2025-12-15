using Rmc.Clases;
using Rmc.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Packaging.Reports
{
    public partial class YarmInventoryForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;
        DataTable datosProv = new DataTable();
        BodegaController BControl = new BodegaController();

        private string BODEGA_ID = "2";

        public YarmInventoryForm()
        {
            InitializeComponent();
            rgvDetalle.MultiSelect = true;
            rgvDetalle.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvDetalle.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            //rgvDetalle2.MultiSelect = true;
            //rgvDetalle2.SelectionMode = GridViewSelectionMode.FullRowSelect;
            //rgvDetalle2.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        //private void btnInventario_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        rgvDetalle.BringToFront();
        //        rgvDetalle.Visible = true;
        //        rgvDetalle2.Visible = false;
        //        rgvProveedor.Visible = false;
        //        GRID_VIEW_PACK.Visible = false;

        //        sql = "SELECT "
        //            + "YCITEM AS CODIGO,	"
        //            + "LLDESC AS DESCRIPCION, "
        //            + "SUM(YCQTY) AS CANTIDAD "
        //            + "FROM "
        //            + "	HQ400B.YNLIB.YNLCASE3 YNLCASE3, "
        //            + "	HQ400B.PDLIB.PSL510A PSL510A, "
        //            + "	HQ400B.PDLIB.PTP001 PTP001, "
        //            + "	HQ400B.YNLIB.YNLCSRF1 YNLCSRF1 "
        //            + "WHERE "
        //            + "	YNLCASE3.YCITEM = PSL510A.LITEM	"
        //            + "	AND YNLCASE3.YCLOT = PSL510A.LLOT "
        //            + "	AND PTP001.K0TCOD = YNLCASE3.YCVEND	"
        //            + "	AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS "
        //            + "	AND ( YCPLNT = '6D' "
        //            + "	AND YCBNRO NOT IN( '999999' )	"
        //            + "	AND YCDEPT = '88Y' "
        //            + "	AND YCSTS = '25') "
        //            + "GROUP BY YCITEM, LLDESC ";

        //        sc.OpenConection();
        //        sc.LlenarGrid(rgvDetalle, sql, "x", "x");
        //        sc.CloseConection();

        //        if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false;
        //        if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = false;
        //        if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = false;
        //        if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = false;
        //    }
        //    catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        //}

        private void btnInventario_Click(object sender, EventArgs e)
        {
            string usuarioTTS = "NTTRAIN1QA";
            string pwdTTS = "NTTRAIN1QA";
            string strCnn = "DSN=HBITTSQA;UID=" + usuarioTTS + ";PWD=" + pwdTTS + ";";

            string queryAS = @"
                            SELECT 
                                YCITEM AS CODIGO,
                                LLDESC AS DESCRIPCION,
                                SUM(YCQTY) AS LIBRAS
                            FROM 
                                HQ400B.YNLIB.YNLCASE3 YNLCASE3,  
                                HQ400B.PDLIB.PSL510A PSL510A,  
                                HQ400B.PDLIB.PTP001 PTP001,  
                                HQ400B.YNLIB.YNLCSRF1 YNLCSRF1 
                            WHERE 
                                YNLCASE3.YCITEM = PSL510A.LITEM
                                AND YNLCASE3.YCLOT = PSL510A.LLOT
                                AND PTP001.K0TCOD = YNLCASE3.YCVEND
                                AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS
                                AND (YCPLNT = '6D'
                                AND YCBNRO NOT IN('999999')
                                AND YCDEPT = '88Y'
                                AND YCSTS = '25')
                            GROUP BY YCITEM, LLDESC
                        ";

            using (OdbcConnection con = new OdbcConnection(strCnn))
            {
                try
                {
                    con.Open();
                    OdbcDataAdapter adapter = new OdbcDataAdapter(queryAS, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rgvDetalle.AutoGenerateColumns = true;
                    rgvDetalle.DataSource = dt;
                    rgvDetalle.BringToFront();
                    rgvDetalle.Visible = true;
                    //rgvDetalle2.Visible = false;
                    //rgvProveedor.Visible = false;
                    //GRID_VIEW_PACK.Visible = false;

                    // Configuración de visibilidad de columnas
                    if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = false; //Localidad
                    if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true; //Codigo
                    if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true; //Descripcion
                    if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false; //Paquetes
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = false; //Pack_ID
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true; //Libras
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = false; //Fecha_Ingreso
                    if (rgvDetalle.Columns.Count > 7) rgvDetalle.Columns[7].IsVisible = false; //Lote
                    if (rgvDetalle.Columns.Count > 8) rgvDetalle.Columns[8].IsVisible = false; //Dias
                    if (rgvDetalle.Columns.Count > 9) rgvDetalle.Columns[9].IsVisible = false; //Leyenda
                    if (rgvDetalle.Columns.Count > 10) rgvDetalle.Columns[10].IsVisible = false; //Proveedor
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos TTS o ejecutar la consulta: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void btnInventarioLocalidades_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        rgvDetalle.BringToFront();
        //        rgvDetalle.Visible = true;
        //        rgvDetalle2.Visible = false;
        //        rgvProveedor.Visible = false;
        //        GRID_VIEW_PACK.Visible = false;

        //        sql = "SELECT * FROM (SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
        //            + " COUNT(PL.pac_id) AS PAQUETES, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS "
        //            + " FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id "
        //            + " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = '" + BODEGA_ID + "' "
        //            + " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion "
        //            + " UNION ALL "
        //            + " SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
        //            + " COUNT(D.dev_id) AS PAQUETES, ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS "
        //            + " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id "
        //            + " WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + BODEGA_ID + "' GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion)  AS AUX "
        //            + " WHERE AUX.LIBRAS >0 ORDER BY LOCALIDAD, CODIGO, DESCRIPCION ";

        //        sc.OpenConection();
        //        sc.LlenarGrid(rgvDetalle, sql, "x", "x");
        //        sc.CloseConection();

        //        if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = false;
        //        if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = false;
        //    }
        //    catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        //}

        private void btnInventarioLocalidades_Click(object sender, EventArgs e)
        {
            string usuarioTTS = "NTTRAIN1QA";
            string pwdTTS = "NTTRAIN1QA";
            string strCnn = "DSN=HBITTSQA;UID=" + usuarioTTS + ";PWD=" + pwdTTS + ";";

            string queryAS = @"
                            SELECT 
                            YCDEPT AS LOCALIDAD,
                            YCITEM AS CODIGO,
                            LLDESC AS DESCRIPCION,
                            COUNT(YCCASE) AS PAQUETES,
                            SUM(YCQTY) AS LIBRAS
                            FROM 
	                            HQ400B.YNLIB.YNLCASE3 YNLCASE3,  
	                            HQ400B.PDLIB.PSL510A PSL510A,  
	                            HQ400B.PDLIB.PTP001 PTP001,  
	                            HQ400B.YNLIB.YNLCSRF1 YNLCSRF1 
                            WHERE 
	                            YNLCASE3.YCITEM = PSL510A.LITEM
	                            AND YNLCASE3.YCLOT = PSL510A.LLOT
	                            AND PTP001.K0TCOD = YNLCASE3.YCVEND
	                            AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS
	                            AND ( YCPLNT = '6D'
	                            AND YCBNRO NOT IN( '999999' )
	                            AND YCDEPT = '88Y'
	                            AND YCSTS = '25')
                            GROUP BY YCITEM, LLDESC, YCDEPT
                        ";

            using (OdbcConnection con = new OdbcConnection(strCnn))
            {
                try
                {
                    con.Open();
                    OdbcDataAdapter adapter = new OdbcDataAdapter(queryAS, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rgvDetalle.AutoGenerateColumns = true;
                    rgvDetalle.DataSource = dt;
                    rgvDetalle.BringToFront();
                    rgvDetalle.Visible = true;
                    //rgvDetalle2.Visible = false;
                    //rgvProveedor.Visible = false;
                    //GRID_VIEW_PACK.Visible = false;

                    // Configuración de visibilidad de columnas
                    if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true; //Localidad
                    if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true; //Codigo
                    if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true; //Descripcion
                    if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = true; //Paquetes
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = false; //Pack_ID
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true; //Libras
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = false; //Fecha_Ingreso
                    if (rgvDetalle.Columns.Count > 7) rgvDetalle.Columns[7].IsVisible = false; //Lote
                    if (rgvDetalle.Columns.Count > 8) rgvDetalle.Columns[8].IsVisible = false; //Dias
                    if (rgvDetalle.Columns.Count > 9) rgvDetalle.Columns[9].IsVisible = false; //Leyenda
                    if (rgvDetalle.Columns.Count > 10) rgvDetalle.Columns[10].IsVisible = false; //Proveedor
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos TTS o ejecutar la consulta: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void btnInventarioLocalidadesDetalle_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        rgvDetalle.BringToFront();
        //        rgvDetalle.Visible = true;
        //        rgvDetalle2.Visible = false;
        //        rgvProveedor.Visible = false;
        //        GRID_VIEW_PACK.Visible = false;

        //        sql = "SELECT * FROM (SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,  CONVERT(VARCHAR,PL.pac_id) AS PACKID,"
        //            + " ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS, PL.pac_scan_whin  AS FECHAINGRESO FROM wai_Item I "
        //            + " INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id "
        //            + " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = '" + BODEGA_ID + "' "
        //            + " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, PL.pac_id, PL.pac_scan_whin "
        //            + " UNION ALL "
        //            + " SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,D.dev_codigo AS PACKID, "
        //            + " ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS, D.dev_fecha_in AS FECHAINGRESO "
        //            + " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id "
        //            + " INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + BODEGA_ID + "' "
        //            + " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, D.dev_codigo, D.dev_fecha_in)  AS AUX "
        //            + " WHERE AUX.LIBRAS >0 ORDER BY PACKID ";

        //        sc.OpenConection();
        //        sc.LlenarGrid(rgvDetalle, sql, "x", "x");
        //        sc.CloseConection();

        //        if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false;
        //        if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true;
        //        if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = true;
        //    }
        //    catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        //}

        private void btnInventarioLocalidadesDetalle_Click(object sender, EventArgs e)
        {
            string usuarioTTS = "NTTRAIN1QA";
            string pwdTTS = "NTTRAIN1QA";
            string strCnn = "DSN=HBITTSQA;UID=" + usuarioTTS + ";PWD=" + pwdTTS + ";";

            string queryAS = @"
                            SELECT 
                            YCDEPT AS LOCALIDAD,
                            YCITEM AS CODIGO,
                            LLDESC AS DESCRIPCION,
                            YCCASE AS PACKID,
                            SUM(YCQTY) AS LIBRAS,
                            CASE 
                                WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                    '20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' ||
                                    SUBSTR(DIGITS(YCRECD), 3, 2) || '-' ||
                                    SUBSTR(DIGITS(YCRECD), 5, 2)
                                ELSE NULL
                            END AS FECHAINGRESO
                            FROM 
                                HQ400B.YNLIB.YNLCASE3 YNLCASE3,  
                                HQ400B.PDLIB.PSL510A PSL510A,  
                                HQ400B.PDLIB.PTP001 PTP001,  
                                HQ400B.YNLIB.YNLCSRF1 YNLCSRF1 
                            WHERE 
                                YNLCASE3.YCITEM = PSL510A.LITEM
                                AND YNLCASE3.YCLOT = PSL510A.LLOT
                                AND PTP001.K0TCOD = YNLCASE3.YCVEND
                                AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS
                                AND ( YCPLNT = '6D'
                                AND YCBNRO NOT IN( '999999' )
                                AND YCDEPT = '88Y'
                                AND YCSTS = '25')
	                            AND YCRECD <> 0
                            GROUP BY YCITEM, LLDESC, YCDEPT, YCCASE, YCRECD
                        ";

            using (OdbcConnection con = new OdbcConnection(strCnn))
            {
                try
                {
                    con.Open();
                    OdbcDataAdapter adapter = new OdbcDataAdapter(queryAS, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rgvDetalle.AutoGenerateColumns = true;
                    rgvDetalle.DataSource = dt;
                    rgvDetalle.BringToFront();
                    rgvDetalle.Visible = true;
                    //rgvDetalle2.Visible = false;
                    //rgvProveedor.Visible = false;
                    //GRID_VIEW_PACK.Visible = false;

                    // Configuración de visibilidad de columnas
                    if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true; //Localidad
                    if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true; //Codigo
                    if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true; //Descripcion
                    if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false; //Paquetes
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = true; //Pack_ID
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true; //Libras
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = false; //Fecha_Ingreso
                    if (rgvDetalle.Columns.Count > 7) rgvDetalle.Columns[7].IsVisible = false; //Lote
                    if (rgvDetalle.Columns.Count > 8) rgvDetalle.Columns[8].IsVisible = false; //Dias
                    if (rgvDetalle.Columns.Count > 9) rgvDetalle.Columns[9].IsVisible = false; //Leyenda
                    if (rgvDetalle.Columns.Count > 10) rgvDetalle.Columns[10].IsVisible = false; //Proveedor
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos TTS o ejecutar la consulta: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void btnInventarioAntiguedad_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        rgvDetalle2.Visible = true;
        //        rgvDetalle.Visible = false;
        //        rgvProveedor.Visible = false;
        //        GRID_VIEW_PACK.Visible = false;
        //        sql = "SELECT *, CASE WHEN CATEGORIA = 'D' THEN 'More than 12 Months' ELSE CASE WHEN CATEGORIA = 'C' THEN 'Between 9 and 12 Months' ELSE "
        //            + " CASE WHEN CATEGORIA = 'B' THEN 'Between 6 and 9 Months' ELSE 'Less than 6 Months' END END END AS LEYENDA FROM (SELECT CONVERT(VARCHAR,PL.pac_id) AS PACKID, "
        //            + " I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS, FD.facd_lote AS LOTE, "
        //            + " PL.pac_scan_whin  AS FECHAINGRESO, DATEDIFF(D,PL.pac_scan_whin,GETDATE()) AS DIAS, CASE WHEN DATEDIFF(D,PL.pac_scan_whin,GETDATE()) > 365 THEN 'D' ELSE "
        //            + " CASE WHEN DATEDIFF(D,PL.pac_scan_whin,GETDATE()) > 270 THEN 'C' ELSE CASE WHEN DATEDIFF(D,PL.pac_scan_whin,GETDATE()) > 180 THEN 'B' ELSE 'A' "
        //            + " END END END AS CATEGORIA FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id "
        //            + " INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = '" + BODEGA_ID + "' "
        //            + " AND PL.pac_scan_whin IS NOT NULL GROUP BY I.ite_codigo, I.ite_descripcion, FD.facd_lote, PL.pac_id, PL.pac_scan_whin "
        //            + " UNION ALL "
        //            + " SELECT D.dev_codigo AS PACKID, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
        //            + " ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS, D.dev_lote AS LOTE, D.dev_fecha_in AS FECHAINGRESO, "
        //            + " DATEDIFF(D, D.dev_fecha_in, GETDATE())  AS DIAS, CASE WHEN DATEDIFF(D, D.dev_fecha_in, GETDATE()) > 365 THEN 'D' ELSE "
        //            + " CASE WHEN DATEDIFF(D, D.dev_fecha_in, GETDATE()) > 270 THEN 'C' ELSE CASE WHEN DATEDIFF(D, D.dev_fecha_in, GETDATE()) > 180 THEN 'B' ELSE 'A' "
        //            + " END END END AS CATEGORIA FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id "
        //            + " WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + BODEGA_ID + "' GROUP BY I.ite_codigo, I.ite_descripcion, D.dev_lote, D.dev_codigo, D.dev_fecha_in)  AS AUX "
        //            + " WHERE AUX.LIBRAS >0 ORDER BY DIAS DESC ";
        //        Console.WriteLine(sql);
        //        sc.OpenConection();
        //        sc.LlenarGrid(rgvDetalle2, sql, "x", "x");
        //        sc.CloseConection();
        //    }
        //    catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        //}

        private void btnInventarioAntiguedad_Click(object sender, EventArgs e)
        {
            string usuarioTTS = "NTTRAIN1QA";
            string pwdTTS = "NTTRAIN1QA";
            string strCnn = "DSN=HBITTSQA;UID=" + usuarioTTS + ";PWD=" + pwdTTS + ";";

            string queryAS = @"
                            SELECT
                            YCDEPT AS LOCALIDAD,
                            YCITEM AS CODIGO,
                            LLDESC AS DESCRIPCION,
                            YCCASE AS PACKID,
                            SUM(YCQTY) AS LIBRAS,
                            YXLOT AS LOTE,
                            CASE 
                                WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                    '20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' ||
                                    SUBSTR(DIGITS(YCRECD), 3, 2) || '-' ||
                                    SUBSTR(DIGITS(YCRECD), 5, 2)
                                ELSE NULL
                            END AS FECHAINGRESO,
  
                              CASE 
                                WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                  '20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' ||
                                  SUBSTR(DIGITS(YCRECD), 3, 2) || '-' ||
                                  SUBSTR(DIGITS(YCRECD), 5, 2)
                                ELSE NULL
                              END AS FECHA_CONVERTIDA,

                              -- DÍAS DE DIFERENCIA (usando DAYS función de DB2)
                              CASE 
                                WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                  DAYS(CURRENT DATE) - DAYS(DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                 SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                 SUBSTR(DIGITS(YCRECD), 5, 2)))
                                ELSE NULL
                              END AS DIAS,

                              -- CATEGORIA SEGÚN MESES
                              CASE 
                                WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                  CASE 
                                    WHEN MONTHS_BETWEEN(CURRENT DATE, DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 5, 2))) < 6 THEN 'A'
                                    WHEN MONTHS_BETWEEN(CURRENT DATE, DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 5, 2))) BETWEEN 6 AND 12 THEN 'C'
                                    WHEN MONTHS_BETWEEN(CURRENT DATE, DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 5, 2))) > 12 THEN 'D'
                                    ELSE NULL
                                  END
                                ELSE NULL
                              END AS CATEGORIA,

                              -- LEYENDA EN TEXTO
                              CASE 
                                WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                  CASE 
                                    WHEN MONTHS_BETWEEN(CURRENT DATE, DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 5, 2))) < 6 THEN 'Less than 6 months'
                                    WHEN MONTHS_BETWEEN(CURRENT DATE, DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 5, 2))) BETWEEN 6 AND 12 THEN 'Between 6 and 12 Months'
                                    WHEN MONTHS_BETWEEN(CURRENT DATE, DATE('20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 3, 2) || '-' || 
                                                                            SUBSTR(DIGITS(YCRECD), 5, 2))) > 12 THEN 'More than 12 months'
                                    ELSE NULL
                                  END
                                ELSE NULL
                              END AS LEYENDA

                            FROM HQ400B.YNLIB.YNLCASE3 YNLCASE3,
                                 HQ400B.PDLIB.PSL510A PSL510A,
                                 HQ400B.PDLIB.PTP001 PTP001,
                                 HQ400B.YNLIB.YNLCSRF1 YNLCSRF1
                            WHERE
                              YNLCASE3.YCITEM = PSL510A.LITEM
                              AND YNLCASE3.YCLOT = PSL510A.LLOT
                              AND PTP001.K0TCOD = YNLCASE3.YCVEND
                              AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS
                              AND YCPLNT = '6D'
                              AND YCBNRO NOT IN ('999999')
                              AND YCDEPT = '88Y'
                              AND YCSTS = '25'
                              AND YCRECD <> 0
                            GROUP BY
                              YCCASE, YCITEM, LLDESC, YXLOT, YCRECD,YCDEPT
                        ";

            using (OdbcConnection con = new OdbcConnection(strCnn))
            {
                try
                {
                    con.Open();
                    OdbcDataAdapter adapter = new OdbcDataAdapter(queryAS, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rgvDetalle.AutoGenerateColumns = true;
                    rgvDetalle.DataSource = dt;
                    rgvDetalle.BringToFront();
                    rgvDetalle.Visible = true;
                    //rgvDetalle2.Visible = false;
                    //rgvProveedor.Visible = false;
                    //GRID_VIEW_PACK.Visible = false;

                    // Configuración de visibilidad de columnas
                    if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true; //Localidad
                    if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true; //Codigo
                    if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true; //Descripcion
                    if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false; //Paquetes
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = true; //Pack_ID
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true; //Libras
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = true; //Fecha_Ingreso
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[7].IsVisible = true; //Lote
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[8].IsVisible = true; //Dias
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[9].IsVisible = true; //Leyenda
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos TTS o ejecutar la consulta: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void btnInvProveedor_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        rgvProveedor.BringToFront();
        //        rgvProveedor.Visible = true;
        //        rgvDetalle.Visible = false;
        //        rgvDetalle2.Visible = false;
        //        GRID_VIEW_PACK.Visible = false;

        //        rgvProveedor.DataSource = BControl.ObtenerIventarioProveedor(Convert.ToInt32(BODEGA_ID));
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        private void btnInvProveedor_Click(object sender, EventArgs e)
        {
            string usuarioTTS = "NTTRAIN1QA";
            string pwdTTS = "NTTRAIN1QA";
            string strCnn = "DSN=HBITTSQA;UID=" + usuarioTTS + ";PWD=" + pwdTTS + ";";

            string queryAS = @"
                           SELECT 
                            COUNT(YCCASE) AS PACKID,
                            YCITEM AS CODIGO,
                            LLDESC AS DESCRIPCION,
                            K0LDSC AS PROVEEDOR,
                            SUM(YCQTY) AS LIBRAS
                            FROM 
	                            HQ400B.YNLIB.YNLCASE3 YNLCASE3,  
	                            HQ400B.PDLIB.PSL510A PSL510A,  
	                            HQ400B.PDLIB.PTP001 PTP001,  
	                            HQ400B.YNLIB.YNLCSRF1 YNLCSRF1 
                            WHERE 
	                            YNLCASE3.YCITEM = PSL510A.LITEM
	                            AND YNLCASE3.YCLOT = PSL510A.LLOT
	                            AND PTP001.K0TCOD = YNLCASE3.YCVEND
	                            AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS
	                            AND ( YCPLNT = '6D'
	                            AND YCBNRO NOT IN( '999999' )
	                            AND YCDEPT = '88Y'
	                            AND YCSTS = '25')
                            GROUP BY YCITEM, LLDESC, K0LDSC
                            ";

            using (OdbcConnection con = new OdbcConnection(strCnn))
            {
                try
                {
                    con.Open();
                    OdbcDataAdapter adapter = new OdbcDataAdapter(queryAS, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rgvDetalle.AutoGenerateColumns = true;
                    rgvDetalle.DataSource = dt;
                    rgvDetalle.BringToFront();
                    rgvDetalle.Visible = true;
                    //rgvDetalle2.Visible = false;
                    //rgvProveedor.Visible = false;
                    //GRID_VIEW_PACK.Visible = false;

                    // Configuración de visibilidad de columnas
                    if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = false; //Localidad
                    if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true; //Codigo
                    if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true; //Descripcion
                    if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false; //Paquetes
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = true; //Pack_ID
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true; //Libras
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = false; //Fecha_Ingreso
                    if (rgvDetalle.Columns.Count > 7) rgvDetalle.Columns[7].IsVisible = false; //Lote
                    if (rgvDetalle.Columns.Count > 8) rgvDetalle.Columns[8].IsVisible = false; //Dias
                    if (rgvDetalle.Columns.Count > 9) rgvDetalle.Columns[9].IsVisible = false; //Leyenda
                    if (rgvDetalle.Columns.Count > 10) rgvDetalle.Columns[10].IsVisible = true; //Leyenda
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos TTS o ejecutar la consulta: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void BTN_PACK_PROVEEDOR_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //GRID_VIEW_PACK.BringToFront();
        //        //GRID_VIEW_PACK.Visible = true;
        //        //rgvProveedor.Visible = false;
        //        //rgvDetalle.Visible = false;
        //        //rgvDetalle2.Visible = false;

        //        //GRID_VIEW_PACK.DataSource = BControl.ObtenerPackProveedor(Convert.ToInt32(BODEGA_ID));
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        private void BTN_PACK_PROVEEDOR_Click(object sender, EventArgs e)
        {
            string usuarioTTS = "NTTRAIN1QA";
            string pwdTTS = "NTTRAIN1QA";
            string strCnn = "DSN=HBITTSQA;UID=" + usuarioTTS + ";PWD=" + pwdTTS + ";";

            string queryAS = @"
                           SELECT
                              YCCASE AS PACKID,
                              YCITEM AS CODIGO,
                              LLDESC AS DESCRIPCION,
                              K0LDSC AS PROVEEDOR,
                              SUM(YCQTY) AS LIBRAS,
                              YXLOT AS LOTE,
                              YCDEPT AS LOCALIDAD,
                              CASE 
                                   WHEN DIGITS(YCRECD) IS NOT NULL AND LENGTH(DIGITS(YCRECD)) = 6 THEN
                                       '20' || SUBSTR(DIGITS(YCRECD), 1, 2) || '-' ||
                                       SUBSTR(DIGITS(YCRECD), 3, 2) || '-' ||
                                       SUBSTR(DIGITS(YCRECD), 5, 2)
                                   ELSE NULL
                               END AS FECHAINGRESO
                            FROM HQ400B.YNLIB.YNLCASE3 YNLCASE3,
                                 HQ400B.PDLIB.PSL510A PSL510A,
                                 HQ400B.PDLIB.PTP001 PTP001,
                                 HQ400B.YNLIB.YNLCSRF1 YNLCSRF1
                            WHERE
                              YNLCASE3.YCITEM = PSL510A.LITEM
                              AND YNLCASE3.YCLOT = PSL510A.LLOT
                              AND PTP001.K0TCOD = YNLCASE3.YCVEND
                              AND YNLCASE3.YCCASE = YNLCSRF1.YXHBCS
                              AND (YCPLNT = '6D'
                              AND YCBNRO NOT IN('999999')
                              AND YCDEPT = '88Y'
                              AND YCSTS = '25')
                            GROUP BY
                              YCCASE, YCITEM, LLDESC, K0LDSC, YXLOT, YCDEPT, YCRECD
                            ";

            using (OdbcConnection con = new OdbcConnection(strCnn))
            {
                try
                {
                    con.Open();
                    OdbcDataAdapter adapter = new OdbcDataAdapter(queryAS, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rgvDetalle.AutoGenerateColumns = true;
                    rgvDetalle.DataSource = dt;
                    rgvDetalle.BringToFront();
                    rgvDetalle.Visible = true;
                    //rgvDetalle2.Visible = false;
                    //rgvProveedor.Visible = false;
                    //GRID_VIEW_PACK.Visible = false;

                    // Configuración de visibilidad de columnas
                    if (rgvDetalle.Columns.Count > 0) rgvDetalle.Columns[0].IsVisible = true; //Localidad
                    if (rgvDetalle.Columns.Count > 1) rgvDetalle.Columns[1].IsVisible = true; //Codigo
                    if (rgvDetalle.Columns.Count > 2) rgvDetalle.Columns[2].IsVisible = true; //Descripcion
                    if (rgvDetalle.Columns.Count > 3) rgvDetalle.Columns[3].IsVisible = false; //Paquetes
                    if (rgvDetalle.Columns.Count > 4) rgvDetalle.Columns[4].IsVisible = true; //Pack_ID
                    if (rgvDetalle.Columns.Count > 5) rgvDetalle.Columns[5].IsVisible = true; //Libras
                    if (rgvDetalle.Columns.Count > 6) rgvDetalle.Columns[6].IsVisible = true; //Fecha_Ingreso
                    if (rgvDetalle.Columns.Count > 7) rgvDetalle.Columns[7].IsVisible = true; //Lote
                    if (rgvDetalle.Columns.Count > 8) rgvDetalle.Columns[8].IsVisible = false; //Dias
                    if (rgvDetalle.Columns.Count > 9) rgvDetalle.Columns[9].IsVisible = false; //Leyenda
                    if (rgvDetalle.Columns.Count > 10) rgvDetalle.Columns[10].IsVisible = true; //Proveedor
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos TTS o ejecutar la consulta: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void YarmInventoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
