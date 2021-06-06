using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Habitacao
    {
        // props
        public int HabitacaoID { get; set; }
        public double Bateria { get; set; }
        public double Capacidade { get; set; }
        public string Morada { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<int> PaineisID { get; set; }
        public int LocalidadeID { get; set; }

        public Dictionary<DateTime,int> ConsumosID { get; set; }


        // nav props
        public Painel Paineis { get; set; }
        public Localidade Localidade { get; set; }

        //public Dictionary<DateTime,ConsumoEnergetico> Consumos { get; set; }
        public ConsumoEnergetico Consumo { get; set; }


    }

  
}
