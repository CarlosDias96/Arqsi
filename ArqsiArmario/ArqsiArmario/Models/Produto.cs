using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }
        public Material Material { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        /*public int? categoriaId
        [ForeignKey["Categoria"]]
        public virtual Categoria Categoria;*/



    }
}