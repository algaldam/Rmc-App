using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

/* =====================================================
 *  CLASE: MesaUIHandler
 *  DESCRIPCIÓN: Gestor de interfaz para visualización 
 *               interactiva de mesas.
 *  AUTOR: Alex Galdamez
 *  
 *  FUNCIONALIDADES PRINCIPALES:
 *  ✔ Renderizado de botones
 *  ✔ Sistema de estados visuales (Disponible/Ocupada/Desactivada)
 *  ✔ Tooltips dinámicos con información operativa
 *  ✔ Gestión segura de eventos multi-hilo                          
 *  
 *  ÚLTIMA ACTUALIZACIÓN: 07/25/2025
 * ===================================================== */
namespace Rmc.MaterialEmpaque.Mesas
{
    public class MesaUIHandler
    {
        private const int Margen = 25;
        private const int Columnas = 4;
        private const int BotonAlto = 128;
        private const int BotonAncho = 180;

        private readonly Panel _contenedor;
        private readonly ToolTip _toolTip = new ToolTip();

        private readonly Dictionary<EstadoMesa, ColorConfig> _coloresEstados = new Dictionary<EstadoMesa, ColorConfig>
        {
            [EstadoMesa.Ocupada] = new ColorConfig(
                Color.FromArgb(231, 76, 60),
                Color.FromArgb(192, 57, 43),
                Color.FromArgb(241, 148, 138),
                "🛑 Ocupada"),

            [EstadoMesa.Disponible] = new ColorConfig(
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(41, 128, 185),
                Color.FromArgb(93, 173, 226),
                "✅ Disponible"),

            [EstadoMesa.Desactivada] = new ColorConfig(
                Color.FromArgb(149, 165, 166),
                Color.FromArgb(127, 140, 141),
                Color.FromArgb(189, 195, 199),
                "⚪ Desactivada")
        };

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public MesaUIHandler(Panel contenedor)
        {
            _contenedor = contenedor;

            _toolTip.AutoPopDelay = 5000;
            _toolTip.InitialDelay = 300;
            _toolTip.ShowAlways = true;
            _toolTip.ToolTipTitle = "Detalles de Mesa";
        }

        public void CrearBotonesMesas(List<Mesa> mesas)
        {
            if (_contenedor.InvokeRequired)
            {
                _contenedor.Invoke(new Action(() => CrearBotonesMesas(mesas)));
                return;
            }

            _contenedor.Controls.Clear();
            _contenedor.SuspendLayout();

            int x = Margen;
            int y = Margen;
            int contador = 0;

            foreach (var mesa in mesas)
            {
                var btn = new Button
                {
                    Name = $"btnMesa{mesa.Id}",
                    Tag = mesa,
                    Width = BotonAncho,
                    Height = BotonAlto,
                    Location = new Point(x, y),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = $" Mesa {mesa.Id}\nCargando..."
                };

                btn.FlatAppearance.BorderSize = 2;
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));

                btn.MouseDown += (s, e) =>
                {
                    if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                    {
                        var button = s as Button;
                        var mesaTag = button.Tag as Mesa;

                        string mensaje = mesaTag.Activa
                            ? "¿Desea desactivar esta mesa?"
                            : "¿Desea activar esta mesa?";

                        if (RadMessageBox.Show(mensaje, "Confirmar",
                            MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                        {
                            CambiarEstadoMesa(mesaTag, button);
                        }
                    }
                };

                ConfigurarHover(btn, mesa);
                ConfigurarBoton(btn, mesa.Activa ? EstadoMesa.Disponible : EstadoMesa.Desactivada, mesa.Id);
                _contenedor.Controls.Add(btn);

                contador++;
                x += BotonAncho + Margen;

                if (contador % Columnas == 0)
                {
                    x = Margen;
                    y += BotonAlto + Margen;
                }
            }

            _contenedor.ResumeLayout();
            _contenedor.AutoScroll = true;
        }

