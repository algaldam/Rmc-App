namespace Rmc.Consultas
{
    partial class VerDevoluciones
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.rgvDevoluciones = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDevoluciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDevoluciones.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightGray;
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            // 
            // 
            // 
            this.radPanel1.RootElement.BorderHighlightColor = System.Drawing.Color.Black;
            this.radPanel1.Size = new System.Drawing.Size(1185, 50);
            this.radPanel1.TabIndex = 26;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 45);
            this.label6.TabIndex = 13;
            this.label6.Text = "Devoluciones";
            // 
            // rgvDevoluciones
            // 
            this.rgvDevoluciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvDevoluciones.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rgvDevoluciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDevoluciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rgvDevoluciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDevoluciones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDevoluciones.Location = new System.Drawing.Point(20, 66);
            // 
            // 
            // 
            this.rgvDevoluciones.MasterTemplate.AllowAddNewRow = false;
            this.rgvDevoluciones.MasterTemplate.AllowDeleteRow = false;
            this.rgvDevoluciones.MasterTemplate.AllowEditRow = false;
            this.rgvDevoluciones.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "PACKID";
            gridViewTextBoxColumn1.HeaderText = "PACK ID";
            gridViewTextBoxColumn1.Name = "PACKID";
            gridViewTextBoxColumn1.Width = 110;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ITEM";
            gridViewTextBoxColumn2.HeaderText = "ITEM";
            gridViewTextBoxColumn2.Name = "ITEM";
            gridViewTextBoxColumn2.Width = 330;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "LOCALIDAD";
            gridViewTextBoxColumn3.HeaderText = "LOCALIDAD";
            gridViewTextBoxColumn3.Name = "LOCALIDAD";
            gridViewTextBoxColumn3.Width = 82;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "LOTE";
            gridViewTextBoxColumn4.HeaderText = "LOTE";
            gridViewTextBoxColumn4.Name = "LOTE";
            gridViewTextBoxColumn4.Width = 82;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "LIBRAS";
            gridViewTextBoxColumn5.HeaderText = "LIBRAS";
            gridViewTextBoxColumn5.Name = "LIBRAS";
            gridViewTextBoxColumn5.Width = 82;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "FECHAENTRADA";
            gridViewTextBoxColumn6.HeaderText = "FECHA ENTRADA";
            gridViewTextBoxColumn6.Name = "FECHAENTRADA";
            gridViewTextBoxColumn6.Width = 137;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "FECHASALIDA";
            gridViewTextBoxColumn7.HeaderText = "FECHA SALIDA";
            gridViewTextBoxColumn7.Name = "FECHASALIDA";
            gridViewTextBoxColumn7.Width = 137;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "FECHACADUCIDAD";
            gridViewTextBoxColumn8.HeaderText = "FECHA CADUCIDAD";
            gridViewTextBoxColumn8.Name = "FECHACADUCIDAD";
            gridViewTextBoxColumn8.Width = 166;
            this.rgvDevoluciones.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.rgvDevoluciones.MasterTemplate.EnableFiltering = true;
            this.rgvDevoluciones.MasterTemplate.EnableGrouping = false;
            this.rgvDevoluciones.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDevoluciones.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvDevoluciones.Name = "rgvDevoluciones";
            this.rgvDevoluciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDevoluciones.Size = new System.Drawing.Size(1157, 520);
            this.rgvDevoluciones.TabIndex = 27;
            this.rgvDevoluciones.ThemeName = "TelerikMetroBlue";
            // 
            // VerDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 598);
            this.Controls.Add(this.rgvDevoluciones);
            this.Controls.Add(this.radPanel1);
            this.Name = "VerDevoluciones";
            this.Text = "Ver Devoluciones";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDevoluciones.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDevoluciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadGridView rgvDevoluciones;
    }
}
