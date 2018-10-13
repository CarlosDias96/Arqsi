using System.Collections.Generic;

namespace ArqsiArmario.DTOs
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Composto { get; set; }
        public ICollection<ProdutoDto> Produtos { get; set; }

        public MaterialDto Material{ get; set; }
        public int? MaterialId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public int? CategoriaId { get; set; }

        public ProdutoDto() { }
        public ProdutoDto(string Nome, bool Composto, ICollection<ProdutoDto> Produtos, MaterialDto Material, CategoriaDto Categoria)
        {
            this.Nome = Nome;
            this.Composto = Composto;
            this.Produtos = Produtos;
            this.Material = Material;
            this.Categoria = Categoria;
        }
    }
}