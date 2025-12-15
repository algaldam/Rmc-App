using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Consultas
{
    public partial class InventarioFisicoForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;
        string inventario;
        string item;
        string localidad;
        public int RowIndex { get; set; }
        public string ValorConcatenado { get; set; }

        public InventarioFisicoForm()
        {
            InitializeComponent();
        }

        public void AsignarParametros(string inventario, string localidad)
        {
            this.inventario = inventario;
            this.localidad = localidad;
            LlenarItems();
        }

        private void LlenarItems()
        {
            try
            {
                GridItems.DataSource = null;
                sql = "SELECT * FROM (SELECT I.ite_id AS ID, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION FROM wai_Inventario_Escaneos IE "
                + " INNER JOIN wai_Inventario_Localidad IL ON IL.invl_id = IE.inve_localidadinventario_id INNER JOIN wai_Pack_List PL ON CONVERT(VARCHAR,PL.pac_id) = IE.inve_packid "
                + " INNER JOIN wai_Factura_Detalle FD ON FD.facd_id=PL.pac_factura_detalle_id INNER JOIN wai_Item I ON I.ite_id = FD.facd_item_id "
                + " INNER JOIN wai_Localidad L ON L.loc_id = IL.invl_localidad_id "
                + " WHERE IL.invl_localidad_id='" + localidad + "' AND IL.invl_inventario_id='" + inventario + "' "
                + " UNION ALL "
                + " SELECT I.ite_id AS ID, I.ite_codigo AS CODIGO, I.ite_descripcion AS DESCRIPCION FROM wai_Inventario_Escaneos IE "
                + " INNER JOIN wai_Inventario_Localidad IL ON IL.invl_id = IE.inve_localidadinventario_id INNER JOIN wai_Devoluciones D ON CONVERT(VARCHAR,D.dev_codigo) = IE.inve_packid "
                + " INNER JOIN wai_Item I ON I.ite_id = D.dev_item_id INNER JOIN wai_Localidad L ON L.loc_id = IL.invl_localidad_id "
                + " WHERE IL.invl_localidad_id='" + localidad + "' AND IL.invl_inventario_id='" + inventario + "' ) AS ITEMS "
                + " GROUP BY ID, CODIGO, DESCRIPCION  ORDER BY CODIGO";
                sc.LlenarGrid(GridItems, sql, "x", "x");
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void GridItems_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = GridItems.CurrentRow.Index + 1;
                string itemSeleccionado = GridItems.CurrentRow.Cells["CODIGO"].Value.ToString();
                this.reportViewer1.ReportSource.Parameters["inventario"].Value = this.inventario;
                this.reportViewer1.ReportSource.Parameters["item"].Value = GridItems.CurrentRow.Cells[0].Value.ToString();
                this.reportViewer1.ReportSource.Parameters["localidad"].Value = this.localidad;
                string valorConcatenadoConRowIndex = $"{ValorConcatenado}-{rowIndex}";
                this.reportViewer1.ReportSource.Parameters["valorConcatenadoConRowIndex"].Value = valorConcatenadoConRowIndex;
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
