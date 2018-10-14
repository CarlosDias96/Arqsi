using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.DTOs
{
    public class MaterialAcabamentoDto
    {
        public MaterialAcabamentoDto() { }
        public MaterialAcabamentoDto(MaterialDto material, AcabamentoDto acabamento)
        {
            this.Acabamento = acabamento;
            this.Material = material;
        }
        public int? MaterialId { get; set; }
        public MaterialDto Material { get; set; }
        public int? AcabamentoId { get; set; }
        public AcabamentoDto Acabamento { get; set; }
    }
}
