using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/* =====================================================================
 *  CLASE: MesaService
 *  DESCRIPCIÓN: Capa de servicio para gestión de mesas en base de datos
 *  AUTOR: Alex Galdamez
 *  
 *  ÚLTIMA ACTUALIZACIÓN: 08/11/2025
 * ===================================================================== */
namespace Rmc.MaterialEmpaque.Mesas
{
    public class MesaService
    {
        private readonly string _connectionString;

        public MesaService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Logica de Asignacion
        public (int AssignedTable, string messsage) AssignTable(AssignmentTracerIDs assignment)
        {
            int AssignedTable = 0;
            string messsage = "";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_AsignarMesa", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TraceID", assignment.traceId);
                cmd.Parameters.AddWithValue("@Saca", string.IsNullOrWhiteSpace(assignment.saca) ? (object)DBNull.Value : assignment.saca);
                cmd.Parameters.AddWithValue("@MillStyle", string.IsNullOrWhiteSpace(assignment.millStyle) ? (object)DBNull.Value : assignment.millStyle);
                cmd.Parameters.AddWithValue("@Size", assignment.size);
                cmd.Parameters.AddWithValue("@Color", string.IsNullOrWhiteSpace(assignment.color) ? (object)DBNull.Value : assignment.color);
                cmd.Parameters.AddWithValue("@WeekId", string.IsNullOrWhiteSpace(assignment.weekId) ? (object)DBNull.Value : assignment.weekId);
                cmd.Parameters.AddWithValue("@Deviation", string.IsNullOrWhiteSpace(assignment.deviation) ? (object)DBNull.Value : assignment.deviation);
                cmd.Parameters.AddWithValue("@MaterialDeviation", string.IsNullOrWhiteSpace(assignment.materialDeviation) ? (object)DBNull.Value : assignment.materialDeviation);
                cmd.Parameters.AddWithValue("@Dozens", string.IsNullOrWhiteSpace(assignment.dozens) ? (object)DBNull.Value : assignment.dozens);
                cmd.Parameters.AddWithValue("@AssortmentID", string.IsNullOrWhiteSpace(assignment.assortment) ? (object)DBNull.Value : assignment.assortment);

                var mesaParam = new SqlParameter("@AssignedTable", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                var resultadoParam = new SqlParameter("@Message", SqlDbType.NVarChar, 200)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(mesaParam);
                cmd.Parameters.Add(resultadoParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                AssignedTable = mesaParam.Value != DBNull.Value ? Convert.ToInt32(mesaParam.Value) : 0;
                messsage = resultadoParam.Value?.ToString();
            }

            return (AssignedTable, messsage);
        }

        public void ActualizarEstadosTareas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_ActualizarEstadoTareas", 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void ActualizarEstadosPendientes()
        {
            const string query = @"
                        UPDATE A
                        SET A.Status = 'Completado',
                            A.EndDate = GETDATE(),
                            A.StartDate = GETDATE()
                        FROM pmc_AsignacionTraceIDs A
                        WHERE A.Status = 'Pendiente'
                          AND EXISTS (
                              SELECT 1
                              FROM CheckPointTrans C
                              WHERE C.TraceID = A.TraceID
                                AND C.ChkID = 'FIN-PREKIT'
                                AND C.DateOUT IS NOT NULL)";

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Filas actualizadas: {rowsAffected}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar tareas pendientes: {ex.Message}");
                throw;
            }
        }

        #endregion



