using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Rmc.Clases;
using Rmc.Consultas;
using Rmc.Subidas;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Rmc.Reportes.ReportesForm;
using Rmc.MaterialEmpaque;
using Rmc.Warehouse;
using Rmc.RMC.Warehouse.CycleCounts;
using Rmc.RMC.Warehouse.Reports;
using Rmc.RMC.Packaging.Reports;
using Rmc.RMC.Chemical.Reports;
using Rmc.RMC.Warehouse.Maintenance;
using Rmc.RMC.Chemical.Request;
using Rmc.RMC.Warehouse.Requests;
using Rmc.RMC.Warehouse.Transactions;
using Rmc.RMC.Packaging.Request;
using Rmc.MaterialEmpaque.Mesas;
using Rmc.MaterialEmpaque.Monitoreo;
using Rmc.MaterialEmpaque.Inventario;
using Rmc.MaterialEmpaque.Consultas;
using Rmc.MaterialEmpaque.Ventana;
using Rmc.MaterialEmpaque.Impresion;
using System.Collections.Generic;

namespace Rmc
{
    public partial class Main : Telerik.WinControls.UI.RadRibbonForm
    {
        SystemClass sc;
        string usrName;
        
        public Main()
        {
            InitializeComponent();
            //ThemeResolutionService.LoadPackageResource("Rmc.Resources.GreenPack.tssp");


            this.Text = "Rmc App - " + Application.ProductVersion;
            //lblRmcAppVersion.Text = "[+] RMC " + Application.ProductVersion;

            //ThemeResolutionService.LoadPackageResource("Rmc.Temas.TelerikMetroBluePro.tssp");
            //ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light";
            //ThemeResolutionService.LoadPackageResource("Temas.TelerikMetroBluePro.tssp");
            ThemeResolutionService.ApplicationThemeName = "Breeze";
            //ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            //ThemeResolutionService.ApplicationThemeName = "Office2007Silver";
            this.WindowState = FormWindowState.Maximized;
            sc = new SystemClass();
            sc.OpenConection();
            usrName = sc.Usuario;

            Permisos(usrName);
            // radRibbonBar1.Expanded = false;
            radRibbonBar1.RibbonBarElement.TabStripElement.Items[1].IsSelected = true;
           
        }
        


        public bool VerificarForm(string nombre)
        {
            foreach (DockWindow rd in this.radDock1.DockWindows.DocumentWindows)
            {
                System.Console.WriteLine(rd.Name.ToString());
                if (rd.Text == nombre)
                {
                    this.radDock1.ActiveWindow = rd;
                    return false;
                }
            }
            //MessageBox.Show("verdadero");
            return true;
        }


