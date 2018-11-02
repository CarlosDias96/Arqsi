using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class AcabamentoRepository : IAcabamentoRepository, IDisposable
    {
        private ArqsiContext context;

        public AcabamentoRepository(ArqsiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Acabamento> GetAcabamentos()
        {
            return context.Acabamentos.ToList();
        }

        public Acabamento GetAcabamentoByID(int id)
        {
            return context.Acabamentos.Find(id);
        }

        public void InsertAcabamento(Acabamento Acabamento)
        {
            context.Acabamentos.Add(Acabamento);
        }

        public void DeleteAcabamento(int AcabamentoID)
        {
            Acabamento Acabamento = context.Acabamentos.Find(AcabamentoID);
            context.Acabamentos.Remove(Acabamento);
        }

        public void UpdateAcabamento(Acabamento Acabamento)
        {
            context.Entry(Acabamento).State = EntityState.Modified;
            context.Update(Acabamento);
        }

        public void Save()
        {
            context.SaveChanges();
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

  

    }
}
