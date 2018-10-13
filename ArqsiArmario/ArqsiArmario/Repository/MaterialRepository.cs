using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Repository
{
    public class MaterialRepository : IMaterialRepository, IDisposable
    {


        private ArqsiContext context;

        public MaterialRepository(ArqsiContext context)
        {
            this.context = context;
        }

        public void DeleteMaterial(int Materialid)
        {
            Material mat = context.Materiais.Find(Materialid);
            context.Materiais.Remove(mat);
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

        public IEnumerable<Material> GetMateriais()
        {
            return context.Materiais;
        }

        public Material GetMaterialByID(int MaterialId)
        {
            return context.Materiais.Find(MaterialId);
        }

        public Material GetMaterialByID(int? MaterialId)
        {
            return context.Materiais.Find(MaterialId);
        }
        public void InsertMaterial(Material Material)
        {
            context.Materiais.Add(Material);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMaterial(Material Material)
        {
            context.Entry(Material).State = EntityState.Modified;
        }
    }
}
