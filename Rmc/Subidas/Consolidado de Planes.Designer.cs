namespace Rmc.Subidas
{
    partial class Consolidado_de_Planes
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.Windows.Documents.Spreadsheet.Model.Workbook workbook1 = new Telerik.Windows.Documents.Spreadsheet.Model.Workbook();
            Telerik.Windows.Documents.Model.DocumentInfo documentInfo1 = new Telerik.Windows.Documents.Model.DocumentInfo();
            this.GridConsolidado = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.BrowseConsolidado = new Telerik.WinControls.UI.RadBrowseEditor();
            this.ProcesarBOM = new Telerik.WinControls.UI.RadButton();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblNumRegistrosOrden = new System.Windows.Forms.Label();
            this.lblRegistroOrden = new System.Windows.Forms.Label();
            this.radSpreadsheet1 = new Telerik.WinControls.UI.RadSpreadsheet();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.panelControles = new System.Windows.Forms.Panel();
            this.panelEstado = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.radWaitingBar2 = new Telerik.WinControls.UI.RadWaitingBar();
            this.waitingBarIndicatorElement1 = new Telerik.WinControls.UI.WaitingBarIndicatorElement();
            this.waitingBarIndicatorElement2 = new Telerik.WinControls.UI.WaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsolidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsolidado.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowseConsolidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcesarBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).BeginInit();
            this.panelPrincipal.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelControles.SuspendLayout();
            this.panelEstado.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GridConsolidado
            // 
            this.GridConsolidado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridConsolidado.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridConsolidado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridConsolidado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GridConsolidado.ForeColor = System.Drawing.Color.Black;
            this.GridConsolidado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridConsolidado.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.GridConsolidado.MasterTemplate.AllowAddNewRow = false;
            this.GridConsolidado.MasterTemplate.AllowEditRow = false;
            this.GridConsolidado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.GridConsolidado.MasterTemplate.BottomPinnedRowsMode = Telerik.WinControls.UI.GridViewBottomPinnedRowsMode.Fixed;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "sku";
            gridViewTextBoxColumn1.HeaderText = "SKU";
            gridViewTextBoxColumn1.Name = "sku";
            gridViewTextBoxColumn1.Width = 76;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "socktype";
            gridViewTextBoxColumn2.HeaderText = "Tipo Calcetín";
            gridViewTextBoxColumn2.Name = "socktype";
            gridViewTextBoxColumn2.Width = 76;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "dc";
            gridViewTextBoxColumn3.HeaderText = "DC";
            gridViewTextBoxColumn3.Name = "dc";
            gridViewTextBoxColumn3.Width = 61;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Docenas";
            gridViewTextBoxColumn4.HeaderText = "Docenas";
            gridViewTextBoxColumn4.Name = "Docenas";
            gridViewTextBoxColumn5.FieldName = "QR";
            gridViewTextBoxColumn5.HeaderText = "QR";
            gridViewTextBoxColumn5.Name = "QR";
            gridViewTextBoxColumn5.Width = 100;
            this.GridConsolidado.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.GridConsolidado.MasterTemplate.EnableFiltering = true;
            this.GridConsolidado.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.GridConsolidado.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridConsolidado.Name = "GridConsolidado";
            this.GridConsolidado.Padding = new System.Windows.Forms.Padding(2);
            this.GridConsolidado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridConsolidado.Size = new System.Drawing.Size(414, 391);
            this.GridConsolidado.TabIndex = 22;
            this.GridConsolidado.ThemeName = "Fluent";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.BrowseConsolidado);
            this.radGroupBox1.Controls.Add(this.ProcesarBOM);
            this.radGroupBox1.Controls.Add(this.radWaitingBar1);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.radGroupBox1.HeaderText = "CARGAR CONSOLIDADO DE PLANES";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            this.radGroupBox1.Size = new System.Drawing.Size(1184, 100);
            this.radGroupBox1.TabIndex = 28;
            this.radGroupBox1.Text = "CARGAR CONSOLIDADO DE PLANES";
            this.radGroupBox1.ThemeName = "Fluent";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel1.Location = new System.Drawing.Point(15, 35);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(175, 19);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Archivo Consolidado de Planes";
            this.radLabel1.ThemeName = "Fluent";
            // 
            // BrowseConsolidado
            // 
            this.BrowseConsolidado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BrowseConsolidado.Location = new System.Drawing.Point(15, 55);
            this.BrowseConsolidado.Name = "BrowseConsolidado";
            this.BrowseConsolidado.Size = new System.Drawing.Size(400, 24);
            this.BrowseConsolidado.TabIndex = 5;
            this.BrowseConsolidado.ThemeName = "Fluent";
            this.BrowseConsolidado.ValueChanged += new System.EventHandler(this.BrowseConsolidadoValueChanged);
            this.BrowseConsolidado.Click += new System.EventHandler(this.BrowseConsolidado_Click);
            // 
            // ProcesarBOM
            // 
            this.ProcesarBOM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ProcesarBOM.Location = new System.Drawing.Point(430, 45);
            this.ProcesarBOM.Name = "ProcesarBOM";
            this.ProcesarBOM.Size = new System.Drawing.Size(120, 35);
            this.ProcesarBOM.TabIndex = 6;
            this.ProcesarBOM.Text = "Procesar Plan";
            this.ProcesarBOM.ThemeName = "Fluent";
            this.ProcesarBOM.Click += new System.EventHandler(this.ProcesarConsolidadoClick);
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(570, 35);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(200, 30);
            this.radWaitingBar1.TabIndex = 27;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.Visible = false;
            this.radWaitingBar1.WaitingIndicators.Add(this.dotsRingWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.radWaitingBar1.WaitingSpeed = 50;
            this.radWaitingBar1.WaitingStep = 20;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            // 
            // dotsRingWaitingBarIndicatorElement1
            // 
            this.dotsRingWaitingBarIndicatorElement1.Name = "dotsRingWaitingBarIndicatorElement1";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.lblNumRegistrosOrden);
            this.radGroupBox2.Controls.Add(this.lblRegistroOrden);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.radGroupBox2.HeaderText = "INFORMACIÓN";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            this.radGroupBox2.Size = new System.Drawing.Size(1184, 60);
            this.radGroupBox2.TabIndex = 34;
            this.radGroupBox2.Text = "INFORMACIÓN";
            this.radGroupBox2.ThemeName = "Fluent";
            // 
            // lblNumRegistrosOrden
            // 
            this.lblNumRegistrosOrden.AutoSize = true;
            this.lblNumRegistrosOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNumRegistrosOrden.Location = new System.Drawing.Point(80, 30);
            this.lblNumRegistrosOrden.Name = "lblNumRegistrosOrden";
            this.lblNumRegistrosOrden.Size = new System.Drawing.Size(14, 15);
            this.lblNumRegistrosOrden.TabIndex = 186;
            this.lblNumRegistrosOrden.Text = "0";
            // 
            // lblRegistroOrden
            // 
            this.lblRegistroOrden.AutoSize = true;
            this.lblRegistroOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegistroOrden.Location = new System.Drawing.Point(15, 30);
            this.lblRegistroOrden.Name = "lblRegistroOrden";
            this.lblRegistroOrden.Size = new System.Drawing.Size(62, 15);
            this.lblRegistroOrden.TabIndex = 185;
            this.lblRegistroOrden.Text = "Registros:";
            // 
            // radSpreadsheet1
            // 
            this.radSpreadsheet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSpreadsheet1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radSpreadsheet1.Location = new System.Drawing.Point(0, 0);
            this.radSpreadsheet1.Name = "radSpreadsheet1";
            this.radSpreadsheet1.Size = new System.Drawing.Size(770, 391);
            this.radSpreadsheet1.TabIndex = 35;
            this.radSpreadsheet1.ThemeName = "Fluent";
            workbook1.ActiveTabIndex = -1;
            documentInfo1.Author = null;
            documentInfo1.Description = null;
            documentInfo1.Keywords = null;
            documentInfo1.Subject = null;
            documentInfo1.Title = null;
            workbook1.DocumentInfo = documentInfo1;
            workbook1.Name = "Book1";
            workbook1.WorkbookContentChangedInterval = System.TimeSpan.Parse("00:00:00.0300000");
            this.radSpreadsheet1.Workbook = workbook1;
            ((Telerik.WinControls.UI.RadSpreadsheetElement)(this.radSpreadsheet1.GetChildAt(0))).Workbook = workbook1;
            ((Telerik.WinControls.UI.RadSpreadsheetElement)(this.radSpreadsheet1.GetChildAt(0))).DrawBorder = true;
            ((Telerik.WinControls.UI.RadSpreadsheetElement)(this.radSpreadsheet1.GetChildAt(0))).BorderInnerColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.panelDatos);
            this.panelPrincipal.Controls.Add(this.panelControles);
            this.panelPrincipal.Controls.Add(this.panelEstado);
            this.panelPrincipal.Controls.Add(this.panelHeader);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(10);
            this.panelPrincipal.Size = new System.Drawing.Size(1204, 621);
            this.panelPrincipal.TabIndex = 36;
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.panelGrid);
            this.panelDatos.Controls.Add(this.panelPreview);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(10, 160);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(1184, 391);
            this.panelDatos.TabIndex = 2;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.GridConsolidado);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(770, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(414, 391);
            this.panelGrid.TabIndex = 1;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.radSpreadsheet1);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPreview.Location = new System.Drawing.Point(0, 0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(770, 391);
            this.panelPreview.TabIndex = 0;
            // 
            // panelControles
            // 
            this.panelControles.Controls.Add(this.radGroupBox1);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControles.Location = new System.Drawing.Point(10, 60);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(1184, 100);
            this.panelControles.TabIndex = 1;
            // 
            // panelEstado
            // 
            this.panelEstado.Controls.Add(this.radGroupBox2);
            this.panelEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEstado.Location = new System.Drawing.Point(10, 551);
            this.panelEstado.Name = "panelEstado";
            this.panelEstado.Size = new System.Drawing.Size(1184, 60);
            this.panelEstado.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.radWaitingBar2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(10, 10);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1184, 50);
            this.panelHeader.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1184, 50);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Subida - Consolidado de Planes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radWaitingBar2
            // 
            this.radWaitingBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWaitingBar2.Location = new System.Drawing.Point(0, 0);
            this.radWaitingBar2.Name = "radWaitingBar2";
            this.radWaitingBar2.Size = new System.Drawing.Size(1184, 50);
            this.radWaitingBar2.TabIndex = 28;
            this.radWaitingBar2.Text = "radWaitingBar2";
            this.radWaitingBar2.Visible = false;
            this.radWaitingBar2.WaitingIndicators.Add(this.waitingBarIndicatorElement1);
            this.radWaitingBar2.WaitingIndicators.Add(this.waitingBarIndicatorElement2);
            this.radWaitingBar2.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.radWaitingBar2.WaitingStep = 30;
            this.radWaitingBar2.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber;
            // 
            // waitingBarIndicatorElement1
            // 
            this.waitingBarIndicatorElement1.Name = "waitingBarIndicatorElement1";
            this.waitingBarIndicatorElement1.StretchHorizontally = false;
            // 
            // waitingBarIndicatorElement2
            // 
            this.waitingBarIndicatorElement2.Name = "waitingBarIndicatorElement2";
            this.waitingBarIndicatorElement2.StretchHorizontally = false;
            // 
            // Consolidado_de_Planes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 621);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "Consolidado_de_Planes";
            this.Text = "Consolidado de Planes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Consolidado_de_Planes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridConsolidado.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridConsolidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowseConsolidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcesarBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelEstado.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView GridConsolidado;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadBrowseEditor BrowseConsolidado;
        private Telerik.WinControls.UI.RadButton ProcesarBOM;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.Label lblNumRegistrosOrden;
        private System.Windows.Forms.Label lblRegistroOrden;
        private Telerik.WinControls.UI.RadSpreadsheet radSpreadsheet1;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Panel panelEstado;
        private System.Windows.Forms.Panel panelHeader;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement1;
        private System.Windows.Forms.Label lblTitulo;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar2;
        private Telerik.WinControls.UI.WaitingBarIndicatorElement waitingBarIndicatorElement1;
        private Telerik.WinControls.UI.WaitingBarIndicatorElement waitingBarIndicatorElement2;
    }
}