using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.MaterialEmpaque.Mesas
{
    public class RegistroMesa
    {
        public string TraceId { get; set; }
        public string Saca { get; set; }
        public string WeekId { get; set; }
        public string CantidadStickers { get; set; }
        public string Dozens { get; set; }
        public DateTime StartDate { get; set; }
    }

}
