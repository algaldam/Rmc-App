using Rmc.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Warehouse.Maintenance
{
    public partial class Areas : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int id;
        int areId;

        public Areas()
        {
            InitializeComponent();
            rgvAreas.MultiSelect = true;
            rgvAreas.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvAreas.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            sc.AddButtonCerrar(this);
            this.id = sc.AppID;
            this.CargarDatos();
        }

        public void CargarDatos()
        {
            try
            {
                sc.OpenConection();

                sql = "SELECT are_id,are_codigo,are_descripcion FROM wai_Areas";
                sc.LlenarGrid(this.rgvAreas, sql, "x", "x");

                this.rgvAreas.Columns["are_id"].SortOrder = RadSortOrder.Ascending;

                sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, sc.AppID, "Areas", 'L');

                sc.CloseConection();
                txtCodigo.Enabled = true;
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
                    areId = Int32.Parse(rgvAreas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtCodigo.Text = rgvAreas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDescripcion.Text = rgvAreas.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Areas", 'U');

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    txtCodigo.Enabled = true;
                    txtDescripcion.Enabled = true;
                }
                else
                {
                    rgvAreas.GridNavigator.SelectAll();
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
            sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Areas", 'N');
            RadControl(true);
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] campos = new string[] { "txtCodigo", "txtDescripcion" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Areas_CRUD "
                                + sc.Usuario + ","
                                + 0 + ", "
                                + "'" + txtCodigo.Text.ToString() + "'" + ", "
                                + "'" + txtDescripcion.Text.ToString() + "'" + ", "
                                + "'C'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Área Ingresada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Área Duplicada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string[] campos = new string[] { "txtNombre" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Areas_CRUD "
                                + sc.Usuario + ","
                                + areId + ", "
                                + "'" + txtCodigo.Text.ToString() + "'" + ", "
                                + "'" + txtDescripcion.Text.ToString() + "'" + ", "
                                + "'U'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Área Actualizada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Área No Actualizada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de eliminar el Área?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacion1 == DialogResult.OK)
            {
                try
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Areas_CRUD "
                                + sc.Usuario + ","
                                + areId + ", "
                                + "''" + ", "
                                + "''" + ", "
                                + "'D'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Área Eliminada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Área No Eliminada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