        public void Permisos(string strUsuario)
        {
            string permisos = "EXEC [usp_mst_PermissionsByUser] '" + strUsuario + "', " + sc.AppID;

            Console.WriteLine($"Ejecutando: {permisos}");

            sc.OpenConection();
            SqlDataReader mir = sc.DevDataReader(permisos);

            try
            {
                // PASO 1: Recopilar MEJORES permisos (evitar duplicados)
                Dictionary<string, decimal> mejoresPermisos = new Dictionary<string, decimal>();
                Dictionary<string, string> tiposPorNombre = new Dictionary<string, string>();

                while (mir.Read())
                {
                    string nombreBD = mir.GetString(0).Trim();
                    decimal permisoLeer = mir.GetDecimal(2);
                    string tipo = mir.GetString(6).Trim();

                    Console.WriteLine($"Leyendo BD: {nombreBD}, PLeer={permisoLeer}");

                    // Guardar el MAYOR valor de PLeer para cada nombre
                    if (!mejoresPermisos.ContainsKey(nombreBD) || permisoLeer > mejoresPermisos[nombreBD])
                    {
                        mejoresPermisos[nombreBD] = permisoLeer;
                        tiposPorNombre[nombreBD] = tipo;
                    }
                }

                // Cerrar reader temprano
                mir.Close();

                // PASO 2: Ocultar TODO por defecto
                foreach (RibbonTab tb in this.radRibbonBar1.RibbonBarElement.CommandTabs)
                {
                    tb.Visibility = ElementVisibility.Collapsed;

                    foreach (RadRibbonBarGroup gr in tb.Items)
                    {
                        gr.Visibility = ElementVisibility.Collapsed;

                        foreach (RadItem item in gr.Items)
                        {
                            item.Visibility = ElementVisibility.Collapsed;
                            item.Enabled = false;
                        }
                    }
                }

                // PASO 3: Aplicar MEJORES permisos desde el diccionario
                Console.WriteLine("\nAplicando mejores permisos:");
                foreach (var kvp in mejoresPermisos)
                {
                    string nombreBD = kvp.Key;
                    decimal permisoLeer = kvp.Value;
                    string tipo = tiposPorNombre[nombreBD];

                    Console.WriteLine($"Aplicando: {nombreBD} ({tipo}), PLeer={permisoLeer}");

                    bool encontrado = false;

                    // Buscar en pestañas
                    foreach (RibbonTab tab in radRibbonBar1.RibbonBarElement.CommandTabs)
                    {
                        if (tab.Name == nombreBD)
                        {
                            // Para pestañas: NO las mostramos aquí, las evaluaremos después
                            // Solo marcamos que existe
                            encontrado = true;
                            Console.WriteLine($"  ✓ Es pestaña: {tab.Name}");
                            break;
                        }

                        // Buscar en grupos
                        foreach (RadRibbonBarGroup grupo in tab.Items)
                        {
                            if (grupo.Name == nombreBD)
                            {
                                bool visible = (permisoLeer > 0);
                                grupo.Visibility = visible ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                                grupo.Enabled = visible;
                                encontrado = true;
                                Console.WriteLine($"  ✓ Es grupo: {grupo.Name}, Visible={visible}");
                                break;
                            }

                            // Buscar en items
                            foreach (RadItem item in grupo.Items)
                            {
                                if (item.Name == nombreBD)
                                {
                                    bool visible = (permisoLeer > 0);
                                    item.Visibility = visible ? ElementVisibility.Visible : ElementVisibility.Collapsed;
                                    item.Enabled = visible;  // IMPORTANTE: mismo valor que Visibility
                                    encontrado = true;
                                    Console.WriteLine($"  ✓ Es item: {item.Name}, Visible={visible}, Enabled={visible}");
                                    break;
                                }
                            }

                            if (encontrado) break;
                        }

                        if (encontrado) break;
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine($"  ✗ No encontrado en controles: {nombreBD}");
                    }
                }

                // PASO 4: Evaluar pestañas (mostrar solo si tienen grupos/items visibles)
                Console.WriteLine("\nEvaluando pestañas:");
                foreach (RibbonTab tb in this.radRibbonBar1.RibbonBarElement.CommandTabs)
                {
                    bool pestañaTieneVisible = false;

                    foreach (RadRibbonBarGroup gr in tb.Items)
                    {
                        bool grupoTieneVisible = false;

                        // Verificar si el grupo tiene items visibles
                        foreach (RadItem item in gr.Items)
                        {
                            if (item.Visibility == ElementVisibility.Visible && item.Enabled)
                            {
                                grupoTieneVisible = true;
                                break;
                            }
                        }

                        // También considerar si el grupo mismo es visible
                        if (gr.Visibility == ElementVisibility.Visible)
                        {
                            grupoTieneVisible = true;
                        }

                        // Actualizar visibilidad del grupo
                        gr.Visibility = grupoTieneVisible ?
                            ElementVisibility.Visible : ElementVisibility.Collapsed;

                        if (grupoTieneVisible)
                        {
                            pestañaTieneVisible = true;
                            Console.WriteLine($"  Grupo visible: {gr.Name}");
                        }
                    }

                    // Actualizar visibilidad de la pestaña
                    tb.Visibility = pestañaTieneVisible ?
                        ElementVisibility.Visible : ElementVisibility.Collapsed;

                    Console.WriteLine($"Pestaña '{tb.Name}': {(pestañaTieneVisible ? "VISIBLE" : "OCULTA")}");
                }

                Console.WriteLine("=== FIN PERMISOS ===");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e.Message);
            }
            finally
            {
                sc.CloseConection();
            }
        }


