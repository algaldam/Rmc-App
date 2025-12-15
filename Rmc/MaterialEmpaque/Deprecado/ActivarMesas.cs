using Rmc.Clases;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace Rmc.MaterialEmpaque
{

    public partial class ActivarMesas : Telerik.WinControls.UI.RadForm
    {
        SystemClass sc = new SystemClass();
        private int hoveredRow = -1;
        private int hoveredCol = -1;
        private int cuadroSize = 130;
        private int separacion = 5;
        private int cuadrosPorFila = 4;
        private int cuadroPequenoSize = 20;
        private int numeroSeleccionado = 0;
        private Label numeroLabel;
        private bool[,] cuadrosActivados;
        private int selectedRow = -1;
        private int selectedCol = -1;

        public ActivarMesas()
        {
            InitializeComponent();
            cuadrosActivados = new bool[cuadrosPorFila, cuadrosPorFila];
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
            chkEstados.CheckedChanged += new EventHandler(chkEstados_CheckedChanged);
            numeroLabel = new Label();
            numeroLabel.Location = new Point(10, 10);
            numeroLabel.AutoSize = true;
            this.Controls.Add(numeroLabel);
            CargarEstadoCuadros();
            chkEstados.Checked = false;
            chkEstados.Enabled = false;
        }

        private void CargarEstadoCuadros()
        {
            sc.OpenConection();
            string query = "SELECT mesa, Enable FROM [pmc_Mesas]";
            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object mesaObj = reader["mesa"];
                        int mesa;
                        if (mesaObj is int)
                        {
                            mesa = (int)mesaObj;
                        }
                        else if (mesaObj is short)
                        {
                            mesa = (short)mesaObj;
                        }
                        else if (mesaObj is long)
                        {
                            mesa = (int)(long)mesaObj;
                        }
                        else if (mesaObj is string)
                        {
                            if (!int.TryParse((string)mesaObj, out mesa))
                            {
                                throw new InvalidCastException("No se pudo convertir el valor de la columna 'mesa' a int");
                            }
                        }
                        else
                        {
                            throw new InvalidCastException("Tipo de datos inesperado para la columna 'mesa'");
                        }
                        bool enable = reader.GetBoolean(1);
                        int row = (mesa - 1) / cuadrosPorFila;
                        int col = (mesa - 1) % cuadrosPorFila;
                        cuadrosActivados[row, col] = enable;
                    }
                }
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int cuadroSize = 120;
            int separacion = 5;
            int cuadrosPorFila = 4;
            int cuadroPequenoSize = 20;
            Graphics g = e.Graphics;
            int totalCuadrosSize = (cuadroSize + separacion) * cuadrosPorFila - separacion;
            int offsetX = (pictureBox1.Width - totalCuadrosSize) / 2;
            int offsetY = (pictureBox1.Height - totalCuadrosSize) / 2;
            Pen pen = new Pen(Color.LightBlue);
            Pen penPequeno = new Pen(Color.White);
            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(Color.White);
            Brush highlightBrush = new SolidBrush(Color.FromArgb(128, Color.LightGray));
            Brush activeBrush = new SolidBrush(Color.LightGreen);
            Brush inactiveBrush = new SolidBrush(Color.Gray);
            Pen cuadroActivoBrush = new Pen(Color.DarkBlue, 5);
            int numero = 1;
            for (int row = 0; row < cuadrosPorFila; row++)
            {
                for (int col = 0; col < cuadrosPorFila; col++)
                {
                    int x = offsetX + col * (cuadroSize + separacion);
                    int y = offsetY + row * (cuadroSize + separacion);
                    if (cuadrosActivados[row, col])
                    {
                        g.DrawRectangle(cuadroActivoBrush, x, y, cuadroSize, cuadroSize);
                    }
                    else if (row == hoveredRow && col == hoveredCol)
                    {
                        g.FillRectangle(highlightBrush, x, y, cuadroSize, cuadroSize);
                    }
                    else if (row == hoveredRow && col == hoveredCol)
                    {
                        g.FillRectangle(highlightBrush, x, y, cuadroSize, cuadroSize);
                    }
                    else
                    {
                        g.FillRectangle(inactiveBrush, x, y, cuadroSize, cuadroSize);
                    }
                    g.DrawRectangle(pen, x, y, cuadroSize, cuadroSize);
                    int pequenoX = x + 5; 
                    int pequenoY = y + 5; 
                    g.DrawRectangle(penPequeno, pequenoX, pequenoY, cuadroPequenoSize, cuadroPequenoSize);
                    SizeF textSize = g.MeasureString(numero.ToString(), font);
                    float textoX = pequenoX + (cuadroPequenoSize - textSize.Width) / 2;
                    float textoY = pequenoY + (cuadroPequenoSize - textSize.Height) / 2;
                    g.DrawString(numero.ToString(), font, brush, textoX, textoY);
                    numero++;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            int totalCuadrosSize = (cuadroSize + separacion) * cuadrosPorFila - separacion;
            int offsetX = (pictureBox1.Width - totalCuadrosSize) / 2;
            int offsetY = (pictureBox1.Height - totalCuadrosSize) / 2;
            if (x >= offsetX && y >= offsetY && x < offsetX + totalCuadrosSize && y < offsetY + totalCuadrosSize)
            {
                int col = (x - offsetX) / (cuadroSize + separacion);
                int row = (y - offsetY) / (cuadroSize + separacion);
                int cuadroX = offsetX + col * (cuadroSize + separacion);
                int cuadroY = offsetY + row * (cuadroSize + separacion);
                if (x >= cuadroX && y >= cuadroY && x < cuadroX + cuadroSize && y < cuadroY + cuadroSize)
                {
                    hoveredRow = row;
                    hoveredCol = col;
                    pictureBox1.Invalidate();
                    return;
                }
            }
            hoveredRow = -1;
            hoveredCol = -1;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            int totalCuadrosSize = (cuadroSize + separacion) * cuadrosPorFila - separacion;
            int offsetX = (pictureBox1.Width - totalCuadrosSize) / 2;
            int offsetY = (pictureBox1.Height - totalCuadrosSize) / 2;
            int col = (mouseX - offsetX) / (cuadroSize + separacion);
            int row = (mouseY - offsetY) / (cuadroSize + separacion);
            if (col >= 0 && col < cuadrosPorFila && row >= 0 && row < cuadrosPorFila)
            {
                selectedRow = row;
                selectedCol = col;        
                int numero = row * cuadrosPorFila + col + 1;
                lblMesa.Text = numero.ToString();
                chkEstados.CheckedChanged -= chkEstados_CheckedChanged;
                chkEstados.Checked = cuadrosActivados[row, col];
                chkEstados.Enabled = true;
                chkEstados.CheckedChanged += chkEstados_CheckedChanged;
                pictureBox1.Invalidate();
            }
            else
            {
                chkEstados.CheckedChanged -= chkEstados_CheckedChanged;
                chkEstados.Checked = false;
                chkEstados.Enabled = false;
                chkEstados.CheckedChanged += chkEstados_CheckedChanged;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblMesa.Text, out int numeroMesa))
            {
                MessageBox.Show("No se ha seleccionado ninguna mesa.");
                return;
            }
            bool estado = chkEstados.Checked;
            sc.OpenConection();
            string query = "UPDATE [pmc_Mesas] SET Enable = @Enable WHERE mesa = @Mesa";
            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {               
                cmd.Parameters.AddWithValue("@Enable", estado);
                cmd.Parameters.AddWithValue("@Mesa", numeroMesa);
        try
        {
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                if (estado)
                {
                    MessageBox.Show("Mesa activa");
                }
                else
                {
                    MessageBox.Show("Mesa inactiva");
                }
            }
            else
            {
                MessageBox.Show("No se encontró la mesa especificada.");
            }
        }
        catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void chkEstado_CheckStateChanged(object sender, EventArgs e)
        {
            if (selectedRow != -1 && selectedCol != -1)
            {
                cuadrosActivados[selectedRow, selectedCol] = chkEstados.Checked;
                pictureBox1.Invalidate();
            }
        }

        private void chkEstados_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedRow != -1 && selectedCol != -1)
            {
                cuadrosActivados[selectedRow, selectedCol] = chkEstados.Checked;
                pictureBox1.Invalidate();
            }
        }
    }
}
