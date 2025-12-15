using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Rmc.MaterialEmpaque.Inventario
{
    public class AutomaticStatusChanger
    {
        private readonly string _connectionString;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public AutomaticStatusChanger(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteStatusChangeAsync()
        {
            if (!await _semaphore.WaitAsync(0))
            {
                Console.WriteLine($"{DateTime.Now}: ⏸️  Proceso ya en ejecución. Saltando...");
                return;
            }

            try
            {
                Console.WriteLine($"{DateTime.Now}: INICIANDO PROCESO AUTOMÁTICO DE CAMBIO DE ESTADO");

                // Obtener TraceIDs únicos usando HashSet
                var traceIds = await GetReadyTraceIdsAsync();
                var traceIdsForStatus5 = await GetReadyTraceIdsForStatus5Async();

                traceIdsForStatus5.ExceptWith(traceIds);

                int processedStatus4 = 0;
                int processedStatus5 = 0;
                int skippedDuplicates = 0;

                // Procesar estado 3 -> 4
                if (traceIds.Count > 0)
                {
                    Console.WriteLine($"{DateTime.Now}: Encontrados {traceIds.Count} TraceIDs únicos para cambiar a estado 4");

                    foreach (var traceId in traceIds)
                    {
                        if (await ExecuteChangeTransactionStatusAsync(traceId, 4, "system"))
                        {
                            processedStatus4++;
                        }
                        else
                        {
                            skippedDuplicates++;
                        }
                    }

                    Console.WriteLine($"{DateTime.Now}: Proceso completado - {processedStatus4} transacciones cambiadas a estado 4, {skippedDuplicates} duplicados omitidos");
                }

                // Reiniciar contador de duplicados para el siguiente grupo
                skippedDuplicates = 0;

                // Procesar estado 4 -> 5
                if (traceIdsForStatus5.Count > 0)
                {
                    Console.WriteLine($"{DateTime.Now}: Encontrados {traceIdsForStatus5.Count} TraceIDs únicos para cambiar a estado 5");

                    foreach (var traceId in traceIdsForStatus5)
                    {
                        if (await ExecuteChangeTransactionStatusAsync(traceId, 5, "system"))
                        {
                            processedStatus5++;
                        }
                        else
                        {
                            skippedDuplicates++;
                        }
                    }

                    Console.WriteLine($"{DateTime.Now}: Proceso completado - {processedStatus5} transacciones cambiadas a estado 5, {skippedDuplicates} duplicados omitidos");
                }

                if (traceIds.Count == 0 && traceIdsForStatus5.Count == 0)
                {
                    Console.WriteLine($"{DateTime.Now}: No hay TraceIDs listos para cambiar de estado");
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now}: RESUMEN FINAL - Estado 4: {processedStatus4}, Estado 5: {processedStatus5}, Duplicados omitidos: {skippedDuplicates}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}: ERROR en el proceso automático: {ex.Message}");
                Console.WriteLine($"{DateTime.Now}: StackTrace: {ex.StackTrace}");
                throw;
            }
            finally
            {
                _semaphore.Release();
                Console.WriteLine($"{DateTime.Now}: 🔓 Proceso liberado");
            }
        }

        // Para Status 3 -> 4
        private async Task<HashSet<int>> GetReadyTraceIdsAsync()
        {
            var traceIds = new HashSet<int>();

            string query = @"SELECT DISTINCT t.TraceID
                            FROM ES_SOCKS.dbo.pmc_Transactions t
                            INNER JOIN ES_SOCKS.dbo.pmc_TransactionDetails td ON t.ID = td.TransactionID
                            INNER JOIN ES_SOCKS.dbo.pmc_InventoryPreparation i ON td.Code = i.Code
                            INNER JOIN dbo.pmc_AsignacionTraceIDs a ON t.TraceID = a.TraceId
                            WHERE 
                                td.QuantityREAL IS NOT NULL 
                                AND t.StatusID = 3
                                AND a.Status IN ('Completado', 'Completado (M)')";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        traceIds.Add(reader.GetInt32(0));
                    }
                }
            }

            Console.WriteLine($"{DateTime.Now}: Consulta 3->4 devolvió {traceIds.Count} TraceIDs únicos");
            return traceIds;
        }

        // Para Status 4 -> 5 
        private async Task<HashSet<int>> GetReadyTraceIdsForStatus5Async()
        {
            var traceIds = new HashSet<int>();

            string query = @"SELECT DISTINCT t.TraceID
                            FROM ES_SOCKS.dbo.pmc_Transactions t
                            INNER JOIN ES_SOCKS.dbo.pmc_TransactionDetails td ON t.ID = td.TransactionID
                            INNER JOIN ES_SOCKS.dbo.pmc_InventoryPreparation i ON td.Code = i.Code
                            WHERE 
                                t.StatusID = 4
                                AND EXISTS (
                                    SELECT 1 
                                    FROM dbo.CheckPointTrans fin_basc
                                    INNER JOIN dbo.CheckPointTrans fin_kit ON fin_basc.RelatedID = fin_kit.TraceID
                                    WHERE fin_basc.TraceID = t.TraceID 
                                      AND fin_basc.ChkID = 'FIN-BASC'
                                      AND fin_kit.ChkID = 'FIN-KIT'
                                )";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        traceIds.Add(reader.GetInt32(0));
                    }
                }
            }

            Console.WriteLine($"{DateTime.Now}: Consulta 4->5 devolvió {traceIds.Count} TraceIDs únicos");
            return traceIds;
        }

        private async Task<bool> ExecuteChangeTransactionStatusAsync(int traceId, int newStatusId, string badge)
        {
            if (await IsStatusAlreadyActiveAsync(traceId, newStatusId))
            {
                Console.WriteLine($"{DateTime.Now}: ⚠️  OMITIDO - TraceID {traceId} ya tiene estado {newStatusId} activo");
                return false;
            }

            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.ES_SOCKSConnectionString))
                using (var command = new SqlCommand("sp_ChangeTransactionStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TraceID", traceId);
                    command.Parameters.AddWithValue("@NewStatusID", newStatusId);
                    command.Parameters.AddWithValue("@Badge", badge);
                    command.CommandTimeout = 30;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    Console.WriteLine($"{DateTime.Now}: ✅ EXITOSO - TraceID {traceId} cambiado a estado {newStatusId}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}: ❌ ERROR - TraceID {traceId} a estado {newStatusId}: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> IsStatusAlreadyActiveAsync(int traceId, int statusId)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM ES_SOCKS.dbo.pmc_StatusTracking st
                INNER JOIN ES_SOCKS.dbo.pmc_Transactions t ON st.TransactionID = t.ID
                WHERE t.TraceID = @TraceID 
                  AND st.StatusID = @StatusID 
                  AND st.EndDate IS NULL";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TraceID", traceId);
                command.Parameters.AddWithValue("@StatusID", statusId);

                await connection.OpenAsync();
                var count = (int)await command.ExecuteScalarAsync();
                return count > 0;
            }
        }
    }
}