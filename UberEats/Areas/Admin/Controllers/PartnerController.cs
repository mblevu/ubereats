using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberEats.Models;

namespace UberEats.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartnerController : Controller
    {
        private UberEatsContext context;
        private List<Category> categories;

        public PartnerController(UberEatsContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
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

            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind Partners to view
            return View(Partners);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // create new Partner object
            Partner Partner = new Partner();                

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            // bind Partner to AddUpdate view
            return View("AddUpdate", Partner);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Partner object for specified primary key
            Partner Partner = context.Partners
                .Include(p => p.Category)
                .FirstOrDefault(p => p.PartnerID == id) ?? new Partner();

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            // bind Partner to AddUpdate view
            return View("AddUpdate", Partner);
        }

        [HttpPost]
        public IActionResult Update(Partner Partner)
        {
            if (ModelState.IsValid)
            {
                if (Partner.PartnerID == 0)           // new Partner
                {
                    context.Partners.Add(Partner);
                }
                else                                  // existing Partner
                {
                    context.Partners.Update(Partner);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", Partner);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Partner Partner = context.Partners
                .FirstOrDefault(p => p.PartnerID == id) ?? new Partner();
            return View(Partner);
        }

        [HttpPost]
        public IActionResult Delete(Partner Partner)
        {
            context.Partners.Remove(Partner);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}