using System;
using CMBData.Models;
using Microsoft.EntityFrameworkCore;

namespace CMBData
{
    public class CMBContext : DbContext
    {
        public CMBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

    }
}