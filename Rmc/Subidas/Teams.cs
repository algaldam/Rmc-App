using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.Subidas
{
    public partial class Celulas : Telerik.WinControls.UI.RadForm
    {
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.TracerConnectionString);
        SystemClass sc = new SystemClass();
        string sql;
        SqlCommand cm = null;

        public Celulas()
        {
            InitializeComponent();
        }

        private void Celulas_Load(object sender, EventArgs e)
        {

        }
        private void SetGrid(RadGridView gv, DataTable dt)
        {
            int columnas = 0;
            int filas = 0;
            //Evaluación de datos para carga manual
            columnas = dt.Columns.Count;
            filas = dt.Rows.Count;

            if (columnas != 3)
            {
                //Falta alguna columna
                MessageBox.Show("Cantidad de columnas incompletas. Favor revisar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Las columnas están completas
                int contadorErrores = 0;
                var strHeaders = new[] { "CelulaID", "Celula", "Turno"};
                //Analizar filas a cargar
                for (int i = 0; i < filas; i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            //Evaluación de Headers
                            var strBuscar = dt.Columns[j].ToString();
                            if (!strHeaders.Any(strBuscar.Contains))
                            {
                                MessageBox.Show("El siguiente header no se encuentra en la tabla destino: " + strBuscar, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                contadorErrores++;
                                return;
                            }
                        }
                    }
                }
                //Al no haber ningún error, se carga la data en el Grid
                BindingSource bs = new BindingSource();
                try
                {
                    bs.DataSource = dt;
                    gv.DataSource = bs;
                    lblNumRegistrosOrden.Text = GridCelulas.Rows.Count.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cargar los datos ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void CargaCelulas_Click(object sender, EventArgs e)
        {
            // Validar que el RadBrowseEditor no esté vacío
            if (string.IsNullOrEmpty(BrowseCelulas.Text))
            {
                MessageBox.Show("Debe seleccionar un archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "DELETE FROM pmc_Celulas";
            sc.OpenConectionTracer();
            sc.EjecutarQueryTracer(sql);
            sc.CloseConectionTracer();
            try
            {
                sc.OpenConectionTracer();
                cm = new SqlCommand();
                cm.Connection = cn;
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlTransaction transaction = cn.BeginTransaction();
                if (transaction == null)
                {
                    MessageBox.Show("No se ha podido iniciar una transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cm.Transaction = transaction;
                for (int i = 0; i < GridCelulas.Rows.Count; i++)
                {
                    GridViewRowInfo row = GridCelulas.Rows[i];
                    cm.CommandText = @" INSERT INTO [pmc_Celulas] (CelulaID, Celula, Turno )
                                         VALUES(@CelulaID, @Celula, @Turno)";


                    cm.Parameters.Clear();
                    // Agregar parámetros aquí, utilizando los valores de cada celda de la fila actual
                    cm.Parameters.AddWithValue("@CelulaID", row.Cells[0].Value == null ? (object)DBNull.Value : row.Cells[0].Value.ToString());
                    cm.Parameters.AddWithValue("@Celula", row.Cells[1].Value == null ? (object)DBNull.Value : row.Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@Turno", row.Cells[2].Value == null ? (object)DBNull.Value : row.Cells[2].Value.ToString());

                    cm.ExecuteNonQuery();
                }
                transaction.Commit();
                //Mostrar un mensaje de éxito
                MessageBox.Show("Orden guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridCelulas.DataSource = null;
                lblNumRegistrosOrden.Text = GridCelulas.Rows.Count.ToString();
            }
            catch (Exception error)
            {
                //Mostrar un mensaje de error
                MessageBox.Show("Ha ocurrido un error al guardar las órdenes: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Cerrar la conexión
                sc.CloseConectionTracer();
            }
        }

        private void BrowseCelulas_Click(object sender, EventArgs e)
        {
            GridCelulas.DataSource = null;
            lblNumRegistrosOrden.Text = "0";
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            f.Title = "Seleccione el archivo de excel";
            f.FileName = string.Empty;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BrowseCelulas.Text = f.FileName.ToString();
                Files file = new Files(BrowseCelulas.Text);
                BrowseCelulas.Value = f.FileName.ToString();
                SetGrid(GridCelulas, file.GetDataTable());
            }
        }
    }
}