        public bool CrearMesas(int tableId, bool enable = false)
        {
            const string query = @"
                INSERT INTO pmc_MesasEstikerado 
                    (TableId, Enable, Created)
                SELECT @tableId, @enable, GETDATE()
                WHERE NOT EXISTS (
                    SELECT 1 FROM 
                        pmc_MesasEstikerado 
                    WHERE 
                        TableId = @tableId)";

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@tableId", SqlDbType.Int).Value = tableId;
                    cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = enable;

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL Server al crear mesa: {ex.Message}");
                return false;
            }
        }

        public int GetProximoMesaId()
        {
            const string query = @"SELECT ISNULL(MAX(TableId), 0) + 1 FROM pmc_MesasEstikerado";

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al obtener próximo MesaId: {ex.Message}");
                throw;
            }
        }

        public bool CheckActiveTables()
        {
            const string query = @"
                SELECT COUNT(*) 
                FROM 
                    pmc_MesasEstikerado
                WHERE Enable = 1";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                        return cantidad > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar mesas activas: " + ex.Message);
                return false;
            }
        }

        public bool CheckTraceIDs(string traceId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    const string query = @"SELECT 1 
                             FROM pmc_AsignacionTraceIDs 
                             WHERE TraceId = @TraceId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TraceId", traceId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar existencia del TraceID: " + ex.Message);
                return false;
            }
        }

        public List<Mesa> ObtenerTodasLasMesas()
        {
            var mesas = new List<Mesa>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT TableId, Enable FROM pmc_MesasEstikerado ORDER BY TableId";
                var command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mesas.Add(new Mesa
                            {
                                Id = reader.GetInt32(0),
                                Activa = reader.GetBoolean(1)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener mesas de la base de datos", ex);
                }
            }

            return mesas;
        }

        public ResultadoOperacion CambiarEstadoMesa(int mesaId, bool activar)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "UPDATE pmc_MesasEstikerado SET Enable = @estado WHERE TableId = @mesaId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@estado", activar ? 1 : 0);
                    command.Parameters.AddWithValue("@mesaId", mesaId);

                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows == 0)
                    {
                        return new ResultadoOperacion(false, "No se encontró la mesa especificada");
                    }

                    return new ResultadoOperacion(true);
                }
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion(false, $"Error al cambiar estado de la mesa: {ex.Message}");
            }
        }

        private List<int> ObtenerMesasOcupadas()
        {
            var mesasOcupadas = new List<int>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT DISTINCT TableId 
                    FROM 
                        pmc_AsignacionTraceIDs
                    WHERE 
                        TableId IS NOT NULL 
                    AND 
                        Status NOT IN ('Completado', 'Completado (M)')";
                var command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mesasOcupadas.Add(reader.GetInt32(0));
                    }
                }
            }

            return mesasOcupadas;
        }

        public RegistroMesa ObtenerRegistroActivo(int mesaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<RegistroMesa>(@"
                    SELECT TOP 1 
                        TraceId, Saca, WeekId, Dozens, CantidadStickers, StartDate
                    FROM 
                        pmc_AsignacionTraceIDs
                    WHERE 
                        TableId = @mesaId 
                        AND Status = 'EnProceso'
                    ORDER BY StartDate DESC",
                        new { mesaId });
            }
        }

        public int ObtenerConteoPendientes(int mesaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(@"
                    SELECT COUNT(*) 
                    FROM pmc_AsignacionTraceIDs
                    WHERE 
                        TableId = @mesaId
                        AND Status = 'Pendiente'",
                        new { mesaId });
            }
        }

        public int ObtenerConteoTotalStickers(int mesaId) 
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(@"
                    SELECT SUM(CantidadStickers) 
                    FROM pmc_AsignacionTraceIDs 
                    WHERE 
	                    TableId = @mesaId 
	                    AND Status IN ('EnProceso', 'Pendiente')", 
                        new { mesaId });
            }
        }

        public 
            (int mesasActivas, decimal totalDocenas, int stickersEnMesas, int completadas, int proceso, int pendientes, decimal pendienteDz, decimal procesocDz) ObtenerIndicadores()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var mesasActivas = connection.ExecuteScalar<int>(@"
                    SELECT COUNT(*) 
                    FROM pmc_MesasEstikerado 
                    WHERE Enable = 1"
                );

                var totalDocenas = connection.ExecuteScalar<decimal>(@"
                    SELECT SUM(CAST(Dozens AS DECIMAL(10, 2))) AS TotalDozens 
                    FROM pmc_AsignacionTraceIDs
                    WHERE ISNUMERIC(Dozens) = 1 
                        AND Status IN ('EnProceso', 'Pendiente')"
                );

                var stickersEnMesas = connection.ExecuteScalar<int>(@"
                    SELECT SUM(CantidadStickers) 
                    FROM pmc_AsignacionTraceIDs 
                    WHERE Status NOT IN ('Completado', 'Completado (M)')"
                );

                var completadas = connection.ExecuteScalar<int>(@"
                    SELECT COUNT(*) 
                    FROM pmc_AsignacionTraceIDs
                    WHERE Status IN ('Completado', 'Completado (M)')
                      AND CAST(EndDate AS DATE) = CAST(GETDATE() AS DATE)");

                var proceso = connection.ExecuteScalar<int>(@"
                    SELECT COUNT(*) 
                    FROM pmc_AsignacionTraceIDs
                    WHERE Status IN ('EnProceso')");

                var pendientes = connection.ExecuteScalar<int>(@"
                    SELECT COUNT(*) 
                    FROM pmc_AsignacionTraceIDs
                    WHERE Status IN ('Pendiente')");

                var pendienteDz = connection.ExecuteScalar<decimal>(@"
                    SELECT SUM(CAST(Dozens AS DECIMAL(10, 2))) AS TotalDozensPendiente
                    FROM pmc_AsignacionTraceIDs
                    WHERE ISNUMERIC(Dozens) = 1 
                        AND Status IN ('Pendiente')");

                var procesocDz = connection.ExecuteScalar<decimal>(@"
                    SELECT SUM(CAST(Dozens AS DECIMAL(10, 2))) AS TotalDozensProceso 
                    FROM pmc_AsignacionTraceIDs
                    WHERE ISNUMERIC(Dozens) = 1 
                        AND Status IN ('EnProceso')");

                return (mesasActivas, totalDocenas, stickersEnMesas, completadas, proceso, pendientes, pendienteDz, procesocDz);
            }
        }

        public Dictionary<int, EstadoMesa> ObtenerEstadosMesas()
        {
            var estados = new Dictionary<int, EstadoMesa>();
            var mesasOcupadas = ObtenerMesasOcupadas();

            foreach (var mesa in ObtenerTodasLasMesas())
            {
                if (!mesa.Activa)
                {
                    estados[mesa.Id] = EstadoMesa.Desactivada;
                }
                else if (mesasOcupadas.Contains(mesa.Id))
                {
                    estados[mesa.Id] = EstadoMesa.Ocupada;
                }
                else
                {
                    estados[mesa.Id] = EstadoMesa.Disponible;
                }
            }

            return estados;
        }

    }
}
