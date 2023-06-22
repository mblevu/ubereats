using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UberEats.Models;

namespace UberEats.Controllers
{
    public class PartnerController : Controller
    {
        private UberEatsContext context;

        public PartnerController(UberEatsContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            List<Partner> Partners;
            if (id == "All")
            {
                Partners = context.Partners
                    .OrderBy(p => p.PartnerID).ToList();
            }
            else
            {
                Partners = context.Partners
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.PartnerID).ToList();
            }

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind Partners to view
            return View(Partners);
        }

        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            Partner Partner = context.Partners.Find(id) ?? new Partner();

            string imageFilename = Partner.Email + "";

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            // bind Partner to view
            return View(Partner);
        }
    }
}