using Rmc.Clases;
using Rmc.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Rmc.Controllers
{
    public class LawsonController
    {
        public static List<POLawson> ObtenerPODesdeLawson(string numeroPO, string numeroFactura)
        {
            var conexion = new LawsonConnection();
            List<POLawson> resp = new List<POLawson>();

            using (var conn = conexion.OracleConexion())
            {
                string query = @"SELECT
                                L.PO_NUMBER AS NUMERO_PO,
                                L.CREATED_BY AS CREADOR_PO,
                                L.REFERENCE_NO AS NUMERO_FACTURA,
                                L.ENT_REC_QTY AS PESO,
                                L.ITEM AS CODIGO,
                                L.DESCRIPTION AS PRODUCTO,
                                L.ENT_REC_UOM AS MEDIDA
                              FROM LAWPROD.PORECLINE L
                              WHERE COMPANY IN ('3488')
                              AND TRIM(REFERENCE_NO) = ?
                              AND TRIM(PO_NUMBER) = ?";

                using (var cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", numeroFactura);
                    cmd.Parameters.AddWithValue("?", numeroPO);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resp.Add(new POLawson
                            {
                                Numero = reader["NUMERO_PO"].ToString().Trim(),
                                Creador = reader["CREADOR_PO"].ToString().Trim(),
                                NumeroFactura = reader["NUMERO_FACTURA"].ToString().Trim(),
                                Peso = Convert.ToDecimal(reader["PESO"]),
                                CodigoProducto = reader["CODIGO"].ToString().Trim(),
                                NombreProducto = reader["PRODUCTO"].ToString().Trim(),
                                UnidadMedida = reader["MEDIDA"].ToString().Trim(),
                                Cantidad = 0,
                                Lote = string.Empty,
                                Prioridad = 0
                            });
                        }
                    }
                }
            }
            return resp;
        }

    }
}
