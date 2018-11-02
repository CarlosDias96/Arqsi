using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class ProdutoRepository : IProdutoRepository, IDisposable
    {
        private ArqsiContext context;

        public ProdutoRepository(ArqsiContext context)
        {
            this.context = context;
        }

        public void DeleteProduto(int Produtoid)
        {
            Produto pro = context.Produtos.Find(Produtoid);
            context.Produtos.Remove(pro);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Produto GetProdutoByID(int ProdutoId)
        {
            
            return context.Produtos.Find(ProdutoId);
        }
        public IQueryable<Produto> GetProdutoByNome(string Nome)
        {
               var produto= context.Produtos.Include(p => p.Categoria).Include(p => p.ProdutosMateriais).Include(p => p.Produtos).Where(p => p.Nome.Equals(Nome, StringComparison.InvariantCultureIgnoreCase));
            return produto;
        }
        public IEnumerable<Produto> GetProdutos()
        {
            return context.Produtos;
        }

        public void InsertProduto(Produto Produto)
        {
            context.Produtos.Add(Produto);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateProduto(Produto Produto)
        {
            context.Entry(Produto).State = EntityState.Modified;
        }
    }
}
