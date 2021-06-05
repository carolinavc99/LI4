using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Funcionario : Utilizador
    {
        public Dictionary<DateTime,Manutencao> Manutencoes { get; set; }
    }
}
