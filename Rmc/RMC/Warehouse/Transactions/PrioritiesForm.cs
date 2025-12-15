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
using Telerik.WinControls.UI;

namespace Rmc.Warehouse
{
    public partial class PrioritiesForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int id;
        int itemID;

        public PrioritiesForm()
        {
            InitializeComponent();
            this.id = sc.AppID;
            this.UpdatePrioridades();
            this.LlenarBodegas();
        }

        private void UpdatePrioridades()
        {
            sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','L','','','',''";
            sc.OpenConection();
            if (sc.DevValorString(sql) == "OK")
                Console.WriteLine("Prioridades Actualizadas");
            else
                Console.WriteLine("Prioridades No Actualizadas");
            sc.CloseConection();
        }

        private void LlenarBodegas()
        {
            sql = "SELECT bod_id,CONCAT(bod_nombre,' - ',bod_descripcion) AS nombre FROM wai_Bodegas";
            sc.LlenarDropDownList(ddlBodegas, sql, "nombre", "bod_id");
        }

        private void ddlBodegas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.LlenarItem(Int32.Parse(ddlBodegas.SelectedValue.ToString()));
        }

        public void LlenarItem(int bodega)
        {
            try
            {
                sql = "SELECT ite_id, CONCAT(ite_codigo, ' - ',ite_descripcion) AS nombre FROM wai_Item "
                        + " INNER JOIN wai_Bodegas ON bod_id = ite_bodega_id "
                        + " INNER JOIN wai_Prioridades ON pri_item_id = ite_id "
                        + " WHERE bod_id='" + bodega + "' "
                        + " GROUP BY ite_id,ite_codigo,ite_descripcion";
                sc.LlenarGrid(this.rgvProductos, sql, "x", "x");
                LlenarPrioridades();
                LlenarDevoluciones();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void LlenarPrioridades()
        {
            try
            {
                rgvPrioridades.DataSource = null;
                itemID = Int32.Parse(rgvProductos.CurrentRow.Cells[0].Value.ToString());
                sql = "SELECT pri_item_id,pri_lote,pri_prioridad, pri_paquetes, pri_libras, pri_semana, 0 AS pri_modificado FROM wai_Prioridades WHERE pri_item_id='" + itemID + "'";
                sc.LlenarGrid(this.rgvPrioridades, sql, "x", "x");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LlenarDevoluciones()
        {
            try
            {
                rgvPriDevoluciones.DataSource = null;

                itemID = Int32.Parse(rgvProductos.CurrentRow.Cells[0].Value.ToString());
                sql = "SELECT dev_lote AS LOTE, dev_prioridad AS PRIORIDAD, COUNT(dev_id) AS PAQUETES, SUM(ISNULL(dev_libras,0)) AS LIBRAS "
                    + " FROM wai_Devoluciones D "
                    + " INNER JOIN wai_Localidad L ON L.loc_id = D.dev_localidad_id "
                    + " WHERE D.dev_item_id='" + itemID + "' "
                    + " GROUP BY dev_lote,dev_prioridad";
                sc.LlenarGrid(this.rgvPriDevoluciones, sql, "x", "x");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            bool procesado = true;
            try
            {
                foreach (GridViewRowInfo row in rgvPrioridades.Rows)
                {
                    if (row.Cells[6].Value.ToString() == "1")
                    {
                        sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','U','" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "', '" + row.Cells[5].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'";
                        Console.WriteLine(sql);
                        sc.OpenConection();
                        if (sc.DevValorString(sql) != "OK")
                        {
                            procesado = false;
                        }
                        sc.CloseConection();
                    }
                }
                LlenarItem(int.Parse(ddlBodegas.SelectedValue.ToString()));
                if (procesado)
                    RadMessageBox.Show("Actualizado", "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);
                else
                    MessageBox.Show("No Actualizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdatePrioridades();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void MasterTemplate_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            rgvPrioridades.CurrentRow.Cells["pri_modificado"].Value = 1;
            Console.WriteLine("cambio en linea ");
        }

        private void btnAsignacionAutomatica_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion1 = RadMessageBox.Show("¿Está seguro de Asignar las Prioridades Automáticas?", "Confirmación", MessageBoxButtons.OKCancel, RadMessageIcon.Question);
            if (confirmacion1 == DialogResult.OK)
            {
                try
                {
                    sc.OpenConection();
                    sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','R','','','',''";
                    if (sc.DevValorString(sql) == "OK")
                    {
                        DialogResult confirmacion2 = RadMessageBox.Show("Prioridades Actualizadas ¿Desea aplicar las Prioridades Automáticas?", "Confirmación", MessageBoxButtons.OKCancel, RadMessageIcon.Question);
                        if (confirmacion2 == DialogResult.OK)
                        {
                            try
                            {
                                sc.OpenConection();
                                sql = "EXEC usp_wai_Prioridades_CRUD '" + sc.Usuario + "','A','','','',''";
                                Console.WriteLine(sql);
                                if (sc.DevValorString(sql) == "OK")
                                    RadMessageBox.Show("Prioridades Actualizadas", "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);
                                else
                                    RadMessageBox.Show("Prioridades No Actualizadas", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                                sc.CloseConection();
                                this.UpdatePrioridades();
                                LlenarItem(int.Parse(ddlBodegas.SelectedValue.ToString()));
                            }
                            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
                        }
                    }

                    else
                        RadMessageBox.Show("Prioridades No Actualizadas \n   ", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    sc.CloseConection();
                }
                catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
            }
        }


        private void rgvProductos_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    LlenarPrioridades();
                    LlenarDevoluciones();
                }
                else
                {
                    rgvProductos.GridNavigator.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
