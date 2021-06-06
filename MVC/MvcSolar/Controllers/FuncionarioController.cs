using Microsoft.AspNetCore.Mvc;
using MvcSolar.Data;
using MvcSolar.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace MvcMovie.Controllers
{

    public class FuncionarioController : Controller
    {
        // 
        // GET: /HelloWorld/

        private readonly MvcSolarContext _context;

        public FuncionarioController(MvcSolarContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> IndexAsync()
        {

            var mvcSolarContext = _context.Habitacoes.Include(h => h.Localidade);
            var lista = await mvcSolarContext.ToListAsync();
            var locations = new List<Location>();
            foreach(Habitacao h in lista)
            {
                locations.Add(new Location(h.Latitude, h.Longitude));
            }
            ViewBag.locations = locations;
            return View("FuncionariosView");

        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}