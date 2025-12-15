namespace Rmc.Reportes.ReportesForm
{
    partial class FrmRptTransacciones
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
            Telerik.Windows.Documents.Spreadsheet.Model.Workbook workbook1 = new Telerik.Windows.Documents.Spreadsheet.Model.Workbook();
            this.radSpreadsheet1 = new Telerik.WinControls.UI.RadSpreadsheet();
            this.radSpreadsheetRibbonBar1 = new Telerik.WinControls.UI.RadSpreadsheetRibbonBar();
            this.radRibbonFormBehavior1 = new Telerik.WinControls.UI.RadRibbonFormBehavior();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheetRibbonBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSpreadsheet1
            // 
            this.radSpreadsheet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSpreadsheet1.Location = new System.Drawing.Point(0, 161);
            this.radSpreadsheet1.Name = "radSpreadsheet1";
            this.radSpreadsheet1.Size = new System.Drawing.Size(1013, 375);
            this.radSpreadsheet1.TabIndex = 0;
            this.radSpreadsheet1.Text = "Reporte Completo Plan";
            this.radSpreadsheet1.ThemeName = "Desert";
            workbook1.ActiveTabIndex = -1;
            workbook1.Name = "Book1";
            workbook1.WorkbookContentChangedInterval = System.TimeSpan.Parse("00:00:00.0300000");
            this.radSpreadsheet1.Workbook = workbook1;
            // 
            // radSpreadsheetRibbonBar1
            // 
            this.radSpreadsheetRibbonBar1.ApplicationMenuStyle = Telerik.WinControls.UI.ApplicationMenuStyle.BackstageView;
            this.radSpreadsheetRibbonBar1.AssociatedSpreadsheet = this.radSpreadsheet1;
            // 
            // 
            // 
            this.radSpreadsheetRibbonBar1.ExitButton.Text = "Exit";
            this.radSpreadsheetRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radSpreadsheetRibbonBar1.Name = "radSpreadsheetRibbonBar1";
            // 
            // 
            // 
            this.radSpreadsheetRibbonBar1.OptionsButton.Text = "Options";
            this.radSpreadsheetRibbonBar1.Size = new System.Drawing.Size(1013, 161);
            this.radSpreadsheetRibbonBar1.TabIndex = 0;
            this.radSpreadsheetRibbonBar1.Text = "Reporte Completo Plan";
            this.radSpreadsheetRibbonBar1.ThemeName = "Desert";
            // 
            // radRibbonFormBehavior1
            // 
            this.radRibbonFormBehavior1.Form = this;
            // 
            // FrmRptTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 536);
            this.Controls.Add(this.radSpreadsheet1);
            this.Controls.Add(this.radSpreadsheetRibbonBar1);
            this.FormBehavior = this.radRibbonFormBehavior1;
            this.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
            this.Name = "FrmRptTransacciones";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte Completo Plan";
            this.ThemeName = "Desert";
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheetRibbonBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadSpreadsheet radSpreadsheet1;
        private Telerik.WinControls.UI.RadSpreadsheetRibbonBar radSpreadsheetRibbonBar1;
        private Telerik.WinControls.UI.RadRibbonFormBehavior radRibbonFormBehavior1;

    }
}
