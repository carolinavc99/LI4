using Microsoft.AspNetCore.Mvc;
using MvcSolar.Data;
using MvcSolar.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace MvcMovie.Controllers
{
    public class DashboardPaineisController : Controller
    {
        // 
        // GET: /HelloWorld/

        private readonly MvcSolarContext _context;
        private readonly INotyfService _notyf;


        public DashboardPaineisController(MvcSolarContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var paineis = from s in _context.Paineis
                select s.Estado;

            var count = 0;

            foreach (Estado m in paineis)
            {
                if (m == Estado.Avariado)
                    count++;
            }

            if (count > 0)
                _notyf.Warning("Aviso:\n Existem " + count + " paineis avariados.");

            var mvcSolarContext = _context.Paineis.Include(p => p.Habitacao);
            var lista = await mvcSolarContext.ToListAsync();

            var mvcSolarContext2 = _context.Habitacoes.Include(h => h.Localidade);
            var casas = (await mvcSolarContext2.ToListAsync());

            var dashboard = new Dashboard(lista, casas[0]);


            ViewBag.dashboard = dashboard;
            return View("DashboardPaineis");
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}