        private void DebugNombresControles()
        {
            Console.WriteLine("\n=== DEBUG: NOMBRES DE CONTROLES ===");

            // Verificar AppID primero
            Console.WriteLine($"AppID actual: {sc.AppID}");

            // Listar todos los controles con sus nombres
            int contador = 0;
            foreach (RibbonTab tab in radRibbonBar1.RibbonBarElement.CommandTabs)
            {
                contador++;
                Console.WriteLine($"{contador}. Pestaña: Name='{tab.Name}', Text='{tab.Text}'");

                foreach (RadRibbonBarGroup grupo in tab.Items)
                {
                    contador++;
                    Console.WriteLine($"   {contador}. Grupo: Name='{grupo.Name}', Text='{grupo.Text}'");

                    foreach (RadItem item in grupo.Items)
                    {
                        contador++;
                        Console.WriteLine($"      {contador}. Item: Name='{item.Name}', Text='{item.Text}'");
                    }
                }
            }

            Console.WriteLine($"Total controles encontrados: {contador}");
        }


        private void ProbarPermisosCompleto()
        {
            //Console.Clear();  // Limpiar consola para mejor visualización

            // 1. Debug de nombres
            DebugNombresControles();

            // 2. Verificar AppID
            Console.WriteLine($"\n=== CONFIGURACIÓN ===");
            Console.WriteLine($"Usuario: algaldam");
            Console.WriteLine($"AppID: {sc.AppID}");

            // 3. Ejecutar SP directamente para ver qué devuelve
            Console.WriteLine($"\n=== EJECUTANDO SP ===");
            string query = $"EXEC [usp_mst_PermissionsByUser] @UsLogin = 'algaldam', @App = {sc.AppID}";
            Console.WriteLine($"Query: {query}");

            try
            {
                sc.OpenConection();
                SqlDataReader reader = sc.DevDataReader(query);

                Console.WriteLine("\nResultados del SP:");
                Console.WriteLine("Nombre BD        | Tipo     | PLeer");
                Console.WriteLine("-----------------|----------|------");

                while (reader.Read())
                {
                    string nombre = reader.GetString(0).Trim();
                    decimal pleer = reader.GetDecimal(2);
                    string tipo = reader.GetString(6).Trim();

                    Console.WriteLine($"{nombre,-16} | {tipo,-8} | {pleer}");
                }

                reader.Close();
                sc.CloseConection();

                // 4. Ahora ejecutar el método Permisos
                Console.WriteLine($"\n=== EJECUTANDO MÉTODO Permisos() ===");
                Permisos("algaldam");

                // 5. Ver resultado final
                Console.WriteLine($"\n=== ESTADO FINAL DE CONTROLES ===");
                foreach (RibbonTab tab in radRibbonBar1.RibbonBarElement.CommandTabs)
                {
                    Console.WriteLine($"Pestaña '{tab.Name}': {tab.Visibility}");

                    foreach (RadRibbonBarGroup grupo in tab.Items)
                    {
                        Console.WriteLine($"  Grupo '{grupo.Name}': {grupo.Visibility}");

                        foreach (RadItem item in grupo.Items)
                        {
                            Console.WriteLine($"    Item '{item.Name}': {item.Visibility}, Enabled={item.Enabled}");
                        }
                    }
                }

                //MessageBox.Show("Prueba completada. Revisa la consola.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Temporal: para pruebas
            ProbarPermisosCompleto();

            // O desde un botón:
            // button1.Click += (s, args) => ProbarPermisosCompleto();
        }

        /// <summary>
        /// CREATED BY DAVID AYALA
        /// </summary>
        /// 

        private void SubSobrantesExcel_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Carga Sobrantes") != false)
                sc.CargarFormulario(new frmSobrantes(), this, radDock1);
        }

        private void SubBomExcelClick(object sender, EventArgs e)
        {
            if (VerificarForm("BOM") != false)
                sc.CargarFormulario(new SubBOMExcel(), this, radDock1);
        }

