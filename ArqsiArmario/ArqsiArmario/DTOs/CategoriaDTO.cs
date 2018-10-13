using System.Collections.Generic;
using ArqsiArmario.Models;

namespace ArqsiArmario.DTOs
{
    public class CategoriaDto
    {
        public CategoriaDto() { }
        public CategoriaDto(string Nome, string Descricao, bool Composto, Categoria CategoriaPai, ICollection<Categoria> SubCategorias)
        {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Composto = Composto;
            this.CategoriaPai = CategoriaPai;
            this.SubCategorias = SubCategorias;
        }
        public string Nome { get; set; }
        public bool Composto { get; set; }
        public string Descricao { get; set; }
        public virtual Categoria CategoriaPai { get; set; }
        public int? CategoriaId { get; set; }
        public ICollection<Categoria> SubCategorias { get; set; }
    }
}