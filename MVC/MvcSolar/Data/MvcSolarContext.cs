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
            /* 
             Algumas destas tabelas podem ser excluídas - o EF cria tabelas para todas as entidades que são referenciadas
             ou seja iincluir só o utilizador o EF ia gerar Habitação também porque o utilizador precisa dela 
            */

            modelBuilder.Entity<Alerta>().ToTable("Alertas");
            modelBuilder.Entity<ConsumoEnergetico>().ToTable("Consumos Energéticos");
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionários");
            modelBuilder.Entity<Habitacao>().ToTable("Habitações");
            modelBuilder.Entity<Lembrete>().ToTable("Lembretes");
            modelBuilder.Entity<Localidade>().ToTable("Localidades");
            modelBuilder.Entity<Manutencao>().ToTable("Manutenções");
            modelBuilder.Entity<Meteorologia>().ToTable("Meteorologia");
            modelBuilder.Entity<Painel>().ToTable("Painéis");
            modelBuilder.Entity<Utilizador>().ToTable("Utilizadores");
        }
    }
}
