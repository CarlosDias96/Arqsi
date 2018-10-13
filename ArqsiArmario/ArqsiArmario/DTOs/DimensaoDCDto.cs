using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.DTOs
{
    public class DimensaoDCDto
    {
        public DimensaoDCDto() { }
        public DimensaoDCDto(float AlturaMin, float AlturaMax, ICollection<Valor> ListaDiscreta)
        {
            this.ListaDiscreta = ListaDiscreta;
            this.AlturaMin = AlturaMin;
            this.AlturaMax = AlturaMax;
        }
        public int Id { get; set; }
        public ICollection<Valor> ListaDiscreta{ get; set; }
        public float AlturaMin { get; set; }
        public float AlturaMax { get; set; }
    }
}
