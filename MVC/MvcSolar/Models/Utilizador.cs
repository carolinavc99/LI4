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

        // nav props

        public ICollection<Lembrete> lembretes;
        public ICollection<Tipo> alertas_ativados;

        
        

    }
}
