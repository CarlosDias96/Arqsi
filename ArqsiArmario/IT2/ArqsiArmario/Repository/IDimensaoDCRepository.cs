using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface IDimensaoDCRepository : IDisposable
    {
        IEnumerable<DimensaoDC> GetDimensao();
        DimensaoDC GetDimensoesByID(int DimensaoId);
        DimensaoDC GetDimensoesByID(int? DimensaoId);
        void InsertDimensao(DimensaoDC Dimensao);
        void DeleteDimensao(int Dimensao);
        void UpdateDimensao(DimensaoDC Dimensao);
        void Save();
    }
}
