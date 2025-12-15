using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.EntityFramework.Main
{
    class fn_wai_Reporte_Toma_Inventario
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public Single LIBRAS { get; set; }
        public string PACK_ID { get; set; }
        public string LOC_ESCANEO { get; set; }
        public DateTime? FECHA_ENTRADA { get; set; }
        public string ESCANEO { get; set; }
        public DateTime? FECHA_ESCANEO { get; set; }
        public TimeSpan? HORA_ESCANEO { get; set; }
        public string LOC_PREESCANEO { get; set; }
        public string USUARIO { get; set; }
        public DateTime? FECHA { get; set; }
        public string CAMBIO_LOCALIDAD { get; set; }
    }
}
