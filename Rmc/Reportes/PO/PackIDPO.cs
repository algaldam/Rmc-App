using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Wainari.Vista.Reportes.PO
{
    public partial class PackIDPO : Telerik.WinControls.UI.RadForm
    {
        public PackIDPO()
        {
            InitializeComponent();
        }
        public void AsignarParametros(string facdID, int impresion)
        {
            this.reportViewer1.ReportSource.Parameters["idFacD"].Value = facdID;
            this.reportViewer1.ReportSource.Parameters["impresion"].Value = impresion;
            this.reportViewer1.ReportSource.Parameters["fecha"].Value = (DateTime.Now.ToString("dd/MMM/yyyy"));
            this.reportViewer1.RefreshReport();
            
        }
        private void reportViewer1_RenderingEnd(object sender, Telerik.ReportViewer.Common.RenderingEndEventArgs args)
        {
            if (this.reportViewer1.TotalPages > 0)
            {
                this.reportViewer1.PrintReport();
            }
        }

        private void reportViewer1_PrintEnd(object sender, Telerik.ReportViewer.Common.PrintEndEventArgs args)
        {
            Console.WriteLine(sender);
            Console.WriteLine(args);
        }
    }
}