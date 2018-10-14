using System.Collections.Generic;

namespace ArqsiArmario.DTOs
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Composto { get; set; }
        public ICollection<ProdutoDto> Produtos { get; set; }

        public ICollection<ProdutoMaterialDto> ProdutoMateriais{ get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ICollection<int?> MaterialId { get; set; }

        public CategoriaDto Categoria { get; set; }
        public int? CategoriaId { get; set; }
        public DimensaoDto Dimensao { get; set; }

        public ProdutoDto() { }
        public ProdutoDto(string Nome, bool Composto, ICollection<ProdutoDto> Produtos, ICollection<ProdutoMaterialDto> Material, CategoriaDto Categoria)
        {
            this.Nome = Nome;
            this.Composto = Composto;
            this.Produtos = Produtos;
            this.ProdutoMateriais = Material;
            this.Categoria = Categoria;
        }
    }
}