using Rmc.EntityFramework;
using Rmc.EntityFramework.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Controllers
{
    class ConsultasSql
    {
        public static DateTime ObtenerFechaServer()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var fecha = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
                    return fecha.First();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string ObtenerTurno()
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string Consulta = " SELECT CONVERT(char(1), cal_turno) AS TURNO                                                  " +
                                     " FROM dbo.mst_Calendario                                                                      " +
                                     " WHERE  (GETDATE() BETWEEN cal_inicio AND cal_fin) AND(cal_turno<> 'D') AND(cal_turno<> 'ADM') AND(cal_turno<> '2')";
                    var turno = db.Database.SqlQuery<string>(Consulta).FirstOrDefault();
                    return turno.Trim();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static mst_Autorizadores ValidarMovimientos(string pass, int AppID, string NombreObjeto)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var Consulta = " SELECT AU.* FROM                                                        " +
                                   " mst_Autorizadores AU                                                    " +
                                   " INNER JOIN mst_Objects OBJ ON AU.aut_Obj_ID = OBJ.Obj_ID                " +
                                   " INNER JOIN mst_Applications AP ON obj.App_ID = AP.App_ID                " +
                                   " WHERE AU.aut_contrasenia = '" + pass + "'  AND ap.App_ID = " + AppID + "       " +
                                   "       AND obj.Obj_Name = '" + NombreObjeto + "'                             ";

                    var resultado = db.Database.SqlQuery<mst_Autorizadores>(Consulta).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<fn_mst_GetFormPermissions> ObtenerBotones(string form)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {

                    var botones = db.Database.SqlQuery<fn_mst_GetFormPermissions>(" SELECT * FROM fn_mst_GetFormPermissions('" + form + "'," + Convert.ToInt32(Properties.Settings.Default.appID) + ",'" + Environment.UserName + "')").ToList<fn_mst_GetFormPermissions>();

                    return botones;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static int ValidadCarnet(string carnet)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var resultado = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM mst_Empleados WHERE Emp_ID ='" + carnet + "' and Emp_Estado ='A'").First();
                    return resultado;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ObtenerPermisoBoton(int opcion, string boton)
        {
            try
            {
                int respuesta = 0;
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    var permiso = db.Database.SqlQuery<fn_mst_GetFormPermissions>(" SELECT * FROM fn_mst_GetFormPermissions('" + boton + "'," + 26 + ",'" + Environment.UserName + "')").Select(x => x).FirstOrDefault();
                    if (permiso.PermisosActualizar != null)
                    {

                        switch (opcion)
                        {

                            case 1:
                                if (Convert.ToInt32(permiso.PermisosCrear) > 0)
                                {
                                    respuesta = 1;
                                }
                                else
                                {
                                    respuesta = 0;
                                };
                                break;
                            case 2:
                                if (Convert.ToInt32(permiso.PermisosActualizar) > 0)
                                {
                                    respuesta = 1;
                                }
                                else
                                {
                                    respuesta = 0;
                                };
                                break;
                            case 3:
                                if (Convert.ToInt32(permiso.PermisosEliminar) > 0)
                                {
                                    respuesta = 1;
                                }
                                else
                                {
                                    respuesta = 0;
                                };
                                break;
                        }


                    }
                }
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
