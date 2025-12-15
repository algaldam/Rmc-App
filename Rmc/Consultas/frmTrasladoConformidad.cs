using Rmc.Clases;
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

namespace Rmc.Consultas
{
    public partial class frmTrasladoConformidad : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        NConformeController NControl = new NConformeController();

        public frmTrasladoConformidad()
        {
            InitializeComponent();
            CargarDatos();
        }
        List<ProductoNoConforme> L_DATOS = new List<ProductoNoConforme>();
        public List<LocalidadTraslados> LNoConformidadTraslado = new List<LocalidadTraslados>();
        public int LocalidadDestino;
        SystemClass sc = new SystemClass();
        #endregion


        #region  METODOS
        private void CargarDatos()
        {
            try
            {
                L_DATOS = LNoConformidadTraslado.
                                   Select(s => new ProductoNoConforme { IdItem = s.ID, NombreItem = s.ITEM, Origen = s.ORIGEN }).ToList();

                ((GridViewComboBoxColumn)GRID_VIEW_NO_CONFORMIDAD.Columns["IdDefecto"]).DataSource = NControl.ObtenerDefectos();
                GRID_VIEW_NO_CONFORMIDAD.DataSource = L_DATOS;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region EVENTOS

        private void frmTrasladoConformidad_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
