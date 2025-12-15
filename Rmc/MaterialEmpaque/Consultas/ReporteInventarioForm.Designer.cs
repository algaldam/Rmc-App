using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    partial class ReporteInventarioForm : RadForm
    {
        private System.ComponentModel.IContainer components = null;
        private RadGridView gridMovimientos;
        private RadButton btnVerSalidas;
        private RadButton btnVerTransferencias;
        private RadLabel lblTitulo;
        private RadPanel pnlFiltros;
        private RadLabel lblDesde;
        private RadDateTimePicker dtpDesde;
        private RadLabel lblHasta;
        private RadDateTimePicker dtpHasta;
        private RadButton btnFiltrar;
        private RadButton btnExportarExcel;
        private RadButton btnLimpiarFiltros;
        private RadPanel pnlKPIs;
        private RadLabel lblTotalRegistros;
        private RadLabel lblValorTotalRegistros;
        private RadLabel lblValorSalidas;
        private RadLabel lblEntradas;
        private RadLabel lblValorEntradas;
        private RadLabel lblTransferencias;
        private RadLabel lblValorTransferencias;
        private RadLabel lblUltimaActualizacion;
        private RadProgressBar progressCarga;
        private RadLabel lblEstado;
        private TableLayoutPanel tableLayoutKPIs;
        private RadLabel radLabel1;
        private RadLabel lblFiltroMovimiento;
        private ComboBox cbFiltroMovimiento;

        // Nuevos controles para filtros de hora
        private RadLabel lblHoraDesde;
        private RadDateTimePicker dtpHoraDesde;
        private RadLabel lblHoraHasta;
        private RadDateTimePicker dtpHoraHasta;
        private RadButton btnUltimosMovimientos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridMovimientos = new Telerik.WinControls.UI.RadGridView();
            this.btnVerSalidas = new Telerik.WinControls.UI.RadButton();
            this.btnVerTransferencias = new Telerik.WinControls.UI.RadButton();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.pnlFiltros = new Telerik.WinControls.UI.RadPanel();
            this.cbFiltroMovimiento = new System.Windows.Forms.ComboBox();
            this.lblFiltroMovimiento = new Telerik.WinControls.UI.RadLabel();
            this.dtpHoraHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHoraHasta = new Telerik.WinControls.UI.RadLabel();
            this.dtpHoraDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHoraDesde = new Telerik.WinControls.UI.RadLabel();
            this.lblDesde = new Telerik.WinControls.UI.RadLabel();
            this.dtpDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHasta = new Telerik.WinControls.UI.RadLabel();
            this.dtpHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnFiltrar = new Telerik.WinControls.UI.RadButton();
            this.btnLimpiarFiltros = new Telerik.WinControls.UI.RadButton();
            this.btnExportarExcel = new Telerik.WinControls.UI.RadButton();
            this.btnUltimosMovimientos = new Telerik.WinControls.UI.RadButton();
            this.pnlKPIs = new Telerik.WinControls.UI.RadPanel();
            this.tableLayoutKPIs = new System.Windows.Forms.TableLayoutPanel();
            this.lblUltimaActualizacion = new Telerik.WinControls.UI.RadLabel();
            this.lblTransferencias = new Telerik.WinControls.UI.RadLabel();
            this.lblValorTransferencias = new Telerik.WinControls.UI.RadLabel();
            this.lblEntradas = new Telerik.WinControls.UI.RadLabel();
            this.lblValorEntradas = new Telerik.WinControls.UI.RadLabel();
            this.lblValorSalidas = new Telerik.WinControls.UI.RadLabel();
            this.lblTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            this.lblValorTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.progressCarga = new Telerik.WinControls.UI.RadProgressBar();
            this.lblEstado = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFiltroMovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiarFiltros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUltimosMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKPIs)).BeginInit();
            this.pnlKPIs.SuspendLayout();
            this.tableLayoutKPIs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUltimaActualizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMovimientos
            // 
            this.gridMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMovimientos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gridMovimientos.Location = new System.Drawing.Point(20, 281);
            // 
            // 
            // 
            this.gridMovimientos.MasterTemplate.AllowAddNewRow = false;
            this.gridMovimientos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridMovimientos.MasterTemplate.EnableFiltering = true;
            this.gridMovimientos.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gridMovimientos.Name = "gridMovimientos";
            this.gridMovimientos.Size = new System.Drawing.Size(1571, 399);
            this.gridMovimientos.TabIndex = 5;
            this.gridMovimientos.ThemeName = "Fluent";
            // 
            // btnVerSalidas
            // 
            this.btnVerSalidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnVerSalidas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerSalidas.ForeColor = System.Drawing.Color.White;
            this.btnVerSalidas.Image = global::Rmc.Properties.Resources.reporte;
            this.btnVerSalidas.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerSalidas.Location = new System.Drawing.Point(20, 235);
            this.btnVerSalidas.Name = "btnVerSalidas";
            this.btnVerSalidas.Size = new System.Drawing.Size(150, 40);
            this.btnVerSalidas.TabIndex = 3;
            this.btnVerSalidas.Text = "MOVIMIENTOS";
            this.btnVerSalidas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerSalidas.ThemeName = "Fluent";
            this.btnVerSalidas.Click += new System.EventHandler(this.btnVerSalidas_Click);
            // 
            // btnVerTransferencias
            // 
            this.btnVerTransferencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnVerTransferencias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerTransferencias.ForeColor = System.Drawing.Color.White;
            this.btnVerTransferencias.Image = global::Rmc.Properties.Resources.transfer;
            this.btnVerTransferencias.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerTransferencias.Location = new System.Drawing.Point(180, 235);
            this.btnVerTransferencias.Name = "btnVerTransferencias";
            this.btnVerTransferencias.Size = new System.Drawing.Size(168, 40);
            this.btnVerTransferencias.TabIndex = 4;
            this.btnVerTransferencias.Text = "TRANSFERENCIAS";
            this.btnVerTransferencias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerTransferencias.ThemeName = "Fluent";
            this.btnVerTransferencias.Click += new System.EventHandler(this.btnVerTransferencias_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(342, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MOVIMIENTOS DE INVENTARIO";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.cbFiltroMovimiento);
            this.pnlFiltros.Controls.Add(this.lblFiltroMovimiento);
            this.pnlFiltros.Controls.Add(this.dtpHoraHasta);
            this.pnlFiltros.Controls.Add(this.lblHoraHasta);
            this.pnlFiltros.Controls.Add(this.dtpHoraDesde);
            this.pnlFiltros.Controls.Add(this.lblHoraDesde);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.pnlFiltros.Controls.Add(this.btnExportarExcel);
            this.pnlFiltros.Location = new System.Drawing.Point(20, 60);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(15);
            this.pnlFiltros.Size = new System.Drawing.Size(1571, 70);
            this.pnlFiltros.TabIndex = 1;
            // 
            // cbFiltroMovimiento
            // 
            this.cbFiltroMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltroMovimiento.FormattingEnabled = true;
            this.cbFiltroMovimiento.Location = new System.Drawing.Point(1326, 23);
            this.cbFiltroMovimiento.Name = "cbFiltroMovimiento";
            this.cbFiltroMovimiento.Size = new System.Drawing.Size(121, 23);
            this.cbFiltroMovimiento.TabIndex = 8;
            // 
            // lblFiltroMovimiento
            // 
            this.lblFiltroMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroMovimiento.Location = new System.Drawing.Point(1234, 25);
            this.lblFiltroMovimiento.Name = "lblFiltroMovimiento";
            this.lblFiltroMovimiento.Size = new System.Drawing.Size(86, 19);
            this.lblFiltroMovimiento.TabIndex = 7;
            this.lblFiltroMovimiento.Text = "Movimientos:";
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraHasta.Location = new System.Drawing.Point(657, 22);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.Size = new System.Drawing.Size(103, 24);
            this.dtpHoraHasta.TabIndex = 12;
            this.dtpHoraHasta.TabStop = false;
            this.dtpHoraHasta.Text = "6:00:00 PM";
            this.dtpHoraHasta.Value = new System.DateTime(2025, 11, 13, 18, 0, 0, 0);
            // 
            // lblHoraHasta
            // 
            this.lblHoraHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraHasta.Location = new System.Drawing.Point(597, 25);
            this.lblHoraHasta.Name = "lblHoraHasta";
            this.lblHoraHasta.Size = new System.Drawing.Size(45, 19);
            this.lblHoraHasta.TabIndex = 11;
            this.lblHoraHasta.Text = "HORA:";
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraDesde.Location = new System.Drawing.Point(278, 22);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.Size = new System.Drawing.Size(103, 24);
            this.dtpHoraDesde.TabIndex = 10;
            this.dtpHoraDesde.TabStop = false;
            this.dtpHoraDesde.Text = "7:00:00 AM";
            this.dtpHoraDesde.Value = new System.DateTime(2025, 11, 13, 7, 0, 0, 0);
            // 
            // lblHoraDesde
            // 
            this.lblHoraDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraDesde.Location = new System.Drawing.Point(218, 25);
            this.lblHoraDesde.Name = "lblHoraDesde";
            this.lblHoraDesde.Size = new System.Drawing.Size(45, 19);
            this.lblHoraDesde.TabIndex = 9;
            this.lblHoraDesde.Text = "HORA:";
            // 
            // lblDesde
            // 
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.Location = new System.Drawing.Point(20, 25);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(48, 19);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "DESDE:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(83, 22);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 24);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.TabStop = false;
            this.dtpDesde.Text = "11/7/2025";
            this.dtpDesde.ThemeName = "Fluent";
            this.dtpDesde.Value = new System.DateTime(2025, 11, 7, 16, 25, 31, 966);
            // 
            // lblHasta
            // 
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.Location = new System.Drawing.Point(396, 25);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(51, 19);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "HASTA:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(462, 22);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 24);
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.TabStop = false;
            this.dtpHasta.Text = "11/7/2025";
            this.dtpHasta.ThemeName = "Fluent";
            this.dtpHasta.Value = new System.DateTime(2025, 11, 7, 16, 25, 31, 987);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Image = global::Rmc.Properties.Resources.lupa;
            this.btnFiltrar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFiltrar.Location = new System.Drawing.Point(807, 15);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(123, 35);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFiltrar.ThemeName = "Fluent";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(937, 15);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiarFiltros.TabIndex = 5;
            this.btnLimpiarFiltros.Text = "LIMPIAR";
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Image = global::Rmc.Properties.Resources.excefile;
            this.btnExportarExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportarExcel.Location = new System.Drawing.Point(1072, 15);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(156, 35);
            this.btnExportarExcel.TabIndex = 6;
            this.btnExportarExcel.Text = "EXPORTAR EXCEL";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnUltimosMovimientos
            // 
            this.btnUltimosMovimientos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnUltimosMovimientos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUltimosMovimientos.ForeColor = System.Drawing.Color.White;
            this.btnUltimosMovimientos.Location = new System.Drawing.Point(364, 238);
            this.btnUltimosMovimientos.Name = "btnUltimosMovimientos";
            this.btnUltimosMovimientos.Size = new System.Drawing.Size(150, 35);
            this.btnUltimosMovimientos.TabIndex = 13;
            this.btnUltimosMovimientos.Text = "ÚLTIMOS 300";
            this.btnUltimosMovimientos.Visible = false;
            this.btnUltimosMovimientos.Click += new System.EventHandler(this.btnUltimosMovimientos_Click);
            // 
            // pnlKPIs
            // 
            this.pnlKPIs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKPIs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlKPIs.Controls.Add(this.tableLayoutKPIs);
            this.pnlKPIs.Location = new System.Drawing.Point(20, 140);
            this.pnlKPIs.Name = "pnlKPIs";
            this.pnlKPIs.Padding = new System.Windows.Forms.Padding(10);
            this.pnlKPIs.Size = new System.Drawing.Size(1571, 89);
            this.pnlKPIs.TabIndex = 2;
            // 
            // tableLayoutKPIs
            // 
            this.tableLayoutKPIs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutKPIs.ColumnCount = 8;
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutKPIs.Controls.Add(this.lblUltimaActualizacion, 7, 0);
            this.tableLayoutKPIs.Controls.Add(this.lblTransferencias, 6, 1);
            this.tableLayoutKPIs.Controls.Add(this.lblValorTransferencias, 6, 0);
            this.tableLayoutKPIs.Controls.Add(this.lblEntradas, 4, 1);
            this.tableLayoutKPIs.Controls.Add(this.lblValorEntradas, 4, 0);
            this.tableLayoutKPIs.Controls.Add(this.lblValorSalidas, 2, 0);
            this.tableLayoutKPIs.Controls.Add(this.lblTotalRegistros, 0, 1);
            this.tableLayoutKPIs.Controls.Add(this.lblValorTotalRegistros, 0, 0);
            this.tableLayoutKPIs.Controls.Add(this.radLabel1, 2, 1);
            this.tableLayoutKPIs.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutKPIs.Name = "tableLayoutKPIs";
            this.tableLayoutKPIs.RowCount = 2;
            this.tableLayoutKPIs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.29508F));
            this.tableLayoutKPIs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.70492F));
            this.tableLayoutKPIs.Size = new System.Drawing.Size(1551, 66);
            this.tableLayoutKPIs.TabIndex = 9;
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUltimaActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(1354, 11);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(194, 18);
            this.lblUltimaActualizacion.TabIndex = 8;
            this.lblUltimaActualizacion.Text = "Actualizado: --:--:--";
            // 
            // lblTransferencias
            // 
            this.lblTransferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransferencias.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTransferencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTransferencias.Location = new System.Drawing.Point(1161, 44);
            this.lblTransferencias.Name = "lblTransferencias";
            this.lblTransferencias.Size = new System.Drawing.Size(187, 18);
            this.lblTransferencias.TabIndex = 7;
            this.lblTransferencias.Text = "TRANSFERENCIAS";
            this.lblTransferencias.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblValorTransferencias
            // 
            this.lblValorTransferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTransferencias.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblValorTransferencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblValorTransferencias.Location = new System.Drawing.Point(1161, 6);
            this.lblValorTransferencias.Name = "lblValorTransferencias";
            this.lblValorTransferencias.Size = new System.Drawing.Size(187, 29);
            this.lblValorTransferencias.TabIndex = 6;
            this.lblValorTransferencias.Text = "0";
            this.lblValorTransferencias.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblEntradas
            // 
            this.lblEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntradas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblEntradas.Location = new System.Drawing.Point(775, 44);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(187, 18);
            this.lblEntradas.TabIndex = 5;
            this.lblEntradas.Text = "ENTRADAS";
            this.lblEntradas.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblValorEntradas
            // 
            this.lblValorEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorEntradas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblValorEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblValorEntradas.Location = new System.Drawing.Point(775, 6);
            this.lblValorEntradas.Name = "lblValorEntradas";
            this.lblValorEntradas.Size = new System.Drawing.Size(187, 29);
            this.lblValorEntradas.TabIndex = 4;
            this.lblValorEntradas.Text = "0";
            this.lblValorEntradas.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblValorSalidas
            // 
            this.lblValorSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorSalidas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblValorSalidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblValorSalidas.Location = new System.Drawing.Point(389, 6);
            this.lblValorSalidas.Name = "lblValorSalidas";
            this.lblValorSalidas.Size = new System.Drawing.Size(187, 29);
            this.lblValorSalidas.TabIndex = 2;
            this.lblValorSalidas.Text = "0";
            this.lblValorSalidas.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(3, 44);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(187, 18);
            this.lblTotalRegistros.TabIndex = 1;
            this.lblTotalRegistros.Text = "TOTAL";
            this.lblTotalRegistros.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblValorTotalRegistros
            // 
            this.lblValorTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblValorTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblValorTotalRegistros.Location = new System.Drawing.Point(3, 6);
            this.lblValorTotalRegistros.Name = "lblValorTotalRegistros";
            this.lblValorTotalRegistros.Size = new System.Drawing.Size(187, 29);
            this.lblValorTotalRegistros.TabIndex = 0;
            this.lblValorTotalRegistros.Text = "0";
            this.lblValorTotalRegistros.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.radLabel1.Location = new System.Drawing.Point(389, 44);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(187, 18);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "SALIDAS";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // progressCarga
            // 
            this.progressCarga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressCarga.Location = new System.Drawing.Point(20, 690);
            this.progressCarga.Name = "progressCarga";
            this.progressCarga.Size = new System.Drawing.Size(1571, 8);
            this.progressCarga.TabIndex = 6;
            this.progressCarga.ThemeName = "Fluent";
            this.progressCarga.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEstado.Location = new System.Drawing.Point(20, 700);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(61, 18);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Cargando...";
            this.lblEstado.Visible = false;
            // 
            // ReporteInventarioForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1611, 730);
            this.Controls.Add(this.btnUltimosMovimientos);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.progressCarga);
            this.Controls.Add(this.pnlKPIs);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.btnVerSalidas);
            this.Controls.Add(this.btnVerTransferencias);
            this.Controls.Add(this.gridMovimientos);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ReporteInventarioForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Inventario";
            this.ThemeName = "Fluent";
            this.Load += new System.EventHandler(this.ReporteInventarioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerTransferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFiltroMovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiarFiltros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUltimosMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKPIs)).EndInit();
            this.pnlKPIs.ResumeLayout(false);
            this.tableLayoutKPIs.ResumeLayout(false);
            this.tableLayoutKPIs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUltimaActualizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTransferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}