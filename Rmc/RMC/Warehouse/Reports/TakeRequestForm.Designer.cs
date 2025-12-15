namespace Rmc.RMC.Warehouse.Reports
{
    partial class TakeRequestForm
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            this.LBL_GUARDAR = new Telerik.WinControls.UI.RadLabel();
            this.CbxProveedor = new Telerik.WinControls.UI.RadDropDownList();
            this.TxtCarguista = new Telerik.WinControls.UI.RadTextBox();
            this.TxtProducto = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.BtnCerrar = new Telerik.WinControls.UI.RadButton();
            this.TxtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.btnProcesar = new Telerik.WinControls.UI.RadButton();
            this.BTN_GUARDAR = new Telerik.WinControls.UI.RadButton();
            this.TxtIdSolicitud = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.CbxEstado = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.carguistasDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.waiProveedorDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.POP_ALERT = new Telerik.WinControls.UI.RadDesktopAlert(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LBL_GUARDAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCarguista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_GUARDAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIdSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carguistasDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waiProveedorDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_GUARDAR
            // 
            this.LBL_GUARDAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_GUARDAR.ForeColor = System.Drawing.Color.Lime;
            this.LBL_GUARDAR.Location = new System.Drawing.Point(124, 292);
            this.LBL_GUARDAR.Name = "LBL_GUARDAR";
            this.LBL_GUARDAR.Size = new System.Drawing.Size(227, 25);
            this.LBL_GUARDAR.TabIndex = 50;
            this.LBL_GUARDAR.Text = "Registro ha sido Guardado...";
            this.LBL_GUARDAR.Visible = false;
            // 
            // CbxProveedor
            // 
            this.CbxProveedor.DisplayMember = "PROVEEDOR";
            this.CbxProveedor.DropDownHeight = 118;
            this.CbxProveedor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxProveedor.Enabled = false;
            this.CbxProveedor.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.CbxProveedor.Location = new System.Drawing.Point(116, 226);
            this.CbxProveedor.Name = "CbxProveedor";
            this.CbxProveedor.Size = new System.Drawing.Size(423, 28);
            this.CbxProveedor.TabIndex = 48;
            this.CbxProveedor.ValueMember = "ID";
            // 
            // TxtCarguista
            // 
            this.TxtCarguista.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.TxtCarguista.Location = new System.Drawing.Point(116, 103);
            this.TxtCarguista.Name = "TxtCarguista";
            this.TxtCarguista.ReadOnly = true;
            this.TxtCarguista.Size = new System.Drawing.Size(423, 28);
            this.TxtCarguista.TabIndex = 47;
            // 
            // TxtProducto
            // 
            this.TxtProducto.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.TxtProducto.Location = new System.Drawing.Point(116, 185);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.ReadOnly = true;
            this.TxtProducto.Size = new System.Drawing.Size(423, 28);
            this.TxtProducto.TabIndex = 39;
            // 
            // radLabel7
            // 
            this.radLabel7.BackColor = System.Drawing.Color.Transparent;
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.radLabel7.Location = new System.Drawing.Point(30, 186);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(74, 24);
            this.radLabel7.TabIndex = 46;
            this.radLabel7.Text = "Producto";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCerrar.Location = new System.Drawing.Point(561, 286);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(125, 37);
            this.BtnCerrar.TabIndex = 37;
            this.BtnCerrar.Text = "Salir";
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnCerrar.GetChildAt(0))).Text = "Salir";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnCerrar.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnCerrar.GetChildAt(0))).Shape = null;
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.TxtCodigo.Location = new System.Drawing.Point(116, 144);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(423, 28);
            this.TxtCodigo.TabIndex = 49;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Image = global::Rmc.Properties.Resources.procesar;
            this.btnProcesar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProcesar.Location = new System.Drawing.Point(479, 21);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(207, 65);
            this.btnProcesar.TabIndex = 38;
            this.btnProcesar.Text = "Procesar Salida";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProcesar.Click += new System.EventHandler(this.BtnProcesar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnProcesar.GetChildAt(0))).Image = global::Rmc.Properties.Resources.procesar;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnProcesar.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnProcesar.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnProcesar.GetChildAt(0))).Text = "Procesar Salida";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnProcesar.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnProcesar.GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnProcesar.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnProcesar.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnProcesar.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Empty;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnProcesar.GetChildAt(0).GetChildAt(0))).GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnProcesar.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // BTN_GUARDAR
            // 
            this.BTN_GUARDAR.Enabled = false;
            this.BTN_GUARDAR.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BTN_GUARDAR.Location = new System.Drawing.Point(430, 286);
            this.BTN_GUARDAR.Name = "BTN_GUARDAR";
            this.BTN_GUARDAR.Size = new System.Drawing.Size(125, 37);
            this.BTN_GUARDAR.TabIndex = 36;
            this.BTN_GUARDAR.Text = "Guardar";
            this.BTN_GUARDAR.Click += new System.EventHandler(this.BTN_GUARDAR_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BTN_GUARDAR.GetChildAt(0))).Text = "Guardar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BTN_GUARDAR.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BTN_GUARDAR.GetChildAt(0))).Shape = null;
            // 
            // TxtIdSolicitud
            // 
            this.TxtIdSolicitud.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.TxtIdSolicitud.Location = new System.Drawing.Point(116, 21);
            this.TxtIdSolicitud.Name = "TxtIdSolicitud";
            this.TxtIdSolicitud.ReadOnly = true;
            this.TxtIdSolicitud.Size = new System.Drawing.Size(139, 28);
            this.TxtIdSolicitud.TabIndex = 40;
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.radLabel5.Location = new System.Drawing.Point(46, 145);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(60, 24);
            this.radLabel5.TabIndex = 42;
            this.radLabel5.Text = "Código";
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.radLabel4.Location = new System.Drawing.Point(19, 227);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(83, 24);
            this.radLabel4.TabIndex = 45;
            this.radLabel4.Text = "Proveedor";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(12, 22);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(90, 24);
            this.radLabel3.TabIndex = 44;
            this.radLabel3.Text = "Id Solicitud";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.Location = new System.Drawing.Point(14, 104);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(88, 24);
            this.radLabel1.TabIndex = 43;
            this.radLabel1.Text = "Asignado a";
            // 
            // CbxEstado
            // 
            this.CbxEstado.DropDownHeight = 118;
            this.CbxEstado.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            radListDataItem1.Text = "Proceso";
            radListDataItem2.Text = "Espera";
            radListDataItem3.Text = "Entregado";
            this.CbxEstado.Items.Add(radListDataItem1);
            this.CbxEstado.Items.Add(radListDataItem2);
            this.CbxEstado.Items.Add(radListDataItem3);
            this.CbxEstado.Location = new System.Drawing.Point(116, 62);
            this.CbxEstado.Name = "CbxEstado";
            this.CbxEstado.Size = new System.Drawing.Size(152, 28);
            this.CbxEstado.TabIndex = 35;
            this.CbxEstado.Click += new System.EventHandler(this.CbxEstado_Click);
            // 
            // radLabel10
            // 
            this.radLabel10.BackColor = System.Drawing.Color.Transparent;
            this.radLabel10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.radLabel10.Location = new System.Drawing.Point(50, 63);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(56, 24);
            this.radLabel10.TabIndex = 41;
            this.radLabel10.Text = "Estado";
            // 
            // POP_ALERT
            // 
            this.POP_ALERT.AutoCloseDelay = 2;
            this.POP_ALERT.FadeAnimationFrames = 10;
            this.POP_ALERT.PopupAnimationFrames = 10;
            // 
            // TakeRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.LBL_GUARDAR);
            this.Controls.Add(this.CbxProveedor);
            this.Controls.Add(this.TxtCarguista);
            this.Controls.Add(this.TxtProducto);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.BTN_GUARDAR);
            this.Controls.Add(this.TxtIdSolicitud);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.CbxEstado);
            this.Controls.Add(this.radLabel10);
            this.Name = "TakeRequestForm";
            this.Text = "Proceso";
            this.Load += new System.EventHandler(this.FrmTomaSolicitud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LBL_GUARDAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCarguista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_GUARDAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtIdSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbxEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carguistasDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waiProveedorDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel LBL_GUARDAR;
        private Telerik.WinControls.UI.RadDropDownList CbxProveedor;
        private Telerik.WinControls.UI.RadTextBox TxtCarguista;
        private Telerik.WinControls.UI.RadTextBox TxtProducto;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadButton BtnCerrar;
        private Telerik.WinControls.UI.RadTextBox TxtCodigo;
        private Telerik.WinControls.UI.RadButton btnProcesar;
        private Telerik.WinControls.UI.RadButton BTN_GUARDAR;
        private Telerik.WinControls.UI.RadTextBox TxtIdSolicitud;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList CbxEstado;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private System.Windows.Forms.BindingSource carguistasDataTableBindingSource;
        private System.Windows.Forms.BindingSource waiProveedorDataTableBindingSource;
        private Telerik.WinControls.UI.RadDesktopAlert POP_ALERT;
    }
}
