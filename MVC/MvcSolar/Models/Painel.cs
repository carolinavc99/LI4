using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Painel
    {
        public int ID { get; set; }
        public double ProducaoPrevistaHora { get; set; }
        public string Marca { get; set; }
        public int Estado { get; set; } // 0-Ligado, 1-Desligado, 2-Avariado

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public List<ProducaoEnergetica> Producoes { get; set; }
    }
}
