using System.Windows.Forms;

namespace Rmc.MaterialEmpaque.Monitoreo
{
    partial class TraceIdCard
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSaca;
        private Label lblMesa;
        private Label lblDocenas;
        private Label lblInicio;
        private Label lblStickers;
        private Label lblTranscurrido;
        private Button btnCompletar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSaca = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblDocenas = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblStickers = new System.Windows.Forms.Label();
            this.lblTranscurrido = new System.Windows.Forms.Label();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(27, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TraceID:";
            // 
            // lblSaca
            // 
            this.lblSaca.Location = new System.Drawing.Point(27, 40);
            this.lblSaca.Name = "lblSaca";
            this.lblSaca.Size = new System.Drawing.Size(150, 18);
            this.lblSaca.TabIndex = 1;
            this.lblSaca.Text = "Saca:";
            // 
            // lblMesa
            // 
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(185, 40);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(150, 18);
            this.lblMesa.TabIndex = 2;
            this.lblMesa.Text = "Mesa:";
            // 
            // lblDocenas
            // 
            this.lblDocenas.Location = new System.Drawing.Point(27, 60);
            this.lblDocenas.Name = "lblDocenas";
            this.lblDocenas.Size = new System.Drawing.Size(150, 18);
            this.lblDocenas.TabIndex = 3;
            this.lblDocenas.Text = "Docenas:";
            // 
            // lblInicio
            // 
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.Location = new System.Drawing.Point(28, 80);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(307, 18);
            this.lblInicio.TabIndex = 4;
            this.lblInicio.Text = "Inicio:";
            // 
            // lblStickers
            // 
            this.lblStickers.Location = new System.Drawing.Point(185, 60);
            this.lblStickers.Name = "lblStickers";
            this.lblStickers.Size = new System.Drawing.Size(142, 18);
            this.lblStickers.TabIndex = 5;
            this.lblStickers.Text = "Stickers:";
            // 
            // lblTranscurrido
            // 
            this.lblTranscurrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranscurrido.Location = new System.Drawing.Point(27, 100);
            this.lblTranscurrido.Name = "lblTranscurrido";
            this.lblTranscurrido.Size = new System.Drawing.Size(300, 18);
            this.lblTranscurrido.TabIndex = 6;
            this.lblTranscurrido.Text = "Transcurrido:";
            // 
            // btnCompletar
            // 
            this.btnCompletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnCompletar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletar.ForeColor = System.Drawing.Color.White;
            this.btnCompletar.Image = global::Rmc.Properties.Resources.check;
            this.btnCompletar.Location = new System.Drawing.Point(31, 125);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(146, 45);
            this.btnCompletar.TabIndex = 7;
            this.btnCompletar.Text = "Liberar TraceID";
            this.btnCompletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompletar.UseVisualStyleBackColor = false;
            // 
            // TraceIdCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSaca);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblDocenas);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblStickers);
            this.Controls.Add(this.lblTranscurrido);
            this.Controls.Add(this.btnCompletar);
            this.Name = "TraceIdCard";
            this.Size = new System.Drawing.Size(340, 174);
            this.ResumeLayout(false);

        }
    }
}