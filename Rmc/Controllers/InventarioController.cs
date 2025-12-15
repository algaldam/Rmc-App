using Rmc.EntityFramework;
using Rmc.EntityFramework.Main;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Controllers
{
    class InventarioController
    {
        public bool ValidarLibrasPackList(string PackID)
        {
            try
            {
                bool respuesta = false;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT pac_libras - ISNULL(pac_libras_salida,0) FROM wai_Pack_List WHERE pac_id = '" + PackID + "'";
                    var resultado = db.Database.SqlQuery<Single>(consulta).FirstOrDefault();

                    if (resultado > 0.0)
                    {
                        respuesta = true;

                    }
                    else
                    {
                        respuesta = false;
                    }
                }
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClaseGenerica> ObtenerLibrasProducto(string codigo)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT CODIGO AS Codigo, DESCRIPCION AS Descripcion, SUM(LIBRAS) AS LIBRAS                                                                                                               " +
                                      " FROM     (SELECT CODIGO, DESCRIPCION, LIBRAS                                                                                                                    " +
                                      "          FROM      (SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS   " +
                                      "                     FROM      dbo.wai_Item AS I INNER JOIN                                                                                                      " +
                                      "                               dbo.wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                                                            " +
                                      "                               dbo.wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN                                                      " +
                                      "                               dbo.wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id                                                                          " +
                                      "                     WHERE   (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) AND (I.ite_codigo ='" + codigo + "')                                                  " +
                                      "                     GROUP BY I.ite_codigo, I.ite_descripcion                                                                                                    " +
                                      "                     UNION ALL                                                                                                                                   " +
                                      "                     SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS        " +
                                      "                     FROM     dbo.wai_Item AS I INNER JOIN                                                                                                       " +
                                      "                              dbo.wai_Devoluciones AS D ON D.dev_item_id = I.ite_id INNER JOIN                                                                   " +
                                      "                              dbo.wai_Localidad AS L ON L.loc_id = D.dev_localidad_id                                                                            " +
                                      "                     WHERE  (D.dev_libras > ISNULL(D.dev_libras_out, 0)) AND (I.ite_codigo = '" + codigo + "')                                                   " +
                                      "                     GROUP BY I.ite_codigo, I.ite_descripcion) AS AUX                                                                                            " +
                                      "          WHERE   (LIBRAS > 0)) AS PRODUCTO                                                                                                                      " +
                                      "  GROUP BY CODIGO, DESCRIPCION";
                    var resultado = db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClaseGenerica> ObtenerLibrasProducto(string codigo, int bodegaId)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string filtro = " AND I.ite_bodega_id = " + bodegaId + " ";

                    string consulta = "SELECT CODIGO AS Codigo, DESCRIPCION AS Descripcion, SUM(LIBRAS) AS LIBRAS " +
                                      "FROM (SELECT CODIGO, DESCRIPCION, LIBRAS FROM ( " +
                                      "SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, " +
                                      "ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS " +
                                      "FROM dbo.wai_Item I " +
                                      "INNER JOIN dbo.wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id " +
                                      "INNER JOIN dbo.wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id " +
                                      "INNER JOIN dbo.wai_Localidad L ON L.loc_id = PL.pac_localidad_id " +
                                      "WHERE (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) AND I.ite_codigo = '" + codigo + "'" +
                                      filtro +
                                      " GROUP BY I.ite_codigo, I.ite_descripcion " +
                                      "UNION ALL " +
                                      "SELECT I.ite_codigo, I.ite_descripcion, " +
                                      "ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS " +
                                      "FROM dbo.wai_Item I " +
                                      "INNER JOIN dbo.wai_Devoluciones D ON D.dev_item_id = I.ite_id " +
                                      "INNER JOIN dbo.wai_Localidad L ON L.loc_id = D.dev_localidad_id " +
                                      "WHERE (D.dev_libras > ISNULL(D.dev_libras_out, 0)) AND I.ite_codigo = '" + codigo + "'" +
                                      filtro +
                                      " GROUP BY I.ite_codigo, I.ite_descripcion ) AS AUX " +
                                      "WHERE LIBRAS > 0) AS PRODUCTO " +
                                      "GROUP BY CODIGO, DESCRIPCION";

                    return db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public double PesoProveedor(string CodigoProducto, int IdProveedor)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT SUM(ISNULL(LIBRAS, 0)) AS LIBRAS                                                                                                                       " +
                                    " FROM     (SELECT CODIGO, DESCRIPCION, LIBRAS                                                                                                                       " +
                                    "           FROM      (SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS     " +
                                    "                      FROM      dbo.wai_Item AS I INNER JOIN                                                                                                        " +
                                    "                                dbo.wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                                                              " +
                                    "                                dbo.wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN                                                        " +
                                    "                                dbo.wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN                                                                 " +
                                    "                                dbo.wai_Factura AS FAC ON FD.facd_fac_id = FAC.fac_id INNER JOIN                                                                    " +
                                    "                                dbo.wai_POS AS PO ON FAC.fac_pos_id = PO.pos_id INNER JOIN                                                                          " +
                                    "                                dbo.wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                                                          " +
                                    "                      WHERE   (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) AND (I.ite_codigo = '" + CodigoProducto + "') AND (pr.pro_id =" + IdProveedor + ")    " +
                                    "                      GROUP BY I.ite_codigo, I.ite_descripcion                                                                                                      " +
                                    "                      UNION ALL                                                                                                                                     " +
                                    "                      SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS          " +
                                    "                      FROM     dbo.wai_Item AS I INNER JOIN                                                                                                         " +
                                    "                               dbo.wai_Devoluciones AS D ON D.dev_item_id = I.ite_id INNER JOIN                                                                     " +
                                    "                               dbo.wai_Localidad AS L ON L.loc_id = D.dev_localidad_id INNER JOIN                                                                   " +
                                    "                               dbo.wai_Factura_Detalle AS fad ON I.ite_id = fad.facd_item_id INNER JOIN                                                             " +
                                    "                               dbo.wai_Factura AS fa ON fad.facd_fac_id = fa.fac_id INNER JOIN                                                                      " +
                                    "                               dbo.wai_POS AS PO ON fa.fac_pos_id = PO.pos_id INNER JOIN                                                                            " +
                                    "                               dbo.wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                                                           " +
                                    "                      WHERE  (D.dev_libras > ISNULL(D.dev_libras_out, 0)) AND (I.ite_codigo = '" + CodigoProducto + "') AND (pr.pro_id =" + IdProveedor + ")        " +
                                    "                      GROUP BY I.ite_codigo, I.ite_descripcion) AS AUX                                                                                              " +
                                    "           WHERE   (LIBRAS > 0)) AS PRODUCTO                                                                                                                        " +
                                    " GROUP BY CODIGO, DESCRIPCION";

                    var resultado = db.Database.SqlQuery<double>(consulta).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public double PesoProveedor(string codigoProducto, int idProveedor, int bodegaId)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string filtroBodega = " AND I.ite_bodega_id = " + bodegaId + " ";

                    string consulta = " SELECT SUM(ISNULL(LIBRAS, 0)) AS LIBRAS " +
                                      " FROM (SELECT CODIGO, DESCRIPCION, LIBRAS FROM ( " +
                                      // Pack List
                                      " SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, " +
                                      " ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS " +
                                      " FROM dbo.wai_Item AS I " +
                                      " INNER JOIN dbo.wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id " +
                                      " INNER JOIN dbo.wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id " +
                                      " INNER JOIN dbo.wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id " +
                                      " INNER JOIN dbo.wai_Factura AS FAC ON FD.facd_fac_id = FAC.fac_id " +
                                      " INNER JOIN dbo.wai_POS AS PO ON FAC.fac_pos_id = PO.pos_id " +
                                      " INNER JOIN dbo.wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id " +
                                      " WHERE (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) " +
                                      " AND I.ite_codigo = '" + codigoProducto + "' " +
                                      " AND pr.pro_id = " + idProveedor + filtroBodega +
                                      " GROUP BY I.ite_codigo, I.ite_descripcion " +

                                      " UNION ALL " +
                                      // Devoluciones
                                      " SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, " +
                                      " ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS " +
                                      " FROM dbo.wai_Item AS I " +
                                      " INNER JOIN dbo.wai_Devoluciones AS D ON D.dev_item_id = I.ite_id " +
                                      " INNER JOIN dbo.wai_Localidad AS L ON L.loc_id = D.dev_localidad_id " +
                                      " INNER JOIN dbo.wai_Factura_Detalle AS fad ON I.ite_id = fad.facd_item_id " +
                                      " INNER JOIN dbo.wai_Factura AS fa ON fad.facd_fac_id = fa.fac_id " +
                                      " INNER JOIN dbo.wai_POS AS PO ON fa.fac_pos_id = PO.pos_id " +
                                      " INNER JOIN dbo.wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id " +
                                      " WHERE (D.dev_libras > ISNULL(D.dev_libras_out, 0)) " +
                                      " AND I.ite_codigo = '" + codigoProducto + "' " +
                                      " AND pr.pro_id = " + idProveedor + filtroBodega +
                                      " GROUP BY I.ite_codigo, I.ite_descripcion ) AS AUX " +
                                      " WHERE LIBRAS > 0 ) AS PRODUCTO " +
                                      " GROUP BY CODIGO, DESCRIPCION";

                    var resultado = db.Database.SqlQuery<double>(consulta).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int ObtenerCantidadProducto(int IdProducto)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT COUNT(*) FROM wai_Pack_List PL INNER JOIN wai_Factura_Detalle FD ON FD.facd_id = PL.pac_factura_detalle_id " +
                                      " WHERE FD.facd_item_id=" + IdProducto + " AND                                                                      " +
                                      "       FD.facd_prioridad=1 AND (PL.pac_libras - ISNULL(PL.pac_libras_salida,0)) > 0                                " +
                                      "       AND PL.pac_scan_whin IS NOT NULL                                                                            ";

                    var resultado = db.Database.SqlQuery<int>(consulta).First();
                    return resultado;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Proveedor> ObtenerProveedor()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT pro_id, pro_nombre FROM wai_Proveedor";
                    var proveedores = db.Database.SqlQuery<Proveedor>(consulta).ToList<Proveedor>();
                    return proveedores;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PackListSalida> ObtenerPackListSalida(OpcionPackList Opcion, int IdProducto, int IdProveedor = 0)
        {
            try
            {

                string consulta = "";
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    if ((int)Opcion == 1)
                    {
                        consulta = "SELECT CONVERT(VARCHAR,PL.pac_id) AS PackId, FD.facd_lote AS Lote, FD.facd_prioridad AS Prioridad,         " +
                                    "       ROUND((ISNULL((PL.pac_libras - ISNULL(PL.pac_libras_salida,0)), 0)),2) AS Peso,                    " +
                                    "       L.loc_nombre AS Localidad, CONVERT(VARCHAR(25),PL.pac_fecha_produccion,103) AS FechaProduccion,    " +
                                    "	   CONVERT(VARCHAR(25),PL.pac_scan_whin,(103)) AS FechaEntrada, PO.pos_semana AS Semana                " +
                                    " FROM wai_Item AS I                                                                                       " +
                                    " INNER JOIN wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id                                       " +
                                    " INNER JOIN wai_Factura AS F ON F.fac_id = FD.facd_fac_id                                                 " +
                                    " INNER JOIN wai_POS AS PO ON PO.pos_id = F.fac_pos_id                                                     " +
                                    " INNER JOIN wai_Pack_List AS PL ON PL.pac_factura_detalle_id=FD.facd_id                                   " +
                                    " INNER JOIN wai_Localidad AS L ON L.loc_id=PL.pac_localidad_id                                            " +
                                    " WHERE I.ite_id=" + IdProducto + " AND                                                                    " +
                                    "      (PL.pac_No_Conformidad=0 OR PL.pac_No_Conformidad IS NULL) AND                                      " +
                                    "	   PL.pac_scan_whin IS NOT NULL AND PL.pac_scan_whout IS NULL AND                                      " +
                                    "	   ISNULL((PL.pac_libras - ISNULL(PL.pac_libras_salida,0)), 0) > 0                                     " +
                                    " ORDER BY Prioridad, PackId                                                                               ";
                    }
                    else if ((int)Opcion == 2)
                    {


                        consulta = "SELECT '1' AS Contador,D.dev_codigo AS PackId, L.loc_nombre AS Localidad, D.dev_lote AS Lote,                 " +
                                   "       D.dev_prioridad AS Prioridad, ROUND((D.dev_libras - ISNULL(D.dev_libras_out,0)),2) AS Peso,            " +
                                   "	   '' AS FechaProduccion,CONVERT(VARCHAR(25), D.dev_fecha_in,103) AS FechaEntrada, '' AS Semana           " +
                                   " FROM wai_Item AS I                                                                                           " +
                                   " INNER JOIN wai_Devoluciones AS D ON D.dev_item_id = I.ite_id                                                 " +
                                   " INNER JOIN wai_Localidad AS L ON L.loc_id = D.dev_localidad_id                                               " +
                                   " LEFT JOIN wai_Transacciones_Devoluciones AS TD ON TD.tra_dev_dev_id = D.dev_id                               " +
                                   " WHERE I.ite_id=" + IdProducto + "  AND                                                                       " +
                                   "      (D.dev_No_Conformidad=0 OR D.dev_No_Conformidad IS NULL) AND D.dev_fecha_out IS NULL                    " +
                                   " GROUP BY D.dev_codigo, L.loc_nombre, D.dev_lote, D.dev_prioridad,                                            " +
                                   "          D.dev_libras, D.dev_libras_out, D.dev_fecha_in                                                      " +
                                   " HAVING (D.dev_libras > SUM(ISNULL(tra_dev_libras,0)))                                                        " +
                                   "                                                                                                              " +
                                   " UNION ALL                                                                                                    " +
                                   " SELECT '2' AS Contador, CONVERT(VARCHAR, PL.pac_id) AS PackId,L.loc_nombre AS Localidad,                     " +
                                   "  FD.facd_lote AS Lote, FD.facd_prioridad AS Prioridad,                                                       " +
                                   "         ROUND(ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0), 2) AS Peso,                        " +
                                   "          CONVERT(VARCHAR(25), PL.pac_fecha_produccion, 103) AS FechaProduccion,                              " +
                                   "         CONVERT(VARCHAR(25), PL.pac_scan_whin, 103) AS FechaEntrada, PO.pos_semana AS Semana                 " +
                                   "  FROM     dbo.wai_Item AS I INNER JOIN                                                                       " +
                                   "                   dbo.wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                     " +
                                   "                   dbo.wai_Factura AS F ON F.fac_id = FD.facd_fac_id INNER JOIN                               " +
                                   "                   dbo.wai_POS AS PO ON PO.pos_id = F.fac_pos_id INNER JOIN                                   " +
                                   "                   dbo.wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN               " +
                                   "                   dbo.wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN                        " +
                                   "                   dbo.wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                 " +
                                   " WHERE(I.ite_id = " + IdProducto + ") AND(PL.pac_No_Conformidad = 0 OR PL.pac_No_Conformidad IS NULL) AND     " +
                                   "     (PL.pac_scan_whin IS NOT NULL) AND(PL.pac_scan_whout IS NULL) AND                                        " +
                                   "    (ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0) > 0)                                          " +
                                   "                                                                                    ";

                    }
                    else if ((int)Opcion == 3)
                    {

                        consulta = " SELECT  CONVERT(VARCHAR,PL.pac_id) AS PackId, FD.facd_lote AS Lote, FD.facd_prioridad AS Prioridad,         " +
                                  "        ROUND(ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0), 2) AS Peso,                        " +
                                  " 	   L.loc_nombre AS Localidad, CONVERT(VARCHAR(25),PL.pac_fecha_produccion, 103) AS FechaProduccion,     " +
                                  " 	   CONVERT(VARCHAR(25), PL.pac_scan_whin, 103) AS FechaEntrada, PO.pos_semana AS Semana                 " +
                                  " FROM  wai_Item AS I INNER JOIN                                                                              " +
                                  "       wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                                    " +
                                  "       wai_Factura AS F ON F.fac_id = FD.facd_fac_id INNER JOIN                                              " +
                                  "       wai_POS AS PO ON PO.pos_id = F.fac_pos_id INNER JOIN                                                  " +
                                  "       wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN                              " +
                                  "       wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN                                       " +
                                  "       wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                                " +
                                  " WHERE  (I.ite_id =" + IdProducto + ") AND (pr.pro_id = " + IdProveedor + ") AND                             " +
                                  "        (PL.pac_No_Conformidad = 0 OR PL.pac_No_Conformidad IS NULL) AND (PL.pac_scan_whin IS NOT NULL) AND  " +
                                  " 		(PL.pac_scan_whout IS NULL) AND (ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0) > 0)    " +
                                  " ORDER BY Prioridad, PackId                                                                                  ";

                    }
                    else if ((int)Opcion == 4)
                    {
                        consulta = "SELECT '1' AS Contador, D.dev_codigo AS PackId, D.dev_lote AS Lote, D.dev_prioridad AS Prioridad,           " +
                                  "       ROUND(D.dev_libras - ISNULL(D.dev_libras_out, 0), 2) AS Peso,                                         " +
                                  "	   L.loc_nombre AS Localidad, '' AS FechaProduccion,                                                        " +
                                  "	   CONVERT(VARCHAR(25), D.dev_fecha_in, 103) AS FechaEntrada, '' AS Semana                                  " +
                                  "FROM   wai_Item AS I INNER JOIN                                                                              " +
                                  "       wai_Devoluciones AS D ON D.dev_item_id = I.ite_id INNER JOIN                                          " +
                                  "       wai_Localidad AS L ON L.loc_id = D.dev_localidad_id INNER JOIN                                        " +
                                  "       wai_Proveedor AS pr ON D.pro_id = pr.pro_id LEFT OUTER JOIN                                           " +
                                  "       wai_Transacciones_Devoluciones AS TD ON TD.tra_dev_dev_id = D.dev_id                                  " +
                                  "WHERE (I.ite_id =" + IdProducto + ") AND (pr.pro_id =" + IdProveedor + ") AND                                " +
                                  "      (D.dev_No_Conformidad = 0 OR  D.dev_No_Conformidad IS NULL) AND (D.dev_fecha_out IS NULL)              " +
                                  "GROUP BY D.dev_codigo, D.dev_lote, D.dev_prioridad, D.dev_libras, L.loc_nombre, D.dev_libras_out,            " +
                                  "      D.dev_fecha_in, pr.pro_nombre                                                                          " +
                                  "HAVING        (D.dev_libras > SUM(ISNULL(TD.tra_dev_libras, 0)))                                             " +

                                  "UNION ALL                                                                                                    " +
                                  " SELECT '2' AS Contador, CONVERT(VARCHAR,PL.pac_id) AS PackId, FD.facd_lote AS Lote," +
                                  "        FD.facd_prioridad AS Prioridad,                                                                      " +
                                  "        ROUND(ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0), 2) AS Peso,                        " +
                                  " 	   L.loc_nombre AS Localidad, CONVERT(VARCHAR(25),PL.pac_fecha_produccion, 103) AS FechaProduccion,     " +
                                  " 	   CONVERT(VARCHAR(25), PL.pac_scan_whin, 103) AS FechaEntrada, PO.pos_semana AS Semana                 " +
                                  " FROM  wai_Item AS I INNER JOIN                                                                              " +
                                  "       wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                                    " +
                                  "       wai_Factura AS F ON F.fac_id = FD.facd_fac_id INNER JOIN                                              " +
                                  "       wai_POS AS PO ON PO.pos_id = F.fac_pos_id INNER JOIN                                                  " +
                                  "       wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN                              " +
                                  "       wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN                                       " +
                                  "       wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                                " +
                                  " WHERE  (I.ite_id =" + IdProducto + ") AND (pr.pro_id = " + IdProveedor + ") AND                             " +
                                  "        (PL.pac_No_Conformidad = 0 OR PL.pac_No_Conformidad IS NULL) AND (PL.pac_scan_whin IS NOT NULL) AND  " +
                                  " 		(PL.pac_scan_whout IS NULL) AND (ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0) > 0)    ";
                    }
                    else if ((int)Opcion == 5)
                    {
                        consulta = "SELECT '1' AS Contador,D.dev_codigo AS PackId, L.loc_nombre AS Localidad, D.dev_lote AS Lote,                 " +
                                   "       D.dev_prioridad AS Prioridad, ROUND((D.dev_libras - ISNULL(D.dev_libras_out,0)),2) AS Peso,            " +
                                   "	   '' AS FechaProduccion,CONVERT(VARCHAR(25), D.dev_fecha_in,103) AS FechaEntrada, '' AS Semana           " +
                                   " FROM wai_Item AS I                                                                                           " +
                                   " INNER JOIN wai_Devoluciones AS D ON D.dev_item_id = I.ite_id                                                 " +
                                   " INNER JOIN wai_Localidad AS L ON L.loc_id = D.dev_localidad_id                                               " +
                                   " LEFT JOIN wai_Transacciones_Devoluciones AS TD ON TD.tra_dev_dev_id = D.dev_id                               " +
                                   " WHERE I.ite_id=" + IdProducto + "  AND                                                                       " +
                                   "      (D.dev_No_Conformidad=0 OR D.dev_No_Conformidad IS NULL) AND D.dev_fecha_out IS NULL                    " +
                                   " GROUP BY D.dev_codigo, L.loc_nombre, D.dev_lote, D.dev_prioridad,                                            " +
                                   "          D.dev_libras, D.dev_libras_out, D.dev_fecha_in                                                      " +
                                   " HAVING (D.dev_libras > SUM(ISNULL(tra_dev_libras,0)))                                                        " +
                                   " ORDER BY Prioridad, PackId                                                                                   ";
                    }
                    var Resultado = db.Database.SqlQuery<PackListSalida>(consulta).ToList();
                    return Resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClaseGenerica> ObtenerInventarioLocalidad(int opcion, int BodegaId)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "";
                    if (opcion == 1)
                    {
                        Consulta = " SELECT * FROM(SELECT  L.loc_id AS ID,L.loc_nombre AS Localidad, I.ite_codigo AS Codigo, I.ite_descripcion AS ite_descripcion,                          " +
                                   " COUNT(PL.pac_id) AS Paquetes, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS                                                 " +
                                   " FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id  " +
                                   " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = " + BodegaId +
                                   " GROUP BY  L.loc_id,L.loc_nombre, I.ite_codigo, I.ite_descripcion                                                                                       " +
                                   " UNION ALL                                                                                                                                              " +
                                   " SELECT  L.loc_id AS ID,L.loc_nombre AS Localidad, I.ite_codigo AS Codigo, I.ite_descripcion AS ite_descripcion,                                         " +
                                   " COUNT(D.dev_id) AS Paquetes, ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS                                                          " +
                                   " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id                  " +
                                   " WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id =" + BodegaId +
                                   " GROUP BY  L.loc_id,L.loc_nombre, I.ite_codigo, I.ite_descripcion)  AS AUX                                                                              " +
                                   " WHERE AUX.LIBRAS >0 ORDER BY Localidad, Codigo, ite_descripcion                                                                                        ";
                    }
                    else if (opcion == 2)
                    {

                        Consulta = " SELECT * FROM(SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, CONVERT(VARCHAR, PL.pac_id) AS PACKID,      " +
                                   " ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS, PL.pac_scan_whin  AS FECHAINGRESO FROM wai_Item I                           " +
                                   " INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id                 " +
                                   " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = " + BodegaId +
                                   " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, PL.pac_id, PL.pac_scan_whin                                                                   " +
                                   " UNION ALL                                                                                                                                             " +
                                   " SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,D.dev_codigo AS PACKID,                                    " +
                                   " ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS, D.dev_fecha_in AS FECHAINGRESO                                                      " +
                                   " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id                                                                             " +
                                   " INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id =" + BodegaId +
                                   " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, D.dev_codigo, D.dev_fecha_in)  AS AUX                                                         " +
                                   " WHERE AUX.LIBRAS >0 ORDER BY PACKID                                                                                                                   ";
                    }

                    var resultado = db.Database.SqlQuery<ClaseGenerica>(Consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClaseGenerica> ObtenerEscaneos(int Inventario)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "  SELECT IE.inve_packid AS PackID, CONVERT(float,IE.inve_libras) AS LIBRAS,IL.invl_localidad_id AS ID,              " +
                                     "  CONVERT(BIT,IE.inve_escaneado) AS Escaneado, IE.inve_nuevo AS Nuevo,IE.inve_eliminado AS Eliminado                 " +
                                     " FROM wai_Inventario_Escaneos IE                                                                                     " +
                                     " INNER JOIN wai_Inventario_Localidad IL ON IL.invl_id=IE.inve_localidadinventario_id                                 " +
                                     " WHERE IL.invl_inventario_id=" + Inventario; //+ " AND IL.invl_localidad_id=" + Localidad;

                    var resultado = db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Transacciones(string usuario, int Accion, string PackID, float Libras, int IdProducto, int Autorizacion)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.usp_wai_Transacciones_CRUD(usuario, Accion, PackID, Libras, IdProducto, Autorizacion).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string TransaccionesBod(string usuario, int Accion, string PackID, float Libras, int IdProducto, int Autorizacion)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.usp_wai_TransaccionesProv_CRUD(usuario, Accion, PackID, Libras, IdProducto, Autorizacion).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CrudInventarioPeriodos(int opcion, wai_Inventario ObjInventario)
        {
            try
            {
                var Fecha = ConsultasSql.ObtenerFechaServer();
                int resultado = 0;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    using (var Transaccion = db.Database.BeginTransaction())
                    {
                        try
                        {
                            if (opcion == 1)
                            {
                                ObjInventario.inv_fecha = Fecha;
                                ObjInventario.inv_fecha_crea = Fecha;
                                db.wai_Inventario.Add(ObjInventario);
                                db.SaveChanges();
                            }
                            else if (opcion == 2)
                            {
                                var ObjActualizar = db.wai_Inventario.Where(x => x.inv_id == ObjInventario.inv_id).FirstOrDefault();
                                ObjActualizar.inv_activo = ObjInventario.inv_activo;
                                ObjActualizar.inv_fecha_mod = Fecha;
                                ObjActualizar.inv_usuario_mod = Environment.UserName;
                                db.SaveChanges();
                            }
                            else if (opcion == 3)
                            {
                                //var escaneo = db.wai_Inventario_Escaneos.Where(x=>x.)
                                var noOfRowDeleted = db.Database.ExecuteSqlCommand(" DELETE from wai_Inventario_Escaneos                                              " +
                                                                                    " WHERE inve_localidadinventario_id IN(SELECT invl_id FROM wai_Inventario_Localidad" +
                                                                                    " WHERE invl_inventario_id =" + ObjInventario.inv_id + " )                          " +
                                                                                    " DELETE FROM wai_Inventario_Localidad                                             " +
                                                                                    " WHERE invl_inventario_id =" + ObjInventario.inv_id);
                                var ObjEliminar = db.wai_Inventario.Where(x => x.inv_id == ObjInventario.inv_id).FirstOrDefault();
                                db.wai_Inventario.Remove(ObjEliminar);
                                db.SaveChanges();
                            }
                            Transaccion.Commit();
                            resultado = 1;
                        }
                        catch (Exception)
                        {
                            Transaccion.Rollback();
                            throw;
                        }
                    }
                }
                return resultado;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ContarLocalidadesInventario(int IdInventario)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.Database.SqlQuery<int>("SELECT COUNT(*)  AS TOTAL FROM wai_Inventario_Localidad where invl_inventario_id =" + IdInventario).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CrudInventarioLocalidad(int opcion, int Idinventario, int IdLocalidad, string responsable = "")
        {
            try
            {
                string resultado = "";
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    if (opcion == 1)
                    {
                        resultado = db.usp_wai_Inventario_Localidad(Environment.UserName, "C", Idinventario, IdLocalidad).First();
                    }
                    else if (opcion == 2)
                    {
                        var LocUpdate = db.wai_Inventario_Localidad.Where(x => x.invl_localidad_id == IdLocalidad && x.invl_inventario_id == Idinventario).FirstOrDefault();

                        LocUpdate.invl_fecha_mod = DateTime.Now;
                        LocUpdate.invl_responsable = responsable;
                        LocUpdate.invl_usuario_mod = Environment.UserName;
                        db.SaveChanges();
                        resultado = "OK";
                    }
                }
                return resultado == "OK" ? 1 : 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ProcesarEscaneos(string PackID, int Inventario, int localidad, int estado)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.usp_wai_Inventario_Escaneos(Environment.UserName, PackID, Inventario, localidad, estado).First();

                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //METODO QUE OBTIENE  TODO EL INVENTARIO ESCANEADO 
        public List<ClaseGenerica> ObtenerEscaneadosReporte(int Inventario)
        {
            try
            {

                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "EXEC usp_wai_Consulta_Escaneos " + Inventario + ",'ESCANEADO'";


                    var resultado = db.Database.SqlQuery<fn_wai_Reporte_Toma_Inventario>(Consulta).ToList();

                    // AGRUPAMIENTO SEGUN CODIGO CON SU RESPECTIVA SUMATORIA
                    var Lista = resultado.GroupBy(x => new { Codigo = x.CODIGO, Descripcion = x.DESCRIPCION })
                                        .Select(group => new ClaseGenerica
                                        {
                                            Codigo = group.Key.Codigo,
                                            Descripcion = group.Key.Descripcion,
                                            LIBRAS = Math.Round((double)group.Sum(x => x.LIBRAS), 2)
                                        }).OrderBy(x => x.Codigo).ToList();
                    return resultado.Count > 0 ? Lista : new List<ClaseGenerica>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<fn_wai_Reporte_Toma_Inventario> ObtenerInventarioEscaneo(int Inventario, string Estado)
        {
            try
            {
                string filtro = "";
                if (Estado == "E")
                {
                    filtro = "'ESCANEADO'";
                }
                else if (Estado == "S")
                {
                    filtro = "'SIN ESCANEAR'";
                }
                else
                {
                    filtro = "'ESCAN'";
                }
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "EXEC usp_wai_Consulta_Escaneos " + Inventario + "," + filtro;
                    var resultado = db.Database.SqlQuery<fn_wai_Reporte_Toma_Inventario>(Consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public enum OpcionPackList
    {
        Normal = 1,
        ConDevolucion = 2,
        ProveedorNormal = 3,
        ProveedorConDevolucion = 4,
        SoloDevolucion = 5
    }

    public class Escaneos
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
