using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class ProductosFactura
    {
        public int facd_id { get; set; }
        public int facd_item_id { get; set; }
        public string ite_codigo { get; set; }
        public string ite_descripcion { get; set; }
        public int facd_cantidad { get; set; }
        public Double facd_peso { get; set; }
        public string facd_lote { get; set; }
        public int facd_prioridad { get; set; }
        public DateTime facd_fecha_caducidad { get; set; }
        public int CantidadPackList { get; set; }
        public int facd_no_conforme { get; set; }
    }
}
