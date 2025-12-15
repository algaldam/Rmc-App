using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class PackListSalida
    {
        public string PackId { get; set; }
        public String Lote { get; set; }
        public int Prioridad { get; set; }
        public double Peso { get; set; }
        public string Localidad { get; set; }
        public string FechaProduccion { get; set; }
        public string FechaEntrada { get; set; }
        public string Semana { get; set; }
        public string Contador { get; set; }
    }
}
