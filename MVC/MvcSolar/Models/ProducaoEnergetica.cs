using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class ProducaoEnergetica
    {
        // props
        public double Producao { get; set; }
        public DateTime Data { get; set; }
        public int PainelID { get; set; }

        // nav props
        public Painel Painel { get; set; }
    }
}
