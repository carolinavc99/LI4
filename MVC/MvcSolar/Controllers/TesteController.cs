using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult TesteAction()
        {
            return View();
        }
    }
}
