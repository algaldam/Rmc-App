using Rmc;

namespace Rmc.Subidas
{
    partial class frmCargaSolicitudesEPC
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.GridViewSolicitud = new Telerik.WinControls.UI.RadGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.CbxSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.pmcSemanasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(58, 500);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(241, 42);
            this.LblError.TabIndex = 38;
            this.LblError.Text = "No es posible cargar Solicitudes,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(963, 469);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 36;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(963, 444);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(89, 18);
            this.radLabel5.TabIndex = 37;
            this.radLabel5.Text = "* Sobreconsumo";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Gold;
            this.radLabel3.Location = new System.Drawing.Point(926, 445);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(31, 18);
            this.radLabel3.TabIndex = 34;
            this.radLabel3.Text = "        ";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(926, 469);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 35;
            this.radLabel2.Text = "        ";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(631, 500);
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
            this.BtnLimpiar.Location = new System.Drawing.Point(774, 500);
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
            // GridViewSolicitud
            // 
            this.GridViewSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewSolicitud.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewSolicitud.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridViewSolicitud.ForeColor = System.Drawing.Color.Black;
            this.GridViewSolicitud.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewSolicitud.Location = new System.Drawing.Point(52, 116);
            this.GridViewSolicitud.Margin = new System.Windows.Forms.Padding(118);
            // 
            // 
            // 
            this.GridViewSolicitud.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewSolicitud.MasterTemplate.AllowDragToGroup = false;
            this.GridViewSolicitud.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "sol_SACA";
            gridViewTextBoxColumn1.HeaderText = "SA/CA";
            gridViewTextBoxColumn1.MinWidth = 200;
            gridViewTextBoxColumn1.Name = "sol_SACA";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 211;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Item";
            gridViewTextBoxColumn2.HeaderText = "Producto";
            gridViewTextBoxColumn2.MinWidth = 200;
            gridViewTextBoxColumn2.Name = "Item";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 211;
            gridViewMaskBoxColumn1.DataType = typeof(int);
            gridViewMaskBoxColumn1.EnableExpressionEditor = false;
            gridViewMaskBoxColumn1.FieldName = "Cantidad";
            gridViewMaskBoxColumn1.HeaderText = "Cantidad";
            gridViewMaskBoxColumn1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn1.MinWidth = 200;
            gridViewMaskBoxColumn1.Name = "Cantidad";
            gridViewMaskBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn1.Width = 212;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ESTADO";
            gridViewTextBoxColumn3.HeaderText = "ESTADO";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.MinWidth = 12;
            gridViewTextBoxColumn3.Name = "ESTADO";
            gridViewTextBoxColumn3.Width = 112;
            gridViewCheckBoxColumn1.FieldName = "SOBRE_CONSUMO";
            gridViewCheckBoxColumn1.HeaderText = "Sobreconsumo";
            gridViewCheckBoxColumn1.MinWidth = 130;
            gridViewCheckBoxColumn1.Name = "SOBRE_CONSUMO";
            gridViewCheckBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn1.Width = 208;
            this.GridViewSolicitud.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewMaskBoxColumn1,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1});
            this.GridViewSolicitud.MasterTemplate.EnableGrouping = false;
            this.GridViewSolicitud.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridViewSolicitud.Name = "GridViewSolicitud";
            this.GridViewSolicitud.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewSolicitud.Size = new System.Drawing.Size(860, 373);
            this.GridViewSolicitud.TabIndex = 31;
            this.GridViewSolicitud.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewSolicitud_RowFormatting);
            this.GridViewSolicitud.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewSolicitud_CellFormatting);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(370, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "Carga de Solicitudes EPC";
            // 
            // CbxSemana
            // 
            this.CbxSemana.DataSource = this.pmcSemanasBindingSource;
            this.CbxSemana.DisplayMember = "sem_ID";
            this.CbxSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxSemana.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.CbxSemana.Location = new System.Drawing.Point(756, 79);
            this.CbxSemana.Name = "CbxSemana";
            this.CbxSemana.Size = new System.Drawing.Size(156, 29);
            this.CbxSemana.TabIndex = 29;
            this.CbxSemana.ValueMember = "sem_ID";
            this.CbxSemana.Click += new System.EventHandler(this.CbxSemana_Click);
            // 
            // pmcSemanasBindingSource
            // 
            this.pmcSemanasBindingSource.DataSource = typeof(Rmc.Clases.pmc_Semanas);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(682, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Semana";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(963, 421);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(82, 18);
            this.radLabel1.TabIndex = 40;
            this.radLabel1.Text = "* Fuera de Plan";
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.Red;
            this.radLabel4.Location = new System.Drawing.Point(926, 421);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(31, 18);
            this.radLabel4.TabIndex = 39;
            this.radLabel4.Text = "        ";
            // 
            // frmCargaSolicitudesEPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1094, 582);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.GridViewSolicitud);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbxSemana);
            this.Controls.Add(this.label5);
            this.Name = "frmCargaSolicitudesEPC";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Solicitudes EPC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSolicitudesEPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
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
        private Telerik.WinControls.UI.RadGridView GridViewSolicitud;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadDropDownList CbxSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource pmcSemanasBindingSource;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        
    }
}
