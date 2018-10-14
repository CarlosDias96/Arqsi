using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.DTOs
{
    public class ValorDto
    {
        public int Id { get; set; }
        public int ValorDiscreto { get; set; }
        public ValorDto() { }
        public ValorDto(int ValorDiscreto)
        {
            this.ValorDiscreto = ValorDiscreto;
        }
    }
}
