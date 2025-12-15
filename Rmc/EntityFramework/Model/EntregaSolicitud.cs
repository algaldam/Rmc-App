using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class EntregaSolicitud
    {
        public string PackId { get; set; }
        public string Semana { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public string Proveedor { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string PersonaEntrega { get; set; }
        public double Minutos { get; set; }
        public string PersonaAutoriza { get; set; }
        public string Bodega { get; set; }
    }
}
