using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using System;


/* =====================================================================
 *  CLASE: TareasGridHandler
 *  DESCRIPCIÓN: Controlador especializado para gestión visual de DataGridView
 *                de tareas asignadas a mesas.
 *  AUTOR: Alex Galdamez
 *  
 *  ÚLTIMA ACTUALIZACIÓN: 08/11/2025
 * ===================================================================== */
namespace Rmc.MaterialEmpaque.Mesas
{
    public class TareasGridHandler
    {
        private readonly RadGridView _grid;
        public event EventHandler<ReasignacionEventArgs> ReasignacionSolicitada;

        public TareasGridHandler(RadGridView grid)
        {
            _grid = grid;
            _grid.CellDoubleClick += Grid_CellDoubleClick;
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

            AgregarColumnaTexto("TraceID", "Trace ID", 70);
            AgregarColumnaTexto("Saca", "Saca", 80);
            AgregarColumnaTexto("MillStyle", "MillStyle", 60);
            AgregarColumnaTexto("Talla", "Talla", 40);
            AgregarColumnaTexto("Color", "Color", 60);
            AgregarColumnaTexto("Semana", "Semana", 60);
            AgregarColumnaTexto("Docenas", "Docenas", 70);
            AgregarColumnaTexto("Assortment", "Assort", 58);
            AgregarColumnaTexto("TotalStickers", "#Stickers", 80);
            AgregarColumnaTexto("MesaID", "Mesa", 50);
            AgregarColumnaTexto("Estado", "Estado", 75);
            AgregarColumnaFecha("FechaAsignacion", "Asignación", 150);
            AgregarColumnaFecha("FechaInicio", "Inicio", 150);
            //AgregarColumnaFecha("FechaFinalizacion", "Finalización", 120);

            AplicarColoresPorEstado();
        }

        public void CargarTareas()
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                string query = @"
                    SELECT TOP 100
                        TraceId AS TraceID,
                        Saca,
                        MillStyle,
                        Size AS Talla,
                        Color,
                        WeekId AS Semana,
                        Dozens AS Docenas,
                        Assortment,
                        CantidadStickers AS TotalStickers,
                        TableId AS MesaID,
                        Status AS Estado,
                        FORMAT(AssignmentDate, 'dd MMM yyyy - h:mm tt') AS FechaAsignacion,
                        FORMAT(StartDate, 'dd MMM yyyy - h:mm tt') AS FechaInicio,
                        FORMAT(EndDate, 'dd MMM yyyy - h:mm tt') AS FechaFinalizacion
                    FROM pmc_AsignacionTraceIDs
                    WHERE Status NOT IN ('Completado', 'Completado (M)')
                    ORDER BY 
                        CASE Status
                            WHEN 'EnProceso' THEN 1
                            WHEN 'Pendiente' THEN 2
                        END,
                        StartDate DESC";

                var adapter = new SqlDataAdapter(query, connection);
                var table = new DataTable();
                adapter.Fill(table);

                _grid.DataSource = table;
            }
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

            var finalizado = new ConditionalFormattingObject("Completado", ConditionTypes.Equal, "Completado", "", true)
            {
                CellBackColor = Color.FromArgb(220, 255, 220),
                CellForeColor = Color.FromArgb(0, 130, 0)
            };

            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(pendiente);
            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(enProceso);
            _grid.Columns["Estado"].ConditionalFormattingObjectList.Add(finalizado);
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
                FormatString = "{0:dd/MM/yyyy HH:mm}"
            };
            _grid.Columns.Add(col);
        }

        private void Grid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Row != null && e.Row is GridViewDataRowInfo)
            {
                var traceId = e.Row.Cells["TraceID"].Value?.ToString();
                var mesaActual = e.Row.Cells["MesaID"].Value?.ToString();

                if (!string.IsNullOrEmpty(traceId))
                {
                    // Disparar el evento
                    ReasignacionSolicitada?.Invoke(this,
                        new ReasignacionEventArgs
                        {
                            TraceId = traceId,
                            MesaActual = mesaActual
                        });
                }
            }
        }
    }

    public class ReasignacionEventArgs : EventArgs
    {
        public string TraceId { get; set; }
        public string MesaActual { get; set; }
    }
}
