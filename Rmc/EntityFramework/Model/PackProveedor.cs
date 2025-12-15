using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class PackProveedor
    {
        public string PackID { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Proveedor { get; set; }
        public double Libras { get; set; }
        public string Lote { get; set; }
        public string Localidad { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
