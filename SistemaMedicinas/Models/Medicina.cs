using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMedicinas.Models
{
    public class Medicina
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public decimal Precio { get; set; }
    }
}
