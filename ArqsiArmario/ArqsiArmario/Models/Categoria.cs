using System.Collections;
using System.Collections.Generic;

namespace ArqsiArmario.Models
{
    public class Categoria
    {
        public Categoria(string nome,Categoria CategoriaPai)
        {
            this.Nome = Nome;
            this.CategoriaPai = CategoriaPai;
        }
        public Categoria() { }
        public int Id { get; set; }
        public bool Composto { get; set; }
        public string Nome { get; set; }
        public virtual Categoria CategoriaPai { get; set; }
        public int? CategoriaId { get; set; }
        public ICollection<Categoria> SubCategorias { get; set; }

   
    }
}