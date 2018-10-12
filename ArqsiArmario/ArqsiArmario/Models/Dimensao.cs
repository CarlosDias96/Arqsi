using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Dimensao
    {
     public Dimensao() { }
        public int Id { get; set; }

        public DimensaoDC Altura { get; set; }
        public DimensaoDC Profundidade { get; set; }
        public DimensaoDC Largura { get; set; }

    }
}