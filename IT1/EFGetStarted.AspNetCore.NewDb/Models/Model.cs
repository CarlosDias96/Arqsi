using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace  EFGetStarted.AspNetCore.NewDb.Models
{
    public class ArqsiContext : DbContext
    {
        public ArqsiContext(DbContextOptions<ArqsiContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<DimensaoContinua>();
            builder.Entity<DimensaoDiscreta>();

            base.OnModelCreating(builder);
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Acabamento> Acabamento { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Dimensao> Dimensoes { get; set; }
    }

   
}