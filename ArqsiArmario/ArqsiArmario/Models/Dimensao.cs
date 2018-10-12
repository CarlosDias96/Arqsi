using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Dimensao
    {
     public Dimensao() { }
        public int Id { get; set; }

        public DimensaoDC Altura;
        public DimensaoDC Profundidade;
        public DimensaoDC Largura;

    }
}