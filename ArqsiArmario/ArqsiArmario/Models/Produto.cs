using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set;}

        public Material Material { get; set; }
        public int MaterialId { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        /*public int? categoriaId
        [ForeignKey["Categoria"]]
        public virtual Categoria Categoria;*/
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