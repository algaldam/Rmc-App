using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class Facturas
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public int Paquetes { get; set; }
        public string Libras { get; set; }
        public DateTime Fecha { get; set; }
    }
}
