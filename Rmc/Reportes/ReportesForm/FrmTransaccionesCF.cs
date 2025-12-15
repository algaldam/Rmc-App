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
    public partial class FrmTransaccionesCF : Telerik.WinControls.UI.RadForm
    {
        public FrmTransaccionesCF()
        {
            InitializeComponent();
        }

        public void AsignarParametros(string anio, string semana, string flujo)
        {
            this.VistaReporte.ReportSource.Parameters["anio"].Value = anio;
            this.VistaReporte.ReportSource.Parameters["semana"].Value = semana;
            this.VistaReporte.ReportSource.Parameters["flujo"].Value = flujo;
            this.VistaReporte.RefreshReport();
        }
    }
}
