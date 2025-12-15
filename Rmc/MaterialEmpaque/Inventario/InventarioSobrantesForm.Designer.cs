namespace Rmc.MaterialEmpaque.Inventario
{
    partial class InventarioSobrantesForm
    {
        private System.ComponentModel.IContainer components = null;

        private Telerik.WinControls.UI.RadPanel panelHeader;
        private Telerik.WinControls.UI.RadLabel lblTitulo;
        private Telerik.WinControls.UI.RadButton btnRefrescar;
        private Telerik.WinControls.UI.RadLabel lblSaca;
        private Telerik.WinControls.UI.RadDropDownList cmbSaca;
        private Telerik.WinControls.UI.RadLabel lblItem;
        private Telerik.WinControls.UI.RadLabel lblCantidad;
        private Telerik.WinControls.UI.RadTextBox txtCantidad;
        private Telerik.WinControls.UI.RadLabel lblLocalidad;
        private Telerik.WinControls.UI.RadTextBox txtLocalidad;
        private Telerik.WinControls.UI.RadLabel lblCarnet;
        private Telerik.WinControls.UI.RadTextBox txtCarnet;
        private Telerik.WinControls.UI.RadButton btnAgregar;
        private Telerik.WinControls.UI.RadButton btnLimpiar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadPanel panelGrid;
        private Telerik.WinControls.UI.RadGridView gridSobrantes;
        private Telerik.WinControls.UI.RadPanel panelAccionesGrid;
        private Telerik.WinControls.UI.RadButton btnEditar;
        private Telerik.WinControls.UI.RadButton btnEliminar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panelHeader = new Telerik.WinControls.UI.RadPanel();
            this.lblTitulo = new Telerik.WinControls.UI.RadLabel();
            this.btnRefrescar = new Telerik.WinControls.UI.RadButton();
            this.lblSaca = new Telerik.WinControls.UI.RadLabel();
            this.cmbSaca = new Telerik.WinControls.UI.RadDropDownList();
            this.lblItem = new Telerik.WinControls.UI.RadLabel();
            this.lblCantidad = new Telerik.WinControls.UI.RadLabel();
            this.txtCantidad = new Telerik.WinControls.UI.RadTextBox();
            this.lblLocalidad = new Telerik.WinControls.UI.RadLabel();
            this.txtLocalidad = new Telerik.WinControls.UI.RadTextBox();
            this.lblCarnet = new Telerik.WinControls.UI.RadLabel();
            this.txtCarnet = new Telerik.WinControls.UI.RadTextBox();
            this.btnAgregar = new Telerik.WinControls.UI.RadButton();
            this.btnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.panelGrid = new Telerik.WinControls.UI.RadPanel();
            this.gridSobrantes = new Telerik.WinControls.UI.RadGridView();
            this.panelAccionesGrid = new Telerik.WinControls.UI.RadPanel();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.btnEditar = new Telerik.WinControls.UI.RadButton();
            this.btnEliminar = new Telerik.WinControls.UI.RadButton();
            this.lblMensaje = new Telerik.WinControls.UI.RadLabel();
            this.panelFormulario = new Telerik.WinControls.UI.RadPanel();
            this.panelCard = new Telerik.WinControls.UI.RadPanel();
            this.cmbItem = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCarnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSobrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSobrantes.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAccionesGrid)).BeginInit();
            this.panelAccionesGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFormulario)).BeginInit();
            this.panelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCard)).BeginInit();
            this.panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.btnRefrescar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1389, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1389, 80);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "INVENTARIO SOBRANTES";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(1275, 23);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(90, 35);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "🔄 Actualizar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // lblSaca
            // 
            this.lblSaca.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaca.Location = new System.Drawing.Point(30, 51);
            this.lblSaca.Name = "lblSaca";
            this.lblSaca.Size = new System.Drawing.Size(52, 24);
            this.lblSaca.TabIndex = 0;
            this.lblSaca.Text = "SACA:";
            // 
            // cmbSaca
            // 
            this.cmbSaca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSaca.Location = new System.Drawing.Point(30, 76);
            this.cmbSaca.Name = "cmbSaca";
            this.cmbSaca.Size = new System.Drawing.Size(280, 31);
            this.cmbSaca.TabIndex = 1;
            this.cmbSaca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSaca_KeyDown);
            this.cmbSaca.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbSaca_SelectedIndexChanged);
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(30, 116);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(49, 24);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "ITEM:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(30, 181);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(92, 24);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "CANTIDAD:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(30, 206);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 27);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalidad.Location = new System.Drawing.Point(30, 246);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(97, 24);
            this.lblLocalidad.TabIndex = 6;
            this.lblLocalidad.Text = "UBICACIÓN:";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalidad.Location = new System.Drawing.Point(30, 271);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(160, 31);
            this.txtLocalidad.TabIndex = 7;
            this.txtLocalidad.Text = "N/A";
            this.txtLocalidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocalidad_KeyDown);
            // 
            // lblCarnet
            // 
            this.lblCarnet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnet.Location = new System.Drawing.Point(30, 311);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(72, 24);
            this.lblCarnet.TabIndex = 8;
            this.lblCarnet.Text = "CARNET:";
            // 
            // txtCarnet
            // 
            this.txtCarnet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(30, 336);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(160, 31);
            this.txtCarnet.TabIndex = 9;
            this.txtCarnet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCarnet_KeyDown);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::Rmc.Properties.Resources.check;
            this.btnAgregar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.Location = new System.Drawing.Point(61, 406);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 35);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(179, 406);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(108, 35);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(121, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gridSobrantes);
            this.panelGrid.Controls.Add(this.panelAccionesGrid);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(400, 80);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(989, 617);
            this.panelGrid.TabIndex = 2;
            // 
            // gridSobrantes
            // 
            this.gridSobrantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSobrantes.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gridSobrantes.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gridSobrantes.Name = "gridSobrantes";
            this.gridSobrantes.Size = new System.Drawing.Size(989, 559);
            this.gridSobrantes.TabIndex = 0;
            // 
            // panelAccionesGrid
            // 
            this.panelAccionesGrid.Controls.Add(this.btnActualizar);
            this.panelAccionesGrid.Controls.Add(this.btnEditar);
            this.panelAccionesGrid.Controls.Add(this.btnEliminar);
            this.panelAccionesGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAccionesGrid.Location = new System.Drawing.Point(0, 559);
            this.panelAccionesGrid.Name = "panelAccionesGrid";
            this.panelAccionesGrid.Size = new System.Drawing.Size(989, 58);
            this.panelAccionesGrid.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.DarkGray;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::Rmc.Properties.Resources.reload3_78495;
            this.btnActualizar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActualizar.Location = new System.Drawing.Point(273, 9);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(116, 37);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Regrescar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::Rmc.Properties.Resources.draw;
            this.btnEditar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditar.Location = new System.Drawing.Point(30, 10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 34);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::Rmc.Properties.Resources.trash;
            this.btnEliminar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Location = new System.Drawing.Point(150, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 34);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(0, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(350, 31);
            this.lblMensaje.TabIndex = 12;
            this.lblMensaje.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelFormulario
            // 
            this.panelFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelFormulario.Controls.Add(this.panelCard);
            this.panelFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFormulario.Location = new System.Drawing.Point(0, 80);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(400, 617);
            this.panelFormulario.TabIndex = 1;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.cmbItem);
            this.panelCard.Controls.Add(this.lblSaca);
            this.panelCard.Controls.Add(this.cmbSaca);
            this.panelCard.Controls.Add(this.lblItem);
            this.panelCard.Controls.Add(this.lblCantidad);
            this.panelCard.Controls.Add(this.txtCantidad);
            this.panelCard.Controls.Add(this.lblLocalidad);
            this.panelCard.Controls.Add(this.txtLocalidad);
            this.panelCard.Controls.Add(this.lblCarnet);
            this.panelCard.Controls.Add(this.txtCarnet);
            this.panelCard.Controls.Add(this.btnAgregar);
            this.panelCard.Controls.Add(this.btnLimpiar);
            this.panelCard.Controls.Add(this.btnCancelar);
            this.panelCard.Controls.Add(this.lblMensaje);
            this.panelCard.Location = new System.Drawing.Point(20, 20);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(350, 577);
            this.panelCard.TabIndex = 0;
            // 
            // cmbItem
            // 
            this.cmbItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItem.Location = new System.Drawing.Point(30, 141);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(280, 31);
            this.cmbItem.TabIndex = 14;
            this.cmbItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // InventarioSobrantesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1389, 697);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "InventarioSobrantesForm";
            this.Text = "Inventario de Sobrantes";
            this.Load += new System.EventHandler(this.InventarioSobrantesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCarnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSobrantes.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSobrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelAccionesGrid)).EndInit();
            this.panelAccionesGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFormulario)).EndInit();
            this.panelFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCard)).EndInit();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel lblMensaje;
        private Telerik.WinControls.UI.RadPanel panelFormulario;
        private Telerik.WinControls.UI.RadPanel panelCard;
        private Telerik.WinControls.UI.RadDropDownList cmbItem;
        private Telerik.WinControls.UI.RadButton btnActualizar;
    }
}
