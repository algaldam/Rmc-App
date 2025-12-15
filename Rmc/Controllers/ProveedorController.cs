using Rmc.EntityFramework;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Controllers
{
    class ProveedorController
    {
        public List<wai_Proveedor> ObtenerProveedores()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    return db.Database.SqlQuery<wai_Proveedor>("SELECT * FROM wai_Proveedor").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ClaseGenerica> ObtenerProveedorPorProducto(string Codigo)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT ID  , PROVEEDOR AS Proveedor                                                                                                      " +
                                      "FROM     (SELECT ID, PROVEEDOR, CODIGO, DESCRIPCION, LIBRAS                                                                              " +
                                      "                 FROM      (SELECT pr.pro_id AS ID, pr.pro_nombre AS PROVEEDOR, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION," +
                                      "                                   ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS                              " +
                                      "                            FROM      dbo.wai_Item AS I INNER JOIN                                                                       " +
                                      "                                      dbo.wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN                             " +
                                      "                                      dbo.wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN                       " +
                                      "                                      dbo.wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN                                " +
                                      "                                      dbo.wai_Factura AS FAC ON FD.facd_fac_id = FAC.fac_id INNER JOIN                                   " +
                                      "                                      dbo.wai_POS AS PO ON FAC.fac_pos_id = PO.pos_id INNER JOIN                                         " +
                                      "                                      dbo.wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id                                         " +
                                      "                            WHERE   (PL.pac_No_Conformidad=0 OR PL.pac_No_Conformidad IS NULL) AND                                       " +
                                      "                                    PL.pac_scan_whin IS NOT NULL AND PL.pac_scan_whout IS NULL AND                                       " +
                                      "                                    (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) AND (I.ite_codigo ='" + Codigo + "')                   " +
                                      "                            GROUP BY pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion                                           " +
                                      "                            UNION ALL                                                                                                    " +
                                      "                            SELECT pr.pro_id AS ID, pr.pro_nombre AS PROVEEDOR, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION," +
                                      "                                    ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS                                  " +
                                      "                            FROM     dbo.wai_Item AS I INNER JOIN                                                                        " +
                                      "                                     dbo.wai_Devoluciones AS D ON D.dev_item_id = I.ite_id INNER JOIN                                    " +
                                      "                                     dbo.wai_Localidad AS L ON L.loc_id = D.dev_localidad_id INNER JOIN                                  " +
                                      "                                     dbo.wai_Proveedor AS pr ON D.pro_id = pr.pro_id                                                     " +
                                      "                            WHERE  (D.dev_No_Conformidad=0 OR D.dev_No_Conformidad IS NULL)  AND                                         " +
                                      "                                   (D.dev_libras > ISNULL(D.dev_libras_out, 0)) AND (I.ite_codigo = '" + Codigo + "')                    " +
                                      "                            GROUP BY pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion) AS AUX                                   " +
                                      "                 WHERE   (LIBRAS > 0)) AS PRODUCTO                                                                                       " +
                                      " GROUP BY ID, PROVEEDOR, CODIGO, DESCRIPCION";
                    var resultado = db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClaseGenerica> ObtenerProveedorPorProducto(string codigo, int bodegaId)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    // Usar parámetros SQL para evitar inyección
                    var codigoParam = new SqlParameter("@codigo", codigo);
                    var bodegaParam = new SqlParameter("@bodegaId", bodegaId);

                    string consulta = @"SELECT ID, PROVEEDOR AS Proveedor 
                              FROM (
                                  SELECT ID, PROVEEDOR, ite_codigo AS CODIGO, ite_descripcion AS DESCRIPCION, LIBRAS 
                                  FROM (
                                      SELECT pr.pro_id AS ID, pr.pro_nombre AS PROVEEDOR, I.ite_codigo, I.ite_descripcion, 
                                      ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS 
                                      FROM dbo.wai_Item I 
                                      INNER JOIN dbo.wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id 
                                      INNER JOIN dbo.wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id 
                                      INNER JOIN dbo.wai_Localidad L ON L.loc_id = PL.pac_localidad_id 
                                      INNER JOIN dbo.wai_Factura FAC ON FD.facd_fac_id = FAC.fac_id 
                                      INNER JOIN dbo.wai_POS PO ON FAC.fac_pos_id = PO.pos_id 
                                      INNER JOIN dbo.wai_Proveedor pr ON PO.pos_proveedor_id = pr.pro_id 
                                      WHERE (PL.pac_No_Conformidad=0 OR PL.pac_No_Conformidad IS NULL) 
                                      AND PL.pac_scan_whin IS NOT NULL AND PL.pac_scan_whout IS NULL 
                                      AND (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0)) 
                                      AND I.ite_codigo = @codigo
                                      AND I.ite_bodega_id = @bodegaId
                                      GROUP BY pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion 
                                      
                                      UNION ALL 
                                      
                                      SELECT pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion, 
                                      ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2) AS LIBRAS 
                                      FROM dbo.wai_Item I 
                                      INNER JOIN dbo.wai_Devoluciones D ON D.dev_item_id = I.ite_id 
                                      INNER JOIN dbo.wai_Localidad L ON L.loc_id = D.dev_localidad_id 
                                      INNER JOIN dbo.wai_Proveedor pr ON D.pro_id = pr.pro_id 
                                      WHERE (D.dev_No_Conformidad=0 OR D.dev_No_Conformidad IS NULL) 
                                      AND (D.dev_libras > ISNULL(D.dev_libras_out, 0)) 
                                      AND I.ite_codigo = @codigo
                                      AND I.ite_bodega_id = @bodegaId
                                      GROUP BY pr.pro_id, pr.pro_nombre, I.ite_codigo, I.ite_descripcion 
                                  ) AS AUX 
                                  WHERE LIBRAS > 0
                              ) AS PRODUCTO 
                              GROUP BY ID, PROVEEDOR, CODIGO, DESCRIPCION";

                    return db.Database.SqlQuery<ClaseGenerica>(consulta, codigoParam, bodegaParam).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener proveedores por producto: {ex.Message}", ex);
            }
        }

    }
}
