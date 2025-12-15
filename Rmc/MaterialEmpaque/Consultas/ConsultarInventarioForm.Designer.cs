using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque.Consultas
{
    partial class ConsultarInventarioForm
    {
        private System.ComponentModel.IContainer components = null;

        private RadLabel lblTitulo;
        private RadPanel pnlControles;
        private RadLabel lblEstadoSeleccion;
        private RadButton btnMesa;
        private RadButton btnEstante;
        private RadButton btnFinishing;
        private RadPanel pnlFiltros;
        private RadLabel lblFechaDesde;
        private RadDateTimePicker dtpFechaDesde;
        private RadLabel lblHoraDesde;
        private RadDateTimePicker dtpHoraDesde;
        private RadLabel lblFechaHasta;
        private RadDateTimePicker dtpFechaHasta;
        private RadLabel lblHoraHasta;
        private RadDateTimePicker dtpHoraHasta;
        private RadButton btnConsultar;
        private RadButton btnLimpiar;
        private RadGridView gridResultados;
        private RadProgressBar progressBar;
        private RadLabel lblEstado;
        private RadLabel lblResultados;
        private RadLabel lblUltimaActualizacion;
        private RadButton btnExportar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.pnlControles = new Telerik.WinControls.UI.RadPanel();
            this.lblEstadoSeleccion = new Telerik.WinControls.UI.RadLabel();
            this.btnMesa = new Telerik.WinControls.UI.RadButton();
            this.btnEstante = new Telerik.WinControls.UI.RadButton();
            this.btnFinishing = new Telerik.WinControls.UI.RadButton();
            this.pnlFiltros = new Telerik.WinControls.UI.RadPanel();
            this.btnExportar = new Telerik.WinControls.UI.RadButton();
            this.btnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.dtpHoraHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHoraHasta = new Telerik.WinControls.UI.RadLabel();
            this.dtpFechaHasta = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblFechaHasta = new Telerik.WinControls.UI.RadLabel();
            this.dtpHoraDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblHoraDesde = new Telerik.WinControls.UI.RadLabel();
            this.dtpFechaDesde = new Telerik.WinControls.UI.RadDateTimePicker();
            this.lblFechaDesde = new Telerik.WinControls.UI.RadLabel();
            this.gridResultados = new Telerik.WinControls.UI.RadGridView();
            this.progressBar = new Telerik.WinControls.UI.RadProgressBar();
            this.lblEstado = new Telerik.WinControls.UI.RadLabel();
            this.lblResultados = new Telerik.WinControls.UI.RadLabel();
            this.lblUltimaActualizacion = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControles)).BeginInit();
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstadoSeleccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEstante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinishing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUltimaActualizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(280, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CONSULTAR INVENTARIO";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.BackColor = System.Drawing.Color.White;
            this.pnlControles.Controls.Add(this.lblEstadoSeleccion);
            this.pnlControles.Controls.Add(this.btnMesa);
            this.pnlControles.Controls.Add(this.btnEstante);
            this.pnlControles.Controls.Add(this.btnFinishing);
            this.pnlControles.Location = new System.Drawing.Point(20, 60);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Padding = new System.Windows.Forms.Padding(15);
            this.pnlControles.Size = new System.Drawing.Size(1250, 80);
            this.pnlControles.TabIndex = 1;
            // 
            // lblEstadoSeleccion
            // 
            this.lblEstadoSeleccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoSeleccion.Location = new System.Drawing.Point(15, 25);
            this.lblEstadoSeleccion.Name = "lblEstadoSeleccion";
            this.lblEstadoSeleccion.Size = new System.Drawing.Size(147, 21);
            this.lblEstadoSeleccion.TabIndex = 0;
            this.lblEstadoSeleccion.Text = "SELECCIONE ESTADO:";
            // 
            // btnMesa
            // 
            this.btnMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMesa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMesa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnMesa.Location = new System.Drawing.Point(180, 20);
            this.btnMesa.Name = "btnMesa";
            this.btnMesa.Size = new System.Drawing.Size(120, 35);
            this.btnMesa.TabIndex = 1;
            this.btnMesa.Text = "MESA";
            this.btnMesa.ThemeName = "Fluent";
            // 
            // btnEstante
            // 
            this.btnEstante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnEstante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEstante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnEstante.Location = new System.Drawing.Point(320, 20);
            this.btnEstante.Name = "btnEstante";
            this.btnEstante.Size = new System.Drawing.Size(120, 35);
            this.btnEstante.TabIndex = 2;
            this.btnEstante.Text = "ESTANTE";
            this.btnEstante.ThemeName = "Fluent";
            // 
            // btnFinishing
            // 
            this.btnFinishing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnFinishing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFinishing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnFinishing.Location = new System.Drawing.Point(460, 20);
            this.btnFinishing.Name = "btnFinishing";
            this.btnFinishing.Size = new System.Drawing.Size(120, 35);
            this.btnFinishing.TabIndex = 3;
            this.btnFinishing.Text = "FINISHING";
            this.btnFinishing.ThemeName = "Fluent";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFiltros.Controls.Add(this.btnExportar);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.btnConsultar);
            this.pnlFiltros.Controls.Add(this.dtpHoraHasta);
            this.pnlFiltros.Controls.Add(this.lblHoraHasta);
            this.pnlFiltros.Controls.Add(this.dtpFechaHasta);
            this.pnlFiltros.Controls.Add(this.lblFechaHasta);
            this.pnlFiltros.Controls.Add(this.dtpHoraDesde);
            this.pnlFiltros.Controls.Add(this.lblHoraDesde);
            this.pnlFiltros.Controls.Add(this.dtpFechaDesde);
            this.pnlFiltros.Controls.Add(this.lblFechaDesde);
            this.pnlFiltros.Location = new System.Drawing.Point(20, 150);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(15);
            this.pnlFiltros.Size = new System.Drawing.Size(1250, 90);
            this.pnlFiltros.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::Rmc.Properties.Resources.excefile;
            this.btnExportar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportar.Location = new System.Drawing.Point(1070, 25);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(162, 35);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "EXPORTAR EXCEL";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(900, 25);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 35);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "LIMPIAR FILTROS";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnConsultar.Enabled = false;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Image = global::Rmc.Properties.Resources.lupa;
            this.btnConsultar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConsultar.Location = new System.Drawing.Point(730, 25);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(153, 35);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraHasta.Location = new System.Drawing.Point(590, 30);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.Size = new System.Drawing.Size(106, 24);
            this.dtpHoraHasta.TabIndex = 7;
            this.dtpHoraHasta.TabStop = false;
            this.dtpHoraHasta.Text = "11:59:00 PM";
            this.dtpHoraHasta.Value = new System.DateTime(2025, 11, 7, 23, 59, 0, 0);
            // 
            // lblHoraHasta
            // 
            this.lblHoraHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraHasta.Location = new System.Drawing.Point(540, 33);
            this.lblHoraHasta.Name = "lblHoraHasta";
            this.lblHoraHasta.Size = new System.Drawing.Size(45, 19);
            this.lblHoraHasta.TabIndex = 6;
            this.lblHoraHasta.Text = "HORA:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(410, 30);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(120, 24);
            this.dtpFechaHasta.TabIndex = 5;
            this.dtpFechaHasta.TabStop = false;
            this.dtpFechaHasta.Text = "11/7/2025";
            this.dtpFechaHasta.Value = new System.DateTime(2025, 11, 7, 16, 25, 31, 987);
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaHasta.Location = new System.Drawing.Point(350, 33);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(51, 19);
            this.lblFechaHasta.TabIndex = 4;
            this.lblFechaHasta.Text = "HASTA:";
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraDesde.Location = new System.Drawing.Point(220, 30);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.Size = new System.Drawing.Size(106, 24);
            this.dtpHoraDesde.TabIndex = 3;
            this.dtpHoraDesde.TabStop = false;
            this.dtpHoraDesde.Text = "12:00:00 AM";
            this.dtpHoraDesde.Value = new System.DateTime(2025, 11, 7, 0, 0, 0, 0);
            // 
            // lblHoraDesde
            // 
            this.lblHoraDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoraDesde.Location = new System.Drawing.Point(170, 33);
            this.lblHoraDesde.Name = "lblHoraDesde";
            this.lblHoraDesde.Size = new System.Drawing.Size(45, 19);
            this.lblHoraDesde.TabIndex = 2;
            this.lblHoraDesde.Text = "HORA:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(40, 30);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(120, 24);
            this.dtpFechaDesde.TabIndex = 1;
            this.dtpFechaDesde.TabStop = false;
            this.dtpFechaDesde.Text = "11/7/2025";
            this.dtpFechaDesde.Value = new System.DateTime(2025, 11, 7, 16, 25, 31, 966);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaDesde.Location = new System.Drawing.Point(15, 33);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(26, 19);
            this.lblFechaDesde.TabIndex = 0;
            this.lblFechaDesde.Text = "DE:";
            // 
            // gridResultados
            // 
            this.gridResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridResultados.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gridResultados.Location = new System.Drawing.Point(20, 280);
            // 
            // 
            // 
            this.gridResultados.MasterTemplate.AllowAddNewRow = false;
            this.gridResultados.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridResultados.MasterTemplate.EnableFiltering = true;
            this.gridResultados.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.Size = new System.Drawing.Size(1250, 350);
            this.gridResultados.TabIndex = 3;
            this.gridResultados.ThemeName = "Fluent";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(20, 640);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1250, 8);
            this.progressBar.TabIndex = 4;
            this.progressBar.ThemeName = "Fluent";
            this.progressBar.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblEstado.Location = new System.Drawing.Point(20, 650);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(61, 18);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Cargando...";
            this.lblEstado.Visible = false;
            // 
            // lblResultados
            // 
            this.lblResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblResultados.Location = new System.Drawing.Point(20, 680);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(152, 19);
            this.lblResultados.TabIndex = 6;
            this.lblResultados.Text = "0 productos encontrados";
            this.lblResultados.Visible = false;
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUltimaActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(1152, 680);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(118, 18);
            this.lblUltimaActualizacion.TabIndex = 7;
            this.lblUltimaActualizacion.Text = "Última consulta: --:--:--";
            // 
            // ConsultarInventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1290, 730);
            this.Controls.Add(this.lblUltimaActualizacion);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gridResultados);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.lblTitulo);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ConsultarInventarioForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Inventario por Estado";
            this.ThemeName = "Fluent";
            this.Load += new System.EventHandler(this.ConsultarInventarioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControles)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstadoSeleccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEstante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinishing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHoraDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoraDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUltimaActualizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}