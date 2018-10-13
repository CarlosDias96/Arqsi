using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.Models;

namespace ArqsiArmario.Repository
{
    interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();
        Categoria GetCategoriaByID(int CategoriaId);
        void InsertCategoria(Categoria Categoria);
        void DeleteCategoria(int Categoria);
        void UpdateCategoria(Categoria Categoria);
        void Save();
    }
}
