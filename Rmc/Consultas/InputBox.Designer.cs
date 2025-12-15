namespace Rmc.Consultas
{
    partial class InputBox
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
            this.lblIndicacion = new Telerik.WinControls.UI.RadLabel();
            this.txtLibras = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIndicacion
            // 
            this.lblIndicacion.AutoSize = false;
            this.lblIndicacion.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicacion.ForeColor = System.Drawing.Color.White;
            this.lblIndicacion.Location = new System.Drawing.Point(23, 12);
            this.lblIndicacion.Name = "lblIndicacion";
            this.lblIndicacion.Size = new System.Drawing.Size(672, 175);
            this.lblIndicacion.TabIndex = 1;
            this.lblIndicacion.Text = "Ingrese la cantidad de Libras del Pack ID";
            this.lblIndicacion.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLibras
            // 
            this.txtLibras.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLibras.Location = new System.Drawing.Point(34, 225);
            this.txtLibras.Name = "txtLibras";
            this.txtLibras.Size = new System.Drawing.Size(661, 95);
            this.txtLibras.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.Image = global::Rmc.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelar.Location = new System.Drawing.Point(335, 359);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(360, 99);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.ThemeName = "TelerikMetroBlue";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOk.Image = global::Rmc.Properties.Resources.comp;
            this.btnOk.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Location = new System.Drawing.Point(34, 359);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(295, 99);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOk.ThemeName = "TelerikMetroBlue";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(727, 490);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtLibras);
            this.Controls.Add(this.lblIndicacion);
            this.Name = "InputBox";
            this.Text = "Reingreso";
            ((System.ComponentModel.ISupportInitialize)(this.lblIndicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLibras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblIndicacion;
        private Telerik.WinControls.UI.RadTextBox txtLibras;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadButton btnCancelar;
    }
}
