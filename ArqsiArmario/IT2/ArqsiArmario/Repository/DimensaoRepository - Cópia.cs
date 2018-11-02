using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class DimensaoDCRepository : IDimensaoDCRepository, IDisposable
    {
        private ArqsiContext context;

        public DimensaoDCRepository(ArqsiContext context)
        {
            this.context = context;
        }

        public void DeleteDimensao(int Dimensao)
        {
            DimensaoDC dim = context.DimensoesDC.Find(Dimensao);
            context.DimensoesDC.Remove(dim);
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

        public IEnumerable<DimensaoDC> GetDimensao()
        {
            return context.DimensoesDC;
        }

        public DimensaoDC GetDimensoesByID(int DimensaoId)
        {
            Dimensao dim = context.Dimensoes.Find(DimensaoId);

            return context.DimensoesDC.Find(dim);
        }
        public DimensaoDC GetDimensoesByID(int? DimensaoId)
        {
            DimensaoDC dim = context.DimensoesDC.Find(DimensaoId);

            return context.DimensoesDC.Find(dim);
        }

        public void InsertDimensao(DimensaoDC Dimensao)
        {
            context.DimensoesDC.Add(Dimensao);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateDimensao(DimensaoDC Dimensao)
        {
            context.Entry(Dimensao).State = EntityState.Modified;
        }
    }
}
