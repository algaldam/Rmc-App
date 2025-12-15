using Rmc.Clases;
using Rmc.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Warehouse.Reports
{
    public partial class WarehouseReportForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;
        DataTable datosProv = new DataTable();
        BodegaController BControl = new BodegaController();

        public WarehouseReportForm()
        {
            InitializeComponent();
            this.CargarBodegas();
            rgvDetalle.MultiSelect = true;
            rgvDetalle.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvDetalle.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            rgvDetalle2.MultiSelect = true;
            rgvDetalle2.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvDetalle2.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }
        private void CargarBodegas()
        {
            sc.OpenConection();
            sql = "SELECT  bod_id, CONCAT(bod_nombre,' - ',bod_descripcion) AS bod_nombre FROM wai_Bodegas";
            sc.LlenarDropDownList(ddlBodegas, sql, "bod_nombre", "bod_id");
            sc.CloseConection();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                rgvDetalle.Visible = true;
                rgvDetalle2.Visible = false;
                rgvProveedor.Visible = false;
                GRID_VIEW_PACK.Visible = false;
                sql = "SELECT * FROM (SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
                    + " ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS FROM wai_Item I "
                    + " INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id "
                    + " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0) AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' "
                    + " GROUP BY I.ite_codigo, I.ite_descripcion "
                    + " UNION ALL "
                    + " SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
                    + " ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS "
                    + " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id "
                    + " INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' "
                    + " GROUP BY I.ite_codigo, I.ite_descripcion)  AS AUX "
                    + " WHERE AUX.LIBRAS >0 ORDER BY CODIGO ";
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[0].IsVisible = false;
                rgvDetalle.Columns[1].IsVisible = true;
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = false;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = false;
                rgvDetalle.BringToFront();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void btnInventarioLocalidades_Click(object sender, EventArgs e)
        {
            try
            {
                rgvDetalle.Visible = true;
                rgvDetalle2.Visible = false;
                rgvProveedor.Visible = false;
                GRID_VIEW_PACK.Visible = false;
                sql = "SELECT * FROM (SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
                    + " COUNT(PL.pac_id) AS PAQUETES, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS "
                    + " FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id "
                    + " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' "
                    + " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion "
                    + " UNION ALL "
                    + " SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
                    + " COUNT(D.dev_id) AS PAQUETES, ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS "
                    + " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id "
                    + " WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion)  AS AUX "
                    + " WHERE AUX.LIBRAS >0 ORDER BY LOCALIDAD, CODIGO, DESCRIPCION ";
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[0].IsVisible = true;
                rgvDetalle.Columns[1].IsVisible = true;
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = true;
                rgvDetalle.Columns[4].IsVisible = false;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = false;
                rgvDetalle.BringToFront();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void btnInventarioLocalidadesDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                rgvDetalle.Visible = true;
                rgvDetalle2.Visible = false;
                rgvProveedor.Visible = false;
                GRID_VIEW_PACK.Visible = false;
                sql = "SELECT * FROM (SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,  CONVERT(VARCHAR,PL.pac_id) AS PACKID,"
                    + " ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS, PL.pac_scan_whin  AS FECHAINGRESO FROM wai_Item I "
                    + " INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id "
                    + " INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' "
                    + " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, PL.pac_id, PL.pac_scan_whin "
                    + " UNION ALL "
                    + " SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION,D.dev_codigo AS PACKID, "
                    + " ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS, D.dev_fecha_in AS FECHAINGRESO "
                    + " FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id "
                    + " INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' "
                    + " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, D.dev_codigo, D.dev_fecha_in)  AS AUX "
                    + " WHERE AUX.LIBRAS >0 ORDER BY PACKID ";
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle.Columns[0].IsVisible = true;
                rgvDetalle.Columns[1].IsVisible = true;
                rgvDetalle.Columns[2].IsVisible = true;
                rgvDetalle.Columns[3].IsVisible = false;
                rgvDetalle.Columns[4].IsVisible = true;
                rgvDetalle.Columns[5].IsVisible = true;
                rgvDetalle.Columns[6].IsVisible = true;
                rgvDetalle.BringToFront();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void btnInventarioAntiguedad_Click(object sender, EventArgs e)
        {
            try
            {
                rgvDetalle.Visible = false;
                rgvDetalle2.Visible = true;
                rgvProveedor.Visible = false;
                GRID_VIEW_PACK.Visible = false;
                sql = "SELECT *, CASE WHEN CATEGORIA = 'D' THEN 'More than 12 Months' ELSE CASE WHEN CATEGORIA = 'C' THEN 'Between 9 and 12 Months' ELSE "
                    + " CASE WHEN CATEGORIA = 'B' THEN 'Between 6 and 9 Months' ELSE 'Less than 6 Months' END END END AS LEYENDA FROM (SELECT CONVERT(VARCHAR,PL.pac_id) AS PACKID, "
                    + " I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS, FD.facd_lote AS LOTE, "
                    + " PL.pac_scan_whin  AS FECHAINGRESO, DATEDIFF(D,PL.pac_scan_whin,GETDATE()) AS DIAS, CASE WHEN DATEDIFF(D,PL.pac_scan_whin,GETDATE()) > 365 THEN 'D' ELSE "
                    + " CASE WHEN DATEDIFF(D,PL.pac_scan_whin,GETDATE()) > 270 THEN 'C' ELSE CASE WHEN DATEDIFF(D,PL.pac_scan_whin,GETDATE()) > 180 THEN 'B' ELSE 'A' "
                    + " END END END AS CATEGORIA FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id "
                    + " INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id WHERE PL.pac_libras > ISNULL(PL.pac_libras_salida,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' "
                    + " AND PL.pac_scan_whin IS NOT NULL GROUP BY I.ite_codigo, I.ite_descripcion, FD.facd_lote, PL.pac_id, PL.pac_scan_whin "
                    + " UNION ALL "
                    + " SELECT D.dev_codigo AS PACKID, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
                    + " ROUND(SUM(D.dev_libras- ISNULL(D.dev_libras_out,0)),2) AS LIBRAS, D.dev_lote AS LOTE, D.dev_fecha_in AS FECHAINGRESO, "
                    + " DATEDIFF(D, D.dev_fecha_in, GETDATE())  AS DIAS, CASE WHEN DATEDIFF(D, D.dev_fecha_in, GETDATE()) > 365 THEN 'D' ELSE "
                    + " CASE WHEN DATEDIFF(D, D.dev_fecha_in, GETDATE()) > 270 THEN 'C' ELSE CASE WHEN DATEDIFF(D, D.dev_fecha_in, GETDATE()) > 180 THEN 'B' ELSE 'A' "
                    + " END END END AS CATEGORIA FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id "
                    + " WHERE D.dev_libras > ISNULL(D.dev_libras_out,0)  AND I.ite_bodega_id = '" + ddlBodegas.SelectedValue.ToString() + "' GROUP BY I.ite_codigo, I.ite_descripcion, D.dev_lote, D.dev_codigo, D.dev_fecha_in)  AS AUX "
                    + " WHERE AUX.LIBRAS >0 ORDER BY DIAS DESC ";
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvDetalle2, sql, "x", "x");
                sc.CloseConection();
                rgvDetalle2.BringToFront();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void rgvDetalle_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

        }

        private void rgvDetalle2_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

        }

        private void btnInvProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                rgvProveedor.Visible = true;
                rgvDetalle.Visible = false;
                rgvDetalle2.Visible = false;
                GRID_VIEW_PACK.Visible = false;

                rgvProveedor.DataSource = BControl.ObtenerIventarioProveedor(Convert.ToInt32(ddlBodegas.SelectedValue.ToString()));
                rgvProveedor.BringToFront();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_PACK_PROVEEDOR_Click(object sender, EventArgs e)
        {
            try
            {
                GRID_VIEW_PACK.Visible = true;
                rgvProveedor.Visible = false;
                rgvDetalle.Visible = false;
                rgvDetalle2.Visible = false;
                GRID_VIEW_PACK.DataSource = BControl.ObtenerPackProveedor(Convert.ToInt32(ddlBodegas.SelectedValue.ToString()));
                GRID_VIEW_PACK.BringToFront();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
