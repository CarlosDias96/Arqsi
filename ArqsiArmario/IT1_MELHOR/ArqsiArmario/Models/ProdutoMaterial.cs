using ArqsiArmario.DTOs;

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


        public ProdutoMaterialDto toDTO()
        {
            ProdutoMaterialDto produtoMaterialDto = new ProdutoMaterialDto(this.Produto.toDTO(),this.Material.toDTO());
            return produtoMaterialDto;
        }
        public static ProdutoMaterial fromDTO(ProdutoMaterialDto produtoMaterialDto)
        {
            ProdutoMaterial produtoMaterial = new ProdutoMaterial(Produto.fromDTO(produtoMaterialDto.Produto), Material.fromDTO(produtoMaterialDto.Material));
            return produtoMaterial;
        }
        public override bool Equals(object obj)
        {
            var produtoMaterial = obj as ProdutoMaterial;
            return produtoMaterial != null && this.ProdutoId == produtoMaterial.ProdutoId && this.MaterialId == produtoMaterial.MaterialId ;
        }
    }
}
