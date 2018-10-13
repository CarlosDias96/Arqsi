using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiArmario.Models
{
    public class ProdutoMaterial
    {
        public ProdutoMaterial(Produto Produto, Material Material)
        {
            this.Produto = Produto;
            this.Material = Material;
        }
        public ProdutoMaterial() { }

        public int? ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
