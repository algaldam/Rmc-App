namespace Rmc.Subidas
{
    partial class BagIrr
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.Windows.Documents.Spreadsheet.Model.Workbook workbook2 = new Telerik.Windows.Documents.Spreadsheet.Model.Workbook();
            Telerik.Windows.Documents.Model.DocumentInfo documentInfo2 = new Telerik.Windows.Documents.Model.DocumentInfo();
            this.GridBag = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.BrowseBag = new Telerik.WinControls.UI.RadBrowseEditor();
            this.ProcesarBag = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblNumRegistrosOrden = new System.Windows.Forms.Label();
            this.lblRegistroOrden = new System.Windows.Forms.Label();
            this.radSpreadsheet1 = new Telerik.WinControls.UI.RadSpreadsheet();
            this.radWaitingBar2 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsSpinnerWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.waitingBarIndicatorElement2 = new Telerik.WinControls.UI.WaitingBarIndicatorElement();
            this.waitingBarIndicatorElement1 = new Telerik.WinControls.UI.WaitingBarIndicatorElement();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.panelControles = new System.Windows.Forms.Panel();
            this.panelEstado = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBag.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowseBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcesarBag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).BeginInit();
            this.radSpreadsheet1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            this.panelPrincipal.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelControles.SuspendLayout();
            this.panelEstado.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GridBag
            // 
            this.GridBag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridBag.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridBag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridBag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GridBag.ForeColor = System.Drawing.Color.Black;
            this.GridBag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridBag.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.GridBag.MasterTemplate.AllowAddNewRow = false;
            this.GridBag.MasterTemplate.AllowEditRow = false;
            this.GridBag.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.GridBag.MasterTemplate.BottomPinnedRowsMode = Telerik.WinControls.UI.GridViewBottomPinnedRowsMode.Fixed;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "SACA_IRR";
            gridViewTextBoxColumn5.HeaderText = "SACA";
            gridViewTextBoxColumn5.Name = "SACA_IRR";
            gridViewTextBoxColumn5.Width = 94;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Item";
            gridViewTextBoxColumn6.HeaderText = "Item";
            gridViewTextBoxColumn6.Name = "Item";
            gridViewTextBoxColumn6.Width = 113;
            gridViewTextBoxColumn7.FieldName = "Descripcion";
            gridViewTextBoxColumn7.HeaderText = "Descripción";
            gridViewTextBoxColumn7.Name = "Descripcion";
            gridViewTextBoxColumn7.Width = 236;
            gridViewTextBoxColumn8.FieldName = "Factor100%";
            gridViewTextBoxColumn8.HeaderText = "Factor 100%";
            gridViewTextBoxColumn8.Name = "Factor100%";
            gridViewTextBoxColumn8.Width = 113;
            this.GridBag.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.GridBag.MasterTemplate.EnableFiltering = true;
            this.GridBag.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GridBag.Name = "GridBag";
            this.GridBag.Padding = new System.Windows.Forms.Padding(2);
            this.GridBag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridBag.Size = new System.Drawing.Size(590, 391);
            this.GridBag.TabIndex = 26;
            this.GridBag.ThemeName = "Fluent";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.BrowseBag);
            this.radGroupBox1.Controls.Add(this.ProcesarBag);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.radGroupBox1.HeaderText = "CARGAR BOLSA IRR";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            this.radGroupBox1.Size = new System.Drawing.Size(1184, 100);
            this.radGroupBox1.TabIndex = 25;
            this.radGroupBox1.Text = "CARGAR BOLSA IRR";
            this.radGroupBox1.ThemeName = "Fluent";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel1.Location = new System.Drawing.Point(15, 35);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(93, 19);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Archivo Bag IRR";
            this.radLabel1.ThemeName = "Fluent";
            // 
            // BrowseBag
            // 
            this.BrowseBag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BrowseBag.Location = new System.Drawing.Point(15, 55);
            this.BrowseBag.Name = "BrowseBag";
            this.BrowseBag.Size = new System.Drawing.Size(400, 24);
            this.BrowseBag.TabIndex = 5;
            this.BrowseBag.ThemeName = "Fluent";
            this.BrowseBag.Click += new System.EventHandler(this.BrowseBag_Click);
            // 
            // ProcesarBag
            // 
            this.ProcesarBag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ProcesarBag.Location = new System.Drawing.Point(430, 45);
            this.ProcesarBag.Name = "ProcesarBag";
            this.ProcesarBag.Size = new System.Drawing.Size(150, 35);
            this.ProcesarBag.TabIndex = 6;
            this.ProcesarBag.Text = "Procesar Bag IRR";
            this.ProcesarBag.ThemeName = "Fluent";
            this.ProcesarBag.Click += new System.EventHandler(this.ProcesarBag_Click);
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
            this.radGroupBox2.TabIndex = 36;
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
            this.radSpreadsheet1.Controls.Add(this.radWaitingBar2);
            this.radSpreadsheet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSpreadsheet1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radSpreadsheet1.Location = new System.Drawing.Point(0, 0);
            this.radSpreadsheet1.Name = "radSpreadsheet1";
            this.radSpreadsheet1.Size = new System.Drawing.Size(594, 391);
            this.radSpreadsheet1.TabIndex = 37;
            this.radSpreadsheet1.ThemeName = "Fluent";
            workbook2.ActiveTabIndex = -1;
            documentInfo2.Author = null;
            documentInfo2.Description = null;
            documentInfo2.Keywords = null;
            documentInfo2.Subject = null;
            documentInfo2.Title = null;
            workbook2.DocumentInfo = documentInfo2;
            workbook2.Name = "Book1";
            workbook2.WorkbookContentChangedInterval = System.TimeSpan.Parse("00:00:00.0300000");
            this.radSpreadsheet1.Workbook = workbook2;
            ((Telerik.WinControls.UI.RadSpreadsheetElement)(this.radSpreadsheet1.GetChildAt(0))).Workbook = workbook2;
            ((Telerik.WinControls.UI.RadSpreadsheetElement)(this.radSpreadsheet1.GetChildAt(0))).DrawBorder = true;
            ((Telerik.WinControls.UI.RadSpreadsheetElement)(this.radSpreadsheet1.GetChildAt(0))).BorderInnerColor = System.Drawing.SystemColors.AppWorkspace;
            // 
            // radWaitingBar2
            // 
            this.radWaitingBar2.Location = new System.Drawing.Point(197, 185);
            this.radWaitingBar2.Name = "radWaitingBar2";
            this.radWaitingBar2.Size = new System.Drawing.Size(200, 30);
            this.radWaitingBar2.TabIndex = 2;
            this.radWaitingBar2.Text = "radWaitingBar1";
            this.radWaitingBar2.Visible = false;
            this.radWaitingBar2.WaitingIndicators.Add(this.dotsSpinnerWaitingBarIndicatorElement1);
            this.radWaitingBar2.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.radWaitingBar2.WaitingSpeed = 100;
            this.radWaitingBar2.WaitingStep = 6;
            this.radWaitingBar2.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner;
            // 
            // dotsSpinnerWaitingBarIndicatorElement1
            // 
            this.dotsSpinnerWaitingBarIndicatorElement1.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dotsSpinnerWaitingBarIndicatorElement1.Name = "dotsSpinnerWaitingBarIndicatorElement1";
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWaitingBar1.Location = new System.Drawing.Point(0, 0);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(1184, 50);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.Visible = false;
            this.radWaitingBar1.WaitingIndicators.Add(this.waitingBarIndicatorElement2);
            this.radWaitingBar1.WaitingIndicators.Add(this.waitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingIndicatorSize = new System.Drawing.Size(200, 20);
            this.radWaitingBar1.WaitingSpeed = 100;
            this.radWaitingBar1.WaitingStep = 45;
            this.radWaitingBar1.WaitingStarted += new System.EventHandler(this.radWaitingBar1_WaitingStarted);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingIndicatorSize = new System.Drawing.Size(200, 20);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingSpeed = 100;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingStep = 45;
            // 
            // waitingBarIndicatorElement2
            // 
            this.waitingBarIndicatorElement2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement2.BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement2.BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement2.Name = "waitingBarIndicatorElement2";
            this.waitingBarIndicatorElement2.StretchHorizontally = false;
            // 
            // waitingBarIndicatorElement1
            // 
            this.waitingBarIndicatorElement1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement1.BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement1.BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.waitingBarIndicatorElement1.Name = "waitingBarIndicatorElement1";
            this.waitingBarIndicatorElement1.StretchHorizontally = false;
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
            this.panelPrincipal.TabIndex = 39;
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.panelGrid);
            this.panelDatos.Controls.Add(this.panelPreview);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(10, 160);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(1184, 391);
            this.panelDatos.TabIndex = 3;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.GridBag);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(594, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(590, 391);
            this.panelGrid.TabIndex = 1;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.radSpreadsheet1);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPreview.Location = new System.Drawing.Point(0, 0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(594, 391);
            this.panelPreview.TabIndex = 0;
            // 
            // panelControles
            // 
            this.panelControles.Controls.Add(this.radGroupBox1);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControles.Location = new System.Drawing.Point(10, 60);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(1184, 100);
            this.panelControles.TabIndex = 2;
            // 
            // panelEstado
            // 
            this.panelEstado.Controls.Add(this.radGroupBox2);
            this.panelEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEstado.Location = new System.Drawing.Point(10, 551);
            this.panelEstado.Name = "panelEstado";
            this.panelEstado.Size = new System.Drawing.Size(1184, 60);
            this.panelEstado.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.radWaitingBar1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(10, 10);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1184, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1184, 50);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Subida - Bolsa de Irregulares";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BagIrr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 621);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "BagIrr";
            this.Text = "Bolsa de Irregulares";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.GridBag.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowseBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcesarBag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).EndInit();
            this.radSpreadsheet1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelEstado.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView GridBag;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadBrowseEditor BrowseBag;
        private Telerik.WinControls.UI.RadButton ProcesarBag;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.Label lblNumRegistrosOrden;
        private System.Windows.Forms.Label lblRegistroOrden;
        private Telerik.WinControls.UI.RadSpreadsheet radSpreadsheet1;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar2;
        private Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement dotsSpinnerWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.WaitingBarIndicatorElement waitingBarIndicatorElement2;
        private Telerik.WinControls.UI.WaitingBarIndicatorElement waitingBarIndicatorElement1;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Panel panelEstado;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
    }
}