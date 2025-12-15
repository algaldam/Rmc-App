using Rmc.Clases;
using Rmc.Controllers;
using Rmc.Reportes.ReportesDesign;
using Rmc.Reportes.ReportesForm;
using Rmc.RMC.Warehouse.Transactions.Request;
using Rmc.RMC.Warehouse.Transactions.Request.Exits;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static Rmc.Modelo.Utilidades;

namespace Rmc.Warehouse
{
    public partial class InventoryExitsForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        SolicitudController SControl = new SolicitudController();
        InventarioController InvControl = new InventarioController();
        DevolucionController DControl = new DevolucionController();
        POController PControl = new POController();
        BodegaController BControl = new BodegaController();

        int conteo;
        bool flagACTIVA = false;
        public string Codigo = "";
        public string Cadena = "";
        public bool flag = false;
        public int IdProveedor = 0;
        public int ID;
        public bool flagPrioridad = false;
        bool flagPri = false;
        bool FlagInicio = true;

        public InventoryExitsForm()
        {
            InitializeComponent();

            this.CBX_PRODUCTOS.DropDownListElement.DropDownWidth = 350;
            CBX_PRODUCTOS.AutoCompleteMode = AutoCompleteMode.Suggest;
            CBX_PRODUCTOS.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(CBX_PRODUCTOS.DropDownListElement);
            CBX_PRODUCTOS.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            CargarBodegas();
        }

        #endregion

        #region METODOS

