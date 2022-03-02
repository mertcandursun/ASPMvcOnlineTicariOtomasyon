using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private Context c = new Context();
        public ActionResult Index()
        {
            var results = c.Employees.ToList();
            return View(results);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> value = (from x in c.Departments.ToList()
                select new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.result = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            c.Employees.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> value = (from x in c.Departments.ToList()
                select new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            ViewBag.result = value;
            var result = c.Employees.Find(id);
            return View("GetEmployee",result);
        }

        public ActionResult UpdateEmployee(Employee e)
        {
            var employee = c.Employees.Find(e.Id);
            employee.Name = e.Name;
            employee.Surname = e.Surname;
            employee.Image = e.Image;
            employee.DepartmentID = e.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleHistory(int id)
        {
            var results = c.SaleActions.Where(x => x.EmployeeID == id).ToList();
            var employee = c.Employees.Where(x => x.Id == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.name = employee;
            return View(results);
        }
    }
}