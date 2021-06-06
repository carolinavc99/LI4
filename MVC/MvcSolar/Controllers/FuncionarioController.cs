using Microsoft.AspNetCore.Mvc;
using MvcSolar.Models;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class FuncionarioController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            
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