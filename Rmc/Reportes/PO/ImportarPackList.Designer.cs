namespace Wainari.Vista.Movimientos
{
    partial class ImportarPackList
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgvPackList = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnImportar = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPackList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPackList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvPackList
            // 
            this.rgvPackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvPackList.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rgvPackList.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvPackList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvPackList.ForeColor = System.Drawing.Color.Black;
            this.rgvPackList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvPackList.Location = new System.Drawing.Point(6, 105);
            this.rgvPackList.Margin = new System.Windows.Forms.Padding(4);
            // 
            // 
            // 
            this.rgvPackList.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.rgvPackList.MasterTemplate.AllowDragToGroup = false;
            this.rgvPackList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "prov_pack_id";
            gridViewTextBoxColumn1.HeaderText = "PROV PACK ID";
            gridViewTextBoxColumn1.MinWidth = 6;
            gridViewTextBoxColumn1.Name = "prov_pack_id";
            gridViewTextBoxColumn1.Width = 295;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "libras";
            gridViewTextBoxColumn2.HeaderText = "LIBRAS";
            gridViewTextBoxColumn2.MinWidth = 6;
            gridViewTextBoxColumn2.Name = "libras";
            gridViewTextBoxColumn2.Width = 216;
            gridViewDateTimeColumn1.FieldName = "fecha_produccion";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatInfo = new System.Globalization.CultureInfo("es-US");
            gridViewDateTimeColumn1.FormatString = "{0:MM/dd/yyyy }";
            gridViewDateTimeColumn1.HeaderText = "FECHA PRODUCCIÓN";
            gridViewDateTimeColumn1.MinWidth = 110;
            gridViewDateTimeColumn1.Name = "fecha_produccion";
            gridViewDateTimeColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn1.Width = 325;
            this.rgvPackList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1});
            this.rgvPackList.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvPackList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvPackList.Name = "rgvPackList";
            this.rgvPackList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvPackList.Size = new System.Drawing.Size(872, 465);
            this.rgvPackList.TabIndex = 0;
            this.rgvPackList.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(172, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(503, 33);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "IMPORTAR PESOS EN LIBRAS DEL PACKING LIST";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = "btnCancelar";
            this.btnCancelar.AccessibleName = "btnCancelar";
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(747, 59);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 29);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "TelerikMetroBlue";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.AccessibleDescription = "btnImportar";
            this.btnImportar.AccessibleName = "btnImportar";
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Location = new System.Drawing.Point(616, 59);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(125, 29);
            this.btnImportar.TabIndex = 23;
            this.btnImportar.Text = "Importar";
            this.btnImportar.ThemeName = "TelerikMetroBlue";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.btnImportar);
            this.radPanel1.Controls.Add(this.btnCancelar);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(884, 98);
            this.radPanel1.TabIndex = 24;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.Red;
            this.radLabel2.Location = new System.Drawing.Point(193, 65);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(362, 21);
            this.radLabel2.TabIndex = 24;
            this.radLabel2.Text = "Formato de Fecha es:  mes/día/ año,    ejemplo:  02/28/2021";
            // 
            // ImportarPackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(884, 583);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.rgvPackList);
            this.MaximumSize = new System.Drawing.Size(892, 613);
            this.MinimumSize = new System.Drawing.Size(892, 613);
            this.Name = "ImportarPackList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(892, 613);
            this.ShowIcon = false;
            this.Text = "Importar Pack List";
            this.ThemeName = "TelerikMetroBlue";
            ((System.ComponentModel.ISupportInitialize)(this.rgvPackList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvPackList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImportar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvPackList;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadButton btnImportar;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
