namespace Rmc.Subidas
{
    partial class SubBOMExcel
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
            this.ProcesarBOM = new Telerik.WinControls.UI.RadButton();
            this.BrowseBOM = new Telerik.WinControls.UI.RadBrowseEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.GridBOM = new Telerik.WinControls.UI.RadGridView();
            this.radSpreadsheet1 = new Telerik.WinControls.UI.RadSpreadsheet();
            this.dotsRingWaitingBarIndicatorElement2 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            this.dotsRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsRingWaitingBarIndicatorElement3 = new Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement();
            this.panelControles = new System.Windows.Forms.Panel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.panelExcel = new System.Windows.Forms.Panel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.panelEstado = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProcesarBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowseBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBOM.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            this.panelControles.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.panelExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.panelEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcesarBOM
            // 
            this.ProcesarBOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcesarBOM.Location = new System.Drawing.Point(311, 46);
            this.ProcesarBOM.Name = "ProcesarBOM";
            this.ProcesarBOM.Size = new System.Drawing.Size(134, 24);
            this.ProcesarBOM.TabIndex = 6;
            this.ProcesarBOM.Text = "Procesar BOM";
            this.ProcesarBOM.ThemeName = "Desert";
            this.ProcesarBOM.Click += new System.EventHandler(this.ProcesarBomClick);
            // 
            // BrowseBOM
            // 
            this.BrowseBOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseBOM.Location = new System.Drawing.Point(5, 46);
            this.BrowseBOM.Name = "BrowseBOM";
            this.BrowseBOM.Size = new System.Drawing.Size(300, 20);
            this.BrowseBOM.TabIndex = 5;
            this.BrowseBOM.ThemeName = "Desert";
            this.BrowseBOM.ValueChanged += new System.EventHandler(this.BrowseBomValueChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(5, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Archivo BOM";
            // 
            // GridBOM
            // 
            this.GridBOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridBOM.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridBOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.GridBOM.ForeColor = System.Drawing.Color.Black;
            this.GridBOM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridBOM.Location = new System.Drawing.Point(0, 18);
            // 
            // 
            // 
            this.GridBOM.MasterTemplate.AllowAddNewRow = false;
            this.GridBOM.MasterTemplate.AllowEditRow = false;
            this.GridBOM.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.GridBOM.MasterTemplate.BottomPinnedRowsMode = Telerik.WinControls.UI.GridViewBottomPinnedRowsMode.Fixed;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "sub_SACA";
            gridViewTextBoxColumn1.HeaderText = "SACA";
            gridViewTextBoxColumn1.Name = "bom_SACA";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "sub_producto";
            gridViewTextBoxColumn2.HeaderText = "Producto";
            gridViewTextBoxColumn2.Name = "bom_producto";
            gridViewTextBoxColumn2.Width = 61;
            gridViewTextBoxColumn3.FieldName = "sub_descripcion";
            gridViewTextBoxColumn3.HeaderText = "Descripción";
            gridViewTextBoxColumn3.Name = "bom_descripcion";
            gridViewTextBoxColumn3.Width = 85;
            gridViewTextBoxColumn4.FieldName = "sub_factor";
            gridViewTextBoxColumn4.HeaderText = "Factor 100%";
            gridViewTextBoxColumn4.Name = "bom_factor";
            gridViewTextBoxColumn4.Width = 28;
            gridViewTextBoxColumn5.FieldName = "sub_TypeMaterials";
            gridViewTextBoxColumn5.HeaderText = "Tipo Material";
            gridViewTextBoxColumn5.Name = "bom_TypeMaterials";
            gridViewTextBoxColumn5.Width = 40;
            this.GridBOM.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.GridBOM.MasterTemplate.EnableFiltering = true;
            this.GridBOM.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.GridBOM.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridBOM.Name = "GridBOM";
            this.GridBOM.Padding = new System.Windows.Forms.Padding(1);
            this.GridBOM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridBOM.Size = new System.Drawing.Size(283, 503);
            this.GridBOM.TabIndex = 8;
            this.GridBOM.ThemeName = "Desert";
            // 
            // radSpreadsheet1
            // 
            this.radSpreadsheet1.BackColor = System.Drawing.Color.White;
            this.radSpreadsheet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSpreadsheet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpreadsheet1.Location = new System.Drawing.Point(0, 18);
            this.radSpreadsheet1.Name = "radSpreadsheet1";
            this.radSpreadsheet1.Size = new System.Drawing.Size(729, 503);
            this.radSpreadsheet1.TabIndex = 9;
            this.radSpreadsheet1.ThemeName = "Desert";
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
            // dotsRingWaitingBarIndicatorElement2
            // 
            this.dotsRingWaitingBarIndicatorElement2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement2.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(245)))), ((int)(((byte)(63)))));
            this.dotsRingWaitingBarIndicatorElement2.ElementColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(247)))), ((int)(((byte)(1)))));
            this.dotsRingWaitingBarIndicatorElement2.ElementColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(123)))), ((int)(((byte)(4)))));
            this.dotsRingWaitingBarIndicatorElement2.GradientPercentage2 = 0.67F;
            this.dotsRingWaitingBarIndicatorElement2.Name = "dotsRingWaitingBarIndicatorElement2";
            this.dotsRingWaitingBarIndicatorElement2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement2.UseCompatibleTextRendering = false;
            // 
            // dotsRingWaitingBarIndicatorElement1
            // 
            this.dotsRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement1.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(245)))), ((int)(((byte)(63)))));
            this.dotsRingWaitingBarIndicatorElement1.ElementColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(247)))), ((int)(((byte)(1)))));
            this.dotsRingWaitingBarIndicatorElement1.ElementColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(123)))), ((int)(((byte)(4)))));
            this.dotsRingWaitingBarIndicatorElement1.GradientPercentage2 = 0.67F;
            this.dotsRingWaitingBarIndicatorElement1.Name = "dotsRingWaitingBarIndicatorElement1";
            this.dotsRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radWaitingBar1.Location = new System.Drawing.Point(618, 15);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(70, 70);
            this.radWaitingBar1.TabIndex = 20;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.dotsRingWaitingBarIndicatorElement3);
            this.radWaitingBar1.WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            this.radWaitingBar1.WaitingSpeed = 50;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingIndicatorSize = new System.Drawing.Size(100, 14);
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.radWaitingBar1.GetChildAt(0))).WaitingSpeed = 50;
            ((Telerik.WinControls.UI.WaitingBarContentElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0))).WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsRing;
            ((Telerik.WinControls.UI.WaitingBarSeparatorElement)(this.radWaitingBar1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Dash = false;
            // 
            // dotsRingWaitingBarIndicatorElement3
            // 
            this.dotsRingWaitingBarIndicatorElement3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.dotsRingWaitingBarIndicatorElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement3.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(245)))), ((int)(((byte)(63)))));
            this.dotsRingWaitingBarIndicatorElement3.ElementColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(247)))), ((int)(((byte)(1)))));
            this.dotsRingWaitingBarIndicatorElement3.ElementColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(123)))), ((int)(((byte)(4)))));
            this.dotsRingWaitingBarIndicatorElement3.GradientPercentage2 = 0.67F;
            this.dotsRingWaitingBarIndicatorElement3.Name = "dotsRingWaitingBarIndicatorElement3";
            this.dotsRingWaitingBarIndicatorElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.dotsRingWaitingBarIndicatorElement3.UseCompatibleTextRendering = false;
            this.dotsRingWaitingBarIndicatorElement3.Click += new System.EventHandler(this.dotsRingWaitingBarIndicatorElement3_Click);
            // 
            // panelControles
            // 
            this.panelControles.BackColor = System.Drawing.Color.White;
            this.panelControles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControles.Controls.Add(this.radLabel1);
            this.panelControles.Controls.Add(this.BrowseBOM);
            this.panelControles.Controls.Add(this.ProcesarBOM);
            this.panelControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControles.Location = new System.Drawing.Point(0, 0);
            this.panelControles.Name = "panelControles";
            this.panelControles.Padding = new System.Windows.Forms.Padding(10);
            this.panelControles.Size = new System.Drawing.Size(1036, 100);
            this.panelControles.TabIndex = 21;
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.panelGrid);
            this.panelDatos.Controls.Add(this.panelExcel);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 100);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Padding = new System.Windows.Forms.Padding(10);
            this.panelDatos.Size = new System.Drawing.Size(1036, 543);
            this.panelDatos.TabIndex = 22;
            // 
            // panelGrid
            // 
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.GridBOM);
            this.panelGrid.Controls.Add(this.radLabel3);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(741, 10);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(285, 523);
            this.panelGrid.TabIndex = 1;
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(0, 0);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(155, 18);
            this.radLabel3.TabIndex = 11;
            this.radLabel3.Text = "DATOS PROCESADOS";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // panelExcel
            // 
            this.panelExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExcel.Controls.Add(this.radSpreadsheet1);
            this.panelExcel.Controls.Add(this.radLabel2);
            this.panelExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelExcel.Location = new System.Drawing.Point(10, 10);
            this.panelExcel.Name = "panelExcel";
            this.panelExcel.Size = new System.Drawing.Size(731, 523);
            this.panelExcel.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(0, 0);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(729, 18);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "VISTA PREVIA DEL EXCEL";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // panelEstado
            // 
            this.panelEstado.Controls.Add(this.radWaitingBar1);
            this.panelEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEstado.Location = new System.Drawing.Point(0, 643);
            this.panelEstado.Name = "panelEstado";
            this.panelEstado.Size = new System.Drawing.Size(1036, 100);
            this.panelEstado.TabIndex = 23;
            // 
            // SubBOMExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1036, 743);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.panelEstado);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SubBOMExcel";
            this.Text = "BOM";
            this.ThemeName = "Desert";
            this.Load += new System.EventHandler(this.SubBOMExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcesarBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrowseBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBOM.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpreadsheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.panelExcel.ResumeLayout(false);
            this.panelExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.panelEstado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton ProcesarBOM;
        private Telerik.WinControls.UI.RadBrowseEditor BrowseBOM;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView GridBOM;
        private Telerik.WinControls.UI.RadSpreadsheet radSpreadsheet1;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement2;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.DotsRingWaitingBarIndicatorElement dotsRingWaitingBarIndicatorElement3;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelExcel;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.Panel panelEstado;
    }
}