        private void radButtonElement5_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Mantemiento Semanas") != false)
                sc.CargarFormulario(new frmMtnSemanas(), this, radDock1);
        }

        private void SubidaArchivos_Click(object sender, EventArgs e)
        {
            radRibbonBar1.Expanded = true;

        }

        private void Consultas_Click(object sender, EventArgs e)
        {
            radRibbonBar1.Expanded = true;
        }

        private void BtnRptPlan_Click(object sender, EventArgs e)
        {

        }

        private void ConsTransacciones_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Transacciones") != false)
            {
                frmTransacciones consTransacciones = new frmTransacciones();
                sc.CargarFormulario(consTransacciones, this, radDock1);
            }
        }

        private void ConsSobrantes_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Consultar Sobrantes") != false)
                sc.CargarFormulario(new frmListSobrantes(), this, radDock1);
        }

        private void ConsSobrantesNo_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Consultar Ordenes") != false)
                sc.CargarFormulario(new ConsOrdenes(), this, radDock1);
        }

        private void rbtnRequiMatBodega_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Solicitudes de req.") != false)
                sc.CargarFormulario(new RequisicionMaterialBodega(), this, radDock1);
        }

        private void rbtnBOM_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Impresión BOM") != false)
                sc.CargarFormulario(new BOMForm(), this, radDock1);
        }

        private void rbtnInventarioMat_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario Material") != false)
                sc.CargarFormulario(new InventarioMaterial(), this, radDock1);
        }

        private void rbtnDevWaste_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Devolucion y Desperdicio") != false)
                sc.CargarFormulario(new DevolucionDesperdicio(), this, radDock1);
        }

        private void SubidaIRR_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Carga Irregulares") != false)
                sc.CargarFormulario(new SubIRR(), this, radDock1);
        }

        private void BagIRR_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Bolsa de Irregulares") != false)
                sc.CargarFormulario(new BagIrr(), this, radDock1);
        }

        private void Dobladoirr_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Doblado de Irregulares") != false)
                sc.CargarFormulario(new DobladoIRR(), this, radDock1);
        }

        private void ConsolidadosPlan_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Consolidado de Planes") != false)
                sc.CargarFormulario(new Consolidado_de_Planes(), this, radDock1);
        }

        private void ProductMaster_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Product Master") != false)
                sc.CargarFormulario(new ProductMaster(), this, radDock1);
        }

        private void Desviaciones_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Desviaciones") != false)
                sc.CargarFormulario(new Desviaciones(), this, radDock1);
        }

        private void rbtnReport_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Reporteria de Inventario") != false)
                sc.CargarFormulario(new ReporteriaInventario(), this, radDock1);
        }

        private void UPC_Click(object sender, EventArgs e)
        {
            if (VerificarForm("UPC") != false)
                sc.CargarFormulario(new UPC(), this, radDock1);
        }

        private void btnBodega_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Material de Bodega") != false)
                sc.CargarFormulario(new MaterialDeBodega(), this, radDock1);
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Manto Users") != false)
                sc.CargarFormulario(new MantoUsers(), this, radDock1);
        }

        private void rbtnPreKiteoSaca_Click(object sender, EventArgs e)
        {
            if (VerificarForm("PreKiteoSACA") != false)
                sc.CargarFormulario(new PreKiteoSACA(), this, radDock1);
        }

        private void Células_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Celulas") != false)
                sc.CargarFormulario(new Celulas(), this, radDock1);
        }

        private void Maquinas_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Maquinas") != false)
                sc.CargarFormulario(new Maquinas(), this, radDock1);
        }

        private void BtnHistoricoID_Click(object sender, EventArgs e)
        {
            if (VerificarForm("HistoricosID") != false)
                sc.CargarFormulario(new Consolidado_de_Planes(), this, radDock1);
            //sc.CargarFormulario(new HistoricosID(), this, radDock1);
        }

        private void StickersBtn_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Subida de Stickers") != false)
                sc.CargarFormulario(new Subida_de_Stickers(), this, radDock1);
        }

        #region Developed by Alex Galdamez - May 2025

        #region Menu Buttons - Warehouse Inventory Transactions
        private void btnWarehouseSalidas_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Salidas") != false)
                sc.CargarFormulario(new InventoryExitsForm(), this, radDock1);
        }
        private void btnWarehouseRecepcion_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Entradas") != false)
                sc.CargarFormulario(new InventoryReceiptForm(), this, radDock1);
        }
        private void btnWarehousePrioridades_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Prioridades") != false)
                sc.CargarFormulario(new PrioritiesForm(), this, radDock1);
        }
        private void btnWarehouseDevoluciones_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Devoluciones") != false)
                sc.CargarFormulario(new ReturnsForm(), this, radDock1);
        }

        private void btnWarehouseEnvios_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Envios") != false)
                sc.CargarFormulario(new ShipmentsForm(), this, radDock1);
        }

        private void btnWarehouseTransf_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Traslados") != false)
                sc.CargarFormulario(new TransfersForm(), this, radDock1);
        }
        private void btnProductionDate_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Produccion") != false)
                sc.CargarFormulario(new ProductionDateForm(), this, radDock1);
        }
        #endregion

        #region Menu Buttons - Warehouse Request
        private void btnWarehouseListChemicalRequest_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Solicitudes de Quimicos - Bodega") != false)
                sc.CargarFormulario(new WarehouseChemicalRequest(), this, radDock1);
        }

        private void btnWarehouseReportRequestPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Listado Solicitudes") != false)
                sc.CargarFormulario(new frmOrdenesRpt(), this, radDock1);
        }

        private void btnWarehouseListPackagingRequest_Click_1(object sender, EventArgs e)
        {
            if (VerificarForm("Solicitudes Regulares") != false)
                sc.CargarFormulario(new frmListadoSolicitud(), this, radDock1);
        }

        private void btnWarehouseRequestPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Mantenimiento Solicitudes") != false)
                sc.CargarFormulario(new frmConsSolicitud(), this, radDock1);
        }

        private void btnWarehouseDailyDeliveriesPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Entregas Diarias") != false)
                sc.CargarFormulario(new frmEntregas(), this, radDock1);
        }
        #endregion

        #region  Menu Buttons - Warehouse Cycle Counts Inv
        private void btnWarehouseConteoCiclico_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Conteo Ciclico") != false)
                sc.CargarFormulario(new CycleCountInvForm(), this, radDock1);
        }
        #endregion

        #region  Menu Buttons - Warehouse Reports
        private void btnWarehouseReporte_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario") != false)
                sc.CargarFormulario(new WarehouseReportForm(), this, radDock1);
        }
        private void btnWarehouseTransacReport_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Transacciones") != false)
                sc.CargarFormulario(new WarehouseTransactionsForm(), this, radDock1);
        }

        private void btnWarehouseItems_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Items") != false)
                sc.CargarFormulario(new WarehouseItemsForm(), this, radDock1);
        }

        private void btnWarehouseEntregaSolicitudes_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Entrega de Solicitudes") != false)
                sc.CargarFormulario(new WarehouseDeliveryForm(), this, radDock1);
        }
        #endregion

        #region Menu Buttons - Warehouse Maintenance

        private void btnWarehouseArea_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Areas") != false)
                sc.CargarFormulario(new Areas(), this, radDock1);

        }
        private void btnWarehousesMant_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Bodegas") != false)
                sc.CargarFormulario(new WarehousesForm(), this, radDock1);
        }
        private void btnWarehouseLocalities_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Localidades") != false)
                sc.CargarFormulario(new LocalitiesForm(), this, radDock1);
        }

        private void btnWarehouseProduct_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Productos") != false)
                sc.CargarFormulario(new ProductsForm(), this, radDock1);
        }

        private void btnWarehouseSuppliers_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Proveedores") != false)
                sc.CargarFormulario(new SuppliersForm(), this, radDock1);
        }
        #endregion

        #region  Menu Buttons - Packaging Inventory Reports
        private void btnInvetoryReportPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario de Empaquetado") != false)
                sc.CargarFormulario(new PackagingInventoryForm(), this, radDock1);
        }

        private void btnPackagingItems_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Empaquetado") != false)
                sc.CargarFormulario(new PackagingItemsForm(), this, radDock1);
        }

        private void btnPackagingTransactions_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Bodega de Empaque") != false)
                sc.CargarFormulario(new PackagingTransactionsForm(), this, radDock1);
        }
        private void btnPackagingRequestDelivery_Click(object sender, EventArgs e)
        {
            if (VerificarForm("") != false)
                sc.CargarFormulario(new PackagingRequestDeliveryForm(), this, radDock1);
        }
        #endregion

        #region Menu Buttons - Packaging Request / Plan
        private void btnSendRequestPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Carga Solicitudes") != false)
                sc.CargarFormulario(new frmSolicitudes(), this, radDock1);
        }

        private void btnListPackagingRequest_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Solicitudes Regulares") != false)
                sc.CargarFormulario(new frmListadoSolicitud(), this, radDock1);
        }
        private void btnPlanDetailPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Detalle Plan") != false)
                sc.CargarFormulario(new frmRtpPlan(), this, radDock1);
        }

        private void btnWeeklyPlanPackaging_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Planes") != false)
                sc.CargarFormulario(new frmSubidaPlan(), this, radDock1);
        }
        #endregion

        #region  Menu Buttons - Chemicals Inventory Reports
        private void btnChemicalsItems_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Quimicos") != false)
                sc.CargarFormulario(new ChemicalsItemsForm(), this, radDock1);
        }
        private void btnWarehouseChemicalTran_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Bodega de Quimicos") != false)
                sc.CargarFormulario(new ChemicalsTransactionsForm(), this, radDock1);
        }
        private void btnWerehouseChemicalReport_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario de Quimicos") != false)
                sc.CargarFormulario(new ChemicalsInventoryForm(), this, radDock1);
        }

        private void btnChemicalRequestDelivery_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Entrega Solicitudes - Quimicos") != false)
                sc.CargarFormulario(new ChemicalsRequestDeliveryForm(), this, radDock1);
        }
        #endregion

        #region Menu Buttons - Chemicals Request / Plan
        private void btnListChemicalRequest_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Solicitudes de Quimicos") != false)
                sc.CargarFormulario(new ListChemicalsRequestForm(), this, radDock1);
        }
        private void btnCreateRequestChemical_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Crear Solicitud para Quimicos") != false)
                sc.CargarFormulario(new CreateChemicalRequestForm(), this, radDock1);
        }
        private void btnWeeklyPlanChemical_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Plan Senamal") != false)
                sc.CargarFormulario(new WeeklyPlanForm(), this, radDock1);
        }

        #endregion

        #region Menu Buttons - Yarm Request / Plan
        private void btnInventoryReportYarn(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario de Hilos") != false)
                sc.CargarFormulario(new YarmInventoryForm(), this, radDock1);
        }

        #endregion

        #endregion

        private void btnPOS_Click(object sender, EventArgs e)
        {
            if (VerificarForm("PO") != false)
                sc.CargarFormulario(new frmPO(), this, radDock1);
        }

        private void radButtonElement6_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Control de Mesas") != false)
                sc.CargarFormulario(new MesasForm(), this, radDock1);
        }

        private void btnMonitoringTraceIds_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Monitoreo TraceIDs") != false)
                sc.CargarFormulario(new MonitoreoTraceIDs(), this, radDock1);
        }

        private void btnPreparacionPkg_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Preparacion de Material") != false)
                sc.CargarFormulario(new PreparacionForm(), this, radDock1);
        }


        private void rbtnPlanSemanal_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Planes") != false)
                sc.CargarFormulario(new frmSubidaPlan(), this, radDock1);
        }
        private void rbtnInvPreparacion_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario - Preparacion") != false)
                sc.CargarFormulario(new InventarioPreparacionForm(Environment.UserName, 1, "Preparacion"), this, radDock1);
        }

        private void rbtnInventoryVtn_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario - PrintHub") != false)
                sc.CargarFormulario(new InventarioPreparacionForm(Environment.UserName, 2, "PrintHub"), this, radDock1);
        }

        private void rbtnInventarioVent_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario - Ventana") != false)
                sc.CargarFormulario(new InventarioPreparacionForm(Environment.UserName, 3, "Ventana"), this, radDock1);
        }

        private void rbtnDashboardPreparacion_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Dashboard de Preparación") != false)
                sc.CargarFormulario(new VistaPreparacionForm(), this, radDock1);
        }

        private void btnReporteInventario_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Reporte de Inventario") != false)
                sc.CargarFormulario(new ReporteInventarioForm(), this, radDock1);
        }

        private void rbtnVentana_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Consumos en Ventana") != false)
                sc.CargarFormulario(new VentanaForm(), this, radDock1);
        }

        private void btnConsultarInventario_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Consultar Inventario por Estado") != false)
                sc.CargarFormulario(new ConsultarInventarioForm(), this, radDock1);
        }

        private void btnRequestOver_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Impresion de Sobreconsumos") != false)
                sc.CargarFormulario(new SolicitudSobreconsumos(), this, radDock1);
        }

        private void rbtnSobrantes_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario de Sobrantes") != false)
                sc.CargarFormulario(new InventarioSobrantesForm(), this, radDock1);
        }

        private void rbtnCrearSobreConsumo_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Solicitudes de Sobreconsumos") != false)
                sc.CargarFormulario(new SobreconsumosForm(), this, radDock1);
        }

        private void btnWasteLogReport_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Reporte de Desperdicio") != false)
                sc.CargarFormulario(new WasteLogReportForm(), this, radDock1);
        }

        private void btnInvOverview_Click(object sender, EventArgs e)
        {
            if (VerificarForm("Inventario General") != false)
                sc.CargarFormulario(new InventoryOverviewForm(), this, radDock1);
        }
    }

}
