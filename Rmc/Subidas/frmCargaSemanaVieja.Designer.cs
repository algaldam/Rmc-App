namespace Rmc.Subidas
{
    partial class frmCargaSemanaVieja
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
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn2 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GridViewAntiguo = new Telerik.WinControls.UI.RadGridView();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.label6 = new System.Windows.Forms.Label();
            this.CbxSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAntiguo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAntiguo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewAntiguo
            // 
            this.GridViewAntiguo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewAntiguo.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewAntiguo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GridViewAntiguo.ForeColor = System.Drawing.Color.Black;
            this.GridViewAntiguo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewAntiguo.Location = new System.Drawing.Point(101, 127);
            this.GridViewAntiguo.Margin = new System.Windows.Forms.Padding(118);
            // 
            // 
            // 
            this.GridViewAntiguo.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewAntiguo.MasterTemplate.AllowDragToGroup = false;
            this.GridViewAntiguo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Item";
            gridViewTextBoxColumn1.HeaderText = "Producto";
            gridViewTextBoxColumn1.MinWidth = 230;
            gridViewTextBoxColumn1.Name = "Item";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 230;
            gridViewTextBoxColumn2.FieldName = "mov_item_desv";
            gridViewTextBoxColumn2.HeaderText = "Desviación";
            gridViewTextBoxColumn2.MinWidth = 230;
            gridViewTextBoxColumn2.Name = "mov_item_desv";
            gridViewTextBoxColumn2.Width = 230;
            gridViewMaskBoxColumn1.DataType = typeof(int);
            gridViewMaskBoxColumn1.EnableExpressionEditor = false;
            gridViewMaskBoxColumn1.FieldName = "mov_cantidad_vieja";
            gridViewMaskBoxColumn1.HeaderText = "Cantidad";
            gridViewMaskBoxColumn1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn1.MinWidth = 230;
            gridViewMaskBoxColumn1.Name = "mov_cantidad_vieja";
            gridViewMaskBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn1.Width = 269;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ESTADO";
            gridViewTextBoxColumn3.HeaderText = "ESTADO";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.MinWidth = 12;
            gridViewTextBoxColumn3.Name = "ESTADO";
            gridViewTextBoxColumn3.Width = 112;
            gridViewMaskBoxColumn2.FieldName = "mov_cantidad_vieja_desc";
            gridViewMaskBoxColumn2.HeaderText = "Cantidad Desviación";
            gridViewMaskBoxColumn2.MinWidth = 230;
            gridViewMaskBoxColumn2.Name = "mov_cantidad_vieja_desc";
            gridViewMaskBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn2.Width = 231;
            this.GridViewAntiguo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewMaskBoxColumn1,
            gridViewTextBoxColumn3,
            gridViewMaskBoxColumn2});
            this.GridViewAntiguo.MasterTemplate.EnableGrouping = false;
            this.GridViewAntiguo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridViewAntiguo.Name = "GridViewAntiguo";
            this.GridViewAntiguo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewAntiguo.Size = new System.Drawing.Size(978, 402);
            this.GridViewAntiguo.TabIndex = 38;
            this.GridViewAntiguo.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewAntiguo_RowFormatting);
            this.GridViewAntiguo.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewAntiguo_CellFormatting);
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(101, 545);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(235, 42);
            this.LblError.TabIndex = 37;
            this.LblError.Text = "No es posible cargar,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(800, 545);
            this.BtnGuardar.Name = "BtnGuardar";
            // 
            // 
            // 
            this.BtnGuardar.RootElement.EnableElementShadow = true;
            this.BtnGuardar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.Size = new System.Drawing.Size(137, 30);
            this.BtnGuardar.TabIndex = 36;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(943, 545);
            this.BtnLimpiar.Name = "BtnLimpiar";
            // 
            // 
            // 
            this.BtnLimpiar.RootElement.EnableElementShadow = true;
            this.BtnLimpiar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.Size = new System.Drawing.Size(137, 30);
            this.BtnLimpiar.TabIndex = 35;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(375, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Carga  de Cantidades  Apartadas en Semana Antigua";
            // 
            // CbxSemana
            // 
            this.CbxSemana.DisplayMember = "sem_ID";
            this.CbxSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxSemana.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.CbxSemana.Location = new System.Drawing.Point(920, 98);
            this.CbxSemana.Name = "CbxSemana";
            this.CbxSemana.Size = new System.Drawing.Size(156, 25);
            this.CbxSemana.TabIndex = 33;
            this.CbxSemana.ValueMember = "sem_ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(856, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 32;
            this.label5.Text = "Semana";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Red;
            this.radLabel1.Location = new System.Drawing.Point(1086, 488);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 18);
            this.radLabel1.TabIndex = 40;
            this.radLabel1.Text = "        ";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(1122, 488);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(115, 18);
            this.radLabel5.TabIndex = 39;
            this.radLabel5.Text = "* Fuera de Pendientes";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(1123, 512);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 42;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(1086, 512);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 41;
            this.radLabel2.Text = "        ";
            // 
            // frmCargaSemanaVieja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 625);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.GridViewAntiguo);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbxSemana);
            this.Controls.Add(this.label5);
            this.MinimumSize = new System.Drawing.Size(1096, 655);
            this.Name = "frmCargaSemanaVieja";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Carga Semana Anterior";
            this.Load += new System.EventHandler(this.FrmCargaSemanaVieja_Load);
            this.Enter += new System.EventHandler(this.FrmCargaSemanaVieja_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAntiguo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAntiguo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GridViewAntiguo;
        private Telerik.WinControls.UI.RadLabel LblError;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadButton BtnLimpiar;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadDropDownList CbxSemana;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
