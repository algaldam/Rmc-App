using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rmc.Reportes.ReportesForm;
using Telerik.WinControls;

namespace Rmc.Consultas
{
    public partial class ConsOrdenes : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        string transID;

        public ConsOrdenes()
        {
            InitializeComponent();
            sc.PermisosBotoneria(BtnActualizar, BtnEliminar, sc.Usuario, sc.AppID, "ConsOrdenes", 'L');
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtOrden.Text != "")
            {
                Buscar();
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (transID != null)
            {
                try
                {
                    FrmOrden frmOrden = new FrmOrden();

                    sql = "SET LANGUAGE Spanish;SELECT T.tra_semana, CASE WHEN T.tra_turno= 0 THEN 'Diurno' ELSE 'Nocturno' END AS turno, "
                        + "DATENAME(dw,T.tra_fecha_crea) AS dia, U.Usr_Name AS usuario, T.tra_fecha_crea AS fecha FROM pmc_Trans AS T"
                        + " LEFT JOIN mst_Users AS U ON U.Usr_Login=T.tra_usuario_crea WHERE T.tra_id = '" + transID + "'";

                    sc.OpenConection();
                    string[] parametros = sc.DevArray(sql);
                    sc.CloseConection();
                    if (parametros.Length > 0)
                    {
                        frmOrden.AsignarParametros(transID, parametros[0].ToString(), parametros[1].ToString(), parametros[2].ToString(), parametros[3].ToString(), parametros[4].ToString());

                        frmOrden.Show();
                    }
                    else
                    {
                        MessageBox.Show("Orden no encontrada", "No Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe buscar una orden", "Fallo de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (transID != null)
            {
                try
                {
                    DataSet ds = (DataSet)GridOrden.DataSource;
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        sql = "EXEC usp_pmc_Ordenes '" + transID + "','" + sc.Usuario + "','" + dr[0].ToString() + "','" + dr[7].ToString() + "','U'";
                        //MessageBox.Show(dr[0].ToString()+", "+dr[7].ToString());
                        /*sql = "DECLARE @semanaID varchar(7) = (SELECT CONCAT(tra_anio,'-',tra_semana) FROM pmc_Trans WHERE tra_id='"+transID+"');"
                            + " UPDATE pmc_Trans_Det SET trad_cantidad = '" + dr[7].ToString() + "', "
                            + " trad_user_mod = '" + sc.Usuario + "', trad_fecha_mod = GETDATE() "
                            + " OUTPUT '" + sc.Usuario + "','pmc_Trans_Det','UPDATE CANTIDAD ORDEN',"
                            + " @semanaID,"
                            + " CONCAT('ORDEN:', INSERTED.trad_tra_id,'- SACA:',INSERTED.trad_SACA,' - ITEM:',INSERTED.trad_producto,' - CANTIDAD:',INSERTED.trad_cantidad), "
                            + " CONCAT('ORDEN:', DELETED.trad_tra_id,'- SACA:',DELETED.trad_SACA,' - ITEM:',DELETED.trad_producto,' - CANTIDAD:',DELETED.trad_cantidad), "
                            + " GETDATE() INTO pmc_Auditoria "
                            + " WHERE trad_id ='" + dr[0].ToString() + "' ";*/
                        //Console.WriteLine(sql);
                        sc.OpenConection();
                        sc.EjecutarQuery(sql);
                        sc.CloseConection();
                    }
                    GridOrden.DataSource = null;
                    MessageBox.Show("Orden Actualizada", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "SELECT TD.trad_id,F.flu_nombre, T.tra_anio, T.tra_semana, TD.trad_SACA, TD.trad_producto, "
                            + " TD.trad_desviacion, TD.trad_cantidad, TD.trad_ubicacion, TD.trad_ubicacion_cantidad "
                            + " FROM pmc_Trans AS T "
                            + " INNER JOIN pmc_Trans_Det AS TD ON TD.trad_tra_id = T.tra_id "
                            + " INNER JOIN pmc_Flujo AS F ON F.flu_id = TD.trad_flujo_id "
                            + " WHERE T.tra_id = '" + transID + "'";
                    sc.OpenConection();
                    sc.LlenarGrid(GridOrden, sql, "x", "x");
                    sc.CloseConection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe buscar una orden", "Fallo de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (transID != null)
            {
                try
                {
                    DataSet ds = (DataSet)GridOrden.DataSource;
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        //MessageBox.Show(dr[0].ToString()+", "+dr[7].ToString());
                        sql = "EXEC usp_pmc_Ordenes '" + transID + "','" + sc.Usuario + "','" + dr[0].ToString() + "','" + dr[7].ToString() + "','D'";
                        /*sql = "DECLARE @semanaID varchar(7) = (SELECT CONCAT(tra_anio,'-',tra_semana) FROM pmc_Trans WHERE tra_id='" + transID + "');"
                            + " UPDATE pmc_Trans_Det SET trad_cantidad = 0 , "
                            + " trad_user_mod = '" + sc.Usuario + "', trad_fecha_mod = GETDATE() "
                            + " OUTPUT '" + sc.Usuario + "','pmc_Trans_Det','DELETE ORDEN',"
                            + " @semanaID,"
                            + " CONCAT('ORDEN:', INSERTED.trad_tra_id,'- SACA:',INSERTED.trad_SACA,' - ITEM:',INSERTED.trad_producto,' - CANTIDAD:',INSERTED.trad_cantidad), "
                            + " CONCAT('ORDEN:', DELETED.trad_tra_id,'- SACA:',DELETED.trad_SACA,' - ITEM:',DELETED.trad_producto,' - CANTIDAD:',DELETED.trad_cantidad), "
                            + " GETDATE() INTO pmc_Auditoria "
                            + " WHERE trad_id ='" + dr[0].ToString() + "' ";*/
                        sc.OpenConection();
                        sc.EjecutarQuery(sql);
                        sc.CloseConection();
                    }
                    GridOrden.DataSource = null;
                    MessageBox.Show("Orden Actualizada", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "SELECT TD.trad_id,F.flu_nombre, T.tra_anio, T.tra_semana, TD.trad_SACA, TD.trad_producto, "
                            + " TD.trad_desviacion, TD.trad_cantidad, TD.trad_ubicacion, TD.trad_ubicacion_cantidad "
                            + " FROM pmc_Trans AS T "
                            + " INNER JOIN pmc_Trans_Det AS TD ON TD.trad_tra_id = T.tra_id "
                            + " INNER JOIN pmc_Flujo AS F ON F.flu_id = TD.trad_flujo_id "
                            + " WHERE T.tra_id = '" + transID + "'";
                    sc.OpenConection();
                    sc.LlenarGrid(GridOrden, sql, "x", "x");
                    sc.CloseConection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe buscar una orden", "Fallo de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (TxtOrden.Text != "")
                {
                    Buscar();
                }
            }
        }

        private void Buscar()
        {
            transID = TxtOrden.Text.ToString();

            try
            {
                GridOrden.DataSource = null;
                sql = "SELECT TD.trad_id,F.flu_nombre, T.tra_anio, T.tra_semana, TD.trad_SACA, TD.trad_producto, "
                        + " TD.trad_desviacion, TD.trad_cantidad, TD.trad_ubicacion, TD.trad_ubicacion_cantidad "
                        + " FROM pmc_Trans AS T "
                        + " INNER JOIN pmc_Trans_Det AS TD ON TD.trad_tra_id = T.tra_id "
                        + " INNER JOIN pmc_Flujo AS F ON F.flu_id = TD.trad_flujo_id "
                        + " WHERE T.tra_id = '" + transID + "'";
                sc.OpenConection();
                sc.LlenarGrid(GridOrden, sql, "x", "x");
                sc.CloseConection();
                sc.PermisosBotoneria(this.BtnActualizar, this.BtnEliminar, sc.Usuario, sc.AppID, "ConsOrdenes", 'U');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
    }
}
