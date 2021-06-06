using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Funcionario : Utilizador
    {
        public int FuncionarioId { get; set; }


        //nav properties
        public ICollection<Manutencao> Manutencoes { get; set; }

        public Utilizador Utilizador { get; set; }
    }
}
