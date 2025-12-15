using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Documents.Spreadsheet.PropertySystem;

namespace Rmc.Reportes.ReportesForm
{
    public partial class FrmRptTransacciones : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string anio;
        string semana;
        string flujo;
        Worksheet ws;
        //CellStyle cellStyle;

        public FrmRptTransacciones(string anio, string semana, string flujo)
        {
            InitializeComponent();
            this.anio = anio;
            this.semana = semana;
            this.flujo = flujo;

            GenerarReporte();
        }

        private void GenerarReporte()
        {
            ws = this.radSpreadsheet1.SpreadsheetElement.Workbook.ActiveWorksheet;
            string sql = "SELECT "
                        + " flu_nombre AS FLUJO, "
                        + " CONVERT(INTEGER,pla_anio) AS ANIO, "
                        + " CONVERT(INTEGER,pla_semana) AS SEMANA, "
                        + " pla_SACA AS SACA, "
                        + " pla_producto AS PRODUCTO, "
                        + " pla_desviacion AS DESVIACION, "
                        + " pla_silueta AS SILUETA, "
                        + " pla_millstyle AS MILLSTYLE, "
                        + " pla_talla AS TALLA, "
                        + " (CONVERT(REAL,SUBSTRING ( pla_porcentaje ,0 , 3 ))/100)  AS PORCENTAJE, "
                        + " CONVERT(REAL,pla_cantidad_total) AS CANTIDADTOTAL, "
                        + " CONVERT(REAL,pla_cantidad_real) AS CANTIDADREAL, "
                        + " CONVERT(REAL,cantidad_entregada) AS CANTIDADENTREGADA, "
                        + " CONVERT(REAL,cantidad_restante) AS CANTIDADRESTANTE, "
                        + " CONVERT(REAL,pla_sobrantes) AS SOBRANTE, "
                        + " CONVERT(REAL,sobreconsumo) AS SOBRECONSUMO, "
                        + " CONVERT(REAL,ISNULL(TOTAL,0)) AS TOTAL "
                        + " FROM Pmc_View_Transacciones "
                        + " WHERE pla_anio= "+this.anio+" AND pla_semana = "+this.semana+" AND pla_flujo_id= "+this.flujo+" ";
            sc.OpenConection();
            DataTable dt = sc.DevDataTable(sql);
            sc.CloseConection();

            ws.Cells[0, 0].SetValueAsText("Flujo");
            ws.Cells[0, 1].SetValueAsText("Año");
            ws.Cells[0, 2].SetValueAsText("Semana");
            ws.Cells[0, 3].SetValueAsText("SACA");
            ws.Cells[0, 4].SetValueAsText("Producto");
            ws.Cells[0, 5].SetValueAsText("Desviación");
            ws.Cells[0, 6].SetValueAsText("Silueta");
            ws.Cells[0, 7].SetValueAsText("Millstyle");
            ws.Cells[0, 8].SetValueAsText("Talla");
            ws.Cells[0, 9].SetValueAsText("Porcentaje");
            ws.Cells[0, 10].SetValueAsText("Cantidad Plan");
            ws.Cells[0, 11].SetValueAsText("Cantidad Real");
            ws.Cells[0, 12].SetValueAsText("Entregado");
            ws.Cells[0, 13].SetValueAsText("Restante");
            ws.Cells[0, 14].SetValueAsText("Sobrante");
            ws.Cells[0, 15].SetValueAsText("Sobreconsumo");
            ws.Cells[0, 16].SetValueAsText("TOTAL");

            
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.Cells[i, j].SetValueAsText(dt.Rows[i][j].ToString());
                }
            }

        }

    }
}
