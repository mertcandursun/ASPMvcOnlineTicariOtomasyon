using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        private Context c = new Context();
        public ActionResult Index()
        {
            var results = c.Categories.ToList();
            return View(results);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult RemoveCategory(int id)
        {
            var categoryId = c.Categories.Find(id);
            c.Categories.Remove(categoryId);
            c.SaveChanges();
            return Redirect("~/Category/Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = c.Categories.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(Category k)
        {
            var category = c.Categories.Find(k.Id);
            category.Name = k.Name;
            c.SaveChanges();
            return Redirect("Index");
        }
    }
}