        private void CargarBodegas()
        {
            try
            {
                CbxBodegas.DataSource = BControl.ObtenerBodegas().Select(x => new { bod_id = x.bod_id, bod_nombre = x.bod_nombre + "-" + x.bod_descripcion }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SE LLENA EL COMBO  CON EN EL LISTADO DE PRODUCTOS
        private void LlenarItem(int bodega)
        {
            try
            {
                CBX_PRODUCTOS.DataSource = BControl.ObtenerTodosProductosBodega(bodega);
                FlagInicio = false;
                if (Codigo != "" && Codigo != null)
                {
                    flagPri = flagPrioridad;
                    CBX_PRODUCTOS.Text = Cadena;
                }
                else
                {
                    CBX_PRODUCTOS.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { RadMessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        public void SalidaSinPrioridad()
        {
            try
            {

                string resultado = "";
                if (conteo == 0)
                {
                    // 1: Salida normal
                    var msg = InvControl.Transacciones(Environment.UserName, 1, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue.ToString()), 1);

                    resultado = msg.ToString();
                }
                else
                {
                    // 2: Salida de devolucion
                    var msg = InvControl.Transacciones(Environment.UserName, 2, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue.ToString()), 1);

                    resultado = msg.ToString();
                }

                if (resultado == "NOCOINCIDE")
                {
                    MessageBox.Show("El PACK ID no pertenece al Item seleccionado", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (resultado == "NOENCONTRADO")
                {
                    MessageBox.Show("El PACK ID ingresado no existe en el sistema", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                else if (resultado == "OK")
                {

                    Variables.banderap = false;
                    // SE ACTUALIZA ESTADO DE SOLICITUD
                    if (ID != 0)
                    {
                        // SE ACTUALIZA ESTADO DE SOLICITUD
                        int ActualizarEstado = SControl.CrudSolicitudes(3, ID, TxtID.Text.Trim(), Variables.IdAut, permiso: 1, Estado: "Entregado");


                        if (ActualizarEstado > 0)
                        {
                            Application.OpenForms["frmTomaSolicitud"].Close();
                        }
                    }
                    txtUltimoID.Text = TxtID.Text.ToString();
                    TxtID.Text = String.Empty;
                    txtLibras.Text = String.Empty;
                    LlenarGridPackList();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                    if (conteo == 0)
                    {
                        ImprimirPackID(txtUltimoID.Text.ToString());
                    }
                    else
                    {
                        if (txtUltimoID.Text.ToString().Contains("D"))
                        {
                            ImprimirPackID_D(txtUltimoID.Text.ToString());
                        }
                        else
                        {
                            ImprimirPackID(txtUltimoID.Text.ToString());
                        }
                    }
                }
                else if (resultado == "LIBRAS")
                {
                    MessageBox.Show("Las libras ingresadas sobrepasan las libras disponibles", "Libras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema con el servidor, comuníquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // SE ACTUALIZAN LAS PRIORIDADES 
                if (InvControl.ObtenerCantidadProducto(Convert.ToInt32(CBX_PRODUCTOS.SelectedValue)) > 0)
                {
                    var Resultado = BControl.CrudPrioridades("P", Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), "", "", 0);

                    var resultado2 = BControl.CrudPrioridades("A", 0, "", "", 0);
                    LlenarGridPackList();
                }

                txtLibras.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add Bodega
        public void SalidaSinPrioridadBod()
        {
            try
            {

                string resultado = "";
                if (conteo == 0)
                {
                    // 1: Salida normal
                    var msg = InvControl.TransaccionesBod(Environment.UserName, 1, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue.ToString()), 1);

                    resultado = msg.ToString();
                }
                else
                {
                    // 2: Salida de devolucion
                    var msg = InvControl.TransaccionesBod(Environment.UserName, 2, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue.ToString()), 1);

                    resultado = msg.ToString();
                }

                if (resultado == "NOCOINCIDE")
                {
                    MessageBox.Show("El PACK ID no pertenece al Item seleccionado", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (resultado == "NOENCONTRADO")
                {
                    MessageBox.Show("El PACK ID ingresado no existe en el sistema", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                else if (resultado == "OK")
                {

                    Variables.banderap = false;
                    // SE ACTUALIZA ESTADO DE SOLICITUD
                    if (ID != 0)
                    {
                        // SE ACTUALIZA ESTADO DE SOLICITUD
                        int ActualizarEstado = SControl.CrudSolicitudes(3, ID, TxtID.Text.Trim(), Variables.IdAut, permiso: 1, Estado: "Entregado");


                        if (ActualizarEstado > 0)
                        {
                            Application.OpenForms["frmTomaSolicitud"].Close();
                        }
                    }
                    txtUltimoID.Text = TxtID.Text.ToString();
                    TxtID.Text = String.Empty;
                    txtLibras.Text = String.Empty;
                    LlenarGridPackList();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();
                    if (conteo == 0)
                    {
                        ImprimirPackID(txtUltimoID.Text.ToString());
                    }
                    else
                    {
                        if (txtUltimoID.Text.ToString().Contains("D"))
                        {
                            ImprimirPackID_D(txtUltimoID.Text.ToString());
                        }
                        else
                        {
                            ImprimirPackID(txtUltimoID.Text.ToString());
                        }
                    }
                }
                else if (resultado == "LIBRAS")
                {
                    MessageBox.Show("Las libras ingresadas sobrepasan las libras disponibles", "Libras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema con el servidor, comuníquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // SE ACTUALIZAN LAS PRIORIDADES 
                if (InvControl.ObtenerCantidadProducto(Convert.ToInt32(CBX_PRODUCTOS.SelectedValue)) > 0)
                {
                    var Resultado = BControl.CrudPrioridades("P", Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), "", "", 0);

                    var resultado2 = BControl.CrudPrioridades("A", 0, "", "", 0);
                    LlenarGridPackList();
                }

                txtLibras.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalidaPackList()
        {
            try
            {
                string resultado = "";

                // SE VERIFICA SI SE HA ACTIVADO LA SALIDA SIN PRIORIDADES
                if (flagACTIVA == true)
                {
                    resultado = "PRIORIDAD";
                }
                else
                {
                    // SE EVALUA SI HAY CONTEO DE DEVOLUCIONES
                    if (conteo == 0)
                    {
                        // 1: Salida normal
                        if (flagACTIVA == false)
                        {
                            var msg = InvControl.Transacciones(Environment.UserName, 1, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString()), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), 0);

                            resultado = msg.ToString().Trim();
                        }
                    }
                    else
                    {
                        // 2: Salida de devolucion
                        var msg = InvControl.Transacciones(Environment.UserName, 2, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString()), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), 0);

                        resultado = msg.ToString().Trim();
                    }
                }
                //sc.CloseConection(conn);
                if (resultado == "NOCOINCIDE")
                {
                    MessageBox.Show("El PACK ID no pertenece al Item seleccionado", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (resultado == "NOENCONTRADO")
                {
                    MessageBox.Show("El PACK ID ingresado no existe en el sistema", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (resultado == "PRIORIDAD")
                {
                    MessageBox.Show("Debe respetar las prioridades para realizar la salida del producto", "Prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (flagPrioridad == true)
                    {
                        using (ValidarSalidaForm vsal = new ValidarSalidaForm())
                        {
                            vsal.ShowDialog();
                            if (Variables.banderap == true)
                            {
                                SalidaSinPrioridad();
                                flagACTIVA = false;
                                goto SIN_PRIORIDAD;
                            }
                        }

                    }
                }
                else if (resultado == "OK")
                {

                    // SE ACTUALIZA ESTADO DE SOLICITUD
                    if (ID != 0)
                    {
                        int ActualizarEstado = SControl.CrudSolicitudes(3, ID, TxtID.Text.Trim(), Variables.IdAut, permiso: 2, Estado: "Entregado");

                        if (ActualizarEstado > 0)
                        {
                            Application.OpenForms["frmTomaSolicitud"].Close();
                        }
                    }

                    txtUltimoID.Text = TxtID.Text.ToString();
                    TxtID.Text = String.Empty;
                    txtLibras.Text = String.Empty;
                    LlenarGridPackList();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();

                    // SE REALIZAN IMPRESIONES SEGUN EXISTA DEVOLUCION O NO
                    if (conteo == 0)
                    {
                        ImprimirPackID(txtUltimoID.Text.ToString());
                    }
                    else
                    {
                        if (txtUltimoID.Text.ToString().Contains("D"))
                        {
                            ImprimirPackID_D(txtUltimoID.Text.ToString());
                        }
                        else
                        {
                            ImprimirPackID(txtUltimoID.Text.ToString());
                        }
                    }
                }
                else if (resultado == "LIBRAS")
                {
                    MessageBox.Show("Libras insuficientes para la cantidad solicitada \nó existen Devoluciones activas", "Libras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema con el servidor, comuníquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (InvControl.ObtenerCantidadProducto(Convert.ToInt32(CBX_PRODUCTOS.SelectedValue)) == 0)
                {
                    var Resultado = BControl.CrudPrioridades("P", Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), "", "", 0);
                    var resultado2 = BControl.CrudPrioridades("A", 0, "", "", 0);
                    LlenarGridPackList();
                }
            SIN_PRIORIDAD: txtLibras.Focus();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        //Add Bodega
        private void SalidaPackListBod()
        {
            try
            {
                string resultado = "";

                // SE VERIFICA SI SE HA ACTIVADO LA SALIDA SIN PRIORIDADES
                if (flagACTIVA == true)
                {
                    resultado = "PRIORIDAD";
                }
                else
                {
                    // SE EVALUA SI HAY CONTEO DE DEVOLUCIONES
                    if (conteo == 0)
                    {
                        // 1: Salida normal
                        if (flagACTIVA == false)
                        {
                             var msg = InvControl.TransaccionesBod(Environment.UserName, 1, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString()), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), 0);

                            resultado = msg.ToString().Trim();
                        }
                    }
                    else
                    {
                        // 2: Salida de devolucion
                        var msg = InvControl.TransaccionesBod(Environment.UserName, 2, TxtID.Text.ToString(), float.Parse(txtLibras.Text.ToString()), Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), 0);

                        resultado = msg.ToString().Trim();
                    }
                }
                //sc.CloseConection(conn);
                if (resultado == "NOCOINCIDE")
                {
                    MessageBox.Show("El PACK ID no pertenece al Item seleccionado", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (resultado == "NOENCONTRADO")
                {
                    MessageBox.Show("El PACK ID ingresado no existe en el sistema", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (resultado == "PRIORIDAD")
                {
                    MessageBox.Show("Debe respetar las prioridades para realizar la salida del producto", "Prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (flagPrioridad == true)
                    {
                        using (ValidarSalidaForm vsal = new ValidarSalidaForm())
                        {
                            vsal.ShowDialog();
                            if (Variables.banderap == true)
                            {
                                SalidaSinPrioridadBod();
                                flagACTIVA = false;
                                goto SIN_PRIORIDAD;
                            }
                        }

                    }
                }
                else if (resultado == "OK")
                {

                    // SE ACTUALIZA ESTADO DE SOLICITUD
                    if (ID != 0)
                    {
                        int ActualizarEstado = SControl.CrudSolicitudes(3, ID, TxtID.Text.Trim(), Variables.IdAut, permiso: 2, Estado: "Entregado");

                        if (ActualizarEstado > 0)
                        {
                            Application.OpenForms["frmTomaSolicitud"].Close();
                        }
                    }

                    txtUltimoID.Text = TxtID.Text.ToString();
                    TxtID.Text = String.Empty;
                    txtLibras.Text = String.Empty;
                    LlenarGridPackList();
                    txtEscaneados.Text = (int.Parse(txtEscaneados.Text.ToString()) + 1).ToString();

                    // SE REALIZAN IMPRESIONES SEGUN EXISTA DEVOLUCION O NO
                    if (conteo == 0)
                    {
                        ImprimirPackID(txtUltimoID.Text.ToString());
                    }
                    else
                    {
                        if (txtUltimoID.Text.ToString().Contains("D"))
                        {
                            ImprimirPackID_D(txtUltimoID.Text.ToString());
                        }
                        else
                        {
                            ImprimirPackID(txtUltimoID.Text.ToString());
                        }
                    }
                }
                else if (resultado == "LIBRAS")
                {
                    MessageBox.Show("Libras insuficientes para la cantidad solicitada \nó existen Devoluciones activas", "Libras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema con el servidor, comuníquese con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (InvControl.ObtenerCantidadProducto(Convert.ToInt32(CBX_PRODUCTOS.SelectedValue)) == 0)
                {
                    var Resultado = BControl.CrudPrioridades("P", Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), "", "", 0);
                    var resultado2 = BControl.CrudPrioridades("A", 0, "", "", 0);
                    LlenarGridPackList();
                }
            SIN_PRIORIDAD: txtLibras.Focus();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void LlenarGridPackList()
        {
            try
            {
                // SE EJECUTA SI EL FORMULARIO SE ABRE A TRAVES DE UNA SOLICITUD DE HILO
                if (flag == true)
                {
                    conteo = DControl.ObtenerCuentaDevolucionPorProducto(Convert.ToInt32(CBX_PRODUCTOS.SelectedValue));

                    if (DControl.ObtenerConteoDevolucion(Codigo) == 0)
                    {
                        GRID_VIEW_PACK_LIST.DataSource = InvControl.ObtenerPackListSalida(OpcionPackList.ProveedorNormal, Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), IdProveedor);
                    }
                    else
                    {
                        var ListadoConDProv = InvControl.ObtenerPackListSalida(OpcionPackList.ProveedorConDevolucion, Convert.ToInt32(CBX_PRODUCTOS.SelectedValue), IdProveedor);

                        //SE EVALUA SI NO RETORNAN DEVOLUCIONES PARA EL PROVEEDOR DETALLADO
                        if (ListadoConDProv.Where(x => x.PackId.Contains("D")).Count() > 0)
                        {
                            GRID_VIEW_PACK_LIST.DataSource = ListadoConDProv.OrderBy(x => x.PackId).OrderBy(x => x.Prioridad).OrderBy(x => x.Contador)
                                                                            .ToList();
                        }
                        else
                        {
                            //SE AGREGA DEVOLUCIONES SI NO HAY CON PROVEEDOR
                            var ListadDevTodos = InvControl.ObtenerPackListSalida(OpcionPackList.SoloDevolucion, Convert.ToInt32(CBX_PRODUCTOS.SelectedValue));

                            ListadoConDProv.AddRange(ListadDevTodos);
                            GRID_VIEW_PACK_LIST.DataSource = ListadoConDProv.OrderBy(x => x.PackId).OrderBy(x => x.Prioridad).OrderBy(x => x.Contador)
                                                                            .ToList();
                        }
                    }
                }
                // SE EJECUTA CUANDO EL FORMULARIO SALIDAS SE ABRE SIN SOLICITUDES
                else
                {
                    conteo = DControl.ObtenerCuentaDevolucionPorProducto(Convert.ToInt32(CBX_PRODUCTOS.SelectedValue));

                    // SE EJECUTA SI NO EXISTEN DEVOLUCIONES PARA EL ARTICULO SELECCIONADO
                    if (conteo == 0)
                    {
                        GRID_VIEW_PACK_LIST.DataSource = InvControl.ObtenerPackListSalida(OpcionPackList.Normal, Convert.ToInt32(CBX_PRODUCTOS.SelectedValue));
                    }
                    // SE EJECUTA SI EXISTEN DEVOLUCIONES PARA EL ARTICULO SELECCIONADO
                    else
                    {
                        GRID_VIEW_PACK_LIST.DataSource = InvControl
                                                                    .ObtenerPackListSalida(OpcionPackList.ConDevolucion, Convert.ToInt32(CBX_PRODUCTOS.SelectedValue))
                                                                    .OrderBy(x => x.PackId).OrderBy(x => x.Prioridad).OrderBy(x => x.Contador)
                                                                    .ToList();
                        string[] codigos = CBX_PRODUCTOS.Text.Split(' ');
                    }
                }

            }
            catch (Exception ex) { RadMessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        // SE IMPRIME ESTAMPA DE PACK LIST CON EL REMANENTE 
        private void ImprimirPackID(string PackID)
        {
            try
            {
                if (InvControl.ValidarLibrasPackList(PackID) == true)
                {
                    var LDatos = PControl.ObtenerEstampaImpresion(2, PackListID: PackID);
                    PackIDDesign reporte = new PackIDDesign();
                    reporte.DataSource = LDatos;

                    InstanceReportSource instanceReportSource = new InstanceReportSource();
                    instanceReportSource.ReportDocument = reporte;

                    PackIDForm popup = new PackIDForm();
                    popup.reportViewer1.ReportSource = instanceReportSource;
                    popup.reportViewer1.RefreshReport();
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.TopLevel = true;
                    popup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // SE IMPRIME ESTAMPA DE PACK LIST DEVOLUCION CON EL REMANENTE 
        private void ImprimirPackID_D(string PackID)
        {
            try
            {
                var IdDevolucion = DControl.ObtenerIdDevolucion(PackID);
                if (IdDevolucion != null && IdDevolucion.Trim() != "")
                {
                    var LDatos = DControl.ObtenerEstampaDevoluciones(IdDevolucion);
                    DevolucionDesign reporte = new DevolucionDesign();
                    reporte.DataSource = LDatos;

                    InstanceReportSource instanceReportSource = new InstanceReportSource();
                    instanceReportSource.ReportDocument = reporte;

                    DevolucionForm popup = new DevolucionForm();
                    popup.reportViewer1.ReportSource = instanceReportSource;
                    popup.reportViewer1.RefreshReport();
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.TopLevel = true;
                    popup.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        #endregion
        #region EVENTOS

        private void ddlBodegas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (CbxBodegas.SelectedIndex != -1)
            {
                this.LlenarItem(Int32.Parse(CbxBodegas.SelectedValue.ToString()));
            }
        }

        private void ddlItem_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (FlagInicio == false)
                {
                    if (CBX_PRODUCTOS.SelectedIndex != -1)
                    {
                        LlenarGridPackList();
                        txtLibras.Focus();
                    }
                    else
                    {
                        GRID_VIEW_PACK_LIST.DataSource = null;
                    }
                }
            }
            catch (Exception ex) { RadMessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
            {
                if (!txtLibras.Text.ToString().Equals(""))
                {
                    if (double.Parse(txtLibras.Text.ToString()) > 0)
                    {
                        if (!TxtID.Text.ToString().Equals(""))
                        {
                            // Obtener la bodega seleccionada
                            var selectedBodega = CbxBodegas.SelectedValue;

                            // Validar que se haya seleccionado una bodega y que sea convertible a int
                            if (selectedBodega != null && int.TryParse(selectedBodega.ToString(), out int bodegaId))
                            {
                                if (bodegaId == 4)
                                {
                                    SalidaPackListBod();
                                }
                                else
                                {
                                    SalidaPackList();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe seleccionar una bodega válida", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El PACK ID no puede estar vacío", "Pack ID", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las libras deben ser mayor a cero", "Libras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("El valor de las libras no puede estar vacío", "Libras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void txtLibras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
            {
                TxtID.Focus();
            }
        }

        private void Salida_Load(object sender, EventArgs e)
        {
            if (Codigo != "" && Codigo != null)
            {
                flagPri = flagPrioridad;
                CBX_PRODUCTOS.Focus();
                int itemIndex = this.CBX_PRODUCTOS.FindString(Cadena);
                if (itemIndex > -1)
                {
                    CBX_PRODUCTOS.SelectedIndex = itemIndex;
                }
                CBX_PRODUCTOS.Text = Cadena;
            }
        }

        private void ddlItem_Click(object sender, EventArgs e)
        {
            flag = false;
        }
        // MENU AL DAR CLIC DERECHO
        private void rgvPackList_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            try
            {
                RadMenuItem ItemUpPrioridad = new RadMenuItem("Activar Salida Sin Prioridad");
                RadMenuItem ItemDownPrioridad = new RadMenuItem("Deshabilitar Prioridad");
                ItemUpPrioridad.Click += new EventHandler(ItemActivarPrioridad_Click);
                ItemDownPrioridad.Click += new EventHandler(ItemDesactivarPrioridad_Click);
                e.ContextMenu.Items.Add(ItemUpPrioridad);
                e.ContextMenu.Items.Add(ItemDownPrioridad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemActivarPrioridad_Click(object sender, EventArgs e)
        {
            try
            {
                flagACTIVA = true;
                flagPrioridad = true;
                conteo = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemDesactivarPrioridad_Click(object sender, EventArgs e)
        {
            try
            {
                flagPrioridad = false;
                LlenarGridPackList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_REFRESH_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.F5)
                {
                    BTN_REFRESH.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TxtID_KeyUp(object sender, KeyEventArgs e)
        {
            TxtID.CharacterCasing = CharacterCasing.Upper;
        }
        #endregion
    }
}
