using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class ProducaoEnergetica
    {
        // props
        public int ProducaoEnergeticaID { get; set; }
        public double Producao { get; set; }
        public DateTime Data { get; set; }
        public int PainelID { get; set; }

        // nav props
        public Painel Painel { get; set; }
    }
}
