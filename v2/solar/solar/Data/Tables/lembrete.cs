// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace solar.Data.Tables
{
    public partial class lembrete
    {
        public int idLembrete { get; set; }
        public DateTime dataHora { get; set; }
        public string Utilizador_username { get; set; }
        public int Evento_idEvento { get; set; }

        public virtual evento Evento_idEventoNavigation { get; set; }
        public virtual utilizador Utilizador_usernameNavigation { get; set; }
    }
}