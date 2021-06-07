using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSolar.Models;

namespace MvcSolar.Services
{
    public class ConsumoEnergeticosService
    {
        public static List<ConsumoEnergetico> GetConsumoEnergeticos()
        {
            var lista = new List<ConsumoEnergetico>();
            lista.Add(new ConsumoEnergetico { ConsumoEnergeticoID = 1, Consumo = 45094, HabitacaoID = 39585, Data = DateTime.Parse("01/01/2020") });
            lista.Add(new ConsumoEnergetico { ConsumoEnergeticoID = 1, Consumo = 21119, HabitacaoID = 16715, Data = DateTime.Parse("01/01/2020") });
            lista.Add(new ConsumoEnergetico { ConsumoEnergeticoID = 1, Consumo = 16718, HabitacaoID = 15464, Data = DateTime.Parse("01/01/2020") });
            lista.Add(new ConsumoEnergetico { ConsumoEnergeticoID = 1, Consumo = 15344, HabitacaoID = 10120, Data = DateTime.Parse("01/01/2020") });
            lista.Add(new ConsumoEnergetico { ConsumoEnergeticoID = 1, Consumo = 11320, HabitacaoID = 8912, Data = DateTime.Parse("01/01/2020") });
            return lista;
        }
    }
}
