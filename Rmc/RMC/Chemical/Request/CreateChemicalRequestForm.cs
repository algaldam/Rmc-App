using Rmc.Controllers;
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
    public partial class CreateChemicalRequestForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        List<Solicitud> LSolicitudes = new List<Solicitud>();
        SolicitudController SControl = new SolicitudController();

        public CreateChemicalRequestForm()
        {
            InitializeComponent();
            var font1 = ThemeResolutionService.GetCustomFont("TelerikWebUI");
            CargarDatos();
            BtnNuevaSolicitud.ButtonElement.CustomFont = font1.Name;
            BtnNuevaSolicitud.ButtonElement.CustomFontSize = 15;
            BtnNuevaSolicitud.ButtonElement.ToolTipText = "Nueva Solicitud";
            BtnNuevaSolicitud.Text = "\ue907" + " Nueva";
        }

        bool flagRecargar = false;
        #endregion

        #region METODOS
        private void CargarDatos()
        {
            try
            {
                LSolicitudes = SControl.ObtenerSolicitudesActivas(usuario: Environment.UserName);
                LISTVIEW_SOLICITUD.DataSource = LSolicitudes;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region EVENTOS
        private void FrmCrearSolicitudes_Load(object sender, EventArgs e)
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

        private void LISTVIEW_SOLICITUD_VisualItemCreating(object sender, Telerik.WinControls.UI.ListViewVisualItemCreatingEventArgs e)
        {
            try
            {
                if (this.LISTVIEW_SOLICITUD.ViewType == ListViewType.ListView)
                {
                    e.VisualItem = new CarsListVisualItem();
                }
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
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void BtnNuevaSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (SControl.ObtenerNumeroSolicitudesUsuario() > 10)
                {
                    MessageBox.Show("Ha realizado demasiadas Solicitudes Espere que algunas sean Entregadas", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    CrudChemicalRequestForm fcrud = new CrudChemicalRequestForm();
                    fcrud.flag = false;
                    fcrud.ShowDialog();
                    CargarDatos();
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

        private void LISTVIEW_SOLICITUD_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            try
            {

                if (LISTVIEW_SOLICITUD.Items.Count > -1)
                {
                    CrudChemicalRequestForm mdfSol = new CrudChemicalRequestForm();
                    mdfSol.Id = Convert.ToInt32(LISTVIEW_SOLICITUD.SelectedItem.Value);
                    mdfSol.flag = true;
                    mdfSol.objSolicitud = LSolicitudes.Where(x => x.sol_ID == Convert.ToInt32(LISTVIEW_SOLICITUD.SelectedItem.Value)).FirstOrDefault();
                    mdfSol.ShowDialog();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LISTVIEW_SOLICITUD_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    BaseListViewVisualItem item = this.LISTVIEW_SOLICITUD.ElementTree.GetElementAtPoint(e.Location) as BaseListViewVisualItem;
                    if (item != null)
                    {
                        this.LISTVIEW_SOLICITUD.SelectedItem = item.Data;
                        if (LISTVIEW_SOLICITUD.SelectedIndex > -1)
                        {
                            MessageBox.Show("Se va ha eliminar  Solicitud  ¿ Desea continuar ?", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            var confirmacion1 = MessageBox.Show("Se va a eliminar la solicitud. ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            if (confirmacion1 == DialogResult.Yes)
                            {
                                int resultado = SControl.CrudSolicitudes(2, Convert.ToInt32(LISTVIEW_SOLICITUD.SelectedItem.Value.ToString()), "", 0, null, "D");

                                if (resultado > 0)
                                {
                                    MessageBox.Show("Registro eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargarDatos();
                                }
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
    }
}
