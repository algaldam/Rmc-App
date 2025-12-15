using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Warehouse
{
    public partial class InventoryReceiptForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;

        public InventoryReceiptForm()
        {
            InitializeComponent();
            LlenarLocalidad();
            LlenarBodega();
        }

        private void LlenarLocalidad() 
        {
            sc.OpenConection();
            sql = "SELECT  loc_id, loc_nombre FROM wai_Localidad";
            sc.LlenarDropDownList(ddlLocalidad, sql, "loc_nombre", "loc_id");
            sc.CloseConection();
            ddlLocalidad.SelectedIndex = 0;
        }

        private void LlenarBodega()
        {
            sc.OpenConection();
            sql = "SELECT bod_id, CONCAT(bod_nombre, ' - ', bod_descripcion) AS Nombre FROM dbo.wai_Bodegas";
            sc.LlenarDropDownList(ddlBodega, sql, "Nombre", "bod_id");
            sc.CloseConection();
            ddlBodega.SelectedIndex = 0;
        }

        //private void ddlLocalidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) //Llena el grid
        //{
        //    try
        //    {
        //        if (ddlLocalidad.SelectedIndex != -1)
        //        {
        //            LlenarGridLocalidad();
        //            txtID.Focus();
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        //}

        private void ddlLocalidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ddlLocalidad.SelectedIndex != -1)
                {
                    // Validar si se ha seleccionado una bodega
                    if (ddlBodega.SelectedValue != null && ddlBodega.SelectedValue.ToString() != "-1")
                    {
                        MessageBox.Show("La bodega seleccionada es: " + ddlBodega.SelectedItem.Text);
                        LlenarGridLocalidad();
                        txtID.Focus();
                    }

                    // Si la bodega no es 4, se llena el grid como normalmente
                    LlenarGridLocalidad();
                    txtID.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString());
            }
        }

        private void LlenarGridLocalidad()
        {
            try
            {
                sql = "SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, COUNT(PL.pac_id) AS PAQUETES, ROUND(SUM(PL.pac_libras),2) AS LIBRAS "
                            + " FROM wai_Item I INNER JOIN wai_Factura_Detalle FD ON FD.facd_item_id = I.ite_id "
                            + " INNER JOIN wai_Pack_List PL ON PL.pac_factura_detalle_id=FD.facd_id "
                            + " INNER JOIN wai_Localidad L ON L.loc_id=PL.pac_localidad_id "
                            + " WHERE L.loc_id='" + ddlLocalidad.SelectedValue.ToString() + "' AND PL.pac_scan_whout IS NULL "
                            + " GROUP BY I.ite_codigo,I.ite_descripcion "
                            + " UNION ALL SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, "
                            + " COUNT(D.dev_id) AS PAQUETES, ROUND(SUM(D.dev_libras),2) AS LIBRAS "
                            + " FROM wai_Item I INNER JOIN wai_Devoluciones D ON  I.ite_id = D.dev_item_id "
                            + " INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id "
                            + " WHERE L.loc_id = '" + ddlLocalidad.SelectedValue.ToString() + "' AND D.dev_fecha_out IS NULL GROUP BY I.ite_codigo, I.ite_descripcion";
                sc.OpenConection();
                sc.LlenarGrid(rgvDatosLocalidad, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private string LlenarPOPackID()
        {
            SqlConnection conn = sc.OpenConection();
            string resultadoTexto = "";

            string sql = @"SELECT  
                            pos_numero
                            FROM wai_Pack_List 
                            INNER JOIN wai_Factura_Detalle ON facd_id = pac_factura_detalle_id
                            INNER JOIN wai_Factura ON fac_id = facd_fac_id
                            INNER JOIN wai_POS ON pos_id = fac_pos_id
                            WHERE pac_id = @PacId";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PacId", txtID.Text.Trim());

                try
                {
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        resultadoTexto = resultado.ToString();
                        TxBPO.Text = resultadoTexto;
                    }
                    else
                    {
                        resultadoTexto = "No encontrado";
                        TxBPO.Text = resultadoTexto;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar el número de PO: " + ex.Message);
                }
            }

            sc.CloseConection();
            return resultadoTexto;
        }

        private string LlenarPOPackProvID(string pacProvId)
        {
            SqlConnection conn = sc.OpenConection();
            string resultadoTexto = "";

            string sql = @"SELECT  
                            pos_numero
                            FROM wai_Pack_List 
                            INNER JOIN wai_Factura_Detalle ON facd_id = pac_factura_detalle_id
                            INNER JOIN wai_Factura ON fac_id = facd_fac_id
                            INNER JOIN wai_POS ON pos_id = fac_pos_id
                            WHERE pac_prov_pack_id = @PacProvId";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PacProvId", pacProvId);

                try
                {
                    object resultado = cmd.ExecuteScalar();
                    resultadoTexto = resultado != null ? resultado.ToString() : "No encontrado";
                    TxBPO.Text = resultadoTexto;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar el número de PO: " + ex.Message);
                }
            }

            sc.CloseConection();
            return resultadoTexto;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
            {
                string idBod = txtID.Text.Length >= 9 ? txtID.Text.Substring(0, 8) : txtID.Text;

                string poNumero = LlenarPOPackID();           // Este método es para otras bodegas
                string poNumeroBod = LlenarPOPackProvID(idBod); // Este método es para bodega 4

                if (ddlBodega.SelectedValue != null && ddlBodega.SelectedValue.ToString() == "4")
                {
                    MessageBox.Show("Número de PO: " + poNumeroBod);
                    MessageBox.Show("La bodega seleccionada es: " + ddlBodega.SelectedItem.Text +
                                    "\nLa localidad seleccionada es: " + ddlLocalidad.SelectedItem.Text);
                    IngresoPackListBodega();
                }
                else
                {
                    MessageBox.Show("Número de PO: " + poNumero);
                    MessageBox.Show("La bodega seleccionada es: " + ddlBodega.SelectedItem.Text +
                                    "\nLa localidad seleccionada es: " + ddlLocalidad.SelectedItem.Text);
                    IngresoPackList();
                }
            }
        }

        private void IngresoPackList()
        {
            try
            {
                sql = "SELECT pac_id FROM wai_Pack_List WHERE pac_id = '" + txtID.Text.ToString() + "' AND pac_scan_whout IS NULL "; //Existe el packId pero no ha sido escaneado como salida
                sc.OpenConection(); 
                if (!sc.DevValorString(sql).Equals(""))
                {
                    sql = "SELECT COUNT(*) FROM wai_Pack_List "
                        + " WHERE pac_id = '" + txtID.Text.ToString() + "' "
                        + " AND pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "'  "; //Verifica si ya fue escaneado en esa localidad
                    if (int.Parse(sc.DevValorString(sql)) == 0)
                    {
                        sql = "SELECT COUNT(*) FROM wai_Pack_List "
                        + " WHERE pac_id = '" + txtID.Text.ToString() + "' "
                        + " AND pac_localidad_id IS NOT NULL "; // Verifica si pertenece a otra localidad
                        if (int.Parse(sc.DevValorString(sql)) > 0)
                        {
                            DialogResult confirmacion1 = MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " pertenece a otra localidad ¿Desea actualizar la localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (confirmacion1 == DialogResult.OK)
                            {
                                sql = "SELECT COUNT(*) FROM wai_Pack_List WHERE pac_id = '" + txtID.Text.ToString() + "' AND pac_scan_whin IS NULL"; //
                                if (int.Parse(sc.DevValorString(sql)) > 0)
                                {
                                    sql = "UPDATE wai_Pack_List SET pac_scan_whin=GETDATE(), pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE pac_id = '" + txtID.Text.ToString() + "' AND pac_scan_whin IS NULL";
                                    if (sc.EjecutarQuery(sql))
                                    {
                                        txtUltimoID.Text = txtID.Text.ToString();
                                        txtID.Text = String.Empty;
                                        LlenarGridLocalidad();
                                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " no puede ser escaneado, comuniquese con soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtID.Text = "";
                                        txtID.Focus();
                                    }
                                }
                                else
                                {
                                    sql = "UPDATE wai_Pack_List SET pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE pac_id = '" + txtID.Text.ToString() + "'";
                                    if (sc.EjecutarQuery(sql))
                                    {
                                        txtUltimoID.Text = txtID.Text.ToString();
                                        txtID.Text = String.Empty;
                                        LlenarGridLocalidad();
                                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " no puede ser escaneado, comuniquese con soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtID.Text = "";
                                        txtID.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            IngresoPackList2();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " ya fue escaneado en esta localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Text = "";
                        txtID.Focus();
                    }
                }
                else
                {
                    sql = "SELECT dev_id FROM wai_Devoluciones WHERE dev_codigo = '" + txtID.Text.ToString() + "' AND dev_fecha_out IS NULL ";
                    sc.OpenConection();
                    if (!sc.DevValorString(sql).Equals(""))
                    {
                        sql = "SELECT COUNT(*) FROM wai_Devoluciones "
                        + " WHERE dev_codigo = '" + txtID.Text.ToString() + "' "
                        + " AND dev_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "'  ";
                        if (int.Parse(sc.DevValorString(sql)) == 0)
                        {
                            sql = "SELECT COUNT(*) FROM wai_Devoluciones "
                            + " WHERE dev_codigo = '" + txtID.Text.ToString() + "' "
                            + " AND dev_localidad_id IS NOT NULL ";
                            if (int.Parse(sc.DevValorString(sql)) > 0)
                            {
                                DialogResult confirmacion1 = MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " pertenece a otra localidad ¿Desea actualizar la localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (confirmacion1 == DialogResult.OK)
                                {
                                    sql = "UPDATE wai_Devoluciones SET dev_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE dev_codigo = '" + txtID.Text.ToString() + "'";
                                    if (sc.EjecutarQuery(sql))
                                    {
                                        txtUltimoID.Text = txtID.Text.ToString();
                                        txtID.Text = String.Empty;
                                        LlenarGridLocalidad();
                                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                                    }
                                }
                            }
                            else
                                IngresoPackList3();
                        }
                        else
                        {
                            MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " ya fue escaneado en esta localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtID.Text = "";
                            txtID.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " no existe en el sistema o ya fue dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Text = "";
                        txtID.Focus();
                    }
                }
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void IngresoPackListBodega()
        {
            try
            {
                string idBod = txtID.Text.Length >= 9 ? txtID.Text.Substring(0, 8) : txtID.Text; //Variable temporal

                sql = "SELECT pac_prov_pack_id FROM wai_Pack_List WHERE pac_prov_pack_id = '" + idBod + "' AND pac_scan_whout IS NULL ";
                sc.OpenConection();
                if (!sc.DevValorString(sql).Equals(""))
                {
                    sql = "SELECT COUNT(*) FROM wai_Pack_List "
                        + " WHERE pac_prov_pack_id = '" + idBod + "' "
                        + " AND pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "'  ";
                    if (int.Parse(sc.DevValorString(sql)) == 0)
                    {
                        sql = "SELECT COUNT(*) FROM wai_Pack_List "
                        + " WHERE pac_prov_pack_id = '" + idBod + "' "
                        + " AND pac_localidad_id IS NOT NULL ";
                        if (int.Parse(sc.DevValorString(sql)) > 0)
                        {
                            DialogResult confirmacion1 = MessageBox.Show("El Pack ID " + idBod + " pertenece a otra localidad ¿Desea actualizar la localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (confirmacion1 == DialogResult.OK)
                            {
                                sql = "SELECT COUNT(*) FROM wai_Pack_List WHERE pac_prov_pack_id = '" + idBod + "' AND pac_scan_whin IS NULL";
                                if (int.Parse(sc.DevValorString(sql)) > 0)
                                {
                                    sql = "UPDATE wai_Pack_List SET pac_scan_whin=GETDATE(), pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE pac_prov_pack_id = '" + idBod + "' AND pac_scan_whin IS NULL";
                                    if (sc.EjecutarQuery(sql))
                                    {
                                        txtUltimoID.Text = idBod;
                                        txtID.Text = String.Empty;
                                        LlenarGridLocalidad();
                                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El Pack ID " + idBod + " no puede ser escaneado, comuniquese con soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtID.Text = "";
                                        txtID.Focus();
                                    }
                                }
                                else
                                {
                                    sql = "UPDATE wai_Pack_List SET pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE pac_prov_pack_id = '" + idBod + "'";
                                    if (sc.EjecutarQuery(sql))
                                    {
                                        txtUltimoID.Text = idBod;
                                        txtID.Text = String.Empty;
                                        LlenarGridLocalidad();
                                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El Pack ID " + idBod + " no puede ser escaneado, comuniquese con soporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtID.Text = "";
                                        txtID.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            IngresoPackList2Bodega();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Pack ID " + idBod + " ya fue escaneado en esta localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Text = "";
                        txtID.Focus();
                    }
                }
                else
                {
                    sql = "SELECT dev_id FROM wai_Devoluciones WHERE dev_codigo = '" + idBod + "' AND dev_fecha_out IS NULL ";
                    sc.OpenConection();
                    if (!sc.DevValorString(sql).Equals(""))
                    {
                        sql = "SELECT COUNT(*) FROM wai_Devoluciones "
                        + " WHERE dev_codigo = '" + idBod + "' "
                        + " AND dev_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "'  ";
                        if (int.Parse(sc.DevValorString(sql)) == 0)
                        {
                            sql = "SELECT COUNT(*) FROM wai_Devoluciones "
                            + " WHERE dev_codigo = '" + idBod + "' "
                            + " AND dev_localidad_id IS NOT NULL ";
                            if (int.Parse(sc.DevValorString(sql)) > 0)
                            {
                                DialogResult confirmacion1 = MessageBox.Show("El Pack ID " + idBod + " pertenece a otra localidad ¿Desea actualizar la localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (confirmacion1 == DialogResult.OK)
                                {
                                    sql = "UPDATE wai_Devoluciones SET dev_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE dev_codigo = '" + idBod + "'";
                                    if (sc.EjecutarQuery(sql))
                                    {
                                        txtUltimoID.Text = idBod;
                                        txtID.Text = String.Empty;
                                        LlenarGridLocalidad();
                                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                                    }
                                }
                            }
                            else
                                IngresoPackList3();
                        }
                        else
                        {
                            MessageBox.Show("El Pack ID " + idBod + " ya fue escaneado en esta localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtID.Text = "";
                            txtID.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Pack ID " + idBod + " no existe en el sistema o ya fue dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Text = "";
                        txtID.Focus();
                    }
                }
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        public void IngresoPackList2()
        {
            try
            {
                sql = "UPDATE wai_Pack_List SET pac_scan_whin=GETDATE(), pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE pac_id = '" + txtID.Text.ToString() + "'";
                if (sc.EjecutarQuery(sql))
                {
                    txtUltimoID.Text = txtID.Text.ToString();
                    txtID.Text = String.Empty;
                    LlenarGridLocalidad();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        public void IngresoPackList2Bodega()
        {
            try
            {
                string idBod2 = txtID.Text.Length >= 9 ? txtID.Text.Substring(0, 8) : txtID.Text; //Variable temporal

                sql = "UPDATE wai_Pack_List SET pac_scan_whin=GETDATE(), pac_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE  pac_prov_pack_id = '" + idBod2 + "'";
                if (sc.EjecutarQuery(sql))
                {
                    txtUltimoID.Text = txtID.Text.ToString();
                    txtID.Text = String.Empty;
                    LlenarGridLocalidad();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        public void IngresoPackList3()
        {
            try
            {
                sql = "UPDATE wai_Devoluciones SET dev_localidad_id = '" + ddlLocalidad.SelectedValue.ToString() + "' WHERE dev_codigo = '" + txtID.Text.ToString() + "'";
                if (sc.EjecutarQuery(sql))
                {
                    txtUltimoID.Text = txtID.Text.ToString();
                    txtID.Text = String.Empty;
                    LlenarGridLocalidad();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void InventoryReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
