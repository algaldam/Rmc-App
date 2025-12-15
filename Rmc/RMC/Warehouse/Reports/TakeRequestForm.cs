using Rmc.Controllers;
using Rmc.Modelo;
using Rmc.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.RMC.Warehouse.Reports
{
    public partial class TakeRequestForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        public int Id;
        string codigo;

        public DataTable GTable = new DataTable();

        ProveedorController PControl = new ProveedorController();
        SolicitudController SControl = new SolicitudController();
        BindingSource bs = new BindingSource();
        Solicitud ObjSolicitud = new Solicitud();

        public TakeRequestForm()
        {
            InitializeComponent();
            InitializeCustomStyles();
        }

        public TakeRequestForm(Solicitud solicitud)
        {
            InitializeComponent();
            this.ObjSolicitud = solicitud;
            this.Id = solicitud.sol_ID;
            InitializeCustomStyles();
        }

        private void InitializeCustomStyles() 
        {
            var font1 = ThemeResolutionService.GetCustomFont("TelerikWebUI");

            BTN_GUARDAR.ButtonElement.CustomFont = font1.Name;
            BTN_GUARDAR.ButtonElement.CustomFontSize = 13;
            BTN_GUARDAR.Text = "\ue109" + " Guardar";

            BtnCerrar.ButtonElement.CustomFont = font1.Name;
            BtnCerrar.ButtonElement.CustomFontSize = 13;
            BtnCerrar.Text = "\ue131" + " Salir";

            btnProcesar.ButtonElement.CustomFont = font1.Name;
            btnProcesar.ButtonElement.CustomFontSize = 14;
            btnProcesar.Text = "\ue026 " + "Procesar Salida";
        }
        #endregion

        #region DATOS

        private void CargarDatos()
        {
            try
            {
                if (ObjSolicitud != null)
                {
                    bs.DataSource = ObjSolicitud;

                    CbxEstado.SelectedIndex = -1;
                    TxtIdSolicitud.Text = ObjSolicitud.sol_ID.ToString();
                    codigo = ObjSolicitud.sol_item;

                    Unbinding();

                    CbxProveedor.ValueMember = "ID";
                    CbxProveedor.DisplayMember = "Descripcion";
                    CbxProveedor.DataSource = PControl.ObtenerProveedorPorProducto(codigo)
                        .Select(x => new { ID = Convert.ToInt32(x.ID), Descripcion = x.Proveedor });

                    Binding();

                    if (TxtCarguista.Text.Trim() == "" || TxtCarguista.Text == null)
                    {
                        TxtCarguista.Text = SControl.ObtenerNombreUsuario();
                    }
                    if (CbxEstado.Text.Trim() == "Nuevo")
                    {
                        CbxEstado.Enabled = true;
                        CbxEstado.Text = "";
                        btnProcesar.Enabled = false;
                        CbxEstado.Items[2].Enabled = false;
                    }
                    else
                    {
                        btnProcesar.Enabled = true;
                        CbxEstado.Items[2].Enabled = true;
                    }
                    if (TxtCarguista.Text.Trim() != "")
                    {
                        TxtCarguista.Enabled = false;
                        btnProcesar.Enabled = true;
                    }
                    else
                    {
                        TxtCarguista.Enabled = true;
                        btnProcesar.Enabled = false;
                    }
                    if (CbxEstado.Text.Trim() == "Nuevo" || TxtCarguista.Text.Trim() == "" || CbxEstado.Text.Trim() == "")
                    {
                        btnProcesar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Unbinding()
        {
            try
            {
                TxtCodigo.DataBindings.Clear();
                CbxProveedor.DataBindings.Clear();
                TxtProducto.DataBindings.Clear();
                CbxEstado.DataBindings.Clear();
                TxtCarguista.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Binding()
        {
            try
            {
                TxtCarguista.DataBindings.Add("Text", bs, "NOMBRE_ENTREGA", false, DataSourceUpdateMode.Never);
                CbxProveedor.DataBindings.Add("Text", bs, "pro_nombre", false, DataSourceUpdateMode.Never);
                TxtCodigo.DataBindings.Add("Text", bs, "sol_item", false, DataSourceUpdateMode.Never);
                TxtProducto.DataBindings.Add("Text", bs, "ite_descripcion", false, DataSourceUpdateMode.Never);
                CbxEstado.DataBindings.Add("SelectedValue", bs, "sol_estado", false, DataSourceUpdateMode.Never);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region EVENTOS

        private void FrmTomaSolicitud_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryExitsForm salida = new InventoryExitsForm();
                salida.Codigo = TxtCodigo.Text.Trim();
                salida.Cadena = TxtCodigo.Text.Trim() + " - " + TxtProducto.Text.Trim();
                salida.flag = true;
                salida.flagPrioridad = true;
                salida.ID = Convert.ToInt32(TxtIdSolicitud.Text.Trim());
                salida.IdProveedor = Convert.ToInt32(CbxProveedor.SelectedItem.Value.ToString());
                salida.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BTN_GUARDAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbxEstado.Text.Trim() == "")
                {
                    CbxEstado.BackColor = Color.LightCoral;
                }
                else if (TxtCarguista.Text.Trim() == "")
                {
                    TxtCarguista.BackColor = Color.LightCoral;
                }
                else
                {
                    int ActualizarEstado = SControl.CrudSolicitudes(3, Convert.ToInt32(TxtIdSolicitud.Text.Trim()), "", 0, permiso: 3, Estado: CbxEstado.SelectedItem.Text.Trim());

                    if (CbxEstado.Text.Trim() == "Entregado")
                    {

                        this.Close();
                    }
                    else
                    {
                        CargarDatos();
                    }
                    LBL_GUARDAR.Visible = true;
                    BTN_GUARDAR.Enabled = false;
                    MessageBox.Show("Actualización correcta...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CbxEstado_Click(object sender, EventArgs e)
        {
            BTN_GUARDAR.Enabled = true;
        }

        private void CbxEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (CbxEstado.SelectedIndex > -1)
                {
                    LBL_GUARDAR.Visible = false;
                    BTN_GUARDAR.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}
