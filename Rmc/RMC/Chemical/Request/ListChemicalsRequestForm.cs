using Rmc.Controllers;
using Rmc.Modelo;
using Rmc.RMC.Warehouse.Reports;
using Rmc.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.RMC.Chemical.Request
{
    public partial class ListChemicalsRequestForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION

        SolicitudController SControl = new SolicitudController();
        List<Solicitud> LSolicitudes = new List<Solicitud>();

        // Poner el ID de bodega para obtener el listado de solicitudes
        private readonly int warehouseID = 3;

        public ListChemicalsRequestForm()
        {
            InitializeComponent();
        }

        bool flagRecargar = false;
        #endregion

        #region METODOS
        private void CargarDatos()
        {
            try
            {
                LSolicitudes = SControl.ObtenerListaSolicitudes(null, warehouseID);
                LISTVIEW_SOLICITUD.DataSource = LSolicitudes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region EVENTOS
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

                MessageBox.Show(ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmListadoSolicitudes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                timer1.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LISTVIEW_SOLICITUD_VisualItemFormatting(object sender, Telerik.WinControls.UI.ListViewVisualItemEventArgs e)
        {
            try
            {
                if (LISTVIEW_SOLICITUD.Items.Count > 0)
                {
                    e.VisualItem.DrawFill = true;
                    e.VisualItem.GradientStyle = GradientStyles.Solid;
                    e.VisualItem.ForeColor = Color.White;
                    if (e.VisualItem.Data["sol_estado"] != null && e.VisualItem.Data["sol_estado"].ToString().Trim() == "Nuevo")
                    {
                        if ((e.VisualItem.Data["sol_prioridad"] != null && e.VisualItem.Data["sol_prioridad"].ToString().Trim() == "Alta"))
                        {
                            e.VisualItem.NumberOfColors = 1;
                            e.VisualItem.BackColor = Color.Purple;
                        }
                        else
                        {
                            e.VisualItem.NumberOfColors = 1;
                            e.VisualItem.BackColor = Color.DarkBlue;

                            e.VisualItem.ForeColor = Color.White;
                        }

                    }
                    else if (e.VisualItem.Data["sol_estado"] != null && e.VisualItem.Data["sol_estado"].ToString().Trim() == "Proceso")
                    {
                        e.VisualItem.NumberOfColors = 1;
                        e.VisualItem.BackColor = Color.DarkGreen;
                    }
                    else if (e.VisualItem.Data["sol_estado"] != null && e.VisualItem.Data["sol_estado"].ToString().Trim() == "Espera")
                    {
                        e.VisualItem.NumberOfColors = 1;
                        e.VisualItem.BackColor = Color.Maroon;
                    }

                    DateTime fechaCreacion = Convert.ToDateTime(e.VisualItem.Data["sol_FH_crea"].ToString());
                    string tiempo = (DateTime.Now - fechaCreacion).ToString("c");
                    string TiempoFormato = tiempo.Remove(tiempo.Length - 8, 8);
                    e.VisualItem.AutoSize = true;
                    e.VisualItem.Text = "";
                    e.VisualItem.TextAlignment = ContentAlignment.MiddleCenter;
                    e.VisualItem.Padding = new Padding(0, 2, 0, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LISTVIEW_SOLICITUD_ItemMouseDoubleClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            try
            {
                if (LISTVIEW_SOLICITUD.Items.Count > -1)
                {
                    if (ConsultasSql.ObtenerPermisoBoton(2, this.Name) > 0)
                    {
                        TakeRequestForm TomSol = new TakeRequestForm();

                        TomSol.Id = Convert.ToInt32(LISTVIEW_SOLICITUD.SelectedItem.Value);
                        flagRecargar = true;
                        TomSol.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LISTVIEW_SOLICITUD_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            try
            {
                if (this.LISTVIEW_SOLICITUD.ViewType == ListViewType.ListView)
                {
                    //SE CREA EL ITEM DE CADA LISTA CON UN FORMATEO ESPECIFICO
                    e.VisualItem = new CarsListVisualItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LISTVIEW_SOLICITUD_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (flagRecargar == true)
                {
                    CargarDatos();
                    flagRecargar = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_REFRESH_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
