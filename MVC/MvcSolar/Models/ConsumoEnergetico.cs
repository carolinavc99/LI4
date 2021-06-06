using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class ConsumoEnergetico
    {
        // props
        public int ConsumoEnergeticoID { get; set; }
        public double Consumo { get; set; }
        public DateTime Data { get; set; }
        public int HabitacaoID { get; set; }

        // nav props
        public Habitacao Habitacao { get; set; }
    }
}
