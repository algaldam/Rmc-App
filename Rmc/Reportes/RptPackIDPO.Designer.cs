namespace Rmc.Reportes
{
    partial class RptPackIDPO
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.txtPackID = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.txtBodega = new Telerik.Reporting.TextBox();
            this.txtReprint = new Telerik.Reporting.TextBox();
            this.panel3 = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.txtSemana = new Telerik.Reporting.TextBox();
            this.txtLote = new Telerik.Reporting.TextBox();
            this.txtProvPackID = new Telerik.Reporting.TextBox();
            this.txtPO = new Telerik.Reporting.TextBox();
            this.txtFactura = new Telerik.Reporting.TextBox();
            this.txtCodigo = new Telerik.Reporting.TextBox();
            this.txtDescripcion = new Telerik.Reporting.TextBox();
            this.txtProveedor = new Telerik.Reporting.TextBox();
            this.txtLibras = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.panel2 = new Telerik.Reporting.Panel();
            this.txtPackIDBC = new Telerik.Reporting.TextBox();
            this.txtHora = new Telerik.Reporting.TextBox();
            this.txtFecha = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.9D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(3.5D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel3});
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.25D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtPackID,
            this.textBox1,
            this.txtBodega,
            this.txtReprint});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.75D), Telerik.Reporting.Drawing.Unit.Inch(0.9D));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // txtPackID
            // 
            this.txtPackID.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1D), Telerik.Reporting.Drawing.Unit.Inch(0.1D));
            this.txtPackID.Name = "txtPackID";
            this.txtPackID.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.601D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.txtPackID.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(30D);
            this.txtPackID.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtPackID.Value = "= \"ID#: \" + Fields.pac_id";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.9D), Telerik.Reporting.Drawing.Unit.Inch(0.4D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Value = "HBI\r\nES_SOCKS";
            // 
            // txtBodega
            // 
            this.txtBodega.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.txtBodega.Name = "txtBodega";
            this.txtBodega.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtBodega.Style.Font.Bold = true;
            this.txtBodega.Value = "= Fields.bod_descripcion";
            // 
            // txtReprint
            // 
            this.txtReprint.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7D), Telerik.Reporting.Drawing.Unit.Inch(0.65D));
            this.txtReprint.Name = "txtReprint";
            this.txtReprint.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtReprint.Style.Font.Bold = true;
            this.txtReprint.Value = "= IIf(Fields.pac_impreso=1,\"REPRINT\",\"\")";
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.txtSemana,
            this.txtLote,
            this.txtProvPackID,
            this.txtPO,
            this.txtFactura,
            this.txtCodigo,
            this.txtDescripcion,
            this.txtProveedor,
            this.txtLibras,
            this.textBox2});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.75D), Telerik.Reporting.Drawing.Unit.Inch(3.5D));
            this.panel3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.1D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Value = "PO #:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.35D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Value = "FACTURA:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Value = "CÓDIGO:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.85D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.05D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Value = "DESCRIPCIÓN";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(1.1D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Value = "PROVEEDOR:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(1.35D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Value = "= Fields.Medida";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(2.05D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Value = "LOTE:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(2.4D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.001D), Telerik.Reporting.Drawing.Unit.Inch(0.325D));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Value = "PROV \r\nPACK ID";
            // 
            // txtSemana
            // 
            this.txtSemana.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(2.8D));
            this.txtSemana.Name = "txtSemana";
            this.txtSemana.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.txtSemana.Style.BackgroundColor = System.Drawing.Color.Black;
            this.txtSemana.Style.Color = System.Drawing.Color.White;
            this.txtSemana.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(25D);
            this.txtSemana.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtSemana.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtSemana.Value = "= Fields.pos_semana";
            // 
            // txtLote
            // 
            this.txtLote.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(2.05D));
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.275D));
            this.txtLote.Style.BackgroundColor = System.Drawing.Color.Black;
            this.txtLote.Style.Color = System.Drawing.Color.White;
            this.txtLote.Style.Font.Bold = true;
            this.txtLote.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.txtLote.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtLote.Value = "= Fields.facd_lote";
            // 
            // txtProvPackID
            // 
            this.txtProvPackID.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(2.4D));
            this.txtProvPackID.Name = "txtProvPackID";
            this.txtProvPackID.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.325D));
            this.txtProvPackID.Style.Font.Bold = false;
            this.txtProvPackID.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.txtProvPackID.Value = "= Fields.pac_prov_pack_id";
            // 
            // txtPO
            // 
            this.txtPO.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.1D));
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtPO.Style.Font.Bold = true;
            this.txtPO.Value = "= Fields.pos_numero";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.35D));
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtFactura.Style.Font.Bold = true;
            this.txtFactura.Value = "= Fields.fac_numero";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.6D));
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtCodigo.Style.Font.Bold = true;
            this.txtCodigo.Value = "= Fields.ite_codigo";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.85D));
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtDescripcion.Style.Font.Bold = true;
            this.txtDescripcion.Value = "= Fields.ite_descripcion";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(1.1D));
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtProveedor.Style.Font.Bold = true;
            this.txtProveedor.Value = "= Fields.pro_nombre";
            // 
            // txtLibras
            // 
            this.txtLibras.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(1.35D));
            this.txtLibras.Name = "txtLibras";
            this.txtLibras.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.txtLibras.Style.Font.Bold = true;
            this.txtLibras.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.txtLibras.Value = "= Fields.pac_libras";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(1.6D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(0.4D));
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(35D);
            this.textBox2.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Justify;
            this.textBox2.TextWrap = false;
            this.textBox2.Value = "= \"*\"+Fields.pac_libras+\"*\"";
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtPackIDBC,
            this.txtHora,
            this.txtFecha});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.75D), Telerik.Reporting.Drawing.Unit.Inch(1.25D));
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // txtPackIDBC
            // 
            this.txtPackIDBC.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(0.1D));
            this.txtPackIDBC.Name = "txtPackIDBC";
            this.txtPackIDBC.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5D), Telerik.Reporting.Drawing.Unit.Inch(0.76D));
            this.txtPackIDBC.Style.Font.Name = "Microsoft Sans Serif";
            this.txtPackIDBC.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(50D);
            this.txtPackIDBC.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtPackIDBC.Value = "= \"*\"+Fields.pac_id+\"*\"";
            // 
            // txtHora
            // 
            this.txtHora.Format = "{0:t}";
            this.txtHora.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.4D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.201D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtHora.Style.Font.Bold = true;
            this.txtHora.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtHora.Value = "= Now()";
            // 
            // txtFecha
            // 
            this.txtFecha.Format = "{0:dd/MMM/yyyy}";
            this.txtFecha.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2D), Telerik.Reporting.Drawing.Unit.Inch(0.2D));
            this.txtFecha.Style.Font.Bold = true;
            this.txtFecha.Value = "= Now()";
            // 
            // RptPackIDPO
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "RptPackIDPO";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(3.75D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox txtPackID;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox txtBodega;
        private Telerik.Reporting.TextBox txtReprint;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox txtSemana;
        private Telerik.Reporting.TextBox txtLote;
        private Telerik.Reporting.TextBox txtProvPackID;
        private Telerik.Reporting.TextBox txtPO;
        private Telerik.Reporting.TextBox txtFactura;
        private Telerik.Reporting.TextBox txtCodigo;
        private Telerik.Reporting.TextBox txtDescripcion;
        private Telerik.Reporting.TextBox txtProveedor;
        private Telerik.Reporting.TextBox txtLibras;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox txtPackIDBC;
        private Telerik.Reporting.TextBox txtHora;
        private Telerik.Reporting.TextBox txtFecha;
    }
}