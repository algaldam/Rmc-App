using Telerik.WinControls.UI;

namespace Rmc.RMC.Packaging.Reports
{
    partial class YarmInventoryForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInvProveedor = new Telerik.WinControls.UI.RadButton();
            this.BTN_PACK_PROVEEDOR = new Telerik.WinControls.UI.RadButton();
            this.btnInventarioAntiguedad = new Telerik.WinControls.UI.RadButton();
            this.btnInventarioLocalidadesDetalle = new Telerik.WinControls.UI.RadButton();
            this.btnInventarioLocalidades = new Telerik.WinControls.UI.RadButton();
            this.btnInventario = new Telerik.WinControls.UI.RadButton();
            this.rgvDetalle = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInvProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_PACK_PROVEEDOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventarioAntiguedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventarioLocalidadesDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventarioLocalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventario)).BeginInit();
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
            this.radPanel1.Size = new System.Drawing.Size(1292, 62);
            this.radPanel1.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(456, 45);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reporte de Inventario - Hilos";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnInvProveedor
            // 
            this.btnInvProveedor.AccessibleDescription = "btnInventario";
            this.btnInvProveedor.AccessibleName = "btnInventario";
            this.btnInvProveedor.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvProveedor.Image = global::Rmc.Properties.Resources.proveedores;
            this.btnInvProveedor.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInvProveedor.Location = new System.Drawing.Point(761, 88);
            this.btnInvProveedor.Name = "btnInvProveedor";
            this.btnInvProveedor.Size = new System.Drawing.Size(169, 59);
            this.btnInvProveedor.TabIndex = 60;
            this.btnInvProveedor.Text = "Inventario\r\nProveedor";
            this.btnInvProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInvProveedor.TextWrap = true;
            this.btnInvProveedor.ThemeName = "TelerikMetroBlue";
            this.btnInvProveedor.Click += new System.EventHandler(this.btnInvProveedor_Click);
            // 
            // BTN_PACK_PROVEEDOR
            // 
            this.BTN_PACK_PROVEEDOR.AccessibleDescription = "btnInventario";
            this.BTN_PACK_PROVEEDOR.AccessibleName = "btnInventario";
            this.BTN_PACK_PROVEEDOR.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_PACK_PROVEEDOR.Image = global::Rmc.Properties.Resources.proveedorr;
            this.BTN_PACK_PROVEEDOR.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BTN_PACK_PROVEEDOR.Location = new System.Drawing.Point(936, 88);
            this.BTN_PACK_PROVEEDOR.Name = "BTN_PACK_PROVEEDOR";
            this.BTN_PACK_PROVEEDOR.Size = new System.Drawing.Size(169, 59);
            this.BTN_PACK_PROVEEDOR.TabIndex = 61;
            this.BTN_PACK_PROVEEDOR.Text = "Pack\r\nProveedor";
            this.BTN_PACK_PROVEEDOR.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BTN_PACK_PROVEEDOR.TextWrap = true;
            this.BTN_PACK_PROVEEDOR.ThemeName = "TelerikMetroBlue";
            this.BTN_PACK_PROVEEDOR.Click += new System.EventHandler(this.BTN_PACK_PROVEEDOR_Click);
            // 
            // btnInventarioAntiguedad
            // 
            this.btnInventarioAntiguedad.AccessibleDescription = "btnInventarioAntiguedad";
            this.btnInventarioAntiguedad.AccessibleName = "btnInventarioAntiguedad";
            this.btnInventarioAntiguedad.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioAntiguedad.Image = global::Rmc.Properties.Resources.produccion;
            this.btnInventarioAntiguedad.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInventarioAntiguedad.Location = new System.Drawing.Point(586, 88);
            this.btnInventarioAntiguedad.Name = "btnInventarioAntiguedad";
            this.btnInventarioAntiguedad.Size = new System.Drawing.Size(169, 59);
            this.btnInventarioAntiguedad.TabIndex = 56;
            this.btnInventarioAntiguedad.Text = "Inventario Antigüedad";
            this.btnInventarioAntiguedad.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInventarioAntiguedad.TextWrap = true;
            this.btnInventarioAntiguedad.ThemeName = "TelerikMetroBlue";
            this.btnInventarioAntiguedad.Click += new System.EventHandler(this.btnInventarioAntiguedad_Click);
            // 
            // btnInventarioLocalidadesDetalle
            // 
            this.btnInventarioLocalidadesDetalle.AccessibleDescription = "btnInventarioLocalidadesDetalle";
            this.btnInventarioLocalidadesDetalle.AccessibleName = "btnInventarioLocalidadesDetalle";
            this.btnInventarioLocalidadesDetalle.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioLocalidadesDetalle.Image = global::Rmc.Properties.Resources.inspeccion;
            this.btnInventarioLocalidadesDetalle.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInventarioLocalidadesDetalle.Location = new System.Drawing.Point(370, 88);
            this.btnInventarioLocalidadesDetalle.Name = "btnInventarioLocalidadesDetalle";
            this.btnInventarioLocalidadesDetalle.Size = new System.Drawing.Size(210, 59);
            this.btnInventarioLocalidadesDetalle.TabIndex = 59;
            this.btnInventarioLocalidadesDetalle.Text = "Inventario Localidades Detalle";
            this.btnInventarioLocalidadesDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInventarioLocalidadesDetalle.TextWrap = true;
            this.btnInventarioLocalidadesDetalle.ThemeName = "TelerikMetroBlue";
            this.btnInventarioLocalidadesDetalle.Click += new System.EventHandler(this.btnInventarioLocalidadesDetalle_Click);
            // 
            // btnInventarioLocalidades
            // 
            this.btnInventarioLocalidades.AccessibleDescription = "btnInventarioLocalidades";
            this.btnInventarioLocalidades.AccessibleName = "btnInventarioLocalidades";
            this.btnInventarioLocalidades.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioLocalidades.Image = global::Rmc.Properties.Resources.area;
            this.btnInventarioLocalidades.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInventarioLocalidades.Location = new System.Drawing.Point(195, 88);
            this.btnInventarioLocalidades.Name = "btnInventarioLocalidades";
            this.btnInventarioLocalidades.Size = new System.Drawing.Size(169, 59);
            this.btnInventarioLocalidades.TabIndex = 58;
            this.btnInventarioLocalidades.Text = "Inventario Localidades";
            this.btnInventarioLocalidades.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInventarioLocalidades.TextWrap = true;
            this.btnInventarioLocalidades.ThemeName = "TelerikMetroBlue";
            this.btnInventarioLocalidades.Click += new System.EventHandler(this.btnInventarioLocalidades_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.AccessibleDescription = "btnInventario";
            this.btnInventario.AccessibleName = "btnInventario";
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Image = global::Rmc.Properties.Resources.embalaje;
            this.btnInventario.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInventario.Location = new System.Drawing.Point(20, 88);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(169, 59);
            this.btnInventario.TabIndex = 57;
            this.btnInventario.Text = "Inventario Empaquetado";
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnInventario.TextWrap = true;
            this.btnInventario.ThemeName = "TelerikMetroBlue";
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
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
            this.rgvDetalle.Location = new System.Drawing.Point(20, 184);
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
            gridViewTextBoxColumn1.Width = 104;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CODIGO";
            gridViewTextBoxColumn2.HeaderText = "CÓDIGO";
            gridViewTextBoxColumn2.Name = "CODIGO";
            gridViewTextBoxColumn2.Width = 125;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DESCRIPCION";
            gridViewTextBoxColumn3.HeaderText = "DESCRIPCION";
            gridViewTextBoxColumn3.Name = "DESCRIPCION";
            gridViewTextBoxColumn3.Width = 209;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PAQUETES";
            gridViewTextBoxColumn4.HeaderText = "PAQUETES";
            gridViewTextBoxColumn4.Name = "PAQUETES";
            gridViewTextBoxColumn4.Width = 104;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "PACKID";
            gridViewTextBoxColumn5.HeaderText = "PACK_ID";
            gridViewTextBoxColumn5.Name = "PACKID";
            gridViewTextBoxColumn5.Width = 104;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "LIBRAS";
            gridViewTextBoxColumn6.HeaderText = "LIBRAS";
            gridViewTextBoxColumn6.Name = "LIBRAS";
            gridViewTextBoxColumn6.Width = 104;
            gridViewTextBoxColumn7.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "FECHAINGRESO";
            gridViewTextBoxColumn7.FormatString = "{0:yyyy/MM/dd HH:mm:ss}";
            gridViewTextBoxColumn7.HeaderText = "FECHA INGRESO";
            gridViewTextBoxColumn7.Name = "FECHAINGRESO";
            gridViewTextBoxColumn7.Width = 104;
            gridViewTextBoxColumn8.FieldName = "LOTE";
            gridViewTextBoxColumn8.HeaderText = "LOTE";
            gridViewTextBoxColumn8.Name = "LOTE";
            gridViewTextBoxColumn8.Width = 114;
            gridViewTextBoxColumn9.FieldName = "DIAS";
            gridViewTextBoxColumn9.HeaderText = "DIAS";
            gridViewTextBoxColumn9.Name = "DIAS";
            gridViewTextBoxColumn9.Width = 114;
            gridViewTextBoxColumn10.FieldName = "LEYENDA";
            gridViewTextBoxColumn10.HeaderText = "LEYENDA";
            gridViewTextBoxColumn10.Name = "LEYENDA";
            gridViewTextBoxColumn10.Width = 102;
            gridViewTextBoxColumn11.FieldName = "PROVEEDOR";
            gridViewTextBoxColumn11.HeaderText = "PROVEEDOR";
            gridViewTextBoxColumn11.Name = "PROVEEDOR";
            gridViewTextBoxColumn11.Width = 48;
            this.rgvDetalle.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.rgvDetalle.MasterTemplate.EnableFiltering = true;
            this.rgvDetalle.MasterTemplate.EnableGrouping = false;
            this.rgvDetalle.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDetalle.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvDetalle.Name = "rgvDetalle";
            this.rgvDetalle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDetalle.Size = new System.Drawing.Size(1260, 450);
            this.rgvDetalle.TabIndex = 62;
            this.rgvDetalle.ThemeName = "TelerikMetroBlue";
            // 
            // YarmInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 636);
            this.Controls.Add(this.rgvDetalle);
            this.Controls.Add(this.btnInvProveedor);
            this.Controls.Add(this.BTN_PACK_PROVEEDOR);
            this.Controls.Add(this.btnInventarioAntiguedad);
            this.Controls.Add(this.btnInventarioLocalidadesDetalle);
            this.Controls.Add(this.btnInventarioLocalidades);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.radPanel1);
            this.Name = "YarmInventoryForm";
            this.Text = "Inventario de Hilos";
            this.Load += new System.EventHandler(this.YarmInventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInvProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_PACK_PROVEEDOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventarioAntiguedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventarioLocalidadesDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventarioLocalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;

        public YarmInventoryForm(RadPanel radPanel1)
        {
            this.radPanel1 = radPanel1;
        }

        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton btnInvProveedor;
        private Telerik.WinControls.UI.RadButton BTN_PACK_PROVEEDOR;
        private Telerik.WinControls.UI.RadButton btnInventarioAntiguedad;
        private Telerik.WinControls.UI.RadButton btnInventarioLocalidadesDetalle;
        private Telerik.WinControls.UI.RadButton btnInventarioLocalidades;
        private Telerik.WinControls.UI.RadButton btnInventario;
        private Telerik.WinControls.UI.RadGridView rgvDetalle;
    }
}
