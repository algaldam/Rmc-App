namespace Rmc.Subidas
{
    partial class frmSobrantes
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn2 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label6 = new System.Windows.Forms.Label();
            this.CbxSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.pmcSemanasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.GridViewSobrantes = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSobrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSobrantes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(212, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 0;
            // 
            // CbxSemana
            // 
            this.CbxSemana.DataSource = this.pmcSemanasBindingSource;
            this.CbxSemana.DisplayMember = "sem_ID";
            this.CbxSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxSemana.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.CbxSemana.Location = new System.Drawing.Point(689, 74);
            this.CbxSemana.Name = "CbxSemana";
            this.CbxSemana.Size = new System.Drawing.Size(156, 29);
            this.CbxSemana.TabIndex = 21;
            this.CbxSemana.ValueMember = "sem_ID";
            // 
            // pmcSemanasBindingSource
            // 
            this.pmcSemanasBindingSource.DataSource = typeof(Rmc.Clases.pmc_Semanas);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(615, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Semana";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(408, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Carga de Sobrantes";
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(850, 237);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(236, 42);
            this.LblError.TabIndex = 46;
            this.LblError.Text = "No es posible cargar Sobrantes,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(885, 466);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 44;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(885, 442);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(82, 18);
            this.radLabel5.TabIndex = 45;
            this.radLabel5.Text = "* Fuera de Plan";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Tomato;
            this.radLabel3.Location = new System.Drawing.Point(848, 442);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(31, 18);
            this.radLabel3.TabIndex = 42;
            this.radLabel3.Text = "        ";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(848, 466);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 43;
            this.radLabel2.Text = "        ";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(565, 500);
            this.BtnGuardar.Name = "BtnGuardar";
            // 
            // 
            // 
            this.BtnGuardar.RootElement.EnableElementShadow = true;
            this.BtnGuardar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.Size = new System.Drawing.Size(137, 30);
            this.BtnGuardar.TabIndex = 41;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(708, 500);
            this.BtnLimpiar.Name = "BtnLimpiar";
            // 
            // 
            // 
            this.BtnLimpiar.RootElement.EnableElementShadow = true;
            this.BtnLimpiar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.Size = new System.Drawing.Size(137, 30);
            this.BtnLimpiar.TabIndex = 40;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            // 
            // GridViewSobrantes
            // 
            this.GridViewSobrantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewSobrantes.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewSobrantes.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridViewSobrantes.ForeColor = System.Drawing.Color.Black;
            this.GridViewSobrantes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewSobrantes.Location = new System.Drawing.Point(96, 116);
            this.GridViewSobrantes.Margin = new System.Windows.Forms.Padding(118);
            // 
            // 
            // 
            this.GridViewSobrantes.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewSobrantes.MasterTemplate.AllowDragToGroup = false;
            this.GridViewSobrantes.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.FieldName = "pla_SACA";
            gridViewTextBoxColumn4.HeaderText = "SA/CA";
            gridViewTextBoxColumn4.MinWidth = 200;
            gridViewTextBoxColumn4.Name = "pla_SACA";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 237;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Item";
            gridViewTextBoxColumn5.HeaderText = "Producto";
            gridViewTextBoxColumn5.MinWidth = 200;
            gridViewTextBoxColumn5.Name = "Item";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 234;
            gridViewMaskBoxColumn2.DataType = typeof(int);
            gridViewMaskBoxColumn2.EnableExpressionEditor = false;
            gridViewMaskBoxColumn2.FieldName = "Cantidad";
            gridViewMaskBoxColumn2.HeaderText = "Sobrante";
            gridViewMaskBoxColumn2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn2.MinWidth = 200;
            gridViewMaskBoxColumn2.Name = "Cantidad";
            gridViewMaskBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn2.Width = 259;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "ESTADO";
            gridViewTextBoxColumn6.HeaderText = "ESTADO";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.MinWidth = 12;
            gridViewTextBoxColumn6.Name = "ESTADO";
            gridViewTextBoxColumn6.Width = 112;
            this.GridViewSobrantes.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewMaskBoxColumn2,
            gridViewTextBoxColumn6});
            this.GridViewSobrantes.MasterTemplate.EnableGrouping = false;
            this.GridViewSobrantes.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GridViewSobrantes.Name = "GridViewSobrantes";
            this.GridViewSobrantes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewSobrantes.Size = new System.Drawing.Size(749, 373);
            this.GridViewSobrantes.TabIndex = 39;
            this.GridViewSobrantes.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewSobrantes_RowFormatting);
            this.GridViewSobrantes.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewSobrantes_CellFormatting);
            // 
            // frmSobrantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1101, 575);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.GridViewSobrantes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbxSemana);
            this.Controls.Add(this.label5);
            this.Name = "frmSobrantes";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Carga Sobrantes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSobrantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSobrantes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSobrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadDropDownList CbxSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        
        private Telerik.WinControls.UI.RadLabel LblError;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadButton BtnLimpiar;
        private Telerik.WinControls.UI.RadGridView GridViewSobrantes;
        private System.Windows.Forms.BindingSource pmcSemanasBindingSource;
    }
}
