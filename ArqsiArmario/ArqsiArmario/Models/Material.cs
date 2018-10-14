using System.Collections.Generic;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class Material
    {
      
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<MaterialAcabamento> MaterialAcabamentos { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ICollection<int?> MaterialAcabamentosId { get; set; }


        public ICollection<ProdutoMaterial> ProdutoMateriais { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ICollection<int?> ProdutoMateriaisId { get; set; }

        public Material() { }
        public Material(string Nome)
        {
            this.Nome = Nome;
        }

        public MaterialDto toDTO()
        {
            List<MaterialAcabamentoDto> ListaMA = new List<MaterialAcabamentoDto>();
            foreach (MaterialAcabamento ma in this.MaterialAcabamentos)
            {
                ListaMA.Add(ma.toDTO());
            }
            MaterialDto materialDto = new MaterialDto(this.Nome,ListaMA);
            return materialDto;
        }
        public static Material fromDTO(MaterialDto MaterialDto)
        {
            Material material = new Material(MaterialDto.Nome);
            return material;
        }
        public override bool Equals(object obj)
        {
            var acabamento = obj as Acabamento;
            return acabamento != null && this.Id == acabamento.Id && EqualityComparer<string>.Default.Equals(Nome, acabamento.Nome);
        }
    }
}