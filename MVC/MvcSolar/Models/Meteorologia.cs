using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSolar.Models
{
    public class Meteorologia
    {
        // props
        public int MeteorologiaID { get; set; } // data que acontece & localização
        public string WeatherType { get; set; }
        public string SkyCondition { get; set; }
        public double ProbPrecipitacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime Sunrise { get; set; }

        [DataType(DataType.Date)]
        public DateTime Sunset { get; set; }
         
        // nav props
    }
}
