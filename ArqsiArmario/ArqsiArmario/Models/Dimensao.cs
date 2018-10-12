using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Dimensao
    {
     public Dimensao() { }
        public int Id { get; set; }

        public DimensaoContinua DimContinua { get; set; }

        public List<DimensaoDiscreta> DimDiscreta { get; set; }

    }
}