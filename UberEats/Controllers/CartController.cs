﻿using Microsoft.AspNetCore.Mvc;

namespace UberEats.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(string id)
        {
            ViewBag.PartnerSlug = id;
            return View();
        }
    }
}