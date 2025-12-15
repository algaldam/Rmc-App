namespace Rmc.Reportes.ReportesForm
{
    partial class FrmOrden
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
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("traID", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("semana", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("turno", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("dia", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("fecha", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("usuario", null));
            typeReportSource1.TypeName = "Rmc.Reportes.ReportesDesign.RptOrden, Rmc, Version=1.0.0.0, Culture=neutral, Publ" +
    "icKeyToken=null";
            this.reportViewer1.ReportSource = typeReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(700, 466);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 466);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmOrden";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Orden";
            this.ThemeName = "Desert";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;



    }
}
