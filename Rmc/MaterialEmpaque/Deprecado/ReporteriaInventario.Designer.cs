namespace Rmc.MaterialEmpaque
{
    partial class ReporteriaInventario
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnImprimir = new Telerik.WinControls.UI.RadButton();
            this.lswAreas = new Telerik.WinControls.UI.RadListView();
            this.GridInventario = new Telerik.WinControls.UI.RadGridView();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lswAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridInventario.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1508, 83);
            this.radGroupBox1.TabIndex = 31;
            this.radGroupBox1.ThemeName = "Desert";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.BtnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 723);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1508, 65);
            this.panel1.TabIndex = 71;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Location = new System.Drawing.Point(1353, 9);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnImprimir.Size = new System.Drawing.Size(145, 48);
            this.BtnImprimir.TabIndex = 12;
            this.BtnImprimir.Text = "Exportar Inventario";
            this.BtnImprimir.ThemeName = "Desert";
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // lswAreas
            // 
            this.lswAreas.AllowEdit = false;
            this.lswAreas.AllowRemove = false;
            this.lswAreas.Dock = System.Windows.Forms.DockStyle.Left;
            this.lswAreas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lswAreas.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.lswAreas.Location = new System.Drawing.Point(0, 0);
            this.lswAreas.Name = "lswAreas";
            // 
            // 
            // 
            this.lswAreas.RootElement.AccessibleDescription = "Areas";
            this.lswAreas.RootElement.AccessibleName = "Areas";
            this.lswAreas.RootElement.Tag = "Areas";
            this.lswAreas.Size = new System.Drawing.Size(172, 640);
            this.lswAreas.TabIndex = 4;
            this.lswAreas.ThemeName = "ControlDefault";
            this.lswAreas.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.lswAreas.SelectedIndexChanged += new System.EventHandler(this.lswAreas_SelectedIndexChanged);
            // 
            // GridInventario
            // 
            this.GridInventario.AutoScroll = true;
            this.GridInventario.BackColor = System.Drawing.Color.White;
            this.GridInventario.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GridInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(72)))), ((int)(((byte)(58)))));
            this.GridInventario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridInventario.Location = new System.Drawing.Point(172, 0);
            // 
            // 
            // 
            this.GridInventario.MasterTemplate.AllowAddNewRow = false;
            this.GridInventario.MasterTemplate.AllowDeleteRow = false;
            this.GridInventario.MasterTemplate.AllowEditRow = false;
            this.GridInventario.MasterTemplate.AllowRowResize = false;
            this.GridInventario.MasterTemplate.AutoGenerateColumns = false;
            this.GridInventario.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.GridInventario.MasterTemplate.EnableFiltering = true;
            this.GridInventario.MasterTemplate.EnableGrouping = false;
            this.GridInventario.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GridInventario.Name = "GridInventario";
            this.GridInventario.Padding = new System.Windows.Forms.Padding(1);
            this.GridInventario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridInventario.Size = new System.Drawing.Size(1336, 640);
            this.GridInventario.TabIndex = 15;
            this.GridInventario.ThemeName = "Desert";
            // 
            // radPanel3
            // 
            this.radPanel3.AutoScroll = true;
            this.radPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.radPanel3.Controls.Add(this.GridInventario);
            this.radPanel3.Controls.Add(this.lswAreas);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel3.ForeColor = System.Drawing.Color.Black;
            this.radPanel3.Location = new System.Drawing.Point(0, 83);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(1508, 640);
            this.radPanel3.TabIndex = 72;
            this.radPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReporteriaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 788);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ReporteriaInventario";
            this.Text = "Reporteria de Inventario";
            this.Load += new System.EventHandler(this.frm_Inventario_Por_Area_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lswAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridInventario.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton BtnImprimir;
        private Telerik.WinControls.UI.RadListView lswAreas;
        private Telerik.WinControls.UI.RadGridView GridInventario;
        public Telerik.WinControls.UI.RadPanel radPanel3;
    }
}