        private void ConfigurarHover(Button btn, Mesa mesa)
        {
            btn.MouseEnter += async (sender, e) =>
            {
                try
                {
                    var form = btn.FindForm() as MesasForm;
                    if (form == null) return;

                    var registroActivo = await Task.Run(() =>
                        form.MesaService.ObtenerRegistroActivo(mesa.Id));

                    var pendientesCount = await Task.Run(() =>
                        form.MesaService.ObtenerConteoPendientes(mesa.Id));

                    var totalStickers = await Task.Run(() =>
                        form.MesaService.ObtenerConteoTotalStickers(mesa.Id));

                    string textoHover = $"MESA: {mesa.Id}" +
                                        $"\nTotal Stickers: {totalStickers}";

                    if (registroActivo != null)
                    {
                        textoHover += $"\n\n ▶ EN PROCESO" +
                                     $"\nTrace ID: {registroActivo.TraceId}" +
                                     $"\nSaca: {registroActivo.Saca}" +
                                     $"\nSemana: {registroActivo.WeekId}" +
                                     $"\nStickers: {registroActivo.CantidadStickers}" +
                                     $"\nDocenas: {registroActivo.Dozens}" +
                                     $"\nTiempo: {DateTime.Now - registroActivo.StartDate:hh\\:mm\\:ss}";
                    }

                    textoHover += $"\n\n ▶ PENDIENTES: {pendientesCount}";

                    if (btn.InvokeRequired)
                    {
                        btn.Invoke(new Action(() => _toolTip.SetToolTip(btn, textoHover)));
                    }
                    else
                    {
                        _toolTip.SetToolTip(btn, textoHover);
                    }
                }
                catch (Exception ex)
                {
                    if (btn.InvokeRequired)
                    {
                        btn.Invoke(new Action(() => _toolTip.SetToolTip(btn, $"Error cargando datos:\n{ex.Message}")));
                    }
                    else
                    {
                        _toolTip.SetToolTip(btn, $"Error cargando datos:\n{ex.Message}");
                    }
                }
            };
        }

        private async void CambiarEstadoMesa(Mesa mesa, Button button)
        {
            try
            {
                var form = button.FindForm() as MesasForm;
                if (form == null) return;

                bool nuevoEstado = !mesa.Activa;
                var operacion = await Task.Run(() =>
                    form.MesaService.CambiarEstadoMesa(mesa.Id, nuevoEstado));

                if (operacion.Exitoso)
                {
                    mesa.Activa = nuevoEstado;
                    var estado = nuevoEstado ? EstadoMesa.Disponible : EstadoMesa.Desactivada;

                    if (button.InvokeRequired)
                    {
                        button.Invoke(new Action(() => ConfigurarBoton(button, estado, mesa.Id)));
                    }
                    else
                    {
                        ConfigurarBoton(button, estado, mesa.Id);
                    }

                    form.ActualizarEstados();
                }
                else
                {
                    MessageBox.Show(operacion.MensajeError, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el estado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarBotones(Dictionary<int, EstadoMesa> estados)
        {
            if (_contenedor.InvokeRequired)
            {
                _contenedor.Invoke(new Action(() => ActualizarBotones(estados)));
                return;
            }

            foreach (Control control in _contenedor.Controls)
            {
                if (control is Button btn && btn.Tag is Mesa mesa && estados.ContainsKey(mesa.Id))
                {
                    ConfigurarBoton(btn, estados[mesa.Id], mesa.Id);
                }
            }
        }

        private void ConfigurarBoton(Button btn, EstadoMesa estado, int mesaId)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke(new Action(() => ConfigurarBoton(btn, estado, mesaId)));
                return;
            }

            var config = _coloresEstados[estado];

            btn.BackColor = config.ColorFondo;
            btn.FlatAppearance.BorderColor = config.ColorBorde;
            btn.FlatAppearance.MouseDownBackColor = config.ColorClick;
            btn.FlatAppearance.MouseOverBackColor = config.ColorHover;
            btn.Text = $" Mesa {mesaId}\n{config.TextoEstado}";
            btn.Enabled = true;
        }

        private class ColorConfig
        {
            public Color ColorFondo { get; }
            public Color ColorBorde { get; }
            public Color ColorClick { get; }
            public Color ColorHover { get; }
            public string TextoEstado { get; }

            public ColorConfig(Color fondo, Color borde, Color hover, string texto)
            {
                ColorFondo = fondo;
                ColorBorde = borde;
                ColorClick = borde;
                ColorHover = hover;
                TextoEstado = texto;
            }
        }
    }
}
