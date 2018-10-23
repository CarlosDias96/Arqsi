using System;
using System.Collections.Generic;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface IAcabamentoRepository : IDisposable
    {
        IEnumerable<Acabamento> GetAcabamentos();
        Acabamento GetAcabamentoByID(int AcabamentoId);
        void InsertAcabamento(Acabamento Acabamento);
        void DeleteAcabamento(int Acabamento);
        void UpdateAcabamento(Acabamento Acabamento);
        void Save();
    }
}
