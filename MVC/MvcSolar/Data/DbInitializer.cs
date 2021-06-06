using MvcSolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcSolar.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MvcSolarContext context)
        {
            context.Database.EnsureCreated();

            /*
             * PAINÉIS
            */
            if (context.Painel.Any())
            {
                return;   // DB has been seeded
            }

            var paineis = new Painel[]
            {
            new Painel{PainelID=0,ProducaoPrevistaHora=2.0,Marca="PSolares",Estado=Estado.Ligado,Data=DateTime.Parse("08/18/2018"),
                ProducoesID=new Dictionary<DateTime, int>() { 
                        { DateTime.Parse("08/18/2018"), 1}}
            }
            };
            foreach (Painel p in paineis)
            {
                context.Painel.Add(p);
            }
            context.SaveChanges();

            /*
             * HABITAÇÕES
             */
            if (context.Habitacao.Any())
            {
                return;   // DB has been seeded
            }

            var habits = new Habitacao[]
            {
            new Habitacao{HabitacaoID=1,Bateria=10.0,Capacidade=10.0,Morada="morada1",Latitude=1.0,Longitude=1.0,PaineisID=new List<int>(paineis[0].PainelID),LocalidadeID=1}
            };
            foreach (Habitacao h in habits)
            {
                context.Habitacao.Add(h);
            }
            context.SaveChanges();

            // LOCALIDADES
            var locs = new Localidade[]
            {
            new Localidade{LocalidadeID=1,Latitude=1.0,Longitude=1.0,Nome="localidade1",Distrito="distrito1",Concelho="concelho1",
                MeteorologiasID=new Dictionary<DateTime, int>()
                {
                    {DateTime.Parse("08/18/2018"), 1}
                }
            };
            foreach (Localidade l in locs)
            {
                context.Localidade.Add(l);
            }
            context.SaveChanges();

        }
    }