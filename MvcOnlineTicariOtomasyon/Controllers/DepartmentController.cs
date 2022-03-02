using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        private Context c = new Context();

        // GET: Department
        public ActionResult Index()
        {
            var result = c.Departments.Where(x => x.Status == true).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            d.Status = true;
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveDepartment(int id)
        {
            var value = c.Departments.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var value = c.Departments.Find(id);
            return View("GetDepartment", value);
        }

        public ActionResult UpdateDepartment(Department d)
        {
            var department = c.Departments.Find(d.Id);
            department.Name = d.Name;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetails(int id)
        {
            var values = c.Employees.Where(x => x.DepartmentID == id).ToList();
            var dptName = c.Departments.Where(x => x.Id == id).Select(y => y.Name).FirstOrDefault();
            ViewBag.d = dptName;
            return View(values);
        }

        public ActionResult DepartmentEmployeeSale(int id)
        {
            var results = c.SaleActions.Where(x => x.EmployeeID == id).ToList();
            var employee = c.Employees.Where(x => x.Id == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.name = employee;
            return View(results);
        }
    }
}