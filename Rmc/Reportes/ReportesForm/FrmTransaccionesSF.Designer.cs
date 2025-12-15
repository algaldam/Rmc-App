namespace Rmc.Reportes.ReportesForm
{
    partial class FrmTransaccionesSF
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
            this.VistaReporte = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // VistaReporte
            // 
            this.VistaReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VistaReporte.Location = new System.Drawing.Point(0, 0);
            this.VistaReporte.Name = "VistaReporte";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("anio", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("semana", null));
            typeReportSource1.TypeName = "Rmc.Reportes.ReportesDesign.RptTransaccionesSF, Rmc, Version=1.0.0.0, Culture=neu" +
    "tral, PublicKeyToken=null";
            this.VistaReporte.ReportSource = typeReportSource1;
            this.VistaReporte.Size = new System.Drawing.Size(1109, 515);
            this.VistaReporte.TabIndex = 0;
            // 
            // FrmTransaccionesSF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 515);
            this.Controls.Add(this.VistaReporte);
            this.Name = "FrmTransaccionesSF";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmTransacciones";
            this.ThemeName = "Desert";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer VistaReporte;
    }
}
