using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Material> Materiais { get; set; }

    }
}