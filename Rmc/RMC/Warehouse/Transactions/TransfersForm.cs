using Rmc.Clases;
using Rmc.Consultas;
using Rmc.Controllers;
using Rmc.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.Warehouse
{
    public partial class TransfersForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        NConformeController NControl = new NConformeController();
        BodegaController BControl = new BodegaController();
        SystemClass sc = new SystemClass();
        string sql;
        List<LocalidadTraslados> LItemsLocalidad = new List<LocalidadTraslados>();

        public TransfersForm()
        {
            InitializeComponent();
            this.CBX_ORIGEN.DropDownListElement.DropDownWidth = 100;
            this.CBX_DESTINO.DropDownListElement.DropDownWidth = 100;
            this.ddlItem.DropDownListElement.DropDownWidth = 450;
            LlenarLocalidad();
            LlenarItem();
        }

        #endregion
        #region METODOS
        // SE LLENAN LOS COMBOS PARA LOCALIDAD DE ORIGEN Y DESTINO SEGUN  CONFORMIDAD
        private void LlenarLocalidad(int opcion = 1)
        {
            //SI opcion =1  SE OBTIENEN LOCALIDADES QUE NO CONTIENEN PNC 
            try
            {
                if (CHK_CONFORMIDAD.Checked == true)
                {
                    if (RB_INGRESO.IsChecked == true)
                    {
                        CBX_ORIGEN.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, 1);
                        CBX_ORIGEN.SelectedIndex = -1;
                    }
                    else
                    {
                        CBX_ORIGEN.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, 2);
                        CBX_ORIGEN.SelectedIndex = -1;
                    }

                    if (RB_SALIDA.IsChecked == true)
                    {
                        CBX_DESTINO.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, 1);
                        CBX_DESTINO.SelectedIndex = -1;
                    }
                    else
                    {
                        CBX_DESTINO.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, 2);
                        CBX_DESTINO.SelectedIndex = -1;
                    }
                }
                else
                {
                    CBX_ORIGEN.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, 1);
                    CBX_ORIGEN.SelectedIndex = -1;
                    CBX_DESTINO.DataSource = BControl.ObtenerLocalidad(Filtro.Especifico, 1);
                    CBX_DESTINO.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Trasladar()
        {
            try
            {

                if (CBX_DESTINO.SelectedIndex > -1)
                {
                    if (LItemsLocalidad.Where(x => x.MARCAR == true).Count() > 0)
                    {
                        int contador = 0;
                        bool procesado = false;
                        string packID = string.Empty;
                        if (CHK_CONFORMIDAD.Checked == true)
                        {
                            if (RB_INGRESO.IsChecked == true)
                            {
                                frmTrasladoConformidad dialog = new frmTrasladoConformidad();
                                dialog.LNoConformidadTraslado = LItemsLocalidad.Where(x => x.MARCAR == true).ToList();
                                dialog.LocalidadDestino = Convert.ToInt32(CBX_DESTINO.SelectedItem.Value.ToString());
                                dialog.ShowDialog();
                                procesado = true;

                            }
                            else if (RB_SALIDA.IsChecked == true)
                            {
                                procesado = NControl.ActualizarLocalidad(LItemsLocalidad.Where(x => x.MARCAR == true).ToList(), Convert.ToInt32(CBX_DESTINO.SelectedItem.Value.ToString()), true);
                            }
                        }
                        else
                        {
                            procesado = NControl.ActualizarLocalidad(LItemsLocalidad.Where(x => x.MARCAR == true).ToList(), Convert.ToInt32(CBX_DESTINO.SelectedItem.Value.ToString()), false);
                        }
                        if (procesado == true)
                        {
                            MessageBox.Show("Cambio de Localidad realizado con éxito", "Éxtio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Ocurrio un error con los siguientes PackID " + packID + " y no se cambió su localidad.");
                        Console.WriteLine(contador.ToString());
                        SeleccionarOrigen();
                    }
                    else
                    {
                        MessageBox.Show("Aun no se han seleccionado Registros", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Debe seleccionar una localidad de destino", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenaLocalidadItem(string filtro)
        {
            try
            {
                LItemsLocalidad.Clear();
                LItemsLocalidad = null;
                LItemsLocalidad = NControl.ObtenerItemPorLocalidad(filtro);
                GRID_VIEW_TRASLADOS.DataSource = null;
                GRID_VIEW_TRASLADOS.DataSource = LItemsLocalidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LlenarItem()
        {
            try
            {
                sql = "SELECT ite_id, CONCAT(ite_codigo,' - ',ite_descripcion) AS item FROM wai_Item WHERE ite_bodega_id = '1' ORDER BY ite_codigo";
                sc.LlenarDropDownList(ddlItem, sql, "item", "ite_id");
                ddlItem.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void SeleccionarOrigen()
        {
            try
            {
                if (CBX_ORIGEN.SelectedIndex != -1)
                {
                    sql = " AND L.loc_id='" + CBX_ORIGEN.SelectedValue.ToString() + "' ";
                    LlenaLocalidadItem(sql);
                }
                else
                {
                    GRID_VIEW_TRASLADOS.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        #endregion
        #region EVENTOS
        private void rcbLocalidad_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (args.ToggleState.ToString().ToUpper().Equals("ON"))
                {
                    rcbItem.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    rcbLocalidad.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    lblOrigen.Visible = true;
                    CBX_ORIGEN.Visible = true;

                    lblItem.Visible = false;
                    ddlItem.Visible = false;

                    lblDestino.Location = new Point(130, 140);
                    CBX_DESTINO.Location = new Point(130, 177);
                }
                else
                {
                    rcbItem.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    rcbLocalidad.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void rcbItem_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            try
            {
                if (args.ToggleState.ToString().ToUpper().Equals("ON"))
                {
                    rcbLocalidad.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    rcbItem.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

                    lblOrigen.Visible = false;
                    CBX_ORIGEN.Visible = false;

                    lblItem.Visible = true;
                    ddlItem.Visible = true;

                    lblDestino.Location = new Point(416, 140);
                    CBX_DESTINO.Location = new Point(416, 177);
                }
                else
                {
                    rcbItem.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                    rcbLocalidad.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void ddlOrigen_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            SeleccionarOrigen();
        }
        private void ddlItem_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ddlItem.SelectedIndex != -1)
                {
                    sql = " AND I.ite_id='" + ddlItem.SelectedValue.ToString() + "' ";
                    LlenaLocalidadItem(sql);
                }
                else
                {
                    GRID_VIEW_TRASLADOS.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }


        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GRID_VIEW_TRASLADOS.DataSource != null)
                {
                    Trasladar();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRowInfo row in GRID_VIEW_TRASLADOS.Rows)
            {
                row.Cells[7].Value = 1;
            }
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRowInfo row in GRID_VIEW_TRASLADOS.Rows)
            {
                row.Cells[7].Value = 0;
            }
        }

        private void CHK_CONFORMIDAD_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                if (CHK_CONFORMIDAD.Checked == true)
                {
                    RB_INGRESO.IsChecked = false;
                    RB_SALIDA.IsChecked = false;
                    RB_INGRESO.Enabled = true;
                    RB_SALIDA.Enabled = true;
                    CBX_DESTINO.Enabled = false;
                    CBX_ORIGEN.Enabled = false;
                }
                else if (CHK_CONFORMIDAD.Checked == false)
                {
                    RB_INGRESO.IsChecked = false;
                    RB_SALIDA.IsChecked = false;
                    RB_INGRESO.Enabled = false;
                    RB_SALIDA.Enabled = false;
                    CBX_DESTINO.Enabled = true;
                    CBX_ORIGEN.Enabled = true;
                    LlenarLocalidad();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RB_INGRESO_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                if (RB_INGRESO.IsChecked == true)
                {
                    LlenarLocalidad();
                    CBX_DESTINO.Enabled = true;
                    CBX_ORIGEN.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RB_SALIDA_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            try
            {
                if (RB_SALIDA.IsChecked == true)
                {
                    LlenarLocalidad();
                    CBX_DESTINO.Enabled = true;
                    CBX_ORIGEN.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Traslados_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
