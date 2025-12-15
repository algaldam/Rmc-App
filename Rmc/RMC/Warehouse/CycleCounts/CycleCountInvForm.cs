using Rmc.Clases;
using Rmc.Consultas;
using Rmc.Controllers;
using Rmc.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI.Export;

namespace Rmc.RMC.Warehouse.CycleCounts
{
    public partial class CycleCountInvForm : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        string sql;
        int idInventario;
        int idLocalidad;
        string directorio;
        string tempFile;
        NConformeController NoControl = new NConformeController();
        InventarioController InvControl = new InventarioController();
        private string periodoSeleccionado = string.Empty;
        private string localidadSeleccionada = string.Empty;

        public CycleCountInvForm()
        {
            InitializeComponent();
            dtpFecha.Culture = new System.Globalization.CultureInfo("en-GB");
            dtpFecha.CustomFormat = "dd-MM-yyy";
            dtpFecha.Value = DateTime.Now;
            LlenarPeriodos();
        }

        private void ConteoCiclicoForm_Load(object sender, EventArgs e)
        {

        }

        private void LlenarPeriodos()
        {
            try
            {
                sc.OpenConection();
                sql = "SELECT  inv_id AS IDINVENTARIO, inv_periodo AS PERIODO, inv_responsable AS RESPONSABLE FROM wai_Inventario WHERE inv_activo=1 AND inv_tipo <>2";
                sc.LlenarGrid(rgvPeriodos, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void LlenarLocalidad()
        {
            try
            {
                sc.OpenConection();
                sql = "SELECT  loc_id, loc_nombre FROM wai_Localidad";
                sc.LlenarDropDownList(ddlLocalidad, sql, "loc_nombre", "loc_id");
                sc.CloseConection();
                ddlLocalidad.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void rgvPeriodos_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    idInventario = int.Parse(e.Row.Cells[0].Value.ToString());
                    periodoSeleccionado = e.Row.Cells["PERIODO"].Value.ToString(); // Asumiendo que la columna se llama "PERIODO"
                                                                                   // Asignar o guardar el valor del periodo
                    LlenarLocalidad();
                    LlenarGridLocalidad();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void bntCrearPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                string[] campos = new string[] { "txtPeriodo", "txtResponsable", "dtpFecha" };
                if (!sc.RadControlNotNull(this, campos))
                    MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    wai_Inventario Inventario = new wai_Inventario()
                    {
                        inv_periodo = txtPeriodo.Text.ToString(),
                        inv_responsable = txtResponsable.Text.ToString(),
                        inv_activo = 1,
                        inv_usuario_crea = Environment.UserName,
                        inv_tipo = 1,
                    };
                    DialogResult confirmacion1 = MessageBox.Show(
                                "Se creará un nuevo Período de Inventario ¿ Desea continuar ?", "Confirmación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                                );

                    if (confirmacion1 == DialogResult.Yes)
                    {
                        var resultado = InvControl.CrudInventarioPeriodos(1, Inventario);

                        MessageBox.Show("Proceso Correcto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPeriodo.Clear();
                        txtResponsable.Clear();
                        sc.CloseConection();
                        LlenarPeriodos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminarPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de eliminar el Período?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmacion1 == DialogResult.OK)
                {
                    string sql = "EXEC usp_wai_Inventario " + sc.Usuario + "," + idInventario + ", '', '', '' ";
                    Console.WriteLine(sql);
                    sc.OpenConection();
                    if (sc.DevValorString(sql) == "OK")
                    {
                        MessageBox.Show("Período Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Período No Eliminado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPeriodo.Clear();
                        txtResponsable.Clear();
                    }
                    sc.CloseConection();
                    LlenarPeriodos();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlLocalidad.SelectedIndex > -1)
                {
                    sql = "EXEC usp_wai_Inventario_Localidad " + sc.Usuario + ",'C','" + idInventario + "','" + ddlLocalidad.SelectedValue.ToString() + "' ";
                    sc.OpenConection();
                    string resultado = sc.DevValorString(sql);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Localidad Agregada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == "DUPLICADO")
                    {
                        MessageBox.Show("Localidad ya esta agregada en el Inventario", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Error al agregar la localidad", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sc.CloseConection();
                    LlenarGridLocalidad();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una localidad para agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void btnEliminarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgvLocalidades.CurrentRow.Index > -1)
                {
                    DialogResult confirmacion1 = MessageBox.Show("¿Está seguro de eliminar la Localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirmacion1 == DialogResult.OK)
                    {
                        sql = "EXEC usp_wai_Inventario_Localidad " + sc.Usuario + ",'D','" + idInventario + "','" + rgvLocalidades.CurrentRow.Cells[0].Value.ToString() + "' ";
                        Console.WriteLine(sql);
                        sc.OpenConection();
                        string resultado = sc.DevValorString(sql);
                        if (resultado == "OK")
                        {
                            MessageBox.Show("Localidad Eliminada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error al eliminar la localidad", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sc.CloseConection();
                        LlenarGridLocalidad();
                        LlenarGridEscaneos();
                        txtLocalidadEscaneo.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una localidad del Grid para eliminarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void LlenarGridLocalidad()
        {
            try
            {
                sc.OpenConection();
                sql = "SELECT loc_id AS IDLOCALIDAD, loc_nombre AS LOCALIDAD FROM wai_Localidad L "
                    + " INNER JOIN wai_Inventario_Localidad IL ON IL.invl_localidad_id = L.loc_id "
                    + " WHERE IL.invl_inventario_id = '" + idInventario + "' ";
                sc.LlenarGrid(rgvLocalidades, sql, "x", "x");
                sc.CloseConection();
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void rgvLocalidades_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    idLocalidad = int.Parse(e.Row.Cells[0].Value.ToString());
                    localidadSeleccionada = e.Row.Cells["LOCALIDAD"].Value.ToString(); // Asumiendo que la columna se llama "LOCALIDAD"
                                                                                       // Asignar o guardar el valor de la localidad
                    LlenarGridEscaneos();
                    txtLocalidadEscaneo.Text = e.Row.Cells[1].Value.ToString();
                    txtIdEscaneo.Focus();
                    ConcatenarValores();
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
        private void ConcatenarValores()
        {
            if (!string.IsNullOrEmpty(periodoSeleccionado) && !string.IsNullOrEmpty(localidadSeleccionada))
            {
                string concatenado = periodoSeleccionado + "" + localidadSeleccionada;
            }
            else
            {
                MessageBox.Show("Debe seleccionar ambos valores: periodo y localidad.");
            }
        }

        private void LlenarGridEscaneos()
        {
            try
            {
                sql = "SELECT IE.inve_packid AS PACKID, IE.inve_libras AS LIBRAS, IE.inve_escaneado AS ESCANEADO, IE.inve_nuevo AS NUEVO, IE.inve_eliminado AS ELIMINADO "
                            + " FROM wai_Inventario_Escaneos IE "
                            + " INNER JOIN wai_Inventario_Localidad IL ON IL.invl_id=IE.inve_localidadinventario_id "
                            + " WHERE IL.invl_inventario_id='" + idInventario + "' AND IL.invl_localidad_id='" + idLocalidad + "'";
                sc.OpenConection();
                sc.LlenarGrid(rgvEscaneos, sql, "x", "x");
                sc.CloseConection();
                var escaneados = from t in (((DataSet)rgvEscaneos.DataSource).Tables[0]).AsEnumerable()
                                 where t.Field<Int32>("ESCANEADO") == 1
                                 select new
                                 {
                                     ESCANEADO = t.Field<Int32>("ESCANEADO")
                                 };
                var pendientes = from t in (((DataSet)rgvEscaneos.DataSource).Tables[0]).AsEnumerable()
                                 where t.Field<Int32>("ESCANEADO") == 0
                                 select new
                                 {
                                     ESCANEADO = t.Field<Int32>("ESCANEADO")
                                 };
                txtEscaneados.Text = escaneados.Count().ToString();
                txtPendientes.Text = pendientes.Count().ToString();
                if (escaneados.Count() > 0)
                    txtPorcentaje.Text = (Math.Round((((double.Parse(escaneados.Count().ToString())) / (double.Parse(escaneados.Count().ToString()) + double.Parse(pendientes.Count().ToString()))) * 100), 2)).ToString() + " %";
                else
                    txtPorcentaje.Text = "0 %";

            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void txtIdEscaneo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
                {
                    if (NoControl.PackNoComforme(txtIdEscaneo.Text.ToString()) > 0 &&
                        txtLocalidadEscaneo.Text.Trim().Substring(0, 3).ToUpper() != "PNC")
                    {
                        RadMessageBox.Show("No puede mover Producto de una localidad PNC  a " + txtLocalidadEscaneo.Text.Trim(), "Warning", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    }
                    else
                    {
                        EscaneoPackID();
                        LlenarGridEscaneos();
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void EscaneoPackID()
        {
            try
            {
                if (idLocalidad != 0 && idInventario != 0)
                {
                    sql = "EXEC usp_wai_Inventario_Escaneos '" + sc.Usuario + "','" + txtIdEscaneo.Text.ToString() + "','" + idInventario + "','" + idLocalidad + "', '0'";
                    sc.OpenConection();
                    string resultado = sc.DevValorString(sql);
                    sc.CloseConection();
                    if (resultado == "ESCANEADO")
                    {
                        MessageBox.Show("El PackID ya ha sido escaneado anteriormente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == "LOCALIDAD")
                    {
                        DialogResult confirmacion1 = MessageBox.Show("El PackID no pertenece a la localidad seleccionada ¿Desea cambiarle la localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (confirmacion1 == DialogResult.OK)
                        {
                            sql = "EXEC usp_wai_Inventario_Escaneos '" + sc.Usuario + "','" + txtIdEscaneo.Text.ToString() + "','" + idInventario + "','" + idLocalidad + "', '1'";
                            sc.OpenConection();
                            resultado = sc.DevValorString(sql);
                            sc.CloseConection();

                            if (resultado == "OK")
                            {
                                MessageBox.Show("La localidad del Pack ID se ha cambiado y se ha agregado al escaneo actual.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (resultado == "LOCALIDAD2")
                    {
                        DialogResult confirmacion1 = MessageBox.Show("El PackID no pertenece al inventario ¿Desea agregarlo y hacer el cambio de localidad?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (confirmacion1 == DialogResult.OK)
                        {
                            sql = "EXEC usp_wai_Inventario_Escaneos '" + sc.Usuario + "','" + txtIdEscaneo.Text.ToString() + "','" + idInventario + "','" + idLocalidad + "', '1'";
                            Console.WriteLine(sql);
                            sc.OpenConection();
                            resultado = sc.DevValorString(sql);
                            sc.CloseConection();

                            if (resultado == "OK")
                            {
                                MessageBox.Show("La localidad del Pack ID se ha cambiado y se ha agregado al escaneo actual.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Ocurrio un error al procesar la petición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (resultado == "SALIDA")
                    {
                        DialogResult confirmacion2 = MessageBox.Show("El PackID existe en el sistema, pero ya se le dio salida ¿Desea ingresarlo nuevamente?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (confirmacion2 == DialogResult.OK)
                        {
                            InputBox inputBox = new InputBox(this.idInventario, this.idLocalidad, txtIdEscaneo.Text.ToString());
                            inputBox.StartPosition = FormStartPosition.CenterScreen;
                            inputBox.ShowDialog();
                        }
                    }
                    else if (resultado == "NOENCONTRADO")
                    {
                        MessageBox.Show("El PackID no existe en el sistema", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado != "OK")
                        MessageBox.Show("Error en el escaneo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        txtUltimoEscaneo.Text = txtIdEscaneo.Text.ToString();
                    }
                    sc.CloseConection();
                    txtIdEscaneo.Text = string.Empty;
                    LlenarGridEscaneos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el período y la localidad para poder escanear", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnDescargarCompleto_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM fn_wai_Reporte_Toma_Inventario (" + idInventario + ") ORDER BY LOC_ESCANEO";
            ExportarExcel();
        }
        private void btnDescargarConsolidado_Click(object sender, EventArgs e)
        {
            sql = "SELECT CODIGO, DESCRIPCION, ROUND(SUM(LIBRAS),2) AS LIBRAS FROM fn_wai_Reporte_Toma_Inventario (" + idInventario + ") WHERE ESCANEO='ESCANEADO' GROUP BY CODIGO, DESCRIPCION ORDER BY CODIGO";
            ExportarExcel();
        }
        private void ExportarExcel()
        {
            try
            {
                sc.LlenarGrid(GridExport, sql, "x", "x");

                for (int i = 0; i < GridExport.Columns.Count; i++)
                {
                    GridExport.Columns[i].BestFit();
                    GridExport.Columns[i].ExcelExportType = DisplayFormatType.None;
                }
                GridViewSpreadExport spreadExporter = new GridViewSpreadExport(GridExport);
                SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
                spreadExporter.FreezeHeaderRow = true;
                spreadExporter.FileExportMode = Telerik.WinControls.Export.FileExportMode.CreateOrOverrideFile;
                spreadExporter.ExportVisualSettings = false;
                spreadExporter.HiddenColumnOption = HiddenOption.DoNotExport;
                directorio = System.IO.Path.GetTempPath() + "\\Wainari";
                try
                {
                    Directory.Delete(directorio, true);
                }
                catch { }

                if (!Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);
                tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Wainari\\" + Guid.NewGuid() + ".xlsx");
                spreadExporter.RunExport(tempFile, exportRenderer);
                System.Diagnostics.Process.Start(tempFile);
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnDescargarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (idInventario != 0 && idLocalidad != 0)
                {
                    InventarioFisicoForm reporte = new InventarioFisicoForm();
                    reporte.AsignarParametros(idInventario.ToString(), idLocalidad.ToString());
                    reporte.ValorConcatenado = periodoSeleccionado + " " + localidadSeleccionada;
                    reporte.StartPosition = FormStartPosition.CenterScreen;
                    reporte.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el inventario y la localidad para generar el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgvEscaneos.CurrentRow.Index > -1)
                {
                    DialogResult confirmacion1 = MessageBox.Show("El PackID " + rgvEscaneos.CurrentRow.Cells[0].Value.ToString() + " sera eliminado de la toma de inventario ¿Desea continuar?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirmacion1 == DialogResult.OK)
                    {
                        sql = "DELETE FROM wai_Inventario_Escaneos WHERE inve_packid = '" + rgvEscaneos.CurrentRow.Cells[0].Value.ToString() + "'";
                        Console.WriteLine(sql);
                        sc.OpenConection();
                        if (sc.EjecutarQuery(sql))
                        {
                            MessageBox.Show("Pack ID eliminado", "'Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Pack ID no pudo ser eliminado, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LlenarGridEscaneos();
                    }
                }
                else
                    MessageBox.Show("Debe seleccionar un Pack ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("ERROR: " + ex.Message.ToString()); }
        }
    }
}
