using System.Collections;
using System.Collections.Generic;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class Categoria
    {
        public Categoria(string Nome,string Descricao, bool Composto, Categoria CategoriaPai, ICollection<Categoria> SubCategorias)
        {
            this.Nome = Nome;
            this.CategoriaPai = CategoriaPai;
            this.Descricao = Descricao;
            this.Composto = Composto;
            this.CategoriaPai = CategoriaPai;
            this.SubCategorias = SubCategorias;
        }
        public Categoria() { }
        public int Id { get; set; }
        public bool Composto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual Categoria CategoriaPai { get; set; }
        public int? CategoriaId { get; set; }
        public ICollection<int?> SubCategoriasId { get; set; }
        public ICollection<Categoria> SubCategorias { get; set; }

        public CategoriaDto toDTO()
        {
            List<CategoriaDto> CategoriasSub = new List<CategoriaDto>(); 
            foreach(Categoria c in this.SubCategorias)
            {
                CategoriasSub.Add(c.toDTO());
            }
            CategoriaDto categoriaDto = new CategoriaDto(this.Nome,this.Descricao,this.Composto,this.CategoriaPai.toDTO(),CategoriasSub);
            return categoriaDto;
        }
        public static Categoria fromDTO(CategoriaDto categoriaDto)
        {
            List<Categoria> CategoriasSub = new List<Categoria>();
            foreach(CategoriaDto c in categoriaDto.SubCategorias)
            {
                CategoriasSub.Add(Categoria.fromDTO(c));
            }
            Categoria categoria = new Categoria(categoriaDto.Nome,categoriaDto.Descricao,categoriaDto.Composto,Categoria.fromDTO(categoriaDto.CategoriaPai),CategoriasSub);
            return categoria;
        }
        public override bool Equals(object obj)
        {
            var acabamento = obj as Categoria;
            return acabamento != null && this.Id == acabamento.Id && EqualityComparer<string>.Default.Equals(Nome, acabamento.Nome);
        }

    }
}