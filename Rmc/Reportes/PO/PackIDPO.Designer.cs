namespace Wainari.Vista.Reportes.PO
{
    partial class PackIDPO
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
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("idFacD", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("impresion", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("fecha", null));
            typeReportSource1.TypeName = "Wainari.Vista.Movimientos.Reportes.PackIDDesign, Wainari, Version=1.0.0.0, Cultur" +
    "e=neutral, PublicKeyToken=null";
            this.reportViewer1.ReportSource = typeReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(432, 603);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ViewMode = Telerik.ReportViewer.WinForms.ViewMode.PrintPreview;
            this.reportViewer1.PrintEnd += new Telerik.ReportViewer.Common.PrintEndEventHandler(this.reportViewer1_PrintEnd);
            this.reportViewer1.RenderingEnd += new Telerik.ReportViewer.Common.RenderingEndEventHandler(this.reportViewer1_RenderingEnd);
            // 
            // PackIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 603);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PackIDForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "PackIDForm";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
    }
}
