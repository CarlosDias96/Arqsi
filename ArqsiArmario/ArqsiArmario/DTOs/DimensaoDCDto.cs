using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.DTOs
{
    public class DimensaoDCDto
    {

        public List<ValorDto> ListaDiscretaDto { get; set; }
        public float AlturaMinDto { get; set; }
        public float AlturaMaxDto { get; set; }
    }
}
