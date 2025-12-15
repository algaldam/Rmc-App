using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.RMC.Warehouse.Transactions.Request.Exits
{
    public partial class ProvIDForm : Telerik.WinControls.UI.RadForm
    {
        public ProvIDForm()
        {
            InitializeComponent();
        }

        public void AsignarParametros(string packID)
        {
            this.reportViewer2.ReportSource.Parameters["packID"].Value = packID;
            this.reportViewer2.ReportSource.Parameters["fecha"].Value = (DateTime.Now.ToString("dd/MMM/yyyy"));
            this.reportViewer2.RefreshReport();
        }
        private void reportViewer2_RenderingEnd(object sender, Telerik.ReportViewer.Common.RenderingEndEventArgs args)
        {

        }
        private void reportViewer2_PrintEnd(object sender, Telerik.ReportViewer.Common.PrintEndEventArgs args)
        {
            Console.WriteLine(sender);
            Console.WriteLine(args);
        }
    }
}
