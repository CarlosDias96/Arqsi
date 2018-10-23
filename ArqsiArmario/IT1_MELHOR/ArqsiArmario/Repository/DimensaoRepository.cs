using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class DimensaoRepository : IDimensaoRepository, IDisposable
    {
        private ArqsiContext context;

        public DimensaoRepository(ArqsiContext context)
        {
            this.context = context;
        }

        public void DeleteDimensao(int Dimensao)
        {
            Dimensao dim = context.Dimensoes.Find(Dimensao);
            context.Dimensoes.Remove(dim);
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

        public IEnumerable<Dimensao> GetDimensao()
        {
            return context.Dimensoes;
        }

        public Dimensao GetDimensoesByID(int DimensaoId)
        {


            return context.Dimensoes.Find(DimensaoId);
        }
        public Dimensao GetDimensoesByID(int? DimensaoId)
        {
            

            return context.Dimensoes.Find(DimensaoId);
        }

        public void InsertDimensao(Dimensao Dimensao)
        {
            context.Dimensoes.Add(Dimensao);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateDimensao(Dimensao Dimensao)
        {
            context.Entry(Dimensao).State = EntityState.Modified;
        }
    }
}
