namespace Rmc.MaterialEmpaque
{
    partial class ActivarMesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivarMesas));
            this.txtYear = new Telerik.WinControls.UI.RadGroupBox();
            this.chkEstados = new System.Windows.Forms.CheckBox();
            this.lblMesa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new Telerik.WinControls.UI.RadButton();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            this.txtYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtYear
            // 
            this.txtYear.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Controls.Add(this.chkEstados);
            this.txtYear.Controls.Add(this.lblMesa);
            this.txtYear.Controls.Add(this.label1);
            this.txtYear.Controls.Add(this.btnGuardar);
            this.txtYear.Controls.Add(this.radLabel10);
            this.txtYear.Controls.Add(this.radLabel1);
            this.txtYear.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.txtYear.HeaderText = "Mesa";
            this.txtYear.Location = new System.Drawing.Point(583, 12);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(177, 540);
            this.txtYear.TabIndex = 3;
            this.txtYear.Text = "Mesa";
            this.txtYear.ThemeName = "Crystal";
            // 
            // chkEstados
            // 
            this.chkEstados.AutoSize = true;
            this.chkEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstados.Location = new System.Drawing.Point(74, 94);
            this.chkEstados.Name = "chkEstados";
            this.chkEstados.Size = new System.Drawing.Size(15, 14);
            this.chkEstados.TabIndex = 79;
            this.chkEstados.UseVisualStyleBackColor = true;
            this.chkEstados.CheckedChanged += new System.EventHandler(this.chkEstados_CheckedChanged);
            // 
            // lblMesa
            // 
            this.lblMesa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMesa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMesa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(70, 39);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(79, 28);
            this.lblMesa.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.Location = new System.Drawing.Point(11, 126);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(45, 45);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(11, 86);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(57, 22);
            this.radLabel10.TabIndex = 13;
            this.radLabel10.Text = "Activa:";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(11, 39);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(53, 22);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Mesa:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(561, 540);
            this.pictureBox1.TabIndex = 325;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // ActivarMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(772, 569);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtYear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivarMesas";
            this.Text = "Activación de mesas";
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            this.txtYear.ResumeLayout(false);
            this.txtYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox txtYear;
        private Telerik.WinControls.UI.RadButton btnGuardar;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.CheckBox chkEstados;
    }
}
