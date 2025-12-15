namespace Rmc.Consultas
{
    partial class InventarioFisicoForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            this.GridItems = new Telerik.WinControls.UI.RadGridView();
            this.lblTituloForm = new Telerik.WinControls.UI.RadLabel();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GridItems
            // 
            this.GridItems.BackColor = System.Drawing.Color.DarkSlateGray;
            this.GridItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridItems.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridItems.Location = new System.Drawing.Point(12, 93);
            // 
            // 
            // 
            this.GridItems.MasterTemplate.AllowAddNewRow = false;
            this.GridItems.MasterTemplate.AllowColumnReorder = false;
            this.GridItems.MasterTemplate.AllowDeleteRow = false;
            this.GridItems.MasterTemplate.AllowEditRow = false;
            gridViewTextBoxColumn1.AllowNaturalSort = false;
            gridViewTextBoxColumn1.AllowReorder = false;
            gridViewTextBoxColumn1.AllowSort = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.AllowNaturalSort = false;
            gridViewTextBoxColumn2.AllowReorder = false;
            gridViewTextBoxColumn2.AllowSort = false;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CODIGO";
            gridViewTextBoxColumn2.HeaderText = "CÓDIGO";
            gridViewTextBoxColumn2.Name = "CODIGO";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.AllowNaturalSort = false;
            gridViewTextBoxColumn3.AllowReorder = false;
            gridViewTextBoxColumn3.AllowSort = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DESCRIPCION";
            gridViewTextBoxColumn3.HeaderText = "DESCRIPCIÓN";
            gridViewTextBoxColumn3.Name = "DESCRIPCION";
            gridViewTextBoxColumn3.Width = 220;
            this.GridItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.GridItems.MasterTemplate.EnableGrouping = false;
            this.GridItems.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.GridItems.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridItems.Name = "GridItems";
            this.GridItems.ReadOnly = true;
            this.GridItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridItems.Size = new System.Drawing.Size(379, 611);
            this.GridItems.TabIndex = 3;
            this.GridItems.ThemeName = "TelerikMetroBlue";
            this.GridItems.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GridItems_CellClick);
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(12, 12);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(285, 30);
            this.lblTituloForm.TabIndex = 5;
            this.lblTituloForm.Text = "REPORTE INVENTARIO FÍSICO";
            this.lblTituloForm.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.AllowDrop = true;
            this.reportViewer1.Location = new System.Drawing.Point(397, 93);
            this.reportViewer1.Name = "reportViewer1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("inventario", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("item", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("localidad", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("valorConcatenadoConRowIndex", null));
            typeReportSource1.TypeName = "Wainari.Vista.Reporte.Inventario.InventarioFisicoDesign, Wainari, Version=1.0.0.0" +
    ", Culture=neutral, PublicKeyToken=null";
            this.reportViewer1.ReportSource = typeReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(1173, 611);
            this.reportViewer1.TabIndex = 6;
            // 
            // InventarioFisicoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1372, 755);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.GridItems);
            this.Name = "InventarioFisicoForm";
            this.Text = "Inventario Fisico";
            ((System.ComponentModel.ISupportInitialize)(this.GridItems.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GridItems;
        private Telerik.WinControls.UI.RadLabel lblTituloForm;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
    }
}
