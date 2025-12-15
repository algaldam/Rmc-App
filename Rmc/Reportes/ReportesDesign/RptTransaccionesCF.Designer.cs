namespace Rmc.Reportes.ReportesDesign
{
    partial class RptTransaccionesCF
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptTransaccionesCF));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.fLUJODataTextBox = new Telerik.Reporting.TextBox();
            this.aNIODataTextBox = new Telerik.Reporting.TextBox();
            this.sEMANADataTextBox = new Telerik.Reporting.TextBox();
            this.sACADataTextBox = new Telerik.Reporting.TextBox();
            this.pRODUCTODataTextBox = new Telerik.Reporting.TextBox();
            this.dESVIACIONDataTextBox = new Telerik.Reporting.TextBox();
            this.sILUETADataTextBox = new Telerik.Reporting.TextBox();
            this.mILLSTYLEDataTextBox = new Telerik.Reporting.TextBox();
            this.tALLADataTextBox = new Telerik.Reporting.TextBox();
            this.pORCENTAJEDataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADTOTALDataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADREALDataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADENTREGADADataTextBox = new Telerik.Reporting.TextBox();
            this.cANTIDADRESTANTEDataTextBox = new Telerik.Reporting.TextBox();
            this.sOBRANTEDataTextBox = new Telerik.Reporting.TextBox();
            this.sOBRECONSUMODataTextBox = new Telerik.Reporting.TextBox();
            this.tOTALDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Rmc.Properties.Settings.ESSOCKS";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@anio", System.Data.DbType.String, "= Parameters.anio.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@semana", System.Data.DbType.String, "= Parameters.semana.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@flujo", System.Data.DbType.String, "= Parameters.flujo.Value")});
            this.sqlDataSource1.SelectCommand = resources.GetString("sqlDataSource1.SelectCommand");
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4791666269302368D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Reporte de Transacciones";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.4479165077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(12.5D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.4479165077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.518750011920929D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.31875011324882507D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Reporte de Transacciones";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.sOBRECONSUMODataTextBox,
            this.tOTALDataTextBox,
            this.fLUJODataTextBox,
            this.aNIODataTextBox,
            this.sEMANADataTextBox,
            this.sACADataTextBox,
            this.pRODUCTODataTextBox,
            this.dESVIACIONDataTextBox,
            this.sILUETADataTextBox,
            this.mILLSTYLEDataTextBox,
            this.tALLADataTextBox,
            this.pORCENTAJEDataTextBox,
            this.cANTIDADTOTALDataTextBox,
            this.cANTIDADREALDataTextBox,
            this.cANTIDADENTREGADADataTextBox,
            this.cANTIDADRESTANTEDataTextBox,
            this.sOBRANTEDataTextBox});
            this.detail.Name = "detail";
            // 
            // fLUJODataTextBox
            // 
            this.fLUJODataTextBox.CanGrow = true;
            this.fLUJODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.fLUJODataTextBox.Name = "fLUJODataTextBox";
            this.fLUJODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.fLUJODataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.fLUJODataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.fLUJODataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.fLUJODataTextBox.Style.Font.Name = "Calibri";
            this.fLUJODataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.fLUJODataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.fLUJODataTextBox.StyleName = "Data";
            this.fLUJODataTextBox.Value = "= Fields.FLUJO";
            // 
            // aNIODataTextBox
            // 
            this.aNIODataTextBox.CanGrow = true;
            this.aNIODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0000787973403931D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.aNIODataTextBox.Name = "aNIODataTextBox";
            this.aNIODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.aNIODataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.aNIODataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.aNIODataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.aNIODataTextBox.Style.Font.Name = "Calibri";
            this.aNIODataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.aNIODataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.aNIODataTextBox.StyleName = "Data";
            this.aNIODataTextBox.Value = "= Fields.ANIO";
            // 
            // sEMANADataTextBox
            // 
            this.sEMANADataTextBox.CanGrow = true;
            this.sEMANADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sEMANADataTextBox.Name = "sEMANADataTextBox";
            this.sEMANADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sEMANADataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.sEMANADataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.sEMANADataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.sEMANADataTextBox.Style.Font.Name = "Calibri";
            this.sEMANADataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.sEMANADataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.sEMANADataTextBox.StyleName = "Data";
            this.sEMANADataTextBox.Value = "= Fields.SEMANA";
            // 
            // sACADataTextBox
            // 
            this.sACADataTextBox.CanGrow = true;
            this.sACADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sACADataTextBox.Name = "sACADataTextBox";
            this.sACADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sACADataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.sACADataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.sACADataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.sACADataTextBox.Style.Font.Name = "Calibri";
            this.sACADataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.sACADataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.sACADataTextBox.StyleName = "Data";
            this.sACADataTextBox.Value = "= Fields.SACA";
            // 
            // pRODUCTODataTextBox
            // 
            this.pRODUCTODataTextBox.CanGrow = true;
            this.pRODUCTODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pRODUCTODataTextBox.Name = "pRODUCTODataTextBox";
            this.pRODUCTODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pRODUCTODataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.pRODUCTODataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pRODUCTODataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.pRODUCTODataTextBox.Style.Font.Name = "Calibri";
            this.pRODUCTODataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.pRODUCTODataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pRODUCTODataTextBox.StyleName = "Data";
            this.pRODUCTODataTextBox.Value = "= Fields.PRODUCTO";
            // 
            // dESVIACIONDataTextBox
            // 
            this.dESVIACIONDataTextBox.CanGrow = true;
            this.dESVIACIONDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.dESVIACIONDataTextBox.Name = "dESVIACIONDataTextBox";
            this.dESVIACIONDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.dESVIACIONDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.dESVIACIONDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.dESVIACIONDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.dESVIACIONDataTextBox.Style.Font.Name = "Calibri";
            this.dESVIACIONDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.dESVIACIONDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.dESVIACIONDataTextBox.StyleName = "Data";
            this.dESVIACIONDataTextBox.Value = "= Fields.DESVIACION";
            // 
            // sILUETADataTextBox
            // 
            this.sILUETADataTextBox.CanGrow = true;
            this.sILUETADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.0000786781311035D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sILUETADataTextBox.Name = "sILUETADataTextBox";
            this.sILUETADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sILUETADataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.sILUETADataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.sILUETADataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.sILUETADataTextBox.Style.Font.Name = "Calibri";
            this.sILUETADataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.sILUETADataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.sILUETADataTextBox.StyleName = "Data";
            this.sILUETADataTextBox.Value = "= Fields.SILUETA";
            // 
            // mILLSTYLEDataTextBox
            // 
            this.mILLSTYLEDataTextBox.CanGrow = true;
            this.mILLSTYLEDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.000394344329834D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.mILLSTYLEDataTextBox.Name = "mILLSTYLEDataTextBox";
            this.mILLSTYLEDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.mILLSTYLEDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.mILLSTYLEDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.mILLSTYLEDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.mILLSTYLEDataTextBox.Style.Font.Name = "Calibri";
            this.mILLSTYLEDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.mILLSTYLEDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.mILLSTYLEDataTextBox.StyleName = "Data";
            this.mILLSTYLEDataTextBox.Value = "= Fields.MILLSTYLE";
            // 
            // tALLADataTextBox
            // 
            this.tALLADataTextBox.CanGrow = true;
            this.tALLADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.0004730224609375D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tALLADataTextBox.Name = "tALLADataTextBox";
            this.tALLADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.tALLADataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.tALLADataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tALLADataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.tALLADataTextBox.Style.Font.Name = "Calibri";
            this.tALLADataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.tALLADataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tALLADataTextBox.StyleName = "Data";
            this.tALLADataTextBox.Value = "= Fields.TALLA";
            // 
            // pORCENTAJEDataTextBox
            // 
            this.pORCENTAJEDataTextBox.CanGrow = true;
            this.pORCENTAJEDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0005521774292D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pORCENTAJEDataTextBox.Name = "pORCENTAJEDataTextBox";
            this.pORCENTAJEDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.999448835849762D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pORCENTAJEDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.pORCENTAJEDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pORCENTAJEDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.pORCENTAJEDataTextBox.Style.Font.Name = "Calibri";
            this.pORCENTAJEDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.pORCENTAJEDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.pORCENTAJEDataTextBox.StyleName = "Data";
            this.pORCENTAJEDataTextBox.Value = "= Fields.PORCENTAJE";
            // 
            // cANTIDADTOTALDataTextBox
            // 
            this.cANTIDADTOTALDataTextBox.CanGrow = true;
            this.cANTIDADTOTALDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cANTIDADTOTALDataTextBox.Name = "cANTIDADTOTALDataTextBox";
            this.cANTIDADTOTALDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADTOTALDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.cANTIDADTOTALDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.cANTIDADTOTALDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.cANTIDADTOTALDataTextBox.Style.Font.Name = "Calibri";
            this.cANTIDADTOTALDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.cANTIDADTOTALDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.cANTIDADTOTALDataTextBox.StyleName = "Data";
            this.cANTIDADTOTALDataTextBox.Value = "= Fields.CANTIDADTOTAL";
            // 
            // cANTIDADREALDataTextBox
            // 
            this.cANTIDADREALDataTextBox.CanGrow = true;
            this.cANTIDADREALDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(11.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cANTIDADREALDataTextBox.Name = "cANTIDADREALDataTextBox";
            this.cANTIDADREALDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADREALDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.cANTIDADREALDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.cANTIDADREALDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.cANTIDADREALDataTextBox.Style.Font.Name = "Calibri";
            this.cANTIDADREALDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.cANTIDADREALDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.cANTIDADREALDataTextBox.StyleName = "Data";
            this.cANTIDADREALDataTextBox.Value = "= Fields.CANTIDADREAL";
            // 
            // cANTIDADENTREGADADataTextBox
            // 
            this.cANTIDADENTREGADADataTextBox.CanGrow = true;
            this.cANTIDADENTREGADADataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(12.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cANTIDADENTREGADADataTextBox.Name = "cANTIDADENTREGADADataTextBox";
            this.cANTIDADENTREGADADataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADENTREGADADataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.cANTIDADENTREGADADataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.cANTIDADENTREGADADataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.cANTIDADENTREGADADataTextBox.Style.Font.Name = "Calibri";
            this.cANTIDADENTREGADADataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.cANTIDADENTREGADADataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.cANTIDADENTREGADADataTextBox.StyleName = "Data";
            this.cANTIDADENTREGADADataTextBox.Value = "= Fields.CANTIDADENTREGADA";
            // 
            // cANTIDADRESTANTEDataTextBox
            // 
            this.cANTIDADRESTANTEDataTextBox.CanGrow = true;
            this.cANTIDADRESTANTEDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(13.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.cANTIDADRESTANTEDataTextBox.Name = "cANTIDADRESTANTEDataTextBox";
            this.cANTIDADRESTANTEDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.cANTIDADRESTANTEDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.cANTIDADRESTANTEDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.cANTIDADRESTANTEDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.cANTIDADRESTANTEDataTextBox.Style.Font.Name = "Calibri";
            this.cANTIDADRESTANTEDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.cANTIDADRESTANTEDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.cANTIDADRESTANTEDataTextBox.StyleName = "Data";
            this.cANTIDADRESTANTEDataTextBox.Value = "= Fields.CANTIDADRESTANTE";
            // 
            // sOBRANTEDataTextBox
            // 
            this.sOBRANTEDataTextBox.CanGrow = true;
            this.sOBRANTEDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(14.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sOBRANTEDataTextBox.Name = "sOBRANTEDataTextBox";
            this.sOBRANTEDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sOBRANTEDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.sOBRANTEDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.sOBRANTEDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.sOBRANTEDataTextBox.Style.Font.Name = "Calibri";
            this.sOBRANTEDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.sOBRANTEDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.sOBRANTEDataTextBox.StyleName = "Data";
            this.sOBRANTEDataTextBox.Value = "= Fields.SOBRANTE";
            // 
            // sOBRECONSUMODataTextBox
            // 
            this.sOBRECONSUMODataTextBox.CanGrow = true;
            this.sOBRECONSUMODataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(15.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.sOBRECONSUMODataTextBox.Name = "sOBRECONSUMODataTextBox";
            this.sOBRECONSUMODataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992120265960693D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.sOBRECONSUMODataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.sOBRECONSUMODataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.sOBRECONSUMODataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.sOBRECONSUMODataTextBox.Style.Font.Name = "Calibri";
            this.sOBRECONSUMODataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.sOBRECONSUMODataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.sOBRECONSUMODataTextBox.StyleName = "Data";
            this.sOBRECONSUMODataTextBox.Value = "= Fields.SOBRECONSUMO";
            // 
            // tOTALDataTextBox
            // 
            this.tOTALDataTextBox.CanGrow = true;
            this.tOTALDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(16.000078201293945D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.tOTALDataTextBox.Name = "tOTALDataTextBox";
            this.tOTALDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.999922513961792D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.tOTALDataTextBox.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.tOTALDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.tOTALDataTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.tOTALDataTextBox.Style.Font.Name = "Calibri";
            this.tOTALDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(11D);
            this.tOTALDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.tOTALDataTextBox.StyleName = "Data";
            this.tOTALDataTextBox.Value = "= Fields.TOTAL";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox1.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Value = "Flujo";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0000787973403931D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox2.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Value = "Año";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox3.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Value = "Semana";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0000789165496826D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox4.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Value = "SACA";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.0001578330993652D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox5.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Value = "Producto";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.0002365112304688D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox6.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.Value = "Desviación";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.0003151893615723D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox7.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Value = "Silueta";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.000394344329834D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox8.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox8.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Value = "MillStyle";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.0004730224609375D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox9.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox9.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Value = "Talla";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0005521774292D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99944877624511719D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox10.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox10.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Value = "Porcentaje";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.000080108642578D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99991989135742188D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox11.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Value = "Cantidad Plan";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(11D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox12.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox12.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Value = "Cantidad Real";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(12.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox13.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox13.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Value = "Entregado";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(13.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox14.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox14.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Value = "Restante";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(14.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox15.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox15.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Value = "Sobrante";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(15.000079154968262D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992114305496216D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox16.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox16.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.Value = "Sobreconsumo";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(16.000078201293945D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99992245435714722D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox17.Style.BorderColor.Default = System.Drawing.Color.Gray;
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.10000000149011612D);
            this.textBox17.Style.Font.Name = "Microsoft Sans Serif";
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.Value = "TOTAL";
            // 
            // RptTransaccionesCF
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "RptTransaccionesCF";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(18D), Telerik.Reporting.Drawing.Unit.Inch(11D));
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "anio";
            reportParameter1.Text = "anio";
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "semana";
            reportParameter2.Text = "semana";
            reportParameter3.AllowNull = true;
            reportParameter3.Name = "flujo";
            reportParameter3.Text = "flujo";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule2.Style.Font.Name = "Calibri";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule3.Style.Font.Name = "Calibri";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule4.Style.Font.Name = "Calibri";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            styleRule5.Style.Font.Name = "Calibri";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(17.000001907348633D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox fLUJODataTextBox;
        private Telerik.Reporting.TextBox aNIODataTextBox;
        private Telerik.Reporting.TextBox sEMANADataTextBox;
        private Telerik.Reporting.TextBox sACADataTextBox;
        private Telerik.Reporting.TextBox pRODUCTODataTextBox;
        private Telerik.Reporting.TextBox dESVIACIONDataTextBox;
        private Telerik.Reporting.TextBox sILUETADataTextBox;
        private Telerik.Reporting.TextBox mILLSTYLEDataTextBox;
        private Telerik.Reporting.TextBox tALLADataTextBox;
        private Telerik.Reporting.TextBox pORCENTAJEDataTextBox;
        private Telerik.Reporting.TextBox cANTIDADTOTALDataTextBox;
        private Telerik.Reporting.TextBox cANTIDADREALDataTextBox;
        private Telerik.Reporting.TextBox cANTIDADENTREGADADataTextBox;
        private Telerik.Reporting.TextBox cANTIDADRESTANTEDataTextBox;
        private Telerik.Reporting.TextBox sOBRANTEDataTextBox;
        private Telerik.Reporting.TextBox sOBRECONSUMODataTextBox;
        private Telerik.Reporting.TextBox tOTALDataTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;

    }
}