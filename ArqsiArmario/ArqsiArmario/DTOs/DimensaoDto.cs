using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.DTOs
{
    public class DimensaoDto
    {

        public DimensaoDCDto AlturaDto { get; set; }
        public DimensaoDCDto ProfundidadeDto { get; set; }
        public DimensaoDCDto LarguraDto { get; set; }
        public DimensaoDto() { }
        
    }
}
