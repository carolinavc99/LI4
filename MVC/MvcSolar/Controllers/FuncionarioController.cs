using Microsoft.AspNetCore.Mvc;
using MvcSolar.Data;
using MvcSolar.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class FuncionarioController : Controller
    {

        private MvcSolarContext _context;

        public FuncionarioController(MvcSolarContext context)
        {
            _context = context;
        }
        // 
        // GET: /HelloWorld/

        public async Task<IActionResult> IndexAsync()
        {
            var mvcSolarContext = _context.Avarias.Include(a => a.Habitacao);
            return View("FuncionariosView", await mvcSolarContext.ToListAsync());
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}