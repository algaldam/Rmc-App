using Rmc.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Rmc.MaterialEmpaque
{
    public partial class Asignaciones : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        dsPMC ds = new dsPMC();
        private string selectedTraceID;
        private string selectedMesa;
        private List<RadTextBox> traceTextBoxes = new List<RadTextBox>();
        private string mesaText;
        private List<bool> esSacaIDs = new List<bool>(); // Lista para almacenar si el ID es de Saca o Trace

        public Asignaciones()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarRadGridView();
            ConfigurarRadTextBoxes();
        }

        public void SetMesaText(string mesaText)
        {
            txtMesa.Text = mesaText;
            LlenarIDsDesdeTxtMesa();
        }

        private void Asignaciones_Load(object sender, EventArgs e)
        {
            LlenarRadGridView();
            ConfigurarRadTextBoxes();
        }

        private void ConfigurarRadTextBoxes()
        {
            var textBoxes = new RadTextBox[]
            {
                txtDeck1, txtDeck2, txtDeck3, txtDeck4, txtDeck5,
                txtDeck6, txtDeck7, txtDeck8, txtDeck9, txtDeck10,
                txtDeck11, txtDeck12, txtDeck13, txtDeck14, txtDeck15,
                txtDeck16, txtDeck17, txtDeck18, txtDeck19, txtDeck20
            };

            foreach (var textBox in textBoxes)
            {
                textBox.ReadOnly = true;
                textBox.Click += RadTextBox_Click;
                traceTextBoxes.Add(textBox); // Agregar TextBox a la lista
            }
        }

        private void RadTextBox_Click(object sender, EventArgs e)
        {
            RadTextBox textBox = sender as RadTextBox;
            if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
            {
                selectedTraceID = textBox.Text;
            }
        }

        private void LlenarIDsDesdeTxtMesa()
        {
            if (int.TryParse(txtMesa.Text, out int mesaId))
            {
                List<string> ids = ObtenerIDsPorMesa(mesaId);
                esSacaIDs = new List<bool>(); // Resetear lista de esSaca

                foreach (var id in ids)
                {
                    bool esSaca = EsSacaID(id); // Determinar si el ID es SacaID
                    esSacaIDs.Add(esSaca);
                }

                LlenarIDs(ids);
            }
            else
            {
                MessageBox.Show("El valor de txtMesa no es válido.");
            }
        }

        private void LlenarIDs(List<string> ids)
        {
            RadTextBox[] textBoxes = new RadTextBox[]
            {
                txtDeck1, txtDeck2, txtDeck3, txtDeck4, txtDeck5,
                txtDeck6, txtDeck7, txtDeck8, txtDeck9, txtDeck10,
                txtDeck11, txtDeck12, txtDeck13, txtDeck14, txtDeck15,
                txtDeck16, txtDeck17, txtDeck18, txtDeck19, txtDeck20
            };

            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (i < ids.Count)
                {
                    textBoxes[i].Text = ids[i];
                }
                else
                {
                    textBoxes[i].Text = string.Empty;
                }
            }
        }

        private List<string> ObtenerIDsPorMesa(int mesaId)
        {
            List<string> ids = new List<string>();

            // Consulta para obtener TraceIDs
            string queryTrace = "SELECT ID FROM [dbo].[pmc_InventarioByTraceID] WHERE MesaID = @mesaId";
            // Consulta para obtener SacaIDs
            string querySaca = "SELECT ID FROM [dbo].[pmc_InventarioBySaca] WHERE MesaID = @mesaId";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                try
                {
                    connection.Open();

                    // Obtener TraceIDs
                    SqlCommand commandTrace = new SqlCommand(queryTrace, connection);
                    commandTrace.Parameters.AddWithValue("@mesaId", mesaId);
                    SqlDataReader readerTrace = commandTrace.ExecuteReader();
                    while (readerTrace.Read())
                    {
                        ids.Add(readerTrace["ID"].ToString());
                    }
                    readerTrace.Close();

                    // Obtener SacaIDs
                    SqlCommand commandSaca = new SqlCommand(querySaca, connection);
                    commandSaca.Parameters.AddWithValue("@mesaId", mesaId);
                    SqlDataReader readerSaca = commandSaca.ExecuteReader();
                    while (readerSaca.Read())
                    {
                        ids.Add(readerSaca["ID"].ToString());
                    }
                    readerSaca.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al obtener IDs: " + ex.Message);
                }
            }

            return ids;
        }

        private bool EsSacaID(string id)
        {
            bool esSaca = false;
            string query = "SELECT COUNT(*) FROM [dbo].[pmc_InventarioBySaca] WHERE ID = @id";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    esSaca = (count > 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al determinar el tipo de ID: " + ex.Message);
                }
            }
            return esSaca;
        }

        private void LlenarRadGridView()
        {
            sc.OpenConection();
            string query = "SELECT MESA FROM pmc_Mesas WHERE ENABLE = 1";
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    rgvMesas.DataSource = dataTable;
                    rgvMesas.SelectionChanged += RgvMesas_SelectionChanged;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }

        private void RgvMesas_SelectionChanged(object sender, EventArgs e)
        {
            if (rgvMesas.SelectedRows.Count > 0)
            {
                var selectedRow = rgvMesas.SelectedRows[0];
                selectedMesa = selectedRow.Cells["MESA"].Value.ToString();
            }
        }

        private void btnDeckCurrent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTraceID) || string.IsNullOrEmpty(selectedMesa))
            {
                MessageBox.Show("Por favor seleccione un ID y una Mesa.");
                return;
            }

            // Buscar el índice del TextBox seleccionado y determinar si es un SacaID o TraceID
            int index = traceTextBoxes.IndexOf(traceTextBoxes.Find(tb => tb.Text == selectedTraceID));
            bool esSaca = esSacaIDs[index]; // Usar la lista para obtener el valor correspondiente

            DialogResult result = MessageBox.Show("¿Estás de acuerdo en cambiar la asignación?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ActualizarAsignacionMesa(selectedMesa, selectedTraceID, esSaca);
            }
        }

        private void ActualizarAsignacionMesa(string mesaNumber, string id, bool esSaca)
        {
            string query = esSaca ?
                "UPDATE [dbo].[pmc_InventarioBySaca] SET MesaID = @mesaId WHERE ID = @id" :
                "UPDATE [dbo].[pmc_InventarioByTraceID] SET MesaID = @mesaId WHERE ID = @id";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@mesaId", mesaNumber);
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"El ID {id} fue asignado a la mesa {mesaNumber}");

                    // Actualizar los IDs en la interfaz después de la modificación
                    LlenarIDsDesdeTxtMesa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }
    }
}
