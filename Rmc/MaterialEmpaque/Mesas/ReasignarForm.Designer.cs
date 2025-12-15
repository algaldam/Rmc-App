namespace Rmc.MaterialEmpaque.Mesas
{
    partial class ReasignarForm
    {
        private System.ComponentModel.IContainer components = null;
        private Telerik.WinControls.UI.RadLabel lblTraceId;
        private Telerik.WinControls.UI.RadLabel lblMesaActual;
        private Telerik.WinControls.UI.RadLabel lblNuevaMesa;
        private Telerik.WinControls.UI.RadLabel lblResumen;
        private Telerik.WinControls.UI.RadDropDownList cmbMesas;
        private Telerik.WinControls.UI.RadButton btnReasignar;
        private Telerik.WinControls.UI.RadButton btnCancelar;

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
            this.lblTraceId = new Telerik.WinControls.UI.RadLabel();
            this.lblMesaActual = new Telerik.WinControls.UI.RadLabel();
            this.lblNuevaMesa = new Telerik.WinControls.UI.RadLabel();
            this.cmbMesas = new Telerik.WinControls.UI.RadDropDownList();
            this.btnReasignar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.lblResumen = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTraceId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMesaActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNuevaMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReasignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTraceId
            // 
            this.lblTraceId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTraceId.Location = new System.Drawing.Point(12, 12);
            this.lblTraceId.Name = "lblTraceId";
            this.lblTraceId.Size = new System.Drawing.Size(54, 19);
            this.lblTraceId.TabIndex = 0;
            this.lblTraceId.Text = "TraceID:";
            // 
            // lblMesaActual
            // 
            this.lblMesaActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMesaActual.Location = new System.Drawing.Point(12, 40);
            this.lblMesaActual.Name = "lblMesaActual";
            this.lblMesaActual.Size = new System.Drawing.Size(81, 19);
            this.lblMesaActual.TabIndex = 1;
            this.lblMesaActual.Text = "Mesa Actual:";
            // 
            // lblNuevaMesa
            // 
            this.lblNuevaMesa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNuevaMesa.Location = new System.Drawing.Point(12, 75);
            this.lblNuevaMesa.Name = "lblNuevaMesa";
            this.lblNuevaMesa.Size = new System.Drawing.Size(81, 19);
            this.lblNuevaMesa.TabIndex = 2;
            this.lblNuevaMesa.Text = "Nueva Mesa:";
            // 
            // cmbMesas
            // 
            this.cmbMesas.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbMesas.Location = new System.Drawing.Point(103, 73);
            this.cmbMesas.Name = "cmbMesas";
            this.cmbMesas.Size = new System.Drawing.Size(250, 24);
            this.cmbMesas.TabIndex = 3;
            this.cmbMesas.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbMesas_SelectedIndexChanged);
            // 
            // btnReasignar
            // 
            this.btnReasignar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReasignar.Enabled = false;
            this.btnReasignar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReasignar.ForeColor = System.Drawing.Color.White;
            this.btnReasignar.Location = new System.Drawing.Point(103, 130);
            this.btnReasignar.Name = "btnReasignar";
            this.btnReasignar.Size = new System.Drawing.Size(110, 35);
            this.btnReasignar.TabIndex = 4;
            this.btnReasignar.Text = "&Reasignar";
            this.btnReasignar.Click += new System.EventHandler(this.btnReasignar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Location = new System.Drawing.Point(219, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 35);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblResumen
            // 
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblResumen.ForeColor = System.Drawing.Color.Gray;
            this.lblResumen.Location = new System.Drawing.Point(289, 12);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(2, 2);
            this.lblResumen.TabIndex = 6;
            // 
            // ReasignarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 180);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnReasignar);
            this.Controls.Add(this.cmbMesas);
            this.Controls.Add(this.lblNuevaMesa);
            this.Controls.Add(this.lblMesaActual);
            this.Controls.Add(this.lblTraceId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReasignarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reasignar Mesa";
            this.Load += new System.EventHandler(this.ReasignarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTraceId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMesaActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNuevaMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReasignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}