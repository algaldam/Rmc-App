using FontAwesome.Sharp;
using Rmc.Clases;
using Rmc.Controllers;
using Rmc.EntityFramework;
using Rmc.EntityFramework.Model;
using Rmc.Modelo;
using Rmc.Reportes;
using Rmc.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Wainari.Vista.Movimientos;
using Wainari.Vista.Reportes.PO;
using static Rmc.Modelo.Utilidades;

namespace Rmc.Consultas
{
    public partial class frmPO : Telerik.WinControls.UI.RadForm
    {
        private List<POLawson> POS = new List<POLawson>();

        #region INICIALIZACION
        POController PControl = new POController();
        BodegaController BControl = new BodegaController();
        ProveedorController PrController = new ProveedorController();
        BindingSource BindSource = new BindingSource();
        BindingSource BindSourceFac = new BindingSource();
        BindingSource BindSourcePro = new BindingSource();
        List<wai_Factura> LFacturas;
        List<ProductosFactura> LProductosFactura;
        List<wai_POS> LObjetosPO;
        bool NuevaPO = false;
        bool NuevaFactura = false;
        bool NuevoProducto = false;
        string EstadoPO = "";
        bool FlagInicio = true;
        SystemClass sc;
        SqlConnection conn;

        public frmPO()
        {
            InitializeComponent();

            BtnAbierto.Image = IconChar.DoorOpen.ToBitmap(IconFont.Auto, 25, Color.Orange);
            BtnCerrado.Image = IconChar.DoorClosed.ToBitmap(IconFont.Auto, 25, Color.Orange);
            BtnTodo.Image = IconChar.Dungeon.ToBitmap(IconFont.Auto, 25, Color.Orange);

            DtFecha.Format = DateTimePickerFormat.Custom;
            DtFecha.CustomFormat = "MM/dd/yyyy";

            var font1 = ThemeResolutionService.GetCustomFont("TelerikWebUI");

            // BOTONES PO
            BtnNuevo.Enabled = true;
            BtnNuevo.ButtonElement.CustomFont = font1.Name;
            BtnNuevo.ButtonElement.CustomFontSize = 17;
            BtnNuevo.Text = "\ue906";
            BtnGuardar.ButtonElement.CustomFont = font1.Name;
            BtnGuardar.ButtonElement.CustomFontSize = 17;
            BtnGuardar.Text = "\ue109";//e102                
            BtnCancelar.ButtonElement.CustomFont = font1.Name;
            BtnCancelar.ButtonElement.CustomFontSize = 17;
            BtnCancelar.Text = "\ue102";
            BtnEliminar.ButtonElement.CustomFont = font1.Name;
            BtnEliminar.ButtonElement.CustomFontSize = 17;
            BtnEliminar.Text = "\ue10C";

            //BOTONES FACTURAS
            BtnNuevoFac.ButtonElement.CustomFont = font1.Name;
            BtnNuevoFac.ButtonElement.CustomFontSize = 14;
            BtnNuevoFac.Text = "\ue906";
            BtnGuardarFac.ButtonElement.CustomFont = font1.Name;
            BtnGuardarFac.ButtonElement.CustomFontSize = 14;
            BtnGuardarFac.Text = "\ue109";
            BtnCancelarFac.ButtonElement.CustomFont = font1.Name;
            BtnCancelarFac.ButtonElement.CustomFontSize = 14;
            BtnCancelarFac.Text = "\ue102";

            BtnEliminarFac.ButtonElement.CustomFont = font1.Name;
            BtnEliminarFac.ButtonElement.CustomFontSize = 14;
            BtnEliminarFac.Text = "\ue10C";

            // BOTONES PRODUCTOS
            #region BOTONES PRODUCTO
            BtnNuevoPro.ButtonElement.CustomFont = font1.Name;
            BtnNuevoPro.ButtonElement.CustomFontSize = 14;
            BtnNuevoPro.Text = "\ue906";

            BtnGuardarPro.ButtonElement.CustomFont = font1.Name;
            BtnGuardarPro.ButtonElement.CustomFontSize = 14;
            BtnGuardarPro.ButtonElement.ToolTipText = "Guardar";
            BtnGuardarPro.Text = "\ue109";


            BtnCancelarPro.ButtonElement.CustomFont = font1.Name;
            BtnCancelarPro.ButtonElement.CustomFontSize = 14;
            BtnCancelarPro.ButtonElement.ToolTipText = "Recargar";
            BtnCancelarPro.Text = "\ue102";

            BtnEliminarPro.ButtonElement.CustomFont = font1.Name;
            BtnEliminarPro.ButtonElement.CustomFontSize = 14;
            BtnEliminarPro.Text = "\ue10C";
            //----------
            BtnImprimirAll.ButtonElement.CustomFont = font1.Name;
            BtnImprimirAll.ButtonElement.CustomFontSize = 14;
            BtnImprimirAll.ButtonElement.ToolTipText = "Imprimir Todos";
            BtnImprimirAll.Text = "\ue10A";

            BtnImprimirNew.ButtonElement.CustomFont = font1.Name;
            BtnImprimirNew.ButtonElement.CustomFontSize = 14;
            BtnImprimirNew.ButtonElement.ToolTipText = "Imprimir Sin Localidad";
            BtnImprimirNew.Text = "\ue63E";

            BtnVerLista.ButtonElement.CustomFont = font1.Name;
            BtnVerLista.ButtonElement.CustomFontSize = 14;
            BtnVerLista.ButtonElement.ToolTipText = "Ver Lista";
            BtnVerLista.Text = "\ue13D";

            BtnImportar.ButtonElement.CustomFont = font1.Name;
            BtnImportar.ButtonElement.CustomFontSize = 14;
            BtnImportar.ButtonElement.ToolTipText = "Importar";
            BtnImportar.Text = "\ue133";

            #endregion

            CbxProveedor.ListElement.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            CbxProveedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            CbxProveedor.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(CbxProveedor.DropDownListElement);
            CbxProveedor.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

            CbxProducto.ListElement.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            CbxProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            CbxProducto.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(CbxProducto.DropDownListElement);
            CbxProducto.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            VALIDAR_PERMISOS();
            CargarCombos();
            Limpiar();

        }
        #endregion

