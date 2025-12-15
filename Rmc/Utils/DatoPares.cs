using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.Utils
{
    class DatoPares
    {
        public static List<ParesGenericos> Estado()
        {
            try
            {
                var datos = new List<ParesGenericos>()
                {
                  new ParesGenericos("A","Abierto"),
                   new ParesGenericos("C","Cerrado"),
                };
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<ParesGenericos> EstadoEscaneo()
        {
            try
            {
                var datos = new List<ParesGenericos>()
                {
                  new ParesGenericos("E","Escanedos"),
                  new ParesGenericos("S","Sin Escanear"),
                  new ParesGenericos("T","Todos"),
                };
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<ParesGenericos> Periodos()
        {
            try
            {
                var datos = new List<ParesGenericos>()
                {
                  new ParesGenericos(1,"1"),
                  new ParesGenericos(2,"2"),
                  new ParesGenericos(3,"3"),
                  new ParesGenericos(4,"4"),
                  new ParesGenericos(5,"5"),
                  new ParesGenericos(6,"6"),
                  new ParesGenericos(7,"7"),
                  new ParesGenericos(8,"8"),
                  new ParesGenericos(9,"9"),
                  new ParesGenericos(10,"10"),
                  new ParesGenericos(11,"11"),
                  new ParesGenericos(12,"12"),
                };
                return datos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ParesGenericos> ObtenerLocalidadesEntrega()
        {
            try
            {
                var datos = new List<ParesGenericos>()
                {
                new ParesGenericos("A", "A"),
                new ParesGenericos("B", "B"),
                new ParesGenericos("C", "C"),
                new ParesGenericos("D", "D"),
                new ParesGenericos("E", "E"),
                new ParesGenericos("F", "F"),
                new ParesGenericos("G", "G"),
                new ParesGenericos("H", "H"),
                new ParesGenericos("I", "I"),
                new ParesGenericos("J", "J"),
                new ParesGenericos("K", "K"),
                new ParesGenericos("L", "L"),
                new ParesGenericos("M", "M"),
                new ParesGenericos("N", "N"),
                new ParesGenericos("O", "O"),
                new ParesGenericos("P", "P"),
                new ParesGenericos("Q", "Q"),
                new ParesGenericos("R", "R"),
                new ParesGenericos("S", "S"),
                new ParesGenericos("T", "T"),
                new ParesGenericos("U", "U"),
                new ParesGenericos("V", "V"),
                new ParesGenericos("W", "W"),
                new ParesGenericos("X", "X"),
                new ParesGenericos("Y", "Y"),
                new ParesGenericos("Z", "Z"),
                new ParesGenericos("27", "Bodega"),
                new ParesGenericos("28", "Tunel 1"),
                new ParesGenericos("29", "Tunel 2"),
                new ParesGenericos("30", "Tunel 3"),
                new ParesGenericos("31", "Cuarto químicos auxiliares"),
                new ParesGenericos("32", "Cuarto colorantes -WIP"),
                new ParesGenericos("33", "Cuarto colorantes- Bodega"),
            };
                return datos;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
