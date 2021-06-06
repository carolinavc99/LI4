using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSolar.Controllers
{
    public class CalendairController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("CalendairView");
        }
    }
}