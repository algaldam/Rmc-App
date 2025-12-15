using Rmc.MaterialEmpaque.Inventario;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Rmc.MaterialEmpaque.Mesas
{
    public partial class MesasForm : Telerik.WinControls.UI.RadForm
    {
        private bool _isClosing = false;
        private DateTime _proximaActualizacion;

        public MesaService MesaService => _mesaService;
        private readonly AutomaticStatusChanger _statusChanger;

        private readonly MesaService _mesaService;
        private readonly MesaUIHandler _uiHandler;
        private readonly TareasGridHandler _gridHandler;
        private readonly Timer _contadorTimer = new Timer();

        public MesasForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            _uiHandler = new MesaUIHandler(panelMesasContainer);
            _gridHandler = new TareasGridHandler(dataGridViewTareas);
            _mesaService = new MesaService(Properties.Settings.Default.TracerConnectionString);
            _statusChanger = new AutomaticStatusChanger(Properties.Settings.Default.TracerConnectionString);

            ConfigureForm();
        }

        #region Eventos Form
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarTodo();
        }

        private void MesasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isClosing) return;
            _isClosing = true;

            try
            {
                // Desvincular eventos
                timerActualizacion.Tick -= TimerActualizacion_Tick;
                _contadorTimer.Tick -= ContadorTimer_Tick;

                // Detener timers
                timerActualizacion.Stop();
                _contadorTimer.Stop();
            }
            finally
            {
                _isClosing = false;
            }
        }

        private void btnActualizar_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                ActualizarTodo();
            }
        }

        private void TimerActualizacion_Tick(object sender, EventArgs e)
        {
            _proximaActualizacion = DateTime.Now.AddMilliseconds(timerActualizacion.Interval);
            ActualizarTodo();
        }

        private void ContadorTimer_Tick(object sender, EventArgs e)
        {
            var tiempoRestante = _proximaActualizacion - DateTime.Now;

            if (tiempoRestante.TotalSeconds > 0)
            {
                int minutos = (int)tiempoRestante.TotalMinutes;
                int segundos = tiempoRestante.Seconds;

                if (tiempoRestante.TotalSeconds <= 10)
                {
                    lblUltimaActualizacion.ForeColor = Color.Red;
                    lblUltimaActualizacion.Text = $"Actualizando en: {segundos}s";
                }
                else
                {
                    lblUltimaActualizacion.ForeColor = Color.White;
                    lblUltimaActualizacion.Text = $"Actualización: {minutos}:{segundos:D2}";
                }
            }
            else if (!lblUltimaActualizacion.Text.StartsWith(""))
            {
                lblUltimaActualizacion.Text = "Actualizando...";
                lblUltimaActualizacion.ForeColor = Color.White;
            }
        }

        private void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            int proximoMesaId = _mesaService.GetProximoMesaId();

            var dialogResult = RadMessageBox.Show(
                this,
                $"Se agregará la Mesa #{proximoMesaId}\n\n" +
                "Una vez creada, esta mesa no podrá ser eliminada.\n" +
                "¿Desea continuar?",
                "Confirmar creación de mesa",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool creada = _mesaService.CrearMesas(proximoMesaId);

                    if (creada)
                    {
                        CargarInterfaz();
                    }
                    else
                    {
                        RadMessageBox.Show(
                            this,
                            $"La mesa {proximoMesaId} ya existe o no se pudo crear.",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            RadMessageIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show(
                        this,
                        $"Error al crear la mesa: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
            }
        }

        private void dataGridViewTareas_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is Telerik.WinControls.UI.GridHeaderCellElement)
            {
                e.CellElement.BackColor = Color.FromArgb(44, 62, 80);
                e.CellElement.ForeColor = Color.White;
                e.CellElement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellElement.DrawFill = true;
            }
        }

        private void GridHandler_ReasignacionSolicitada(object sender, ReasignacionEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, ReasignacionEventArgs>(GridHandler_ReasignacionSolicitada), sender, e);
                return;
            }

            try
            {
                using (var formReasignar = new ReasignarForm(e.TraceId, e.MesaActual))
                {
                    if (formReasignar.ShowDialog(this) == DialogResult.OK)
                    {
                        // Recargar datos si se realizó la reasignación
                        ActualizarGridTareas();
                        ActualizarEstados();
                        Task.Run(() => ActualizarIndicadores());
                    }
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this,
                    $"Error al abrir formulario de reasignación: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error);
            }
        }
        #endregion

        #region Metodos
        private void ConfigureForm()
        {
            _gridHandler.ReasignacionSolicitada += GridHandler_ReasignacionSolicitada;

            // Timer de actualización principal (2 min)
            timerActualizacion.Interval = 120000;
            timerActualizacion.Tick += TimerActualizacion_Tick;

            // Timer para el contador regresivo (1 segundo)
            _contadorTimer.Interval = 1000;
            _contadorTimer.Tick += ContadorTimer_Tick;

            timerActualizacion.Start();
            _contadorTimer.Start();

            _proximaActualizacion = DateTime.Now.AddMilliseconds(timerActualizacion.Interval);
            _gridHandler.ConfigurarGrid();
            CargarInterfaz();
            ActualizarTodo();
        }

        private void ActualizarGridTareas()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarGridTareas));
                return;
            }

            try
            {
                _gridHandler.CargarTareas();
                _gridHandler.AplicarColoresPorEstado();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar grid de tareas: {ex.Message}");
            }
        }

        private async void ActualizarTodo()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarTodo));
                return;
            }

            try
            {
                lblUltimaActualizacion.Text = "Actualizando...";
                lblUltimaActualizacion.ForeColor = Color.White;
                this.Refresh();

                await Task.Run(async () =>
                {
                    _mesaService.ActualizarEstadosTareas();
                    ActualizarEstados();
                    ActualizarGridTareas();
                    await _statusChanger.ExecuteStatusChangeAsync();
                    return ActualizarIndicadores();
                });

                _proximaActualizacion = DateTime.Now.AddMilliseconds(timerActualizacion.Interval);
            }
            catch (Exception ex)
            {
                lblIndicadorMesas.Text = "Err";
                lblIndicadorDocenas.Text = "Err";
                lblIndicadorStickers.Text = "Err";

                Debug.WriteLine($"Error en actualización: {ex.Message}");
            }
        }

        private void CargarInterfaz()
        {
            var mesas = _mesaService.ObtenerTodasLasMesas();
            _uiHandler.CrearBotonesMesas(mesas);
            ActualizarTodo();
        }

        public void ActualizarEstados()
        {
            try
            {
                _mesaService.ActualizarEstadosTareas();
                _mesaService.ActualizarEstadosPendientes();
                var estados = _mesaService.ObtenerEstadosMesas();
                _uiHandler.ActualizarBotones(estados);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar estados: {ex.Message}");
            }
        }

        private async Task ActualizarIndicadores()
        {
            try
            {
                var (mesasActivas, totalDocenas, stickersEnMesas, completadas, proceso, pendientes, pendienteDz, procesocDz) 
                    = await Task.Run(() => _mesaService.ObtenerIndicadores());

                this.Invoke(new Action(() =>
                {
                    lblIndicadorMesas.Text = mesasActivas.ToString("N0");
                    lblIndicadorDocenas.Text = totalDocenas.ToString("N2");
                    lblIndicadorStickers.Text = stickersEnMesas.ToString("N0");

                    lblIndicadorTareasProceso.Text = proceso.ToString("N0") + " / " + procesocDz.ToString("N2") + " Dz";
                    lblIndicadorTareasPendientes.Text = pendientes.ToString("N0") + " / " + pendienteDz.ToString("N2") + " Dz";
                    lblIndicadorTareasCompletadas.Text = completadas.ToString("N0");

                    lblIndicadorMesas.ForeColor = mesasActivas > 0 ? Color.Black : Color.Red;
                    lblIndicadorDocenas.ForeColor = totalDocenas > 0 ? Color.Black : Color.Red;
                    lblIndicadorStickers.ForeColor = stickersEnMesas > 0 ? Color.Black : Color.Red;
                    lblIndicadorTareasProceso.ForeColor = proceso > 0 ? Color.Black : Color.Red;
                    lblIndicadorTareasPendientes.ForeColor = pendientes > 0 ? Color.Black : Color.Red;
                    lblIndicadorTareasCompletadas.ForeColor = completadas > 0 ? Color.Black : Color.Red;
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() =>
                {
                    lblIndicadorMesas.Text = "Err";
                    lblIndicadorDocenas.Text = "Err";
                    lblIndicadorStickers.Text = "Err";
                    lblIndicadorTareasProceso.Text = "Err";
                    lblIndicadorTareasPendientes.Text = "Err";
                    lblIndicadorTareasCompletadas.Text = "Err";

                    lblIndicadorMesas.ForeColor = Color.Red;
                    lblIndicadorDocenas.ForeColor = Color.Red;
                    lblIndicadorStickers.ForeColor = Color.Red;
                    lblIndicadorTareasProceso.ForeColor = Color.Red;
                    lblIndicadorTareasPendientes.ForeColor= Color.Red;
                    lblIndicadorTareasCompletadas.ForeColor = Color.Red;
                }));

                throw;
            }
        }
        #endregion

        
    }

    public class DoubleClickButton : Button
    {
        public DoubleClickButton()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            DoubleBuffered = true;
        }
    }
}