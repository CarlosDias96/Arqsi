using System.Collections.Generic;

namespace ArqsiArmario.DTOs
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public List<ProdutoDto> Produtos { get; set; }
        public MaterialDto Material { get; set; }
        public CategoriaDto Categoria { get; set; }

    }
}