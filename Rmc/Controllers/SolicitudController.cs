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
    class SolicitudController
    {
        public int ObtenerNumeroSolicitudesUsuario()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    String Consulta = "SELECT COUNT(*) FROM wai_Solicitudes  WHERE sol_usuario_pedido = '" + Environment.UserName + "' AND sol_estado <> 'Entregado' ";
                    var solicitudes = db.Database.SqlQuery<int>(Consulta).First();
                    return solicitudes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ObtenerNombreUsuario()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = "SELECT Usr_Name FROM mst_Users WHERE Usr_Login ='" + Environment.UserName + "'";
                    var resultado = db.Database.SqlQuery<string>(consulta).First();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public wai_Solicitudes ObtenerSolicitudPorId(int ID)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.wai_Solicitudes.Where(x => x.sol_ID == ID).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<T> CreateList<T>(params T[] elements)
        {
            return new List<T>(elements);
        }

        public List<ClaseGenerica> ObtenerProductoPorSemana(string Semana)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = " SELECT PL.pla_item, IT.ite_descripcion, PL.pla_UOM       " +
                                     " FROM   dbo.wai_Plan AS PL INNER JOIN                      " +
                                     "        dbo.wai_Item AS IT ON PL.pla_item = IT.ite_codigo  " +
                                     " WHERE  (PL.pla_semana = '" + Semana + "')                 " +
                                     " ORDER BY IT.ite_descripcion ASC                           ";
                    var resultado = db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClaseGenerica> ObtenerProductoPorSemana(string semana, int bodegaId)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = @"
                                        SELECT [PLAN].pla_item, IT.ite_descripcion, [PLAN].pla_UOM, SUM(LIBRAS) AS LIBRAS
                                        FROM (
                                            SELECT I.ite_codigo AS Codigo,
                                                   ROUND(SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida, 0)), 2) AS LIBRAS
                                            FROM dbo.wai_Item I
                                            INNER JOIN dbo.wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id
                                            INNER JOIN dbo.wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id
                                            INNER JOIN dbo.wai_Localidad L ON L.loc_id = PL.pac_localidad_id
                                            WHERE (PL.pac_libras > ISNULL(PL.pac_libras_salida, 0))
                                              AND I.ite_bodega_id = " + bodegaId + @"
                                            GROUP BY I.ite_codigo

                                            UNION ALL

                                            SELECT I.ite_codigo,
                                                   ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out, 0)), 2)
                                            FROM dbo.wai_Item I
                                            INNER JOIN dbo.wai_Devoluciones D ON D.dev_item_id = I.ite_id
                                            INNER JOIN dbo.wai_Localidad L ON L.loc_id = D.dev_localidad_id
                                            WHERE (D.dev_libras > ISNULL(D.dev_libras_out, 0))
                                              AND I.ite_bodega_id = " + bodegaId + @"
                                            GROUP BY I.ite_codigo
                                        ) AS LIBRAS
                                        INNER JOIN dbo.wai_Plan [PLAN] ON [PLAN].pla_item = LIBRAS.Codigo
                                        INNER JOIN dbo.wai_Item IT ON [PLAN].pla_item = IT.ite_codigo
                                        WHERE [PLAN].pla_semana = '" + semana + @"'
                                        GROUP BY [PLAN].pla_item, IT.ite_descripcion, [PLAN].pla_UOM
                                        HAVING SUM(LIBRAS) > 0
                                        ORDER BY IT.ite_descripcion DESC";

                    return db.Database.SqlQuery<ClaseGenerica>(consulta).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<ClaseGenerica> ObtenerQuimicosPorSemana(string Semana)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string consulta = @"
                                        SELECT 
                                            PL.pla_item, 
                                            IT.ite_descripcion, 
                                            PL.pla_UOM
                                        FROM dbo.wai_Plan AS PL
                                        INNER JOIN dbo.wai_Item AS IT 
                                            ON PL.pla_item = IT.ite_codigo
                                        WHERE 
                                            PL.pla_semana = @semana
                                            AND IT.ite_bodega_id = 3
                                        ORDER BY IT.ite_descripcion ASC";

                    var resultado = db.Database.SqlQuery<ClaseGenerica>(consulta,
                        new SqlParameter("@semana", Semana)).ToList();

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // METODO PARA OBTENER TODAS LAS SOLICITUDES ACTIVAS
        public List<Solicitud> ObtenerSolicitudesActivas(string usuario = null)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string filtro = "";
                    if (usuario != null)
                    {
                        filtro = "(SL.sol_estado <> 'Entregado') AND (SL.sol_usuario_pedido = '" + usuario + "')";
                    }
                    else
                    {
                        filtro = "(SL.sol_estado <> 'Entregado')";
                    }
                    string cadena = "SELECT SL.sol_ID, SL.sol_semana, SL.sol_item, SL.sol_estado, SL.sol_UOM, PR.pro_nombre, SL.sol_turno_crea,          " +
                                    "        SL.sol_turno_entrega, SL.sol_FH_crea, SL.sol_FH_entrega,                                                    " +
                                    "                  SL.sol_localidad, SL.sol_usuario_pedido,                                                          " +
                                    "       (SELECT Usr_Name                                                                                             " +
                                    "        FROM      dbo.mst_Users                                                                                     " +
                                    "        WHERE   (Usr_Login = SL.sol_usuario_pedido)) AS NOMBRE_PIDE, SL.sol_usuario_entrega,                        " +
                                    "       (SELECT Usr_Name                                                                                             " +
                                    "        FROM      dbo.mst_Users AS mst_Users_1                                                                      " +
                                    "        WHERE   (Usr_Login = SL.sol_usuario_entrega)) AS NOMBRE_ENTREGA, ite.ite_descripcion, SL.sol_prioridad      " +
                                    " FROM     dbo.wai_Solicitudes AS SL INNER JOIN                                                                      " +
                                    "                  dbo.wai_Proveedor AS PR ON SL.sol_pro_ID = PR.pro_id INNER JOIN                                   " +
                                    "                  dbo.wai_Item AS ite ON RTRIM(LTRIM(SL.sol_item)) = RTRIM(LTRIM(ite.ite_codigo)) INNER JOIN        " +
                                    "                  dbo.mst_Users AS EMP ON SL.sol_usuario_pedido = EMP.Usr_Login                                     " +
                                    " WHERE " + filtro + "                                                                                               " +
                                    " ORDER BY SL.sol_prioridad ASC,SL.sol_FH_crea";
                    var Solicitudes = db.Database.SqlQuery<Solicitud>(cadena).ToList<Solicitud>();
                    return Solicitudes;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Solicitud> ObtenerListaSolicitudes(string usuario = null, int? bodegaId = null)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    List<string> condiciones = new List<string>
                    {
                        "SL.sol_estado <> 'Entregado'"
                    };

                    if (!string.IsNullOrEmpty(usuario))
                    {
                        condiciones.Add("SL.sol_usuario_pedido = '" + usuario + "'");
                    }

                    if (bodegaId.HasValue)
                    {
                        condiciones.Add("ite.ite_bodega_id = " + bodegaId.Value);
                    }

                    string filtro = string.Join(" AND ", condiciones);

                    string query = $@"
                                    SELECT 
                                        SL.sol_ID, 
                                        SL.sol_semana, 
                                        SL.sol_item, 
                                        SL.sol_estado, 
                                        SL.sol_UOM, 
                                        PR.pro_nombre, 
                                        SL.sol_turno_crea,         
                                        SL.sol_turno_entrega, 
                                        SL.sol_FH_crea, 
                                        SL.sol_FH_entrega,                                                    
                                        SL.sol_localidad, 
                                        SL.sol_usuario_pedido,                                                          
                                        (
                                            SELECT Usr_Name
                                            FROM dbo.mst_Users 
                                            WHERE Usr_Login = SL.sol_usuario_pedido
                                        ) AS NOMBRE_PIDE, 
                                        SL.sol_usuario_entrega,                        
                                        (
                                            SELECT Usr_Name
                                            FROM dbo.mst_Users AS mst_Users_1
                                            WHERE Usr_Login = SL.sol_usuario_entrega
                                        ) AS NOMBRE_ENTREGA, 
                                        ite.ite_descripcion, 
                                        SL.sol_prioridad
                                    FROM dbo.wai_Solicitudes AS SL
                                    INNER JOIN dbo.wai_Proveedor AS PR ON SL.sol_pro_ID = PR.pro_id
                                    INNER JOIN dbo.wai_Item AS ite ON RTRIM(LTRIM(SL.sol_item)) = RTRIM(LTRIM(ite.ite_codigo))
                                    INNER JOIN dbo.mst_Users AS EMP ON SL.sol_usuario_pedido = EMP.Usr_Login
                                    WHERE {filtro}
                                    ORDER BY SL.sol_prioridad ASC, SL.sol_FH_crea";

                    var Solicitudes = db.Database.SqlQuery<Solicitud>(query).ToList();
                    return Solicitudes;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // METODO PARA CRUD SOLICITUDES       
        public int CrudSolicitudes(int opcion, int ID, string PackID, int AutorizacionID, wai_Solicitudes Solicitud = null, string Accion = "", int permiso = 1, string Estado = "Entregado")
        {
            try
            {
                var Fecha = ConsultasSql.ObtenerFechaServer();
                int resultado = 0;
                string turno = ConsultasSql.ObtenerTurno();
                object respuesta = "";
                using (ES_SOCKSEntities2 dbl = new ES_SOCKSEntities2())
                {
                    if (opcion == 1)
                    {
                        respuesta = dbl.usp_wai_Solicitud_CRUD(ID, Solicitud.sol_semana, Solicitud.sol_item, Solicitud.sol_estado, Solicitud.sol_UOM, Solicitud.sol_pro_ID,
                                                Solicitud.sol_localidad, Solicitud.sol_prioridad, Solicitud.sol_usuario_pedido, Accion).FirstOrDefault();
                    }
                    else if (opcion == 2)
                    {

                        if (Accion.Trim() == "D")
                        {
                            respuesta = dbl.usp_wai_Solicitud_CRUD(ID, "", "", "", "", 0, "", "", Environment.UserName, Accion).FirstOrDefault();
                        }
                        else
                        {
                            respuesta = dbl.usp_wai_Solicitud_CRUD(Solicitud.sol_ID, Solicitud.sol_semana, Solicitud.sol_item, Solicitud.sol_estado, Solicitud.sol_UOM, Solicitud.sol_pro_ID,
                                                          Solicitud.sol_localidad, Solicitud.sol_prioridad, Solicitud.sol_usuario_pedido, Accion).FirstOrDefault();
                        }
                    }
                    else if (opcion == 3)
                    {
                        var registro = dbl.wai_Solicitudes.Where(x => x.sol_ID == ID).FirstOrDefault();
                        registro.sol_estado = Estado;
                        if (Estado == "Entregado")
                        {
                            registro.sol_turno_entrega = turno;
                            registro.sol_FH_entrega = Fecha;
                        }

                        if (PackID.Trim() != "")
                        {
                            registro.sol_pack_list_ID = PackID;
                        }

                        if (permiso == 1)
                        {
                            registro.sol_aut_ID = AutorizacionID;
                            mst_Autorizadores_Bitacora bit = new mst_Autorizadores_Bitacora
                            {
                                aut_ID = AutorizacionID,
                                aut_bit_FH_creacion = Fecha
                            };
                            dbl.mst_Autorizadores_Bitacora.Add(bit);
                        }
                        else if (permiso == 3)
                        {
                            registro.sol_usuario_entrega = Environment.UserName;
                        }

                        dbl.SaveChanges();
                        respuesta = "OK";
                    }
                    if (respuesta.ToString().Trim() == "OK")
                    {
                        resultado = 1;
                    }
                    else
                    {
                        resultado = 0;
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
    }
}
