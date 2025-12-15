using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Warehouse
{
    public partial class ShipmentsForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;

        public ShipmentsForm()
        {
            InitializeComponent();
            CargarBodegas();
            sc.ApplyComparer(ddlItem);
            ddlItem.SelectedIndex = -1;
        }

        private void CargarBodegas()
        {
            sc.OpenConection();
            sql = "SELECT  bod_id, CONCAT(bod_nombre,' - ',bod_descripcion) AS bod_nombre FROM wai_Bodegas";
            sc.LlenarDropDownList(ddlBodegas, sql, "bod_nombre", "bod_id");
            sc.CloseConection();
        }


        private void LlenarItem(int bodega)
        {
            try
            {
                sql = " SELECT DISTINCT(ite_id), item  FROM(SELECT I.ite_id, CONCAT(I.ite_codigo,' - ',I.ite_descripcion) AS item" +
                      " FROM wai_Item AS I                                                                                                " +
                      " INNER JOIN wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id                                                " +
                      " INNER JOIN wai_Pack_List AS PL ON PL.pac_factura_detalle_id = FD.facd_id                                          " +
                      " WHERE ite_bodega_id =" + bodega + " AND PL.pac_scan_whin IS NOT NULL  AND PL.pac_scan_whout IS NULL               " +
                      " GROUP BY ite_id, I.ite_codigo,I.ite_descripcion                                                                   " +
                      " UNION ALL                                                                                                         " +
                      " SELECT I.ite_id, CONCAT(I.ite_codigo,' - ',I.ite_descripcion) AS item                                             " +
                      " FROM wai_Item I                                                                                                   " +
                      " INNER JOIN wai_Devoluciones D ON D.dev_item_id = I.ite_id                                                         " +
                      " WHERE (D.dev_libras - ISNULL(D.dev_libras_out,0))>0 AND D.dev_fecha_in IS NOT NULL) AUX                           " +
                      " ORDER BY item                                                                                                     ";

                sc.LlenarDropDownList(ddlItem, sql, "item", "ite_id");
                this.ddlItem.DropDownListElement.DropDownWidth = 350;
                ddlItem.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void ddlBodegas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlBodegas.SelectedIndex != -1)
            {
                this.LlenarItem(Int32.Parse(ddlBodegas.SelectedValue.ToString()));
            }
        }

        private void ddlItem_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ddlItem.SelectedIndex != -1)
                {
                    LlenarGridPackList();
                    txtID.Focus();
                }
                else
                {
                    rgvPackList.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void LlenarGridPackList()
        {
            try
            {
                sql = "SELECT CONVERT(VARCHAR, PL.pac_id) AS PACK_ID, L.loc_nombre AS LOCALIDAD, FD.facd_lote AS LOTE, FD.facd_prioridad AS PRIORIDAD, ROUND((ISNULL((PL.pac_libras - ISNULL(PL.pac_libras_salida,0)), 0)),2) AS PESO, "
                        + " PL.pac_fecha_produccion AS FECHA_PRODUCCION, PL.pac_scan_whin AS FECHA_ENTRADA, PO.pos_semana AS SEMANA "
                        + " FROM wai_Item AS I INNER JOIN wai_Factura_Detalle AS FD ON FD.facd_item_id = I.ite_id INNER JOIN wai_Factura AS F ON F.fac_id = FD.facd_fac_id "
                        + " INNER JOIN wai_POS AS PO ON PO.pos_id = F.fac_pos_id INNER JOIN wai_Pack_List AS PL ON PL.pac_factura_detalle_id=FD.facd_id INNER JOIN wai_Localidad AS L ON L.loc_id=PL.pac_localidad_id "
                        + " WHERE I.ite_id='" + ddlItem.SelectedValue.ToString() + "'  AND (PL.pac_No_Conformidad=0 OR PL.pac_No_Conformidad IS NULL) AND PL.pac_scan_whin IS NOT NULL AND PL.pac_scan_whout IS NULL AND ISNULL((PL.pac_libras - ISNULL(PL.pac_libras_salida,0)),0) > 0 "
                        + " UNION ALL "
                        + " SELECT D.dev_codigo AS PACK_ID, L.loc_nombre AS LOCALIDAD, D.dev_lote AS LOTE, D.dev_prioridad AS PRIORIDAD, ROUND((D.dev_libras - ISNULL(D.dev_libras_out,0)),2) AS PESO, "
                        + " '', D.dev_fecha_in AS FECHA_ENTRADA, '' FROM wai_Item AS I "
                        + " INNER JOIN wai_Devoluciones AS D ON D.dev_item_id = I.ite_id "
                        + " INNER JOIN wai_Localidad AS L ON L.loc_id = D.dev_localidad_id "
                        + " LEFT JOIN wai_Transacciones_Devoluciones AS TD ON TD.tra_dev_dev_id = D.dev_id "
                        + " WHERE I.ite_id='" + ddlItem.SelectedValue.ToString() + "' AND (D.dev_No_Conformidad=0 OR D.dev_No_Conformidad IS NULL)  AND D.dev_fecha_out IS NULL AND ISNULL((D.dev_libras - ISNULL(D.dev_libras_out,0)),0) > 0"
                        + " GROUP BY D.dev_codigo, L.loc_nombre, D.dev_lote, D.dev_prioridad, D.dev_libras, D.dev_libras_out, D.dev_fecha_in "
                        + " HAVING (D.dev_libras > SUM(ISNULL(tra_dev_libras,0))) "
                        + " ORDER BY PACK_ID";

                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(rgvPackList, sql, "x", "x");
                sc.CloseConection();

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
            {
                if (!txtID.Text.ToString().Equals(""))
                {
                    // Verifica si hay una bodega seleccionada
                    if (ddlBodegas.SelectedValue != null)
                    {
                        int bodegaSeleccionada;
                        if (int.TryParse(ddlBodegas.SelectedValue.ToString(), out bodegaSeleccionada))
                        {
                            if (bodegaSeleccionada == 4)
                                SalidaPackListBod(); // Si la bodega es 4
                            else
                                SalidaPackList();    // Si es cualquier otra bodega
                        }
                        else
                        {
                            MessageBox.Show("La bodega seleccionada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una bodega.", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("El PACK ID no puede estar vacío", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SalidaPackList()
        {
            try
            {
                // 3: Salida por Envio
                sql = "EXEC usp_wai_Transacciones_CRUD '" + sc.Usuario + "', '3', '" + txtID.Text.ToString() + "', '', '" + ddlItem.SelectedValue.ToString() + "' , '" + 0 + "'";
                Console.WriteLine(sql);
                sc.OpenConection();
                string resultado = sc.DevValorString(sql);
                sc.CloseConection();
                if (resultado == "NOCOINCIDE")
                {
                    MessageBox.Show("El PACK ID no pertenece al Item seleccionado", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado == "NOENCONTRADO")
                {
                    MessageBox.Show("El PACK ID ingresado no existe en el sistema", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado == "OK")
                {
                    txtUltimoID.Text = txtID.Text.ToString();
                    txtID.Text = String.Empty;
                    LlenarGridPackList();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                }
                else
                {
                    MessageBox.Show("Ocurrio un problema con el servidor, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                sql = "SELECT COUNT(*) FROM wai_Pack_List PL INNER JOIN wai_Factura_Detalle FD ON FD.facd_id = PL.pac_factura_detalle_id "
                    + " WHERE FD.facd_item_id='" + ddlItem.SelectedValue.ToString() + "' AND FD.facd_prioridad=1 AND (PL.pac_libras - ISNULL(PL.pac_libras_salida,0)) > 0 "
                    + " AND PL.pac_scan_whin IS NOT NULL";

                sc.OpenConection();
                resultado = sc.DevValorString(sql);
                sc.CloseConection();

                if (int.Parse(resultado) == 0)
                {
                    sc.OpenConection();
                    sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','R','','','',''";
                    resultado = sc.DevValorString(sql);
                    sc.CloseConection();

                    sc.OpenConection();
                    sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','A','','','',''";
                    resultado = sc.DevValorString(sql);
                    sc.CloseConection();
                    LlenarGridPackList();

                }
                txtID.Focus();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void SalidaPackListBod()
        {
            try
            {
                // 3: Salida por Envio
                sql = "EXEC usp_wai_TransaccionesProv_CRUD '" + sc.Usuario + "', '3', '" + txtID.Text.ToString() + "', '', '" + ddlItem.SelectedValue.ToString() + "' , '" + 0 + "'";
                Console.WriteLine(sql);
                sc.OpenConection();
                string resultado = sc.DevValorString(sql);
                sc.CloseConection();
                if (resultado == "NOCOINCIDE")
                {
                    MessageBox.Show("El PACK ID no pertenece al Item seleccionado", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado == "NOENCONTRADO")
                {
                    MessageBox.Show("El PACK ID ingresado no existe en el sistema", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado == "OK")
                {
                    txtUltimoID.Text = txtID.Text.ToString();
                    txtID.Text = String.Empty;
                    LlenarGridPackList();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                }
                else
                {
                    MessageBox.Show("Ocurrio un problema con el servidor, comuniquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                sql = "SELECT COUNT(*) FROM wai_Pack_List PL INNER JOIN wai_Factura_Detalle FD ON FD.facd_id = PL.pac_factura_detalle_id "
                    + " WHERE FD.facd_item_id='" + ddlItem.SelectedValue.ToString() + "' AND FD.facd_prioridad=1 AND (PL.pac_libras - ISNULL(PL.pac_libras_salida,0)) > 0 "
                    + " AND PL.pac_scan_whin IS NOT NULL";

                sc.OpenConection();
                resultado = sc.DevValorString(sql);
                sc.CloseConection();

                if (int.Parse(resultado) == 0)
                {
                    sc.OpenConection();
                    sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','R','','','',''";
                    resultado = sc.DevValorString(sql);
                    sc.CloseConection();

                    sc.OpenConection();
                    sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','A','','','',''";
                    resultado = sc.DevValorString(sql);
                    sc.CloseConection();
                    LlenarGridPackList();

                }
                txtID.Focus();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
