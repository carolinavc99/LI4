using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Models
{
    public class Dashboard
    {
        public List<Painel> paineis;

        public Habitacao casa;

        public double prodAtual;

        public Dashboard(List<Painel> l, Habitacao c)
        {
            prodAtual = 0;
            foreach(Painel p in l)
            {
                prodAtual += p.ProducaoPrevistaHora;

            }

            paineis = l;
            casa = c;
        }

    }


}
