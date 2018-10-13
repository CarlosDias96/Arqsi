using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public bool Composto { get; set; }
        public string Nome { get; set; }
        public ICollection<int?> ProdutosId { get; set; }
        public ICollection<Produto> Produtos { get; set;}

        public Material Material { get; set; }
        public int? MaterialId { get; set; }

        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int? DimensaoId { get; set; }
        public Dimensao Dimensao { get; set; }

        public Produto() { }
        public Produto(string Nome,ICollection<Produto> Produtos, Material Material, Categoria Categoria,Dimensao Dimensao)
        {
            this.Nome = Nome;
            this.Produtos = Produtos;
            this.Material = Material;
            this.Categoria = Categoria;
            this.Dimensao = Dimensao;
        }


    }
}