using Rmc.EntityFramework;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Controllers
{
    class NConformeController
    {
        public int PackNoComforme(string ID)
        {
            try
            {
                int retorno = 0;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    if (ID.ToUpper().Contains("D"))
                    {
                        string cadena = "SELECT  ISNULL(DEV_NO_Conformidad,0) NO_CONFORME FROM wai_Devoluciones WHERE dev_codigo = '" + ID.Trim() + "'";
                        var resultado = db.Database.SqlQuery<bool>(cadena).ToList<bool>().FirstOrDefault();
                        retorno = Convert.ToInt32(resultado);
                    }
                    else
                    {
                        string cadena = "SELECT ISNULL(pac_NO_Conformidad,0) NO_CONFORME " +
                                                       "FROM wai_Pack_List WHERE pac_id = " + Convert.ToInt32(ID);
                        var resultado = db.Database.SqlQuery<bool>(cadena).FirstOrDefault();
                        retorno = Convert.ToInt32(resultado);

                    }
                    return retorno;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<wai_Defectos_NoConformes> ObtenerDefectos()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT def_ID , def_Descripcion , def_FH_crea" +
                                                     " , (SELECT Usr_Name FROM mst_Users WHERE Usr_Login = def_usuario)  AS def_usuario" +
                                                      "  , def_FH_mod " +
                                                       " , (SELECT Usr_Name FROM mst_Users WHERE Usr_Login = def_usuario_mod) AS def_usuario_mod " +
                                                     " FROM wai_Defectos_NoConformes";
                    var defectos = db.Database.SqlQuery<wai_Defectos_NoConformes>(consulta).ToList<wai_Defectos_NoConformes>();
                    return defectos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<LocalidadTraslados> ObtenerItemPorLocalidad(string filtro)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT PL.pac_id AS ID, 1 AS ORIGEN, CONVERT(VARCHAR(20),PL.pac_id) AS PACKID, CONCAT(I.ite_codigo,' - ', I.ite_descripcion) AS ITEM, "
                    + " (PL.pac_libras - ISNULL(PL.pac_libras_salida,0)) AS LIBRAS,	CONVERT(BIT,PL.pac_impreso) AS IMPRESO, PL.pac_scan_whin AS FECHAENTRADA, L.loc_nombre AS LOCALIDAD, CONVERT(BIT,0) AS MARCAR "
                    + " FROM wai_Pack_List PL INNER JOIN wai_Factura_Detalle FD ON FD.facd_id=PL.pac_factura_detalle_id "
                    + " INNER JOIN wai_Item I ON I.ite_id = FD.facd_item_id INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id "
                    + " WHERE PL.pac_scan_whout IS NULL AND (PL.pac_libras - ISNULL(PL.pac_libras_salida,0))>0 " + filtro
                    + " UNION ALL "
                    + " SELECT  D.dev_id AS ID, 2 AS ORIGEN, D.dev_codigo AS PACKID,  CONCAT(I.ite_codigo,' - ', I.ite_descripcion) AS ITEM,  (D.dev_libras - ISNULL(D.dev_libras_out,0)) AS LIBRAS, "
                    + " CONVERT(BIT,D.dev_impreso) AS IMPRESO, D.dev_fecha_in AS FECHAENTRADA, L.loc_nombre AS LOCALIDAD, CONVERT(BIT,0) AS MARCAR "
                    + " FROM wai_Devoluciones D "
                    + " INNER JOIN wai_Item I ON I.ite_id = D.dev_item_id INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id "
                    + " WHERE  (D.dev_libras - ISNULL(D.dev_libras_out,0)) >0 " + filtro;
                    var items = db.Database.SqlQuery<LocalidadTraslados>(consulta).ToList<LocalidadTraslados>();
                    return items;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarLocalidad(List<LocalidadTraslados> LTraslado, int LocalidadFinal, bool SalirNoConformidad)
        {
            try
            {
                bool proceso = false;
                string ActualizarPack = "";
                string ActualizarDevolucion = "";
                if (SalirNoConformidad == true)
                {
                    ActualizarPack = ",pac_No_Conformidad ='" + false + "', pac_FH_No_Conforme_OUT='" + DateTime.Now + "'";
                    ActualizarDevolucion = ",dev_No_Conformidad ='" + false + "', dev_FH_No_Conforme_OUT='" + DateTime.Now + "'";
                }
                else
                {
                    ActualizarPack = "";
                    ActualizarDevolucion = "";
                }

                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    using (var dbTrans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (var item in LTraslado)
                            {
                                if (item.ORIGEN == 1)
                                {
                                    var ActualizarItem = db.Database.ExecuteSqlCommand("UPDATE wai_Pack_List SET pac_localidad_id='" + LocalidadFinal + "'" + ActualizarPack + "  WHERE pac_id= " + item.ID);
                                    proceso = true;
                                }
                                else if (item.ORIGEN == 2)
                                {
                                    var ActualizarItem = db.Database.ExecuteSqlCommand("UPDATE wai_Devoluciones SET dev_localidad_id='" + LocalidadFinal + "'" + ActualizarDevolucion + "  WHERE dev_id= " + item.ID);

                                    proceso = true;
                                }
                            }

                            dbTrans.Commit();
                            return proceso;

                        }
                        catch (Exception)
                        {
                            // Rollback transaction
                            if (dbTrans != null)
                                dbTrans.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;

            }
        }

        public bool ActualizarLocalidadNoConforme(List<ProductoNoConforme> LNoConforme, int LocalidadFinal)
        {
            try
            {
                bool proceso = false;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    using (var dbTrans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (var item in LNoConforme)
                            {
                                if (item.Origen == 1)
                                {
                                    var ActualizarItem = db.Database.ExecuteSqlCommand("UPDATE wai_Pack_List SET pac_localidad_id='" + LocalidadFinal + "' ,pac_No_Conformidad ='" + true + "', pac_FH_No_Conforme_IN='" + DateTime.Now + "', Def_ID =" + item.IdDefecto + " WHERE pac_id= " + item.IdItem);
                                    proceso = true;
                                }
                                else if (item.Origen == 2)
                                {
                                    var ActualizarItem = db.Database.ExecuteSqlCommand("UPDATE wai_Devoluciones SET dev_localidad_id='" + LocalidadFinal + "' ,dev_No_Conformidad ='" + true + "', dev_FH_No_Conforme_IN='" + DateTime.Now + "', Def_ID =" + item.IdDefecto + " WHERE dev_id= " + item.IdItem);
                                    proceso = true;
                                }
                            }
                            dbTrans.Commit();
                            return proceso;
                        }
                        catch (Exception)
                        {
                            // Rollback transaction
                            if (dbTrans != null)
                                dbTrans.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public List<NoConformidadReporte> ObtenerProductosNoConformidad()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT * FROM (" +
                                      " SELECT CONVERT(VARCHAR,PL.pac_id) AS PackID,FD.facd_lote AS Lote, I.ite_codigo AS Codigo, I.ite_descripcion AS Descripcion," +
                                      "       pr.pro_nombre AS Proveedor ,ROUND(ISNULL(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0), 0), 2) AS Libras,DEF_NO.def_Descripcion AS Defecto,L.loc_nombre AS Localidad ,PL.pac_FH_No_Conforme_IN As Fecha   " +
                                      "  FROM      wai_Item AS I INNER JOIN" +
                                      "            wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN" +
                                      "            wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id INNER JOIN" +
                                      "            wai_Localidad AS L ON L.loc_id = PL.pac_localidad_id INNER JOIN" +
                                      "            wai_Factura AS FAC ON FD.facd_fac_id = FAC.fac_id INNER JOIN" +
                                      "            wai_POS AS PO ON FAC.fac_pos_id = PO.pos_id INNER JOIN" +
                                      "            wai_Proveedor AS pr ON PO.pos_proveedor_id = pr.pro_id INNER JOIN" +
                                      "			wai_Defectos_NoConformes  DEF_NO  ON PL.def_ID=DEF_NO.def_ID" +
                                      "  WHERE    PL.pac_No_Conformidad=1" +
                                      "  UNION ALL" +
                                      "  SELECT D.dev_codigo AS PackID,D.dev_lote AS Lote, " +
                                      "	         I.ite_codigo AS Codigo, I.ite_descripcion AS Descripcion , pr.pro_nombre AS Proveedor " +
                                      "             , D.dev_libras  AS Libras,DEF_NO.def_Descripcion AS Defecto,L.loc_nombre AS Localidad ,D.dev_FH_No_Conforme_IN As Fecha" +
                                      "   FROM     wai_Item AS I " +
                                      "	         INNER JOIN wai_Devoluciones AS D ON D.dev_item_id = I.ite_id " +
                                      "			 INNER JOIN wai_Localidad AS L ON L.loc_id = D.dev_localidad_id " +
                                      "			 INNER JOIN wai_Proveedor AS pr ON D.pro_id = pr.pro_id " +
                                      "			 INNER JOIN" +
                                      "			 wai_Defectos_NoConformes  DEF_NO  ON D.def_ID=DEF_NO.def_ID" +
                                      "  WHERE D.dev_No_Conformidad=1 ) AS NO_CONFORME";
                    var productos = db.Database.SqlQuery<NoConformidadReporte>(consulta).ToList<NoConformidadReporte>();
                    return productos;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CrudDefectos(int opcion, int codigo, string descripcion)
        {
            try
            {
                using (ES_SOCKSEntities2 dbl = new ES_SOCKSEntities2())
                {
                    if (opcion == 1)
                    {
                        wai_Defectos_NoConformes epp = new wai_Defectos_NoConformes()
                        {
                            def_Descripcion = descripcion,
                            def_usuario = Environment.UserName,
                        };
                        dbl.wai_Defectos_NoConformes.Add(epp);
                        dbl.SaveChanges();
                    }
                    else if (opcion == 2)
                    {
                        var registro = dbl.wai_Defectos_NoConformes.Where(x => x.def_ID == codigo).FirstOrDefault();
                        registro.def_Descripcion = descripcion;

                        registro.def_FH_mod = DateTime.Now;
                        registro.def_usuario_mod = Environment.UserName;

                        dbl.SaveChanges();

                    }
                    else if (opcion == 3)
                    {
                        var registro = dbl.wai_Defectos_NoConformes.Where(x => x.def_ID == codigo).FirstOrDefault();
                        dbl.wai_Defectos_NoConformes.Remove(registro);
                        dbl.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
