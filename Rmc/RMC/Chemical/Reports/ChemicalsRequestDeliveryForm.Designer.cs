namespace Rmc.RMC.Chemical.Reports
{
    partial class ChemicalsRequestDeliveryForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn5 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn6 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GRID_VIEW_DETALLE = new Telerik.WinControls.UI.RadGridView();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodegas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFecha1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFecha2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GRID_VIEW_DETALLE, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1378, 556);
            this.tableLayoutPanel1.TabIndex = 34;
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
            gridViewTextBoxColumn17.FieldName = "PackId";
            gridViewTextBoxColumn17.HeaderText = "PackId";
            gridViewTextBoxColumn17.IsAutoGenerated = true;
            gridViewTextBoxColumn17.MinWidth = 189;
            gridViewTextBoxColumn17.Name = "PackId";
            gridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn17.Width = 189;
            gridViewTextBoxColumn18.FieldName = "Semana";
            gridViewTextBoxColumn18.HeaderText = "Semana";
            gridViewTextBoxColumn18.IsAutoGenerated = true;
            gridViewTextBoxColumn18.MinWidth = 206;
            gridViewTextBoxColumn18.Name = "Semana";
            gridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn18.Width = 206;
            gridViewTextBoxColumn19.FieldName = "Codigo";
            gridViewTextBoxColumn19.HeaderText = "Código";
            gridViewTextBoxColumn19.IsAutoGenerated = true;
            gridViewTextBoxColumn19.MinWidth = 283;
            gridViewTextBoxColumn19.Name = "Codigo";
            gridViewTextBoxColumn19.Width = 283;
            gridViewTextBoxColumn20.FieldName = "Producto";
            gridViewTextBoxColumn20.HeaderText = "Producto";
            gridViewTextBoxColumn20.IsAutoGenerated = true;
            gridViewTextBoxColumn20.MinWidth = 551;
            gridViewTextBoxColumn20.Name = "Producto";
            gridViewTextBoxColumn20.Width = 551;
            gridViewTextBoxColumn21.FieldName = "Proveedor";
            gridViewTextBoxColumn21.HeaderText = "Proveedor";
            gridViewTextBoxColumn21.IsAutoGenerated = true;
            gridViewTextBoxColumn21.MinWidth = 473;
            gridViewTextBoxColumn21.Name = "Proveedor";
            gridViewTextBoxColumn21.Width = 473;
            gridViewDateTimeColumn5.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn5.FieldName = "FechaCreacion";
            gridViewDateTimeColumn5.HeaderText = "Fecha Crea";
            gridViewDateTimeColumn5.IsAutoGenerated = true;
            gridViewDateTimeColumn5.MinWidth = 316;
            gridViewDateTimeColumn5.Name = "FechaCreacion";
            gridViewDateTimeColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn5.Width = 316;
            gridViewDateTimeColumn6.DataType = typeof(System.Nullable<System.DateTime>);
            gridViewDateTimeColumn6.FieldName = "FechaEntrega";
            gridViewDateTimeColumn6.HeaderText = "Fecha Entrega";
            gridViewDateTimeColumn6.IsAutoGenerated = true;
            gridViewDateTimeColumn6.MinWidth = 316;
            gridViewDateTimeColumn6.Name = "FechaEntrega";
            gridViewDateTimeColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn6.Width = 316;
            gridViewTextBoxColumn22.FieldName = "PersonaEntrega";
            gridViewTextBoxColumn22.HeaderText = "Entrega";
            gridViewTextBoxColumn22.IsAutoGenerated = true;
            gridViewTextBoxColumn22.MinWidth = 396;
            gridViewTextBoxColumn22.Name = "PersonaEntrega";
            gridViewTextBoxColumn22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn22.Width = 396;
            gridViewDecimalColumn3.DataType = typeof(double);
            gridViewDecimalColumn3.FieldName = "Minutos";
            gridViewDecimalColumn3.HeaderText = "Minutos";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.MinWidth = 238;
            gridViewDecimalColumn3.Name = "Minutos";
            gridViewDecimalColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn3.Width = 238;
            gridViewTextBoxColumn23.FieldName = "Bodega";
            gridViewTextBoxColumn23.HeaderText = "Bodega";
            gridViewTextBoxColumn23.MinWidth = 258;
            gridViewTextBoxColumn23.Name = "Bodega";
            gridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn23.Width = 258;
            gridViewTextBoxColumn24.FieldName = "PersonaAutoriza";
            gridViewTextBoxColumn24.HeaderText = "Autoriza";
            gridViewTextBoxColumn24.IsAutoGenerated = true;
            gridViewTextBoxColumn24.MinWidth = 249;
            gridViewTextBoxColumn24.Name = "PersonaAutoriza";
            gridViewTextBoxColumn24.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn24.Width = 249;
            this.GRID_VIEW_DETALLE.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewDateTimeColumn5,
            gridViewDateTimeColumn6,
            gridViewTextBoxColumn22,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24});
            this.GRID_VIEW_DETALLE.MasterTemplate.EnableFiltering = true;
            this.GRID_VIEW_DETALLE.MasterTemplate.MultiSelect = true;
            this.GRID_VIEW_DETALLE.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.GRID_VIEW_DETALLE.Name = "GRID_VIEW_DETALLE";
            this.GRID_VIEW_DETALLE.ReadOnly = true;
            this.GRID_VIEW_DETALLE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.GRID_VIEW_DETALLE.RootElement.EnableElementShadow = true;
            this.GRID_VIEW_DETALLE.RootElement.FocusBorderColor = System.Drawing.Color.DodgerBlue;
            this.GRID_VIEW_DETALLE.Size = new System.Drawing.Size(1366, 458);
            this.GRID_VIEW_DETALLE.TabIndex = 26;
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
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "Bodegas";
            // 
            // ddlBodegas
            // 
            this.ddlBodegas.DropDownHeight = 186;
            this.ddlBodegas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBodegas.Location = new System.Drawing.Point(100, 36);
            this.ddlBodegas.Name = "ddlBodegas";
            this.ddlBodegas.Size = new System.Drawing.Size(267, 28);
            this.ddlBodegas.TabIndex = 41;
            this.ddlBodegas.ThemeName = "TelerikMetroBlue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(471, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fecha Inicial";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = global::Rmc.Properties.Resources.lupa;
            this.BtnBuscar.Location = new System.Drawing.Point(1189, 23);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(177, 50);
            this.BtnBuscar.TabIndex = 21;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1005, 35);
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
            this.DtFecha1.Location = new System.Drawing.Point(638, 29);
            this.DtFecha1.Name = "DtFecha1";
            this.DtFecha1.Size = new System.Drawing.Size(327, 27);
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
            this.DtFecha2.Location = new System.Drawing.Point(1206, 22);
            this.DtFecha2.Name = "DtFecha2";
            this.DtFecha2.Size = new System.Drawing.Size(343, 27);
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
            this.radPanel1.Size = new System.Drawing.Size(1378, 80);
            this.radPanel1.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(733, 46);
            this.label6.TabIndex = 14;
            this.label6.Text = "Historial de Entregas de Químicos Realizadas";
            // 
            // ChemicalsRequestDeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 636);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.radPanel1);
            this.Name = "ChemicalsRequestDeliveryForm";
            this.Text = "Entrega Solicitudes - Quimicos";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_DETALLE)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadGridView GRID_VIEW_DETALLE;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList ddlBodegas;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadButton BtnBuscar;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDateTimePicker DtFecha1;
        private Telerik.WinControls.UI.RadDateTimePicker DtFecha2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
    }
}
