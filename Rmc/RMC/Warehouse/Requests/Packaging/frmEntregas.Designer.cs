namespace Rmc.Subidas
{
    partial class frmEntregas
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.GridViewEntrega = new Telerik.WinControls.UI.RadGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.POP_ALERT = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewEntrega.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(128, 513);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(235, 42);
            this.LblError.TabIndex = 38;
            this.LblError.Text = "No es posible cargar entregas,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(951, 478);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 36;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(951, 454);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(60, 18);
            this.radLabel5.TabIndex = 37;
            this.radLabel5.Text = "* No Existe";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Tomato;
            this.radLabel3.Location = new System.Drawing.Point(914, 454);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(31, 18);
            this.radLabel3.TabIndex = 34;
            this.radLabel3.Text = "        ";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(914, 478);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 35;
            this.radLabel2.Text = "        ";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.AutoScroll = true;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(622, 513);
            this.BtnGuardar.Name = "BtnGuardar";
            // 
            // 
            // 
            this.BtnGuardar.RootElement.EnableElementShadow = true;
            this.BtnGuardar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.Size = new System.Drawing.Size(137, 30);
            this.BtnGuardar.TabIndex = 33;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(765, 513);
            this.BtnLimpiar.Name = "BtnLimpiar";
            // 
            // 
            // 
            this.BtnLimpiar.RootElement.EnableElementShadow = true;
            this.BtnLimpiar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.Size = new System.Drawing.Size(137, 30);
            this.BtnLimpiar.TabIndex = 32;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            // 
            // GridViewEntrega
            // 
            this.GridViewEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewEntrega.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewEntrega.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridViewEntrega.ForeColor = System.Drawing.Color.Black;
            this.GridViewEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewEntrega.Location = new System.Drawing.Point(44, 129);
            this.GridViewEntrega.Margin = new System.Windows.Forms.Padding(231);
            // 
            // 
            // 
            this.GridViewEntrega.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewEntrega.MasterTemplate.AllowDragToGroup = false;
            this.GridViewEntrega.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "sol_ID";
            gridViewDecimalColumn1.HeaderText = "Solicitud";
            gridViewDecimalColumn1.MinWidth = 8;
            gridViewDecimalColumn1.Name = "sol_ID";
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 155;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "sol_SACA";
            gridViewTextBoxColumn1.HeaderText = "SACA";
            gridViewTextBoxColumn1.MinWidth = 0;
            gridViewTextBoxColumn1.Name = "sol_SACA";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 232;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Item";
            gridViewTextBoxColumn2.HeaderText = "Producto";
            gridViewTextBoxColumn2.MinWidth = 0;
            gridViewTextBoxColumn2.Name = "Item";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 214;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "Cantidad";
            gridViewDecimalColumn2.HeaderText = "Cantidad";
            gridViewDecimalColumn2.MinWidth = 6;
            gridViewDecimalColumn2.Name = "Cantidad";
            gridViewDecimalColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn2.Width = 239;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "sol_item_desv";
            gridViewTextBoxColumn3.HeaderText = "Desviación";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.MinWidth = 312;
            gridViewTextBoxColumn3.Name = "sol_item_desv";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 332;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ESTADO";
            gridViewTextBoxColumn4.HeaderText = "ESTADO";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.MinWidth = 24;
            gridViewTextBoxColumn4.Name = "ESTADO";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 219;
            this.GridViewEntrega.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.GridViewEntrega.MasterTemplate.EnableGrouping = false;
            this.GridViewEntrega.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridViewEntrega.Name = "GridViewEntrega";
            this.GridViewEntrega.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewEntrega.Size = new System.Drawing.Size(858, 373);
            this.GridViewEntrega.TabIndex = 31;
            this.GridViewEntrega.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewEntrega_RowFormatting);
            this.GridViewEntrega.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewEntrega_CellFormatting);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(433, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Entregas Diarias";
            // 
            // POP_ALERT
            // 
            this.POP_ALERT.AutoCloseDelay = 3;
            this.POP_ALERT.FadeAnimationFrames = 10;
            this.POP_ALERT.PopupAnimationFrames = 10;
            this.POP_ALERT.ShowOptionsButton = false;
            this.POP_ALERT.ShowPinButton = false;
            this.POP_ALERT.ThemeName = "";
            // 
            // frmEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 587);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.GridViewEntrega);
            this.Controls.Add(this.label6);
            this.Name = "frmEntregas";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregas Diarias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEntregas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewEntrega.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel LblError;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadButton BtnLimpiar;
        private Telerik.WinControls.UI.RadGridView GridViewEntrega;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadDesktopAlert POP_ALERT;
    }
}
