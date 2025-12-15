namespace Wainari.Vista.Reportes.PO
{
    partial class ReportPO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            this.rptPO = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rptPO
            // 
            this.rptPO.AccessibilityKeyMap = null;
            this.rptPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptPO.Location = new System.Drawing.Point(0, 0);
            this.rptPO.Name = "rptPO";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Proveedor", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("NumeroPO", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("NumeroFactura", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FechaFactura", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Medida", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Peso", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("Paquetes", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("NombreUsuario", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("CreadorPO", null));
            typeReportSource1.TypeName = "Wainari.Vista.Reportes.PO.ReportePO, Wainari, Version=2.0.0.11, Culture=neutral, " +
    "PublicKeyToken=null";
            this.rptPO.ReportSource = typeReportSource1;
            this.rptPO.Size = new System.Drawing.Size(831, 599);
            this.rptPO.TabIndex = 1;
            // 
            // ReportPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 599);
            this.Controls.Add(this.rptPO);
            this.Name = "ReportPO";
            this.Text = "ReportPO";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.ReportViewer.WinForms.ReportViewer rptPO;
    }
}
