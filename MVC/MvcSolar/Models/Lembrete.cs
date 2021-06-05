using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Lembrete
    {
        [DataType(DataType.Date)]
        public DateTime dataHora { get; set; }
        public Evento Evento { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
