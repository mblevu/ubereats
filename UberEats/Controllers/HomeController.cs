﻿using Microsoft.AspNetCore.Mvc;

namespace UberEats.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

    }
}
