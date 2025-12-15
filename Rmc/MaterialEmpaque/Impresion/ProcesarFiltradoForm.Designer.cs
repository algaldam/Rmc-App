namespace Rmc.MaterialEmpaque.Impresion
{
    partial class ProcesarFiltradoForm
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
            this.SACA = new System.Windows.Forms.Label();
            this.lblDocenas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaca = new Telerik.WinControls.UI.RadTextBox();
            this.txtDocenas = new Telerik.WinControls.UI.RadTextBox();
            this.txtCarnet = new Telerik.WinControls.UI.RadTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocenas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarnet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SACA
            // 
            this.SACA.AutoSize = true;
            this.SACA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.SACA.Location = new System.Drawing.Point(70, 80);
            this.SACA.Name = "SACA";
            this.SACA.Size = new System.Drawing.Size(62, 21);
            this.SACA.TabIndex = 1;
            this.SACA.Text = "SA/CA:";
            // 
            // lblDocenas
            // 
            this.lblDocenas.AutoSize = true;
            this.lblDocenas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDocenas.Location = new System.Drawing.Point(42, 137);
            this.lblDocenas.Name = "lblDocenas";
            this.lblDocenas.Size = new System.Drawing.Size(90, 21);
            this.lblDocenas.TabIndex = 2;
            this.lblDocenas.Text = "DOCENAS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(56, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "CARNET:";
            // 
            // txtSaca
            // 
            this.txtSaca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSaca.BackColor = System.Drawing.Color.White;
            this.txtSaca.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaca.Location = new System.Drawing.Point(138, 68);
            this.txtSaca.Name = "txtSaca";
            this.txtSaca.Size = new System.Drawing.Size(181, 29);
            this.txtSaca.TabIndex = 8;
            // 
            // txtDocenas
            // 
            this.txtDocenas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDocenas.BackColor = System.Drawing.Color.White;
            this.txtDocenas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocenas.Location = new System.Drawing.Point(138, 125);
            this.txtDocenas.Name = "txtDocenas";
            this.txtDocenas.Size = new System.Drawing.Size(181, 29);
            this.txtDocenas.TabIndex = 9;
            // 
            // txtCarnet
            // 
            this.txtCarnet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCarnet.BackColor = System.Drawing.Color.White;
            this.txtCarnet.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(138, 182);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(181, 29);
            this.txtCarnet.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnProcesar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDocenas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCarnet);
            this.panel1.Controls.Add(this.lblDocenas);
            this.panel1.Controls.Add(this.SACA);
            this.panel1.Controls.Add(this.txtSaca);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 314);
            this.panel1.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(215, 266);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 38);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::Rmc.Properties.Resources.check;
            this.btnProcesar.Location = new System.Drawing.Point(60, 266);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(120, 38);
            this.btnProcesar.TabIndex = 11;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 48);
            this.label1.TabIndex = 10;
            this.label1.Text = "Procesar Filtrado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcesarFiltradoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(397, 329);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "ProcesarFiltradoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.txtSaca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocenas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarnet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SACA;
        private System.Windows.Forms.Label lblDocenas;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtSaca;
        private Telerik.WinControls.UI.RadTextBox txtDocenas;
        private Telerik.WinControls.UI.RadTextBox txtCarnet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
    }
}
