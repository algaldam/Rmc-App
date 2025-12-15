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
    public partial class MesasPB : Telerik.WinControls.UI.RadForm
    {
        Boolean Refresh = false;
        SystemClass sc = new SystemClass();
        private string traceId;
        private string saca;
        private string millStyle;
        private string talla;
        private string color;
        private string dozens;
        private ActivarMesas activarMesasForm = null;
        private Asignaciones asignacionesForm = null;
        private List<int> selectedTables;
        private int hoveredRow = -1;
        private int hoveredCol = -1;
        private int cuadroSize = 120;
        private int separacion = 5;
        private int cuadrosPorFila = 4;
        private bool[,] cuadrosActivados;
        private PictureBox[] cuadros;
        private ToolTip toolTip;
        private List<string> traceIdsList = new List<string>();
        private Dictionary<int, List<string>> traceIdsPorMesa = new Dictionary<int, List<string>>();
        private Timer timer;
        private decimal totalDocenas = 0;

        public MesasPB(string traceId, string saca, string millStyle, string talla, string color, string dozens)
        {
            InitializeComponent();
            this.traceId = traceId;
            this.saca = saca;
            this.millStyle = millStyle;
            this.talla = talla;
            this.color = color;
            this.dozens = dozens;
            cuadrosActivados = new bool[cuadrosPorFila, cuadrosPorFila];
            selectedTables = new List<int>();
            cuadros = new PictureBox[cuadrosPorFila * cuadrosPorFila];
            InicializarCuadros();
            toolTip = new ToolTip();
            PB.Paint += new PaintEventHandler(pictureBox1_Paint);
            PB.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);

            CargarEstadoCuadros();
            // Configurar el temporizador
            timer = new Timer();
            timer.Interval = 10000; //Cada 5 minutos vamos a actualizar el picturebox
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start(); // Iniciar el temporizador
        }
        private void InicializarCuadros()
        {
            for (int i = 0; i < cuadros.Length; i++)
            {
                cuadros[i] = new PictureBox
                {
                    Width = cuadroSize,
                    Height = cuadroSize,
                    BorderStyle = BorderStyle.FixedSingle,
                     Tag = i + 1
                };
                this.Controls.Add(cuadros[i]);
                int row = i / cuadrosPorFila;
                int col = i % cuadrosPorFila;
                cuadros[i].Location = new Point(10 + col * (cuadroSize + separacion), 10 + row * (cuadroSize + separacion));
                cuadros[i].Click += Cuadro_Click;
            }
        }


        private void Cuadro_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            int mesaId = (int)clickedPictureBox.Tag;
            MessageBox.Show($"Número de mesa: {mesaId}");
        }
        public void AgregarTraceID(string traceId)
        {
            traceIdsList.Add(traceId);
            ActualizarCuadros();
        }
        public void ActualizarPictureBox()
        {
            PB.Invalidate();
        }
        public void CargarEstadoCuadros()
        {
            string query = "SELECT mesa, Enable FROM [dbo].[pmc_Mesas]";
            List<(int, bool)> mesaData = new List<(int, bool)>();
            int mesasActivas = 0; // Contador de mesas activas
            totalDocenas = 0;
            int totalIds = 0;


            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                using (  SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object mesaObject = reader["mesa"];
                        int mesaId;

                        if (mesaObject != DBNull.Value)
                        {
                            if (mesaObject is int)
                            {
                                mesaId = (int)mesaObject;
                            }
                            else if (mesaObject is string)
                            {
                                int.TryParse((string)mesaObject, out mesaId);
                            }
                            else
                            {
                                throw new Exception("Invalid data type for 'mesa' column");
                            }
                        }
                        else
                        {
                            mesaId = 0; 
                        }
                        bool enable = reader.GetBoolean(reader.GetOrdinal("Enable"));
                        mesaData.Add((mesaId, enable));
                    }
                }
            }
            HashSet<string> procesadosTraceIds = new HashSet<string>();
            HashSet<string> procesadosSacaIds = new HashSet<string>();
            foreach (var (mesaId, enable) in mesaData)
            {
                int row = (mesaId - 1) / cuadrosPorFila;
                int col = (mesaId - 1) % cuadrosPorFila;
                cuadrosActivados[row, col] = enable;
                if (enable)
                {
                    mesasActivas++;
                    List<string> traceIds = ObtenerTraceIDsParaMesa(mesaId);
                    List<string> sacaIds = ObtenerSacaIDsParaMesa(mesaId);

                    List<string> combinedIds = new List<string>(traceIds);
                    combinedIds.AddRange(sacaIds);

                    traceIdsPorMesa[mesaId] = combinedIds;

                    // Sumar docenas
                    foreach (string traceId in traceIds)
                    {
                        decimal docenas = ObtenerDocenasParaTraceID(traceId);
                        totalDocenas += docenas;
                    }

                    foreach (string sacaId in sacaIds)
                    {
                        decimal docenas = ObtenerDocenasParaSacaID(sacaId);
                        totalDocenas += docenas;
                    }

                    traceIdsList.AddRange(traceIds);
                    totalIds += traceIds.Count + sacaIds.Count;
                }
            }
            lblMesasActivas.Text = mesasActivas.ToString();
            lblTransacciones.Text = totalDocenas.ToString("F2");
            Transacciones.Text = totalIds.ToString();
            ActualizarCuadros();
        }

        private decimal ObtenerDocenasParaTraceID(string traceId)
        {
            decimal docenas = 0;
            string query = "SELECT Docenas FROM [dbo].[pmc_InventarioByTraceID] WHERE ID = @traceId";

            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                cmd.Parameters.AddWithValue("@traceId", traceId);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != string.Empty)
                {
                    docenas = Convert.ToDecimal(result);
                }
            }
            return docenas;
        }

        private decimal ObtenerDocenasParaSacaID(string sacaId)
        {
            decimal docenas = 0;
            string query = "SELECT Docenas FROM [dbo].[pmc_InventarioBySaca] WHERE ID = @sacaId";

            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                cmd.Parameters.AddWithValue("@sacaId", sacaId);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    docenas = Convert.ToDecimal(result);
                }
            }
            return docenas;
        }

        private List<string> ObtenerTraceIDsParaMesa(int mesaId)
        {
            List<string> traceIds = new List<string>();
            try
            {
                string query =
                    @"SELECT ID FROM [dbo].[pmc_InventarioByTraceID] WHERE MesaID = @mesaId AND DESVIACION=''";

                //Considerar usar esta consulta en algun momento debido al status asignado

                //@"SELECT DISTINCT IBTID.ID FROM [dbo].[pmc_InventarioByTraceID] as IBTID 
                //            RIGHT JOIN [Tracer].[dbo].[pmc_Inventario] AS INV ON INV.TraceID = IBTID.ID
                //            where MesaID = @mesaId AND INV.Status='TBL'";
                using (SqlCommand command = new SqlCommand(query, sc.OpenConectionTracer()))
                {
                    command.Parameters.AddWithValue("@mesaId", mesaId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string traceId = reader.GetString(reader.GetOrdinal("ID"));
                            traceIds.Add(traceId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los TraceID para la mesa {mesaId}: {ex.Message}");
            }

            return traceIds;
        }

        private List<string> ObtenerSacaIDsParaMesa(int mesaId)
        {
            List<string> sacaIds = new List<string>();
            try
            {
                string query = @"SELECT id FROM [dbo].[pmc_InventarioBySaca] WHERE MesaID = @mesaId AND DT_Processed IS NULL";
                using (SqlCommand command = new SqlCommand(query, sc.OpenConectionTracer()))
                {
                    command.Parameters.AddWithValue("@mesaId", mesaId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int sacaId = reader.GetInt32(reader.GetOrdinal("ID"));
                            sacaIds.Add(sacaId.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los SACA para la mesa {mesaId}: {ex.Message}");
            }

            return sacaIds;
        }

        public void ActualizarCuadros()
        {
            if (cuadros != null && cuadros.Length > 0)
            {
                for (int i = 0; i < cuadros.Length; i++)
                {
                    int row = i / cuadrosPorFila;
                    int col = i % cuadrosPorFila;

                    if (cuadrosActivados[row, col])
                    {
                        int mesaId = row * cuadrosPorFila + col + 1;
                        if (traceIdsPorMesa.ContainsKey(mesaId))
                        {
                            List<string> traceIds = traceIdsPorMesa[mesaId];
                            if (traceIds != null && traceIds.Count > 0)
                            {
                                cuadros[i].Image = GenerarImagenConTraceIDs(traceIds);
                            }
                        }
                    }
                    else
                    {
                        cuadros[i].Image = null;
                    }
                    cuadros[i].Refresh();
                }
            }
        }

        private Image GenerarImagenConTraceIDs(List<string> ids)
        {
            int imageWidth = cuadroSize - 20;
            int imageHeight = ids.Count * 20 + 10;  
            Bitmap bmp = new Bitmap(imageWidth, imageHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                int yPosition = 10;

                foreach (string id in ids)
                {
                    g.DrawString(traceId, new Font("Arial", 10), Brushes.Black, new PointF(10, yPosition));
                    yPosition += 15;
                }
            }
            return bmp;
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            RadButton clickedButton = sender as RadButton;
            int tableId = (int)clickedButton.Tag;

            if (selectedTables.Contains(tableId))
            {
                selectedTables.Remove(tableId);
                clickedButton.BackColor = SystemColors.Control;
            }
            else
            {
                selectedTables.Add(tableId);
                clickedButton.BackColor = Color.LightGreen;
            }

            UpdateGridView();
        }
        private void UpdateGridView()
        {
            rgUltimasAsignaciones.Rows.Clear();
            foreach (int tableId in selectedTables)
            {
                string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                rgUltimasAsignaciones.Rows.Add(tableId, currentDateTime);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int cuadroSize = 140;
            int separacion = 5;
            int cuadrosPorFila = 4;
            int cuadroPequenoSize = 20;
            Graphics g = e.Graphics;
            int totalCuadrosSize = (cuadroSize + separacion) * cuadrosPorFila - separacion;
            int offsetX = (PB.Width - totalCuadrosSize) / 2;
            int offsetY = (PB.Height - totalCuadrosSize) / 2;
            Pen pen = new Pen(Color.LightBlue);
            Pen penPequeno = new Pen(Color.White);
            Font font = new Font("Century gothic", 10);
            Brush brush = new SolidBrush(Color.White);
            Brush highlightBrush = new SolidBrush(Color.FromArgb(128, Color.LightGray));
            Pen cuadroActivoBrush = new Pen(Color.DarkBlue, 4);
            Brush inactiveBrush = new SolidBrush(Color.Gray);
            int numero = 1;

            for (int row = 0; row < cuadrosPorFila; row++)
            {
                for (int col = 0; col < cuadrosPorFila; col++)
                {
                    int x = offsetX + col * (cuadroSize + separacion);
                    int y = offsetY + row * (cuadroSize + separacion);
                    SizeF textSize;
                    if (cuadrosActivados[row, col])
                    {
                        g.DrawRectangle(cuadroActivoBrush, x, y, cuadroSize, cuadroSize);
                        int mesaId = row * cuadrosPorFila + col + 1;
                        if (traceIdsPorMesa.ContainsKey(mesaId))
                        {
                            List<string> traceIds = traceIdsPorMesa[mesaId];
                            if (traceIds.Count > 0)
                            {

                                // Si hay más de tres traceIds, mostrar los primeros tres y puntos suspensivos
                                int maxIdsToShow = 3;
                                float totalTextHeight = Math.Min(traceIds.Count, maxIdsToShow) * font.Height + (Math.Min(traceIds.Count, maxIdsToShow) - 1) * 5;
                                float startY = y + (cuadroSize - totalTextHeight) / 2;
                                 for (int i = 0; i < traceIds.Count && i < maxIdsToShow; i++)
                        {
                            SizeF traceIdSize = g.MeasureString(traceIds[i], font);
                            float traceIdX = x + (cuadroSize - traceIdSize.Width) / 2;

                            // Colorear de amarillo el primer ID
                            if (i == 0)
                            {
                                g.DrawString(traceIds[i], font, Brushes.Yellow, new PointF(traceIdX, startY));
                            }
                            else
                            {
                                g.DrawString(traceIds[i], font, Brushes.White, new PointF(traceIdX, startY));
                            }

                            startY += font.Height + 5;
                        }
                                if (traceIds.Count > maxIdsToShow)
                                {
                                    string dotsText = "+";
                                    SizeF dotsSize = g.MeasureString(dotsText, font);
                                    float dotsX = x + cuadroSize - dotsSize.Width - 5; // Ajustar a la derecha
                                    float dotsY = y + cuadroSize - dotsSize.Height - 5; // Ajustar hacia abajo
                                    g.DrawString(dotsText, font, Brushes.Yellow, new PointF(dotsX, dotsY));
                                }
                            }
                            else
                            {
                                float startY = y + (cuadroSize - 45) / 2;
                                for (int i = 0; i < 3; i++)
                                {
                                    SizeF placeholderSize = g.MeasureString("-------", font);
                                    float placeholderX = x + (cuadroSize - placeholderSize.Width) / 2;
                                    g.DrawString("-------", font, Brushes.White, new PointF(placeholderX, startY));
                                    startY += font.Height + 5;
                                }
                            }
                        }
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
                    textSize = g.MeasureString(numero.ToString(), font);
                    float textoX = pequenoX + (cuadroPequenoSize - textSize.Width) / 2;
                    float textoY = pequenoY + (cuadroPequenoSize - textSize.Height) / 2;
                    g.DrawString(numero.ToString(), font, brush, textoX, textoY);
                    numero++;
                }
            }
        }
        private string GenerarToolTipText()
        {
            string toolTipText = "";
            int row = hoveredRow;
            int col = hoveredCol;
            int mesaId = row * cuadrosPorFila + col + 1;

            if (traceIdsPorMesa.ContainsKey(mesaId))
            {
                List<string> ids = traceIdsPorMesa[mesaId];

                toolTipText += string.Format("{0,-6} {1,-20} {2,-10} {3,-8} {4,-10} {5,-12} {6,-6}\n",
                                    "SACA", "MillStyle", "Docenas", "WeekID", "Desv.", "DesvMat", "ID");

                foreach (string id in ids)
                {
                    string query = "SELECT [SACA], CONCAT([MillStyle], [Talla], [Color]) AS [MillStyle], [Docenas], [WeekID], [Desviacion], [DesvMaterial], [ID] " +
                                   "FROM [pmc_InventarioByTraceID] WHERE [ID] = @id " +
                                   "UNION " +
                                   "SELECT [SACA], CONCAT([MillStyle], [Talla], [Color]) AS [MillStyle], [Docenas],  [WeekID], [Desviacion], [DesvMaterial], [ID] " +
                                   "FROM [pmc_InventarioBySaca] WHERE [ID] = @id";

                    using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                toolTipText += string.Format("{0,-6} {1,-20} {2,-10} {3,-8} {4,-10} {5,-12} {6,-6}\n",
                                                             reader["SACA"].ToString(),
                                                             reader["MillStyle"].ToString(),
                                                             reader["Docenas"].ToString(),
                                                             reader["WeekID"].ToString(),
                                                             reader["Desviacion"].ToString(),
                                                             reader["DesvMaterial"].ToString(),
                                                             reader["ID"].ToString());
                            }
                        }
                    }
                }
            }
            return toolTipText;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int cuadroSize = 140;
            int separacion = 5;
            int cuadrosPorFila = 4;
            int totalCuadrosSize = (cuadroSize + separacion) * cuadrosPorFila - separacion;
            int offsetX = (PB.Width - totalCuadrosSize) / 2;
            int offsetY = (PB.Height - totalCuadrosSize) / 2;

            int mouseX = e.X - offsetX;
            int mouseY = e.Y - offsetY;
            int col = mouseX / (cuadroSize + separacion);
            int row = mouseY / (cuadroSize + separacion);

            if (mouseX >= 0 && mouseX < totalCuadrosSize && mouseY >= 0 && mouseY < totalCuadrosSize)
            {
                if (row >= 0 && row < cuadrosPorFila && col >= 0 && col < cuadrosPorFila)
                {
                    if (row != hoveredRow || col != hoveredCol)
                    {
                        hoveredRow = row;
                        hoveredCol = col;
                        PB.Invalidate();
                    }
                    if (cuadrosActivados[row, col])
                    {
                        string toolTipText = GenerarToolTipText();
                        toolTip.Show(toolTipText, PB, e.Location, 6000);
                    }
                    else
                    {
                        toolTip.Hide(PB);
                    }
                }
            }
            else
            {
                if (hoveredRow != -1 || hoveredCol != -1)
                {
                    hoveredRow = -1;
                    hoveredCol = -1;
                    PB.Invalidate();
                }
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int totalCuadrosSize = (cuadroSize + separacion) * cuadrosPorFila - separacion;
            int offsetX = (PB.Width - totalCuadrosSize) / 2;
            int offsetY = (PB.Height - totalCuadrosSize) / 2;

            int mouseX = e.X - offsetX;
            int mouseY = e.Y - offsetY;
            int col = mouseX / (cuadroSize + separacion);
            int row = mouseY / (cuadroSize + separacion);

            if (mouseX >= 0 && mouseX < totalCuadrosSize && mouseY >= 0 && mouseY < totalCuadrosSize)
            {
                if (row >= 0 && row < cuadrosPorFila && col >= 0 && col < cuadrosPorFila)
                {
                    int numero = row * cuadrosPorFila + col + 1;
                    if (asignacionesForm == null || asignacionesForm.IsDisposed)
                    {
                        asignacionesForm = new Asignaciones();
                        asignacionesForm.FormClosed += ActivarMesasForm_FormClosed;
                        asignacionesForm.Show();
                    }
                    else
                    {
                        asignacionesForm.Focus();
                    }
                    asignacionesForm.SetMesaText(numero.ToString());
                }
            }
        }

        private void Mesas_Load(object sender, EventArgs e)
        {
            sc.OpenConection();
            string query = @"
                  SELECT ID, MesaID
                  FROM [dbo].[pmc_InventarioByTraceID]
                  WHERE ID IN (SELECT TraceID FROM pmc_Inventario WHERE Status = 'TBL')
                  UNION
                  SELECT ID, MesaID
                  FROM [dbo].[pmc_InventarioBysaca] 
                  LEFT JOIN pmc_Inventario AS INV 
                  ON INV.TraceID = ID
                  WHERE DT_Processed IS NULL
                  AND ID NOT IN (
                      SELECT TRACEID
                      FROM CheckPointTrans 
                      WHERE ChkID = 'FIN-PREKIT' 
                      AND DateOUT IS NOT NULL 
                      AND DT >= DATEADD(MONTH, -3, GETDATE())
                  )
                  AND INV.Status = 'TBL'
                  ORDER BY MesaID;";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.TracerConnectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    rgUltimasAsignaciones.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }

    private static MesasPB instancia;
    public static MesasPB ObtenerInstancia(string traceId, string saca, string millStyle, string talla, string color, string dozens)
        {
        if (instancia == null || instancia.IsDisposed)
        {
            instancia = new MesasPB(traceId, saca, millStyle, talla, color, dozens);
            }
        return instancia;
    }
        private void button1_Click(object sender, EventArgs e)
        {
            if (activarMesasForm == null || activarMesasForm.IsDisposed)
            {
                activarMesasForm = new ActivarMesas();
                activarMesasForm.FormClosed += ActivarMesasForm_FormClosed;
                activarMesasForm.Show();
            }
            else
            {
                activarMesasForm.Focus();
            }
        }
        private void ActivarMesasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            activarMesasForm = null; 
        }

        private void PB_Click(object sender, EventArgs e)
        {

        }

        private void brtRefresh_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Refresh = true;
            CargarEstadoCuadros();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        string searchText = null;
        string searchType = null;

            // Verificar qué checkbox está seleccionado y asignar el tipo y valor de búsqueda correspondientes
            if (cbTID.Checked)
            {
                searchText = txtTraceID.Text;
                searchType = "TraceID";
            }
            else if (cbSaca.Checked)
            {
                searchText = txtSaca.Text;
                searchType = "Saca";
            }
            else if (cbMS.Checked)
            {
                searchText = txtMillstyle.Text;
                searchType = "MillStyle";
            }
            else
            {
                MessageBox.Show("No hay elementos seleccionados.");
                return;
            }

            // Verificar que el campo de texto no esté vacío
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show($"El campo {searchType} está vacío.");
                return;
            }

            // Buscar el texto en los cuadros
            bool found = false;
            for (int i = 0; i < cuadros.Length; i++)
            {
                int mesaId = (int)cuadros[i].Tag;
                if (traceIdsPorMesa.ContainsKey(mesaId))
                {
                    List<string> ids = traceIdsPorMesa[mesaId];
                    foreach (string id in ids)
                    {

                        if (BuscarEnBaseDeDatos(id, searchText, searchType))
                        {
                            ResaltarCuadro(i);  
                            found = true;
                            MessageBox.Show($"{searchType} '{searchText}' encontrado en la mesa {mesaId}.");
                            break; // Salir del bucle si se encuentra
                        }
                    }
                }
                if (found) break; // Salir del bucle si se encontró
            }
            if (!found)
            {
                MessageBox.Show($"{searchType} '{searchText}' no se encontró en ninguna mesa.");
            }
        }

        // Método para buscar en la base de datos basado en el tipo de búsqueda
        private bool BuscarEnBaseDeDatos(string id, string searchText, string searchType)
        {
            bool encontrado = false;
            string query = "";

            // Definir la consulta según el tipo de búsqueda
            if (searchType == "TraceID")
            {
                query = "SELECT COUNT(*) FROM [dbo].[pmc_InventarioByTraceID] WHERE ID = @id AND ID = @searchText";
            }
            else if (searchType == "Saca")
            {
                query = "SELECT COUNT(*) FROM [dbo].[pmc_InventarioBySaca] WHERE ID = @id AND SACA = @searchText";
            }
            else if (searchType == "MillStyle")
            {
                query = "SELECT COUNT(*) FROM [dbo].[pmc_InventarioByTraceID] WHERE ID = @id AND MillStyle = @searchText";
            }

            // Ejecutar la consulta
            using (SqlCommand cmd = new SqlCommand(query, sc.OpenConectionTracer()))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@searchText", searchText);

                int count = (int)cmd.ExecuteScalar();
                encontrado = count > 0;
            }

            return encontrado;
        }

        
        private void ResaltarCuadro(int index)
        {

            // Cambiar el color del cuadro a amarillo temporalmente
            cuadros[index].BackColor = Color.FromArgb(100, Color.Gray);
            cuadros[index].Refresh(); // Forzar la actualización del control

            // Crear un temporizador para restaurar el color original después de un tiempo
            Timer timer = new Timer();
            timer.Interval = 12000; // 2 segundos
            timer.Tick += (s, e) =>
            {
                cuadros[index].BackColor = SystemColors.Control; // Restaurar el color de fondo
                cuadros[index].Refresh(); // Actualizar el control
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
        private void cbTID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTID.Checked)
            {
                cbMS.Checked = false;
                cbSaca.Checked = false;
            }
            else
            {
                cbTID.Checked = false;
            }
        }

        private void cbSaca_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSaca.Checked)
            {
                cbMS.Checked = false;
                cbTID.Checked = false;
            }
            else
            {
                cbSaca.Checked = false;
            }
        }

        private void cbMS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMS.Checked)
            {
                cbSaca.Checked = false;
                cbTID.Checked = false;
            }
            else
            {
                cbMS.Checked = false;
            }
        }
    }
}
