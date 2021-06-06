using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Manutencao
    {
        // props
        public int ManutencaoID { get; set; }
        public int FuncionarioID { get; set; }
        public int HabitacaoID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        // nav props
        public Funcionario Funcionario { get; set; }
        public Habitacao Habitacao { get; set; }
    }
}
