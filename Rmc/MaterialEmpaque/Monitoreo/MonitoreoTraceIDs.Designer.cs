namespace Rmc.MaterialEmpaque.Monitoreo
{
    partial class MonitoreoTraceIDs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            this.timerUi = new System.Windows.Forms.Timer(this.components);
            this.HeaderPanel = new Telerik.WinControls.UI.RadPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.MainPanel = new Telerik.WinControls.UI.RadPanel();
            this.TaskPanel = new Telerik.WinControls.UI.RadPanel();
            this.dataGridViewTareas = new Telerik.WinControls.UI.RadGridView();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.btnExportar = new Telerik.WinControls.UI.RadButton();
            this.btnFiltros = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.CompletadosPanel = new System.Windows.Forms.Panel();
            this.lblIndicadorTareasCompletadas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PendientesPanel = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTituloPre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdDpListEstados = new Telerik.WinControls.UI.RadDropDownList();
            this.btnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefrescar = new Telerik.WinControls.UI.RadButton();
            this.txtTraceIDs = new System.Windows.Forms.TextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskPanel)).BeginInit();
            this.TaskPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas.MasterTemplate)).BeginInit();
            this.dataGridViewTareas.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltros)).BeginInit();
            this.panel1.SuspendLayout();
            this.CompletadosPanel.SuspendLayout();
            this.PendientesPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdDpListEstados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // timerUi
            // 
            this.timerUi.Interval = 90000;
            this.timerUi.Tick += new System.EventHandler(this.TimerUi_Tick);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.HeaderPanel.Controls.Add(this.lblTitulo);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1892, 80);
            this.HeaderPanel.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1892, 80);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MONITOREO DE TRACEIDs";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.MainPanel.Controls.Add(this.TaskPanel);
            this.MainPanel.Controls.Add(this.HeaderPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1892, 785);
            this.MainPanel.TabIndex = 0;
            // 
            // TaskPanel
            // 
            this.TaskPanel.BackColor = System.Drawing.Color.White;
            this.TaskPanel.Controls.Add(this.dataGridViewTareas);
            this.TaskPanel.Controls.Add(this.FilterPanel);
            this.TaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskPanel.Location = new System.Drawing.Point(0, 80);
            this.TaskPanel.Name = "TaskPanel";
            this.TaskPanel.Size = new System.Drawing.Size(1892, 705);
            this.TaskPanel.TabIndex = 1;
            // 
            // dataGridViewTareas
            // 
            this.dataGridViewTareas.AutoScroll = true;
            this.dataGridViewTareas.BackColor = System.Drawing.Color.White;
            this.dataGridViewTareas.Controls.Add(this.flpCards);
            this.dataGridViewTareas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTareas.Location = new System.Drawing.Point(0, 192);
            // 
            // 
            // 
            this.dataGridViewTareas.MasterTemplate.AllowAddNewRow = false;
            this.dataGridViewTareas.MasterTemplate.AllowColumnReorder = false;
            this.dataGridViewTareas.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dataGridViewTareas.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dataGridViewTareas.Name = "dataGridViewTareas";
            this.dataGridViewTareas.ReadOnly = true;
            this.dataGridViewTareas.Size = new System.Drawing.Size(1892, 513);
            this.dataGridViewTareas.TabIndex = 4;
            this.dataGridViewTareas.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dataGridViewTareas_ViewCellFormatting);
            // 
            // flpCards
            // 
            this.flpCards.AutoScroll = true;
            this.flpCards.BackColor = System.Drawing.Color.Gainsboro;
            this.flpCards.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCards.Location = new System.Drawing.Point(1544, 0);
            this.flpCards.Name = "flpCards";
            this.flpCards.Padding = new System.Windows.Forms.Padding(15);
            this.flpCards.Size = new System.Drawing.Size(348, 513);
            this.flpCards.TabIndex = 6;
            this.flpCards.WrapContents = false;
            // 
            // FilterPanel
            // 
            this.FilterPanel.BackColor = System.Drawing.Color.White;
            this.FilterPanel.Controls.Add(this.btnExportar);
            this.FilterPanel.Controls.Add(this.btnFiltros);
            this.FilterPanel.Controls.Add(this.panel1);
            this.FilterPanel.Controls.Add(this.InfoPanel);
            this.FilterPanel.Controls.Add(this.label1);
            this.FilterPanel.Controls.Add(this.rdDpListEstados);
            this.FilterPanel.Controls.Add(this.btnLimpiar);
            this.FilterPanel.Controls.Add(this.lblFechaFin);
            this.FilterPanel.Controls.Add(this.dtpFechaFin);
            this.FilterPanel.Controls.Add(this.lblFechaInicio);
            this.FilterPanel.Controls.Add(this.dtpFechaInicio);
            this.FilterPanel.Controls.Add(this.label5);
            this.FilterPanel.Controls.Add(this.btnRefrescar);
            this.FilterPanel.Controls.Add(this.txtTraceIDs);
            this.FilterPanel.Controls.Add(this.radLabel2);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.FilterPanel.Size = new System.Drawing.Size(1892, 192);
            this.FilterPanel.TabIndex = 5;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.Image = global::Rmc.Properties.Resources.sheet;
            this.btnExportar.Location = new System.Drawing.Point(36, 143);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 30);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnFiltros
            // 
            this.btnFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltros.ForeColor = System.Drawing.Color.White;
            this.btnFiltros.Image = global::Rmc.Properties.Resources.planificacion1;
            this.btnFiltros.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFiltros.Location = new System.Drawing.Point(334, 32);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(182, 42);
            this.btnFiltros.TabIndex = 25;
            this.btnFiltros.Text = "Buscar por Fechas";
            this.btnFiltros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblDisponible);
            this.panel1.Controls.Add(this.CompletadosPanel);
            this.panel1.Controls.Add(this.PendientesPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(834, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 122);
            this.panel1.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label10.Location = new System.Drawing.Point(15, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 29);
            this.label10.TabIndex = 48;
            this.label10.Text = "Estados de TraceIDs:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Tomato;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(170, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 47;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label9.Location = new System.Drawing.Point(207, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 25);
            this.label9.TabIndex = 46;
            this.label9.Text = "Completados (M)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Goldenrod;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(170, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 45;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label8.Location = new System.Drawing.Point(207, 43);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 25);
            this.label8.TabIndex = 44;
            this.label8.Text = "Pendientes";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LimeGreen;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(41, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 43;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(78, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "Completados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(41, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 41;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblDisponible
            // 
            this.lblDisponible.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDisponible.Location = new System.Drawing.Point(78, 42);
            this.lblDisponible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(82, 25);
            this.lblDisponible.TabIndex = 40;
            this.lblDisponible.Text = "EnProceso";
            this.lblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompletadosPanel
            // 
            this.CompletadosPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CompletadosPanel.Controls.Add(this.lblIndicadorTareasCompletadas);
            this.CompletadosPanel.Controls.Add(this.label6);
            this.CompletadosPanel.Location = new System.Drawing.Point(352, 12);
            this.CompletadosPanel.Name = "CompletadosPanel";
            this.CompletadosPanel.Size = new System.Drawing.Size(185, 101);
            this.CompletadosPanel.TabIndex = 4;
            // 
            // lblIndicadorTareasCompletadas
            // 
            this.lblIndicadorTareasCompletadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIndicadorTareasCompletadas.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorTareasCompletadas.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorTareasCompletadas.Location = new System.Drawing.Point(0, 23);
            this.lblIndicadorTareasCompletadas.Name = "lblIndicadorTareasCompletadas";
            this.lblIndicadorTareasCompletadas.Size = new System.Drawing.Size(185, 78);
            this.lblIndicadorTareasCompletadas.TabIndex = 0;
            this.lblIndicadorTareasCompletadas.Text = "[-]";
            this.lblIndicadorTareasCompletadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "TraceIDs Completados";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PendientesPanel
            // 
            this.PendientesPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PendientesPanel.Controls.Add(this.lblResumen);
            this.PendientesPanel.Controls.Add(this.label7);
            this.PendientesPanel.Location = new System.Drawing.Point(543, 12);
            this.PendientesPanel.Name = "PendientesPanel";
            this.PendientesPanel.Size = new System.Drawing.Size(158, 101);
            this.PendientesPanel.TabIndex = 5;
            // 
            // lblResumen
            // 
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblResumen.ForeColor = System.Drawing.Color.Black;
            this.lblResumen.Location = new System.Drawing.Point(0, 23);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(158, 78);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "[-]";
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "TraceIDs Retrasados";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.InfoPanel.Controls.Add(this.label3);
            this.InfoPanel.Controls.Add(this.label2);
            this.InfoPanel.Controls.Add(this.lblTituloPre);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.InfoPanel.Location = new System.Drawing.Point(1544, 15);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(328, 122);
            this.InfoPanel.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Puedes liberarlos manualmente desde aquí.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Asignados hace más de 4h y aún no escaneados.";
            // 
            // lblTituloPre
            // 
            this.lblTituloPre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloPre.Image = global::Rmc.Properties.Resources.adv;
            this.lblTituloPre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloPre.Location = new System.Drawing.Point(20, 21);
            this.lblTituloPre.Name = "lblTituloPre";
            this.lblTituloPre.Size = new System.Drawing.Size(238, 20);
            this.lblTituloPre.TabIndex = 29;
            this.lblTituloPre.Text = "TraceIDs sin escaneo en Prekiteo";
            this.lblTituloPre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(583, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Estados:";
            // 
            // rdDpListEstados
            // 
            this.rdDpListEstados.AutoSize = false;
            this.rdDpListEstados.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "Completado";
            radListDataItem2.Text = "Completado (M)";
            radListDataItem3.Text = "Pendientes";
            radListDataItem4.Text = "EnProceso";
            this.rdDpListEstados.Items.Add(radListDataItem1);
            this.rdDpListEstados.Items.Add(radListDataItem2);
            this.rdDpListEstados.Items.Add(radListDataItem3);
            this.rdDpListEstados.Items.Add(radListDataItem4);
            this.rdDpListEstados.Location = new System.Drawing.Point(655, 99);
            this.rdDpListEstados.Name = "rdDpListEstados";
            this.rdDpListEstados.Size = new System.Drawing.Size(163, 29);
            this.rdDpListEstados.TabIndex = 27;
            this.rdDpListEstados.Text = "Completado";
            this.rdDpListEstados.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.rdDpListEstados_SelectedIndexChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = global::Rmc.Properties.Resources.lupa;
            this.btnLimpiar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLimpiar.Location = new System.Drawing.Point(526, 32);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(152, 41);
            this.btnLimpiar.TabIndex = 26;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.Location = new System.Drawing.Point(307, 104);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(70, 17);
            this.lblFechaFin.TabIndex = 23;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(388, 99);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(163, 25);
            this.dtpFechaFin.TabIndex = 24;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.Location = new System.Drawing.Point(18, 104);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(85, 17);
            this.lblFechaInicio.TabIndex = 21;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(130, 99);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(163, 25);
            this.dtpFechaInicio.TabIndex = 22;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1852, 40);
            this.label5.TabIndex = 0;
            this.label5.Text = "Historial de TraceIDs";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Image = global::Rmc.Properties.Resources.Sign_Refresh_icon;
            this.btnRefrescar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefrescar.Location = new System.Drawing.Point(689, 31);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(124, 41);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text = "Actualizar";
            this.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            // 
            // txtTraceIDs
            // 
            this.txtTraceIDs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTraceIDs.Location = new System.Drawing.Point(142, 32);
            this.txtTraceIDs.Name = "txtTraceIDs";
            this.txtTraceIDs.Size = new System.Drawing.Size(176, 29);
            this.txtTraceIDs.TabIndex = 2;
            this.txtTraceIDs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTraceIDs_KeyDown);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.radLabel2.Location = new System.Drawing.Point(21, 37);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(126, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Consultar TraceID:";
            // 
            // MonitoreoTraceIDs
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1892, 785);
            this.Controls.Add(this.MainPanel);
            this.Name = "MonitoreoTraceIDs";
            this.Text = "Monitoreo TraceIDs";
            this.Load += new System.EventHandler(this.MonitoreoTraceIDs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderPanel)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskPanel)).EndInit();
            this.TaskPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).EndInit();
            this.dataGridViewTareas.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFiltros)).EndInit();
            this.panel1.ResumeLayout(false);
            this.CompletadosPanel.ResumeLayout(false);
            this.PendientesPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdDpListEstados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerUi;
        private Telerik.WinControls.UI.RadPanel HeaderPanel;
        private System.Windows.Forms.Label lblTitulo;
        private Telerik.WinControls.UI.RadPanel TaskPanel;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton btnRefrescar;
        private System.Windows.Forms.TextBox txtTraceIDs;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.Panel CompletadosPanel;
        private System.Windows.Forms.Label lblIndicadorTareasCompletadas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PendientesPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblResumen;
        private Telerik.WinControls.UI.RadGridView dataGridViewTareas;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private Telerik.WinControls.UI.RadPanel MainPanel;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private Telerik.WinControls.UI.RadButton btnFiltros;
        private Telerik.WinControls.UI.RadButton btnLimpiar;
        private Telerik.WinControls.UI.RadDropDownList rdDpListEstados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label lblTituloPre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDisponible;
        private Telerik.WinControls.UI.RadButton btnExportar;
    }
}
