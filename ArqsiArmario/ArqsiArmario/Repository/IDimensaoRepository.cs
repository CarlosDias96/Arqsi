using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface IDimensaoRepository : IDisposable
    {
        IEnumerable<Dimensao> GetDimensao();
        Dimensao GetDimensoesByID(int DimensaoId);
        void InsertDimensao(Dimensao Dimensao);
        void DeleteDimensao(int Dimensao);
        void UpdateDimensao(Dimensao Dimensao);
        void Save();
    }
}
