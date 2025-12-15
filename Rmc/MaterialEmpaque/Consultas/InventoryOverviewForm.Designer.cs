namespace Rmc.MaterialEmpaque.Consultas
{
    partial class InventoryOverviewForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridInventario = new Telerik.WinControls.UI.RadGridView();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.pnlBotones = new Telerik.WinControls.UI.RadPanel();
            this.btnTodos = new Telerik.WinControls.UI.RadButton();
            this.btnPreparacion = new Telerik.WinControls.UI.RadButton();
            this.btnPrinthub = new Telerik.WinControls.UI.RadButton();
            this.btnVentana = new Telerik.WinControls.UI.RadButton();
            this.btnSobrantes = new Telerik.WinControls.UI.RadButton();
            this.btnEnMesa = new Telerik.WinControls.UI.RadButton();
            this.btnEnEstante = new Telerik.WinControls.UI.RadButton();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.btnExportarExcel = new Telerik.WinControls.UI.RadButton();
            this.progressCarga = new Telerik.WinControls.UI.RadProgressBar();
            this.lblEstado = new Telerik.WinControls.UI.RadLabel();
            this.pnlTotales = new Telerik.WinControls.UI.RadPanel();
            this.lblTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            this.lblValorTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBotones)).BeginInit();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreparacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrinthub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVentana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSobrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnEstante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTotales)).BeginInit();
            this.pnlTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInventario
            // 
            this.gridInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInventario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gridInventario.Location = new System.Drawing.Point(20, 192);
            // 
            // 
            // 
            this.gridInventario.MasterTemplate.AllowAddNewRow = false;
            this.gridInventario.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gridInventario.MasterTemplate.EnableFiltering = true;
            this.gridInventario.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridInventario.Name = "gridInventario";
            this.gridInventario.Size = new System.Drawing.Size(1571, 488);
            this.gridInventario.TabIndex = 5;
            this.gridInventario.ThemeName = "Fluent";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(247, 33);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "INVENTARIO GENERAL";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.btnTodos);
            this.pnlBotones.Controls.Add(this.btnPreparacion);
            this.pnlBotones.Controls.Add(this.btnPrinthub);
            this.pnlBotones.Controls.Add(this.btnVentana);
            this.pnlBotones.Controls.Add(this.btnSobrantes);
            this.pnlBotones.Controls.Add(this.btnEnMesa);
            this.pnlBotones.Controls.Add(this.btnEnEstante);
            this.pnlBotones.Controls.Add(this.btnActualizar);
            this.pnlBotones.Controls.Add(this.btnExportarExcel);
            this.pnlBotones.Location = new System.Drawing.Point(20, 60);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBotones.Size = new System.Drawing.Size(1571, 70);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnTodos
            // 
            this.btnTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTodos.ForeColor = System.Drawing.Color.White;
            this.btnTodos.Location = new System.Drawing.Point(20, 15);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(120, 35);
            this.btnTodos.TabIndex = 0;
            this.btnTodos.Text = "TODOS";
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnPreparacion
            // 
            this.btnPreparacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPreparacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnPreparacion.Location = new System.Drawing.Point(150, 15);
            this.btnPreparacion.Name = "btnPreparacion";
            this.btnPreparacion.Size = new System.Drawing.Size(120, 35);
            this.btnPreparacion.TabIndex = 1;
            this.btnPreparacion.Text = "PREPARACIÓN";
            this.btnPreparacion.Click += new System.EventHandler(this.btnPreparacion_Click);
            // 
            // btnPrinthub
            // 
            this.btnPrinthub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrinthub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnPrinthub.Location = new System.Drawing.Point(280, 15);
            this.btnPrinthub.Name = "btnPrinthub";
            this.btnPrinthub.Size = new System.Drawing.Size(120, 35);
            this.btnPrinthub.TabIndex = 2;
            this.btnPrinthub.Text = "PRINTHUB";
            this.btnPrinthub.Click += new System.EventHandler(this.btnPrinthub_Click);
            // 
            // btnVentana
            // 
            this.btnVentana.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVentana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnVentana.Location = new System.Drawing.Point(410, 15);
            this.btnVentana.Name = "btnVentana";
            this.btnVentana.Size = new System.Drawing.Size(120, 35);
            this.btnVentana.TabIndex = 3;
            this.btnVentana.Text = "VENTANA";
            this.btnVentana.Click += new System.EventHandler(this.btnVentana_Click);
            // 
            // btnSobrantes
            // 
            this.btnSobrantes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSobrantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnSobrantes.Location = new System.Drawing.Point(540, 15);
            this.btnSobrantes.Name = "btnSobrantes";
            this.btnSobrantes.Size = new System.Drawing.Size(120, 35);
            this.btnSobrantes.TabIndex = 4;
            this.btnSobrantes.Text = "SOBRANTES";
            this.btnSobrantes.Click += new System.EventHandler(this.btnSobrantes_Click);
            // 
            // btnEnMesa
            // 
            this.btnEnMesa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEnMesa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnEnMesa.Location = new System.Drawing.Point(670, 15);
            this.btnEnMesa.Name = "btnEnMesa";
            this.btnEnMesa.Size = new System.Drawing.Size(120, 35);
            this.btnEnMesa.TabIndex = 5;
            this.btnEnMesa.Text = "EN MESA";
            this.btnEnMesa.Click += new System.EventHandler(this.btnEnMesa_Click);
            // 
            // btnEnEstante
            // 
            this.btnEnEstante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEnEstante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnEnEstante.Location = new System.Drawing.Point(800, 15);
            this.btnEnEstante.Name = "btnEnEstante";
            this.btnEnEstante.Size = new System.Drawing.Size(120, 35);
            this.btnEnEstante.TabIndex = 6;
            this.btnEnEstante.Text = "EN ESTANTE";
            this.btnEnEstante.Click += new System.EventHandler(this.btnEnEstante_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(1072, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 35);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Image = global::Rmc.Properties.Resources.excefile;
            this.btnExportarExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExportarExcel.Location = new System.Drawing.Point(1200, 15);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(156, 35);
            this.btnExportarExcel.TabIndex = 8;
            this.btnExportarExcel.Text = "EXPORTAR EXCEL";
            this.btnExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
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
            this.pnlTotales.Location = new System.Drawing.Point(1400, 140);
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
            // InventoryOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1611, 730);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.progressCarga);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.gridInventario);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "InventoryOverviewForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario General";
            this.ThemeName = "Fluent";
            this.Load += new System.EventHandler(this.InventoryOverviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBotones)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnTodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreparacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrinthub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVentana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSobrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnEstante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTotales)).EndInit();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridInventario;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadPanel pnlBotones;
        private Telerik.WinControls.UI.RadButton btnTodos;
        private Telerik.WinControls.UI.RadButton btnPreparacion;
        private Telerik.WinControls.UI.RadButton btnPrinthub;
        private Telerik.WinControls.UI.RadButton btnVentana;
        private Telerik.WinControls.UI.RadButton btnSobrantes;
        private Telerik.WinControls.UI.RadButton btnEnMesa;
        private Telerik.WinControls.UI.RadButton btnEnEstante;
        private Telerik.WinControls.UI.RadButton btnActualizar;
        private Telerik.WinControls.UI.RadButton btnExportarExcel;
        private Telerik.WinControls.UI.RadProgressBar progressCarga;
        private Telerik.WinControls.UI.RadLabel lblEstado;
        private Telerik.WinControls.UI.RadPanel pnlTotales;
        private Telerik.WinControls.UI.RadLabel lblTotalRegistros;
        private Telerik.WinControls.UI.RadLabel lblValorTotalRegistros;
    }
}