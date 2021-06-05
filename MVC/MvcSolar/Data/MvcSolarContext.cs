using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSolar.Models;

namespace MvcSolar.Data
{
    public class MvcSolarContext : DbContext
    {
        public MvcSolarContext (DbContextOptions<MvcSolarContext> options) : base(options)
        {

        }

        public DbSet<MvcSolar.Models.Evento> Evento { get; set; }

        public DbSet<MvcSolar.Models.Utilizador> Utilizador { get; set; }

        public DbSet<MvcSolar.Models.Painel> Painel { get; set; }

        public DbSet<MvcSolar.Models.Habitacao> Habitacao { get; set; }

        public DbSet<MvcSolar.Models.Localidade> Localidade { get; set; }

        public DbSet<MvcSolar.Models.Meteorologia> Meteorologia { get; set; }

        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("Evento");
            modelBuilder.Entity<Habitacao>().ToTable("Habitação");
            modelBuilder.Entity<Localidade>().ToTable("Localidade");
            modelBuilder.Entity<Meteorologia>().ToTable("Meteorologia");
            modelBuilder.Entity<Painel>().ToTable("Painel");
            modelBuilder.Entity<Utilizador>().ToTable("Utilizador");
        }
    }
}
