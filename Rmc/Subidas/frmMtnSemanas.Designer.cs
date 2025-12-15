namespace Rmc.Subidas
{
    partial class frmMtnSemanas
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GridViewSemanas = new Telerik.WinControls.UI.RadGridView();
            this.pmcSemanasDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.ChkEstado = new Telerik.WinControls.UI.RadCheckBox();
            this.TxtAnio = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.TxtSemana = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.Lbl_ID = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.BtnCancelar = new Telerik.WinControls.UI.RadButton();
            this.BtnEliminar = new Telerik.WinControls.UI.RadButton();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnNuevo = new Telerik.WinControls.UI.RadButton();
            this.POP_ALERT = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSemanas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSemanas.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNuevo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewSemanas
            // 
            this.GridViewSemanas.Location = new System.Drawing.Point(38, 163);
            // 
            // 
            // 
            this.GridViewSemanas.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewSemanas.MasterTemplate.AllowAddNewRow = false;
            this.GridViewSemanas.MasterTemplate.AllowDeleteRow = false;
            this.GridViewSemanas.MasterTemplate.AllowEditRow = false;
            this.GridViewSemanas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(string);
            gridViewDecimalColumn1.FieldName = "sem_ID";
            gridViewDecimalColumn1.HeaderText = "Semana";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.MinWidth = 180;
            gridViewDecimalColumn1.Name = "sem_ID";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 181;
            gridViewTextBoxColumn1.FieldName = "sem_usuario_crea";
            gridViewTextBoxColumn1.HeaderText = "sem_usuario_crea";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.MinWidth = 120;
            gridViewTextBoxColumn1.Name = "sem_usuario_crea";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 120;
            gridViewDateTimeColumn1.FieldName = "sem_FH_mod";
            gridViewDateTimeColumn1.HeaderText = "Fecha mod";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.IsVisible = false;
            gridViewDateTimeColumn1.MinWidth = 120;
            gridViewDateTimeColumn1.Name = "sem_FH_mod";
            gridViewDateTimeColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn1.Width = 120;
            gridViewTextBoxColumn2.FieldName = "sem_usuario_mod";
            gridViewTextBoxColumn2.HeaderText = "sem_usuario_mod";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.MinWidth = 120;
            gridViewTextBoxColumn2.Name = "sem_usuario_mod";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 120;
            gridViewCheckBoxColumn1.FieldName = "sem_estado";
            gridViewCheckBoxColumn1.HeaderText = "Estado";
            gridViewCheckBoxColumn1.IsAutoGenerated = true;
            gridViewCheckBoxColumn1.MinWidth = 120;
            gridViewCheckBoxColumn1.Name = "sem_estado";
            gridViewCheckBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn1.Width = 254;
            gridViewTextBoxColumn3.FieldName = "ANIO";
            gridViewTextBoxColumn3.HeaderText = "ANIO";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.MinWidth = 120;
            gridViewTextBoxColumn3.Name = "ANIO";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.FieldName = "SEMANA";
            gridViewTextBoxColumn4.HeaderText = "SEMANA";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.MinWidth = 120;
            gridViewTextBoxColumn4.Name = "SEMANA";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 120;
            gridViewTextBoxColumn5.FieldName = "USUARIO_CREA";
            gridViewTextBoxColumn5.HeaderText = "Usuario Crea";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.MinWidth = 120;
            gridViewTextBoxColumn5.Name = "USUARIO_CREA";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 256;
            gridViewTextBoxColumn6.FieldName = "USUARIO_MODIFICA";
            gridViewTextBoxColumn6.HeaderText = "USUARIO_MODIFICA";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.MinWidth = 120;
            gridViewTextBoxColumn6.Name = "USUARIO_MODIFICA";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 166;
            gridViewDateTimeColumn2.FieldName = "sem_FH_crea";
            gridViewDateTimeColumn2.HeaderText = "Fecha";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.MinWidth = 120;
            gridViewDateTimeColumn2.Name = "sem_FH_crea";
            gridViewDateTimeColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn2.Width = 179;
            this.GridViewSemanas.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewDateTimeColumn2});
            this.GridViewSemanas.MasterTemplate.DataSource = this.pmcSemanasDataTableBindingSource;
            this.GridViewSemanas.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridViewSemanas.MasterTemplate.EnableFiltering = true;
            this.GridViewSemanas.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridViewSemanas.Name = "GridViewSemanas";
            this.GridViewSemanas.ReadOnly = true;
            this.GridViewSemanas.Size = new System.Drawing.Size(888, 418);
            this.GridViewSemanas.TabIndex = 0;
            this.GridViewSemanas.Click += new System.EventHandler(this.GridViewSemanas_Click);
            // 
            // pmcSemanasDataTableBindingSource
            // 
            this.pmcSemanasDataTableBindingSource.DataSource = typeof(Rmc.Clases.dsPMC.pmc_SemanasDataTable);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(64, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(34, 22);
            this.radLabel1.TabIndex = 20;
            this.radLabel1.Text = "Año";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(372, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mantenimiento de Semanas";
            // 
            // ChkEstado
            // 
            this.ChkEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkEstado.Location = new System.Drawing.Point(357, 39);
            this.ChkEstado.Name = "ChkEstado";
            this.ChkEstado.Size = new System.Drawing.Size(72, 22);
            this.ChkEstado.TabIndex = 12;
            this.ChkEstado.Text = "Estado";
            ((Telerik.WinControls.UI.RadCheckBoxElement)(this.ChkEstado.GetChildAt(0))).Text = "Estado";
            ((Telerik.WinControls.Primitives.CheckPrimitive)(this.ChkEstado.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(2))).MinSize = new System.Drawing.Size(20, 20);
            // 
            // TxtAnio
            // 
            this.TxtAnio.Enabled = false;
            this.TxtAnio.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAnio.Location = new System.Drawing.Point(3, 29);
            this.TxtAnio.Mask = "D4";
            this.TxtAnio.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.TxtAnio.Name = "TxtAnio";
            this.TxtAnio.Size = new System.Drawing.Size(153, 39);
            this.TxtAnio.TabIndex = 1;
            this.TxtAnio.TabStop = false;
            this.TxtAnio.Text = "0000";
            this.TxtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAnio_KeyPress);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(231, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(59, 22);
            this.radLabel2.TabIndex = 50;
            this.radLabel2.Text = "Semana";
            // 
            // TxtSemana
            // 
            this.TxtSemana.Enabled = false;
            this.TxtSemana.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSemana.Location = new System.Drawing.Point(175, 29);
            this.TxtSemana.Mask = "D2";
            this.TxtSemana.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.TxtSemana.Name = "TxtSemana";
            this.TxtSemana.Size = new System.Drawing.Size(156, 39);
            this.TxtSemana.TabIndex = 2;
            this.TxtSemana.TabStop = false;
            this.TxtSemana.Text = "00";
            this.TxtSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtSemana.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSemana_KeyPress);
            // 
            // Lbl_ID
            // 
            this.Lbl_ID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ID.Location = new System.Drawing.Point(53, 84);
            this.Lbl_ID.Name = "Lbl_ID";
            this.Lbl_ID.Size = new System.Drawing.Size(34, 22);
            this.Lbl_ID.TabIndex = 18;
            this.Lbl_ID.Text = "Año";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.BtnCancelar);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.TxtSemana);
            this.radPanel1.Controls.Add(this.ChkEstado);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.TxtAnio);
            this.radPanel1.Controls.Add(this.BtnEliminar);
            this.radPanel1.Controls.Add(this.BtnGuardar);
            this.radPanel1.Controls.Add(this.BtnNuevo);
            this.radPanel1.Location = new System.Drawing.Point(38, 80);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(886, 77);
            this.radPanel1.TabIndex = 18;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::Rmc.Properties.Resources.cancel;
            this.BtnCancelar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCancelar.Location = new System.Drawing.Point(775, 29);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(50, 36);
            this.BtnCancelar.TabIndex = 51;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Image = global::Rmc.Properties.Resources.delete;
            this.BtnEliminar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnEliminar.Location = new System.Drawing.Point(832, 29);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(50, 36);
            this.BtnEliminar.TabIndex = 5;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::Rmc.Properties.Resources.saveal;
            this.BtnGuardar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnGuardar.Location = new System.Drawing.Point(718, 29);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(50, 36);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::Rmc.Properties.Resources.new1;
            this.BtnNuevo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnNuevo.Location = new System.Drawing.Point(661, 29);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(50, 36);
            this.BtnNuevo.TabIndex = 4;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // POP_ALERT
            // 
            this.POP_ALERT.AutoCloseDelay = 2;
            this.POP_ALERT.FadeAnimationFrames = 10;
            this.POP_ALERT.PopupAnimationFrames = 10;
            this.POP_ALERT.ShowOptionsButton = false;
            this.POP_ALERT.ShowPinButton = false;
            this.POP_ALERT.ThemeName = "Windows8";
            // 
            // frmMtnSemanas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(970, 604);
            this.Controls.Add(this.Lbl_ID);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GridViewSemanas);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "frmMtnSemanas";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Mantemiento Semanas";
            this.Load += new System.EventHandler(this.frmMtnSemanas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSemanas.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSemanas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbl_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNuevo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GridViewSemanas;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadCheckBox ChkEstado;
        private Telerik.WinControls.UI.RadMaskedEditBox TxtAnio;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadButton BtnNuevo;
        private Telerik.WinControls.UI.RadButton BtnEliminar;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMaskedEditBox TxtSemana;
        private Telerik.WinControls.UI.RadLabel Lbl_ID;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.BindingSource pmcSemanasDataTableBindingSource;
        private Telerik.WinControls.UI.RadButton BtnCancelar;
        private Telerik.WinControls.UI.RadDesktopAlert POP_ALERT;
    }
}
