using Rmc.EntityFramework;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Controllers
{
    class DevolucionController
    {
        public Tuple<bool, int> ActualizarDevolucion(string opcion, string producto, string Localidad, string Libras, string Lote, int proveedor, int defecto = 0, int accion = 0)
        {
            try
            {
                bool proceso = false;
                int IdDev = 0;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {

                    using (var dbTrans = db.Database.BeginTransaction())
                    {

                        try
                        {
                            var ActualizarItem = db.Database.ExecuteSqlCommand("EXEC usp_wai_Devoluciones_CRUD 'rimolina', '" + opcion + "', '" + producto + "', '" + Localidad + "', '" + Libras + "', '" + Lote + "'");

                            if (ActualizarItem.ToString() == "ERROR")
                            {
                                return Tuple.Create(false, 0);
                            }
                            else
                            {
                                var ultimaDev = db.wai_Devoluciones.Max(x => x.dev_id);
                                if (accion == 0)
                                {
                                    var ActualizarItemC = db.Database.ExecuteSqlCommand("UPDATE wai_Devoluciones SET dev_localidad_id='" + Localidad + "',pro_id =" + proveedor + "  WHERE dev_id= " + ultimaDev);
                                    proceso = true;
                                    IdDev = ultimaDev;

                                }
                                else
                                {
                                    var ActualizarItemN = db.Database.ExecuteSqlCommand("UPDATE wai_Devoluciones SET dev_No_Conformidad ='" + true + "', def_ID = " + defecto + " ,pro_id =" + proveedor + " ," +
                                                                            " dev_FH_No_Conforme_IN ='" + DateTime.Now + "'  WHERE dev_id= " + ultimaDev);
                                    proceso = true;
                                    IdDev = ultimaDev;
                                }
                            }
                            dbTrans.Commit();
                            return Tuple.Create(proceso, IdDev);

                        }
                        catch (Exception)
                        {
                            // Rollback transaction
                            if (dbTrans != null)
                                dbTrans.Rollback();
                            return Tuple.Create(false, 0);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ObtenerIdDevolucion(string PackID)
        {
            try
            {
                string IdDevolucion = "";
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT dev_libras - ISNULL(dev_libras_out,0) FROM wai_Devoluciones WHERE dev_codigo = '" + PackID + "'";

                    var libras = db.Database.SqlQuery<Single>(consulta).FirstOrDefault();

                    if (libras > 0.0)
                    {
                        string consultaDev = "SELECT dev_id FROM wai_Devoluciones WHERE dev_codigo = '" + PackID + "'";

                        var codigo = db.Database.SqlQuery<int>(consultaDev).FirstOrDefault();
                        IdDevolucion = codigo.ToString();
                    }
                }
                return IdDevolucion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EstampaDevolucion> ObtenerEstampaDevoluciones(string IdDevolucion)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT   D.dev_codigo AS PackId, I.ite_codigo AS Codigo, I.ite_descripcion AS Descripcion,                     " +
                                     "          L.loc_nombre AS Localidad, D.dev_lote AS Lote,                                                         " +
                                     "          D.dev_libras - ISNULL(D.dev_libras_out, 0) AS Libras                                                   " +
                                     " FROM    dbo.wai_Item AS I                                                                                       " +
                                     "         INNER JOIN dbo.wai_Devoluciones AS D ON D.dev_item_id = I.ite_id                                        " +
                                     " 		LEFT OUTER JOIN  dbo.wai_Localidad AS L ON L.loc_id = D.dev_localidad_id                                   " +
                                     " WHERE   (D.dev_id = '" + IdDevolucion + "')                                                                     " +
                                     " GROUP BY D.dev_codigo, I.ite_codigo, I.ite_descripcion, L.loc_nombre, D.dev_lote, D.dev_libras, D.dev_libras_out";

                    var resultado = db.Database.SqlQuery<EstampaDevolucion>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ObtenerCuentaDevolucionPorProducto(int codigo)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT COUNT(dev_id) FROM wai_Devoluciones WHERE dev_item_id = '" + codigo + "' " +
                                      " AND (dev_No_Conformidad=0 OR dev_No_Conformidad IS NULL) AND dev_fecha_out IS   " +
                                      "NULL  AND ((dev_libras - ISNULL(dev_libras_out,0) ) > 0)                         ";

                    var resultado = db.Database.SqlQuery<int>(consulta).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // SE OBTIENE EL CONTEO DE DEVOLUCIONES
        public int ObtenerConteoDevolucion(string codigo)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = " SELECT COUNT(DE.dev_id) AS VALOR                                              " +
                                      " FROM     dbo.wai_Devoluciones AS DE INNER JOIN                                " +
                                      "                   dbo.wai_Item AS IT ON DE.dev_item_id = IT.ite_id            " +
                                      " WHERE  (IT.ite_codigo = '" + codigo + "') AND (DE.dev_fecha_out IS NULL) AND  " +
                                      " (DE.dev_libras - ISNULL(DE.dev_libras_out, 0) > 0)                            ";
                    var resultado = db.Database.SqlQuery<int>(Consulta).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
