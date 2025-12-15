using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.MaterialEmpaque.Mesas
{
    public class ResultadoOperacion
    {
        public bool Exitoso { get; }
        public string MensajeError { get; }

        public ResultadoOperacion(bool exitoso, string mensajeError = null)
        {
            Exitoso = exitoso;
            MensajeError = mensajeError;
        }
    }
}
