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
    public partial class frmDatosFactura : Telerik.WinControls.UI.RadForm
    {
        public string NumeroFactura => txtFactura.Text.Trim();

        public frmDatosFactura()
        {
            InitializeComponent();
        }

        public void SetPOValue(string numeroPO)
        {
            txtPO.Text = numeroPO;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFactura.Text))
            {
                MessageBox.Show("Debe ingresar el número de factura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
