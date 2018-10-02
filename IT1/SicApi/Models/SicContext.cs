using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SicApi.Models
{
    public class SicContext : DbContext
    {
        public SicContext(DbContextOptions<SicContext> options)
            : base(options)
        { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}