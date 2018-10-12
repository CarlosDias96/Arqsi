using System.Collections.Generic;

namespace ArqsiArmario.DTOs
{
    public class CategoriaDto
    {
        public string NomeDto { get; set; }
        public bool CompostoDto { get; set; }
        public string DescricaoDto { get; set; }
        public virtual CategoriaDto CategoriaDtoPai { get; set; }
        public int? CategoriaId { get; set; }
        public ICollection<CategoriaDto> SubCategoriasDto { get; set; }
    }
}