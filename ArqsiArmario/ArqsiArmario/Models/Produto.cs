using System.Collections.Generic;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public bool Composto { get; set; }
        public string Nome { get; set; }
        
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ICollection<int?> ProdutoMateriaisId { get; set; }
        public ICollection<ProdutoMaterial> ProdutosMateriais { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public ICollection<int?> ProdutosId { get; set; }
        public ICollection<Produto> Produtos { get; set;}

        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int? DimensaoId { get; set; }
        public Dimensao Dimensao { get; set; }

        public Produto() { }
        public Produto(string Nome,bool Composto,ICollection<Produto> Produtos, ICollection<ProdutoMaterial> ProdutoMateriais, Categoria Categoria,Dimensao Dimensao)
        {
            this.Nome = Nome;
            this.Composto = Composto;
            this.Produtos = Produtos;
            this.ProdutosMateriais = ProdutoMateriais;
            this.Categoria = Categoria;
            this.Dimensao = Dimensao;
        }

        public Produto(string Nome)
        {
            this.Nome = Nome;
        }

        public ProdutoDto toDTO()
        {
            List<ProdutoDto> subProdutos = new List<ProdutoDto>();
            List<ProdutoMaterialDto> materiais = new List<ProdutoMaterialDto>();

            foreach(Produto p in this.Produtos)
            {
                subProdutos.Add(p.toDTO());
            }
            foreach(ProdutoMaterial pm in this.ProdutosMateriais)
            {
                materiais.Add(pm.toDTO());
            }
       
            ProdutoDto produtoDto = new ProdutoDto(this.Nome,this.Composto,subProdutos,materiais,this.Categoria.toDTO());
            return produtoDto;
        }
        public static Produto fromDTO(ProdutoDto produtoDto)
        {
            List<Produto> ListaP = new List<Produto>();
            List<ProdutoMaterial> ListaPM = new List<ProdutoMaterial>();
            foreach (ProdutoMaterialDto pm in produtoDto.ProdutoMateriais)
            {
                ListaPM.Add(ProdutoMaterial.fromDTO(pm));
            }
            foreach(ProdutoDto p in produtoDto.Produtos)
            {
                ListaP.Add(Produto.fromDTO(p));
            }
            Produto produto = new Produto(produtoDto.Nome,produtoDto.Composto,ListaP,ListaPM,Categoria.fromDTO(produtoDto.Categoria),Dimensao.fromDTO(produtoDto.Dimensao));
            return produto;
        }
        public override bool Equals(object obj)
        {
            var produto = obj as Acabamento;
            return produto != null && this.Id == produto.Id && EqualityComparer<string>.Default.Equals(Nome, produto.Nome);
        }
    }
}