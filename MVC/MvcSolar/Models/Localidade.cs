using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Localidade
    {
        // props
        public int LocalidadeID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Nome { get; set; }
        public string Distrito { get; set; }
        public string Concelho { get; set; }
        public Dictionary<DateTime,int> MeteorologiasID { get; set; }

        // nav props
        public Meteorologia Meteorologia { get; set; }
    }
}
