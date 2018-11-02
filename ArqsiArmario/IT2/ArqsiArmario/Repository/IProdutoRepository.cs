using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface IProdutoRepository : IDisposable
    {
        IEnumerable<Produto> GetProdutos();
        Produto GetProdutoByID(int ProdutoId);
        IQueryable<Produto> GetProdutoByNome(string Nome);
        void InsertProduto(Produto Produto);
        void DeleteProduto(int Produto);
        void UpdateProduto(Produto Produto);
        void Save();
    }
}
