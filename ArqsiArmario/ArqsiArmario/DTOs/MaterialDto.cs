using System.Collections.Generic;
namespace ArqsiArmario.DTOs
{
    public class MaterialDto
    {
        public string Nome { get; set; }
        public List<AcabamentoDto> Acabamentos { get; set; }
    }
}