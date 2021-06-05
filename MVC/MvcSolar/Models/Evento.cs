using System;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinalDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}