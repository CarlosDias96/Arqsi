using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class DimensaoContinua
    {
       public DimensaoContinua() { }
        public int Id { get; set; }

        public float AlturaMinima { get; set; }
        public float? AlturaMaxima { get; set; }

        public float ProfundidadeMinima { get; set; }
        public float? ProfunidadeMaxima { get; set; }

        public float LarguraMinima { get; set; }
        public float? LarguraMaxima { get; set; }
    }


}