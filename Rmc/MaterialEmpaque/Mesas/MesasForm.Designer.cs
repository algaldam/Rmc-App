using System.Drawing;
using System.Windows.Forms;

namespace Rmc.MaterialEmpaque.Mesas
{
    partial class MesasForm
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewTareas = new Telerik.WinControls.UI.RadGridView();
            this.panelMesasContainer = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIndicadorTareasCompletadas = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblIndicadorTareasProceso = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIndicadorTareasPendientes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EstadosMesas = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblIndicadorStickers = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIndicadorMesas = new System.Windows.Forms.Label();
            this.lblMesasActivas = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicadorDocenas = new System.Windows.Forms.Label();
            this.lblDocenas = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblOcupada = new System.Windows.Forms.Label();
            this.panelMesasInfo = new System.Windows.Forms.Panel();
            this.btnAgregarMesa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.lblDesactivada = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.timerActualizacion = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas.MasterTemplate)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.EstadosMesas.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelMesasInfo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Green;
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panelMesasContainer);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1972, 698);
            this.panelMain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.dataGridViewTareas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(866, 282);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1106, 416);
            this.panel2.TabIndex = 3;
            // 
            // dataGridViewTareas
            // 
            this.dataGridViewTareas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTareas.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dataGridViewTareas.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dataGridViewTareas.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dataGridViewTareas.Name = "dataGridViewTareas";
            this.dataGridViewTareas.Size = new System.Drawing.Size(1106, 416);
            this.dataGridViewTareas.TabIndex = 0;
            this.dataGridViewTareas.ThemeName = "ControlDefault";
            this.dataGridViewTareas.ViewCellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dataGridViewTareas_ViewCellFormatting);
            // 
            // panelMesasContainer
            // 
            this.panelMesasContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMesasContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMesasContainer.Location = new System.Drawing.Point(0, 282);
            this.panelMesasContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMesasContainer.Name = "panelMesasContainer";
            this.panelMesasContainer.Size = new System.Drawing.Size(866, 416);
            this.panelMesasContainer.TabIndex = 0;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Info;
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.panel3);
            this.panelInfo.Controls.Add(this.EstadosMesas);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 74);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(1972, 208);
            this.panelInfo.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(885, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1085, 206);
            this.panel3.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(243, 69);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 10;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.Location = new System.Drawing.Point(136, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 12;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(16, 66);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 9;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label4.Location = new System.Drawing.Point(173, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pendiente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label5.Location = new System.Drawing.Point(53, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "En Proceso";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label8.Location = new System.Drawing.Point(280, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Completada";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label9.Location = new System.Drawing.Point(18, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 35);
            this.label9.TabIndex = 11;
            this.label9.Text = "Estados de TraceIDs:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(504, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(581, 149);
            this.panel7.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.lblIndicadorTareasCompletadas);
            this.panel8.Location = new System.Drawing.Point(3, 82);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(577, 63);
            this.panel8.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(13, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 34);
            this.label3.TabIndex = 10;
            this.label3.Text = "TraceIDs Completados Hoy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndicadorTareasCompletadas
            // 
            this.lblIndicadorTareasCompletadas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicadorTareasCompletadas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorTareasCompletadas.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorTareasCompletadas.Location = new System.Drawing.Point(189, 14);
            this.lblIndicadorTareasCompletadas.Name = "lblIndicadorTareasCompletadas";
            this.lblIndicadorTareasCompletadas.Size = new System.Drawing.Size(266, 35);
            this.lblIndicadorTareasCompletadas.TabIndex = 12;
            this.lblIndicadorTareasCompletadas.Text = "[-]";
            this.lblIndicadorTareasCompletadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel9.Controls.Add(this.lblIndicadorTareasProceso);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Location = new System.Drawing.Point(3, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(237, 75);
            this.panel9.TabIndex = 13;
            // 
            // lblIndicadorTareasProceso
            // 
            this.lblIndicadorTareasProceso.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicadorTareasProceso.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorTareasProceso.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorTareasProceso.Location = new System.Drawing.Point(3, 31);
            this.lblIndicadorTareasProceso.Name = "lblIndicadorTareasProceso";
            this.lblIndicadorTareasProceso.Size = new System.Drawing.Size(231, 40);
            this.lblIndicadorTareasProceso.TabIndex = 1;
            this.lblIndicadorTareasProceso.Text = "[-]";
            this.lblIndicadorTareasProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(13, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "TraceIDs en Proceso";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.Controls.Add(this.label7);
            this.panel10.Controls.Add(this.lblIndicadorTareasPendientes);
            this.panel10.Location = new System.Drawing.Point(243, 5);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(337, 74);
            this.panel10.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label7.Location = new System.Drawing.Point(9, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "TraceIDs Pendientes";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndicadorTareasPendientes
            // 
            this.lblIndicadorTareasPendientes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicadorTareasPendientes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorTareasPendientes.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorTareasPendientes.Location = new System.Drawing.Point(3, 32);
            this.lblIndicadorTareasPendientes.Name = "lblIndicadorTareasPendientes";
            this.lblIndicadorTareasPendientes.Size = new System.Drawing.Size(332, 35);
            this.lblIndicadorTareasPendientes.TabIndex = 11;
            this.lblIndicadorTareasPendientes.Text = "[-]";
            this.lblIndicadorTareasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1085, 57);
            this.label2.TabIndex = 1;
            this.label2.Text = "DETALLE TRACEIDs";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EstadosMesas
            // 
            this.EstadosMesas.BackColor = System.Drawing.SystemColors.Window;
            this.EstadosMesas.Controls.Add(this.panel6);
            this.EstadosMesas.Controls.Add(this.button2);
            this.EstadosMesas.Controls.Add(this.button3);
            this.EstadosMesas.Controls.Add(this.button1);
            this.EstadosMesas.Controls.Add(this.lblOcupada);
            this.EstadosMesas.Controls.Add(this.panelMesasInfo);
            this.EstadosMesas.Controls.Add(this.lblDisponible);
            this.EstadosMesas.Controls.Add(this.lblDesactivada);
            this.EstadosMesas.Controls.Add(this.lblEstado);
            this.EstadosMesas.Dock = System.Windows.Forms.DockStyle.Left;
            this.EstadosMesas.Location = new System.Drawing.Point(0, 0);
            this.EstadosMesas.Name = "EstadosMesas";
            this.EstadosMesas.Size = new System.Drawing.Size(885, 206);
            this.EstadosMesas.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(374, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(511, 149);
            this.panel6.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.lblIndicadorStickers);
            this.panel5.Controls.Add(this.lblCantidad);
            this.panel5.Location = new System.Drawing.Point(3, 82);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(502, 63);
            this.panel5.TabIndex = 14;
            // 
            // lblIndicadorStickers
            // 
            this.lblIndicadorStickers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicadorStickers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorStickers.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorStickers.Location = new System.Drawing.Point(128, 14);
            this.lblIndicadorStickers.Name = "lblIndicadorStickers";
            this.lblIndicadorStickers.Size = new System.Drawing.Size(233, 35);
            this.lblIndicadorStickers.TabIndex = 11;
            this.lblIndicadorStickers.Text = "[-]";
            this.lblIndicadorStickers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCantidad.Location = new System.Drawing.Point(4, 8);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(149, 22);
            this.lblCantidad.TabIndex = 9;
            this.lblCantidad.Text = "Total Stickers";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblIndicadorMesas);
            this.panel1.Controls.Add(this.lblMesasActivas);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 75);
            this.panel1.TabIndex = 13;
            // 
            // lblIndicadorMesas
            // 
            this.lblIndicadorMesas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicadorMesas.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorMesas.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorMesas.Location = new System.Drawing.Point(41, 31);
            this.lblIndicadorMesas.Name = "lblIndicadorMesas";
            this.lblIndicadorMesas.Size = new System.Drawing.Size(106, 40);
            this.lblIndicadorMesas.TabIndex = 1;
            this.lblIndicadorMesas.Text = "[-]";
            this.lblIndicadorMesas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMesasActivas
            // 
            this.lblMesasActivas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesasActivas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMesasActivas.Location = new System.Drawing.Point(37, 4);
            this.lblMesasActivas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMesasActivas.Name = "lblMesasActivas";
            this.lblMesasActivas.Size = new System.Drawing.Size(116, 25);
            this.lblMesasActivas.TabIndex = 8;
            this.lblMesasActivas.Text = "Mesas Activas";
            this.lblMesasActivas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.lblIndicadorDocenas);
            this.panel4.Controls.Add(this.lblDocenas);
            this.panel4.Location = new System.Drawing.Point(197, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(308, 74);
            this.panel4.TabIndex = 0;
            // 
            // lblIndicadorDocenas
            // 
            this.lblIndicadorDocenas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblIndicadorDocenas.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorDocenas.ForeColor = System.Drawing.Color.Black;
            this.lblIndicadorDocenas.Location = new System.Drawing.Point(34, 34);
            this.lblIndicadorDocenas.Name = "lblIndicadorDocenas";
            this.lblIndicadorDocenas.Size = new System.Drawing.Size(233, 35);
            this.lblIndicadorDocenas.TabIndex = 12;
            this.lblIndicadorDocenas.Text = "[-]";
            this.lblIndicadorDocenas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocenas
            // 
            this.lblDocenas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocenas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDocenas.Location = new System.Drawing.Point(4, 3);
            this.lblDocenas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocenas.Name = "lblDocenas";
            this.lblDocenas.Size = new System.Drawing.Size(157, 34);
            this.lblDocenas.TabIndex = 10;
            this.lblDocenas.Text = "Docenas en Mesas";
            this.lblDocenas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(232, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(129, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(14, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblOcupada
            // 
            this.lblOcupada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcupada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOcupada.Location = new System.Drawing.Point(166, 69);
            this.lblOcupada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOcupada.Name = "lblOcupada";
            this.lblOcupada.Size = new System.Drawing.Size(70, 25);
            this.lblOcupada.TabIndex = 3;
            this.lblOcupada.Text = "Ocupada";
            this.lblOcupada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMesasInfo
            // 
            this.panelMesasInfo.Controls.Add(this.btnAgregarMesa);
            this.panelMesasInfo.Controls.Add(this.label1);
            this.panelMesasInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMesasInfo.Location = new System.Drawing.Point(0, 149);
            this.panelMesasInfo.Name = "panelMesasInfo";
            this.panelMesasInfo.Size = new System.Drawing.Size(885, 57);
            this.panelMesasInfo.TabIndex = 0;
            // 
            // btnAgregarMesa
            // 
            this.btnAgregarMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnAgregarMesa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMesa.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMesa.Image = global::Rmc.Properties.Resources.agregar;
            this.btnAgregarMesa.Location = new System.Drawing.Point(753, 12);
            this.btnAgregarMesa.Name = "btnAgregarMesa";
            this.btnAgregarMesa.Size = new System.Drawing.Size(112, 40);
            this.btnAgregarMesa.TabIndex = 1;
            this.btnAgregarMesa.Text = "Nueva";
            this.btnAgregarMesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarMesa.UseVisualStyleBackColor = false;
            this.btnAgregarMesa.Click += new System.EventHandler(this.btnAgregarMesa_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(885, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "MESAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisponible
            // 
            this.lblDisponible.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDisponible.Location = new System.Drawing.Point(51, 70);
            this.lblDisponible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(82, 25);
            this.lblDisponible.TabIndex = 1;
            this.lblDisponible.Text = "Disponible";
            this.lblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesactivada
            // 
            this.lblDesactivada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesactivada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDesactivada.Location = new System.Drawing.Point(269, 70);
            this.lblDesactivada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesactivada.Name = "lblDesactivada";
            this.lblDesactivada.Size = new System.Drawing.Size(88, 25);
            this.lblDesactivada.TabIndex = 6;
            this.lblDesactivada.Text = "Desactivada";
            this.lblDesactivada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblEstado.Location = new System.Drawing.Point(7, 9);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(157, 35);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estados de Mesas:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelHeader.Controls.Add(this.lblUltimaActualizacion);
            this.panelHeader.Controls.Add(this.btnActualizar);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1972, 74);
            this.panelHeader.TabIndex = 2;
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblUltimaActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaActualizacion.ForeColor = System.Drawing.Color.White;
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(23, 20);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(240, 35);
            this.lblUltimaActualizacion.TabIndex = 9;
            this.lblUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnActualizar.Image = global::Rmc.Properties.Resources.Sign_Refresh_icon;
            this.btnActualizar.Location = new System.Drawing.Point(1611, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(158, 44);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.btnActualizar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnActualizar_KeyDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1972, 74);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CONTROL DE MESAS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerActualizacion
            // 
            this.timerActualizacion.Interval = 60000;
            this.timerActualizacion.Tick += new System.EventHandler(this.TimerActualizacion_Tick);
            // 
            // MesasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1972, 698);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1066, 731);
            this.Name = "MesasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Mesas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MesasForm_FormClosing);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTareas)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.EstadosMesas.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelMesasInfo.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMesasContainer;
        // ... (declarar demás botones)
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblOcupada;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private Label lblDesactivada;
        private Button btnActualizar;
        private Panel panel2;
        private System.Windows.Forms.Timer timerActualizacion;
        private Panel EstadosMesas;
        private Panel panelMesasInfo;
        private Label label1;
        private Label lblDocenas;
        private Label lblCantidad;
        private Label lblMesasActivas;
        private Label lblIndicadorMesas;
        private Label lblIndicadorDocenas;
        private Label lblIndicadorStickers;
        private Label lblUltimaActualizacion;
        private Button button2;
        private Button button1;
        private Button button3;
        private Panel panel3;
        private Label label2;
        private Panel panel4;
        private Panel panel1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Label label3;
        private Label lblIndicadorTareasCompletadas;
        private Panel panel9;
        private Label lblIndicadorTareasProceso;
        private Label label6;
        private Panel panel10;
        private Label label7;
        private Label lblIndicadorTareasPendientes;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
        private Button btnAgregarMesa;
        private Telerik.WinControls.UI.RadGridView dataGridViewTareas;
    }
}
