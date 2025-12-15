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

namespace Rmc.RMC.Warehouse.Maintenance
{
    public partial class ProductsForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int id;
        int itemID;

        public ProductsForm()
        {
            InitializeComponent();
            this.id = sc.AppID;
            rgvProductos.MultiSelect = true;
            rgvProductos.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvProductos.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.LlenarBodegas();
            this.CargarDatos();
            sc.AddButtonCerrar(this);
        }

        private void LlenarBodegas()
        {
            sql = "SELECT bod_id,CONCAT(bod_nombre,' - ',bod_descripcion) AS nombre FROM wai_Bodegas ORDER BY bod_id DESC";
            sc.LlenarDropDownList(ddlBodega, sql, "nombre", "bod_id");
        }

        private void CargarDatos()
        {
            try
            {
                sc.OpenConection();

                sql = "SELECT ite_id, ite_bodega_id, CONCAT(bod_nombre,' - ',bod_descripcion) AS bodega, '' AS ite_area_id, '' AS area, "
                    + " ite_codigo, ite_descripcion, ite_existencia  FROM wai_Item "
                    + " INNER JOIN wai_Bodegas ON bod_id = ite_bodega_id "
                    + " /*INNER JOIN wai_Areas ON are_id = ite_area_id*/ ";
                sc.LlenarGrid(this.rgvProductos, sql, "x", "x");

                this.rgvProductos.Columns["ite_id"].SortOrder = RadSortOrder.Ascending;

                sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, sc.AppID, "Productos", 'L');

                sc.CloseConection();

                ddlBodega.Enabled = true;
                ddlArea.Enabled = true;
                txtCodigo.Enabled = true;
                txtDescripcion.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                RadControl(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DATOS: " + ex.Message.ToString());
            }
        }

        private void RadControl(bool val)
        {
            foreach (RadControl c in this.Controls)
            {
                if (c is RadTextBox)
                {
                    c.Enabled = val;
                    c.Text = String.Empty;
                    c.BackColor = default(Color);
                }
                if (c is RadDropDownList)
                {
                    RadDropDownList d = (RadDropDownList)c;
                    d.SelectedIndex = -1;
                    d.Enabled = val;
                    d.BackColor = default(Color);
                }
            }
        }

        private void rgvProductos_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    itemID = Int32.Parse(rgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ddlBodega.SelectedValue = Int32.Parse(rgvProductos.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtCodigo.Text = rgvProductos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtDescripcion.Text = rgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Productos", 'U');
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    ddlBodega.Enabled = true;
                    ddlArea.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtDescripcion.Enabled = true;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            ddlBodega.Enabled = false;
            ddlArea.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Productos", 'N');
            RadControl(true);
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] campos = new string[] { "ddlBodega", "txtCodigo", "txtDescripcion" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Item_CRUD "
                                + sc.Usuario + ","
                                + 0 + ", "
                                + "'" + ddlBodega.SelectedValue.ToString() + "'" + ", "
                                + "'" + txtCodigo.Text.ToString() + "'" + ", "
                                + "'" + txtDescripcion.Text.ToString() + "'" + ", "
                                + "'C'";
                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Producto Ingresado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Producto No Ingresado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sc.CloseConection();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] campos = new string[] { "ddlBodega", "txtCodigo", "txtDescripcion" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Item_CRUD "
                                + sc.Usuario + ","
                                + itemID + ", "
                                + "'" + ddlBodega.SelectedValue.ToString() + "'" + ", "
                                + "'" + txtCodigo.Text.ToString() + "'" + ", "
                                + "'" + txtDescripcion.Text.ToString() + "'" + ", "
                                + "'U'";

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Producto Actualizado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Producto No Actualizado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sc.CloseConection();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de eliminar el Producto?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacion1 == DialogResult.OK)
            {
                try
                {
                    sc.OpenConection();
                    string sql = "EXEC usp_wai_Item_CRUD "
                                + sc.Usuario + ","
                                + itemID + ", "
                                + "''" + ", "
                                + "''" + ", "
                                + "''" + ", "
                                + "'D'";

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Producto Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Producto No Eliminado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sc.CloseConection();
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

    }
}
