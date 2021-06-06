using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Lembrete
    {
        // props
        public int LembreteID { get; set; }

        [DataType(DataType.Date)]
        public DateTime dataHora { get; set; }
        public int EventoID { get; set; }
        public int UtilizadorID { get; set; }

        // nav props
        public Evento Evento { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
