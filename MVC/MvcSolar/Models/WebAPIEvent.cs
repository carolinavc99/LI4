using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSolar.Models
{
    public class WebAPIEvent
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public static explicit operator WebAPIEvent(Evento schedulerEvent)
        {
            return new WebAPIEvent
            {
                id = schedulerEvent.EventoId,
                text = schedulerEvent.Descricao,
                start_date = schedulerEvent.Data.ToString("yyyy-MM-dd HH:mm"),
                end_date = schedulerEvent.DataFinal.ToString("yyyy-MM-dd HH:mm")
            };
        }

        public static explicit operator Evento(WebAPIEvent schedulerEvent)
        {
            return new Evento
            {
                EventoId = schedulerEvent.id,
                Descricao = schedulerEvent.text,
                Data = DateTime.Parse(
                    schedulerEvent.start_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                DataFinal = DateTime.Parse(
                    schedulerEvent.end_date,
                    System.Globalization.CultureInfo.InvariantCulture)
            };
        }

    }
}