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
    class ConsultasController
    {
        public List<EntregaSolicitud> ObtenerEntregasPorBodega(int bodegaId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {
                    string query = @"
                                    SELECT  
                                        SL.sol_pack_list_ID AS PackId,
                                        SL.sol_semana AS Semana,
                                        SL.sol_item AS Codigo,
                                        ITE.ite_descripcion AS Producto,
                                        PRO.pro_nombre AS Proveedor,
                                        SL.sol_FH_crea AS FechaCreacion,
                                        SL.sol_FH_entrega AS FechaEntrega,
                                        US.Usr_Name AS PersonaEntrega,
                                        BOD.bod_nombre AS Bodega,
                                        ROUND(CONVERT(FLOAT, DATEDIFF(SECOND, SL.sol_FH_crea, SL.sol_FH_entrega)) / 60, 2) AS Minutos
                                    FROM  
                                        wai_Solicitudes AS SL
                                        INNER JOIN wai_Item AS ITE ON SL.sol_item = ITE.ite_codigo
                                        INNER JOIN wai_Bodegas AS BOD ON ITE.ite_bodega_id = BOD.bod_id
                                        INNER JOIN mst_Users AS US ON SL.sol_usuario_entrega = US.Usr_Login
                                        INNER JOIN wai_Proveedor AS PRO ON SL.sol_pro_ID = PRO.pro_id
                                    WHERE  
                                        SL.sol_FH_entrega IS NOT NULL
                                        AND SL.sol_FH_entrega >= @FechaInicio
                                        AND SL.sol_FH_entrega <= @FechaFin
                                        AND ITE.ite_bodega_id = @BodegaID
                                    ORDER BY SL.sol_FH_entrega";

                    return db.Database.SqlQuery<EntregaSolicitud>(
                        query,
                        new SqlParameter("@FechaInicio", fechaInicio),
                        new SqlParameter("@FechaFin", fechaFin),
                        new SqlParameter("@BodegaID", bodegaId)
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener entregas por bodega", ex);
            }
        }


        public List<EntregaSolicitud> ObtenerEntregas(EntregaOpcion Opcion, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                string consulta = "";
                using (ES_SOCKSEntities2 db = new ES_SOCKSEntities2())
                {

                    if ((int)Opcion == 1)
                    {
                        consulta = " SELECT  SL.sol_pack_list_ID AS PackId,SL.sol_semana AS Semana, SL.sol_item AS Codigo,                  " +
                                 "         ITE.ite_descripcion AS Producto, PRO.pro_nombre AS Proveedor, SL.sol_FH_crea AS FechaCreacion,   " +
                                 " 		SL.sol_FH_entrega AS FechaEntrega,US.Usr_Name AS PersonaEntrega,                                    " +
                                 " 		ROUND(CONVERT(FLOAT,DATEDIFF(SS,SL.sol_FH_crea,SL.sol_FH_entrega))/60,2) AS Minutos                 " +
                                 " FROM   wai_Solicitudes AS SL INNER JOIN                                                                  " +
                                 "        wai_Item AS ITE ON SL.sol_item = ITE.ite_codigo INNER JOIN                                        " +
                                 "        mst_Users AS US ON SL.sol_usuario_entrega = US.Usr_Login INNER JOIN                               " +
                                 " 	   wai_Proveedor AS PRO on SL.sol_pro_ID=PRO.pro_id                                                     " +
                                 " WHERE   SL.sol_FH_entrega IS NOT NULL  AND                                                               " +
                                 "        (CONVERT(DATEtime, SL.sol_FH_entrega) >= CONVERT(DATEtime, '" + FechaInicio + "')) AND            " +
                                 "        (CONVERT(DATEtime, SL.sol_FH_entrega) <= CONVERT(DATEtime, '" + FechaFin + "'))                   " +
                                 " ORDER BY SL.sol_FH_entrega                                                                               ";

                    }
                    else if ((int)Opcion == 2)
                    {
                        consulta = "  SELECT  SL.sol_pack_list_ID AS PackId,SL.sol_semana AS Semana, SL.sol_item AS Codigo, ITE.ite_descripcion AS Producto, " +
                                  "         SL.sol_FH_crea AS FechaCreacion, SL.sol_FH_entrega AS FechaEntrega,US.Usr_Name AS PersonaEntrega,                " +
                                  " 	    AUT.aut_usuario AS PersonaAutoriza                                                                               " +
                                  " FROM  wai_Solicitudes AS SL INNER JOIN                                                                                   " +
                                  "       wai_Item AS ITE ON SL.sol_item = ITE.ite_codigo INNER JOIN                                                         " +
                                  "       mst_Users AS US ON SL.sol_usuario_entrega = US.Usr_Login INNER JOIN                                                " +
                                  "       mst_Autorizadores AS AUT ON SL.sol_aut_ID = AUT.aut_ID                                                             " +
                                  " WHERE  (CONVERT(DATETIME, SL.sol_FH_entrega) >= CONVERT(DATETIME, '" + FechaInicio + "')) AND                            " +
                                  "        (CONVERT(DATETIME, SL.sol_FH_entrega) <= CONVERT(DATETIME, '" + FechaFin + "'))                                   " +
                                  " ORDER BY   SL.sol_FH_entrega ASC                                                                                         ";
                    }

                    var resultado = db.Database.SqlQuery<EntregaSolicitud>(consulta).ToList();
                    return resultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
    public enum EntregaOpcion
    {
        Normal = 1,
        SinPrioridad = 2
    }
}
