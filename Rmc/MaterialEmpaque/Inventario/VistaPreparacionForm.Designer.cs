using System.Windows.Forms;

namespace Rmc.MaterialEmpaque.Inventario
{
    partial class VistaPreparacionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Button btnRefresh;
        private Label lblTitulo;
        private Panel panelKPI;
        private Panel panelCards;
        private FlowLayoutPanel flowPanelCards;
        private ProgressBar progressBar;
        private Timer refreshTimer;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelKPI = new System.Windows.Forms.Panel();
            this.kpiGaugeTotal = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lblTotal = new System.Windows.Forms.Label();
            this.radialGaugeArc5 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc6 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeSingleLabel3 = new Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel();
            this.kpiGaugeProceso = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lblCompletados = new System.Windows.Forms.Label();
            this.radialGaugeArc3 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc4 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeSingleLabel2 = new Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel();
            this.kpiGaugePendientes = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.radialGaugeArc1 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc2 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeSingleLabel1 = new Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel();
            this.panelCards = new System.Windows.Forms.Panel();
            this.flowPanelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            this.panelKPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpiGaugeTotal)).BeginInit();
            this.kpiGaugeTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpiGaugeProceso)).BeginInit();
            this.kpiGaugeProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpiGaugePendientes)).BeginInit();
            this.kpiGaugePendientes.SuspendLayout();
            this.panelCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.ForeColor = System.Drawing.Color.White;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1622, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Image = global::Rmc.Properties.Resources.Sign_Refresh_icon;
            this.btnRefresh.Location = new System.Drawing.Point(13, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 39);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Actualizar";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1622, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard de Preparación";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelKPI
            // 
            this.panelKPI.BackColor = System.Drawing.Color.Gainsboro;
            this.panelKPI.Controls.Add(this.kpiGaugeTotal);
            this.panelKPI.Controls.Add(this.kpiGaugeProceso);
            this.panelKPI.Controls.Add(this.kpiGaugePendientes);
            this.panelKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPI.Location = new System.Drawing.Point(0, 60);
            this.panelKPI.Name = "panelKPI";
            this.panelKPI.Padding = new System.Windows.Forms.Padding(10);
            this.panelKPI.Size = new System.Drawing.Size(1622, 175);
            this.panelKPI.TabIndex = 1;
            // 
            // kpiGaugeTotal
            // 
            this.kpiGaugeTotal.BackColor = System.Drawing.Color.White;
            this.kpiGaugeTotal.CausesValidation = false;
            this.kpiGaugeTotal.Controls.Add(this.lblTotal);
            this.kpiGaugeTotal.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc5,
            this.radialGaugeArc6,
            this.radialGaugeSingleLabel3});
            this.kpiGaugeTotal.Location = new System.Drawing.Point(13, 6);
            this.kpiGaugeTotal.Name = "kpiGaugeTotal";
            this.kpiGaugeTotal.RangeEnd = 30D;
            this.kpiGaugeTotal.Size = new System.Drawing.Size(269, 203);
            this.kpiGaugeTotal.StartAngle = 180D;
            this.kpiGaugeTotal.SweepAngle = 180D;
            this.kpiGaugeTotal.TabIndex = 8;
            this.kpiGaugeTotal.Text = "radRadialGauge1";
            this.kpiGaugeTotal.Value = 9F;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(45, 112);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(180, 30);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc5
            // 
            this.radialGaugeArc5.BackColor = System.Drawing.Color.SteelBlue;
            this.radialGaugeArc5.BackColor2 = System.Drawing.Color.SteelBlue;
            this.radialGaugeArc5.BindEndRange = true;
            this.radialGaugeArc5.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc5.Name = "radialGaugeArc5";
            this.radialGaugeArc5.RangeEnd = 9D;
            this.radialGaugeArc5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc5.UseCompatibleTextRendering = false;
            this.radialGaugeArc5.Width = 40D;
            // 
            // radialGaugeArc6
            // 
            this.radialGaugeArc6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc6.BindStartRange = true;
            this.radialGaugeArc6.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc6.Name = "radialGaugeArc6";
            this.radialGaugeArc6.RangeEnd = 100D;
            this.radialGaugeArc6.RangeStart = 9D;
            this.radialGaugeArc6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc6.UseCompatibleTextRendering = false;
            this.radialGaugeArc6.Width = 40D;
            // 
            // radialGaugeSingleLabel3
            // 
            this.radialGaugeSingleLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.radialGaugeSingleLabel3.BindValue = true;
            this.radialGaugeSingleLabel3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeSingleLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radialGaugeSingleLabel3.ForeColor = System.Drawing.Color.Black;
            this.radialGaugeSingleLabel3.LabelFontSize = 10F;
            this.radialGaugeSingleLabel3.LabelText = "Text";
            this.radialGaugeSingleLabel3.LocationPercentage = new System.Drawing.SizeF(0F, -0.1F);
            this.radialGaugeSingleLabel3.Name = "radialGaugeSingleLabel3";
            this.radialGaugeSingleLabel3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeSingleLabel3.UseCompatibleTextRendering = false;
            // 
            // kpiGaugeProceso
            // 
            this.kpiGaugeProceso.BackColor = System.Drawing.Color.White;
            this.kpiGaugeProceso.CausesValidation = false;
            this.kpiGaugeProceso.Controls.Add(this.lblCompletados);
            this.kpiGaugeProceso.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc3,
            this.radialGaugeArc4,
            this.radialGaugeSingleLabel2});
            this.kpiGaugeProceso.Location = new System.Drawing.Point(288, 6);
            this.kpiGaugeProceso.Name = "kpiGaugeProceso";
            this.kpiGaugeProceso.RangeEnd = 20D;
            this.kpiGaugeProceso.Size = new System.Drawing.Size(269, 203);
            this.kpiGaugeProceso.StartAngle = 180D;
            this.kpiGaugeProceso.SweepAngle = 180D;
            this.kpiGaugeProceso.TabIndex = 7;
            this.kpiGaugeProceso.Text = "radRadialGauge1";
            this.kpiGaugeProceso.Value = 5F;
            // 
            // lblCompletados
            // 
            this.lblCompletados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompletados.ForeColor = System.Drawing.Color.Black;
            this.lblCompletados.Location = new System.Drawing.Point(25, 112);
            this.lblCompletados.Name = "lblCompletados";
            this.lblCompletados.Size = new System.Drawing.Size(227, 30);
            this.lblCompletados.TabIndex = 0;
            this.lblCompletados.Text = "EN PROCESO DE PREPARACION";
            this.lblCompletados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc3
            // 
            this.radialGaugeArc3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(36)))));
            this.radialGaugeArc3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(87)))), ((int)(((byte)(28)))));
            this.radialGaugeArc3.BindEndRange = true;
            this.radialGaugeArc3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc3.Name = "radialGaugeArc3";
            this.radialGaugeArc3.RangeEnd = 5D;
            this.radialGaugeArc3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc3.UseCompatibleTextRendering = false;
            this.radialGaugeArc3.Width = 40D;
            // 
            // radialGaugeArc4
            // 
            this.radialGaugeArc4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc4.BindStartRange = true;
            this.radialGaugeArc4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc4.Name = "radialGaugeArc4";
            this.radialGaugeArc4.RangeEnd = 100D;
            this.radialGaugeArc4.RangeStart = 5D;
            this.radialGaugeArc4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeArc4.UseCompatibleTextRendering = false;
            this.radialGaugeArc4.Width = 40D;
            // 
            // radialGaugeSingleLabel2
            // 
            this.radialGaugeSingleLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.radialGaugeSingleLabel2.BindValue = true;
            this.radialGaugeSingleLabel2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeSingleLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radialGaugeSingleLabel2.ForeColor = System.Drawing.Color.Black;
            this.radialGaugeSingleLabel2.LabelFontSize = 10F;
            this.radialGaugeSingleLabel2.LabelText = "Text";
            this.radialGaugeSingleLabel2.LocationPercentage = new System.Drawing.SizeF(0F, -0.1F);
            this.radialGaugeSingleLabel2.Name = "radialGaugeSingleLabel2";
            this.radialGaugeSingleLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radialGaugeSingleLabel2.UseCompatibleTextRendering = false;
            // 
            // kpiGaugePendientes
            // 
            this.kpiGaugePendientes.BackColor = System.Drawing.Color.White;
            this.kpiGaugePendientes.CausesValidation = false;
            this.kpiGaugePendientes.Controls.Add(this.lblPendientes);
            this.kpiGaugePendientes.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc1,
            this.radialGaugeArc2,
            this.radialGaugeSingleLabel1});
            this.kpiGaugePendientes.Location = new System.Drawing.Point(563, 6);
            this.kpiGaugePendientes.Name = "kpiGaugePendientes";
            this.kpiGaugePendientes.RangeEnd = 20D;
            this.kpiGaugePendientes.Size = new System.Drawing.Size(269, 203);
            this.kpiGaugePendientes.StartAngle = 180D;
            this.kpiGaugePendientes.SweepAngle = 180D;
            this.kpiGaugePendientes.TabIndex = 6;
            this.kpiGaugePendientes.Text = "radRadialGauge1";
            this.kpiGaugePendientes.Value = 10F;
            // 
            // lblPendientes
            // 
            this.lblPendientes.BackColor = System.Drawing.Color.Transparent;
            this.lblPendientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPendientes.ForeColor = System.Drawing.Color.Black;
            this.lblPendientes.Location = new System.Drawing.Point(3, 115);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(269, 30);
            this.lblPendientes.TabIndex = 0;
            this.lblPendientes.Text = "PENDIENTES DE PREPARACIÓN";
            this.lblPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc1
            // 
            this.radialGaugeArc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(152)))), ((int)(((byte)(38)))));
            this.radialGaugeArc1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(152)))), ((int)(((byte)(38)))));
            this.radialGaugeArc1.BindEndRange = true;
            this.radialGaugeArc1.Name = "radialGaugeArc1";
            this.radialGaugeArc1.RangeEnd = 10D;
            this.radialGaugeArc1.Width = 40D;
            // 
            // radialGaugeArc2
            // 
            this.radialGaugeArc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.radialGaugeArc2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.radialGaugeArc2.BindStartRange = true;
            this.radialGaugeArc2.Name = "radialGaugeArc2";
            this.radialGaugeArc2.RangeEnd = 100D;
            this.radialGaugeArc2.RangeStart = 10D;
            this.radialGaugeArc2.Width = 40D;
            // 
            // radialGaugeSingleLabel1
            // 
            this.radialGaugeSingleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.radialGaugeSingleLabel1.BindValue = true;
            this.radialGaugeSingleLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radialGaugeSingleLabel1.ForeColor = System.Drawing.Color.Black;
            this.radialGaugeSingleLabel1.LabelFontSize = 10F;
            this.radialGaugeSingleLabel1.LabelText = "Text";
            this.radialGaugeSingleLabel1.LocationPercentage = new System.Drawing.SizeF(0F, -0.1F);
            this.radialGaugeSingleLabel1.Name = "radialGaugeSingleLabel1";
            // 
            // panelCards
            // 
            this.panelCards.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCards.Controls.Add(this.flowPanelCards);
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCards.Location = new System.Drawing.Point(0, 235);
            this.panelCards.Name = "panelCards";
            this.panelCards.Padding = new System.Windows.Forms.Padding(10);
            this.panelCards.Size = new System.Drawing.Size(1622, 428);
            this.panelCards.TabIndex = 2;
            // 
            // flowPanelCards
            // 
            this.flowPanelCards.AutoScroll = true;
            this.flowPanelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelCards.Location = new System.Drawing.Point(10, 10);
            this.flowPanelCards.Name = "flowPanelCards";
            this.flowPanelCards.Size = new System.Drawing.Size(1602, 408);
            this.flowPanelCards.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 663);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1622, 20);
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 300000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // VistaPreparacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1622, 683);
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panelKPI);
            this.Controls.Add(this.panelHeader);
            this.Name = "VistaPreparacionForm";
            this.Text = "Dashboard de Preparación";
            this.panelHeader.ResumeLayout(false);
            this.panelKPI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpiGaugeTotal)).EndInit();
            this.kpiGaugeTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpiGaugeProceso)).EndInit();
            this.kpiGaugeProceso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpiGaugePendientes)).EndInit();
            this.kpiGaugePendientes.ResumeLayout(false);
            this.panelCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Gauges.RadRadialGauge kpiGaugePendientes;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc2;
        private Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel radialGaugeSingleLabel1;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge kpiGaugeProceso;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc3;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc4;
        private Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel radialGaugeSingleLabel2;
        private Telerik.WinControls.UI.Gauges.RadRadialGauge kpiGaugeTotal;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc5;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc6;
        private Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel radialGaugeSingleLabel3;
        private Label lblTotal;
        private Label lblCompletados;
        private Label lblPendientes;
    }
}