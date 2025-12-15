using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class ProductoNoConforme
    {
        public int IdItem { get; set; }
        public int Origen { get; set; }
        public string NombreItem { get; set; }
        public int IdDefecto { get; set; }
    }
}
