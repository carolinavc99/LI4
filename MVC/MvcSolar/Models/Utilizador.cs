using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime LastTimeOnline { get; set; }
        public string Username { get; set; }
        public Habitacao Habitacao { get; set; }
        public Dictionary<int,Evento> Eventos { get; set; }
        public Tipo NotificacoesLigadas { get; set; }
       
    }
}
