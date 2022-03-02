using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        private Context c = new Context();
        public ActionResult Index()
        {
            var result = c.Bills.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBill(Bills b)
        {
            if (!ModelState.IsValid)
            {
                return View("AddBill");
            }
            c.Bills.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBill(int id)
        {
            var bill = c.Bills.Find(id);
            return View("GetBill", bill);
        }

        public ActionResult UpdateBill(Bills b)
        {
            var bill = c.Bills.Find(b.Id);
            bill.SerialNumber = b.SerialNumber;
            bill.RowNumber = b.RowNumber;
            bill.TaxAdministration = b.TaxAdministration;
            bill.Date = b.Date;
            bill.HourTime = b.HourTime;
            bill.Sender = b.Sender;
            bill.Receiver = b.Receiver;
            bill.Total = b.Total;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BillDetail(int id)
        {
            var values = c.BillDetails.Where(x => x.BillID == id).ToList();
            var serialNo = c.Bills.Where(x => x.Id == id).Select(y => y.SerialNumber).FirstOrDefault();
            var rowNo = c.Bills.Where(x => x.Id == id).Select(y => y.RowNumber).FirstOrDefault();
            ViewBag.serial = serialNo;
            ViewBag.row = rowNo;
            return View(values);
        }

        [HttpGet]
        public ActionResult AddBillDetail()
        {
            return View();
        }

        public ActionResult AddBillDetail(BillDetail bD)
        {
            c.BillDetails.Add(bD);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}