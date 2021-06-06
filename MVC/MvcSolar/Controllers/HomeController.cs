﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSolar.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Home/

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        // GET: /Home/Calendario/
        public IActionResult Calendario()
        {
            return View();
        }

        // GET: /Home/Dashboard/
        public IActionResult Dashboard()
        {
            return View();
        }


    }
}
