using System;
using System.Collections.Generic;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    public interface ICategoriaRepository : IDisposable
    {
        IEnumerable<Categoria> GetCategorias();
        Categoria GetCategoriaByID(int CategoriaId);
        void InsertCategoria(Categoria Categoria);
        void DeleteCategoria(int Categoria);
        void UpdateCategoria(Categoria Categoria);
        void Save();
    }
}
