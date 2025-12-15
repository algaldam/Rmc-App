namespace Rmc.RMC.Warehouse.Reports
{
    partial class WarehouseDeliveryForm
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn4 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GRID_VIEW_DETALLE = new Telerik.WinControls.UI.RadGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlBodegas = new Telerik.WinControls.UI.RadDropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBuscar = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.DtFecha1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.DtFecha2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.entregaSolicitudBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE.MasterTemplate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFecha1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFecha2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entregaSolicitudBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GRID_VIEW_DETALLE
            // 
            this.GRID_VIEW_DETALLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GRID_VIEW_DETALLE.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRID_VIEW_DETALLE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRID_VIEW_DETALLE.Font = new System.Drawing.Font("Tahoma", 9F);
            this.GRID_VIEW_DETALLE.ForeColor = System.Drawing.Color.Black;
            this.GRID_VIEW_DETALLE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRID_VIEW_DETALLE.Location = new System.Drawing.Point(6, 92);
            this.GRID_VIEW_DETALLE.Margin = new System.Windows.Forms.Padding(6);
            // 
            // 
            // 
            this.GRID_VIEW_DETALLE.MasterTemplate.AllowAddNewRow = false;
            this.GRID_VIEW_DETALLE.MasterTemplate.AllowDeleteRow = false;
            this.GRID_VIEW_DETALLE.MasterTemplate.AllowEditRow = false;
            this.GRID_VIEW_DETALLE.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.GRID_VIEW_DETALLE.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            gridViewTextBoxColumn9.FieldName = "PackId";
            gridViewTextBoxColumn9.HeaderText = "PackId";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.MinWidth = 171;
            gridViewTextBoxColumn9.Name = "PackId";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 171;
            gridViewTextBoxColumn10.FieldName = "Semana";
            gridViewTextBoxColumn10.HeaderText = "Semana";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.MinWidth = 186;
            gridViewTextBoxColumn10.Name = "Semana";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 186;
            gridViewTextBoxColumn11.FieldName = "Codigo";
            gridViewTextBoxColumn11.HeaderText = "Código";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.MinWidth = 256;
            gridViewTextBoxColumn11.Name = "Codigo";
            gridViewTextBoxColumn11.Width = 256;
            gridViewTextBoxColumn12.FieldName = "Producto";
            gridViewTextBoxColumn12.HeaderText = "Producto";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.MinWidth = 498;
            gridViewTextBoxColumn12.Name = "Producto";
            gridViewTextBoxColumn12.Width = 498;
            gridViewTextBoxColumn13.FieldName = "Proveedor";
            gridViewTextBoxColumn13.HeaderText = "Proveedor";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.MinWidth = 428;
            gridViewTextBoxColumn13.Name = "Proveedor";
            gridViewTextBoxColumn13.Width = 428;
            gridViewDateTimeColumn3.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn3.FieldName = "FechaCreacion";
            gridViewDateTimeColumn3.HeaderText = "Fecha Crea";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.MinWidth = 285;
            gridViewDateTimeColumn3.Name = "FechaCreacion";
            gridViewDateTimeColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn3.Width = 285;
            gridViewDateTimeColumn4.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn4.FieldName = "FechaEntrega";
            gridViewDateTimeColumn4.HeaderText = "Fecha Entrega";
            gridViewDateTimeColumn4.IsAutoGenerated = true;
            gridViewDateTimeColumn4.MinWidth = 285;
            gridViewDateTimeColumn4.Name = "FechaEntrega";
            gridViewDateTimeColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn4.Width = 285;
            gridViewTextBoxColumn14.FieldName = "PersonaEntrega";
            gridViewTextBoxColumn14.HeaderText = "Entrega";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.MinWidth = 357;
            gridViewTextBoxColumn14.Name = "PersonaEntrega";
            gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn14.Width = 357;
            gridViewDecimalColumn2.DataType = typeof(double);
            gridViewDecimalColumn2.FieldName = "Minutos";
            gridViewDecimalColumn2.HeaderText = "Minutos";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.MinWidth = 215;
            gridViewDecimalColumn2.Name = "Minutos";
            gridViewDecimalColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn2.Width = 215;
            gridViewTextBoxColumn15.FieldName = "Bodega";
            gridViewTextBoxColumn15.HeaderText = "Bodega";
            gridViewTextBoxColumn15.MinWidth = 233;
            gridViewTextBoxColumn15.Name = "Bodega";
            gridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn15.Width = 233;
            gridViewTextBoxColumn16.FieldName = "PersonaAutoriza";
            gridViewTextBoxColumn16.HeaderText = "Autoriza";
            gridViewTextBoxColumn16.IsAutoGenerated = true;
            gridViewTextBoxColumn16.MinWidth = 225;
            gridViewTextBoxColumn16.Name = "PersonaAutoriza";
            gridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn16.Width = 225;
            this.GRID_VIEW_DETALLE.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewDateTimeColumn3,
            gridViewDateTimeColumn4,
            gridViewTextBoxColumn14,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.GRID_VIEW_DETALLE.MasterTemplate.EnableFiltering = true;
            this.GRID_VIEW_DETALLE.MasterTemplate.MultiSelect = true;
            this.GRID_VIEW_DETALLE.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GRID_VIEW_DETALLE.Name = "GRID_VIEW_DETALLE";
            this.GRID_VIEW_DETALLE.ReadOnly = true;
            this.GRID_VIEW_DETALLE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.GRID_VIEW_DETALLE.RootElement.EnableElementShadow = true;
            this.GRID_VIEW_DETALLE.RootElement.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.GRID_VIEW_DETALLE.Size = new System.Drawing.Size(1366, 466);
            this.GRID_VIEW_DETALLE.TabIndex = 26;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GRID_VIEW_DETALLE, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1378, 564);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // radPanel2
            // 
            this.radPanel2.AutoScroll = true;
            this.radPanel2.AutoScrollMinSize = new System.Drawing.Size(1230, 80);
            this.radPanel2.Controls.Add(this.label1);
            this.radPanel2.Controls.Add(this.ddlBodegas);
            this.radPanel2.Controls.Add(this.label3);
            this.radPanel2.Controls.Add(this.label2);
            this.radPanel2.Controls.Add(this.DtFecha1);
            this.radPanel2.Controls.Add(this.DtFecha2);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(3, 3);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1372, 80);
            this.radPanel2.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "Bodegas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ddlBodegas
            // 
            this.ddlBodegas.DropDownHeight = 168;
            this.ddlBodegas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBodegas.Location = new System.Drawing.Point(90, 32);
            this.ddlBodegas.Name = "ddlBodegas";
            this.ddlBodegas.Size = new System.Drawing.Size(287, 28);
            this.ddlBodegas.TabIndex = 41;
            this.ddlBodegas.ThemeName = "TelerikMetroBlue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(477, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fecha Inicial";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = global::Rmc.Properties.Resources.lupa;
            this.BtnBuscar.Location = new System.Drawing.Point(1140, 10);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(200, 56);
            this.BtnBuscar.TabIndex = 21;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(983, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Fecha Final";
            // 
            // DtFecha1
            // 
            this.DtFecha1.CustomFormat = "MM/dd/yyyy:HH:mm";
            this.DtFecha1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha1.Location = new System.Drawing.Point(646, 23);
            this.DtFecha1.Name = "DtFecha1";
            this.DtFecha1.Size = new System.Drawing.Size(296, 27);
            this.DtFecha1.TabIndex = 22;
            this.DtFecha1.TabStop = false;
            this.DtFecha1.Text = "04/06/2019:00:00";
            this.DtFecha1.Value = new System.DateTime(2019, 4, 6, 0, 0, 0, 0);
            // 
            // DtFecha2
            // 
            this.DtFecha2.CustomFormat = "MM/dd/yyyy:HH:mm";
            this.DtFecha2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha2.Location = new System.Drawing.Point(1181, 23);
            this.DtFecha2.Name = "DtFecha2";
            this.DtFecha2.Size = new System.Drawing.Size(310, 27);
            this.DtFecha2.TabIndex = 24;
            this.DtFecha2.TabStop = false;
            this.DtFecha2.Text = "04/06/2019:00:00";
            this.DtFecha2.Value = new System.DateTime(2019, 4, 6, 0, 0, 0, 0);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightGray;
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Controls.Add(this.BtnBuscar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1378, 72);
            this.radPanel1.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(526, 46);
            this.label6.TabIndex = 14;
            this.label6.Text = "Historial de Entregas Realizadas";
            // 
            // WarehouseDeliveryForm
            // 
            this.ClientSize = new System.Drawing.Size(1378, 636);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.radPanel1);
            this.Name = "WarehouseDeliveryForm";
            this.Text = "Entrega de Solicitudes";
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodegas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFecha1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFecha2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entregaSolicitudBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GRID_VIEW_DETALLE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton BtnBuscar;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDateTimePicker DtFecha1;
        private Telerik.WinControls.UI.RadDateTimePicker DtFecha2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource entregaSolicitudBindingSource;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList ddlBodegas;
    }
}
