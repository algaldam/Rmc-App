using Rmc.Clases;
using System;
using System.Windows.Forms;

namespace Rmc.RMC.Warehouse.Transactions
{
    public partial class ProductionDateForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;

        public ProductionDateForm()
        {
            InitializeComponent();
            LlenarGrid();
            dtpFecha.Culture = new System.Globalization.CultureInfo("en-GB");
            dtpFecha.CustomFormat = "dd-MM-yyy";
            dtpFecha.Value = DateTime.Now;
            LlenarBodega();
        }

        private void LlenarBodega()
        {
            sc.OpenConection();
            sql = "SELECT bod_id, CONCAT(bod_nombre, ' - ', bod_descripcion) AS Nombre FROM dbo.wai_Bodegas";
            sc.LlenarDropDownList(ddlBodegas, sql, "Nombre", "bod_id");
            sc.CloseConection();
            ddlBodegas.SelectedIndex = 0;
        }

        private void LlenarGrid()
        {
            try
            {
                sql = "SELECT I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION, PL.pac_id AS PACKID FROM wai_Pack_List PL "
                    + " INNER JOIN wai_Factura_Detalle FD ON FD.facd_id = PL.pac_factura_detalle_id INNER JOIN wai_Item I ON I.ite_id=FD.facd_item_id "
                    + " WHERE PL.pac_fecha_produccion IS  NULL ORDER BY PACKID";
                sc.OpenConection();
                sc.LlenarGrid(rgvPackID, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
            {
                // Obtener el bod_id seleccionado
                int bodegaSeleccionada;
                if (int.TryParse(ddlBodegas.SelectedValue.ToString(), out bodegaSeleccionada))
                {
                    if (bodegaSeleccionada == 4)
                        UpdateFechaProduccionBod(); // Si la bodega es 4
                    else
                        UpdateFechaProduccion();    // Si es cualquier otra bodega
                }
            }
        }

        private void UpdateFechaProduccion()
        {
            try
            {
                sql = "SELECT pac_id FROM wai_Pack_List WHERE pac_id = '" + txtID.Text.ToString() + "'";
                sc.OpenConection();
                if (!sc.DevValorString(sql).Equals(""))
                {
                    sql = "SELECT COUNT(*) FROM wai_Pack_List WHERE pac_id = '" + txtID.Text.ToString() + "' AND pac_fecha_produccion IS NULL  ";
                    if (int.Parse(sc.DevValorString(sql)) > 0)
                    {

                        sql = "UPDATE wai_Pack_List SET pac_fecha_produccion = '" + dtpFecha.Value.ToString("yyy-MM-dd") + "' "
                            + " WHERE pac_id = '" + txtID.Text.ToString() + "'";
                        sc.OpenConection();
                        if (!sc.EjecutarQuery(sql))
                        {
                            MessageBox.Show("No se puede asignar una fecha de producción al Pack ID " + txtID.Text.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Se asigno la fecha de producción al Pack ID " + txtID.Text.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        sc.CloseConection();

                        txtUltimoID.Text = txtID.Text.ToString();
                        txtID.Text = String.Empty;
                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                        LlenarGrid();
                    }
                    else
                    {
                        MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " ya tiene fecha de producción asignada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " no existe en el sistema o ya fue dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void UpdateFechaProduccionBod()
        {
            try
            {
                sql = "SELECT pac_prov_pack_id FROM wai_Pack_List WHERE pac_prov_pack_id = '" + txtID.Text.ToString() + "'";
                sc.OpenConection();
                if (!sc.DevValorString(sql).Equals(""))
                {
                    sql = "SELECT COUNT(*) FROM wai_Pack_List WHERE pac_prov_pack_id = '" + txtID.Text.ToString() + "' AND pac_fecha_produccion IS NULL  ";
                    if (int.Parse(sc.DevValorString(sql)) > 0)
                    {

                        sql = "UPDATE wai_Pack_List SET pac_fecha_produccion = '" + dtpFecha.Value.ToString("yyy-MM-dd") + "' "
                            + " WHERE pac_prov_pack_id = '" + txtID.Text.ToString() + "'";
                        sc.OpenConection();
                        if (!sc.EjecutarQuery(sql))
                        {
                            MessageBox.Show("No se puede asignar una fecha de producción al Pack ID " + txtID.Text.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Se asigno la fecha de producción al Pack ID " + txtID.Text.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        sc.CloseConection();

                        txtUltimoID.Text = txtID.Text.ToString();
                        txtID.Text = String.Empty;
                        txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                        LlenarGrid();
                    }
                    else
                    {
                        MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " ya tiene fecha de producción asignada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Pack ID " + txtID.Text.ToString() + " no existe en el sistema o ya fue dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
