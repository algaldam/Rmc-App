using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Rmc.MaterialEmpaque.Inventario
{
    public partial class VistaPreparacionForm : Telerik.WinControls.UI.RadForm
    {
        private string connectionString = Properties.Settings.Default.ES_SOCKSConnectionString;

        public VistaPreparacionForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            refreshTimer.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (progressBar.Visible) return;

            try
            {
                this.Invoke(new Action(() =>
                {
                    progressBar.Visible = true;
                    progressBar.Value = 30;
                }));

                string query = @"WITH UltimoEstado AS (
                                    SELECT 
                                        st.TransactionID,
                                        st.StatusID,
                                        st.StartDate,
                                        st.EndDate,
                                        st.Badge,
                                        s.statusName,
                                        s.statusOrder,
                                        ROW_NUMBER() OVER (PARTITION BY st.TransactionID ORDER BY st.StartDate DESC) AS rn
                                    FROM ES_SOCKS.dbo.pmc_StatusTracking st
                                    INNER JOIN ES_SOCKS.dbo.pmc_Status s ON st.StatusID = s.statusId
                                ),
                                EstadoAnterior AS (
                                    SELECT 
                                        st.TransactionID,
                                        st.Badge AS OperadorImpresion,
                                        s.statusName AS EstadoAnteriorNombre,
                                        ROW_NUMBER() OVER (PARTITION BY st.TransactionID ORDER BY st.StartDate DESC) AS rn
                                    FROM ES_SOCKS.dbo.pmc_StatusTracking st
                                    INNER JOIN ES_SOCKS.dbo.pmc_Status s ON st.StatusID = s.statusId
                                    WHERE s.statusOrder = 1
                                ),
                                OperadorPreparacion AS (
                                    SELECT 
                                        st.TransactionID,
                                        st.Badge AS OperadorPreparacion,
                                        st.StartDate AS FechaInicioPreparacion,
                                        ROW_NUMBER() OVER (PARTITION BY st.TransactionID ORDER BY st.StartDate DESC) AS rn
                                    FROM ES_SOCKS.dbo.pmc_StatusTracking st
                                    INNER JOIN ES_SOCKS.dbo.pmc_Status s ON st.StatusID = s.statusId
                                    WHERE s.statusOrder = 2
                                ),
                                PreparacionCompleta AS (
                                    SELECT 
                                        td.TransactionID,
                                        COUNT(*) AS TotalItems,
                                        COUNT(CASE WHEN td.ConfirmationDate IS NOT NULL THEN 1 END) AS ItemsConfirmados,
                                        COUNT(CASE WHEN td.ConfirmationDate IS NULL THEN 1 END) AS ItemsPendientes,
                                        CASE 
                                            WHEN COUNT(*) = COUNT(CASE WHEN td.ConfirmationDate IS NOT NULL THEN 1 END) 
                                            THEN 1 ELSE 0 
                                        END AS PreparacionCompleta
                                    FROM ES_SOCKS.dbo.pmc_TransactionDetails td
                                    GROUP BY td.TransactionID
                                ),
                                EmpleadosConNombre AS (
                                    SELECT 
                                        Emp_ID,
                                        LEFT(Emp_Nombres, CHARINDEX(' ', Emp_Nombres + ' ') - 1) + ' ' + 
                                        LEFT(Emp_Apellidos, CHARINDEX(' ', Emp_Apellidos + ' ') - 1) AS Nombre
                                    FROM mst_Empleados
                                )
                                SELECT 
                                    t.TraceID AS Transaccion,
                                    t.SACA,
                                    t.SACASeg,
                                    t.Dozens AS Docenas,
                                    t.TableNumber AS Mesa,
                                    ea.EstadoAnteriorNombre AS EstadoAnterior,
                                    ue.statusName AS EstadoActual,
                                    op.OperadorPreparacion AS CarnetOperador,
                                    CASE 
                                        WHEN op.OperadorPreparacion IS NULL OR op.OperadorPreparacion = '' THEN 'N/A'
                                        WHEN op.OperadorPreparacion NOT LIKE '%[^0-9]%' THEN ISNULL(emp.Nombre, 'N/A')
                                        ELSE 'N/A'
                                    END AS NombreOperador,
                                    ue.StartDate AS InicioPreparacion,
                                    pc.TotalItems,
                                    pc.ItemsConfirmados,
                                    pc.ItemsPendientes,
                                    CASE 
                                        WHEN pc.PreparacionCompleta = 1 THEN 'PREPARANDO MATERIAL'
                                        ELSE 'PENDIENTE PREPARACION'
                                    END AS SiguienteAccion,
                                    CASE 
                                        WHEN pc.PreparacionCompleta = 1 THEN 'COMPLETADO'
                                        ELSE 'NO COMPLETADO'
                                    END AS EstadoCompletado
                                FROM ES_SOCKS.dbo.pmc_Transactions t
                                INNER JOIN UltimoEstado ue 
                                    ON t.ID = ue.TransactionID AND ue.rn = 1
                                INNER JOIN PreparacionCompleta pc 
                                    ON t.ID = pc.TransactionID
                                LEFT JOIN EstadoAnterior ea 
                                    ON t.ID = ea.TransactionID AND ea.rn = 1
                                LEFT JOIN OperadorPreparacion op 
                                    ON t.ID = op.TransactionID AND op.rn = 1
                                LEFT JOIN EmpleadosConNombre emp 
                                    ON CASE 
                                           WHEN op.OperadorPreparacion IS NULL OR op.OperadorPreparacion = '' THEN NULL
                                           WHEN op.OperadorPreparacion NOT LIKE '%[^0-9]%' THEN op.OperadorPreparacion
                                           ELSE NULL
                                       END = emp.Emp_ID
                                WHERE ue.EndDate IS NULL 
                                  AND ue.statusOrder = 2
                                ORDER BY 
                                    pc.PreparacionCompleta DESC,
                                    pc.ItemsConfirmados DESC";

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                this.Invoke(new Action(() =>
                {
                    progressBar.Value = 80;

                    UpdateCards(dt);

                    // Actualizar KPIs
                    UpdateKPIs(dt);

                    progressBar.Value = 100;
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
            finally
            {
                this.Invoke(new Action(() =>
                {
                    progressBar.Visible = false;
                    progressBar.Value = 0;
                }));
            }
        }

        private void UpdateCards(DataTable data)
        {
            flowPanelCards.Controls.Clear();

            foreach (DataRow row in data.Rows)
            {
                Panel card = CreateTransactionCard(row);
                flowPanelCards.Controls.Add(card);
            }
        }

        private Panel CreateTransactionCard(DataRow row)
        {
            bool isCompletado = row["EstadoCompletado"].ToString() == "COMPLETADO";
            int confirmados = Convert.ToInt32(row["ItemsConfirmados"]);
            int totalItems = Convert.ToInt32(row["TotalItems"]);
            int pendientes = Convert.ToInt32(row["ItemsPendientes"]);

            Panel card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Size = new Size(280, 235);
            card.Margin = new Padding(10);
            card.Padding = new Padding(0);

            // Header de la card con color sutil
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.BackColor = isCompletado ? Color.FromArgb(220, 255, 220) : Color.FromArgb(255, 240, 220);
            headerPanel.Height = 35;
            headerPanel.Padding = new Padding(8, 5, 5, 5);

            Panel transaccionContainer = new Panel();
            transaccionContainer.Dock = DockStyle.Left;
            transaccionContainer.Width = 180;
            transaccionContainer.Height = 25;

            Label lblTransaccion = new Label();
            lblTransaccion.Dock = DockStyle.Fill;

            string transaccionTexto = row["Transaccion"].ToString();
            string textoMostrado = transaccionTexto.Length > 12 ?
                transaccionTexto.Substring(0, 10) + "..." :
                transaccionTexto;

            lblTransaccion.Text = $"📦 {textoMostrado}";
            lblTransaccion.ForeColor = Color.Black;
            lblTransaccion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTransaccion.TextAlign = ContentAlignment.MiddleLeft;

            transaccionContainer.Controls.Add(lblTransaccion);

            Label lblEstadoBadge = new Label();
            lblEstadoBadge.Dock = DockStyle.Right;
            lblEstadoBadge.Text = isCompletado ? "✅ PROCESO" : "⏳ PENDIENTE";
            lblEstadoBadge.ForeColor = isCompletado ? Color.DarkGreen : Color.DarkOrange;
            lblEstadoBadge.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblEstadoBadge.TextAlign = ContentAlignment.MiddleRight;
            lblEstadoBadge.AutoSize = true;
            lblEstadoBadge.Padding = new Padding(0, 0, 5, 0);

            headerPanel.Controls.Add(lblEstadoBadge);
            headerPanel.Controls.Add(transaccionContainer);

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(250, 250, 250);
            contentPanel.Padding = new Padding(10, 8, 10, 8);

            int yPos = 5;

            // Primera fila - información principal
            AddInfoLabelWithIcon(contentPanel, "🔢", $"SACA: {row["SACA"]}", Color.Black, ref yPos);
            AddInfoLabelWithIcon(contentPanel, "📊", $"Docenas: {row["Docenas"]}", Color.Black, ref yPos);
            AddInfoLabelWithIcon(contentPanel, "🪑", $"Mesa: {row["Mesa"]}", Color.Black, ref yPos);

            yPos += 5;

            // Segunda fila - información de operadores
            AddInfoLabelWithIcon(contentPanel, "👤", $"Operador: {GetShortName(row["NombreOperador"].ToString())}", Color.DarkGray, ref yPos);

            yPos += 5;

            // Tercera fila - información de items
            Panel itemsPanel = new Panel();
            itemsPanel.Location = new Point(5, yPos);
            itemsPanel.Size = new Size(280, 40);
            itemsPanel.BackColor = Color.Transparent;

            // Items confirmados
            Label lblConfirmados = new Label();
            lblConfirmados.Location = new Point(0, 0);
            lblConfirmados.Size = new Size(135, 18);
            lblConfirmados.Text = $"✅ Confirmados: {confirmados}";
            lblConfirmados.ForeColor = Color.DarkGreen;
            lblConfirmados.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblConfirmados.TextAlign = ContentAlignment.MiddleLeft;

            // Items pendientes
            Label lblPendientes = new Label();
            lblPendientes.Location = new Point(140, 0);
            lblPendientes.Size = new Size(135, 18);
            lblPendientes.Text = $"⏳ Pendientes: {pendientes}";
            lblPendientes.ForeColor = Color.OrangeRed;
            lblPendientes.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblPendientes.TextAlign = ContentAlignment.MiddleLeft;

            // Total items
            Label lblTotal = new Label();
            lblTotal.Location = new Point(0, 20);
            lblTotal.Size = new Size(280, 18);
            lblTotal.Text = $"📋 Total Items: {totalItems}";
            lblTotal.ForeColor = Color.DarkBlue;
            lblTotal.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;

            itemsPanel.Controls.Add(lblConfirmados);
            itemsPanel.Controls.Add(lblPendientes);
            itemsPanel.Controls.Add(lblTotal);
            contentPanel.Controls.Add(itemsPanel);

            yPos += 45;

            Label lblAccion = new Label();
            lblAccion.Location = new Point(5, yPos);
            lblAccion.Size = new Size(280, 20);
            lblAccion.Text = GetActionIcon(row["SiguienteAccion"].ToString()) + " " + row["SiguienteAccion"].ToString();
            lblAccion.ForeColor = isCompletado ? Color.DarkGreen : Color.DarkBlue;
            lblAccion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblAccion.TextAlign = ContentAlignment.MiddleCenter;
            contentPanel.Controls.Add(lblAccion);

            yPos += 25;

            // Fecha y estado actual
            if (row["InicioPreparacion"] != DBNull.Value)
            {
                DateTime fecha = Convert.ToDateTime(row["InicioPreparacion"]);
                AddInfoLabelWithIcon(contentPanel, "🕒", $"Inicio: {fecha:dd/MM/yyyy HH:mm}", Color.Gray, ref yPos);
            }

            AddInfoLabelWithIcon(contentPanel, "📝", $"Estado: {row["EstadoActual"]}", Color.Gray, ref yPos);

            card.Controls.Add(contentPanel);
            card.Controls.Add(headerPanel);

            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(lblTransaccion, $"Transacción: {transaccionTexto}");
            toolTip.SetToolTip(transaccionContainer, $"Transacción: {transaccionTexto}");

            return card;
        }

        private void AddInfoLabelWithIcon(Panel parent, string icon, string text, Color color, ref int yPos)
        {
            Label label = new Label();
            label.Location = new Point(5, yPos);
            label.Size = new Size(280, 18);
            label.Text = $"{icon} {text}";
            label.ForeColor = color;
            label.Font = new Font("Segoe UI", 9);
            label.TextAlign = ContentAlignment.MiddleLeft;
            parent.Controls.Add(label);
            yPos += 18;
        }

        private string GetShortName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || fullName == "N/A") return "N/A";

            fullName = fullName.Trim();

            if (fullName.Length <= 18) return fullName;

            string[] words = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0) return "N/A";

            if (words.Length == 1)
            {
                return words[0].Length > 18 ? words[0].Substring(0, 18) + "..." : words[0];
            }
            else if (words.Length == 2)
            {
                return $"{words[0]} {words[1]}";
            }
            else
            {
                return $"{words[0]} {words[words.Length - 1]}";
            }
        }

        private string GetActionIcon(string accion)
        {
            if (accion.Contains("MOVER")) return "🚚";
            if (accion.Contains("PREPARACION")) return "📦";
            return "📝";
        }

        private void UpdateKPIs(DataTable data)
        {
            int total = data.Rows.Count;
            int completados = 0;
            int pendientes = 0;

            foreach (DataRow row in data.Rows)
            {
                if (row["EstadoCompletado"].ToString() == "COMPLETADO")
                    completados++;
                else
                    pendientes++;
            }

            kpiGaugePendientes.Value = pendientes;
            kpiGaugeProceso.Value = completados;
            kpiGaugeTotal.Value = total;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            refreshTimer.Stop();
            base.OnFormClosing(e);
        }
    }
}