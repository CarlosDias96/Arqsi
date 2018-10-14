using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class ProdutoMaterialRepository : IDisposable, IProdutoMaterialRepository
    {
        ArqsiContext context;
        public ProdutoMaterialRepository(ArqsiContext context)
        {
            this.context = context;
        }
        public void DeleteProdutoMaterial(Produto Produto, Material Material)
        {
            ProdutoMaterial pro = context.ProdutoMaterials.Find(Produto);
            ProdutoMaterial pro2 = context.ProdutoMaterials.Find(Material);
            context.ProdutoMaterials.Remove(pro);
            context.ProdutoMaterials.Remove(pro2);
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

        public ProdutoMaterial GetMaterialByProduto(Produto Produto)
        {
            ProdutoMaterial pro = context.ProdutoMaterials.Find(Produto);
            return context.ProdutoMaterials.Find(pro);
        }

        public ProdutoMaterial GetProdutoByMaterial(Material Material)
        {
            ProdutoMaterial pro = context.ProdutoMaterials.Find(Material);
            return context.ProdutoMaterials.Find(pro);
        }

        public IEnumerable<ProdutoMaterial> GetProdutosMateriais()
        {
            return context.ProdutoMaterials;
        }

        public void InsertProdutoMaterial(ProdutoMaterial ProdutoMaterial)
        {
            context.ProdutoMaterials.Add(ProdutoMaterial);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateProdutoMaterial(ProdutoMaterial ProdutoMaterial)
        {
            context.Entry(ProdutoMaterial).State = EntityState.Modified;
        }
    }
}
