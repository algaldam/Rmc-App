namespace Rmc.RMC.Chemical.Reports
{
    partial class ChemicalsItemsForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlIChemicaltem = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.btnReporteItem = new Telerik.WinControls.UI.RadButton();
            this.btnTotalArea = new Telerik.WinControls.UI.RadButton();
            this.rgvDetalleChemicals = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlIChemicaltem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReporteItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTotalArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalleChemicals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalleChemicals.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightGray;
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1355, 56);
            this.radPanel1.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 46);
            this.label6.TabIndex = 14;
            this.label6.Text = "Items - Quimicos";
            // 
            // ddlIChemicaltem
            // 
            this.ddlIChemicaltem.AccessibleDescription = "ddlItem";
            this.ddlIChemicaltem.AccessibleName = "ddlItem";
            this.ddlIChemicaltem.AutoSize = false;
            this.ddlIChemicaltem.DropDownHeight = 118;
            this.ddlIChemicaltem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIChemicaltem.Location = new System.Drawing.Point(112, 81);
            this.ddlIChemicaltem.Name = "ddlIChemicaltem";
            this.ddlIChemicaltem.Size = new System.Drawing.Size(589, 34);
            this.ddlIChemicaltem.TabIndex = 49;
            this.ddlIChemicaltem.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel9
            // 
            this.radLabel9.BackColor = System.Drawing.Color.Transparent;
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(54, 86);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(49, 26);
            this.radLabel9.TabIndex = 48;
            this.radLabel9.Text = "Tipo:";
            // 
            // btnReporteItem
            // 
            this.btnReporteItem.AccessibleDescription = "btnReporteItem";
            this.btnReporteItem.AccessibleName = "btnReporteItem";
            this.btnReporteItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteItem.Image = global::Rmc.Properties.Resources.invquimico;
            this.btnReporteItem.Location = new System.Drawing.Point(288, 129);
            this.btnReporteItem.Name = "btnReporteItem";
            this.btnReporteItem.Size = new System.Drawing.Size(169, 59);
            this.btnReporteItem.TabIndex = 52;
            this.btnReporteItem.Text = "Reporte por Quimico";
            this.btnReporteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReporteItem.TextWrap = true;
            this.btnReporteItem.ThemeName = "TelerikMetroBlue";
            this.btnReporteItem.Click += new System.EventHandler(this.btnReporteItem_Click);
            // 
            // btnTotalArea
            // 
            this.btnTotalArea.AccessibleDescription = "btnTotalArea";
            this.btnTotalArea.AccessibleName = "btnTotalArea";
            this.btnTotalArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalArea.Image = global::Rmc.Properties.Resources.area;
            this.btnTotalArea.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTotalArea.Location = new System.Drawing.Point(112, 128);
            this.btnTotalArea.Name = "btnTotalArea";
            this.btnTotalArea.Size = new System.Drawing.Size(169, 59);
            this.btnTotalArea.TabIndex = 51;
            this.btnTotalArea.Text = "Total por Area";
            this.btnTotalArea.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTotalArea.TextWrap = true;
            this.btnTotalArea.ThemeName = "TelerikMetroBlue";
            this.btnTotalArea.Click += new System.EventHandler(this.btnTotalArea_Click);
            // 
            // rgvDetalleChemicals
            // 
            this.rgvDetalleChemicals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvDetalleChemicals.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rgvDetalleChemicals.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDetalleChemicals.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvDetalleChemicals.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDetalleChemicals.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDetalleChemicals.Location = new System.Drawing.Point(150, 193);
            // 
            // 
            // 
            this.rgvDetalleChemicals.MasterTemplate.AllowAddNewRow = false;
            this.rgvDetalleChemicals.MasterTemplate.AllowDeleteRow = false;
            this.rgvDetalleChemicals.MasterTemplate.AllowEditRow = false;
            this.rgvDetalleChemicals.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "LOCALIDAD";
            gridViewTextBoxColumn1.HeaderText = "LOCALIDAD";
            gridViewTextBoxColumn1.Name = "LOCALIDAD";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 171;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CODIGO";
            gridViewTextBoxColumn2.HeaderText = "CÓDIGO";
            gridViewTextBoxColumn2.Name = "CODIGO";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 205;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DESCRIPCION";
            gridViewTextBoxColumn3.HeaderText = "DESCRIPCION";
            gridViewTextBoxColumn3.Name = "DESCRIPCION";
            gridViewTextBoxColumn3.Width = 342;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PACKID";
            gridViewTextBoxColumn4.HeaderText = "PACK ID";
            gridViewTextBoxColumn4.Name = "PACKID";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 171;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "LIBRAS";
            gridViewTextBoxColumn5.HeaderText = "LIBRAS";
            gridViewTextBoxColumn5.Name = "LIBRAS";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 171;
            this.rgvDetalleChemicals.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.rgvDetalleChemicals.MasterTemplate.EnableFiltering = true;
            this.rgvDetalleChemicals.MasterTemplate.EnableGrouping = false;
            this.rgvDetalleChemicals.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDetalleChemicals.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvDetalleChemicals.Name = "rgvDetalleChemicals";
            this.rgvDetalleChemicals.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDetalleChemicals.Size = new System.Drawing.Size(1097, 451);
            this.rgvDetalleChemicals.TabIndex = 53;
            this.rgvDetalleChemicals.ThemeName = "TelerikMetroBlue";
            // 
            // ChemicalsItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 636);
            this.Controls.Add(this.rgvDetalleChemicals);
            this.Controls.Add(this.btnReporteItem);
            this.Controls.Add(this.btnTotalArea);
            this.Controls.Add(this.ddlIChemicaltem);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radPanel1);
            this.Name = "ChemicalsItemsForm";
            this.Text = "Quimicos";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlIChemicaltem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReporteItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTotalArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalleChemicals.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalleChemicals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadDropDownList ddlIChemicaltem;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadButton btnReporteItem;
        private Telerik.WinControls.UI.RadButton btnTotalArea;
        private Telerik.WinControls.UI.RadGridView rgvDetalleChemicals;
    }
}
