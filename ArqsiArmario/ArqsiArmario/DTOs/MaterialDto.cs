using System.Collections.Generic;
namespace ArqsiArmario.DTOs
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public AcabamentoDto Acabamento { get; set; }
        public int? AcabamentoId { get; set; }
        public MaterialDto() { }
        public MaterialDto(string Nome, AcabamentoDto Acabamento)
        {
            this.Nome = Nome;
            this.Acabamento = Acabamento;
        }
    }
}