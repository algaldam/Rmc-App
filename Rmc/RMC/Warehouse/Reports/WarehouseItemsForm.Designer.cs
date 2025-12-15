namespace Rmc.RMC.Warehouse.Reports
{
    partial class WarehouseItemsForm
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlBodegas = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.ddlItem = new Telerik.WinControls.UI.RadDropDownList();
            this.btnReporteItem = new Telerik.WinControls.UI.RadButton();
            this.btnTotalArea = new Telerik.WinControls.UI.RadButton();
            this.rgvDetalle = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReporteItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTotalArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalle.MasterTemplate)).BeginInit();
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
            this.radPanel1.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 45);
            this.label6.TabIndex = 14;
            this.label6.Text = "Items";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(16, 68);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(67, 25);
            this.radLabel2.TabIndex = 43;
            this.radLabel2.Text = "Bodega";
            // 
            // ddlBodegas
            // 
            this.ddlBodegas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBodegas.Location = new System.Drawing.Point(101, 66);
            this.ddlBodegas.Name = "ddlBodegas";
            this.ddlBodegas.Size = new System.Drawing.Size(304, 27);
            this.ddlBodegas.TabIndex = 44;
            this.ddlBodegas.ThemeName = "TelerikMetroBlue";
            this.ddlBodegas.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlBodegas_SelectedIndexChanged);
            // 
            // radLabel9
            // 
            this.radLabel9.BackColor = System.Drawing.Color.Transparent;
            this.radLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.Location = new System.Drawing.Point(16, 107);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(79, 25);
            this.radLabel9.TabIndex = 45;
            this.radLabel9.Text = "Producto";
            // 
            // ddlItem
            // 
            this.ddlItem.AccessibleDescription = "ddlItem";
            this.ddlItem.AccessibleName = "ddlItem";
            this.ddlItem.AutoSize = false;
            this.ddlItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlItem.Location = new System.Drawing.Point(101, 104);
            this.ddlItem.Name = "ddlItem";
            this.ddlItem.Size = new System.Drawing.Size(532, 30);
            this.ddlItem.TabIndex = 46;
            this.ddlItem.ThemeName = "TelerikMetroBlue";
            // 
            // btnReporteItem
            // 
            this.btnReporteItem.AccessibleDescription = "btnReporteItem";
            this.btnReporteItem.AccessibleName = "btnReporteItem";
            this.btnReporteItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteItem.Location = new System.Drawing.Point(260, 140);
            this.btnReporteItem.Name = "btnReporteItem";
            this.btnReporteItem.Size = new System.Drawing.Size(153, 53);
            this.btnReporteItem.TabIndex = 48;
            this.btnReporteItem.Text = "Reporte por Item";
            this.btnReporteItem.TextWrap = true;
            this.btnReporteItem.ThemeName = "TelerikMetroBlue";
            this.btnReporteItem.Click += new System.EventHandler(this.btnReporteItem_Click);
            // 
            // btnTotalArea
            // 
            this.btnTotalArea.AccessibleDescription = "btnTotalArea";
            this.btnTotalArea.AccessibleName = "btnTotalArea";
            this.btnTotalArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalArea.Location = new System.Drawing.Point(101, 140);
            this.btnTotalArea.Name = "btnTotalArea";
            this.btnTotalArea.Size = new System.Drawing.Size(153, 53);
            this.btnTotalArea.TabIndex = 47;
            this.btnTotalArea.Text = "Total por Area";
            this.btnTotalArea.TextWrap = true;
            this.btnTotalArea.ThemeName = "TelerikMetroBlue";
            this.btnTotalArea.Click += new System.EventHandler(this.btnTotalArea_Click);
            // 
            // rgvDetalle
            // 
            this.rgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvDetalle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rgvDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvDetalle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDetalle.Location = new System.Drawing.Point(175, 206);
            // 
            // 
            // 
            this.rgvDetalle.MasterTemplate.AllowAddNewRow = false;
            this.rgvDetalle.MasterTemplate.AllowDeleteRow = false;
            this.rgvDetalle.MasterTemplate.AllowEditRow = false;
            this.rgvDetalle.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "LOCALIDAD";
            gridViewTextBoxColumn1.HeaderText = "LOCALIDAD";
            gridViewTextBoxColumn1.Name = "LOCALIDAD";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 155;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CODIGO";
            gridViewTextBoxColumn2.HeaderText = "CÓDIGO";
            gridViewTextBoxColumn2.Name = "CODIGO";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 185;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DESCRIPCION";
            gridViewTextBoxColumn3.HeaderText = "DESCRIPCION";
            gridViewTextBoxColumn3.Name = "DESCRIPCION";
            gridViewTextBoxColumn3.Width = 308;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PACKID";
            gridViewTextBoxColumn4.HeaderText = "PACK ID";
            gridViewTextBoxColumn4.Name = "PACKID";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 155;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "LIBRAS";
            gridViewTextBoxColumn5.HeaderText = "LIBRAS";
            gridViewTextBoxColumn5.Name = "LIBRAS";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 154;
            this.rgvDetalle.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.rgvDetalle.MasterTemplate.EnableFiltering = true;
            this.rgvDetalle.MasterTemplate.EnableGrouping = false;
            this.rgvDetalle.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDetalle.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvDetalle.Name = "rgvDetalle";
            this.rgvDetalle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDetalle.Size = new System.Drawing.Size(991, 418);
            this.rgvDetalle.TabIndex = 49;
            this.rgvDetalle.ThemeName = "TelerikMetroBlue";
            // 
            // ItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 636);
            this.Controls.Add(this.rgvDetalle);
            this.Controls.Add(this.btnReporteItem);
            this.Controls.Add(this.btnTotalArea);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.ddlItem);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ddlBodegas);
            this.Controls.Add(this.radPanel1);
            this.Name = "ItemsForm";
            this.Text = "Items";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReporteItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTotalArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlBodegas;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadDropDownList ddlItem;
        private Telerik.WinControls.UI.RadButton btnReporteItem;
        private Telerik.WinControls.UI.RadButton btnTotalArea;
        private Telerik.WinControls.UI.RadGridView rgvDetalle;
    }
}
