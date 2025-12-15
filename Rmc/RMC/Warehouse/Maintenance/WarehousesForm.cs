using Rmc.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Warehouse.Maintenance
{
    public partial class WarehousesForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int id;
        int bodId;

        public WarehousesForm()
        {
            InitializeComponent();
            rgvBodegas.MultiSelect = true;
            rgvBodegas.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvBodegas.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            sc.AddButtonCerrar(this);
            this.id = sc.AppID;
            this.CargarDatos();
        }

        public void CargarDatos()
        {
            try
            {
                sc.OpenConection();
                sql = "SELECT bod_id,bod_nombre,bod_descripcion FROM wai_Bodegas";
                sc.LlenarGrid(this.rgvBodegas, sql, "x", "x");

                this.rgvBodegas.Columns["bod_id"].SortOrder = RadSortOrder.Ascending;

                sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, sc.AppID, "Bodegas", 'L');

                sc.CloseConection();
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                RadControl(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message.ToString());
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

        private void rgvAreas_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    bodId = Int32.Parse(rgvBodegas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtNombre.Text = rgvBodegas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDescripcion.Text = rgvBodegas.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Bodegas", 'U');
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    txtNombre.Enabled = true;
                    txtDescripcion.Enabled = true;
                }
                else
                {
                    rgvBodegas.GridNavigator.SelectAll();
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
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Bodegas", 'N');
            RadControl(true);
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] campos = new string[] { "txtNombre", "txtDescripcion" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Bodegas_CRUD "
                                + sc.Usuario + ","
                                + 0 + ", "
                                + "'" + txtNombre.Text.ToString() + "'" + ", "
                                + "'" + txtDescripcion.Text.ToString() + "'" + ", "
                                + "'C'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Bodega Ingresada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bodega Duplicada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string[] campos = new string[] { "txtNombre", "txtDescripcion" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Bodegas_CRUD "
                                + sc.Usuario + ","
                                + bodId + ", "
                                + "'" + txtNombre.Text.ToString() + "'" + ", "
                                + "'" + txtDescripcion.Text.ToString() + "'" + ", "
                                + "'U'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Bodega Actualizada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bodega No Actualizada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de eliminar la Bodega?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacion1 == DialogResult.OK)
            {
                try
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Bodegas_CRUD "
                                + sc.Usuario + ","
                                + bodId + ", "
                                + "''" + ", "
                                + "''" + ", "
                                + "'D'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Bodega Eliminada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bodega No Eliminada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
