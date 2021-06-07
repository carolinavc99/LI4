using Microsoft.AspNetCore.Mvc;
using MvcSolar.Data;
using MvcSolar.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System;

namespace MvcMovie.Controllers
{

    public class DashboardPaineisController : Controller
    {
        // 
        // GET: /HelloWorld/

        private readonly MvcSolarContext _context;

        public DashboardPaineisController(MvcSolarContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> IndexAsync()
        {

            var mvcSolarContext = _context.Paineis.Include(p => p.Habitacao);
            var lista = await mvcSolarContext.ToListAsync();

            var mvcSolarContext2 = _context.Habitacoes.Include(h => h.Localidade);
            var casas=(await mvcSolarContext2.ToListAsync());

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