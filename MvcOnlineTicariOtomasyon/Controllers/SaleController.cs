using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        private Context c = new Context();
        public ActionResult Index()
        {
            var result = c.SaleActions.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddSale()
        {
            List<SelectListItem> value = (from x in c.Employees.ToList()
                select new SelectListItem()
                {
                    Text = x.Name + " " + x.Surname,
                    Value = x.Id.ToString()
                }).ToList();

            List<SelectListItem> value1 = (from y in c.Products.ToList()
                select new SelectListItem()
                {
                    Text = y.Name,
                    Value = y.Id.ToString()
                }).ToList();

            List<SelectListItem> value2 = (from z in c.Customers.ToList()
                select new SelectListItem()
                {
                    Text = z.Name + " " + z.Surname,
                    Value = z.Id.ToString()
                }).ToList();

            ViewBag.result = value;
            ViewBag.result1 = value1;
            ViewBag.result2 = value2;
            return View();
        }

        [HttpPost]
        public ActionResult AddSale(SaleAction s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaleActions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSale(int id)
        {
            List<SelectListItem> value = (from x in c.Employees.ToList()
                select new SelectListItem()
                {
                    Text = x.Name + " " + x.Surname,
                    Value = x.Id.ToString()
                }).ToList();

            List<SelectListItem> value1 = (from y in c.Products.ToList()
                select new SelectListItem()
                {
                    Text = y.Name,
                    Value = y.Id.ToString()
                }).ToList();

            List<SelectListItem> value2 = (from z in c.Customers.ToList()
                select new SelectListItem()
                {
                    Text = z.Name + " " + z.Surname,
                    Value = z.Id.ToString()
                }).ToList();

            ViewBag.result = value;
            ViewBag.result1 = value1;
            ViewBag.result2 = value2;

            var result = c.SaleActions.Find(id);
            return View("GetSale", result);
        }

        public ActionResult UpdateSale(SaleAction s)
        {
            var sale = c.SaleActions.Find(s.Id);
            sale.ProductID = s.ProductID;
            sale.CustomerID = s.CustomerID;
            sale.EmployeeID = s.EmployeeID;
            sale.Number = s.Number;
            sale.Price = s.Price;
            sale.TotalPrice = s.TotalPrice;
            sale.Date = s.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleDetail(int id)
        {
            var results = c.SaleActions.Where(x => x.Id == id).ToList();
            return View(results);
        }
    }
}