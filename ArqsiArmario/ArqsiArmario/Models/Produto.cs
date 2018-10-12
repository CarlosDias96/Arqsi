using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public bool Composto { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set;}

        public Material Material { get; set; }
        public int? MaterialId { get; set; }

        public int? CategoriaId;
        public Categoria Categoria;

        public Produto() { }
        public Produto(string Nome,List<Produto> Produtos, Material Material, Categoria Categoria)
        {
            this.Nome = Nome;
            this.Produtos = Produtos;
            this.Material = Material;
            this.Categoria = Categoria;
        }


    }
}