using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        private Context c = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var values = c.Products.ToList();
            return View(values);
        }

    }
}