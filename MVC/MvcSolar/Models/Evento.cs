using System;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Evento
    {
        public int EventoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}