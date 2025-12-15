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
    public partial class FrmOrden : Telerik.WinControls.UI.RadForm
    {
        public FrmOrden()
        {
            InitializeComponent();
            
        }

        public void AsignarParametros(string transID, string semana, string turno, string dia, string usuario, string fecha)
        {
            this.reportViewer1.ReportSource.Parameters["traID"].Value = Int32.Parse(transID);
            this.reportViewer1.ReportSource.Parameters["semana"].Value = semana;
            this.reportViewer1.ReportSource.Parameters["turno"].Value = turno;
            this.reportViewer1.ReportSource.Parameters["dia"].Value = dia;
            this.reportViewer1.ReportSource.Parameters["usuario"].Value = usuario;
            this.reportViewer1.ReportSource.Parameters["fecha"].Value = fecha;
            this.reportViewer1.RefreshReport();
        }
    }
}
