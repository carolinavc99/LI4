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
        public string Morada { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Bateria { get; set; }
        public double Capacidade { get; set; }

        public ICollection<Painel> Paineis { get; set; }
        public int LocalidadeID { get; set; }

        public ICollection<ConsumoEnergetico> Consumos { get; set; }


        // nav props
        public Localidade Localidade { get; set; }

    }

  
}
