using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    public class LocalidadTraslados
    {
        public int ID { get; set; }
        public int ORIGEN { get; set; }
        public string PACKID { get; set; }
        public string ITEM { get; set; }
        public Single LIBRAS { get; set; }
        public bool? IMPRESO { get; set; }
        public DateTime? FECHAENTRADA { get; set; }
        public string LOCALIDAD { get; set; }
        public bool? MARCAR { get; set; }
    }
}
