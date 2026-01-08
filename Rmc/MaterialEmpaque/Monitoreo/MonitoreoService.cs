using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Telerik.WinControls.UI;
using System.Drawing;
using Dapper;

namespace Rmc.MaterialEmpaque.Monitoreo
{
    public class MonitoreoService
    {
        private readonly RadGridView _grid;

        public MonitoreoService(RadGridView grid)
        {
            _grid = grid;
        }

        public void ConfigurarGrid()
        {
            _grid.MasterTemplate.AutoGenerateColumns = false;
            _grid.AllowAddNewRow = false;
            _grid.ReadOnly = true;
            _grid.EnableFiltering = true;
            _grid.EnableGrouping = true;
            _grid.ShowGroupPanel = false;
            _grid.TableElement.RowHeight = 28;
            _grid.TableElement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            _grid.Columns.Clear();

            AgregarColumnaTexto("TraceID", "Trace ID", 80);
            AgregarColumnaTexto("Saca", "Saca", 80);
            AgregarColumnaTexto("MillStyle", "MillStyle", 70);
            AgregarColumnaTexto("Talla", "Talla", 40);
            AgregarColumnaTexto("Color", "Color", 55);
            AgregarColumnaTexto("Semana", "Semana", 60);
            AgregarColumnaTexto("Docenas", "Docenas", 70);
            AgregarColumnaTexto("Assortment", "Assort", 60);
            AgregarColumnaTexto("MesaAsignada", "Mesa", 60);
            AgregarColumnaFecha("FechaAsignacion", "Asignación", 120);
            AgregarColumnaFecha("FechaFinalizacion", "Finalización", 120);
            AgregarColumnaTexto("TotalStickers", "#Stickers", 80);
            AgregarColumnaTexto("Estado", "Estado", 120);
            AgregarColumnaTexto("usuario", "Usuario", 80);
            AgregarColumnaTexto("ChkID", "ChkID", 100);
            AgregarColumnaFecha("Entrada_Prekiteo", "Entrada Prekiteo", 120);
            AgregarColumnaFecha("Salida_Prekiteo", "Salida Prekiteo", 120);
            AgregarColumnaTexto("Bin", "Bin", 47);
            AgregarColumnaTexto("Operator", "Operador", 65);

            AplicarColoresPorEstado();
        }

        public bool CargarTareas(string filtroTraceId = null, DateTime? fechaInicio = null, DateTime? fechaFin = null, string filtroEstado = null)
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                var (query, parameters) = ConstruirConsulta(filtroTraceId, fechaInicio, fechaFin, filtroEstado);

                var adapter = new SqlDataAdapter(query, connection);
                AgregarParametros(adapter, parameters);

                var table = new DataTable();
                adapter.Fill(table);

