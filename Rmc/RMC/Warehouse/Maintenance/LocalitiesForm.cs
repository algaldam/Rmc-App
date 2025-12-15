using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Warehouse.Maintenance
{
    public partial class LocalitiesForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int id;
        int locId;

        public LocalitiesForm()
        {
            InitializeComponent();
            rgvLocalidades.MultiSelect = true;
            rgvLocalidades.SelectionMode = GridViewSelectionMode.FullRowSelect;
            rgvLocalidades.ClipboardCopyMode = GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            sc.AddButtonCerrar(this);
            this.id = sc.AppID;
            this.CargarDatos();
        }

        public void CargarDatos()
        {
            try
            {
                sc.OpenConection();

                sql = "SELECT loc_id, loc_nombre FROM wai_Localidad";
                sc.LlenarGrid(this.rgvLocalidades, sql, "x", "x");
                this.rgvLocalidades.Columns["loc_id"].SortOrder = RadSortOrder.Ascending;

                sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, sc.AppID, "Localidades", 'L');

                sc.CloseConection();
                txtNombre.Enabled = true;
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

        private void rgvAreas_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    locId = Int32.Parse(rgvLocalidades.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtNombre.Text = rgvLocalidades.Rows[e.RowIndex].Cells[1].Value.ToString();
                    sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Localidades", 'U');

                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    txtNombre.Enabled = true;
                }
                else
                {
                    rgvLocalidades.GridNavigator.SelectAll();
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
            sc.PermisosBotoneria(btnGuardar, btnActualizar, btnEliminar, sc.Usuario, id, "Localidades", 'N');
            RadControl(true);
            btnCancelar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] campos = new string[] { "txtNombre" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Localidades_CRUD "
                                + sc.Usuario + ","
                                + 0 + ", "
                                + "'" + txtNombre.Text.ToString() + "'" + ", "
                                + "'C'";

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Localidad Ingresada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Localidad Duplicada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string sql = "EXEC usp_wai_Localidades_CRUD "
                                + sc.Usuario + ","
                                + locId + ", "
                                + "'" + txtNombre.Text.ToString() + "'" + ", "
                                + "'U'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Localidad Actualizada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Localidad No Actualizada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de eliminar la Localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmacion1 == DialogResult.OK)
            {
                try
                {
                    sc.OpenConection();

                    string sql = "EXEC usp_wai_Localidades_CRUD "
                                + sc.Usuario + ","
                                + locId + ", "
                                + "''" + ", "
                                + "'D'";
                    Console.WriteLine(sql);

                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Localidad Eliminada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Localidad No Eliminada", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
