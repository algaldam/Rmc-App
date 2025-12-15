using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    public class Solicitud
    {
        public int sol_ID { get; set; }
        public string sol_semana { get; set; }
        public string sol_item { get; set; }
        public string sol_estado { get; set; }
        public string sol_UOM { get; set; }
        public string pro_nombre { get; set; }
        public string sol_turno_crea { get; set; }
        public string sol_turno_entrega { get; set; }
        public DateTime? sol_FH_crea { get; set; }
        public DateTime? sol_FH_entrega { get; set; }
        public string sol_localidad { get; set; }
        public string sol_usuario_pedido { get; set; }
        public string NOMBRE_PIDE { get; set; }
        public string sol_usuario_entrega { get; set; }
        public string NOMBRE_ENTREGA { get; set; }
        public string ite_descripcion { get; set; }
        public string sol_prioridad { get; set; }
    }
}
