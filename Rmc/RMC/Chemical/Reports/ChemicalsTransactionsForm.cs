using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Chemical.Reports
{
    public partial class ChemicalsTransactionsForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;
        private string warehouseChemical = "3";

        public ChemicalsTransactionsForm()
        {
            InitializeComponent();
            sc.formarDatedMyHms(this.DtpInicio);
            sc.formarDatedMyHms(this.DtpFin);
            rgvDetalle.MultiSelect = true;
            rgvDetalle.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvDetalle.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            rgvDetalle.MultiSelect = true;
            rgvDetalle.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvDetalle.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        private void btnEntradasPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 1, '" + this.warehouseChemical.ToString() + "'"; //Reporte de Entradas
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = false;
                rgvDetalle.Columns[6].IsVisible = false;
                rgvDetalle.Columns[7].IsVisible = false;
                rgvDetalle.Columns[8].IsVisible = false;
                rgvDetalle.Columns[9].IsVisible = false;
                rgvDetalle.Columns[10].IsVisible = false;
                rgvDetalle.Columns[11].IsVisible = false;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnEntradasPeriodoDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 2, '" + this.warehouseChemical.ToString() + "'"; //Reporte de Entradas con Detalle
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = true;
                rgvDetalle.Columns[7].IsVisible = false;
                rgvDetalle.Columns[8].IsVisible = false;
                rgvDetalle.Columns[9].IsVisible = false;
                rgvDetalle.Columns[10].IsVisible = false;
                rgvDetalle.Columns[11].IsVisible = false;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnSalidasPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 3, '" + this.warehouseChemical.ToString() + "'"; //Reporte de Salidas
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = true;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = false;
                rgvDetalle.Columns[7].IsVisible = false;
                rgvDetalle.Columns[8].IsVisible = false;
                rgvDetalle.Columns[9].IsVisible = false;
                rgvDetalle.Columns[10].IsVisible = false;
                rgvDetalle.Columns[11].IsVisible = false;

                foreach (GridViewDataRowInfo r in rgvDetalle.Rows)
                {
                    double oz = Math.Round(((float.Parse(r.Cells[3].Value.ToString()) % 1) * 16), 0);
                    string onzas = "";
                    if (oz < 10)
                        onzas = "0" + oz.ToString();
                    else
                        onzas = oz.ToString();

                    r.Cells[4].Value = (Math.Floor(float.Parse(r.Cells[3].Value.ToString())).ToString()) + "." + onzas;
                }

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnSalidasPeriodoDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 4, '" + this.warehouseChemical.ToString() + "'"; //Reporte de Salidas con Detalle
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = true;
                rgvDetalle.Columns[7].IsVisible = true;
                rgvDetalle.Columns[8].IsVisible = false;
                rgvDetalle.Columns[9].IsVisible = false;
                rgvDetalle.Columns[10].IsVisible = false;
                rgvDetalle.Columns[11].IsVisible = false;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }

        }

        private void btnConsolidadoEntradasSalidas_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 5, '" + this.warehouseChemical.ToString() + "'"; //Reporte Consolidado
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = false;
                rgvDetalle.Columns[3].IsVisible = false;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = false;
                rgvDetalle.Columns[6].IsVisible = false;
                rgvDetalle.Columns[7].IsVisible = false;
                rgvDetalle.Columns[8].IsVisible = true;
                rgvDetalle.Columns[9].IsVisible = true;
                rgvDetalle.Columns[10].IsVisible = true;
                rgvDetalle.Columns[11].IsVisible = true;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void rgvDetalle_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            rgvDetalle.GridNavigator.SelectAll();
        }

        private void btnEnvios_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 6, '" + this.warehouseChemical.ToString() + "'"; //Reporte de Envios
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = true;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = false;
                rgvDetalle.Columns[7].IsVisible = false;
                rgvDetalle.Columns[8].IsVisible = false;
                rgvDetalle.Columns[9].IsVisible = false;
                rgvDetalle.Columns[10].IsVisible = false;
                rgvDetalle.Columns[11].IsVisible = false;
                foreach (GridViewDataRowInfo r in rgvDetalle.Rows)
                {
                    double oz = Math.Round(((float.Parse(r.Cells[3].Value.ToString()) % 1) * 16), 0);
                    string onzas = "";
                    if (oz < 10)
                        onzas = "0" + oz.ToString();
                    else
                        onzas = oz.ToString();

                    r.Cells[4].Value = (Math.Floor(float.Parse(r.Cells[3].Value.ToString())).ToString()) + "." + onzas;
                }

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnEnviosDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 7, '" + this.warehouseChemical.ToString() + "'"; //Reporte de Envios con Detalle
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = true;
                rgvDetalle.Columns[7].IsVisible = true;
                rgvDetalle.Columns[8].IsVisible = false;
                rgvDetalle.Columns[9].IsVisible = false;
                rgvDetalle.Columns[10].IsVisible = false;
                rgvDetalle.Columns[11].IsVisible = false;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
