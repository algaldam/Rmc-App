using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class ClaseGenerica
    {
        public int ID { get; set; }
        public String Proveedor { get; set; }
        public String pla_item { get; set; }
        public String ite_descripcion { get; set; }
        public String pla_UOM { get; set; }
        public String Descripcion { get; set; }
        public Double LIBRAS { get; set; }
        public int ite_id { get; set; }
        public String Codigo { get; set; }
        public String Localidad { get; set; }
        public int Paquetes { get; set; }
        public string PackID { get; set; }
        public bool Escaneado { get; set; }
        public int Nuevo { get; set; }
        public int Eliminado { get; set; }
    }
}
