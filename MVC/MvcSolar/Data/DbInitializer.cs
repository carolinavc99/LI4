using MvcSolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcSolar.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MvcSolarContext context)
        {
            context.Database.EnsureCreated();

            
        }
    }
}