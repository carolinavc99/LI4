using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Avaria
    {
        // props
        public int AvariaID { get; set; }
        public int HabitacaoID { get; set; }
        public DateTime Data { get; set; }

        // nav props
        public Habitacao Habitacao { get; set; }
    }
}
