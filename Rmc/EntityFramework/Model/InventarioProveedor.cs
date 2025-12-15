using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class InventarioProveedor
    {
        public int ID { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string PROVEEDOR { get; set; }
        public double LIBRAS { get; set; }
    }
}
