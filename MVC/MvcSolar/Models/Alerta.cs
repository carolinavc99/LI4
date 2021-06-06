using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MvcSolar.Models
{
    public class Alerta
    {
        public int AlertaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Sugestoes { get; set; }
        public Tipo Tipo { get; set; }
    }
}
