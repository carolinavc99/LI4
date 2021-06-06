using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Painel
    {
        // pops
        public int PainelID { get; set; }
        public double ProducaoPrevistaHora { get; set; }
        public string Marca { get; set; }
        public Estado Estado { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public Dictionary<DateTime,int> ProducoesID { get; set; }

        // nav props
        public ProducaoEnergetica Producoes { get; set; }

    }
}
