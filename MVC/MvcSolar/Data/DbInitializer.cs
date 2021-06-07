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

            // ALERTAS
            if (context.Alertas.Any())
            {
                return;
            }
            var alertas = new Alerta[]
            {
                new Alerta{DataHora=DateTime.Parse("01/01/2001"),Descricao="desc1",Sugestoes="sugs1",Tipo=Tipo.Tempestade},
		        new Alerta{DataHora=DateTime.Parse("02/01/2001"),Descricao="desc2",Sugestoes="sugs2",Tipo=Tipo.Workshop},
		        new Alerta{DataHora=DateTime.Parse("03/01/2001"),Descricao="desc3",Sugestoes="sugs3",Tipo=Tipo.QuebraProducao},
		        new Alerta{DataHora=DateTime.Parse("04/01/2001"),Descricao="desc4",Sugestoes="sugs4",Tipo=Tipo.Manutencao},
		        new Alerta{DataHora=DateTime.Parse("05/01/2001"),Descricao="desc5",Sugestoes="sugs5",Tipo=Tipo.Workshop},
		        new Alerta{DataHora=DateTime.Parse("06/01/2001"),Descricao="desc6",Sugestoes="sugs6",Tipo=Tipo.Tempestade},
		        new Alerta{DataHora=DateTime.Parse("07/01/2001"),Descricao="desc7",Sugestoes="sugs7",Tipo=Tipo.Tempestade}
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
                new Localidade{Latitude=10,Longitude=10,Nome="Gualtar",Distrito="Braga",Concelho="Braga"},
		        new Localidade{Latitude=11,Longitude=11,Nome="Ribeira",Distrito="Viana do Castelo",Concelho="Ponte de Lima"},
		        new Localidade{Latitude=12,Longitude=12,Nome="Feitosa",Distrito="Viana do Castelo",Concelho="Ponte de Lima"},
		        new Localidade{Latitude=13,Longitude=13,Nome="Porto",Distrito="Porto",Concelho="Porto"},
		        new Localidade{Latitude=14,Longitude=14,Nome="Lamaçães",Distrito="Braga",Concelho="Braga"},
		        new Localidade{Latitude=15,Longitude=15,Nome="Sameiro",Distrito="Braga",Concelho="Braga"}
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
                new Meteorologia{WeatherType="weathertype1",SkyCondition="skycond1",ProbPrecipitacao=8.0,Sunrise=DateTime.Parse("01-01-2001")},
		        new Meteorologia{WeatherType="weathertype2",SkyCondition="skycond2",ProbPrecipitacao=10.0,Sunrise=DateTime.Parse("01-01-2001")},
		        new Meteorologia{WeatherType="weathertype3",SkyCondition="skycond3",ProbPrecipitacao=15.0,Sunrise=DateTime.Parse("01-01-2001")},
		        new Meteorologia{WeatherType="weathertype4",SkyCondition="skycond4",ProbPrecipitacao=40.0,Sunrise=DateTime.Parse("01-01-2001")},
		        new Meteorologia{WeatherType="weathertype5",SkyCondition="skycond5",ProbPrecipitacao=0.0,Sunrise=DateTime.Parse("01-01-2001")}
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
                new Utilizador{Email="email@gmail.com",Nome="Alexandre Silva",Password="passwordfixolas",LastTimeOnline=DateTime.Parse("01/04/2021"),Username="alexandresilva"},
                new Utilizador{Email="email2@gmail.com",Nome="Fagundo Fagundes",Password="passwordfixolas123",LastTimeOnline=DateTime.Parse("01/04/2021"),Username="fagundo"},
                new Utilizador{Email="email3@gmail.com",Nome="Joaquim",Password="passwordfixolas14234",LastTimeOnline=DateTime.Parse("01/04/2021"),Username="quim"},
                new Utilizador{Email="email4@gmail.com",Nome="Felisberta",Password="passwordfixolasasdas",LastTimeOnline=DateTime.Parse("01/04/2021"),Username="berta"},
                new Utilizador{Email="email5@gmail.com",Nome="Felismina",Password="passwordfixolas423qwe",LastTimeOnline=DateTime.Parse("01/04/2021"),Username="mina"}

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
                new Evento{Data=DateTime.Parse("18/04/2000"),DataFinal=DateTime.Parse("21/04/2000"),Nome="evento1",Descricao="Evento1"},
                new Evento{Data=DateTime.Parse("19/04/2000"),DataFinal=DateTime.Parse("21/04/2000"),Nome="evento2",Descricao="Evento2"},
                new Evento{Data=DateTime.Parse("20/04/2000"),DataFinal=DateTime.Parse("21/04/2000"),Nome="evento3",Descricao="Evento3"},
                new Evento{Data=DateTime.Parse("21/04/2000"),DataFinal=DateTime.Parse("21/04/2000"),Nome="evento4",Descricao="Evento4"},
                new Evento{Data=DateTime.Parse("22/04/2000"),DataFinal=DateTime.Parse("21/04/2000"),Nome="evento5",Descricao="Evento5"}
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
                new Funcionario{Username="Anibal",Email="func1@gmail.com",Nome="Funcionario1",Password="pass1",LastTimeOnline=DateTime.Parse("01/01/1984")},
                new Funcionario{Username="Cândido",Email="func2@gmail.com",Nome="Funcionario2",Password="pass2",LastTimeOnline=DateTime.Parse("01/01/1984")},
                new Funcionario{Username="Generosa",Email="func3@gmail.com",Nome="Funcionario3",Password="pass3",LastTimeOnline=DateTime.Parse("01/01/1984")},
                new Funcionario{Username="Manela",Email="func4@gmail.com",Nome="Funcionario4",Password="pass4",LastTimeOnline=DateTime.Parse("01/01/1984")}
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
                new Lembrete{dataHora=DateTime.Parse("01/01/2000"),EventoID=1,UtilizadorID=1},
                new Lembrete{dataHora=DateTime.Parse("01/01/2000"),EventoID=2,UtilizadorID=2},
                new Lembrete{dataHora=DateTime.Parse("01/01/2000"),EventoID=3,UtilizadorID=3},
                new Lembrete{dataHora=DateTime.Parse("01/01/2000"),EventoID=4,UtilizadorID=4}
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
                new AlertasUtilizador{Tipo=Tipo.Tempestade,UtilizadorID=1},
                new AlertasUtilizador{Tipo=Tipo.Workshop,UtilizadorID=2},
                new AlertasUtilizador{Tipo=Tipo.QuebraProducao,UtilizadorID=3},
                new AlertasUtilizador{Tipo=Tipo.Manutencao,UtilizadorID=4}
            };
            foreach (AlertasUtilizador e in alertasUtilizador)
            {
                context.AlertasUtilizadores.Add(e);
            }
            context.SaveChanges();

            // Habitacao

            if (context.Habitacoes.Any())
            {
                return;
            }
            var habitacoes = new Habitacao[]
            {
                new Habitacao { Morada = "Rua do Alecrim",Latitude =0.00,Longitude=0.00,Bateria = 50.0, Capacidade = 100.0, LocalidadeID = 1  },
                new Habitacao { Morada = "Rua do Ferragial",Latitude =1.00,Longitude=1.00,Bateria = 50.0, Capacidade = 100.0, LocalidadeID = 2  },
                new Habitacao { Morada = "Rua Marechal Saldanha",Latitude =2.00,Longitude=2.00,Bateria = 50.0, Capacidade = 100.0, LocalidadeID = 3  },
                new Habitacao { Morada = "Rua do Ataíde",Latitude =3.00,Longitude=3.00,Bateria = 50.0, Capacidade = 100.0, LocalidadeID = 4  },
                new Habitacao { Morada = "Rua do Zé",Latitude =4.00,Longitude=4.00,Bateria = 50.0, Capacidade = 100.0, LocalidadeID = 5  },
                new Habitacao { Morada= "9 Scott Road",Latitude=45.85,Longitude=40.12,Bateria=8.57,Capacidade=5.45,LocalidadeID=2},
                new Habitacao { Morada= "10662 Larry Center",Latitude=57.58,Longitude=-3.88,Bateria=8.12,Capacidade=6.16,LocalidadeID=4},
                new Habitacao { Morada= "069 Hauk Way",Latitude=10.76,Longitude=-74.75,Bateria=8.82,Capacidade=8.0,LocalidadeID=1},
                new Habitacao { Morada = "46 Hagan Circle", Latitude = -34.54, Longitude = -58.52, Bateria = 7.39, Capacidade = 6.92, LocalidadeID = 2},
                new Habitacao { Morada = "5 Hooker Place", Latitude = 51.20, Longitude = 24.69, Bateria = 9.37, Capacidade = 9.62, LocalidadeID = 4},
                new Habitacao { Morada = "9 Sheridan Street", Latitude = 14.27, Longitude = -87.65, Bateria = 7.89, Capacidade = 8.38, LocalidadeID = 2},
                new Habitacao { Morada = "3 Havey Place", Latitude = 59.37, Longitude = 28.17, Bateria = 6.1, Capacidade = 6.47, LocalidadeID = 3},
                new Habitacao { Morada = "75185 Center Alley", Latitude = -7.63, Longitude = 110.35, Bateria = 7.21, Capacidade = 6.97, LocalidadeID = 2},
                new Habitacao { Morada = "2277 Sunfield Trail", Latitude = 18.11, Longitude = 120.69, Bateria = 8.0, Capacidade = 6.99, LocalidadeID = 5},
                new Habitacao { Morada = "8 Dapin Road", Latitude = 44.98, Longitude = 20.15, Bateria = 8.12, Capacidade = 7.93, LocalidadeID = 5},
                new Habitacao { Morada = "701 School Terrace", Latitude = 23.08, Longitude = 114.38, Bateria = 5.49, Capacidade = 7.76, LocalidadeID = 3},
                new Habitacao { Morada = "4 Pankratz Trail", Latitude = 47.69, Longitude = 31.27, Bateria = 8.26, Capacidade = 8.18, LocalidadeID = 4},
                new Habitacao { Morada = "63009 Pine View Lane", Latitude=36.09, Longitude = 140.11, Bateria = 6.21, Capacidade = 6.6, LocalidadeID = 5},
                new Habitacao { Morada = "0 Barby Junction", Latitude = 37.14, Longitude = 9.78, Bateria = 9.37, Capacidade = 8.67, LocalidadeID = 2},
                new Habitacao { Morada = "2 Leroy Court", Latitude = 41.99, Longitude = 21.34, Bateria = 7.88, Capacidade = 9.96, LocalidadeID = 4},
                new Habitacao { Morada = "2950 Lien Pass", Latitude = 9.87, Longitude = -84.08, Bateria = 8.22, Capacidade = 7.87, LocalidadeID = 5},
                new Habitacao { Morada = "33079 4th Road", Latitude = 34.32, Longitude = 108.11, Bateria = 9.65, Capacidade = 7.11, LocalidadeID = 5}
            };
            foreach (Habitacao e in habitacoes)
            {
                context.Habitacoes.Add(e);
            }
            context.SaveChanges();

            //Manutencoes
            if (context.Manutencoes.Any())
            {
                return;
            }
            var manutencoes = new Manutencao[]
            {
                new Manutencao{FuncionarioID=6,HabitacaoID=1,Data=DateTime.Parse("11/11/2011")},
                new Manutencao{FuncionarioID=7,HabitacaoID=2,Data=DateTime.Parse("11/11/2011")},
                new Manutencao{FuncionarioID=8,HabitacaoID=3,Data=DateTime.Parse("11/11/2011")},
                new Manutencao{FuncionarioID=9,HabitacaoID=4,Data=DateTime.Parse("11/11/2011")}
            };
            foreach (Manutencao m in manutencoes)
            {
                context.Manutencoes.Add(m);
            }
            context.SaveChanges();
        
            
        
            // Painel
            if (context.Paineis.Any())
            {
                return;
            }
            var paineis = new Painel[]
            {
                new Painel{HabitacaoID=1,ProducaoPrevistaHora=2.0,Modelo="modelo1",Estado=Estado.Ligado},
                new Painel{HabitacaoID=2,ProducaoPrevistaHora=2.0,Modelo="modelo2",Estado=Estado.Desligado},
                new Painel{HabitacaoID=3,ProducaoPrevistaHora=2.0,Modelo="modelo3",Estado=Estado.Avariado},
                new Painel{HabitacaoID=4,ProducaoPrevistaHora=2.0,Modelo="modelo4",Estado=Estado.Ligado},
                new Painel{HabitacaoID=5,ProducaoPrevistaHora=2.0,Modelo="modelo5",Estado=Estado.Avariado}
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
                new ProducaoEnergetica {Producao=2.0,Data=DateTime.Parse("01/01/2000"),PainelID=1},
                new ProducaoEnergetica {Producao=2.0,Data=DateTime.Parse("01/01/2000"),PainelID=2},
                new ProducaoEnergetica {Producao=2.0,Data=DateTime.Parse("01/01/2000"),PainelID=3},
                new ProducaoEnergetica {Producao=2.0,Data=DateTime.Parse("01/01/2000"),PainelID=4},
                new ProducaoEnergetica {Producao=2.0,Data=DateTime.Parse("01/01/2000"),PainelID=5}
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
                new ConsumoEnergetico {Consumo=2.0,Data=DateTime.Parse("01/01/2000"),HabitacaoID=1},
                new ConsumoEnergetico {Consumo=2.0,Data=DateTime.Parse("01/01/2000"),HabitacaoID=2},
                new ConsumoEnergetico {Consumo=2.0,Data=DateTime.Parse("01/01/2000"),HabitacaoID=3},
                new ConsumoEnergetico {Consumo=2.0,Data=DateTime.Parse("01/01/2000"),HabitacaoID=4},
                new ConsumoEnergetico {Consumo=2.0,Data=DateTime.Parse("01/01/2000"),HabitacaoID=5}
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
                new Avaria{HabitacaoID = 3,Data =DateTime.Parse("01/01/2000")},
                new Avaria{HabitacaoID = 5,Data =DateTime.Parse("01/01/2000")}
            };
            foreach( Avaria a in avarias){
                context.Avarias.Add(a);
            }
            context.SaveChanges();
        }
    }
}