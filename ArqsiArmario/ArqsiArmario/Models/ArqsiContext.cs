using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Models
{
    public class ArqsiContext : DbContext
    {
        public ArqsiContext(DbContextOptions<ArqsiContext> options)
          : base(options)
        {
        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialAcabamento>()
                .HasKey(bc => new { bc.MaterialId, bc.AcabamentoId });

            modelBuilder.Entity<MaterialAcabamento>()
                .HasOne(bc => bc.Material)
                .WithMany(b => b.Acabamentos)
                .HasForeignKey(bc => bc.MaterialId);

            modelBuilder.Entity<MaterialAcabamento>()
                .HasOne(bc => bc.Acabamento)
                .WithMany(c => c.Materiais)
                .HasForeignKey(bc => bc.AcabamentoId);
        }*/
        public DbSet<AcabamentoDto> Acabamentos { get; set; }
        public DbSet<CategoriaDto> Categorias { get; set; }
        public DbSet<DimensaoDto> Dimensoes { get; set; }
        public DbSet<MaterialDto> Materiais { get; set; }
        public DbSet<DTOs.ProdutoDto> Produtos { get; set; }
        

    }
}


