namespace Rmc.RMC.Chemical.Request
{
    partial class CreateChemicalRequestForm
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.BtnNuevaSolicitud = new Telerik.WinControls.UI.RadButton();
            this.BTN_REFRESH = new Telerik.WinControls.UI.RadButton();
            this.label6 = new System.Windows.Forms.Label();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.LISTVIEW_SOLICITUD = new Telerik.WinControls.UI.RadListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNuevaSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_REFRESH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LISTVIEW_SOLICITUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightGray;
            this.radPanel1.Controls.Add(this.BtnNuevaSolicitud);
            this.radPanel1.Controls.Add(this.BTN_REFRESH);
            this.radPanel1.Controls.Add(this.label6);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            // 
            // 
            // 
            this.radPanel1.RootElement.BorderHighlightColor = System.Drawing.Color.Black;
            this.radPanel1.Size = new System.Drawing.Size(1355, 80);
            this.radPanel1.TabIndex = 34;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // BtnNuevaSolicitud
            // 
            this.BtnNuevaSolicitud.Font = new System.Drawing.Font("Segoe UI", 12.11881F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevaSolicitud.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnNuevaSolicitud.Location = new System.Drawing.Point(669, 19);
            this.BtnNuevaSolicitud.Name = "BtnNuevaSolicitud";
            this.BtnNuevaSolicitud.Size = new System.Drawing.Size(162, 45);
            this.BtnNuevaSolicitud.TabIndex = 0;
            this.BtnNuevaSolicitud.Text = "Nueva";
            this.BtnNuevaSolicitud.Click += new System.EventHandler(this.BtnNuevaSolicitud_Click);
            // 
            // BTN_REFRESH
            // 
            this.BTN_REFRESH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_REFRESH.Location = new System.Drawing.Point(1063, 20);
            this.BTN_REFRESH.Name = "BTN_REFRESH";
            this.BTN_REFRESH.Size = new System.Drawing.Size(58, 51);
            this.BTN_REFRESH.TabIndex = 14;
            this.BTN_REFRESH.Text = "F5";
            this.BTN_REFRESH.Click += new System.EventHandler(this.BTN_REFRESH_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BTN_REFRESH.GetChildAt(0))).Text = "F5";
            ((Telerik.WinControls.UI.RadButtonElement)(this.BTN_REFRESH.GetChildAt(0))).ToolTipText = "Refrescar Datos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(352, 45);
            this.label6.TabIndex = 13;
            this.label6.Text = "Solicitudes - Químicos";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.LISTVIEW_SOLICITUD);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 80);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1355, 556);
            this.radPanel2.TabIndex = 35;
            // 
            // LISTVIEW_SOLICITUD
            // 
            this.LISTVIEW_SOLICITUD.AllowEdit = false;
            this.LISTVIEW_SOLICITUD.AllowRemove = false;
            this.LISTVIEW_SOLICITUD.AutoScroll = true;
            this.LISTVIEW_SOLICITUD.DisplayMember = "NOMBRE_PIDE";
            this.LISTVIEW_SOLICITUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LISTVIEW_SOLICITUD.HeaderHeight = 45.11478F;
            this.LISTVIEW_SOLICITUD.ItemSize = new System.Drawing.Size(258, 219);
            this.LISTVIEW_SOLICITUD.ItemSpacing = 15;
            this.LISTVIEW_SOLICITUD.Location = new System.Drawing.Point(0, 0);
            this.LISTVIEW_SOLICITUD.Name = "LISTVIEW_SOLICITUD";
            this.LISTVIEW_SOLICITUD.Padding = new System.Windows.Forms.Padding(162, 15, 162, 0);
            this.LISTVIEW_SOLICITUD.Size = new System.Drawing.Size(1355, 556);
            this.LISTVIEW_SOLICITUD.TabIndex = 2;
            this.LISTVIEW_SOLICITUD.ValueMember = "sol_ID";
            this.LISTVIEW_SOLICITUD.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.LISTVIEW_SOLICITUD_ItemMouseDoubleClick);
            this.LISTVIEW_SOLICITUD.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(this.LISTVIEW_SOLICITUD_VisualItemFormatting);
            this.LISTVIEW_SOLICITUD.VisualItemCreating += new Telerik.WinControls.UI.ListViewVisualItemCreatingEventHandler(this.LISTVIEW_SOLICITUD_VisualItemCreating);
            this.LISTVIEW_SOLICITUD.MouseHover += new System.EventHandler(this.LISTVIEW_SOLICITUD_MouseHover);
            this.LISTVIEW_SOLICITUD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LISTVIEW_SOLICITUD_MouseUp);
            ((Telerik.WinControls.UI.RadListViewElement)(this.LISTVIEW_SOLICITUD.GetChildAt(0))).ToolTipText = "Doble Clic para  Editar / Clic Derecho Eliminar";
            ((Telerik.WinControls.UI.RadListViewElement)(this.LISTVIEW_SOLICITUD.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(162, 15, 162, 0);
            // 
            // timer1
            // 
            this.timer1.Interval = 50000;
            // 
            // CreateChemicalRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 636);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Name = "CreateChemicalRequestForm";
            this.Text = "Crear Solicitud para Quimicos";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnNuevaSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTN_REFRESH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LISTVIEW_SOLICITUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton BtnNuevaSolicitud;
        private Telerik.WinControls.UI.RadButton BTN_REFRESH;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadListView LISTVIEW_SOLICITUD;
        private System.Windows.Forms.Timer timer1;
    }
}
