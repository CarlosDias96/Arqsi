using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface IProdutoMaterialRepository : IDisposable
    {
        IEnumerable<ProdutoMaterial> GetProdutosMateriais();
        ProdutoMaterial GetProdutoByMaterial(Material Material);
        ProdutoMaterial GetMaterialByProduto(Produto Produto);
        void InsertProdutoMaterial(ProdutoMaterial ProdutoMaterial);
        void DeleteProdutoMaterial(Produto Produto, Material Material);
        void UpdateProdutoMaterial(ProdutoMaterial ProdutoMaterial);
        void Save();
    }
}
