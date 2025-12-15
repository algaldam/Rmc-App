using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Consultas
{
    public partial class frmDatosPO : Telerik.WinControls.UI.RadForm
    {
        public string NumeroPO => txtNumeroPO.Text.Trim();
        public string NumeroFactura => txtNumeroFactura.Text.Trim();

        public frmDatosPO()
        {
            InitializeComponent();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroPO.Text) || string.IsNullOrEmpty(txtNumeroFactura.Text))
            {
                MessageBox.Show("Debe completar ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
