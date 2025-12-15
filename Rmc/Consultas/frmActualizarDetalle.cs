using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rmc.Clases;
using Telerik.WinControls;
using System.Linq;
using System.Globalization;

namespace Rmc.Consultas
{
    public partial class frmActualizarDetalle : Telerik.WinControls.UI.RadForm
    {


        #region INICIALIZACION
        public object ID_DET;
        List<pmc_Mov_Bodega_Det> Data = new List<pmc_Mov_Bodega_Det>();
        public frmActualizarDetalle()
        {
            InitializeComponent();
        }

        #endregion

        #region METODOS



        private void CargarDatos()
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())
                {
                    Data = (from x in db.pmc_Mov_Bodega_Dets
                            where x.mov_det_ID == Convert.ToInt32(ID_DET.ToString())
                            select x).ToList();
                }

                unbinding();
                bindeo();

                if (lblDesviacion.Text.Trim() == "")
                {
                    TxtCantidadDesc.Enabled = false;

                }
                else
                {
                    TxtCantidadDesc.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void bindeo()
        {
            try
            {
                //   
                   LbID_Detalle.DataBindings.Add("Text", Data, "mov_det_ID", false, DataSourceUpdateMode.Never);
                   lblDesviacion.DataBindings.Add("Text", Data, "mov_det_desv", false, DataSourceUpdateMode.Never);
                    lblProducto.DataBindings.Add("Text", Data, "mov_det_item", false, DataSourceUpdateMode.Never);
                   TxtCantidad.DataBindings.Add("Text", Data, "mov_det_cant", false, DataSourceUpdateMode.Never);
                TxtCantidadDesc.DataBindings.Add("Text", Data, "mov_det_cant_desv", false, DataSourceUpdateMode.Never);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void unbinding()
        {
            try
            {
                LbID_Detalle.DataBindings.Clear();
                lblDesviacion.DataBindings.Clear();
                lblProducto.DataBindings.Clear();
                TxtCantidad.DataBindings.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void Actualizar()
        {
            try
            {
                using (dcPmcDataContext db = new dcPmcDataContext())

                {
                    var Actualizar = (from x in db.pmc_Mov_Bodega_Dets
                                      where x.mov_det_ID == Convert.ToInt32(LbID_Detalle.Text.Trim())
                                      select x).FirstOrDefault();

                    Actualizar.mov_det_cant = int.Parse(TxtCantidad.Text, NumberStyles.AllowThousands); 
                    Actualizar.mov_det_cant_desv = int.Parse(TxtCantidadDesc.Text, NumberStyles.AllowThousands); 
                    Actualizar.mov_det_FH_mod = DateTime.Now;
                    Actualizar.mov_det_usuario_mod = Environment.UserName;
                    db.SubmitChanges();
                }
                POP_ALERT.CaptionText = "Exito";
                POP_ALERT.Popup.AlertElement.ContentElement.Font = new Font("Arial", 11f);
                POP_ALERT.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextElement.Font = new Font("Arial", 14f);
                POP_ALERT.ThemeName = "Windows8";
                POP_ALERT.ContentText = "Datos Actualizados";
                POP_ALERT.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region EVENTOS
        private void FrmActualizarDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Actualizar();
              

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtCantidadDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    Actualizar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion
    }
}
