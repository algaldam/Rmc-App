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
    public partial class VerDevoluciones : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;

        public VerDevoluciones()
        {
            InitializeComponent();
        }

        public void LlenarGrid()
        {
            try
            {
                sql = "SELECT D.dev_codigo AS PACKID, CONCAT(I.ite_codigo, '-', I.ite_descripcion) AS ITEM, L.loc_nombre AS LOCALIDAD, D.dev_lote AS LOTE, "
                        + " (D.dev_libras - ISNULL(D.dev_libras_out,0)) AS LIBRAS, D.dev_fecha_in AS FECHAENTRADA, D.dev_fecha_out AS FECHASALIDA, D.dev_fecha_caducidad AS FECHACADUCIDAD "
                        + " FROM wai_Item AS I "
                        + " INNER JOIN wai_Devoluciones AS D ON D.dev_item_id = I.ite_id "
                        + " LEFT JOIN wai_Localidad AS L ON L.loc_id = D.dev_localidad_id "
                        + " LEFT JOIN wai_Transacciones_Devoluciones AS TD ON TD.tra_dev_dev_id = D.dev_id "
                        + " GROUP BY D.dev_codigo, I.ite_codigo, I.ite_descripcion, L.loc_nombre, D.dev_lote, D.dev_prioridad, "
                        + " D.dev_libras, D.dev_libras_out, D.dev_fecha_in , D.dev_fecha_out, D.dev_fecha_caducidad "
                        + " ORDER BY PACKID";
                sc.OpenConection();
                sc.LlenarGrid(rgvDevoluciones, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
