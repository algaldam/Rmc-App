
namespace Rmc.Subidas
{
    partial class frmSubidaPlan
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.label6 = new System.Windows.Forms.Label();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.CbxSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.pmcSemanasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.radScrollablePanel2 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.GridViewPlan = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).BeginInit();
            this.radScrollablePanel2.PanelContainer.SuspendLayout();
            this.radScrollablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPlan.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(561, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Importación de Plan ";
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.CbxSemana);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label5);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.label6);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1254, 95);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1256, 97);
            this.radScrollablePanel1.TabIndex = 14;
            // 
            // CbxSemana
            // 
            this.CbxSemana.DataSource = this.pmcSemanasBindingSource;
            this.CbxSemana.DisplayMember = "sem_ID";
            this.CbxSemana.DropDownAnimationEnabled = true;
            this.CbxSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxSemana.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.CbxSemana.Location = new System.Drawing.Point(85, 52);
            this.CbxSemana.Name = "CbxSemana";
            this.CbxSemana.Size = new System.Drawing.Size(156, 25);
            this.CbxSemana.TabIndex = 16;
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
            this.label5.Location = new System.Drawing.Point(11, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Semana";
            // 
            // radScrollablePanel2
            // 
            this.radScrollablePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radScrollablePanel2.Location = new System.Drawing.Point(0, 485);
            this.radScrollablePanel2.Name = "radScrollablePanel2";
            // 
            // radScrollablePanel2.PanelContainer
            // 
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel6);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel5);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel3);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radLabel2);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.LblError);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.BtnGuardar);
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.BtnLimpiar);
            this.radScrollablePanel2.PanelContainer.Size = new System.Drawing.Size(1254, 92);
            this.radScrollablePanel2.Size = new System.Drawing.Size(1256, 94);
            this.radScrollablePanel2.TabIndex = 15;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(552, 45);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 31;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(552, 21);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(86, 18);
            this.radLabel5.TabIndex = 32;
            this.radLabel5.Text = "* Fuera de BOM";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Tomato;
            this.radLabel3.Location = new System.Drawing.Point(515, 21);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(31, 18);
            this.radLabel3.TabIndex = 29;
            this.radLabel3.Text = "        ";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(515, 45);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 30;
            this.radLabel2.Text = "        ";
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(740, 21);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(235, 42);
            this.LblError.TabIndex = 28;
            this.LblError.Text = "No es posible cargar plan,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(104, 22);
            this.BtnGuardar.Name = "BtnGuardar";
            // 
            // 
            // 
            this.BtnGuardar.RootElement.EnableElementShadow = true;
            this.BtnGuardar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.Size = new System.Drawing.Size(137, 30);
            this.BtnGuardar.TabIndex = 13;
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
            this.BtnLimpiar.Location = new System.Drawing.Point(247, 22);
            this.BtnLimpiar.Name = "BtnLimpiar";
            // 
            // 
            // 
            this.BtnLimpiar.RootElement.EnableElementShadow = true;
            this.BtnLimpiar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.Size = new System.Drawing.Size(137, 30);
            this.BtnLimpiar.TabIndex = 12;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            // 
            // GridViewPlan
            // 
            this.GridViewPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewPlan.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewPlan.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridViewPlan.ForeColor = System.Drawing.Color.Black;
            this.GridViewPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewPlan.Location = new System.Drawing.Point(0, 97);
            this.GridViewPlan.Margin = new System.Windows.Forms.Padding(38);
            // 
            // 
            // 
            this.GridViewPlan.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewPlan.MasterTemplate.AllowDragToGroup = false;
            this.GridViewPlan.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Silueta";
            gridViewTextBoxColumn1.HeaderText = "Silueta";
            gridViewTextBoxColumn1.MinWidth = 195;
            gridViewTextBoxColumn1.Name = "Silueta";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 201;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Estilo";
            gridViewTextBoxColumn2.HeaderText = "Estilo";
            gridViewTextBoxColumn2.MinWidth = 195;
            gridViewTextBoxColumn2.Name = "Estilo";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 201;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Talla";
            gridViewTextBoxColumn3.HeaderText = "Talla";
            gridViewTextBoxColumn3.MinWidth = 156;
            gridViewTextBoxColumn3.Name = "Talla";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 161;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "SACA";
            gridViewTextBoxColumn4.HeaderText = "SACA";
            gridViewTextBoxColumn4.MinWidth = 156;
            gridViewTextBoxColumn4.Name = "SACA";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 161;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Item";
            gridViewTextBoxColumn5.HeaderText = "Producto";
            gridViewTextBoxColumn5.MinWidth = 156;
            gridViewTextBoxColumn5.Name = "Item";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 161;
            gridViewMaskBoxColumn1.DataType = typeof(int);
            gridViewMaskBoxColumn1.EnableExpressionEditor = false;
            gridViewMaskBoxColumn1.FieldName = "Cantidad";
            gridViewMaskBoxColumn1.HeaderText = "Cantidad";
            gridViewMaskBoxColumn1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn1.MinWidth = 150;
            gridViewMaskBoxColumn1.Name = "Cantidad";
            gridViewMaskBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn1.Width = 155;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Item_Desv";
            gridViewTextBoxColumn6.HeaderText = "Desviación";
            gridViewTextBoxColumn6.MinWidth = 195;
            gridViewTextBoxColumn6.Name = "Item_Desv";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.Width = 201;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ESTADO";
            gridViewTextBoxColumn7.HeaderText = "Estado";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.MinWidth = 10;
            gridViewTextBoxColumn7.Name = "ESTADO";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "ORDEN";
            gridViewTextBoxColumn8.HeaderText = "Orden";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.MinWidth = 10;
            gridViewTextBoxColumn8.Name = "ORDEN";
            gridViewTextBoxColumn8.Width = 90;
            this.GridViewPlan.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewMaskBoxColumn1,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.GridViewPlan.MasterTemplate.EnableGrouping = false;
            this.GridViewPlan.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridViewPlan.Name = "GridViewPlan";
            this.GridViewPlan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewPlan.Size = new System.Drawing.Size(1256, 388);
            this.GridViewPlan.TabIndex = 16;
            this.GridViewPlan.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewPlan_RowFormatting);
            this.GridViewPlan.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewPlan_CellFormatting);
            this.GridViewPlan.PastingCellClipboardContent += new Telerik.WinControls.UI.GridViewCellValueEventHandler(this.GridViewPlan_PastingCellClipboardContent);
            // 
            // frmSubidaPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1256, 579);
            this.Controls.Add(this.GridViewPlan);
            this.Controls.Add(this.radScrollablePanel2);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmSubidaPlan";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Planes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSubidaPlan_Load);
            this.Enter += new System.EventHandler(this.FrmSubidaPlan_Enter);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).EndInit();
            this.radScrollablePanel2.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).EndInit();
            this.radScrollablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPlan.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel2;
        private Telerik.WinControls.UI.RadButton BtnLimpiar;
        private Telerik.WinControls.UI.RadGridView GridViewPlan;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDropDownList CbxSemana;
       
        private Telerik.WinControls.UI.RadLabel LblError;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.BindingSource pmcSemanasBindingSource;
    }
}
