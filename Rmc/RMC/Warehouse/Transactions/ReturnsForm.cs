using Rmc.Clases;
using Rmc.Consultas;
using Rmc.Controllers;
using Rmc.Reportes.ReportesDesign;
using Rmc.Reportes.ReportesForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.Warehouse
{
    public partial class ReturnsForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        string sql;
        SqlConnection conn;

        DevolucionController DControl = new DevolucionController();
        BodegaController BControl = new BodegaController();
        NConformeController NOControl = new NConformeController();
        InventarioController InvControl = new InventarioController();

        public ReturnsForm()
        {
            InitializeComponent();
            CargarBodegas();
            sc.ApplyComparer(CBX_PRODUCTOS);
            sc.ApplyComparer(CBX_PROVEEDORES);
            sc.ApplyComparer(CBX_DEFECTOS);
            CBX_BODEGAS.SelectedIndex = -1;
        }
        #endregion

        #region METODOS
        private void CargarBodegas()
        {
            try
            {
                sc.OpenConection();
                sql = "SELECT  bod_id, CONCAT(bod_nombre,' - ',bod_descripcion) AS bod_nombre FROM wai_Bodegas";
                sc.LlenarDropDownList(CBX_BODEGAS, sql, "bod_nombre", "bod_id");
                sc.CloseConection();
                CBX_BODEGAS.SelectedIndex = -1;
                CBX_PROVEEDORES.DataSource = InvControl.ObtenerProveedor();
                CBX_PROVEEDORES.SelectedIndex = -1;

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void LlenarItem(int bodega)
        {
            try
            {
                if (CBX_BODEGAS.SelectedIndex != -1)
                {
                    sql = "SELECT ite_id, CONCAT(ite_codigo,' - ',ite_descripcion) AS item FROM wai_Item WHERE ite_bodega_id = '" + bodega + "' "
                        + " ORDER BY ite_codigo";

                    sc.LlenarDropDownList(CBX_PRODUCTOS, sql, "item", "ite_id");
                    this.CBX_PRODUCTOS.DropDownListElement.DropDownWidth = 350;
                    CBX_PRODUCTOS.SelectedIndex = -1;
                }
                else
                    CBX_PRODUCTOS.DataSource = null;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void LlenarLocalidad(int opcion = 1)
        {
            try
            {
                CBX_LOCALIDADES.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, opcion);
                CBX_LOCALIDADES.SelectedIndex = -1;
                CBX_DEFECTOS.DataSource = NOControl.ObtenerDefectos();
                CBX_DEFECTOS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        // EVENTO PARA CAMBIO DE INDICE EN COMBO  BODEGAS
        private void ddlBodegas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (CBX_BODEGAS.SelectedIndex != -1)
            {
                if (CHECK_NO_CONFORME.Checked == true)
                {
                    LlenarLocalidad(2);
                    CBX_DEFECTOS.Enabled = true;
                }
                else if (CHECK_NO_CONFORME.Checked == false)
                {
                    LlenarLocalidad();
                    CBX_DEFECTOS.Enabled = false;
                }
                CBX_LOCALIDADES.Enabled = true;
                this.LlenarItem(Int32.Parse(CBX_BODEGAS.SelectedValue.ToString()));
            }
            else
            {
                CBX_PRODUCTOS.DataSource = null;
                CBX_LOCALIDADES.Enabled = false;
                GRID_VIEW_PACK_LIST.DataSource = null;
            }
        }

        private void ddlLocalidad_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (CBX_LOCALIDADES.SelectedIndex > -1)
                {
                    LlenarGridPackList();
                }
                else
                {
                    GRID_VIEW_PACK_LIST.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void ddlItem_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (CBX_PRODUCTOS.SelectedIndex != -1)
                {
                    CargarLotes();
                }
                else
                {
                    ddlLote.DataSource = null;
                    GRID_VIEW_PACK_LIST.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void LlenarGridPackList()
        {
            try
            {
                sql = "SELECT D.dev_id as IDDEV, D.dev_codigo AS PACKID, CONCAT(I.ite_codigo,' - ',I.ite_descripcion) AS ITEM, L.loc_nombre AS LOCALIDAD, "
                        + " D.dev_lote AS LOTE, D.dev_libras AS LIBRAS, (D.dev_libras - ISNULL(D.dev_libras_out,0)) AS LBSDISPONIBLEs, D.dev_fecha_in AS FECHA_ENTRADA "
                        + " FROM wai_Item AS I "
                        + " INNER JOIN wai_Devoluciones AS D ON D.dev_item_id = I.ite_id "
                        + " INNER JOIN wai_Localidad AS L ON L.loc_id = D.dev_localidad_id "
                        + " LEFT JOIN wai_Transacciones_Devoluciones AS TD ON TD.tra_dev_dev_id = D.dev_id "
                        + " WHERE D.dev_localidad_id = '" + CBX_LOCALIDADES.SelectedValue.ToString() + "' AND D.dev_fecha_out IS NULL AND D.dev_libras>ISNULL(D.dev_libras_out,0) "
                        + " GROUP BY D.dev_id, D.dev_codigo, I.ite_codigo, I.ite_descripcion, L.loc_nombre, D.dev_lote, D.dev_prioridad, D.dev_libras, D.dev_libras_out, D.dev_fecha_in "
                        + " ORDER BY PACKID";
                Console.WriteLine(sql);
                sc.OpenConection();
                sc.LlenarGrid(GRID_VIEW_PACK_LIST, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void CargarLotes()
        {
            try
            {
                if (CBX_PRODUCTOS.SelectedIndex != -1)
                {
                    sql = "SELECT * FROM (SELECT facd_lote AS LOTE FROM wai_Factura_Detalle WHERE facd_item_id= '" + CBX_PRODUCTOS.SelectedValue.ToString() + "'  UNION ALL "
                        + " SELECT dev_lote AS LOTE FROM wai_Devoluciones WHERE dev_item_id='" + CBX_PRODUCTOS.SelectedValue.ToString() + "') AS LOTES GROUP BY LOTES.LOTE ";
                    sc.OpenConection();
                    sc.LlenarDropDownList(ddlLote, sql, "LOTE", "LOTE");
                    sc.CloseConection();
                    ddlLote.SelectedIndex = -1;
                }
                else
                    ddlLote.DataSource = null;

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        //METODO PARA ALMACENAR DEVOLUCIONES CON LOS COMMPOS NECESARIOS
        private void DevolucionPackList(string opcion)
        {
            try
            {
                string[] campos = new string[] { "CBX_PRODUCTOS", "CBX_LOCALIDADES", "txtLibras", "ddlLote", "CBX_PROVEEDORES" };
                bool validacion = sc.RadControlNotNull(this, campos);

                if (validacion == true)
                {
                    string idDev = string.Empty;
                    bool resultado = false;
                    Tuple<bool, int> RTupla;
                    if (CHECK_NO_CONFORME.Checked == true)
                    {
                        RTupla = DControl.ActualizarDevolucion(opcion, CBX_PRODUCTOS.SelectedValue.ToString(), CBX_LOCALIDADES.SelectedValue.ToString(), txtLibras.Text.ToString(), ddlLote.Text.ToString(), Convert.ToInt32(CBX_PROVEEDORES.SelectedValue.ToString()), Convert.ToInt32(CBX_DEFECTOS.SelectedValue.ToString()), 1);

                    }
                    else
                    {
                        RTupla = DControl.ActualizarDevolucion(opcion, CBX_PRODUCTOS.SelectedValue.ToString(), CBX_LOCALIDADES.SelectedValue.ToString(), txtLibras.Text.ToString(), ddlLote.Text.ToString(), Convert.ToInt32(CBX_PROVEEDORES.SelectedValue.ToString()));
                    }


                    if (RTupla.Item1 == false)
                    {
                        txtLibras.BackColor = default(Color);
                        ddlLote.BackColor = default(Color);
                        MessageBox.Show("La Devolución no fue guardada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtLibras.BackColor = default(Color);
                        ddlLote.BackColor = default(Color);
                        txtLibras.Text = String.Empty;
                        CBX_PRODUCTOS.SelectedIndex = -1;
                        CBX_PROVEEDORES.SelectedIndex = -1;
                        CBX_DEFECTOS.SelectedIndex = -1;
                        LlenarGridPackList();
                        var LDatos = DControl.ObtenerEstampaDevoluciones(RTupla.Item2.ToString());
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
                else
                    MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void ImprimirDevolucion(GridViewRowInfo row)
        {
            try
            {
                var IdDevolucion = DControl.ObtenerIdDevolucion(row.Cells[1].Value.ToString());
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

        private void EliminarDevolucion(GridViewRowInfo row)
        {
            try
            {
                string PackID = row.Cells[0].Value.ToString();
                DialogResult confirmacion1 = MessageBox.Show("Se eliminara el Pack ID " + row.Cells[1].Value.ToString() + " del Pack List. ¿Desea continuar?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmacion1 == DialogResult.OK)
                {
                    sql = "SELECT COUNT(*) FROM wai_Transacciones_Devoluciones WHERE tra_dev_dev_id = '" + PackID + "'";
                    sc.OpenConection();
                    if (int.Parse(sc.DevValorString(sql)) > 0)
                    {
                        DialogResult confirmacion2 = MessageBox.Show("El Pack ID " + row.Cells[1].Value.ToString() + " tiene registros de salida, ¿Esta seguro de eliminarlo?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (confirmacion2 == DialogResult.OK)
                            EliminarDevolucion2(PackID);
                    }
                    else
                    {
                        EliminarDevolucion2(PackID);
                    }
                }
                LlenarGridPackList();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void EliminarDevolucion2(string PackID)
        {
            try
            {
                sql = "DELETE FROM wai_Transacciones_Devoluciones WHERE tra_dev_dev_id ='" + PackID + "'; DELETE FROM wai_Devoluciones WHERE dev_id= '" + PackID + "'";
                sc.OpenConection();
                if (sc.EjecutarQuery(sql))
                {
                    MessageBox.Show("Pack ID eliminado del Pack List", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Pack ID no puede ser eliminado del Pack List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        #endregion

        #region EVENTOS

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion1 = MessageBox.Show("¿Desea agregar a una devolución ya existente?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (confirmacion1 == DialogResult.Yes)
            {
                DevolucionPackList("U");
            }
            else if (confirmacion1 == DialogResult.No)
            {
                DevolucionPackList("C");
            }
        }

        private void btnVerDevoluciones_Click(object sender, EventArgs e)
        {
            try
            {
                VerDevoluciones popup = new VerDevoluciones();
                popup.LlenarGrid();
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.TopLevel = true;

                popup.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void rgvDevPackList_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.Column.Name == "imprimir")
                    ImprimirDevolucion(e.Row);
                if (e.Column.Name == "eliminar")
                {
                    EliminarDevolucion(e.Row);
                }
            }
        }
        private void CHECK_NO_CONFORME_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                if (CBX_BODEGAS.SelectedIndex != -1)
                {
                    if (CHECK_NO_CONFORME.Checked == true)
                    {
                        LlenarLocalidad(2);
                        CBX_DEFECTOS.Enabled = true;
                    }
                    else if (CHECK_NO_CONFORME.Checked == false)
                    {
                        LlenarLocalidad();
                        CBX_DEFECTOS.Enabled = false;
                    }
                    CBX_LOCALIDADES.Enabled = true;
                }
                else
                {
                    CBX_PRODUCTOS.DataSource = null;
                    CBX_LOCALIDADES.Enabled = false;
                    GRID_VIEW_PACK_LIST.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