                _grid.DataSource = table;
                return table.Rows.Count > 0;
            }
        }

        private (string query, Dictionary<string, object> parameters) ConstruirConsulta(
            string filtroTraceId, DateTime? fechaInicio, DateTime? fechaFin, string filtroEstado)
        {
            var parameters = new Dictionary<string, object>();
            bool tieneFiltroTraceId = !string.IsNullOrEmpty(filtroTraceId);
            bool tieneFiltroFechas = fechaInicio.HasValue || fechaFin.HasValue;
            bool usarTop = !tieneFiltroTraceId && !tieneFiltroFechas;

            string topClause = usarTop ? "TOP(150)" : "";
            string selectBase = $@"SELECT {topClause}
                                    AT.TraceId AS TraceID,
                                    AT.Saca,
                                    AT.MillStyle,
                                    AT.Size AS Talla,
                                    AT.Color,
                                    AT.WeekId AS Semana,
                                    AT.Dozens AS Docenas,
                                    AT.Assortment,
                                    AT.TableId AS MesaAsignada,
                                    AT.AssignmentDate AS FechaAsignacion,
                                    AT.EndDate AS FechaFinalizacion,
                                    AT.CantidadStickers AS TotalStickers,
                                    AT.Status AS Estado,
                                    AT.usuario,
                                    CT.ChkID,
                                    CT.DateIN AS Entrada_Prekiteo,
                                    CT.DateOUT AS Salida_Prekiteo,
                                    CT.Bin,
                                    CT.Operator
                                FROM pmc_AsignacionTraceIDs AT
                                INNER JOIN CheckPointTrans CT ON AT.TraceId = CT.TraceID";

                                    string whereBase = @"
                                WHERE CT.ChkID = 'FIN-PREKIT'";

            if (tieneFiltroTraceId)
            {
                whereBase += " AND AT.TraceId = @TraceIdFilter";
                parameters.Add("@TraceIdFilter", filtroTraceId);

                return ($"{selectBase} {whereBase} ORDER BY AT.AssignmentDate DESC", parameters);
            }

            // Filtro de estado
            string condicionEstado = ObtenerCondicionEstado(filtroEstado);
            whereBase += condicionEstado;

            // Filtro de fechas
            bool esEstadoCompletado = EsEstadoCompletado(filtroEstado);
            string condicionFechas = ObtenerCondicionFechas(esEstadoCompletado, fechaInicio, fechaFin, parameters);
            whereBase += condicionFechas;

            // Ordenamiento
            string orderBy = esEstadoCompletado ? "AT.EndDate DESC" : "AT.AssignmentDate DESC";

            return ($"{selectBase} {whereBase} ORDER BY {orderBy}", parameters);
        }

        private string ObtenerCondicionEstado(string filtroEstado)
        {
            switch (filtroEstado)
            {
                case "Completado (M)":
                    return " AND AT.Status = 'Completado (M)'";
                case "Pendientes":
                    return " AND AT.Status = 'Pendiente'";
                case "EnProceso":
                    return " AND AT.Status = 'EnProceso'";
                case null:
                    return " AND AT.Status = 'Completado'";
                default:
                    return " AND AT.Status = 'Completado'";
            }
        }

        private string ObtenerCondicionFechas(bool esEstadoCompletado, DateTime? fechaInicio, DateTime? fechaFin,
                                            Dictionary<string, object> parameters)
        {
            if (!esEstadoCompletado) return string.Empty;

            string condicion = string.Empty;

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                condicion = " AND AT.EndDate BETWEEN @FechaInicio AND @FechaFin";
                parameters.Add("@FechaInicio", fechaInicio.Value.Date);
                parameters.Add("@FechaFin", fechaFin.Value.Date.AddDays(1).AddSeconds(-1));
            }
            else if (fechaInicio.HasValue)
            {
                condicion = " AND AT.EndDate >= @FechaInicio";
                parameters.Add("@FechaInicio", fechaInicio.Value.Date);
            }
            else if (fechaFin.HasValue)
            {
                condicion = " AND AT.EndDate <= @FechaFin";
                parameters.Add("@FechaFin", fechaFin.Value.Date.AddDays(1).AddSeconds(-1));
            }

            return condicion;
        }

        private bool EsEstadoCompletado(string filtroEstado)
        {
            return string.IsNullOrEmpty(filtroEstado) ||
                   filtroEstado == "Completado";
        }

        private void AgregarParametros(SqlDataAdapter adapter, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {
                adapter.SelectCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
        }

        private void AgregarColumnaTexto(string nombre, string header, int ancho)
        {
            var col = new GridViewTextBoxColumn(nombre)
            {
                HeaderText = header,
                Width = ancho
            };
            _grid.Columns.Add(col);
        }

        private void AgregarColumnaFecha(string nombre, string header, int ancho)
        {
            var col = new GridViewTextBoxColumn(nombre)
            {
                HeaderText = header,
                Width = ancho,
                FormatString = "{0:dd/MM/yyyy - HH:mm}"
            };
            _grid.Columns.Add(col);
        }

        public void AplicarColoresPorEstado()
        {
            var pendiente = new ConditionalFormattingObject("Pendiente", ConditionTypes.Equal, "Pendiente", "", true)
            {
                CellBackColor = Color.FromArgb(255, 235, 205),
                CellForeColor = Color.FromArgb(160, 100, 0)
            };

            var enProceso = new ConditionalFormattingObject("EnProceso", ConditionTypes.Equal, "EnProceso", "", true)
            {
                CellBackColor = Color.FromArgb(220, 240, 255),
                CellForeColor = Color.FromArgb(0, 90, 180)
            };

            var completadas = new ConditionalFormattingObject("Completado", ConditionTypes.Equal, "Completado", "", true)
            {
                CellBackColor = Color.FromArgb(220, 255, 220),
                CellForeColor = Color.FromArgb(0, 130, 0)
            };

            var liberadas = new ConditionalFormattingObject("Completado (M)", ConditionTypes.Equal, "Completado (M)", "", true)
            {
                CellBackColor = Color.FromArgb(255, 220, 220),
                CellForeColor = Color.FromArgb(160, 0, 60)
            };

            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(pendiente);
            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(enProceso);
            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(completadas);
            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(liberadas);
        }

        public int ObtenerIndicadores()
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                connection.Open();

                var completadas = connection.ExecuteScalar<int>(@"
                    SELECT COUNT(*) 
                    FROM pmc_AsignacionTraceIDs
                    WHERE Status IN ('Completado', 'Completado (M)') 
                      AND YEAR(AssignmentDate) = YEAR(GETDATE())");

                return completadas;
            }
        }

    }
}