        #region METODOS
        private void VALIDAR_PERMISOS()
        {
            try
            {
                var BOTONES = ConsultasSql.ObtenerBotones("frmPO").FirstOrDefault();
                if (BOTONES != null)
                {
                    if (Convert.ToInt32(BOTONES.PermisosCrear) > 0)
                    {
                        BtnNuevo.Enabled = true;
                        BtnGuardar.Enabled = true;
                    }
                    else
                    {
                        BtnNuevo.Enabled = false;
                        BtnGuardar.Enabled = false;
                    }
                    if (Convert.ToInt32(BOTONES.PermisosActualizar) > 0)
                    {
                        BtnGuardar.Enabled = true;
                    }

                    if (Convert.ToInt32(BOTONES.PermisosEliminar) > 0)
                    {
                        BtnEliminar.Enabled = true;
                    }
                    else
                    {
                        BtnEliminar.Enabled = false;
                    }
                }
                else
                {
                    BtnNuevo.Enabled = false;
                    BtnGuardar.Enabled = false;
                    BtnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            CbxBodegas.SelectedIndex = -1;
            CbxProveedor.SelectedIndex = -1;
            CbxEstado.SelectedIndex = -1;
            DtFecha.Text = "";
            FlagInicio = false;
        }

        private void CargarCombos()
        {
            try
            {
                CbxBodegas.ValueMember = "bod_id";
                CbxBodegas.DisplayMember = "bod_nombre";
                CbxBodegas.DataSource = BControl.ObtenerBodegas().Select(x => new { bod_id = x.bod_id, bod_nombre = x.bod_nombre + "-" + x.bod_descripcion }).ToList();

                CbxEstado.DataSource = DatoPares.Estado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDatos(string Estado)
        {
            try
            {
                if (CbxBodegas.SelectedIndex > -1)
                {
                    LObjetosPO = new List<wai_POS>();
                    LObjetosPO = PControl.ObtenerPOS(Convert.ToInt32(CbxBodegas.SelectedValue), Estado).OrderBy(x => x.pos_id).ToList();
                    BindSource.DataSource = LObjetosPO;
                    GRID_VIEW_PO.DataSource = BindSource;
                    UnBindingPO();
                    BindingPO();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar Bodega", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region BINDING DATOS

        private void BindingPO()
        {
            try
            {
                sc = new SystemClass();
                conn = sc.OpenConection();
                LblPOId.DataBindings.Add("Text", BindSource, "pos_id", false, DataSourceUpdateMode.Never);
                CbxProveedor.DataBindings.Add("SelectedValue", BindSource, "pos_proveedor_id", false, DataSourceUpdateMode.Never);
                CbxEstado.DataBindings.Add("SelectedValue", BindSource, "pos_estado", false, DataSourceUpdateMode.Never);
                TxtNumero.DataBindings.Add("Text", BindSource, "pos_numero", false, DataSourceUpdateMode.Never);
                TxtSemana.DataBindings.Add("Text", BindSource, "pos_semana", false, DataSourceUpdateMode.Never);
                DtFecha.DataBindings.Add("Text", BindSource, "pos_fecha", false, DataSourceUpdateMode.Never);
                txtCreadorPO.DataBindings.Add("Text", BindSource, "pos_creador", false, DataSourceUpdateMode.Never); // Agregado
                string PO = TxtNumero.Text;
                string query = "SELECT pos_creador FROM wai_POS WHERE pos_numero = @PONumero";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@PONumero", PO);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        txtCreadorPO.Text = result.ToString();
                    }
                    else
                    {
                        txtCreadorPO.Text = "No encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    sc.CloseConection(); // Cierra la conexión al finalizar
                }
            }
        }
        private void UnBindingPO()
        {
            try
            {
                CbxProveedor.DataBindings.Clear();
                TxtNumero.DataBindings.Clear();
                TxtSemana.DataBindings.Clear();
                DtFecha.DataBindings.Clear();
                LblPOId.DataBindings.Clear();
                CbxEstado.DataBindings.Clear();
                txtCreadorPO.DataBindings.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindingFac()
        {
            try
            {
                LblFacID.DataBindings.Add("Text", BindSourceFac, "fac_id", false, DataSourceUpdateMode.Never);
                TxtNumeroFa.DataBindings.Add("Text", BindSourceFac, "fac_numero", false, DataSourceUpdateMode.Never);
                TxtPaqueteFac.DataBindings.Add("Text", BindSourceFac, "fac_paquetes", false, DataSourceUpdateMode.Never);
                TxtLibraFac.DataBindings.Add("Text", BindSourceFac, "fac_libras", false, DataSourceUpdateMode.Never);

                CbxMedida.DataBindings.Add("SelectedValue", BindSourceFac, "fac_medida", false, DataSourceUpdateMode.Never);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UnBindingFac()
        {
            try
            {
                LblFacID.DataBindings.Clear();
                TxtNumeroFa.DataBindings.Clear();
                TxtPaqueteFac.DataBindings.Clear();
                TxtLibraFac.DataBindings.Clear();
                CbxMedida.DataBindings.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindingPro()
        {
            try
            {
                LblDetalleFacID.DataBindings.Add("Text", BindSourcePro, "facd_id", false, DataSourceUpdateMode.Never);
                CbxProducto.DataBindings.Add("SelectedValue", BindSourcePro, "facd_item_id", false, DataSourceUpdateMode.Never);
                TxtCantidadPro.DataBindings.Add("Text", BindSourcePro, "facd_cantidad", false, DataSourceUpdateMode.Never);
                TxtLotePro.DataBindings.Add("Text", BindSourcePro, "facd_lote", false, DataSourceUpdateMode.Never);
                TxtPesoPro.DataBindings.Add("Text", BindSourcePro, "facd_peso", false, DataSourceUpdateMode.Never);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UnBindingPro()
        {
            try
            {
                CbxProducto.DataBindings.Clear();
                TxtCantidadPro.DataBindings.Clear();
                TxtLotePro.DataBindings.Clear();
                TxtPesoPro.DataBindings.Clear();
                LblDetalleFacID.DataBindings.Clear();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // SE CARGAN LAS FACTURAS
        void CargarFacturas()
        {
            try
            {
                if (LblPOId.Text.Trim() != "")
                {
                    LFacturas = new List<wai_Factura>();
                    LFacturas = PControl.ObtenerFacuras(Convert.ToInt32(LblPOId.Text.Trim()));
                    BindSourceFac.DataSource = LFacturas;
                    GRID_VIEW_FACTURA.DataSource = BindSourceFac;
                    UnBindingFac();
                    BindingFac();
                    ValidarPaquetesFactura();
                }
                else
                {
                    BindSourceFac.DataSource = new List<wai_Factura>();
                    GRID_VIEW_FACTURA.DataSource = BindSourceFac;
                    UnBindingFac();
                    BindingFac();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // SE CARGAN LAS PO
        void CargarProductos()
        {
            try
            {
                if (LblFacID.Text.Trim() != "")
                {
                    LProductosFactura = new List<ProductosFactura>();

                    LProductosFactura = PControl.ObtenerProductosFactura(Convert.ToInt32(LblFacID.Text.Trim()));

                    BindSourcePro.DataSource = LProductosFactura;
                    GRID_VIEW_PRODUCTOS.DataSource = BindSourcePro;
                    UnBindingPro();
                    BindingPro();
                    ValidarPaquetesFactura();
                }
                else
                {
                    BindSourcePro.DataSource = new List<ProductosFactura>();
                    GRID_VIEW_PRODUCTOS.DataSource = BindSourcePro;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //SE VALIDA QUE LA CANTIDAD DEL DETALLE SEA IGUAL AL NUMERO D EPAQUETES EN LA FACTURA
        void ValidarPaquetesFactura()
        {
            try
            {
                if (LblFacID.Text.Trim() != "")
                {
                    var registro = LFacturas.Where(x => x.fac_id == Convert.ToInt32(LblFacID.Text.Trim())).FirstOrDefault();
                    if (registro != null)
                    {
                        var resultado = PControl.ValidarFactura("FA", Convert.ToInt32(LblFacID.Text.Trim()));
                        if (registro.fac_paquetes != null && registro.fac_paquetes != resultado)
                        {
                            LblPaquetesFactura.Visible = true;
                        }
                        else
                        {
                            LblPaquetesFactura.Visible = false;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ValidarMascaraSemana(string texto)
        {
            try
            {
                bool resultado = false;
                var cadena = texto.Split('-');
                var anio = cadena[0].Replace("_", "").Trim() == "0000" ? 0 : cadena[0].Replace("_", "").Trim().Length;
                var semana = cadena[1].Replace("_", "").Trim() == "00" ? 0 : cadena[1].Replace("_", "").Trim().Length;
                if (anio < 4 || semana < 2)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region EVENTOS 

        #region EVENTOS PO
        private async void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (CbxBodegas.SelectedIndex == -1 || CbxBodegas.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una bodega antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NuevaPO = true;
            LblPOId.Text = "";
            TxtNumero.Text = "";
            txtCreadorPO.Text = "";
            CbxProveedor.SelectedIndex = -1;
            CbxEstado.SelectedIndex = 0;
            CbxEstado.Enabled = false;
            TxtSemana.Clear();

            var popup = new frmDatosPO();
            if (popup.ShowDialog() != DialogResult.OK)
                return;

            string numeroPO = popup.NumeroPO;
            string numeroFactura = popup.NumeroFactura;

            waitingBar.BringToFront();
            waitingBar.Visible = true;
            waitingBar.StartWaiting();

            try
            {
                bool poExiste = false;
                List<POLawson> datosLawson = null;

                await Task.Run(() =>
                {
                    poExiste = PControl.ObtenerCodigo("PO", numeroPO) > 0;
                    if (!poExiste)
                    {
                        datosLawson = LawsonController.ObtenerPODesdeLawson(numeroPO, numeroFactura);
                    }
                });

                if (poExiste)
                {
                    CargarDatos("A");

                    if (LObjetosPO != null)
                    {
                        var poExistente = LObjetosPO.FirstOrDefault(po => po.pos_numero == numeroPO);
                        if (poExistente != null)
                        {
                            BindSource.Position = LObjetosPO.IndexOf(poExistente);
                            MessageBox.Show("La orden de compra se ha cargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("La PO existe pero no fue posible cargarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar la información de la PO desde Wainari.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                if (datosLawson == null || !datosLawson.Any())
                {
                    MessageBox.Show("No se encontró la orden de compra. Verifica los datos ingresados y vuelve a intentarlo.", "Orden No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var linea = datosLawson.First();
                bool insertPos = false;

                await Task.Run(() =>
                {
                    int bodegaId = Convert.ToInt32(CbxBodegas.Invoke(new Func<object>(() => CbxBodegas.SelectedValue)));
                    insertPos = PControl.InsertarPOS(
                        linea.Numero,
                        bodegaId,
                        DateTime.Now,
                        linea.Creador
                    );
                });

                if (insertPos)
                {
                    CargarDatos("A");

                    var nuevaPO = LObjetosPO.FirstOrDefault(po => po.pos_numero == linea.Numero);
                    if (nuevaPO != null)
                    {
                        BindSource.Position = LObjetosPO.IndexOf(nuevaPO);
                    }

                    MessageBox.Show("La orden de compra se ha importado correctamente desde Lawson.", "Importación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // === INSERTAR FACTURA AUTOMÁTICAMENTE ===
                    float pesoTotalFactura = (float)datosLawson.Sum(p => p.Peso);
                    int cantidadProductos = datosLawson.Count;

                    wai_Factura nuevaFactura = new wai_Factura
                    {
                        fac_pos_id = nuevaPO.pos_id,
                        fac_numero = linea.NumeroFactura,
                        fac_paquetes = cantidadProductos,
                        fac_libras = pesoTotalFactura,
                        fac_fecha = DateTime.Now,
                        fac_medida = linea.UnidadMedida,
                        fac_usuario_crea = Environment.UserName
                    };

                    int resultadoFac = PControl.FacturaCRUD(1, nuevaFactura);

                    if (resultadoFac == 1)
                    {
                        CargarFacturas();

                        var facturaInsertada = LFacturas.FirstOrDefault(f => f.fac_numero == linea.NumeroFactura && f.fac_pos_id == nuevaPO.pos_id);
                        if (facturaInsertada != null)
                        {
                            LblFacID.Text = facturaInsertada.fac_id.ToString();

                            // === INSERTAR PRODUCTOS AUTOMÁTICAMENTE ===
                            foreach (var producto in datosLawson)
                            {
                                int? itemId = PControl.ObtenerItemIdPorCodigo(producto.CodigoProducto);

                                if (itemId != null)
                                {
                                    var nuevoDetalle = new ProductosFactura
                                    {
                                        facd_item_id = itemId.Value,
                                        facd_cantidad = 0,
                                        facd_peso = Convert.ToDouble(producto.Peso),
                                        facd_lote = "",
                                        facd_prioridad = 1
                                    };

                                    PControl.InsertarFacturaDetalle(facturaInsertada.fac_id, nuevoDetalle);
                                }
                                else
                                {
                                    MessageBox.Show($"El producto con código {producto.CodigoProducto} no existe en la tabla de Items.\nNo se insertará en la factura.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            CargarProductos();
                        }
                    }
                }

                TxtNumeroFa.Text = linea.NumeroFactura;
                CbxMedida.Text = linea.UnidadMedida;
                TxtPaqueteFac.Text = datosLawson.Count.ToString();
                TxtLibraFac.Text = datosLawson.Sum(p => p.Peso).ToString(CultureInfo.InvariantCulture);
                TxtNumero.Text = linea.Numero;
                txtCreadorPO.Text = linea.Creador;

                var primerProducto = datosLawson.FirstOrDefault();
                if (primerProducto != null)
                {
                    CbxProducto.Text = primerProducto.CodigoProducto + " - " + primerProducto.NombreProducto;
                    TxtCantidadPro.Text = "0";
                    TxtPesoPro.Text = primerProducto.Peso.ToString(CultureInfo.InvariantCulture);
                    TxtLotePro.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante la operación:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                waitingBar.StopWaiting();
                waitingBar.Visible = false;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = GRID_VIEW_PO.Rows.IndexOf(this.GRID_VIEW_PO.CurrentRow);

                UnBindingPO();
                BindingPO();
                GRID_VIEW_PO.Rows[fila].IsSelected = true;
                GRID_VIEW_PO.Rows[fila].IsCurrent = true;

                CbxEstado.Enabled = true;

                NuevaPO = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbxBodegas.Text.Trim() == "" || CbxBodegas.SelectedIndex < 0)
                {
                    MessageBox.Show("Verificar Campo Bodegas", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (NuevaPO == true && PControl.ObtenerCodigo("PO", TxtNumero.Text.Trim()) > 0)
                {
                    LblNumeroPO.Text = "El Número PO ya Existe";
                    LblNumeroPO.Visible = true;
                }
                else if (TxtNumero.Text.Trim() == "")
                {
                    MessageBox.Show("Verificar Número", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (CbxProveedor.Text.Trim() == "" || CbxProveedor.SelectedIndex < 0)
                {
                    MessageBox.Show("Verificar Proveedor", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (ValidarMascaraSemana(TxtSemana.Text.Trim()) == false)
                {
                    MessageBox.Show("Verificar Semana", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (CbxEstado.Text.Trim() == "" || CbxEstado.SelectedIndex < 0)
                {
                    MessageBox.Show("Verificar Estado", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {

                    string creadorPO = txtCreadorPO.Text.Trim();

                    DialogResult resultado1 = MessageBox.Show(
                     "Se guardará la PO. ¿Desea continuar?",
                     "Confirmación",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
                    );

                    if (resultado1 == DialogResult.Yes)
                    {
                        if (LblPOId.Text.Trim() == "")
                        {
                            NuevaPO = true;
                        }
                        else
                        {
                            NuevaPO = false;
                        }
                        wai_POS PO = new wai_POS()
                        {
                            pos_id = LblPOId.Text.Trim() != "" ? Convert.ToInt32(LblPOId.Text.Trim()) : 0,
                            pos_numero = TxtNumero.Text.Trim(),
                            pos_estado = CbxEstado.SelectedValue.ToString(),
                            pos_semana = TxtSemana.Text.Trim(),
                            pos_bodega_id = Convert.ToInt32(CbxBodegas.SelectedValue),
                            pos_proveedor_id = Convert.ToInt32(CbxProveedor.SelectedValue),
                            pos_creador = txtCreadorPO.Text.Trim()
                        };
                        var resultado = PControl.PO_CRUD(1, PO);
                        if (resultado == 1)
                        {
                            if (NuevaPO == true)
                            {
                                CargarDatos("A");
                                int fila = GRID_VIEW_PO.Rows.Count;
                                GRID_VIEW_PO.Rows[fila - 1].IsSelected = true;
                                GRID_VIEW_PO.Rows[fila - 1].IsCurrent = true;
                                NuevaPO = false;
                            }
                            else
                            {
                                CargarDatos(EstadoPO);
                            }
                            MessageBox.Show("PO ha sido procesada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblPOId.Text.Trim() == "")
                {
                    MessageBox.Show("No hay PO seleccionada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Está seguro de eliminar la PO?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation
                    );

                    if (confirmacion == DialogResult.Yes)
                    {
                        var resultado = PControl.PO_CRUD(2, LObjetosPO.Where(x => x.pos_id == Convert.ToInt32(LblPOId.Text.Trim())).First());
                        if (resultado == 1)
                        {
                            CargarDatos(EstadoPO);
                            MessageBox.Show("PO eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Imposible eliminar la PO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "System.Data.Entity.Infrastructure.DbUpdateException")
                {
                    MessageBox.Show("Imposible eliminar la PO. Al parecer contiene facturas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CbxBodegas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (FlagInicio == false)
                {
                    if (CbxBodegas.SelectedIndex > -1)
                    {
                        var Datos = BControl.ObtenerProducto(Convert.ToInt32(CbxBodegas.SelectedValue));
                        CbxProducto.DisplayMember = "Descripcion";
                        CbxProducto.ValueMember = "Codigo";
                        CbxProducto.DataSource = Datos.Select(x => new { Codigo = x.ite_id, Descripcion = x.ite_codigo + " - " + x.ite_descripcion });
                        CbxProducto.SelectedIndex = -1;

                        CbxProveedor.ValueMember = "pro_id";
                        CbxProveedor.DisplayMember = "pro_nombre";
                        CbxProveedor.DataSource = PrController.ObtenerProveedores();
                        CbxProveedor.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GRID_VIEW_PO_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            try
            {
                NuevaPO = false;
                if (e.CurrentRow != null && e.CurrentRow.DataBoundItem != null)
                {
                    var selectedPO = e.CurrentRow.DataBoundItem as wai_POS;
                    if (selectedPO != null)
                    {
                        string numeroPO = selectedPO.pos_numero;
                        // Inicializa la conexión si es nula
                        if (conn == null)
                        {
                            sc = new SystemClass(); // Instancia de la clase de conexión
                            conn = sc.OpenConection();        // Obtén la conexión desde SystemClass
                        }
                        string query = "SELECT pos_creador FROM wai_POS WHERE pos_numero = @PONumero";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@PONumero", numeroPO);
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                txtCreadorPO.Text = result.ToString();
                            }
                            else
                            {
                                txtCreadorPO.Text = "No encontrado";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al obtener el PO seleccionado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión si está abierta
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void TxtNumero_Leave(object sender, EventArgs e)
        {
            try
            {
                if (NuevaPO == true)
                {
                    if (PControl.ObtenerCodigo("PO", TxtNumero.Text.Trim()) > 0)
                    {
                        LblNumeroPO.Text = "El Número PO ya Existe";
                        LblNumeroPO.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void TxtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            LblNumeroPO.Visible = false;
            TxtNumero.CharacterCasing = CharacterCasing.Upper;
        }
        private void BtnAbierto_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatos("A");
                EstadoPO = "A";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCerrado_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatos("C");
                EstadoPO = "C";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnTodo_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatos("T");
                EstadoPO = "T";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS FACTURA
        private void LblPOId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarFacturas();
            }
            catch (Exception ex)
            {

                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void LblFacID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarProductos();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private async void BtnNuevoFac_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtNumero.Text))
                {
                    MessageBox.Show("Debe tener una PO cargada antes de agregar una factura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var poActual = LObjetosPO.FirstOrDefault(po => po.pos_numero == TxtNumero.Text.Trim());
                if (poActual == null)
                {
                    MessageBox.Show("La PO cargada no se encontró en la lista. Cargue la PO correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var popup = new frmDatosFactura();
                popup.SetPOValue(TxtNumero.Text.Trim());
                if (popup.ShowDialog() != DialogResult.OK)
                    return;

                string numeroFactura = popup.NumeroFactura.Trim();

                var facturaExistente = LFacturas.FirstOrDefault(f => f.fac_numero == numeroFactura && f.fac_pos_id == poActual.pos_id);
                if (facturaExistente != null)
                {
                    MessageBox.Show("Esta factura ya fue ingresada para esta PO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                waitingBar.BringToFront();
                waitingBar.Visible = true;
                waitingBar.StartWaiting();

                List<POLawson> datosLawson = null;

                await Task.Run(() =>
                {
                    datosLawson = LawsonController.ObtenerPODesdeLawson(poActual.pos_numero, numeroFactura);
                });

                if (datosLawson == null || !datosLawson.Any())
                {
                    MessageBox.Show("La factura no fue encontrada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var linea = datosLawson.First();
                float pesoTotal = (float)datosLawson.Sum(p => p.Peso);
                int paquetes = datosLawson.Count;

                wai_Factura nuevaFactura = new wai_Factura
                {
                    fac_pos_id = poActual.pos_id,
                    fac_numero = numeroFactura,
                    fac_paquetes = paquetes,
                    fac_libras = pesoTotal,
                    fac_fecha = DateTime.Now,
                    fac_medida = linea.UnidadMedida,
                    fac_usuario_crea = Environment.UserName
                };

                int resultadoFac = PControl.FacturaCRUD(1, nuevaFactura);

                if (resultadoFac == 1)
                {
                    CargarFacturas();

                    var facturaInsertada = LFacturas.FirstOrDefault(f => f.fac_numero == numeroFactura && f.fac_pos_id == poActual.pos_id);
                    if (facturaInsertada != null)
                    {
                        LblFacID.Text = facturaInsertada.fac_id.ToString();
                        TxtNumeroFa.Text = numeroFactura;
                        TxtPaqueteFac.Text = paquetes.ToString();
                        TxtLibraFac.Text = pesoTotal.ToString(CultureInfo.InvariantCulture);
                        CbxMedida.Text = linea.UnidadMedida;

                        foreach (var producto in datosLawson)
                        {
                            int? itemId = PControl.ObtenerItemIdPorCodigo(producto.CodigoProducto);
                            if (itemId != null)
                            {
                                var detalle = new ProductosFactura
                                {
                                    facd_item_id = itemId.Value,
                                    facd_cantidad = 0,
                                    facd_peso = Convert.ToDouble(producto.Peso),
                                    facd_lote = "",
                                    facd_prioridad = 1
                                };

                                PControl.InsertarFacturaDetalle(facturaInsertada.fac_id, detalle);
                            }
                            else
                            {
                                MessageBox.Show($"El producto con código {producto.CodigoProducto} no existe en la tabla de Items.\nNo se insertará.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        CargarProductos();
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error al agregar factura: " + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                waitingBar.StopWaiting();
                waitingBar.Visible = false;
            }
        }

        private void BtnCancelarFac_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = GRID_VIEW_FACTURA.Rows.IndexOf(this.GRID_VIEW_FACTURA.CurrentRow);

                UnBindingFac();
                BindingFac();
                GRID_VIEW_FACTURA.Rows[fila].IsSelected = true;
                GRID_VIEW_FACTURA.Rows[fila].IsCurrent = true;

                NuevaFactura = false;

            }
            catch (Exception ex)
            {

                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        //BOTON GUARDAR FACTURA
        private void BtnGuardarFac_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones iniciales
                if (string.IsNullOrWhiteSpace(LblPOId.Text))
                {
                    MessageBox.Show("No hay PO Seleccionada", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtNumeroFa.Text))
                {
                    MessageBox.Show("Verificar Campo Número", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtPaqueteFac.Text))
                {
                    MessageBox.Show("Problema en Paquetes", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (!double.TryParse(TxtLibraFac.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double libras) || libras == 0.0)
                {
                    MessageBox.Show("Verificar el Peso", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (!int.TryParse(TxtPaqueteFac.Text.Trim(), out int paquetes))
                {
                    MessageBox.Show("Paquetes inválidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(LblPOId.Text.Trim(), out int poId))
                {
                    MessageBox.Show("PO ID inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult confirmacion1 = MessageBox.Show(
                "Se guardará la factura. ¿Desea continuar?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (confirmacion1 == DialogResult.Yes)
                {
                    wai_Factura Factura = new wai_Factura()
                    {
                        fac_id = int.TryParse(LblFacID.Text.Trim(), out int facId) ? facId : 0,
                        fac_pos_id = poId,
                        fac_numero = TxtNumeroFa.Text.Trim(),
                        fac_paquetes = paquetes,
                        fac_libras = (float)libras,
                        fac_medida = CbxMedida.Text.Trim()
                    };

                    int resultado = 0;
                    NuevaFactura = string.IsNullOrWhiteSpace(LblFacID.Text);
                    resultado = PControl.FacturaCRUD(NuevaFactura ? 1 : 2, Factura);

                    if (resultado == 1)
                    {
                        CargarFacturas();

                        if (NuevaFactura)
                        {
                            int fila = GRID_VIEW_FACTURA.Rows.Count;
                            GRID_VIEW_FACTURA.Rows[fila - 1].IsSelected = true;
                            GRID_VIEW_FACTURA.Rows[fila - 1].IsCurrent = true;
                            NuevaFactura = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la factura:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarFac_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblFacID.Text.Trim() == "")
                {
                    MessageBox.Show("No hay factura seleccionada", "¡Alto!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {

                    DialogResult confirmacion1 = MessageBox.Show(
                     "¿Está seguro de eliminar la factura?",
                     "Confirmación",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Exclamation
                    );
                    if (confirmacion1 == DialogResult.Yes)
                    {
                        var resultado = PControl.FacturaCRUD(3, LFacturas.Where(x => x.fac_id == Convert.ToInt32(LblFacID.Text.Trim())).First());
                        if (resultado == 1)
                        {
                            CargarFacturas();
                            MessageBox.Show("Factura eliminada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Imposible eliminar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var resultado = ex.GetType().FullName;

                if (ex.GetType().FullName == "System.Data.Entity.Infrastructure.DbUpdateException")
                {
                    MessageBox.Show(
                        "Imposible eliminar la factura.\nAl parecer contiene productos.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtNumeroFa_Leave(object sender, EventArgs e)
        {
            try
            {
                if (LFacturas.Where(f => f.fac_numero == TxtNumero.Text.Trim()).Count() > 0)
                {
                    LblNumeroFactura.Text = "El Número Factura ya Existe en PO";
                    LblNumeroFactura.Visible = true;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void TxtNumeroFa_KeyUp(object sender, KeyEventArgs e)
        {
            LblNumeroFactura.Visible = false;
            TxtNumeroFa.CharacterCasing = CharacterCasing.Upper;
        }
        private void TxtLibraFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;

                if ((Char.IsDigit(ch) || ch == '.') || ch == (char)8)
                {
                    if (ch == '.' && TxtLibraFac.Text.Contains('.'))
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtPaqueteFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if ((Char.IsDigit(ch)) || ch == (char)8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region EVENTOS PRODUCTO EN FACTURA
        private void BtnNuevoPro_Click(object sender, EventArgs e)
        {
            try
            {
                NuevoProducto = true;
                LblDetalleFacID.Text = "";
                CbxProducto.SelectedIndex = -1;
                TxtCantidadPro.Text = "";
                TxtPesoPro.Text = "";
                TxtLotePro.Text = "";
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void BtnGuardarPro_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblFacID.Text.Trim() == "")
                {
                    MessageBox.Show("No hay Factura Seleccionada", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (CbxProducto.Text.Trim() == "" || CbxProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("Verificar Campo Producto", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (TxtCantidadPro.Text.Trim() == "")
                {
                    MessageBox.Show("Verificar Cantidad", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (TxtPesoPro.Text.Trim() == "" || Convert.ToDouble(TxtPesoPro.Text) == 0.0)
                {
                    MessageBox.Show("Verificar el Peso", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (TxtLotePro.Text.Trim() == "")
                {
                    MessageBox.Show("Verificar Lote", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    DialogResult confirmacion1 = MessageBox.Show(
                        "Se guardará el producto en la factura.\n¿Desea continuar?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmacion1 == DialogResult.Yes)
                    {
                        if (LblDetalleFacID.Text.Trim() == "")
                        {
                            NuevoProducto = true;
                            if (LProductosFactura.Where(x => x.facd_item_id == Convert.ToInt32(CbxProducto.SelectedValue)).Count() > 0)
                            {
                                DialogResult confirmProducto = MessageBox.Show(
                                    "El producto ya existe.\n¿Desea continuar?",
                                    "Confirmación",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation
                                );

                                if (confirmProducto != DialogResult.Yes)
                                {
                                    CargarProductos();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            NuevoProducto = false;
                        }
                        string Semana = "";
                        var RegistroPO = LObjetosPO.FirstOrDefault(x => x.pos_id == Convert.ToInt32(LblPOId.Text.Trim()));

                        Semana = RegistroPO != null ? Semana = RegistroPO.pos_semana.Trim() : "";

                        var PrioridadPO = PControl.ObtenerUltimaPrioridad(Convert.ToInt32(CbxProducto.SelectedValue)).FirstOrDefault();
                        int Prioridad = 0;
                        if (PrioridadPO != null)
                        {
                            if (PrioridadPO.Semana.Trim() == Semana)
                            {
                                Prioridad = PrioridadPO.Prioridad;
                            }
                            else
                            {
                                Prioridad = PrioridadPO.Prioridad + 1;
                            }
                        }
                        else
                        {
                            Prioridad = 1;
                        }
                        ProductosFactura FacturaProducto = new ProductosFactura()
                        {
                            facd_id = LblDetalleFacID.Text.Trim() != "" ? Convert.ToInt32(LblDetalleFacID.Text.Trim()) : 0,
                            facd_item_id = Convert.ToInt32(CbxProducto.SelectedValue),
                            facd_cantidad = Convert.ToInt32(TxtCantidadPro.Text),
                            facd_peso = Convert.ToDouble(TxtPesoPro.Text),
                            facd_lote = TxtLotePro.Text.Trim(),
                            facd_prioridad = Prioridad
                        };
                        var resultado = PControl.FacturaProductoCRUD(1, Convert.ToInt32(LblFacID.Text.Trim()), FacturaProducto);
                        if (resultado == 1)
                        {
                            CargarProductos();
                            if (NuevoProducto == true)
                            {
                                int fila = GRID_VIEW_PRODUCTOS.Rows.Count;

                                GRID_VIEW_PRODUCTOS.Rows[fila - 1].IsSelected = true;
                                GRID_VIEW_PRODUCTOS.Rows[fila - 1].IsCurrent = true;
                                NuevoProducto = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica que la factura ya se haya guardado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCancelarPro_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = GRID_VIEW_PRODUCTOS.Rows.IndexOf(this.GRID_VIEW_PRODUCTOS.CurrentRow);
                UnBindingPro();
                BindingPro();
                GRID_VIEW_PRODUCTOS.Rows[fila].IsSelected = true;
                GRID_VIEW_PRODUCTOS.Rows[fila].IsCurrent = true;
                NuevoProducto = false;
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void BtnImprimirAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() != "")
                {
                    var Datos = PControl.ObtenerEstampaImpresion(1, DetalleFacID: Convert.ToInt32(LblDetalleFacID.Text.Trim()));
                    ImprimirPoductos("Imprimir Todos", Datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ImprimirPoductos(string Texto, List<Estampa> LDatos)
        {
            try
            {
                RptPackIDPO reporte = new RptPackIDPO();
                reporte.DataSource = LDatos;

                InstanceReportSource instanceReportSource = new InstanceReportSource();
                instanceReportSource.ReportDocument = reporte;

                PackIDPO popup = new PackIDPO();
                popup.reportViewer1.ReportSource = instanceReportSource;
                popup.reportViewer1.RefreshReport();
                popup.Text = Texto;
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.TopLevel = true;
                popup.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //SE IMPRIMEN TODOS AQUELLOS PACK LIST QUE NO TIENEN LOCALIDAD ASIGNADA
        private void BtnImprimirNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() != "")
                {
                    var Datos = PControl.ObtenerEstampaImpresion(1, DetalleFacID: Convert.ToInt32(LblDetalleFacID.Text.Trim())).Where(x => x.Localidad < 1).ToList();
                    if (Datos.Count > 0)
                    {
                        ImprimirPoductos("Imprimir Nuevos sin Localidad", Datos);
                    }
                    else
                    {
                        MessageBox.Show(
                            "No hay registros para imprimir",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop
                        );
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnVerLista_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() != "")
                {
                    VerLista popup = new VerLista();
                    popup.facdID = Int32.Parse(LblDetalleFacID.Text.Trim());
                    popup.LlenarGrid();
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

        private void BtnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() != "")
                {
                    ImportarPackList popup = new ImportarPackList();
                    popup.facdID = Int32.Parse(LblDetalleFacID.Text.Trim());
                    popup.libras = double.Parse(TxtPesoPro.Text.Trim());
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.TopLevel = true;
                    popup.ShowDialog();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void BtnEliminarPro_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "No hay producto seleccionado",
                        "¡Alto!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );


                }
                else
                {
                    DialogResult confirmacion1 = MessageBox.Show(
                        "¿Está seguro de eliminar el producto de la factura?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation
                    );
                    if (confirmacion1 == DialogResult.Yes)
                    {
                        var resultado = PControl.FacturaProductoCRUD(2, Convert.ToInt32(LblFacID.Text.Trim()), LProductosFactura.Where(x => x.facd_id == Convert.ToInt32(LblDetalleFacID.Text.Trim())).First());
                        if (resultado == 1)
                        {
                            CargarProductos();
                            MessageBox.Show(
                                "Eliminación realizada correctamente",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        }
                        else
                        {
                            MessageBox.Show(
                                "Imposible eliminar el producto",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtPesoPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;

                if ((Char.IsDigit(ch) || ch == '.') || ch == (char)8)
                {
                    if (ch == '.' && TxtPesoPro.Text.Contains('.'))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtPrioridadPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;

                if ((Char.IsDigit(ch)) || ch == (char)8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {

                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }
        private void TxtCantidadPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if ((Char.IsDigit(ch)) || ch == (char)8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LblDetalleFacID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // ValidarPaquetesFactura();
            }
            catch (Exception ex)
            {

                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void TxtLotePro_KeyUp(object sender, KeyEventArgs e)
        {
            TxtLotePro.CharacterCasing = CharacterCasing.Upper;
        }
        private void GRID_VIEW_PRODUCTOS_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            try
            {
                if (GRID_VIEW_PRODUCTOS.RowCount > 0)
                {
                    if (e.RowElement.RowInfo.Cells["facd_cantidad"].Value != null)
                    {

                        var DetalleID = e.RowElement.RowInfo.Cells["facd_id"].Value.ToString();
                        int cantidad = Convert.ToInt32(e.RowElement.RowInfo.Cells["facd_cantidad"].Value);
                        var Registro = LProductosFactura.Where(x => x.facd_id == Convert.ToInt32(DetalleID.Trim())).FirstOrDefault();

                        if (Registro != null)
                        {
                            if (Convert.ToInt32(cantidad) != Registro.CantidadPackList)
                            {
                                e.RowElement.DrawFill = true;
                                e.RowElement.GradientStyle = GradientStyles.Solid;
                                e.RowElement.BackColor = Color.Firebrick;
                            }
                            else
                            {
                                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                                e.RowElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                                e.RowElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (GRID_VIEW_FACTURA.CurrentRow != null)
                {
                    var selectedFactura = GRID_VIEW_FACTURA.CurrentRow.DataBoundItem as wai_Factura;

                    // Verificar si se obtuvo correctamente el objeto selectedFactura
                    if (selectedFactura == null)
                    {
                        MessageBox.Show("No factura selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Validación de los campos antes de asignarlos
                    string numeroPO = !string.IsNullOrEmpty(TxtNumero.Text) ? TxtNumero.Text : "No PO number provided";
                    string proveedor = CbxProveedor.SelectedItem != null ? CbxProveedor.SelectedItem.ToString() : "No provider selected";
                    string fecha = selectedFactura.fac_fecha.Value.ToString("MM/dd/yyyy");
                    string estado = CbxEstado.SelectedItem != null ? CbxEstado.SelectedItem.ToString() : "No state selected";
                    string semana = TxtSemana.Text;

                    // Recolecta los productos en una lista
                    List<ProductosFactura> productosList = new List<ProductosFactura>();
                    foreach (var row in GRID_VIEW_PRODUCTOS.Rows)
                    {
                        if (row.DataBoundItem is ProductosFactura producto)
                        {
                            productosList.Add(producto);
                        }
                    }
                    GenerarReporte(numeroPO, proveedor, fecha, estado, semana, selectedFactura, productosList);
                }
                else
                {
                    MessageBox.Show("No record selected in GRID_VIEW_FACTURA.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarReporte(
            string numeroPO,
            string proveedor,
            string fecha,
            string estado,
            string semana,
            wai_Factura selectedFactura,
            List<ProductosFactura> productosList)
        {
            try
            {
                sc = new SystemClass(); // Inicializa la clase de conexión

                // Obtener el nombre de usuario de Windows
                string windowsUsername = Environment.UserName;

                // Obtener el nombre de usuario de la base de datos
                string nombreUsuario = ObtenerNombreUsuarioDesdeBD(windowsUsername);
                string creadorPO = ObtenerCreadorPO(numeroPO);

                if (string.IsNullOrEmpty(nombreUsuario))
                {
                    MessageBox.Show("User not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ReportePO reporte = new ReportePO();
                reporte.ReportParameters["NumeroPO"].Value = numeroPO;
                reporte.ReportParameters["Proveedor"].Value = proveedor;
                reporte.ReportParameters["NumeroFactura"].Value = selectedFactura.fac_numero;
                reporte.ReportParameters["Paquetes"].Value = selectedFactura.fac_paquetes;
                reporte.ReportParameters["Peso"].Value = selectedFactura.fac_libras;
                if (string.IsNullOrEmpty(selectedFactura.fac_medida))
                {
                    reporte.ReportParameters["Medida"].Value = ""; // O cualquier valor predeterminado que desees
                }
                else
                {
                    reporte.ReportParameters["Medida"].Value = selectedFactura.fac_medida;
                }
                reporte.ReportParameters["FechaFactura"].Value = selectedFactura.fac_fecha.Value.ToString("MM/dd/yyyy");
                reporte.ReportParameters["NombreUsuario"].Value = nombreUsuario;
                reporte.ReportParameters["CreadorPO"].Value = creadorPO;
                reporte.DataSource = productosList;
                ReportPO reportForm = new ReportPO();
                reportForm.rptPO.ReportSource = reporte;
                reportForm.rptPO.RefreshReport();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para realizar la consulta en la base de datos
        public string ObtenerNombreUsuarioDesdeBD(string windowsUsername)
        {
            string nombreUsuario = string.Empty;
            string query = "SELECT [Usr_Name] FROM [ES_SOCKS].[dbo].[mst_Users] WHERE [Usr_login] = @windowsUsername";

            try
            {
                using (SqlConnection conn = sc.OpenConection())
                using (SqlCommand cmd = new SqlCommand(query, conn)) // Usa Conn1 de SystemClass
                {
                    cmd.Parameters.AddWithValue("@windowsUsername", windowsUsername);
                    sc.OpenConection(); // Abre la conexión a través de SystemClass
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        nombreUsuario = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre de usuario: " + ex.Message);
            }
            finally
            {
                sc.CloseConection(); // Cierra la conexión al finalizar
            }

            return nombreUsuario;
        }
        public string ObtenerCreadorPO(string numeroPO)
        {
            string creadorPO = string.Empty;
            string query = "SELECT pos_creador FROM wai_POS WHERE pos_numero = @numeroPO";

            try
            {
                using (SqlConnection conn = sc.OpenConection())
                using (SqlCommand cmd = new SqlCommand(query, conn)) // Usa Conn1 de SystemClass
                {
                    cmd.Parameters.AddWithValue("@numeroPO", numeroPO);
                    sc.OpenConection(); // Abre la conexión a través de SystemClass
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        creadorPO = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el creador del PO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sc.CloseConection(); // Cierra la conexión al finalizar
            }
            return creadorPO;
        }

        private void BtnImportar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() != "")
                {
                    ImportarPackList popup = new ImportarPackList();
                    popup.facdID = Int32.Parse(LblDetalleFacID.Text.Trim());
                    popup.libras = double.Parse(TxtPesoPro.Text.Trim());
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.TopLevel = true;
                    popup.ShowDialog();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void BtnVerLista_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (LblDetalleFacID.Text.Trim() != "")
                {
                    VerLista popup = new VerLista();
                    popup.facdID = Int32.Parse(LblDetalleFacID.Text.Trim());
                    popup.bodegaID = Convert.ToInt32(CbxBodegas.SelectedValue);  // <- Aquí se pasa la bodega
                    popup.LlenarGrid();
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
    }
}
