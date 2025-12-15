namespace Rmc.RMC.Packaging.Reports
{
    partial class PackagingItemsForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.ddlIPackagingtem = new Telerik.WinControls.UI.RadDropDownList();
            this.btnReporteItem = new Telerik.WinControls.UI.RadButton();
            this.btnTotalArea = new Telerik.WinControls.UI.RadButton();
            this.rgvDetallePackaging = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlIPackagingtem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReporteItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTotalArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetallePackaging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetallePackaging.MasterTemplate)).BeginInit();
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
            this.radPanel1.Size = new System.Drawing.Size(1355, 50);
            this.radPanel1.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(374, 45);
            this.label6.TabIndex = 14;
            this.label6.Text = "Bodega - Empaquetado";
            // 
            // radLabel9
            // 
            this.radLabel9.BackColor = System.Drawing.Color.Transparent;
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(48, 78);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(47, 25);
            this.radLabel9.TabIndex = 46;
            this.radLabel9.Text = "Tipo:";
            // 
            // ddlIPackagingtem
            // 
            this.ddlIPackagingtem.AccessibleDescription = "ddlItem";
            this.ddlIPackagingtem.AccessibleName = "ddlItem";
            this.ddlIPackagingtem.AutoSize = false;
            this.ddlIPackagingtem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIPackagingtem.Location = new System.Drawing.Point(101, 73);
            this.ddlIPackagingtem.Name = "ddlIPackagingtem";
            this.ddlIPackagingtem.Size = new System.Drawing.Size(532, 30);
            this.ddlIPackagingtem.TabIndex = 47;
            this.ddlIPackagingtem.ThemeName = "TelerikMetroBlue";
            // 
            // btnReporteItem
            // 
            this.btnReporteItem.AccessibleDescription = "btnReporteItem";
            this.btnReporteItem.AccessibleName = "btnReporteItem";
            this.btnReporteItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteItem.Image = global::Rmc.Properties.Resources.inventario;
            this.btnReporteItem.Location = new System.Drawing.Point(260, 122);
            this.btnReporteItem.Name = "btnReporteItem";
            this.btnReporteItem.Size = new System.Drawing.Size(153, 53);
            this.btnReporteItem.TabIndex = 50;
            this.btnReporteItem.Text = "Reporte por Empaquetado";
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
            this.btnTotalArea.Location = new System.Drawing.Point(101, 122);
            this.btnTotalArea.Name = "btnTotalArea";
            this.btnTotalArea.Size = new System.Drawing.Size(153, 53);
            this.btnTotalArea.TabIndex = 49;
            this.btnTotalArea.Text = "Total por Area";
            this.btnTotalArea.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTotalArea.TextWrap = true;
            this.btnTotalArea.ThemeName = "TelerikMetroBlue";
            this.btnTotalArea.Click += new System.EventHandler(this.btnTotalArea_Click);
            // 
            // rgvDetallePackaging
            // 
            this.rgvDetallePackaging.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvDetallePackaging.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rgvDetallePackaging.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDetallePackaging.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvDetallePackaging.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDetallePackaging.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDetallePackaging.Location = new System.Drawing.Point(196, 194);
            // 
            // 
            // 
            this.rgvDetallePackaging.MasterTemplate.AllowAddNewRow = false;
            this.rgvDetallePackaging.MasterTemplate.AllowDeleteRow = false;
            this.rgvDetallePackaging.MasterTemplate.AllowEditRow = false;
            this.rgvDetallePackaging.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "LOCALIDAD";
            gridViewTextBoxColumn11.HeaderText = "LOCALIDAD";
            gridViewTextBoxColumn11.Name = "LOCALIDAD";
            gridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn11.Width = 155;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "CODIGO";
            gridViewTextBoxColumn12.HeaderText = "CÓDIGO";
            gridViewTextBoxColumn12.Name = "CODIGO";
            gridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn12.Width = 185;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "DESCRIPCION";
            gridViewTextBoxColumn13.HeaderText = "DESCRIPCION";
            gridViewTextBoxColumn13.Name = "DESCRIPCION";
            gridViewTextBoxColumn13.Width = 308;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "PACKID";
            gridViewTextBoxColumn14.HeaderText = "PACK ID";
            gridViewTextBoxColumn14.Name = "PACKID";
            gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn14.Width = 155;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "LIBRAS";
            gridViewTextBoxColumn15.HeaderText = "LIBRAS";
            gridViewTextBoxColumn15.Name = "LIBRAS";
            gridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn15.Width = 154;
            this.rgvDetallePackaging.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15});
            this.rgvDetallePackaging.MasterTemplate.EnableFiltering = true;
            this.rgvDetallePackaging.MasterTemplate.EnableGrouping = false;
            this.rgvDetallePackaging.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDetallePackaging.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.rgvDetallePackaging.Name = "rgvDetallePackaging";
            this.rgvDetallePackaging.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDetallePackaging.Size = new System.Drawing.Size(991, 418);
            this.rgvDetallePackaging.TabIndex = 51;
            this.rgvDetallePackaging.ThemeName = "TelerikMetroBlue";
            // 
            // PackagingItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 636);
            this.Controls.Add(this.rgvDetallePackaging);
            this.Controls.Add(this.btnReporteItem);
            this.Controls.Add(this.btnTotalArea);
            this.Controls.Add(this.ddlIPackagingtem);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radPanel1);
            this.Name = "PackagingItemsForm";
            this.Text = "Empaquetado";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlIPackagingtem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReporteItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTotalArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetallePackaging.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetallePackaging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadDropDownList ddlIPackagingtem;
        private Telerik.WinControls.UI.RadButton btnReporteItem;
        private Telerik.WinControls.UI.RadButton btnTotalArea;
        private Telerik.WinControls.UI.RadGridView rgvDetallePackaging;
    }
}
