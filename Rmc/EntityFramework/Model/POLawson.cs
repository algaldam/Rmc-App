using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.EntityFramework.Model
{
    public class POLawson
    {
        public string Numero { get; set; }
        public string Creador { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Peso { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string UnidadMedida { get; set; }

        // Campos a ingresar por el usuario
        public int Cantidad { get; set; }
        public string Lote { get; set; }
        public int Prioridad { get; set; }
    }
}
