namespace Rmc.Subidas
{
    partial class frmCargarPendientes
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn3 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn4 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.CbxSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.GridViewApartado = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewApartado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewApartado.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CbxSemana
            // 
            this.CbxSemana.DisplayMember = "sem_ID";
            this.CbxSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxSemana.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.CbxSemana.Location = new System.Drawing.Point(836, 94);
            this.CbxSemana.Name = "CbxSemana";
            this.CbxSemana.Size = new System.Drawing.Size(156, 25);
            this.CbxSemana.TabIndex = 20;
            this.CbxSemana.ValueMember = "sem_ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(774, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Semana";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Carga de Cantidades Apartadas";
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(80, 545);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(235, 42);
            this.LblError.TabIndex = 30;
            this.LblError.Text = "No es posible cargar,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(713, 545);
            this.BtnGuardar.Name = "BtnGuardar";
            // 
            // 
            // 
            this.BtnGuardar.RootElement.EnableElementShadow = true;
            this.BtnGuardar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.Size = new System.Drawing.Size(137, 30);
            this.BtnGuardar.TabIndex = 29;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).Text = "Guardar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(856, 545);
            this.BtnLimpiar.Name = "BtnLimpiar";
            // 
            // 
            // 
            this.BtnLimpiar.RootElement.EnableElementShadow = true;
            this.BtnLimpiar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.Size = new System.Drawing.Size(137, 30);
            this.BtnLimpiar.TabIndex = 28;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            // 
            // GridViewApartado
            // 
            this.GridViewApartado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewApartado.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewApartado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridViewApartado.ForeColor = System.Drawing.Color.Black;
            this.GridViewApartado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewApartado.Location = new System.Drawing.Point(101, 127);
            this.GridViewApartado.Margin = new System.Windows.Forms.Padding(118);
            // 
            // 
            // 
            this.GridViewApartado.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewApartado.MasterTemplate.AllowDragToGroup = false;
            this.GridViewApartado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Item";
            gridViewTextBoxColumn4.HeaderText = "Producto";
            gridViewTextBoxColumn4.MinWidth = 200;
            gridViewTextBoxColumn4.Name = "Item";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 212;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "mov_det_desv";
            gridViewTextBoxColumn5.HeaderText = "Desviación";
            gridViewTextBoxColumn5.MinWidth = 200;
            gridViewTextBoxColumn5.Name = "mov_det_desv";
            gridViewTextBoxColumn5.Width = 212;
            gridViewMaskBoxColumn3.DataType = typeof(int);
            gridViewMaskBoxColumn3.EnableExpressionEditor = false;
            gridViewMaskBoxColumn3.FieldName = "mov_det_cant";
            gridViewMaskBoxColumn3.HeaderText = "Cantidad Original";
            gridViewMaskBoxColumn3.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn3.MinWidth = 200;
            gridViewMaskBoxColumn3.Name = "mov_det_cant";
            gridViewMaskBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn3.Width = 212;
            gridViewMaskBoxColumn4.EnableExpressionEditor = false;
            gridViewMaskBoxColumn4.FieldName = "mov_det_cant_desv";
            gridViewMaskBoxColumn4.HeaderText = "Cantidad Desviación";
            gridViewMaskBoxColumn4.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn4.MinWidth = 225;
            gridViewMaskBoxColumn4.Name = "mov_det_cant_desv";
            gridViewMaskBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn4.Width = 238;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "ESTADO";
            gridViewTextBoxColumn6.HeaderText = "ESTADO";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.MinWidth = 12;
            gridViewTextBoxColumn6.Name = "ESTADO";
            gridViewTextBoxColumn6.Width = 112;
            this.GridViewApartado.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewMaskBoxColumn3,
            gridViewMaskBoxColumn4,
            gridViewTextBoxColumn6});
            this.GridViewApartado.MasterTemplate.EnableGrouping = false;
            this.GridViewApartado.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GridViewApartado.Name = "GridViewApartado";
            this.GridViewApartado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewApartado.Size = new System.Drawing.Size(892, 402);
            this.GridViewApartado.TabIndex = 31;
            this.GridViewApartado.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewApartado_RowFormatting);
            this.GridViewApartado.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewApartado_CellFormatting);
            this.GridViewApartado.PastingCellClipboardContent += new Telerik.WinControls.UI.GridViewCellValueEventHandler(this.GridViewApartado_PastingCellClipboardContent);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Red;
            this.radLabel1.Location = new System.Drawing.Point(995, 488);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 18);
            this.radLabel1.TabIndex = 33;
            this.radLabel1.Text = "        ";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(1032, 488);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(115, 18);
            this.radLabel5.TabIndex = 32;
            this.radLabel5.Text = "* Fuera de Pendientes";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(1032, 512);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 44;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(995, 512);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 43;
            this.radLabel2.Text = "        ";
            // 
            // frmCargarPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1174, 625);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.GridViewApartado);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbxSemana);
            this.Controls.Add(this.label5);
            this.Name = "frmCargarPendientes";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Carga Apartado";
            this.Enter += new System.EventHandler(this.FrmCargarPendientes_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewApartado.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewApartado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList CbxSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadLabel LblError;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadButton BtnLimpiar;
        private Telerik.WinControls.UI.RadGridView GridViewApartado;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
