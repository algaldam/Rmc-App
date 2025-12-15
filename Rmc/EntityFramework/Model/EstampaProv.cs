using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Modelo
{
    class EstampaProv
    {
		public int pac_id { get; set; }
		public bool pac_impreso { get; set; }
		public string pos_numero { get; set; }
		public string fac_numero { get; set; }
		public string ite_codigo { get; set; }
		public string ite_descripcion { get; set; }
		public string pro_nombre { get; set; }
		public float pac_libras { get; set; }
		public string facd_lote { get; set; }
		public string pac_prov_pack_id { get; set; }
		public int Localidad { get; set; }
		public string pos_semana { get; set; }
		public string bod_descripcion { get; set; }
		public DateTime FECHA { get; set; }
		public string Medida { get; set; }
	}
}
