﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace solar.Data.Tables
{
    public partial class painel
    {
        public painel()
        {
            producaoenergetica = new HashSet<producaoenergetica>();
        }

        public int idPainel { get; set; }
        public int Habitacao_idHabitacao { get; set; }
        public double producaoPrevistaHora { get; set; }
        public string modelo { get; set; }
        public int estado { get; set; }

        public virtual habitacao Habitacao_idHabitacaoNavigation { get; set; }
        public virtual ICollection<producaoenergetica> producaoenergetica { get; set; }
    }
}