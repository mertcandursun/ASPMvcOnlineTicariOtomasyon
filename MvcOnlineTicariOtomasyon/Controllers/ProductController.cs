using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.Status == true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> value = (from x in c.Categories.ToList()
                select new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.result = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveProduct(int id)
        {
            var value = c.Products.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> value = (from x in c.Categories.ToList()
                select new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.result = value;

            var productValue = c.Products.Find(id);
            return View("GetProduct", productValue);
        }
        public ActionResult UpdateProduct(Product p)
        {
            var product = c.Products.Find(p.Id);
            product.Brand = p.Brand;
            product.Name = p.Name;
            product.CategoryID = p.CategoryID;
            product.BuyPrice = p.BuyPrice;
            product.SellPrice = p.SellPrice;
            product.Status = p.Status;
            product.Image = p.Image;
            product.Stock = p.Stock;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var result = c.Products.ToList();
            return View(result);
        }
    }
}