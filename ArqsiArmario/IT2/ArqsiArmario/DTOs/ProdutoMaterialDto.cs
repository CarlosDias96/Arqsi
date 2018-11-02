using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.DTOs
{
    public class ProdutoMaterialDto
    {
       
        public int? ProdutoId { get; set; }
        public ProdutoDto Produto { get; set; }

       int? MaterialId { get; set; }
        public MaterialDto Material { get; set; }

        public ProdutoMaterialDto() { }
        public ProdutoMaterialDto(ProdutoDto Produto, MaterialDto Material)
        {
            this.Produto = Produto;
            this.Material = Material;

        }
    }
}
