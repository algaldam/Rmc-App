using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rmc.MaterialEmpaque.Monitoreo
{
    public partial class TraceIdCard : UserControl
    {
        public event EventHandler<string> CompleteClicked;

        public string TraceId => _traceId;
        private readonly string _traceId;
        private readonly DateTime _startDate;

        private Color _severityColor = Color.Gray;
        private Panel _severityBar;

        public TraceIdCard(
            string traceId, string saca, string mesa, string assortment,
            string dozens, string totalStickers, DateTime startDate)
        {
            _traceId = traceId;
            _startDate = startDate;

            InitializeComponent();

            this.Width = 300;
            this.Height = 180;
            this.Margin = new Padding(5);
            this.Padding = new Padding(10);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            _severityBar = new Panel
            {
                Width = 4,
                Dock = DockStyle.Left,
                BackColor = _severityColor
            };
            this.Controls.Add(_severityBar);
            this.Controls.SetChildIndex(_severityBar, 0);

            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateGray;

            Font infoFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Color infoColor = Color.DimGray;

            lblSaca.Font = lblMesa.Font = lblDocenas.Font = lblInicio.Font = lblStickers.Font = lblTranscurrido.Font = infoFont;
            lblSaca.ForeColor = lblMesa.ForeColor = lblDocenas.ForeColor = lblInicio.ForeColor = lblStickers.ForeColor = lblTranscurrido.ForeColor = infoColor;

            lblTitle.Text = $"TraceID: {traceId}";
            lblSaca.Text = $"Saca: {saca}";
            lblMesa.Text = $"Mesa: {mesa}";
            lblDocenas.Text = $"Docenas: {dozens}";
            lblInicio.Text = $"Asignación: {startDate:dd/MM/yyyy - HH:mm}";
            lblStickers.Text = $"Stickers: {totalStickers}";

            btnCompletar.Click += (s, e) => CompleteClicked?.Invoke(this, _traceId);

            UpdateElapsedAndSeverity();
        }

        public void UpdateElapsedAndSeverity()
        {
            TimeSpan elapsed = DateTime.Now - _startDate;
            double hours = elapsed.TotalHours;
            int wholeHours = (int)hours;
            int minutes = elapsed.Minutes;

            lblTranscurrido.Text = $"Transcurrido: {wholeHours} h {minutes} min";

            if (hours > 16)
            {
                _severityColor = Color.FromArgb(180, 0, 0); // Rojo oscuro
                this.BackColor = Color.FromArgb(245, 235, 235); // Gris rosado claro
            }
            else if (hours > 12)
            {
                _severityColor = Color.FromArgb(220, 50, 50); // Rojo medio
                this.BackColor = Color.FromArgb(250, 240, 230); // Beige claro
            }
            else if (hours > 8)
            {
                _severityColor = Color.FromArgb(255, 140, 0); // Naranja fuerte
                this.BackColor = Color.FromArgb(255, 250, 230); // Amarillo pálido
            }
            else if (hours >= 5)
            {
                _severityColor = Color.FromArgb(255, 200, 0); // Amarillo oscuro
                this.BackColor = Color.FromArgb(245, 255, 235); // Verde muy claro
            }
            else
            {
                _severityColor = Color.FromArgb(0, 180, 0); // Verde
                this.BackColor = Color.FromArgb(235, 255, 245); // Verde pálido
            }

            _severityBar.BackColor = _severityColor;
            this.Invalidate();
        }
    }
}