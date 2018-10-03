using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace  EFGetStarted.AspNetCore.NewDb.Models
{
    public class ArqsiContext : DbContext
    {
        public ArqsiContext(DbContextOptions<ArqsiContext> options)
            : base(options)
        { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }

   
}