using Rmc.Clases;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.Consultas
{
    public partial class InputBox : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int idInventario;
        int idLocalidad;
        string packID;

        public InputBox(int idInventario, int idLocalidad, string packID)
        {
            InitializeComponent();
            this.idInventario = idInventario;
            this.idLocalidad = idLocalidad;
            this.packID = packID;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLibras.Text.Trim() == "")
                {
                    RadMessageBox.Show("Debe ingresar las libras antes de continuar", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else
                {
                    string libras = txtLibras.Text.ToString();

                    string subPackID = packID.Substring(0, 1);
                    string invLoc = "";
                    sql = "SELECT invl_id FROM wai_Inventario_Localidad WHERE invl_inventario_id='" + this.idInventario + "' AND invl_localidad_id='" + this.idLocalidad + "' ";
                    sc.OpenConection();
                    invLoc = sc.DevValorString(sql);
                    sc.CloseConection();
                    if (!libras.Equals(""))
                    {
                        sql = "INSERT INTO wai_Inventario_Escaneos (inve_localidadinventario_id, inve_packid, inve_libras, inve_escaneado, inve_nuevo, inve_eliminado, inve_usuario_crea, inve_DT_crea) "
                            + " VALUES('" + invLoc + "', '" + packID + "', '" + libras + "', '1', '0', '0', '" + sc.Usuario + "', GETDATE());";
                        sc.OpenConection();
                        sc.EjecutarQuery(sql);
                        sc.CloseConection();
                        if (subPackID.Equals("D"))
                        {
                            sql = "UPDATE wai_Devoluciones SET dev_libras = dev_libras + " + double.Parse(libras) + ", dev_localidad_id = '" + this.idLocalidad + "', dev_fecha_out = NULL WHERE dev_codigo ='" + this.packID + "'";
                        }
                        else
                        {
                            sql = "UPDATE wai_Pack_List SET pac_libras = pac_libras + " + double.Parse(libras) + ", pac_localidad_id='" + this.idLocalidad + "', pac_scan_whout = NULL WHERE pac_id ='" + this.packID + "'";
                        }
                        sc.OpenConection();
                        sc.EjecutarQuery(sql);
                        sc.CloseConection();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
