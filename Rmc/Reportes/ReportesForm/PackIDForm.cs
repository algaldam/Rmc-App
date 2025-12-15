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
    public partial class PackIDForm : Telerik.WinControls.UI.RadForm
    {
        public PackIDForm()
        {
            InitializeComponent();
        }

        public void AsignarParametros(string packID)
        {
            this.reportViewer1.ReportSource.Parameters["packID"].Value = packID;
            this.reportViewer1.ReportSource.Parameters["fecha"].Value = (DateTime.Now.ToString("dd/MMM/yyyy"));
            this.reportViewer1.RefreshReport();
        }
        private void reportViewer1_RenderingEnd(object sender, Telerik.ReportViewer.Common.RenderingEndEventArgs args)
        {

        }
        private void reportViewer1_PrintEnd(object sender, Telerik.ReportViewer.Common.PrintEndEventArgs args)
        {
            Console.WriteLine(sender);
            Console.WriteLine(args);
        }
    }
}
