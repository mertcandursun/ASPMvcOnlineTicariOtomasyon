using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private Context c = new Context();
        public ActionResult Index()
        {
            var results = c.Customers.Where(x => x.Status == true).ToList();
            return View(results);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer ct)
        {
            ct.Status = true;
            c.Customers.Add(ct);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCustomer(int id)
        {
            var customer = c.Customers.Find(id);
            customer.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = c.Customers.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult UpdateCustomer(Customer ct)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCustomer");
            }
            var customer = c.Customers.Find(ct.Id);
            customer.Name = ct.Name;
            customer.Surname = ct.Surname;
            customer.City = ct.City;
            customer.Mail = ct.Mail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSell(int id)
        {
            var values = c.SaleActions.Where(x => x.CustomerID == id).ToList();
            var name = c.Customers.Where(y => y.Id == id).Select(z => z.Name + " " + z.Surname).FirstOrDefault();
            ViewBag.name = name;
            return View(values);
        }

        public ActionResult CustomerHistory(int id)
        {
            var results = c.SaleActions.Where(x => x.CustomerID == id).ToList();
            var customer = c.Customers.Where(x => x.Id == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.name = customer;
            return View(results);
        }
    }
}