namespace Rmc.Consultas
{
    partial class ConsOrdenes
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.TxtOrden = new Telerik.WinControls.UI.RadTextBox();
            this.BtnBuscar = new Telerik.WinControls.UI.RadButton();
            this.GridOrden = new Telerik.WinControls.UI.RadGridView();
            this.BtnActualizar = new Telerik.WinControls.UI.RadButton();
            this.BtnImprimir = new Telerik.WinControls.UI.RadButton();
            this.BtnEliminar = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrden.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(5, 40);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Orden";
            // 
            // TxtOrden
            // 
            this.TxtOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOrden.Location = new System.Drawing.Point(55, 40);
            this.TxtOrden.Name = "TxtOrden";
            this.TxtOrden.Size = new System.Drawing.Size(150, 24);
            this.TxtOrden.TabIndex = 1;
            this.TxtOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOrden_KeyPress);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(211, 40);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(125, 24);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.ThemeName = "Desert";
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // GridOrden
            // 
            this.GridOrden.BackColor = System.Drawing.Color.White;
            this.GridOrden.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GridOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(72)))), ((int)(((byte)(58)))));
            this.GridOrden.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridOrden.Location = new System.Drawing.Point(30, 148);
            // 
            // 
            // 
            this.GridOrden.MasterTemplate.AllowAddNewRow = false;
            this.GridOrden.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "trad_id";
            gridViewTextBoxColumn1.HeaderText = "trad_id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "trad_id";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "flu_nombre";
            gridViewTextBoxColumn2.HeaderText = "Flujo";
            gridViewTextBoxColumn2.Name = "flu_nombre";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "tra_anio";
            gridViewTextBoxColumn3.HeaderText = "Año";
            gridViewTextBoxColumn3.Name = "tra_anio";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 60;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "tra_semana";
            gridViewTextBoxColumn4.HeaderText = "Semana";
            gridViewTextBoxColumn4.Name = "tra_semana";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 60;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "trad_SACA";
            gridViewTextBoxColumn5.HeaderText = "SACA";
            gridViewTextBoxColumn5.Name = "trad_SACA";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 125;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "trad_producto";
            gridViewTextBoxColumn6.HeaderText = "Producto";
            gridViewTextBoxColumn6.Name = "trad_producto";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 125;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "trad_desviacion";
            gridViewTextBoxColumn7.HeaderText = "Desviación";
            gridViewTextBoxColumn7.Name = "trad_desviacion";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 125;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "trad_cantidad";
            gridViewTextBoxColumn8.HeaderText = "Cantidad";
            gridViewTextBoxColumn8.Name = "trad_cantidad";
            gridViewTextBoxColumn8.Width = 80;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "trad_ubicacion";
            gridViewTextBoxColumn9.HeaderText = "Localidad";
            gridViewTextBoxColumn9.Name = "trad_ubicacion";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "trad_ubicacion_cantidad";
            gridViewTextBoxColumn10.HeaderText = "Cantidad Localidad";
            gridViewTextBoxColumn10.Name = "trad_ubicacion_cantidad";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.Width = 150;
            this.GridOrden.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.GridOrden.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridOrden.Name = "GridOrden";
            this.GridOrden.Padding = new System.Windows.Forms.Padding(1);
            this.GridOrden.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridOrden.Size = new System.Drawing.Size(906, 400);
            this.GridOrden.TabIndex = 4;
            this.GridOrden.ThemeName = "Desert";
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Location = new System.Drawing.Point(473, 40);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(125, 24);
            this.BtnActualizar.TabIndex = 5;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.ThemeName = "Desert";
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Location = new System.Drawing.Point(604, 40);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(125, 24);
            this.BtnImprimir.TabIndex = 6;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.ThemeName = "Desert";
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(342, 40);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(125, 24);
            this.BtnEliminar.TabIndex = 7;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.ThemeName = "Desert";
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.BtnImprimir);
            this.radGroupBox1.Controls.Add(this.BtnEliminar);
            this.radGroupBox1.Controls.Add(this.BtnActualizar);
            this.radGroupBox1.Controls.Add(this.TxtOrden);
            this.radGroupBox1.Controls.Add(this.BtnBuscar);
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(30, 30);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(906, 100);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.ThemeName = "Desert";
            // 
            // ConsOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 602);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.GridOrden);
            this.Name = "ConsOrdenes";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Consultar Ordenes";
            this.ThemeName = "Desert";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrden.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox TxtOrden;
        private Telerik.WinControls.UI.RadButton BtnBuscar;
        private Telerik.WinControls.UI.RadGridView GridOrden;
        private Telerik.WinControls.UI.RadButton BtnActualizar;
        private Telerik.WinControls.UI.RadButton BtnImprimir;
        private Telerik.WinControls.UI.RadButton BtnEliminar;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
