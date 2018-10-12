using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.Models
{
    public class DimensaoDC
    {
        public int Id { get; set; }
        public List<Valor> ListaDiscreta { get; set; }
        public float AlturaMin { get; set; }
        public float AlturaMax { get; set; }
    }
}
