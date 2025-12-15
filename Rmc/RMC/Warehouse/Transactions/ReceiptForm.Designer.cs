namespace Rmc.Warehouse
{
    partial class InventoryReceiptForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLocalidad = new Telerik.WinControls.UI.RadLabel();
            this.ddlLocalidad = new Telerik.WinControls.UI.RadDropDownList();
            this.rgvDatosLocalidad = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtEscaneados = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtUltimoID = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtID = new Telerik.WinControls.UI.RadTextBox();
            this.lblBodega = new Telerik.WinControls.UI.RadLabel();
            this.ddlBodega = new Telerik.WinControls.UI.RadDropDownList();
            this.TxBPO = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLocalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatosLocalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatosLocalidad.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscaneados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUltimoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightGray;
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.radPanel1.Name = "radPanel1";
            // 
            // 
            // 
            this.radPanel1.RootElement.BorderHighlightColor = System.Drawing.Color.Black;
            this.radPanel1.Size = new System.Drawing.Size(2217, 112);
            this.radPanel1.TabIndex = 27;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 45);
            this.label6.TabIndex = 13;
            this.label6.Text = "Entradas";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.BackColor = System.Drawing.Color.Transparent;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalidad.Location = new System.Drawing.Point(35, 140);
            this.lblLocalidad.Margin = new System.Windows.Forms.Padding(6);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(82, 25);
            this.lblLocalidad.TabIndex = 28;
            this.lblLocalidad.Text = "Localidad";
            // 
            // ddlLocalidad
            // 
            this.ddlLocalidad.AutoSize = false;
            this.ddlLocalidad.DropDownHeight = 239;
            this.ddlLocalidad.Location = new System.Drawing.Point(129, 124);
            this.ddlLocalidad.Margin = new System.Windows.Forms.Padding(6);
            this.ddlLocalidad.Name = "ddlLocalidad";
            this.ddlLocalidad.Size = new System.Drawing.Size(228, 50);
            this.ddlLocalidad.TabIndex = 29;
            this.ddlLocalidad.ThemeName = "TelerikMetroBlue";
            this.ddlLocalidad.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlLocalidad_SelectedIndexChanged);
            // 
            // rgvDatosLocalidad
            // 
            this.rgvDatosLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rgvDatosLocalidad.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rgvDatosLocalidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvDatosLocalidad.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvDatosLocalidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rgvDatosLocalidad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvDatosLocalidad.Location = new System.Drawing.Point(15, 186);
            this.rgvDatosLocalidad.Margin = new System.Windows.Forms.Padding(6);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "CODIGO";
            gridViewTextBoxColumn1.HeaderText = "CÓDIGO";
            gridViewTextBoxColumn1.Name = "CODIGO";
            gridViewTextBoxColumn1.Width = 303;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "DESCRIPCION";
            gridViewTextBoxColumn2.HeaderText = "DESCRIPCIÓN";
            gridViewTextBoxColumn2.Name = "DESCRIPCION";
            gridViewTextBoxColumn2.Width = 375;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "PAQUETES";
            gridViewTextBoxColumn3.HeaderText = "PAQUETES";
            gridViewTextBoxColumn3.Name = "PAQUETES";
            gridViewTextBoxColumn3.Width = 261;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "LIBRAS";
            gridViewTextBoxColumn4.HeaderText = "LIBRAS";
            gridViewTextBoxColumn4.Name = "LIBRAS";
            gridViewTextBoxColumn4.Width = 230;
            this.rgvDatosLocalidad.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.rgvDatosLocalidad.MasterTemplate.EnableFiltering = true;
            this.rgvDatosLocalidad.MasterTemplate.EnableGrouping = false;
            this.rgvDatosLocalidad.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.rgvDatosLocalidad.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvDatosLocalidad.Name = "rgvDatosLocalidad";
            this.rgvDatosLocalidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvDatosLocalidad.Size = new System.Drawing.Size(748, 619);
            this.rgvDatosLocalidad.TabIndex = 30;
            this.rgvDatosLocalidad.ThemeName = "TelerikMetroBlue";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtUltimoID);
            this.radGroupBox1.Controls.Add(this.txtEscaneados);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtID);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(787, 186);
            this.radGroupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(4, 40, 4, 4);
            this.radGroupBox1.Size = new System.Drawing.Size(748, 391);
            this.radGroupBox1.TabIndex = 31;
            this.radGroupBox1.ThemeName = "TelerikMetroBlue";
            // 
            // txtEscaneados
            // 
            this.txtEscaneados.AutoSize = false;
            this.txtEscaneados.Enabled = false;
            this.txtEscaneados.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEscaneados.Location = new System.Drawing.Point(222, 303);
            this.txtEscaneados.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtEscaneados.Name = "txtEscaneados";
            this.txtEscaneados.Size = new System.Drawing.Size(171, 55);
            this.txtEscaneados.TabIndex = 11;
            this.txtEscaneados.Text = "0";
            this.txtEscaneados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(50, 303);
            this.radLabel3.Margin = new System.Windows.Forms.Padding(6);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(160, 41);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "Escaneados";
            // 
            // txtUltimoID
            // 
            this.txtUltimoID.AutoSize = false;
            this.txtUltimoID.Enabled = false;
            this.txtUltimoID.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimoID.Location = new System.Drawing.Point(299, 21);
            this.txtUltimoID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtUltimoID.Name = "txtUltimoID";
            this.txtUltimoID.Size = new System.Drawing.Size(360, 66);
            this.txtUltimoID.TabIndex = 7;
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(18, 21);
            this.radLabel2.Margin = new System.Windows.Forms.Padding(6);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(245, 41);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Ultimo Escaneado";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(53, 124);
            this.radLabel1.Margin = new System.Windows.Forms.Padding(6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(157, 99);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "ID #";
            // 
            // txtID
            // 
            this.txtID.AutoSize = false;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(240, 96);
            this.txtID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(499, 144);
            this.txtID.TabIndex = 9;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // lblBodega
            // 
            this.lblBodega.BackColor = System.Drawing.Color.Transparent;
            this.lblBodega.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBodega.Location = new System.Drawing.Point(369, 140);
            this.lblBodega.Margin = new System.Windows.Forms.Padding(6);
            this.lblBodega.Name = "lblBodega";
            this.lblBodega.Size = new System.Drawing.Size(67, 25);
            this.lblBodega.TabIndex = 29;
            this.lblBodega.Text = "Bodega";
            // 
            // ddlBodega
            // 
            this.ddlBodega.AutoSize = false;
            this.ddlBodega.DropDownHeight = 239;
            this.ddlBodega.Location = new System.Drawing.Point(448, 124);
            this.ddlBodega.Margin = new System.Windows.Forms.Padding(6);
            this.ddlBodega.Name = "ddlBodega";
            this.ddlBodega.Size = new System.Drawing.Size(250, 50);
            this.ddlBodega.TabIndex = 32;
            this.ddlBodega.ThemeName = "TelerikMetroBlue";
            // 
            // TxBPO
            // 
            this.TxBPO.Location = new System.Drawing.Point(1000, 112);
            this.TxBPO.Name = "TxBPO";
            this.TxBPO.Size = new System.Drawing.Size(189, 20);
            this.TxBPO.TabIndex = 33;
            this.TxBPO.Visible = false;
            // 
            // InventoryReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2217, 806);
            this.Controls.Add(this.TxBPO);
            this.Controls.Add(this.rgvDatosLocalidad);
            this.Controls.Add(this.ddlBodega);
            this.Controls.Add(this.lblBodega);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.ddlLocalidad);
            this.Controls.Add(this.radPanel1);
            this.Name = "InventoryReceiptForm";
            this.Text = "Entradas";
            this.Load += new System.EventHandler(this.InventoryReceiptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLocalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatosLocalidad.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvDatosLocalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscaneados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUltimoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlBodega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadLabel lblLocalidad;
        private Telerik.WinControls.UI.RadDropDownList ddlLocalidad;
        private Telerik.WinControls.UI.RadGridView rgvDatosLocalidad;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txtEscaneados;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtUltimoID;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtID;
        private Telerik.WinControls.UI.RadLabel lblBodega;
        private Telerik.WinControls.UI.RadDropDownList ddlBodega;
        private System.Windows.Forms.TextBox TxBPO;
    }
}
