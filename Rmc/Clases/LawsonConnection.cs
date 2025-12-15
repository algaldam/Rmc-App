using System;
using System.Data.Odbc;

namespace Rmc.Clases
{
    public class LawsonConnection
    {
        private readonly string connectionString;

        public LawsonConnection()
        {
            connectionString = "DSN=LAWPROD;Uid=svc_mfgautomates;Pwd=K3d9X#Qj;";
        }

        public OdbcConnection OracleConexion()
        {
            OdbcConnection conexion = new OdbcConnection(connectionString);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con Lawson: " + ex.Message, ex);
            }
        }
    }
}

