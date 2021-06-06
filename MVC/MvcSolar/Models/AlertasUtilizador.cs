using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    

    public class AlertasUtilizador
    {
        // props
        public int AlertasUtilizadorID { get; set; }
        public int UtilizadorID { get; set; }

        public Tipo Tipo { get; set; }

        // nav props
        public Utilizador Utilizador { get; set; }



    }
}
