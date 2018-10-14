using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface IMaterialRepository : IDisposable
    {

        IEnumerable<Material> GetMateriais();
        Material GetMaterialByID(int MaterialId);
        void InsertMaterial(Material Material);
        void DeleteMaterial(int Material);
        void UpdateMaterial(Material Material);
        void Save();

    }
}
