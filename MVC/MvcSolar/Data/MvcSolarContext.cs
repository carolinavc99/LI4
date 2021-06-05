using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSolar.Models;

namespace MvcSolar.Data
{
    public class MvcSolarContext : DbContext
    {
        public MvcSolarContext (DbContextOptions<MvcSolarContext> options)
            : base(options)
        {
        }

        public DbSet<MvcSolar.Models.Evento> Evento { get; set; }
    }
}
