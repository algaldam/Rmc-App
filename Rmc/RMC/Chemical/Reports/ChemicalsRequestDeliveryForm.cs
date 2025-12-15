using Rmc.Clases;
using Rmc.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Chemical.Reports
{
    public partial class ChemicalsRequestDeliveryForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        SystemClass sc = new SystemClass();
        ConsultasController CControl = new ConsultasController();

        public ChemicalsRequestDeliveryForm()
        {
            InitializeComponent();
            CargarBodegas();
            DtFecha1.Value = DateTime.Now;
            DtFecha2.Value = DateTime.Now;
            DtFecha1.DateTimePickerElement.ShowTimePicker = true;
            DtFecha2.DateTimePickerElement.ShowTimePicker = true;
            (DtFecha1.DateTimePickerElement.CurrentBehavior as RadDateTimePickerCalendar).DropDownMinSize = new System.Drawing.Size(330, 250);
            (DtFecha2.DateTimePickerElement.CurrentBehavior as RadDateTimePickerCalendar).DropDownMinSize = new System.Drawing.Size(330, 250);
        }
        #endregion

        #region EVENTOS
        private void CargarBodegas()
        {
            sc.OpenConection();
            string sql = "SELECT  bod_id, CONCAT(bod_nombre,' - ',bod_descripcion) AS bod_nombre FROM wai_Bodegas";
            sc.LlenarDropDownList(ddlBodegas, sql, "bod_nombre", "bod_id");
            sc.CloseConection();
            ddlBodegas.SelectedIndex = 2;
            ddlBodegas.Enabled = false;
        }
        private void CargarTabla()
        {
            try
            {
                int bodegaId = Convert.ToInt32(ddlBodegas.SelectedValue);
                var data = CControl.ObtenerEntregasPorBodega(bodegaId, DtFecha1.Value, DtFecha2.Value);
                GRID_VIEW_DETALLE.DataSource = data;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarTabla();
        }
        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
