using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Utilizador
    {
        // props
        public int UtilizadorId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime LastTimeOnline { get; set; }
        public string Username { get; set; }
        public int HabitacaoID { get; set; }
        public Dictionary<int,int> EventosID { get; set; }        
        public Tipo NotificacoesLigadas { get; set; }

        // nav props
        public Habitacao Habitacao { get; set; }
        public Evento Eventos { get; set; }

    }
}
