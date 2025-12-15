namespace Rmc.Consultas
{
    partial class frmTrasladoConformidad
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBL_ERROR = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.BTN_AGREGAR = new Telerik.WinControls.UI.RadButton();
            this.GRID_VIEW_NO_CONFORMIDAD = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LBL_ERROR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_AGREGAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_NO_CONFORMIDAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBL_ERROR);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Controls.Add(this.BTN_AGREGAR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 108);
            this.panel1.TabIndex = 1;
            // 
            // LBL_ERROR
            // 
            this.LBL_ERROR.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ERROR.ForeColor = System.Drawing.Color.Red;
            this.LBL_ERROR.Location = new System.Drawing.Point(66, 77);
            this.LBL_ERROR.Name = "LBL_ERROR";
            this.LBL_ERROR.Size = new System.Drawing.Size(351, 25);
            this.LBL_ERROR.TabIndex = 5;
            this.LBL_ERROR.Text = "Se debe Seleccionar defecto por cada Artículo";
            this.LBL_ERROR.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(306, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(353, 30);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Proceso de Traslado No Conformidad";
            // 
            // BTN_AGREGAR
            // 
            this.BTN_AGREGAR.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_AGREGAR.Image = global::Rmc.Properties.Resources.procesar;
            this.BTN_AGREGAR.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BTN_AGREGAR.Location = new System.Drawing.Point(776, 40);
            this.BTN_AGREGAR.Name = "BTN_AGREGAR";
            this.BTN_AGREGAR.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.BTN_AGREGAR.Size = new System.Drawing.Size(159, 48);
            this.BTN_AGREGAR.TabIndex = 0;
            this.BTN_AGREGAR.Text = "Procesar";
            this.BTN_AGREGAR.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // GRID_VIEW_NO_CONFORMIDAD
            // 
            this.GRID_VIEW_NO_CONFORMIDAD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRID_VIEW_NO_CONFORMIDAD.Location = new System.Drawing.Point(0, 108);
            // 
            // 
            // 
            this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate.AllowAddNewRow = false;
            this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate.AllowDeleteRow = false;
            this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate.AllowRowResize = false;
            this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "IdItem";
            gridViewDecimalColumn1.HeaderText = "ID Item";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.MinWidth = 140;
            gridViewDecimalColumn1.Name = "IdItem";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 144;
            gridViewTextBoxColumn1.FieldName = "NombreItem";
            gridViewTextBoxColumn1.HeaderText = "Producto";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.MinWidth = 450;
            gridViewTextBoxColumn1.Name = "NombreItem";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 469;
            gridViewComboBoxColumn1.DataType = typeof(int);
            gridViewComboBoxColumn1.DisplayMember = "def_Descripcion";
            gridViewComboBoxColumn1.FieldName = "IdDefecto";
            gridViewComboBoxColumn1.HeaderText = "Defecto";
            gridViewComboBoxColumn1.MinWidth = 300;
            gridViewComboBoxColumn1.Name = "IdDefecto";
            gridViewComboBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewComboBoxColumn1.ValueMember = "def_ID";
            gridViewComboBoxColumn1.Width = 328;
            this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewComboBoxColumn1});
            this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRID_VIEW_NO_CONFORMIDAD.Name = "GRID_VIEW_NO_CONFORMIDAD";
            this.GRID_VIEW_NO_CONFORMIDAD.ShowGroupPanel = false;
            this.GRID_VIEW_NO_CONFORMIDAD.Size = new System.Drawing.Size(971, 405);
            this.GRID_VIEW_NO_CONFORMIDAD.TabIndex = 2;
            // 
            // frmTrasladoConformidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 513);
            this.Controls.Add(this.GRID_VIEW_NO_CONFORMIDAD);
            this.Controls.Add(this.panel1);
            this.Name = "frmTrasladoConformidad";
            this.Text = "frmTrasladoConformidad";
            this.Load += new System.EventHandler(this.frmTrasladoConformidad_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LBL_ERROR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_AGREGAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_NO_CONFORMIDAD.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_VIEW_NO_CONFORMIDAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadLabel LBL_ERROR;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton BTN_AGREGAR;
        private Telerik.WinControls.UI.RadGridView GRID_VIEW_NO_CONFORMIDAD;
    }
}
