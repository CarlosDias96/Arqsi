using System.Collections.Generic;

namespace ArqsiArmario.DTOs
{
    public class ProdutoDto
    {
        public string NomeDto { get; set; }
        public bool CompostoDto { get; set; }
        public ICollection<ProdutoDto> ProdutosDto { get; set; }

        public MaterialDto MaterialDto { get; set; }
        public CategoriaDto CategoriaDto { get; set; }
    }
}