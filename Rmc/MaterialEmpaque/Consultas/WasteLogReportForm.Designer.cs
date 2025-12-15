using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    partial class WasteLogReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private RadGridView gridWasteLog;
        private RadLabel lblTitulo;
        private RadPanel pnlFiltros;
        private RadLabel lblDesde;
        private RadDateTimePicker dtpDesde;
        private RadLabel lblHasta;
        private RadDateTimePicker dtpHasta;
        private RadButton btnFiltrar;
        private RadButton btnExportarExcel;
        private RadButton btnLimpiarFiltros;
        private RadProgressBar progressCarga;
        private RadLabel lblEstado;

        // Controles para filtros de hora
        private RadLabel lblHoraDesde;
        private RadDateTimePicker dtpHoraDesde;
        private RadLabel lblHoraHasta;
        private RadDateTimePicker dtpHoraHasta;
        private RadButton btnUltimosRegistros;

        // Panel simplificado para totales
        private RadPanel pnlTotales;
        private RadLabel lblTotalRegistros;
        private RadLabel lblValorTotalRegistros;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridWasteLog = new Telerik.WinControls.UI.RadGridView();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.pnlFiltros = new Telerik.WinControls.UI.RadPanel();
            this.dtpHoraHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHoraHasta = new Telerik.WinControls.UI.RadLabel();
            this.dtpHoraDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHoraDesde = new Telerik.WinControls.UI.RadLabel();
            this.lblDesde = new Telerik.WinControls.UI.RadLabel();
            this.dtpDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHasta = new Telerik.WinControls.UI.RadLabel();
            this.dtpHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.btnLimpiarFiltros = new Telerik.WinControls.UI.RadButton();
            this.btnUltimosRegistros = new Telerik.WinControls.UI.RadButton();
            this.progressCarga = new Telerik.WinControls.UI.RadProgressBar();
            this.lblEstado = new Telerik.WinControls.UI.RadLabel();
            this.pnlTotales = new Telerik.WinControls.UI.RadPanel();
            this.lblTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            this.lblValorTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            this.btnFiltrar = new Telerik.WinControls.UI.RadButton();
            this.btnExportarExcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridWasteLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWasteLog.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiarFiltros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUltimosRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTotales)).BeginInit();
            this.pnlTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridWasteLog
            // 
            this.gridWasteLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWasteLog.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gridWasteLog.Location = new System.Drawing.Point(20, 192);
            // 
            // 
            // 
            this.gridWasteLog.MasterTemplate.AllowAddNewRow = false;
            this.gridWasteLog.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridWasteLog.MasterTemplate.EnableFiltering = true;
            this.gridWasteLog.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridWasteLog.Name = "gridWasteLog";
            this.gridWasteLog.ReadOnly = true;
            this.gridWasteLog.Size = new System.Drawing.Size(1571, 488);
            this.gridWasteLog.TabIndex = 5;
            this.gridWasteLog.ThemeName = "Fluent";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(285, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTE DE DESPERDICIO";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
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
            // btnUltimosRegistros
            // 
            this.btnUltimosRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnUltimosRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUltimosRegistros.ForeColor = System.Drawing.Color.White;
            this.btnUltimosRegistros.Location = new System.Drawing.Point(20, 140);
            this.btnUltimosRegistros.Name = "btnUltimosRegistros";
            this.btnUltimosRegistros.Size = new System.Drawing.Size(150, 35);
            this.btnUltimosRegistros.TabIndex = 13;
            this.btnUltimosRegistros.Text = "ÚLTIMOS 300";
            this.btnUltimosRegistros.Visible = false;
            this.btnUltimosRegistros.Click += new System.EventHandler(this.btnUltimosRegistros_Click);
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
            // pnlTotales
            // 
            this.pnlTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlTotales.Controls.Add(this.lblTotalRegistros);
            this.pnlTotales.Controls.Add(this.lblValorTotalRegistros);
            this.pnlTotales.Location = new System.Drawing.Point(1400, 139);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTotales.Size = new System.Drawing.Size(191, 46);
            this.pnlTotales.TabIndex = 8;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalRegistros.Location = new System.Drawing.Point(116, 10);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(65, 18);
            this.lblTotalRegistros.TabIndex = 1;
            this.lblTotalRegistros.Text = "REGISTROS";
            this.lblTotalRegistros.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblValorTotalRegistros
            // 
            this.lblValorTotalRegistros.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblValorTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblValorTotalRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblValorTotalRegistros.Location = new System.Drawing.Point(10, 10);
            this.lblValorTotalRegistros.Name = "lblValorTotalRegistros";
            this.lblValorTotalRegistros.Size = new System.Drawing.Size(20, 29);
            this.lblValorTotalRegistros.TabIndex = 0;
            this.lblValorTotalRegistros.Text = "0";
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
            // WasteLogReportForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1611, 730);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.btnUltimosRegistros);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.progressCarga);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.gridWasteLog);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "WasteLogReportForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Desperdicio";
            this.ThemeName = "Fluent";
            this.Load += new System.EventHandler(this.WasteLogReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridWasteLog.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWasteLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiarFiltros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUltimosRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTotales)).EndInit();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}