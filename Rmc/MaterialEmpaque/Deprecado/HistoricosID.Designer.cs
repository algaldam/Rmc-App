namespace Rmc.MaterialEmpaque
{
    partial class HistoricosID
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbxFiltrado = new System.Windows.Forms.CheckBox();
            this.cbxTID = new System.Windows.Forms.CheckBox();
            this.rdtpInicio = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdtpFin = new Telerik.WinControls.UI.RadDateTimePicker();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnImprimir = new Telerik.WinControls.UI.RadButton();
            this.HistoricoGrid = new Telerik.WinControls.UI.RadGridView();
            this.ContadorItems = new Telerik.WinControls.UI.RadLabel();
            this.LblRegistros = new Telerik.WinControls.UI.RadLabel();
            this.Filtrar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdtpInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtpFin)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoricoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoricoGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContadorItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filtrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.radGroupBox1.Controls.Add(this.Filtrar);
            this.radGroupBox1.Controls.Add(this.cbxFiltrado);
            this.radGroupBox1.Controls.Add(this.cbxTID);
            this.radGroupBox1.Controls.Add(this.rdtpInicio);
            this.radGroupBox1.Controls.Add(this.rdtpFin);
            this.radGroupBox1.Controls.Add(this.label44);
            this.radGroupBox1.Controls.Add(this.label45);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1508, 83);
            this.radGroupBox1.TabIndex = 32;
            this.radGroupBox1.ThemeName = "Desert";
            // 
            // cbxFiltrado
            // 
            this.cbxFiltrado.AutoSize = true;
            this.cbxFiltrado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbxFiltrado.Location = new System.Drawing.Point(216, 23);
            this.cbxFiltrado.Name = "cbxFiltrado";
            this.cbxFiltrado.Size = new System.Drawing.Size(191, 25);
            this.cbxFiltrado.TabIndex = 74;
            this.cbxFiltrado.Text = "Historico por Filtrado";
            this.cbxFiltrado.UseVisualStyleBackColor = true;
            this.cbxFiltrado.CheckedChanged += new System.EventHandler(this.cbxFiltrado_CheckedChanged);
            // 
            // cbxTID
            // 
            this.cbxTID.AutoSize = true;
            this.cbxTID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbxTID.Location = new System.Drawing.Point(12, 23);
            this.cbxTID.Name = "cbxTID";
            this.cbxTID.Size = new System.Drawing.Size(189, 25);
            this.cbxTID.TabIndex = 73;
            this.cbxTID.Text = "Historico por TraceID";
            this.cbxTID.UseVisualStyleBackColor = true;
            this.cbxTID.CheckedChanged += new System.EventHandler(this.cbxTID_CheckedChanged);
            // 
            // rdtpInicio
            // 
            this.rdtpInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdtpInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdtpInicio.Location = new System.Drawing.Point(1160, 15);
            this.rdtpInicio.Name = "rdtpInicio";
            this.rdtpInicio.Size = new System.Drawing.Size(219, 23);
            this.rdtpInicio.TabIndex = 28;
            this.rdtpInicio.TabStop = false;
            this.rdtpInicio.Text = "Tuesday, May 11, 2021";
            this.rdtpInicio.ThemeName = "VisualStudio2012Dark";
            this.rdtpInicio.Value = new System.DateTime(2021, 5, 11, 0, 0, 0, 0);
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.rdtpInicio.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "Tuesday, May 11, 2021";
            // 
            // rdtpFin
            // 
            this.rdtpFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdtpFin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdtpFin.Location = new System.Drawing.Point(1162, 48);
            this.rdtpFin.Name = "rdtpFin";
            this.rdtpFin.Size = new System.Drawing.Size(217, 23);
            this.rdtpFin.TabIndex = 29;
            this.rdtpFin.TabStop = false;
            this.rdtpFin.Text = "Tuesday, May 11, 2021";
            this.rdtpFin.ThemeName = "VisualStudio2012Dark";
            this.rdtpFin.Value = new System.DateTime(2021, 5, 11, 0, 0, 0, 0);
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.rdtpFin.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "Tuesday, May 11, 2021";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(1112, 18);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 16);
            this.label44.TabIndex = 26;
            this.label44.Text = "Desde:";
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(1112, 51);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(47, 16);
            this.label45.TabIndex = 27;
            this.label45.Text = "Hasta:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.ContadorItems);
            this.panel1.Controls.Add(this.LblRegistros);
            this.panel1.Controls.Add(this.BtnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 723);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1508, 65);
            this.panel1.TabIndex = 72;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Location = new System.Drawing.Point(1360, 9);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnImprimir.Size = new System.Drawing.Size(138, 48);
            this.BtnImprimir.TabIndex = 12;
            this.BtnImprimir.Text = "Exportar datos";
            this.BtnImprimir.ThemeName = "Desert";
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // HistoricoGrid
            // 
            this.HistoricoGrid.AutoScroll = true;
            this.HistoricoGrid.BackColor = System.Drawing.Color.White;
            this.HistoricoGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.HistoricoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoricoGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HistoricoGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(72)))), ((int)(((byte)(58)))));
            this.HistoricoGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.HistoricoGrid.Location = new System.Drawing.Point(0, 83);
            // 
            // 
            // 
            this.HistoricoGrid.MasterTemplate.AllowAddNewRow = false;
            this.HistoricoGrid.MasterTemplate.AllowDeleteRow = false;
            this.HistoricoGrid.MasterTemplate.AllowEditRow = false;
            this.HistoricoGrid.MasterTemplate.AllowRowResize = false;
            this.HistoricoGrid.MasterTemplate.AutoGenerateColumns = false;
            this.HistoricoGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.HistoricoGrid.MasterTemplate.EnableFiltering = true;
            this.HistoricoGrid.MasterTemplate.EnableGrouping = false;
            this.HistoricoGrid.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.HistoricoGrid.Name = "HistoricoGrid";
            this.HistoricoGrid.Padding = new System.Windows.Forms.Padding(1);
            this.HistoricoGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HistoricoGrid.Size = new System.Drawing.Size(1508, 640);
            this.HistoricoGrid.TabIndex = 73;
            this.HistoricoGrid.ThemeName = "Desert";
            // 
            // ContadorItems
            // 
            this.ContadorItems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContadorItems.Location = new System.Drawing.Point(192, 17);
            this.ContadorItems.Name = "ContadorItems";
            this.ContadorItems.Size = new System.Drawing.Size(17, 23);
            this.ContadorItems.TabIndex = 29;
            this.ContadorItems.Text = "0";
            // 
            // LblRegistros
            // 
            this.LblRegistros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRegistros.Location = new System.Drawing.Point(5, 17);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(184, 23);
            this.LblRegistros.TabIndex = 28;
            this.LblRegistros.Text = "Cantidad de registros:";
            // 
            // Filtrar
            // 
            this.Filtrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Filtrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filtrar.Location = new System.Drawing.Point(1398, 15);
            this.Filtrar.Name = "Filtrar";
            this.Filtrar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Filtrar.Size = new System.Drawing.Size(102, 56);
            this.Filtrar.TabIndex = 75;
            this.Filtrar.Text = "Filtrar datos";
            this.Filtrar.ThemeName = "Desert";
            this.Filtrar.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // HistoricosID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 788);
            this.Controls.Add(this.HistoricoGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "HistoricosID";
            this.Text = "HistoricosID";
            this.Load += new System.EventHandler(this.HistoricosID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdtpInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtpFin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoricoGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoricoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContadorItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filtrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton BtnImprimir;
        private Telerik.WinControls.UI.RadGridView HistoricoGrid;
        private Telerik.WinControls.UI.RadDateTimePicker rdtpInicio;
        private Telerik.WinControls.UI.RadDateTimePicker rdtpFin;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox cbxFiltrado;
        private System.Windows.Forms.CheckBox cbxTID;
        private Telerik.WinControls.UI.RadLabel ContadorItems;
        private Telerik.WinControls.UI.RadLabel LblRegistros;
        private Telerik.WinControls.UI.RadButton Filtrar;
    }
}
