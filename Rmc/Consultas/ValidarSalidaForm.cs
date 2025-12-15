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

namespace Rmc.RMC.Warehouse.Transactions.Request
{
    public partial class ValidarSalidaForm : Telerik.WinControls.UI.RadForm
    {
        #region INICIALIZACION
        public ValidarSalidaForm()
        {
            InitializeComponent();
            Variables.banderap = false;
        }
        #endregion

        #region METODOS
        private void ValidarPermiso()
        {
            try
            {
                if (TxtPassword.Text.Trim() != "")
                {
                    var pass = ConsultasSql.ValidarMovimientos(TxtPassword.Text.Trim(), 26, "Salida");

                    if (pass != null && pass.aut_contrasenia.Trim() == TxtPassword.Text.Trim())
                    {
                        Variables.banderap = true;
                        Variables.IdAut = pass.aut_ID;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Autenticación incorrecta", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        TxtPassword.Focus();
                        TxtPassword.Text = "";
                        TxtPassword.TextBoxElement.Border.ForeColor = Color.LightCoral;
                        Variables.banderap = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region EVENTOS
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TxtPassword.TextBoxElement.Border.ForeColor = Color.DodgerBlue;
                if (e.KeyChar == (char)13)
                {
                    ValidarPermiso();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarPermiso();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
