using Rmc;
namespace Rmc.Subidas
{
    partial class frmSolicitudes
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
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn1 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMaskBoxColumn gridViewMaskBoxColumn2 = new Telerik.WinControls.UI.GridViewMaskBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.CbxSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GridViewSolicitud = new Telerik.WinControls.UI.RadGridView();
            this.BtnGuardar = new Telerik.WinControls.UI.RadButton();
            this.BtnLimpiar = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.LblError = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.GridLocalidades = new Telerik.WinControls.UI.RadGridView();
            this.RefreshQueryBtn = new Telerik.WinControls.UI.RadButton();
            this.CargarReqBtn = new Telerik.WinControls.UI.RadButton();
            this.TxtItems = new Telerik.WinControls.UI.RadTextBox();
            this.LblItem = new System.Windows.Forms.Label();
            this.pmcSemanasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLocalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLocalidades.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshQueryBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargarReqBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CbxSemana
            // 
            this.CbxSemana.DataSource = this.pmcSemanasBindingSource;
            this.CbxSemana.DisplayMember = "sem_ID";
            this.CbxSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.CbxSemana.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.CbxSemana.Location = new System.Drawing.Point(79, 40);
            this.CbxSemana.Name = "CbxSemana";
            this.CbxSemana.Size = new System.Drawing.Size(156, 29);
            this.CbxSemana.TabIndex = 18;
            this.CbxSemana.ValueMember = "sem_ID";
            this.CbxSemana.Click += new System.EventHandler(this.CbxSemana_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(5, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "Semana";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Carga de Solicitudes Regulares";
            // 
            // GridViewSolicitud
            // 
            this.GridViewSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridViewSolicitud.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewSolicitud.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridViewSolicitud.ForeColor = System.Drawing.Color.Black;
            this.GridViewSolicitud.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewSolicitud.Location = new System.Drawing.Point(9, 80);
            this.GridViewSolicitud.Margin = new System.Windows.Forms.Padding(118);
            // 
            // 
            // 
            this.GridViewSolicitud.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridViewSolicitud.MasterTemplate.AllowDragToGroup = false;
            this.GridViewSolicitud.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Item";
            gridViewTextBoxColumn1.HeaderText = "Producto";
            gridViewTextBoxColumn1.MinWidth = 150;
            gridViewTextBoxColumn1.Name = "Item";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 172;
            gridViewMaskBoxColumn1.DataType = typeof(int);
            gridViewMaskBoxColumn1.EnableExpressionEditor = false;
            gridViewMaskBoxColumn1.FieldName = "Cantidad";
            gridViewMaskBoxColumn1.HeaderText = "Cantidad";
            gridViewMaskBoxColumn1.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn1.MinWidth = 100;
            gridViewMaskBoxColumn1.Name = "Cantidad";
            gridViewMaskBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn1.Width = 101;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "sol_localidad";
            gridViewTextBoxColumn2.HeaderText = "Localidad";
            gridViewTextBoxColumn2.MinWidth = 100;
            gridViewTextBoxColumn2.Name = "sol_localidad";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 101;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Item_Desv";
            gridViewCheckBoxColumn1.HeaderText = "Desviación";
            gridViewCheckBoxColumn1.MinWidth = 100;
            gridViewCheckBoxColumn1.Name = "Item_Desv";
            gridViewCheckBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn1.Width = 101;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ESTADO";
            gridViewTextBoxColumn3.HeaderText = "ESTADO";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.MinWidth = 12;
            gridViewTextBoxColumn3.Name = "ESTADO";
            gridViewTextBoxColumn3.Width = 112;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.FieldName = "SOBRE_CONSUMO";
            gridViewCheckBoxColumn2.HeaderText = "SobreConsumo";
            gridViewCheckBoxColumn2.MinWidth = 100;
            gridViewCheckBoxColumn2.Name = "SOBRE_CONSUMO";
            gridViewCheckBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn2.Width = 103;
            this.GridViewSolicitud.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewMaskBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn2});
            this.GridViewSolicitud.MasterTemplate.EnableFiltering = true;
            this.GridViewSolicitud.MasterTemplate.EnableGrouping = false;
            this.GridViewSolicitud.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GridViewSolicitud.Name = "GridViewSolicitud";
            this.GridViewSolicitud.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridViewSolicitud.Size = new System.Drawing.Size(600, 420);
            this.GridViewSolicitud.TabIndex = 20;
            this.GridViewSolicitud.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.GridViewSolicitud_RowFormatting);
            this.GridViewSolicitud.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GridViewSolicitud_CellFormatting);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(324, 518);
            this.BtnGuardar.Name = "BtnGuardar";
            // 
            // 
            // 
            this.BtnGuardar.RootElement.EnableElementShadow = true;
            this.BtnGuardar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardar.Size = new System.Drawing.Size(137, 30);
            this.BtnGuardar.TabIndex = 22;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).Text = "Guardar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnGuardar.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(472, 518);
            this.BtnLimpiar.Name = "BtnLimpiar";
            // 
            // 
            // 
            this.BtnLimpiar.RootElement.EnableElementShadow = true;
            this.BtnLimpiar.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.Size = new System.Drawing.Size(137, 30);
            this.BtnLimpiar.TabIndex = 21;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Text = "Limpiar";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnLimpiar.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(339, 575);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(57, 18);
            this.radLabel6.TabIndex = 25;
            this.radLabel6.Text = "* Correcto";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(49, 575);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(82, 18);
            this.radLabel5.TabIndex = 26;
            this.radLabel5.Text = "* Fuera de Plan";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Gold;
            this.radLabel3.Location = new System.Drawing.Point(157, 575);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(31, 18);
            this.radLabel3.TabIndex = 23;
            this.radLabel3.Text = "        ";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.White;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Location = new System.Drawing.Point(302, 575);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 18);
            this.radLabel2.TabIndex = 24;
            this.radLabel2.Text = "        ";
            // 
            // LblError
            // 
            this.LblError.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblError.ForeColor = System.Drawing.Color.Red;
            this.LblError.Location = new System.Drawing.Point(12, 518);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(241, 42);
            this.LblError.TabIndex = 27;
            this.LblError.Text = "No es posible cargar Solicitudes,\r\nFavor reparar las inconsistencias.";
            this.LblError.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Red;
            this.radLabel1.Location = new System.Drawing.Point(12, 575);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 18);
            this.radLabel1.TabIndex = 28;
            this.radLabel1.Text = "        ";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(194, 575);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(89, 18);
            this.radLabel4.TabIndex = 29;
            this.radLabel4.Text = "* Sobreconsumo";
            // 
            // GridLocalidades
            // 
            this.GridLocalidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.GridLocalidades.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridLocalidades.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GridLocalidades.ForeColor = System.Drawing.Color.Black;
            this.GridLocalidades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridLocalidades.Location = new System.Drawing.Point(622, 80);
            this.GridLocalidades.Margin = new System.Windows.Forms.Padding(118);
            // 
            // 
            // 
            this.GridLocalidades.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.GridLocalidades.MasterTemplate.AllowAddNewRow = false;
            this.GridLocalidades.MasterTemplate.AllowColumnReorder = false;
            this.GridLocalidades.MasterTemplate.AllowDragToGroup = false;
            this.GridLocalidades.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn3.EnableExpressionEditor = false;
            gridViewCheckBoxColumn3.HeaderText = "Seleccionar";
            gridViewCheckBoxColumn3.MinWidth = 75;
            gridViewCheckBoxColumn3.Name = "column1";
            gridViewCheckBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn3.Width = 89;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Item";
            gridViewTextBoxColumn4.HeaderText = "Producto";
            gridViewTextBoxColumn4.MinWidth = 100;
            gridViewTextBoxColumn4.Name = "Item";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 138;
            gridViewMaskBoxColumn2.DataType = typeof(int);
            gridViewMaskBoxColumn2.EnableExpressionEditor = false;
            gridViewMaskBoxColumn2.FieldName = "Cantidad";
            gridViewMaskBoxColumn2.HeaderText = "Cantidad";
            gridViewMaskBoxColumn2.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            gridViewMaskBoxColumn2.MinWidth = 80;
            gridViewMaskBoxColumn2.Name = "Cantidad";
            gridViewMaskBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewMaskBoxColumn2.Width = 95;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "sol_localidad";
            gridViewTextBoxColumn5.HeaderText = "Localidad";
            gridViewTextBoxColumn5.MinWidth = 80;
            gridViewTextBoxColumn5.Name = "sol_localidad";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn5.Width = 95;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Num. Lote";
            gridViewTextBoxColumn6.Name = "column2";
            gridViewTextBoxColumn6.Width = 92;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Orden";
            gridViewTextBoxColumn7.Name = "column4";
            gridViewTextBoxColumn7.Width = 92;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "Usuario";
            gridViewTextBoxColumn8.Name = "column6";
            gridViewTextBoxColumn8.Width = 102;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "Fecha Recibido";
            gridViewTextBoxColumn9.Name = "column7";
            gridViewTextBoxColumn9.Width = 102;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "Días en Bodega";
            gridViewTextBoxColumn10.Name = "column8";
            gridViewTextBoxColumn10.Width = 133;
            this.GridLocalidades.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewMaskBoxColumn2,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.GridLocalidades.MasterTemplate.EnableFiltering = true;
            this.GridLocalidades.MasterTemplate.EnableGrouping = false;
            this.GridLocalidades.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GridLocalidades.Name = "GridLocalidades";
            this.GridLocalidades.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GridLocalidades.Size = new System.Drawing.Size(960, 480);
            this.GridLocalidades.TabIndex = 31;
            // 
            // RefreshQueryBtn
            // 
            this.RefreshQueryBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshQueryBtn.Location = new System.Drawing.Point(1269, 35);
            this.RefreshQueryBtn.Name = "RefreshQueryBtn";
            // 
            // 
            // 
            this.RefreshQueryBtn.RootElement.EnableElementShadow = true;
            this.RefreshQueryBtn.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.RefreshQueryBtn.Size = new System.Drawing.Size(145, 34);
            this.RefreshQueryBtn.TabIndex = 24;
            this.RefreshQueryBtn.Text = "Refrescar Query";
            this.RefreshQueryBtn.Click += new System.EventHandler(this.RefreshQueryBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.RefreshQueryBtn.GetChildAt(0))).Text = "Refrescar Query";
            ((Telerik.WinControls.UI.RadButtonElement)(this.RefreshQueryBtn.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.RefreshQueryBtn.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.RefreshQueryBtn.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            ((Telerik.WinControls.UI.RadButtonElement)(this.RefreshQueryBtn.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CargarReqBtn
            // 
            this.CargarReqBtn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarReqBtn.Location = new System.Drawing.Point(1426, 35);
            this.CargarReqBtn.Name = "CargarReqBtn";
            // 
            // 
            // 
            this.CargarReqBtn.RootElement.EnableElementShadow = true;
            this.CargarReqBtn.RootElement.ShadowColor = System.Drawing.Color.DodgerBlue;
            this.CargarReqBtn.Size = new System.Drawing.Size(145, 34);
            this.CargarReqBtn.TabIndex = 23;
            this.CargarReqBtn.Text = "Cargar Solicitud";
            this.CargarReqBtn.Click += new System.EventHandler(this.CargarReqBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.CargarReqBtn.GetChildAt(0))).Text = "Cargar Solicitud";
            ((Telerik.WinControls.UI.RadButtonElement)(this.CargarReqBtn.GetChildAt(0))).EnableElementShadow = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.CargarReqBtn.GetChildAt(0))).ShadowDepth = 2;
            ((Telerik.WinControls.UI.RadButtonElement)(this.CargarReqBtn.GetChildAt(0))).ShadowColor = System.Drawing.Color.DodgerBlue;
            ((Telerik.WinControls.UI.RadButtonElement)(this.CargarReqBtn.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // TxtItems
            // 
            this.TxtItems.AutoSize = false;
            this.TxtItems.BackColor = System.Drawing.Color.White;
            this.TxtItems.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItems.Location = new System.Drawing.Point(661, 35);
            this.TxtItems.Name = "TxtItems";
            this.TxtItems.Size = new System.Drawing.Size(137, 28);
            this.TxtItems.TabIndex = 64;
            this.TxtItems.ThemeName = "Desert";
            this.TxtItems.Visible = false;
            this.TxtItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtItems_KeyDown);
            // 
            // LblItem
            // 
            this.LblItem.AutoSize = true;
            this.LblItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LblItem.Location = new System.Drawing.Point(618, 44);
            this.LblItem.Name = "LblItem";
            this.LblItem.Size = new System.Drawing.Size(37, 19);
            this.LblItem.TabIndex = 65;
            this.LblItem.Text = "Item";
            this.LblItem.Visible = false;
            // 
            // pmcSemanasBindingSource
            // 
            this.pmcSemanasBindingSource.DataSource = typeof(Rmc.Clases.pmc_Semanas);
            // 
            // frmSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1609, 605);
            this.Controls.Add(this.RefreshQueryBtn);
            this.Controls.Add(this.CargarReqBtn);
            this.Controls.Add(this.LblItem);
            this.Controls.Add(this.TxtItems);
            this.Controls.Add(this.GridLocalidades);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel1);
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
            this.Name = "frmSolicitudes";
            this.ShowIcon = false;
            this.Text = "Carga Solicitudes";
            this.Load += new System.EventHandler(this.frmSolicitudes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CbxSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLimpiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LblError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLocalidades.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridLocalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshQueryBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargarReqBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmcSemanasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList CbxSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadGridView GridViewSolicitud;
        private Telerik.WinControls.UI.RadButton BtnGuardar;
        private Telerik.WinControls.UI.RadButton BtnLimpiar;
        // private TracerDataSet tracerDataSet;
       // private Rmc.TracerDataSetTableAdapters.WeekPlanTableAdapter weekPlanTableAdapter;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel LblError;
        private System.Windows.Forms.BindingSource pmcSemanasBindingSource;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadGridView GridLocalidades;
        private Telerik.WinControls.UI.RadButton RefreshQueryBtn;
        private Telerik.WinControls.UI.RadButton CargarReqBtn;
        private Telerik.WinControls.UI.RadTextBox TxtItems;
        private System.Windows.Forms.Label LblItem;
    }
}
