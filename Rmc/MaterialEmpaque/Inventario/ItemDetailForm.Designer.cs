namespace Rmc.MaterialEmpaque.Inventario
{
    partial class ItemDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Telerik.WinControls.UI.RadPanel panelHeader;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadPanel panelMain;
        private Telerik.WinControls.UI.RadTextBox txtCarnet;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtIdCaja;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBox txtUbicacion;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadSpinEditor txtCantidad;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cmbCodigo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadPanel panelFooter;
        private Telerik.WinControls.UI.RadButton btnGuardar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadLabel lblBodegaInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panelHeader = new Telerik.WinControls.UI.RadPanel();
            this.lblBodegaInfo = new Telerik.WinControls.UI.RadLabel();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.panelMain = new Telerik.WinControls.UI.RadPanel();
            this.cmbCodigo = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.txtCarnet = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtIdCaja = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtUbicacion = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtCantidad = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.panelFooter = new Telerik.WinControls.UI.RadPanel();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBodegaInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCodigo.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCodigo.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelHeader.Controls.Add(this.lblBodegaInfo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(530, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBodegaInfo
            // 
            this.lblBodegaInfo.AutoSize = false;
            this.lblBodegaInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBodegaInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBodegaInfo.ForeColor = System.Drawing.Color.White;
            this.lblBodegaInfo.Location = new System.Drawing.Point(0, 50);
            this.lblBodegaInfo.Name = "lblBodegaInfo";
            this.lblBodegaInfo.Size = new System.Drawing.Size(530, 30);
            this.lblBodegaInfo.TabIndex = 1;
            this.lblBodegaInfo.Text = "Bodega: ";
            this.lblBodegaInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(530, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "NUEVO ITEM";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.cmbCodigo);
            this.panelMain.Controls.Add(this.txtCarnet);
            this.panelMain.Controls.Add(this.radLabel3);
            this.panelMain.Controls.Add(this.txtIdCaja);
            this.panelMain.Controls.Add(this.radLabel6);
            this.panelMain.Controls.Add(this.txtUbicacion);
            this.panelMain.Controls.Add(this.radLabel5);
            this.panelMain.Controls.Add(this.txtCantidad);
            this.panelMain.Controls.Add(this.radLabel4);
            this.panelMain.Controls.Add(this.txtDescripcion);
            this.panelMain.Controls.Add(this.radLabel2);
            this.panelMain.Controls.Add(this.radLabel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(530, 360);
            this.panelMain.TabIndex = 1;
            // 
            // cmbCodigo
            // 
            // 
            // cmbCodigo.NestedRadGridView
            // 
            this.cmbCodigo.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCodigo.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodigo.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbCodigo.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cmbCodigo.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cmbCodigo.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cmbCodigo.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cmbCodigo.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cmbCodigo.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cmbCodigo.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.cmbCodigo.EditorControl.Name = "NestedRadGridView";
            this.cmbCodigo.EditorControl.ReadOnly = true;
            this.cmbCodigo.EditorControl.ShowGroupPanel = false;
            this.cmbCodigo.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cmbCodigo.EditorControl.TabIndex = 0;
            this.cmbCodigo.Location = new System.Drawing.Point(150, 20);
            this.cmbCodigo.Name = "cmbCodigo";
            this.cmbCodigo.Size = new System.Drawing.Size(332, 24);
            this.cmbCodigo.TabIndex = 0;
            this.cmbCodigo.TabStop = false;
            // 
            // txtCarnet
            // 
            this.txtCarnet.Location = new System.Drawing.Point(150, 250);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(150, 24);
            this.txtCarnet.TabIndex = 5;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(30, 252);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(42, 18);
            this.radLabel3.TabIndex = 12;
            this.radLabel3.Text = "Carnet:";
            // 
            // txtIdCaja
            // 
            this.txtIdCaja.Location = new System.Drawing.Point(150, 200);
            this.txtIdCaja.Name = "txtIdCaja";
            this.txtIdCaja.Size = new System.Drawing.Size(332, 24);
            this.txtIdCaja.TabIndex = 4;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(30, 202);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(44, 18);
            this.radLabel6.TabIndex = 10;
            this.radLabel6.Text = "ID Caja:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(150, 150);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(150, 24);
            this.txtUbicacion.TabIndex = 3;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(30, 152);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(58, 18);
            this.radLabel5.TabIndex = 8;
            this.radLabel5.Text = "Ubicación:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.DecimalPlaces = 2;
            this.txtCantidad.Location = new System.Drawing.Point(150, 100);
            this.txtCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(150, 24);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.TabStop = false;
            this.txtCantidad.ThousandsSeparator = true;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(30, 102);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(54, 18);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Cantidad:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(150, 50);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            // 
            // 
            // 
            this.txtDescripcion.RootElement.StretchVertically = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(332, 40);
            this.txtDescripcion.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(30, 52);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(67, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Descripción:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(30, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Código:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFooter.Controls.Add(this.btnCancelar);
            this.panelFooter.Controls.Add(this.btnGuardar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 440);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(10);
            this.panelFooter.Size = new System.Drawing.Size(530, 60);
            this.panelFooter.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(120, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(10, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ItemDetailForm
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(530, 500);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item";
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBodegaInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCodigo.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCodigo.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}