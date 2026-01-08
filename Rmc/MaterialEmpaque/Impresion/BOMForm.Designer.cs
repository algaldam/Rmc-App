using System.Drawing;

namespace Rmc.MaterialEmpaque
{
    partial class BOMForm
    {
        private System.ComponentModel.IContainer components = null;

        // 🔹 Controles
        private Telerik.WinControls.UI.RadTextBox txtTraceIdReimpresion;
        private System.Windows.Forms.Label lblReimpresionResultado;
        private Telerik.WinControls.UI.RadButton btnReimprimir;
        private System.Windows.Forms.Label lblWaitingText;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblWaitingText = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnProcesarFiltrado = new Telerik.WinControls.UI.RadButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSobreConsumoId = new Telerik.WinControls.UI.RadTextBox();
            this.TraceID = new System.Windows.Forms.Label();
            this.TxtTraceId = new Telerik.WinControls.UI.RadTextBox();
            this.BtnImprimir = new Telerik.WinControls.UI.RadButton();
            this.gbReimpresion = new Telerik.WinControls.UI.RadGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTraceIdReimpresion = new Telerik.WinControls.UI.RadTextBox();
            this.btnReimprimir = new Telerik.WinControls.UI.RadButton();
            this.lblReimpresionResultado = new System.Windows.Forms.Label();
            this.BOMReport = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesarFiltrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSobreConsumoId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTraceId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbReimpresion)).BeginInit();
            this.gbReimpresion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTraceIdReimpresion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReimprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panel3.Controls.Add(this.lblWaitingText);
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1373, 80);
            this.panel3.TabIndex = 2;
            // 
            // lblWaitingText
            // 
            this.lblWaitingText.BackColor = System.Drawing.Color.Transparent;
            this.lblWaitingText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWaitingText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWaitingText.ForeColor = System.Drawing.Color.White;
            this.lblWaitingText.Location = new System.Drawing.Point(0, 0);
            this.lblWaitingText.Name = "lblWaitingText";
            this.lblWaitingText.Size = new System.Drawing.Size(1373, 80);
            this.lblWaitingText.TabIndex = 2;
            this.lblWaitingText.Text = "Procesando...";
            this.lblWaitingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaitingText.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1373, 80);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Impresión del BOM";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel4.Controls.Add(this.btnProcesarFiltrado);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtSobreConsumoId);
            this.panel4.Controls.Add(this.TraceID);
            this.panel4.Controls.Add(this.TxtTraceId);
            this.panel4.Controls.Add(this.BtnImprimir);
            this.panel4.Controls.Add(this.gbReimpresion);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 80);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(20);
            this.panel4.Size = new System.Drawing.Size(350, 651);
            this.panel4.TabIndex = 1;
            // 
            // btnProcesarFiltrado
            // 
            this.btnProcesarFiltrado.BackColor = System.Drawing.Color.Gray;
            this.btnProcesarFiltrado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesarFiltrado.ForeColor = System.Drawing.Color.White;
            this.btnProcesarFiltrado.Image = global::Rmc.Properties.Resources.procesar;
            this.btnProcesarFiltrado.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcesarFiltrado.Location = new System.Drawing.Point(31, 549);
            this.btnProcesarFiltrado.Name = "btnProcesarFiltrado";
            this.btnProcesarFiltrado.Size = new System.Drawing.Size(300, 40);
            this.btnProcesarFiltrado.TabIndex = 6;
            this.btnProcesarFiltrado.Text = "Procesar Filtrado";
            this.btnProcesarFiltrado.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesarFiltrado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesarFiltrado.ThemeName = "Material";
            this.btnProcesarFiltrado.Click += new System.EventHandler(this.btnProcesarFiltrado_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(27, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "SobreConsumoID:";
            // 
            // txtSobreConsumoId
            // 
            this.txtSobreConsumoId.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSobreConsumoId.Location = new System.Drawing.Point(27, 236);
            this.txtSobreConsumoId.Name = "txtSobreConsumoId";
            this.txtSobreConsumoId.NullText = "Ingrese SobreConsumoID";
            this.txtSobreConsumoId.Size = new System.Drawing.Size(300, 25);
            this.txtSobreConsumoId.TabIndex = 5;
            this.txtSobreConsumoId.ThemeName = "Material";
            this.txtSobreConsumoId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSobreConsumoId_KeyDown);
            // 
            // TraceID
            // 
            this.TraceID.AutoSize = true;
            this.TraceID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TraceID.Location = new System.Drawing.Point(27, 71);
            this.TraceID.Name = "TraceID";
            this.TraceID.Size = new System.Drawing.Size(71, 21);
            this.TraceID.TabIndex = 0;
            this.TraceID.Text = "TraceID:";
            // 
            // TxtTraceId
            // 
            this.TxtTraceId.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TxtTraceId.Location = new System.Drawing.Point(27, 101);
            this.TxtTraceId.Name = "TxtTraceId";
            this.TxtTraceId.NullText = "Ingrese TraceID";
            this.TxtTraceId.Size = new System.Drawing.Size(300, 25);
            this.TxtTraceId.TabIndex = 1;
            this.TxtTraceId.ThemeName = "Material";
            this.TxtTraceId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTraceId_KeyDown);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnImprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.BtnImprimir.ForeColor = System.Drawing.Color.White;
            this.BtnImprimir.Image = global::Rmc.Properties.Resources.comprobado;
            this.BtnImprimir.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.Location = new System.Drawing.Point(27, 146);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(300, 40);
            this.BtnImprimir.TabIndex = 2;
            this.BtnImprimir.Text = "Imprimir BOM";
            this.BtnImprimir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnImprimir.ThemeName = "Material";
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // gbReimpresion
            // 
            this.gbReimpresion.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbReimpresion.BackColor = System.Drawing.Color.Transparent;
            this.gbReimpresion.Controls.Add(this.label1);
            this.gbReimpresion.Controls.Add(this.txtTraceIdReimpresion);
            this.gbReimpresion.Controls.Add(this.btnReimprimir);
            this.gbReimpresion.Controls.Add(this.lblReimpresionResultado);
            this.gbReimpresion.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.gbReimpresion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbReimpresion.HeaderText = "Reimpresión de BOM";
            this.gbReimpresion.Location = new System.Drawing.Point(27, 293);
            this.gbReimpresion.Name = "gbReimpresion";
            this.gbReimpresion.Padding = new System.Windows.Forms.Padding(10);
            this.gbReimpresion.Size = new System.Drawing.Size(300, 200);
            this.gbReimpresion.TabIndex = 3;
            this.gbReimpresion.Text = "Reimpresión de BOM";
            this.gbReimpresion.ThemeName = "Material";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "BomID:";
            // 
            // txtTraceIdReimpresion
            // 
            this.txtTraceIdReimpresion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTraceIdReimpresion.Location = new System.Drawing.Point(10, 79);
            this.txtTraceIdReimpresion.Name = "txtTraceIdReimpresion";
            this.txtTraceIdReimpresion.NullText = "ID de trasabilidad";
            this.txtTraceIdReimpresion.Size = new System.Drawing.Size(280, 25);
            this.txtTraceIdReimpresion.TabIndex = 1;
            this.txtTraceIdReimpresion.ThemeName = "Material";
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(161)))), ((int)(((byte)(105)))));
            this.btnReimprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.ForeColor = System.Drawing.Color.White;
            this.btnReimprimir.Image = global::Rmc.Properties.Resources.reporter;
            this.btnReimprimir.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReimprimir.Location = new System.Drawing.Point(10, 119);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(280, 40);
            this.btnReimprimir.TabIndex = 2;
            this.btnReimprimir.Text = "Reimprimir";
            this.btnReimprimir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReimprimir.ThemeName = "Material";
            this.btnReimprimir.Click += new System.EventHandler(this.BtnReimprimir_Click);
            // 
            // lblReimpresionResultado
            // 
            this.lblReimpresionResultado.AutoSize = true;
            this.lblReimpresionResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblReimpresionResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(161)))), ((int)(((byte)(105)))));
            this.lblReimpresionResultado.Location = new System.Drawing.Point(10, 169);
            this.lblReimpresionResultado.Name = "lblReimpresionResultado";
            this.lblReimpresionResultado.Size = new System.Drawing.Size(0, 15);
            this.lblReimpresionResultado.TabIndex = 3;
            // 
            // BOMReport
            // 
            this.BOMReport.AccessibilityKeyMap = null;
            this.BOMReport.BackColor = System.Drawing.Color.White;
            this.BOMReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BOMReport.Location = new System.Drawing.Point(350, 80);
            this.BOMReport.Name = "BOMReport";
            this.BOMReport.Size = new System.Drawing.Size(1023, 651);
            this.BOMReport.TabIndex = 0;
            this.BOMReport.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.FullPage;
            this.BOMReport.ZoomPercent = 150;
            // 
            // BOMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1373, 731);
            this.Controls.Add(this.BOMReport);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "BOMForm";
            this.Text = "Impresión BOM";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesarFiltrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSobreConsumoId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTraceId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbReimpresion)).EndInit();
            this.gbReimpresion.ResumeLayout(false);
            this.gbReimpresion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTraceIdReimpresion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReimprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Telerik.WinControls.UI.RadButton BtnImprimir;
        private Telerik.ReportViewer.WinForms.ReportViewer BOMReport;
        private Telerik.WinControls.UI.RadTextBox TxtTraceId;
        private Telerik.WinControls.UI.RadGroupBox gbReimpresion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label TraceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtSobreConsumoId;
        private Telerik.WinControls.UI.RadButton btnProcesarFiltrado;
    }
}