namespace Rmc.Subidas
{
    partial class MantoUsers
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn2 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rpnSuperior = new Telerik.WinControls.UI.RadPanel();
            this.chkSol = new System.Windows.Forms.CheckBox();
            this.LblNombreCompleto = new System.Windows.Forms.Label();
            this.txtReq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rpnInferior = new Telerik.WinControls.UI.RadPanel();
            this.btnEliminar = new Telerik.WinControls.UI.RadButton();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.btnNuevotxtReq = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnGuardartxtReq = new Telerik.WinControls.UI.RadButton();
            this.rgvReq = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rpnSuperior)).BeginInit();
            this.rpnSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpnInferior)).BeginInit();
            this.rpnInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevotxtReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardartxtReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvReq.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rpnSuperior
            // 
            this.rpnSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rpnSuperior.Controls.Add(this.chkSol);
            this.rpnSuperior.Controls.Add(this.LblNombreCompleto);
            this.rpnSuperior.Controls.Add(this.txtReq);
            this.rpnSuperior.Controls.Add(this.label1);
            this.rpnSuperior.Controls.Add(this.label3);
            this.rpnSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.rpnSuperior.Location = new System.Drawing.Point(0, 0);
            this.rpnSuperior.Name = "rpnSuperior";
            this.rpnSuperior.Size = new System.Drawing.Size(1336, 101);
            this.rpnSuperior.TabIndex = 19;
            // 
            // chkSol
            // 
            this.chkSol.AutoSize = true;
            this.chkSol.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSol.ForeColor = System.Drawing.Color.Black;
            this.chkSol.Location = new System.Drawing.Point(521, 49);
            this.chkSol.Name = "chkSol";
            this.chkSol.Size = new System.Drawing.Size(92, 21);
            this.chkSol.TabIndex = 2;
            this.chkSol.Text = "Solicitante";
            this.chkSol.UseVisualStyleBackColor = true;
            // 
            // LblNombreCompleto
            // 
            this.LblNombreCompleto.AutoSize = true;
            this.LblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreCompleto.ForeColor = System.Drawing.Color.White;
            this.LblNombreCompleto.Location = new System.Drawing.Point(128, 75);
            this.LblNombreCompleto.Name = "LblNombreCompleto";
            this.LblNombreCompleto.Size = new System.Drawing.Size(14, 21);
            this.LblNombreCompleto.TabIndex = 17;
            this.LblNombreCompleto.Text = " ";
            // 
            // txtReq
            // 
            this.txtReq.Location = new System.Drawing.Point(126, 50);
            this.txtReq.Name = "txtReq";
            this.txtReq.Size = new System.Drawing.Size(389, 20);
            this.txtReq.TabIndex = 0;
            this.txtReq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReq_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Carné completo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 40);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mantenimiento de solicitante";
            // 
            // rpnInferior
            // 
            this.rpnInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rpnInferior.Controls.Add(this.btnEliminar);
            this.rpnInferior.Controls.Add(this.btnActualizar);
            this.rpnInferior.Controls.Add(this.btnNuevotxtReq);
            this.rpnInferior.Controls.Add(this.btnCancelar);
            this.rpnInferior.Controls.Add(this.btnGuardartxtReq);
            this.rpnInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rpnInferior.Location = new System.Drawing.Point(0, 574);
            this.rpnInferior.Name = "rpnInferior";
            this.rpnInferior.Size = new System.Drawing.Size(1336, 54);
            this.rpnInferior.TabIndex = 20;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEliminar.Location = new System.Drawing.Point(626, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(85, 24);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.ThemeName = "ControlDefault";
            this.btnEliminar.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnActualizar.Location = new System.Drawing.Point(894, 16);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(85, 24);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.ThemeName = "ControlDefault";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnNuevotxtReq
            // 
            this.btnNuevotxtReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevotxtReq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevotxtReq.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnNuevotxtReq.Location = new System.Drawing.Point(985, 16);
            this.btnNuevotxtReq.Name = "btnNuevotxtReq";
            this.btnNuevotxtReq.Size = new System.Drawing.Size(110, 24);
            this.btnNuevotxtReq.TabIndex = 4;
            this.btnNuevotxtReq.Text = "Nuevo";
            this.btnNuevotxtReq.ThemeName = "ControlDefault";
            this.btnNuevotxtReq.Click += new System.EventHandler(this.btnNuevotxtReq_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCancelar.Location = new System.Drawing.Point(1217, 16);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 24);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "ControlDefault";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardartxtReq
            // 
            this.btnGuardartxtReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardartxtReq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardartxtReq.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnGuardartxtReq.Location = new System.Drawing.Point(1101, 16);
            this.btnGuardartxtReq.Name = "btnGuardartxtReq";
            this.btnGuardartxtReq.Size = new System.Drawing.Size(110, 24);
            this.btnGuardartxtReq.TabIndex = 5;
            this.btnGuardartxtReq.Text = "Guardar";
            this.btnGuardartxtReq.ThemeName = "ControlDefault";
            this.btnGuardartxtReq.Click += new System.EventHandler(this.btnGuardartxtReq_Click);
            // 
            // rgvReq
            // 
            this.rgvReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvReq.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgvReq.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rgvReq.ForeColor = System.Drawing.Color.Black;
            this.rgvReq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvReq.Location = new System.Drawing.Point(0, 101);
            // 
            // 
            // 
            this.rgvReq.MasterTemplate.AllowAddNewRow = false;
            this.rgvReq.MasterTemplate.AllowSearchRow = true;
            this.rgvReq.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Codigo";
            gridViewTextBoxColumn6.HeaderText = "Codigo";
            gridViewTextBoxColumn6.Name = "Codigo";
            gridViewTextBoxColumn6.Width = 228;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Nombre";
            gridViewTextBoxColumn7.HeaderText = "Nombre";
            gridViewTextBoxColumn7.Name = "Nombre";
            gridViewTextBoxColumn7.Width = 253;
            gridViewTextBoxColumn8.FieldName = "Turno";
            gridViewTextBoxColumn8.HeaderText = "Turno";
            gridViewTextBoxColumn8.Name = "Turno";
            gridViewTextBoxColumn8.Width = 193;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "ModificadoPor";
            gridViewTextBoxColumn9.HeaderText = "Modificado por";
            gridViewTextBoxColumn9.Name = "ModificadoPor";
            gridViewTextBoxColumn9.Width = 438;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "Fecha";
            gridViewTextBoxColumn10.HeaderText = "Fecha";
            gridViewTextBoxColumn10.Name = "Fecha";
            gridViewTextBoxColumn10.Width = 207;
            gridViewMaskBoxColumn2.EnableExpressionEditor = false;
            gridViewMaskBoxColumn2.FieldName = "CodigoFull";
            gridViewMaskBoxColumn2.HeaderText = "CodigoFull";
            gridViewMaskBoxColumn2.IsVisible = false;
            gridViewMaskBoxColumn2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn2.Name = "CodigoFull";
            this.rgvReq.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewMaskBoxColumn2});
            this.rgvReq.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvReq.Name = "rgvReq";
            this.rgvReq.ReadOnly = true;
            this.rgvReq.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvReq.Size = new System.Drawing.Size(1336, 473);
            this.rgvReq.TabIndex = 21;
            this.rgvReq.ThemeName = "ControlDefault";
            this.rgvReq.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvReq_CellClick);
            // 
            // MantoUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 628);
            this.Controls.Add(this.rgvReq);
            this.Controls.Add(this.rpnInferior);
            this.Controls.Add(this.rpnSuperior);
            this.Name = "MantoUsers";
            this.Text = "MantoUsers";
            this.Load += new System.EventHandler(this.Mantenimiento_de_solicitante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpnSuperior)).EndInit();
            this.rpnSuperior.ResumeLayout(false);
            this.rpnSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpnInferior)).EndInit();
            this.rpnInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNuevotxtReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardartxtReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvReq.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel rpnSuperior;
        private System.Windows.Forms.CheckBox chkSol;
        private System.Windows.Forms.Label LblNombreCompleto;
        private System.Windows.Forms.TextBox txtReq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadPanel rpnInferior;
        private Telerik.WinControls.UI.RadButton btnActualizar;
        private Telerik.WinControls.UI.RadButton btnNuevotxtReq;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadButton btnGuardartxtReq;
        private Telerik.WinControls.UI.RadGridView rgvReq;
        private Telerik.WinControls.UI.RadButton btnEliminar;
    }
}
