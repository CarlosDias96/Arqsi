﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArqsiArmario.Models
{
    public class ArqsiContext : DbContext
    {
        public ArqsiContext(DbContextOptions<ArqsiContext> options)
          : base(options)
        {
        }

        public DbSet<Acabamento> Acabamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dimensao> Dimensoes { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}

