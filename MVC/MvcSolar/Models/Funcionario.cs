using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Funcionario : Utilizador
    {
        public int funcionarioId;

        public string username;


        //nav properties
        public ICollection<Manutencao> Manutencoes { get; set; }

        public Utilizador utilizador;
    }
}
