using Rmc.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Wainari.Vista.Movimientos
{
    public partial class ImportarPackList : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql = null;
        SqlConnection conn;

        public int facdID { get; set; }
        public double libras { get; set; }
        double SumLibras = 0;
        public ImportarPackList()
        {
            InitializeComponent();
            conn = sc.OpenConection();

            var font1 = ThemeResolutionService.GetCustomFont("TelerikWebUI");
            btnImportar.ButtonElement.CustomFont = font1.Name;
            btnImportar.ButtonElement.CustomFontSize = 13;
            btnImportar.ButtonElement.ToolTipText = "Importar";
            btnImportar.Text = "\ue133"+ " Importar"; 

            btnCancelar.ButtonElement.CustomFont = font1.Name;
            btnCancelar.ButtonElement.CustomFontSize = 13;
            btnCancelar.ButtonElement.ToolTipText = "Cancelar";
            btnCancelar.Text = "\ue115" + " Cancelar"; 

            rgvPackList.Rows.AddNew();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgvPackList.Rows.Count > 0 && !rgvPackList.Rows[0].Cells[0].Value.ToString().Equals(""))
                {
                    DialogResult confirmacion1 = RadMessageBox.Show("¿Desea actualizar el Pack List?", "Confirmación", MessageBoxButtons.OKCancel, RadMessageIcon.Question);
                    if (confirmacion1 == DialogResult.OK)
                    {

                        if (ValidarLibras())
                        {
                            this.IngresarPackList();
                            
                        }
                        else
                        {
                            MessageBox.Show(
                                "La suma de libras no coincide con el peso ingresado en el detalle de la factura.\nNo puede continuar.",
                                "¡Alto!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop
                            );

                        }
                    }
                }
                else
                    RadMessageBox.Show("No hay datos para realizar la actualización");
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message.ToString());
            }
        }
        private bool ValidarLibras()
        {
            bool validar = true;
            SumLibras=0;
            foreach (GridViewRowInfo row in rgvPackList.Rows)
            {
                SumLibras += double.Parse(row.Cells[1].Value.ToString());
            }
            sql = "Select ISNULL(SUM(pac_libras),0) FROM wai_Pack_List WHERE pac_factura_detalle_id='" + facdID + "'";
            sc.OpenConection();
            SumLibras = SumLibras + double.Parse(sc.DevValorString(sql));
            sc.CloseConection();
            double LibrasComparar = Math.Round(SumLibras, 3);
            if (LibrasComparar != libras)
            {
                validar = false;
            }
            
            return validar;
        }

        private void IngresarPackList()
        {
            try
            {
                bool procesado = true;
                int contador = 0;

                using (SqlConnection conn = sc.OpenConection())
                {
                    for (int i = 0; i < rgvPackList.Rows.Count; i++)
                    {
                        var row = rgvPackList.Rows[i];

                        // Validar fecha
                        DateTime fechaProduccion;
                        if (!DateTime.TryParse(row.Cells["fecha_produccion"].Value?.ToString(), out fechaProduccion))
                        {
                            contador++;
                            continue;
                        }

                        string sql = @"INSERT INTO wai_Pack_List 
                    (pac_factura_detalle_id, pac_prov_pack_id, pac_libras, pac_impreso, pac_fecha_produccion, pac_usuario_crea, pac_fecha_crea) 
                    VALUES (@facdID, @provPackID, @libras, 0, @fechaProduccion, @usuarioCrea, GETDATE())";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@facdID", facdID);
                            cmd.Parameters.AddWithValue("@provPackID", row.Cells["prov_pack_id"].Value?.ToString());
                            cmd.Parameters.AddWithValue("@libras", Convert.ToDouble(row.Cells["libras"].Value));
                            cmd.Parameters.AddWithValue("@fechaProduccion", fechaProduccion);
                            cmd.Parameters.AddWithValue("@usuarioCrea", sc.Usuario);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch
                            {
                                procesado = false;
                            }
                        }
                    }
                }

                if (contador > 0)
                {
                    RadMessageBox.Show($"Existen {contador} fechas con formato incorrecto.\nCorrige antes de continuar.", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else if (procesado)
                {
                    RadMessageBox.Show("Pack List Ingresado", "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);
                    this.Dispose();
                }
                else
                {
                    RadMessageBox.Show("Error al procesar el Pack List", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

    }
}