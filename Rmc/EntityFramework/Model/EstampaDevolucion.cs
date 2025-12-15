using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class EstampaDevolucion
    {
        public string PackId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Localidad { get; set; }
        public string Lote { get; set; }
        public Single Libras { get; set; }
        public string Medida { get; set; }
    }
}
