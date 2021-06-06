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
        public int HabitacaoID { get; set; }
        public double ProducaoPrevistaHora { get; set; }
        public string Modelo { get; set; }
        public Estado Estado { get; set; }

        public ICollection<ProducaoEnergetica> ProducoesID { get; set; }

        // nav props
        public Habitacao Habitacao { get; set; }

    }
}
