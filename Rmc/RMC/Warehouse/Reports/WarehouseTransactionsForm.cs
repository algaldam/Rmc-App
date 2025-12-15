using Rmc.Clases;
using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Warehouse.Reports
{
    public partial class WarehouseTransactionsForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;

        public WarehouseTransactionsForm()
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
            this.CargarBodegas();
        }

        private void CargarBodegas()
        {
            try
            {
                sc.OpenConection();
                sql = "SELECT  bod_id, CONCAT(bod_nombre,' - ',bod_descripcion) AS bod_nombre FROM wai_Bodegas";
                sc.LlenarDropDownList(ddlBodegas, sql, "bod_nombre", "bod_id");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnEntradasPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 1, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte de Entradas
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
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 2, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte de Entradas con Detalle
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
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 3, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte de Salidas
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
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 4, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte de Salidas con Detalle
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
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 5, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte Consolidado
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
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 6, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte de Envios
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
                sql = "EXEC usp_wai_Reporte_Entradas_Salidas '" + DtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DtpFin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', 7, '" + ddlBodegas.SelectedValue.ToString() + "'"; //Reporte de Envios con Detalle
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
