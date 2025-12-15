using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

namespace Rmc.Utils
{
    class CarsListVisualItem : SimpleListViewVisualItem
    {
        private LightVisualElement sol_prioridad;
        private LightVisualElement NOMBRE_PIDE;
        private LightVisualElement sol_item;
        private StackLayoutPanel layout;

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            this.layout = new StackLayoutPanel();
            this.layout.StretchHorizontally = false;
            this.layout.Alignment = ContentAlignment.MiddleCenter;
            this.layout.FitToSizeMode = RadFitToSizeMode.FitToParentContent;
            this.layout.Margin = new Padding(10, 10, 20, 10);
            this.TextAlignment = ContentAlignment.TopCenter;

            this.sol_prioridad = new LightVisualElement();
            sol_prioridad.TextAlignment = ContentAlignment.TopLeft;
            sol_prioridad.MinSize = new Size(350, 0);
            sol_prioridad.MaxSize = new Size(350, 0);
            sol_prioridad.NotifyParentOnMouseInput = true;
            sol_prioridad.ShouldHandleMouseInput = false;
            this.layout.Children.Add(this.sol_prioridad);

            this.sol_item = new LightVisualElement();
            sol_item.TextAlignment = ContentAlignment.TopCenter;
            sol_item.MinSize = new Size(400, 0);
            sol_item.MaxSize = new Size(400, 0);
            sol_item.NotifyParentOnMouseInput = true;
            sol_item.ShouldHandleMouseInput = false;
            this.layout.Children.Add(this.sol_item);

            this.NOMBRE_PIDE = new LightVisualElement();
            NOMBRE_PIDE.TextAlignment = ContentAlignment.TopRight;
            NOMBRE_PIDE.Alignment = ContentAlignment.TopRight;
            NOMBRE_PIDE.MinSize = new Size(350, 0);
            NOMBRE_PIDE.MaxSize = new Size(350, 0);
            NOMBRE_PIDE.NotifyParentOnMouseInput = true;
            NOMBRE_PIDE.ShouldHandleMouseInput = false;
            this.layout.Children.Add(this.NOMBRE_PIDE);
            this.Children.Add(this.layout);

        }

        private bool ContainsFeature(ListViewDataItem item, string feature)
        {
            return item[feature] != null && Convert.ToInt32(item[feature]) != 0;
        }
        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();

            RadElement element = this.FindAncestor<RadListViewElement>();

            if (element == null)
            {
                return;
            }
            DateTime fechaCreacion = Convert.ToDateTime(Data["sol_FH_crea"].ToString());
            string tiempo = (DateTime.Now - fechaCreacion).ToString("c");
            string TiempoFormato = tiempo.Remove(tiempo.Length - 8, 8);
            string loc = Data["sol_localidad"].ToString();
            string Localidad = DatoPares.ObtenerLocalidadesEntrega().Where(x => x.ID.ToString().Trim() == loc.Trim()).FirstOrDefault().Descripcion;

            // FORMATEO CON ETIQUETAS HTML PARA EL TEXTO QUE SE MUESTRA EN CADA ITEM DE LISTA
            this.sol_prioridad.Text = "<html> <span  align =\"left\"style=\"font-size:20pt; font-family:Segoe UI Semibold;\"> <b>" + this.Data["sol_estado"] + "</b></span> " +
                "<span style=\"font-size:19pt; font-family:Segoe UI Semibold;\">    Prioridad  <b>" + this.Data["sol_prioridad"] + "</b></span>" +
                "<br><br><br><br><br><span align=\"left\" style=\"font-size:15pt; font-family: Segoe UI Semibold ;\">  Fecha   " + fechaCreacion.ToString("dddd, dd MMMM yyyy", new CultureInfo("es-ES")) +
                "</span> <br><span align=\"left\" style=\"font-size:15pt; font-family: Segoe UI Semibold ;\">  Tiempo en Espera   " + TiempoFormato + "</span>";

            this.sol_item.Text = "<html><br><span style=\"font-size:24pt;font-family:Segoe UI Semibold;\">" + this.Data["sol_item"] + "</span>" +
            "<br><span align =\"center\" style =\"font-size:24pt; font-family: Segoe UI Semibold;\"> " + Data["ite_descripcion"] + "</span>" +
            "<br><span align=\"center\" style =\"font-size:19pt; font-family: Segoe UI Semibold;\">  " + Data["pro_nombre"] + "</span>" +
            "<br><span  style =\"font-size:16pt; font-family: Segoe UI Semibold;\">    " + Data["sol_UOM"] + "</span><span align=\"center\" style =\"font-size:16pt; font-family: Segoe UI Semibold;\">   Loc ➤ " + Localidad + "</span>" +
            "    ";

            this.NOMBRE_PIDE.Text = "<html><span style=\"font-size:14pt; font-family:Segoe UI Semibold;\"> Creado Por " + this.Data["NOMBRE_PIDE"] + "</span><br>" +
                "<br><br><span  style =\"font-size:17pt; font-family: Segoe UI Semibold;\"> Turno  " + Data["sol_turno_crea"] + "</span>" +
                "<br><br><span align=\"right\" style =\"font-size:15pt; font-family: Segoe UI Semibold;\">Semana  " + Data["sol_semana"] + "</span>" +
                "<br><span align=\"right\" style =\"font-size:14pt; font-family: Segoe UI Semibold;\"> Asignado a  " + Data["NOMBRE_ENTREGA"] + "</span>";

            this.TextAlignment = ContentAlignment.TopRight;
        }
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem);
            }
        }
    }
}
