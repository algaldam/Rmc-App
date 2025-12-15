namespace Rmc.MaterialEmpaque.Impresion
{
    partial class SolicitudSobreconsumos
    {
        private System.ComponentModel.IContainer components = null;
        private Telerik.WinControls.UI.RadGridView gridSolicitudes;
        private Telerik.WinControls.UI.RadButton btnActualizar;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadPanel panelHeader;
        private Telerik.WinControls.UI.RadLabel lblContador;
        private Telerik.WinControls.UI.RadLabel lblEstado;
        private Telerik.WinControls.UI.RadPanel panelFiltros;
        private System.Windows.Forms.Timer timerAutoRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                timerAutoRefresh?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gridSolicitudes = new Telerik.WinControls.UI.RadGridView();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.panelHeader = new Telerik.WinControls.UI.RadPanel();
            this.lblEstado = new Telerik.WinControls.UI.RadLabel();
            this.lblContador = new Telerik.WinControls.UI.RadLabel();
            this.panelFiltros = new Telerik.WinControls.UI.RadPanel();
            this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitudes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitudes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFiltros)).BeginInit();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSolicitudes
            // 
            this.gridSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSolicitudes.Location = new System.Drawing.Point(15, 150);
            // 
            // 
            // 
            this.gridSolicitudes.MasterTemplate.AllowAddNewRow = false;
            this.gridSolicitudes.MasterTemplate.AllowDeleteRow = false;
            this.gridSolicitudes.MasterTemplate.AllowEditRow = false;
            this.gridSolicitudes.MasterTemplate.EnableAlternatingRowColor = true;
            this.gridSolicitudes.MasterTemplate.EnableFiltering = true;
            this.gridSolicitudes.MasterTemplate.EnableGrouping = false;
            this.gridSolicitudes.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridSolicitudes.Name = "gridSolicitudes";
            this.gridSolicitudes.Size = new System.Drawing.Size(1154, 436);
            this.gridSolicitudes.TabIndex = 0;
            this.gridSolicitudes.ThemeName = "Fluent";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = global::Rmc.Properties.Resources.Sign_Refresh_icon;
            this.btnActualizar.Location = new System.Drawing.Point(1026, 0);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(5);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Size = new System.Drawing.Size(128, 50);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.ThemeName = "Fluent";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1154, 70);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Sobreconsumos Pendientes de Impresión";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.ThemeName = "Fluent";
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Location = new System.Drawing.Point(15, 15);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1154, 70);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.ThemeName = "Fluent";
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEstado.ForeColor = System.Drawing.Color.Gray;
            this.lblEstado.Location = new System.Drawing.Point(18, 19);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(133, 19);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Última actualización: --";
            this.lblEstado.ThemeName = "Fluent";
            // 
            // lblContador
            // 
            this.lblContador.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblContador.Location = new System.Drawing.Point(18, 15);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(95, 23);
            this.lblContador.TabIndex = 3;
            this.lblContador.Text = "0 solicitudes";
            this.lblContador.ThemeName = "Fluent";
            // 
            // panelFiltros
            // 
            this.panelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelFiltros.Controls.Add(this.btnActualizar);
            this.panelFiltros.Controls.Add(this.lblContador);
            this.panelFiltros.Location = new System.Drawing.Point(15, 95);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1154, 50);
            this.panelFiltros.TabIndex = 4;
            this.panelFiltros.ThemeName = "Fluent";
            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Interval = 30000;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.radPanel1.Controls.Add(this.lblEstado);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 592);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1184, 50);
            this.radPanel1.TabIndex = 5;
            this.radPanel1.ThemeName = "Fluent";
            // 
            // SolicitudSobreconsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1184, 642);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.gridSolicitudes);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "SolicitudSobreconsumos";
            this.Text = "Impresion de Sobreconsumos";
            this.Load += new System.EventHandler(this.SolicitudSobreconsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitudes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitudes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFiltros)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}