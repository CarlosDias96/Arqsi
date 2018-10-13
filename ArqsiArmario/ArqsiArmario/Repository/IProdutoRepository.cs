using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    interface IProdutoRepository
    {
        IEnumerable<Produto> GetProdutos();
        Produto GetProdutoByID(int ProdutoId);
        void InsertProduto(Produto Produto);
        void DeleteProduto(int Produto);
        void UpdateProduto(Produto Produto);
        void Save();
    }
}
