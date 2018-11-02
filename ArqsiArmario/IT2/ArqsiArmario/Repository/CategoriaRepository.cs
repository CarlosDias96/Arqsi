using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class CategoriaRepository : ICategoriaRepository, IDisposable
    {

        private ArqsiContext context;

        public CategoriaRepository(ArqsiContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteCategoria(int Categoriaid)
        {
            Categoria cat = context.Categorias.Find(Categoriaid);
             context.Categorias.Remove(cat);
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


        public Categoria GetCategoriaByID(int CategoriaId)
        {
            return context.Categorias.Find(CategoriaId);
        }

        public Categoria GetCategoriaByID(int? CategoriaId)
        {
            return context.Categorias.Find(CategoriaId);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return context.Categorias;
        }

        public void InsertCategoria(Categoria Categoria)
        {
             context.Categorias.Add(Categoria);
             
        }

        public void Save()
        {
            context.SaveChanges();

        }

        public void UpdateCategoria(Categoria Categoria)
        {
            context.Entry(Categoria).State = EntityState.Modified;
        }

    }
}
