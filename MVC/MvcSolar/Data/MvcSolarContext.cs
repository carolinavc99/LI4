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

        public DbSet<MvcSolar.Models.Alerta> Alertas { get; set; }
        public DbSet<MvcSolar.Models.AlertasUtilizador> AlertasUtilizadores { get; set; }
        public DbSet<MvcSolar.Models.Avaria> Avarias { get; set; }
        public DbSet<MvcSolar.Models.ConsumoEnergetico> ConsumosEnergeticos { get; set; }
        public DbSet<MvcSolar.Models.Evento> Eventos { get; set; }
        public DbSet<MvcSolar.Models.Utilizador> Utilizadores { get; set; }
        public DbSet<MvcSolar.Models.Funcionario> Funcionarios { get; set; }
        public DbSet<MvcSolar.Models.Habitacao> Habitacoes { get; set; }
        public DbSet<MvcSolar.Models.Lembrete> Lembretes { get; set; }
        public DbSet<MvcSolar.Models.Localidade> Localidades { get; set; }
        public DbSet<MvcSolar.Models.Manutencao> Manutencoes { get; set; }
        public DbSet<MvcSolar.Models.Meteorologia> Meteorologias { get; set; }
        public DbSet<MvcSolar.Models.Painel> Paineis { get; set; }
        public DbSet<MvcSolar.Models.ProducaoEnergetica> ProducoesEnergeticas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Alerta>().ToTable("Alerta");
            modelBuilder.Entity<AlertasUtilizador>().ToTable("AlertasUtilizador");
            modelBuilder.Entity<Avaria>().ToTable("Avaria");
            modelBuilder.Entity<ConsumoEnergetico>().ToTable("Consumo Energético");
            modelBuilder.Entity<Evento>().ToTable("Evento");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionário");
            modelBuilder.Entity<Habitacao>().ToTable("Habitação");
            modelBuilder.Entity<Lembrete>().ToTable("Lembrete");
            modelBuilder.Entity<Localidade>().ToTable("Localidade");
            modelBuilder.Entity<Manutencao>().ToTable("Manutenção");
            modelBuilder.Entity<Meteorologia>().ToTable("Meteorologia");
            modelBuilder.Entity<Painel>().ToTable("Painel");
            modelBuilder.Entity<Utilizador>().ToTable("Utilizador");
            modelBuilder.Entity<ProducaoEnergetica>().ToTable("Produções Energéticas");
        }
    }
}
