using Rmc.Clases;
using Rmc.Controllers;
using Rmc.EntityFramework;
using Rmc.Modelo;
using Rmc.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Chemical.Request
{
    public partial class CrudChemicalRequestForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION

        public int Id;
        private int bodegaChemicalID = 3;
        public bool flag = true;

        SolicitudController SControl = new SolicitudController();
        ProveedorController PControl = new ProveedorController();
        InventarioController INControl = new InventarioController();
        public Solicitud objSolicitud = new Solicitud();
        bool FlagInicio = true;

        public CrudChemicalRequestForm()
        {
            InitializeComponent();
            var font1 = ThemeResolutionService.GetCustomFont("TelerikWebUI");

            btnAceptar.ButtonElement.CustomFont = font1.Name;
            btnAceptar.ButtonElement.CustomFontSize = 13;
            btnAceptar.Text = "\ue109" + " Guardar";

            btnCancelar.ButtonElement.CustomFont = font1.Name;
            btnCancelar.ButtonElement.CustomFontSize = 13;
            btnCancelar.Text = "\ue131" + " Salir";
            CbxProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CbxProducto.DropDownListElement.AutoCompleteSuggest = new SystemClass.CustomAutoCompleteSuggestHelper(CbxProducto.DropDownListElement);
            CbxProducto.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
        }

        BindingSource bs = new BindingSource();
        #endregion


        #region DATOS
        public void CargarDatos()
        {
            try
            {
                var fila = objSolicitud;


                bs.DataSource = objSolicitud;
                CbxProducto.Enabled = false;
                CbxSemana.Enabled = false;
                CbxProveedor.Enabled = false;
                CbxEstado.Enabled = false;
                Llenar();

                Unbinding();
                Binding();
                string producto = TxtCodigo.Text.Trim();
                //rodt.Fill(ds.wai_Proveedor, producto);
                CbxProveedor.ValueMember = "ID";
                CbxProveedor.DisplayMember = "Descripcion";
                CbxProveedor.DataSource = PControl.ObtenerProveedorPorProducto(producto, this.bodegaChemicalID).Select(x => new { ID = Convert.ToInt32(x.ID), Descripcion = x.Proveedor });
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDataNuevo()
        {
            try
            {
                Llenar();
                CbxEstado.Enabled = false;
                CbxEstado.SelectedIndex = 0;

                CbxPrioridad.SelectedIndex = 0;
                TxtUsuario.Text = SControl.ObtenerNombreUsuario();
                TxtFecha.Value = DateTime.Now;
                this.weekPlanTableAdapter1.Fill(this.tracerDataSet1.WeekPlan);
                CbxSemana.DataSource = tracerDataSet1.WeekPlan;
                CbxSemana.DisplayMember = "WeekID";
                CbxSemana.ValueMember = "WeekID";
                CbxSemana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Llenar()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item(1, "A"));
            items.Add(new Item(2, "B"));
            items.Add(new Item(3, "C"));
            items.Add(new Item(4, "D"));
            items.Add(new Item(5, "E"));
            items.Add(new Item(6, "F"));
            items.Add(new Item(7, "G"));
            items.Add(new Item(8, "H"));
            items.Add(new Item(9, "I"));
            items.Add(new Item(10, "J"));
            items.Add(new Item(11, "K"));
            items.Add(new Item(12, "L"));
            items.Add(new Item(13, "M"));
            items.Add(new Item(14, "N"));
            items.Add(new Item(15, "O"));
            items.Add(new Item(16, "P"));
            items.Add(new Item(17, "Q"));
            items.Add(new Item(18, "R"));
            items.Add(new Item(19, "S"));
            items.Add(new Item(20, "T"));
            items.Add(new Item(21, "U"));
            items.Add(new Item(22, "V"));
            items.Add(new Item(23, "W"));
            items.Add(new Item(24, "X"));
            items.Add(new Item(25, "Y"));
            items.Add(new Item(26, "Z"));

            this.CbxLocalidad.DataSource = DatoPares.ObtenerLocalidadesEntrega();
            this.CbxLocalidad.DisplayMember = "Descripcion";
            this.CbxLocalidad.ValueMember = "ID";
        }
        #endregion

        #region BINDEO

        private void Binding()
        {
            try
            {

                TxtUsuario.DataBindings.Add("Text", bs, "NOMBRE_PIDE", false, DataSourceUpdateMode.Never);
                TxtCodigo.DataBindings.Add("Text", bs, "sol_item", false, DataSourceUpdateMode.Never);
                TxtFecha.DataBindings.Add("Text", bs, "sol_FH_crea", false, DataSourceUpdateMode.Never);
                TxtMedida.DataBindings.Add("Text", bs, "sol_UOM", false, DataSourceUpdateMode.Never);
                CbxProducto.DataBindings.Add("Text", bs, "ite_descripcion", false, DataSourceUpdateMode.Never);
                CbxPrioridad.DataBindings.Add("Text", bs, "sol_prioridad", false, DataSourceUpdateMode.Never);
                CbxSemana.DataBindings.Add("Text", bs, "sol_semana", false, DataSourceUpdateMode.Never);
                CbxLocalidad.DataBindings.Add("Text", bs, "sol_localidad", false, DataSourceUpdateMode.Never);
                CbxProveedor.DataBindings.Add("Text", bs, "pro_nombre", false, DataSourceUpdateMode.Never);
                CbxEstado.DataBindings.Add("Text", bs, "sol_estado", false, DataSourceUpdateMode.Never);
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

                TxtUsuario.DataBindings.Clear();
                TxtCodigo.DataBindings.Clear();
                TxtFecha.DataBindings.Clear();
                TxtMedida.DataBindings.Clear();
                CbxProducto.DataBindings.Clear();
                CbxPrioridad.DataBindings.Clear();
                CbxSemana.DataBindings.Clear();
                CbxLocalidad.DataBindings.Clear();
                CbxProveedor.DataBindings.Clear();
                CbxEstado.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region EVENTOS
        private void frmCrudSolicitudes_Load(object sender, EventArgs e)
        {
            try
            {
                this.weekPlanTableAdapter1.Fill(this.tracerDataSet1.WeekPlan);
                if (flag == true)
                {
                    CargarDatos();
                    TxtFecha.Culture = new System.Globalization.CultureInfo("es-ES");
                }
                else
                {
                    CargarDataNuevo();
                    TxtFecha.Culture = new System.Globalization.CultureInfo("es-ES");
                }

                FlagInicio = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CbxLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbxPrioridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbxProducto.Text.Trim() == "")
                {
                    CbxProducto.BackColor = Color.LightCoral;
                    return;
                }
                else if (CbxProveedor.Text.Trim() == "")
                {
                    CbxProveedor.BackColor = Color.LightCoral;
                    return;
                }
                else if (CbxPrioridad.Text.Trim() == "")
                {
                    CbxPrioridad.BackColor = Color.LightCoral;
                    return;
                }
                else if (CbxLocalidad.Text.Trim() == "")
                {
                    CbxLocalidad.BackColor = Color.LightCoral;
                    return;
                }

                // Obtener ID del proveedor de forma segura
                int proveedorId = GetProveedorId();
                if (proveedorId <= 0)
                {
                    MessageBox.Show("No se pudo obtener un ID válido para el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar peso del proveedor
                if (INControl.PesoProveedor(TxtCodigo.Text.Trim(), proveedorId, this.bodegaChemicalID) <= 0)
                {
                    MessageBox.Show("No hay Libras para el proveedor seleccionado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CbxProveedor.BackColor = Color.LightCoral;
                    return;
                }

                // SE ACTUALIZA SOLICITUD
                if (flag == true)
                {
                    wai_Solicitudes solicitud = new wai_Solicitudes()
                    {
                        sol_semana = CbxSemana.Text.Trim(),
                        sol_item = TxtCodigo.Text.Trim(),
                        sol_estado = CbxEstado.Text.Trim(),
                        sol_UOM = TxtMedida.Text.Trim(),
                        sol_pro_ID = 0,
                        sol_localidad = CbxLocalidad.SelectedItem.Value.ToString(),
                        sol_prioridad = CbxPrioridad.Text,
                        sol_usuario_pedido = Environment.UserName,
                        sol_ID = objSolicitud.sol_ID
                    };

                    int resultado = SControl.CrudSolicitudes(2, 0, "", 0, solicitud, "U");
                    if (resultado > 0)
                    {
                        lbmsg.Text = "Actualización correcta...";
                        lbmsg.Visible = true;
                        this.Close();
                    }
                }
                // SE CREA SOLICITUD
                else
                {
                    wai_Solicitudes solicitud = new wai_Solicitudes()
                    {
                        sol_semana = CbxSemana.Text.Trim(),
                        sol_item = TxtCodigo.Text.Trim(),
                        sol_estado = CbxEstado.Text.Trim(),
                        sol_UOM = TxtMedida.Text.Trim(),
                        sol_pro_ID = proveedorId,
                        sol_localidad = CbxLocalidad.SelectedItem.Value.ToString(),
                        sol_prioridad = CbxPrioridad.Text,
                        sol_usuario_pedido = Environment.UserName,
                    };

                    int resultado = SControl.CrudSolicitudes(1, 0, "", 0, solicitud, "C");
                    if (resultado > 0)
                    {
                        lbmsg.Text = "Solicitud Registrada Correctamente...";
                        lbmsg.Visible = true;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetProveedorId()
        {
            try
            {
                if (CbxProveedor.SelectedItem == null)
                {
                    MessageBox.Show("No se ha seleccionado ningún proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }

                if (CbxProveedor.SelectedItem.DataBoundItem != null)
                {
                    dynamic item = CbxProveedor.SelectedItem.DataBoundItem;

                    if (item.GetType().GetProperty("ID") != null)
                    {
                        return item.ID;
                    }
                    else if (item.GetType().GetProperty("Value") != null)
                    {
                        return item.Value;
                    }
                }

                if (CbxProveedor.SelectedItem.Value != null)
                {
                    if (CbxProveedor.SelectedItem.Value is int)
                    {
                        return (int)CbxProveedor.SelectedItem.Value;
                    }
                    else if (CbxProveedor.SelectedItem.Value is IConvertible)
                    {
                        return Convert.ToInt32(CbxProveedor.SelectedItem.Value);
                    }
                }

                if (!string.IsNullOrEmpty(CbxProveedor.ValueMember))
                {
                    var dataSource = CbxProveedor.DataSource;
                    if (dataSource != null)
                    {
                        var selectedValue = CbxProveedor.SelectedValue;
                        if (selectedValue != null && selectedValue is IConvertible)
                        {
                            return Convert.ToInt32(selectedValue);
                        }
                    }
                }

                MessageBox.Show("No se pudo determinar el ID del proveedor seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ID del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void CbxEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbxEstado_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (flag == true)
                {
                    if (CbxEstado.SelectedIndex == 0)
                    {
                        CbxEstado.BackColor = Color.DarkBlue;
                    }
                    else if (CbxEstado.SelectedIndex == 1)
                    {
                        CbxEstado.BackColor = Color.DarkGreen;
                    }
                    else if (CbxEstado.SelectedIndex == 2)
                    {
                        CbxEstado.BackColor = Color.Maroon;
                    }
                }
                else
                {
                    this.BackColor = default(Color);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CbxProducto_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            try
            {
                if (!FlagInicio)
                {
                    if (CbxProducto.SelectedIndex != -1 && CbxProducto.SelectedItem != null)
                    {
                        string producto = CbxProducto.SelectedItem.Value.ToString();

                        // Obtener libras disponibles para el producto
                        var librasData = INControl
                            .ObtenerLibrasProducto(producto, this.bodegaChemicalID)
                            .Where(x => Convert.ToDouble(x.LIBRAS) > 0)
                            .Select(x => new
                            {
                                LIBRAS = Convert.ToDouble(x.LIBRAS)
                            })
                            .FirstOrDefault();

                        if (librasData == null)
                        {
                            MessageBox.Show("No existen suficientes Libras para el producto seleccionado.", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        var proveedores = PControl.ObtenerProveedorPorProducto(producto).ToList();
                        CbxProveedor.DataSource = proveedores;
                        CbxProveedor.DisplayMember = "Proveedor";

                        CbxProveedor.SelectedIndex = 0;

                        // Cargar datos del producto para la semana seleccionada
                        var productoSemana = SControl
                            .ObtenerProductoPorSemana(CbxSemana.Text.Trim(), bodegaChemicalID)
                            .Select(x => new
                            {
                                pla_item = x.pla_item,
                                ite_descripcion = x.ite_descripcion,
                                pla_UOM = x.pla_UOM
                            })
                            .ToList()
                            .FirstOrDefault(x => x.pla_item == producto);

                        if (productoSemana != null)
                        {
                            TxtMedida.Text = productoSemana.pla_UOM.ToString();
                            TxtCodigo.Text = producto;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto en la semana seleccionada.");
                            TxtMedida.Text = "";
                            TxtCodigo.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CbxProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbxProducto_Click(object sender, EventArgs e)
        {
            CbxProducto.BackColor = default(Color);
        }

        private void CbxProveedor_Click(object sender, EventArgs e)
        {
            CbxProveedor.BackColor = default(Color);
        }

        private void CbxPrioridad_Click(object sender, EventArgs e)
        {
            CbxPrioridad.BackColor = default(Color);
        }

        private void CbxLocalidad_Click(object sender, EventArgs e)
        {
            CbxLocalidad.BackColor = default(Color);
        }

        private void CbxSemana_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (!flag)
                {
                    var Lproductos = SControl.ObtenerProductoPorSemana(CbxSemana.Text.Trim(), bodegaChemicalID)
                                             .Select(x => new
                                             {
                                                 pla_item = x.pla_item.ToString(),
                                                 ite_descripcion = x.ite_descripcion.ToString(),
                                                 pla_UOM = x.pla_UOM.ToString()
                                             })
                                             .ToList();

                    CbxProducto.DataSource = Lproductos;
                    CbxProducto.DisplayMember = "ite_descripcion";
                    CbxProducto.ValueMember = "pla_item";

                    CbxProducto.SelectedIndex = -1;
                    CbxProveedor.DataSource = null;
                    TxtCodigo.Text = "";
                    TxtMedida.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos con libras: " + ex.Message);
            }
        }

        private void CbxSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

    }
}
