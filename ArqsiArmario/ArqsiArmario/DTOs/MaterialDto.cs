using System.Collections.Generic;
namespace ArqsiArmario.DTOs
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<MaterialAcabamentoDto> MaterialAcabamento { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ICollection<int?> MaterialAcabamentoId { get; set; }
        public MaterialDto() { }
        public MaterialDto(string Nome, ICollection<MaterialAcabamentoDto> MaterialAcabamento)
        {
            this.Nome = Nome;
            this.MaterialAcabamento = MaterialAcabamento;
        }
    }
}