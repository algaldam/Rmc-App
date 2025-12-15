using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Utils
{
    class ParesGenericos
    {
        public object ID { get; set; }
        public string Descripcion { get; set; }
        public ParesGenericos(object ID, String Desripcion)
        {
            this.ID = ID;
            this.Descripcion = Desripcion;
        }
    }
}
