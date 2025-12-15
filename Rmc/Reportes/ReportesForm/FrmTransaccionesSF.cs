using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Reportes.ReportesForm
{
    public partial class FrmTransaccionesSF : Telerik.WinControls.UI.RadForm
    {
        public FrmTransaccionesSF()
        {
            InitializeComponent();
        }

        public void AsignarParametros(string anio, string semana)
        {
            this.VistaReporte.ReportSource.Parameters["anio"].Value = anio;
            this.VistaReporte.ReportSource.Parameters["semana"].Value = semana;
            this.VistaReporte.RefreshReport();
        }
    }
}
