using Rmc.Clases;
using Rmc.Controllers;
using Rmc.Reportes.ReportesDesign;
using Rmc.RMC.Warehouse.Transactions.Request.Exits;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Wainari.Vista.Movimientos
{
    public partial class VerLista : Telerik.WinControls.UI.RadForm
    {
        string sql;
        public int facdID { get; set; }
        SystemClass sc = new SystemClass();
        SqlConnection conn;
        POController PControl = new POController();
        FontFamily font1 = ThemeResolutionService.GetCustomFont("TelerikWebUI");
        public VerLista()
        {
            InitializeComponent();
            conn = sc.OpenConection();
        }

        public int bodegaID { get; set; }

        public void LlenarGrid()
        {
            try
            {
                sql = "SELECT PL.pac_id, PL.pac_factura_detalle_id, L.loc_nombre, PL.pac_prov_pack_id, PL.pac_libras, "
                    + " PL.pac_impreso, PL.pac_scan_whin, PL.pac_scan_whout FROM wai_Pack_List PL "
                    + " LEFT JOIN wai_Localidad L ON PL.pac_localidad_id = L.loc_id "
                    + " WHERE PL.pac_factura_detalle_id='" + facdID + "'";
                sc.OpenConection();
                sc.LlenarGrid(rgvDatos, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            }
        }

        private void rgvDatos_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo is GridViewCommandColumn)
            {
                RadButtonElement button = (RadButtonElement)e.CellElement.Children[0];
                if (e.CellElement.ColumnInfo.Name == "imprimir")
                {
                    ;
                    button.CustomFont = font1.Name;
                    button.TextAlignment = ContentAlignment.MiddleCenter;
                    button.CustomFontSize = 14;
                    button.ToolTipText = "Reimprimir";
                    button.Text = "\ue10A";
                }
                else if (e.CellElement.ColumnInfo.Name == "eliminar")
                {
                    button.CustomFont = font1.Name;
                    button.TextAlignment = ContentAlignment.MiddleCenter;
                    button.CustomFontSize = 14;
                    button.ToolTipText = "Eliminar";
                    button.Text = "\ue10C";
                }

            }
        }

        private void rgvDatos_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (e.Column.Name.Equals("eliminar"))
                        EliminarPackId(e.Row.Cells[2].Value.ToString());
                    if (e.Column.Name.Equals("imprimir"))
                        ImprimirPackID(e.Row.Cells[2].Value.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void EliminarPackId(string PackID)
        {
            try
            {
                DialogResult confirmacion1 = MessageBox.Show(
                    "Se eliminará el Pack ID " + PackID + " del Pack List. ¿Desea continuar?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation
                );

                if (confirmacion1 == DialogResult.Yes)
                {
                    string sql = "SELECT COUNT(*) FROM wai_Transacciones WHERE tra_pack_list_id ='" + PackID + "' ";
                    sc.OpenConection();

                    if (int.Parse(sc.DevValorString(sql)) > 0)
                    {
                        DialogResult confirmacion2 = MessageBox.Show(
                            "El Pack ID " + PackID + " tiene registros de salida, ¿Está seguro de eliminarlo?",
                            "Confirmación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation
                        );

                        if (confirmacion2 == DialogResult.Yes)
                        {
                            EliminarPackId2(PackID);
                        }
                    }
                    else
                    {
                        EliminarPackId2(PackID);
                    }

                    LlenarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarPackId2(string PackID)
        {
            try
            {
                string sql = "DELETE FROM wai_Transacciones WHERE tra_pack_list_id ='" + PackID + "'; DELETE FROM wai_Pack_List WHERE pac_id= '" + PackID + "'";
                sc.OpenConection();

                if (sc.EjecutarQuery(sql))
                {
                    MessageBox.Show("El registro ha sido eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El Pack ID no puede ser eliminado del Pack List.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                sc.CloseConection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirPackID(string PackID)
        {
            if (bodegaID == 4)
            {
                try
                {
                    var LDatos = PControl.ObtenerEstampaProv(PackListID: PackID);
                    ProvIDDesign reporte = new ProvIDDesign();
                    reporte.DataSource = LDatos;

                    InstanceReportSource instanceReportSource = new InstanceReportSource();
                    instanceReportSource.ReportDocument = reporte;

                    ProvIDForm popup = new ProvIDForm();
                    popup.reportViewer2.ReportSource = instanceReportSource;
                    popup.reportViewer2.RefreshReport();
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.TopLevel = true;
                    popup.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    var LDatos = PControl.ObtenerEstampaImpresion(2, PackListID: PackID);
                    PackIDDesign reporte = new PackIDDesign();
                    reporte.DataSource = LDatos;

                    InstanceReportSource instanceReportSource = new InstanceReportSource();
                    instanceReportSource.ReportDocument = reporte;

                    PackIDForm popup = new PackIDForm();
                    popup.reportViewer1.ReportSource = instanceReportSource;
                    popup.reportViewer1.RefreshReport();
                    popup.StartPosition = FormStartPosition.CenterScreen;
                    popup.TopLevel = true;
                    popup.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message.ToString());
                }
            }
        }

        private void rgvDatos_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridRowHeaderCellElement && e.Row is GridViewDataRowInfo)
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
                e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.TextImageRelationProperty, ValueResetFlags.Local);
            }
        }
    }
}