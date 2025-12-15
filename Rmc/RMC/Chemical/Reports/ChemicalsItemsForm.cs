using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.RMC.Chemical.Reports
{
    public partial class ChemicalsItemsForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;

        int warehouseChemical = 3;

        public ChemicalsItemsForm()
        {
            InitializeComponent();
            sc.ApplyComparer(ddlIChemicaltem);

            LlenarItem(warehouseChemical);
            ddlIChemicaltem.SelectedIndex = 0;
        }

        private void LlenarItem(int bodega)
        {
            try
            {
                sql = "SELECT I.ite_id, CONCAT(I.ite_codigo,' - ',I.ite_descripcion) AS item " +
                      "FROM wai_Item AS I " +
                      "INNER JOIN wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id " +
                      "INNER JOIN wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id " +
                      "WHERE I.ite_bodega_id = '" + bodega + "' AND PL.pac_scan_whin IS NOT NULL " +
                      "AND PL.pac_scan_whout IS NULL " +
                      "GROUP BY I.ite_id, I.ite_codigo, I.ite_descripcion " +
                      "ORDER BY I.ite_codigo";

                sc.LlenarDropDownList(ddlIChemicaltem, sql, "item", "ite_id");
                ddlIChemicaltem.DropDownListElement.DropDownWidth = 350;
                ddlIChemicaltem.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString());
            }
        }

        private void btnTotalArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlIChemicaltem.SelectedIndex > -1)
                {
                    sql = "SELECT * FROM (SELECT L.loc_nombre AS LOCALIDAD, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS " +
                          "FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id " +
                          "INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id " +
                          "INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id " +
                          "WHERE I.ite_id = " + ddlIChemicaltem.SelectedValue.ToString() + " GROUP BY L.loc_nombre " +
                          "UNION ALL " +
                          "SELECT L.loc_nombre AS LOCALIDAD, ROUND((SUM(D.dev_libras - ISNULL(D.dev_libras,0))),2) AS LIBRAS " +
                          "FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id " +
                          "INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id " +
                          "WHERE I.ite_id = " + ddlIChemicaltem.SelectedValue.ToString() + " GROUP BY L.loc_nombre) AS AUX " +
                          "WHERE AUX.LIBRAS > 0";

                    Console.WriteLine(sql);
                    sc.OpenConection();
                    sc.LlenarGrid(rgvDetalleChemicals, sql, "x", "x");
                    sc.CloseConection();

                    rgvDetalleChemicals.Columns[0].IsVisible = true;
                    rgvDetalleChemicals.Columns[1].IsVisible = false;
                    rgvDetalleChemicals.Columns[2].IsVisible = false;
                    rgvDetalleChemicals.Columns[3].IsVisible = false;
                    rgvDetalleChemicals.Columns[4].IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString());
            }
        }

        private void btnReporteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlIChemicaltem.SelectedIndex > -1)
                {
                    sql = "SELECT * FROM (SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, " +
                          "CONVERT(VARCHAR, PL.pac_id) AS PACKID, ROUND((SUM(PL.pac_libras - ISNULL(PL.pac_libras_salida,0))),2) AS LIBRAS " +
                          "FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id " +
                          "INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id = FD.facd_id " +
                          "INNER JOIN wai_Localidad L ON L.loc_id = PL.pac_localidad_id " +
                          "WHERE I.ite_id = " + ddlIChemicaltem.SelectedValue.ToString() +
                          " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, PL.pac_id " +
                          "UNION ALL " +
                          "SELECT L.loc_nombre AS LOCALIDAD, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, " +
                          "D.dev_codigo AS PACKID, ROUND(SUM(D.dev_libras - ISNULL(D.dev_libras_out,0)),2) AS LIBRAS " +
                          "FROM wai_Item I INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id " +
                          "INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id " +
                          "WHERE I.ite_id = " + ddlIChemicaltem.SelectedValue.ToString() +
                          " GROUP BY L.loc_nombre, I.ite_codigo, I.ite_descripcion, D.dev_codigo) AS AUX " +
                          "WHERE AUX.LIBRAS > 0 ORDER BY PACKID";

                    Console.WriteLine(sql);
                    sc.OpenConection();
                    sc.LlenarGrid(rgvDetalleChemicals, sql, "x", "x");
                    sc.CloseConection();

                    rgvDetalleChemicals.Columns[0].IsVisible = true;
                    rgvDetalleChemicals.Columns[1].IsVisible = true;
                    rgvDetalleChemicals.Columns[2].IsVisible = true;
                    rgvDetalleChemicals.Columns[3].IsVisible = true;
                    rgvDetalleChemicals.Columns[4].IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString());
            }
        }
    }
}
