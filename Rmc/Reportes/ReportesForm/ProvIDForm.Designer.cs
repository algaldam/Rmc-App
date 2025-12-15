namespace Rmc.RMC.Warehouse.Transactions.Request.Exits
{
    partial class ProvIDForm
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
            this.reportViewer2 = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.AccessibilityKeyMap = null;
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("packID", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("fecha", null));
            typeReportSource1.TypeName = "Wainari.Salidas.Reportes.PackIDDesign, Wainari, Version=1.0.0.0, Culture=neutral," +
    " PublicKeyToken=null";
            this.reportViewer2.ReportSource = typeReportSource1;
            this.reportViewer2.Size = new System.Drawing.Size(432, 600);
            this.reportViewer2.TabIndex = 1;
            this.reportViewer2.ViewMode = Telerik.ReportViewer.WinForms.ViewMode.PrintPreview;
            this.reportViewer2.PrintEnd += new Telerik.ReportViewer.Common.PrintEndEventHandler(this.reportViewer2_PrintEnd);
            this.reportViewer2.RenderingEnd += new Telerik.ReportViewer.Common.RenderingEndEventHandler(this.reportViewer2_RenderingEnd);
            // 
            // ProvIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 600);
            this.Controls.Add(this.reportViewer2);
            this.Name = "ProvIDForm";
            this.Text = "PackIDForm";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.ReportViewer.WinForms.ReportViewer reportViewer2;
    }
}
