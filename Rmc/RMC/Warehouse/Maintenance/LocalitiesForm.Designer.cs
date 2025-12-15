namespace Rmc.RMC.Warehouse.Maintenance
{
    partial class LocalitiesForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtNombre = new Telerik.WinControls.UI.RadTextBox();
            this.rgvLocalidades = new Telerik.WinControls.UI.RadGridView();
            this.btnNuevo = new Telerik.WinControls.UI.RadButton();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.btnEliminar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLocalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLocalidades.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
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
            this.radPanel1.Size = new System.Drawing.Size(1231, 56);
            this.radPanel1.TabIndex = 16;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(510, 46);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mantenimiento de Localidades\r\n";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(77, 140);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(202, 26);
            this.radLabel1.TabIndex = 17;
            this.radLabel1.Text = "Nombre de la Localidad";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(77, 174);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(428, 32);
            this.txtNombre.TabIndex = 18;
            // 
            // rgvLocalidades
            // 
            this.rgvLocalidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rgvLocalidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvLocalidades.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvLocalidades.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvLocalidades.ForeColor = System.Drawing.Color.Black;
            this.rgvLocalidades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvLocalidades.Location = new System.Drawing.Point(548, 62);
            // 
            // 
            // 
            this.rgvLocalidades.MasterTemplate.AllowAddNewRow = false;
            this.rgvLocalidades.MasterTemplate.AllowDeleteRow = false;
            this.rgvLocalidades.MasterTemplate.AllowEditRow = false;
            this.rgvLocalidades.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "loc_id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.Name = "loc_id";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 132;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "loc_nombre";
            gridViewTextBoxColumn2.HeaderText = "Nombre";
            gridViewTextBoxColumn2.Name = "loc_nombre";
            gridViewTextBoxColumn2.Width = 510;
            this.rgvLocalidades.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.rgvLocalidades.MasterTemplate.EnableFiltering = true;
            this.rgvLocalidades.MasterTemplate.EnableGrouping = false;
            this.rgvLocalidades.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvLocalidades.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvLocalidades.Name = "rgvLocalidades";
            this.rgvLocalidades.Padding = new System.Windows.Forms.Padding(1);
            this.rgvLocalidades.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvLocalidades.Size = new System.Drawing.Size(683, 494);
            this.rgvLocalidades.TabIndex = 19;
            this.rgvLocalidades.ThemeName = "TelerikMetroBlue";
            this.rgvLocalidades.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvAreas_CellDoubleClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "btnNuevo";
            this.btnNuevo.AccessibleName = "btnNuevo";
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::Rmc.Properties.Resources.agregar;
            this.btnNuevo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevo.Location = new System.Drawing.Point(150, 413);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(146, 56);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "Nueva";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNuevo.ThemeName = "TelerikMetroBlue";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleDescription = "btnGuardar";
            this.btnGuardar.AccessibleName = "btnGuardar";
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::Rmc.Properties.Resources.disquete;
            this.btnGuardar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.Location = new System.Drawing.Point(315, 413);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(146, 56);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.ThemeName = "TelerikMetroBlue";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.AccessibleDescription = "btnActualizar";
            this.btnActualizar.AccessibleName = "btnActualizar";
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = global::Rmc.Properties.Resources.comprobado;
            this.btnActualizar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActualizar.Location = new System.Drawing.Point(77, 481);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(146, 56);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnActualizar.ThemeName = "TelerikMetroBlue";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AccessibleDescription = "btnEliminar";
            this.btnEliminar.AccessibleName = "btnEliminar";
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::Rmc.Properties.Resources.borrar;
            this.btnEliminar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Location = new System.Drawing.Point(233, 481);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 56);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEliminar.ThemeName = "TelerikMetroBlue";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = "btnCancelar";
            this.btnCancelar.AccessibleName = "btnCancelar";
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::Rmc.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(366, 481);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(146, 56);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.ThemeName = "TelerikMetroBlue";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // LocalitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 558);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.rgvLocalidades);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radPanel1);
            this.Name = "LocalitiesForm";
            this.Text = "Localidades";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLocalidades.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvLocalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtNombre;
        private Telerik.WinControls.UI.RadGridView rgvLocalidades;
        private Telerik.WinControls.UI.RadButton btnNuevo;
        private Telerik.WinControls.UI.RadButton btnGuardar;
        private Telerik.WinControls.UI.RadButton btnActualizar;
        private Telerik.WinControls.UI.RadButton btnEliminar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
    }
}
