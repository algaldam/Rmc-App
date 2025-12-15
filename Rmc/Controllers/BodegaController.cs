using Rmc.EntityFramework;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Controllers
{
    class BodegaController
    {
        public List<wai_Bodegas> ObtenerBodegas()
        {
            try
            {

                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var Resultado = db.Database.SqlQuery<wai_Bodegas>("SELECT * FROM wai_Bodegas").ToList();
                    return Resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CrudPrioridades(string Accion, int IdProducto, string Lote, string Semana, int Prioridad)
        {
            try
            {
                int respuesta = 0;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.usp_wai_Prioridades_CRUD(Environment.UserName, Accion, IdProducto, Lote, Semana, Prioridad).FirstOrDefault(); ;
                    if (resultado == "OK")
                    {
                        respuesta = 1;

                    }
                    else
                    {
                        respuesta = 0;
                    }
                }
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // OBTIENE TODOS LOS PRODUCTOS POR BODEGA
        public List<ClaseGenerica> ObtenerTodosProductosBodega(int bodega)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT DISTINCT(ite_id), item AS Codigo FROM(SELECT I.ite_id, CONCAT(I.ite_codigo,' - ',I.ite_descripcion) AS item " +
                                      " FROM wai_Item AS I                                                                                                    " +
                                      " INNER JOIN wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id                                                    " +
                                      " INNER JOIN wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id                                              " +
                                      " WHERE ite_bodega_id =" + bodega + " AND PL.pac_scan_whin IS NOT NULL  AND PL.pac_scan_whout IS NULL                   " +
                                      " GROUP BY ite_id, I.ite_codigo,I.ite_descripcion                                                                       " +
                                      " UNION ALL                                                                                                             " +
                                      " SELECT I.ite_id, CONCAT(I.ite_codigo,' - ',I.ite_descripcion) AS item                                                 " +
                                      " FROM wai_Item I                                                                                                       " +
                                      " INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id                                                             " +
                                      " WHERE (D.dev_libras - ISNULL(D.dev_libras_out,0))>0 AND D.dev_fecha_in IS NOT NULL) AUX                               " +
                                      " ORDER BY item                                                                                                         ";

                    var resultado = db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                    return resultado;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // OBTIENE PRODUCTO EN BODEGA
        public List<wai_Item> ObtenerProducto(int bodega = 0)
        {
            try
            {
                string filtro = "";
                if (bodega == 0)
                {
                    filtro = "";
                }
                else
                {
                    filtro = " WHERE ite_bodega_id = " + bodega;
                }
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT * FROM wai_Item" + filtro;
                    var items = db.Database.SqlQuery<wai_Item>(consulta).ToList<wai_Item>();
                    return items;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<PackProveedor> ObtenerPackProveedor(int bodega)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT AUX.PACKID AS PackID,AUX.CODIGO AS Codigo,AUX.DESCRIPCION AS Descripcion, PRO.pro_nombre AS Proveedor,AUX.LIBRAS AS Libras,AUX.Lote,AUX.LOCALIDAD AS Localidad,  " +
                                      "      FECHAINGRESO AS Fecha                                                                                                                                              " +
                                      "       FROM (SELECT L.loc_nombre AS LOCALIDAD,  CONVERT(VARCHAR,PL.pac_id) AS PACKID, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,PR.pro_id,                " +
                                      "              ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS,FD.facd_lote AS Lote, PL.pac_scan_whin  AS FECHAINGRESO FROM wai_Item I           " +
                                      "              INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id                                                                                            " +
                                      "			     INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id                                                                                      " +
                                      "              INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id                                                                                               " +
                                      "			     INNER JOIN wai_Factura AS FAC ON FD.facd_fac_id = FAC.fac_id                                                                                               " +
                                      "			     INNER JOIN wai_POS AS PO ON FAC.fac_pos_id = PO.pos_id                                                                                                     " +
                                      "				 INNER JOIN wai_Proveedor AS PR ON PO.pos_proveedor_id = PR.pro_id                                                                                          " +
                                      "				 WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = " + bodega + "                                                                 " +
                                      "				 GROUP BY  PL.pac_id,PR.pro_id,FD.facd_lote,L.loc_nombre, I.ite_codigo, I.ite_descripcion,  PL.pac_scan_whin                                                " +
                                      "         UNION ALL                                                                                                                                                       " +
                                      "              SELECT L.loc_nombre AS LOCALIDAD,D.dev_codigo AS PACKID, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,PR.pro_id,                               " +
                                      "              ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS,D.dev_lote AS Lote, D.dev_fecha_in AS FECHAINGRESO                                        " +
                                      "              FROM wai_Item I                                                                                                                                            " +
                                      "			     INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id                                                                                                  " +
                                      "              INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id					                                                                            " +
                                      "			     INNER JOIN wai_Proveedor AS PR ON D.pro_id = PR.pro_id					                                                                                    " +
                                      "				 WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = " + bodega + "                                                                      " +
                                      "              GROUP BY D.dev_codigo,PR.pro_id,D.dev_lote,L.loc_nombre, I.ite_codigo, I.ite_descripcion, D.dev_codigo, D.dev_fecha_in)  AS AUX                            " +
                                      "        INNER JOIN wai_Proveedor PRO ON AUX.pro_id =PRO.pro_id                                                                                                           " +
                                      "	       WHERE AUX.LIBRAS >0 ORDER BY PACKID                                                                                                                              ";
                    var ObtenerPackProveedor = db.Database.SqlQuery<PackProveedor>(consulta).ToList<PackProveedor>();
                    return ObtenerPackProveedor;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<InventarioProveedor> ObtenerIventarioProveedor(int bodega)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT ID, CODIGO, DESCRIPCION, PROVEEDOR, SUM(LIBRAS) AS LIBRAS                                                                                  " +
                                      " FROM     (SELECT ID, PROVEEDOR, CODIGO, DESCRIPCION, LIBRAS                                                                                       " +
                                      "                  FROM      (SELECT pr.pro_id AS ID, pr.pro_nombre AS PROVEEDOR, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,         " +
                                      "                                                       ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS                    " +
                                      "                                     FROM      wai_Item AS I INNER JOIN                                                                            " +
                                      "                                                       wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                          " +
                                      "                                                       wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN                    " +
                                      "                                                       wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN                             " +
                                      "                                                       wai_Factura AS FAC ON FD.facd_fac_id = FAC.fac_id INNER JOIN                                " +
                                      "                                                       wai_POS AS PO ON FAC.fac_pos_id = PO.pos_id INNER JOIN                                      " +
                                      "                                                       wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                      " +
                                      "                                     WHERE   (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) AND I.ite_bodega_id =" + bodega + "                 " +
                                      "                                     GROUP BY pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion                                            " +
                                      "                                     UNION ALL                                                                                                     " +
                                      "                                     SELECT pr.pro_id AS ID, pr.pro_nombre AS PROVEEDOR, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, " +
                                      "                                                       ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS                         " +
                                      "                                     FROM     wai_Item AS I INNER JOIN                                                                             " +
                                      "                                                       wai_Devoluciones AS D ON D.dev_item_id = I.ite_id INNER JOIN                                " +
                                      "                                                       wai_Localidad AS L ON L.loc_id = D.dev_localidad_id INNER JOIN                              " +
                                      "                                                       wai_Proveedor AS PR ON D.pro_id = PR.pro_id                                                 " +
                                      "                                     WHERE  (D.dev_libras > ISNULL(D.dev_libras_out, 0)) AND I.ite_bodega_id =" + bodega + "                       " +
                                      "                                     GROUP BY pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion) AS AUX                                    " +
                                      "                  WHERE   (LIBRAS > 0)) AS PRODUCTO " +
                                      " GROUP BY ID, PROVEEDOR, CODIGO, DESCRIPCION " +
                                      " ORDER BY CODIGO ASC,DESCRIPCION";
                    var ObtenerPackProveedor = db.Database.SqlQuery<InventarioProveedor>(consulta).ToList<InventarioProveedor>();
                    return ObtenerPackProveedor;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<wai_Inventario> ObtenerInventarioBodega(int bodegaID, int TipoInvetario)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "SELECT inv_id,CAST(inv_year AS VARCHAR)+'-'+ CAST(inv_num_periodo AS VARCHAR) AS inv_periodo, " +
                                      " inv_responsable,inv_fecha,inv_activo,inv_usuario_crea,inv_fecha_crea                         " +
                                      "      , inv_usuario_mod,inv_fecha_mod,bod_id,inv_tipo,inv_year,inv_num_periodo                " +
                                      "  FROM wai_Inventario                                                                         " +
                                      "  WHERE inv_tipo =" + TipoInvetario + "  AND bod_id=" + bodegaID;

                    var resultado = db.Database.SqlQuery<wai_Inventario>(Consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<int> ObtenerYears(int bodega)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    String Consultas = " SELECT  YEAR(GETDATE()) AS Anio                   " +
                                       " UNION ALL                                        " +
                                       "SELECT  DISTINCT Inv_year AS Anio                 " +
                                       "FROM wai_Inventario                                " +
                                       " WHERE inv_tipo = 2 AND bod_id=" + bodega + "       " +
                                       "ORDER BY ANIO DESC                                 ";

                    var Resultado = db.Database.SqlQuery<int>(Consultas).ToList();
                    return Resultado;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        public int ObtenerUltimoPeriodo(int bodega, int Anio)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = "Select ISNULL(MAX(inv_num_periodo),0) Periodo  FROM wai_Inventario WHERE inv_tipo = 2  AND bod_id= " + bodega + " AND Inv_year = " + Anio;
                    var resultado = db.Database.SqlQuery<int>(Consulta).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LocalidadEscaneos> ObtenerLocalidadInventario(int IdInventario)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = " SELECT loc_id,loc_nombre,invl_responsable AS Responsable,ISNULL(Total, 0) AS Total,                              " +
                                     "         (CASE WHEN SUM(Total) = SUM(Escaneado) THEN 1 ELSE 0 END) AS Terminado,                                  " +
                                     "        ISNULL(Escaneado ,0) AS Escaneado                                                                         " +
                                     " FROM wai_Localidad L                                                                                             " +
                                     " INNER JOIN wai_Inventario_Localidad IL ON IL.invl_localidad_id = L.loc_id                                        " +
                                     " INNER JOIN                                                                                                       " +
                                     " ( SELECT IL.invl_localidad_id,LES.Total,LES.Escaneado,                                                           " +
                                     "         (CASE WHEN LES.Total=LES.Escaneado THEN 1 ELSE 0 END) AS Terminado                                       " +
                                     "   FROM wai_Inventario_Localidad IL                                                                               " +
                                     "   INNER JOIN (                                                                                                   " +
                                     "         SELECT inve_localidadinventario_id, COUNT(*) AS Total,                                                   " +
                                     "               SUM(CASE WHEN inve_escaneado<>0 THEN 1 ELSE 0 END) AS Escaneado                                    " +
                                     "         FROM wai_Inventario_Escaneos                                                                             " +
                                     "         WHERE inve_localidadinventario_id                                                                        " +
                                     "               IN( SELECT invl_id FROM wai_Inventario_Localidad WHERE invl_inventario_id =" + IdInventario + ")    " +
                                     "         GROUP BY inve_localidadinventario_id ) LES ON IL.invl_id=LES.inve_localidadinventario_id) AS ESC         " +
                                     "   ON IL.invl_localidad_id=ESC.invl_localidad_id                                                                  " +
                                     " WHERE IL.invl_inventario_id =" + IdInventario +
                                     " GROUP BY loc_id,loc_nombre,Total,Escaneado,invl_responsable                                                      " +
                                     " ORDER BY Terminado,L.loc_id ASC                                                                                  ";


                    var resultado = db.Database.SqlQuery<LocalidadEscaneos>(Consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<wai_Localidad> ObtenerLocalidad(Filtro enumFiltro, int opcion)
        {
            try
            {

                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    List<wai_Localidad> Localidades = new List<wai_Localidad>();
                    if ((int)enumFiltro == 1)
                    {
                        Localidades = db.Database.SqlQuery<wai_Localidad>("SELECT * FROM wai_Localidad").ToList();
                    }
                    else if ((int)enumFiltro == 2)
                    {
                        switch (opcion)
                        {
                            case 1:
                                Localidades = db.wai_Localidad.Where(x => !x.loc_nombre.Contains("PNC")).ToList();
                                break;
                            case 2:
                                Localidades = db.wai_Localidad.Where(x => x.loc_nombre.Contains("PNC")).ToList();
                                break;

                            default:
                                break;
                        }
                    }


                    return Localidades;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public enum Filtro
    {
        Todos = 1,
        Especifico = 2
    }
}
