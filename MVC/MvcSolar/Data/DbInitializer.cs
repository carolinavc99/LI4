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
             * Alerta x
             * Localidade x
             * Meteorologia x
             * Utilizador x
             * Evento x
             * Funcionario x
             * Lembrete x
             * AlertasUtilizador x
             * Manutencao x
             * Habitacao x
             * Painel x
             * ProducaoEnergetia x
             * ConsumoEnergetico x
             * Avaria x
            */

       

            // ALERTAS
            if (context.Alertas.Any())
            {
                return;
            }
            var alertas = new Alerta[]
            {
                new Alerta{DataHora=DateTime.Parse("01/01/01"),Descricao="desc1",Sugestoes="sugs1",Tipo=Tipo.Tempestade}
            };
            foreach (Alerta a in alertas)
            {
                context.Alertas.Add(a);
            }
            context.SaveChanges();

             //Localidades
            if (context.Localidades.Any())
            {
                return;
            }
            var localidades = new Localidade[]
            {
                new Localidade{Latitude=10,Longitude=10,Nome="Gualtar",Distrito="Braga",Concelho="Braga"}
            };
            foreach ( Localidade l in localidades)
            {
                context.Localidades.Add(l);
            }
            context.SaveChanges();

            
            // METEOROLOGIA
            if (context.Meteorologias.Any())
            {
                return;
            }
            var meteorologias = new Meteorologia[]
            {
                new Meteorologia{WeatherType="weathertype1",SkyCondition="skycond1",ProbPrecipitacao=8.0,Sunrise=DateTime.Parse("01/01/2001")}
            };
            foreach (Meteorologia m in meteorologias)
            {
                context.Meteorologias.Add(m);
            }
            context.SaveChanges();

            //utilizador
            if (context.Utilizadores.Any())
            {
                return;
            }
            var utilizadores = new Utilizador[]
            {
                new Utilizador{Email="email@gmail.com",Nome="Alexandre Silva",Password="passwordfixolas",LastTimeOnline=DateTime.Parse("01/04/2021"),Username="alexandresilva"}

            };

            foreach (Utilizador m in utilizadores)
            {
                context.Utilizadores.Add(m);
            }
            context.SaveChanges();

            //evento
            if (context.Eventos.Any())
            {
                return;
            }
            var eventos = new Evento[]
            {
                new Evento{Data=DateTime.Parse("18/04/2000"),DataFinal=DateTime.Parse("21/04/2000"),}
            };
            foreach (Evento e in eventos)
            {
                context.Eventos.Add(e);
            }
            context.SaveChanges();


            //Funcionario

            if (context.Funcionarios.Any())
            {
                return;
            }
            var funcionarios = new Funcionario[]
            {
                new Funcionario{Username="Anibal"}
            };
            foreach (Funcionario e in funcionarios)
            {
                context.Funcionarios.Add(e);
            }
            context.SaveChanges();

            //LEMBRETE
            if (context.Lembretes.Any())
            {
                return;
            }
            var lembretes = new Lembrete[]
            {
                new Lembrete{dataHora=DateTime.Parse("01/01/2000"),EventoID=1,UtilizadorID=1}
            };
            foreach (Lembrete l in lembretes)
            {
                context.Lembretes.Add(l);
            }
            context.SaveChanges();

            //Alertas Utilizador
            if (context.AlertasUtilizadores.Any())
            {
                return;
            }
            var alertasUtilizador = new AlertasUtilizador[]
            {
                new AlertasUtilizador{Tipo=Tipo.Manutencao,AlertasUtilizadorID=1}
            };
            foreach (AlertasUtilizador e in alertasUtilizador)
            {
                context.AlertasUtilizadores.Add(e);
            }
            context.SaveChanges();


           //Manutencoes
            if (context.Manutencoes.Any())
            {
                return;
            }
            var manutencoes = new Manutencao[]
            {
                new Manutencao{FuncionarioID=1,HabitacaoID=1,Data=DateTime.Parse("11/11/2011")}
            };
            foreach (Manutencao m in manutencoes)
            {
                context.Manutencoes.Add(m);
            }
            context.SaveChanges();

            // Habitacao

            if (context.Habitacoes.Any())
            {
                return;
            }

            var habitacoes = new Habitacao[]
            {
                new Habitacao{Morada = "Rua do Alecrim",Latitude =0.00,Longitude=0.00,Bateria = 50.0, Capacidade = 100.0, LocalidadeID = 1  }
            };
            foreach(Habitacao e in habitacoes)
            {
                context.Habitacoes.Add(e);
            }
            context.SaveChanges();
        
            
        
            // Painel
            if (context.Paineis.Any())
            {
                return;
            }
            var paineis = new Painel[]
            {
                new Painel{HabitacaoID=1,ProducaoPrevistaHora=2.0,Modelo="modelo1",Estado=Estado.Ligado}
            };
            foreach (Painel p in paineis)
            {
                context.Paineis.Add(p);
            }
            context.SaveChanges();
            
            // Producao Energetica
            if (context.ProducoesEnergeticas.Any())
            {
                return;
            }
            var producoesenergeticas = new ProducaoEnergetica[]
            {
                new ProducaoEnergetica {Producao=2.0,Data=DateTime.Parse("01/01/2000"),PainelID=1}
            };
            foreach (ProducaoEnergetica p in producoesenergeticas)
            {
                context.ProducoesEnergeticas.Add(p);
            }
            context.SaveChanges();

            // Consumo Energetico
            if (context.ConsumosEnergeticos.Any())
            {
                return;
            }
            var consumosenergeticos = new ConsumoEnergetico[]
            {
                new ConsumoEnergetico {Consumo=2.0,Data=DateTime.Parse("01/01/2000"),HabitacaoID=1}
            };
            foreach (ConsumoEnergetico c in consumosenergeticos)
            {
                context.ConsumosEnergeticos.Add(c);
            }
            context.SaveChanges();


            //Avaria

            if (context.Avarias.Any())
            {
                return;
            }
            var avarias = new Avaria[]
            {
                new Avaria{HabitacaoID = 1,Data =DateTime.Parse("01/01/2000")}
            };
            foreach( Avaria a in avarias){
                context.Avarias.Add(a);
            }
            context.SaveChanges();
        }
    }
}