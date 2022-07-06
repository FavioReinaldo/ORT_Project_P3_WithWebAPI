using Microsoft.EntityFrameworkCore;
using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EF
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Plaza> Plazas { get; set; }
        public DbSet<Importacion> Importaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer
                (@"data source = FR; database=Obligatorio2P3_Test; integrated security = true");

        }

        public LibreriaContext()
        {

        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {

        }


    }
}
