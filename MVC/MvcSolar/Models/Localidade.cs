using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Localidade
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Nome { get; set; }
        public string Distrito { get; set; }
        public string Concelho { get; set; }

        public Dictionary<DateTime,Meteorologia> Meteorologia { get; set; }
    }
}
