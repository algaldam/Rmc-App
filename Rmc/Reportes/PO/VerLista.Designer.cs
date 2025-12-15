namespace Wainari.Vista.Movimientos
{
    partial class VerLista
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgvDatos = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatos.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvDatos
            // 
            this.rgvDatos.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rgvDatos.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvDatos.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvDatos.ForeColor = System.Drawing.Color.Black;
            this.rgvDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDatos.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rgvDatos.MasterTemplate.AllowAddNewRow = false;
            this.rgvDatos.MasterTemplate.AllowDeleteRow = false;
            this.rgvDatos.MasterTemplate.AllowEditRow = false;
            this.rgvDatos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "pac_factura_detalle_id";
            gridViewTextBoxColumn1.HeaderText = "pac_factura_detalle_id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "pac_factura_detalle_id";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "pac_prov_pack_id";
            gridViewTextBoxColumn2.HeaderText = "PROV PACK ID";
            gridViewTextBoxColumn2.Name = "pac_prov_pack_id";
            gridViewTextBoxColumn2.Width = 165;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "pac_id";
            gridViewTextBoxColumn3.HeaderText = "PACK ID";
            gridViewTextBoxColumn3.Name = "pac_id";
            gridViewTextBoxColumn3.Width = 137;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "pac_libras";
            gridViewTextBoxColumn4.HeaderText = "LIBRAS";
            gridViewTextBoxColumn4.Name = "pac_libras";
            gridViewTextBoxColumn4.Width = 111;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "pac_impreso";
            gridViewCheckBoxColumn1.HeaderText = "IMPRESO";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "pac_impreso";
            gridViewCheckBoxColumn1.ReadOnly = true;
            gridViewCheckBoxColumn1.Width = 111;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "imprimir";
            gridViewCommandColumn1.Name = "imprimir";
            gridViewCommandColumn1.Width = 69;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "eliminar";
            gridViewCommandColumn2.Name = "eliminar";
            gridViewCommandColumn2.Width = 69;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "pac_scan_whin";
            gridViewTextBoxColumn5.HeaderText = "SCAN WHIN";
            gridViewTextBoxColumn5.Name = "pac_scan_whin";
            gridViewTextBoxColumn5.Width = 206;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "loc_nombre";
            gridViewTextBoxColumn6.HeaderText = "LOCATION";
            gridViewTextBoxColumn6.Name = "loc_nombre";
            gridViewTextBoxColumn6.Width = 111;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "pac_scan_whout";
            gridViewTextBoxColumn7.HeaderText = "SCAN WHOUT";
            gridViewTextBoxColumn7.Name = "pac_scan_whout";
            gridViewTextBoxColumn7.Width = 203;
            this.rgvDatos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.rgvDatos.MasterTemplate.EnableFiltering = true;
            this.rgvDatos.MasterTemplate.EnableGrouping = false;
            this.rgvDatos.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDatos.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvDatos.Name = "rgvDatos";
            this.rgvDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDatos.Size = new System.Drawing.Size(1212, 625);
            this.rgvDatos.TabIndex = 0;
            this.rgvDatos.ThemeName = "TelerikMetroBlue";
            this.rgvDatos.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.rgvDatos_CellFormatting);
            this.rgvDatos.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.rgvDatos_ViewCellFormatting);
            this.rgvDatos.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvDatos_CellClick);
            // 
            // VerLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1212, 625);
            this.Controls.Add(this.rgvDatos);
            this.Name = "VerLista";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Lista";
            this.ThemeName = "TelerikMetroBlue";
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvDatos;
    }
}
