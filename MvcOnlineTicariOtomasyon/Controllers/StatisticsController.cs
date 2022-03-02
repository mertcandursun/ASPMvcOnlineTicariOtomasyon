using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        private Context c = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var customerCount = c.Customers.Count().ToString();
            ViewBag.totalCustomer = customerCount;

            var productCount = c.Products.Count().ToString();
            ViewBag.totalProduct = productCount;

            var employeeCount = c.Employees.Count().ToString();
            ViewBag.totalEmployee = employeeCount;

            var categoryCount = c.Categories.Count().ToString();
            ViewBag.totalCategory = categoryCount;

            var totalStockCount = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.totalStock = totalStockCount;

            var totalBrandCount = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.totalBrand = totalBrandCount;

            var totalCriticalStock = c.Products.Count(x => x.Stock < 20).ToString();
            ViewBag.criticalStock = totalCriticalStock;

            var selectMaxPriceProduct = (from x in c.Products select x.SellPrice).Max().ToString();
            var selectMaxPriceProductName =
                (from x in c.Products orderby x.SellPrice descending select x.Name).FirstOrDefault();
            //var selectMaxPriceProductName = (from x in c.Products select x.SellPrice + x.Name).Max();
            ViewBag.maxPriceProduct = selectMaxPriceProduct;
            ViewBag.maxPriceProductNsme = selectMaxPriceProductName;

            var selectMinPriceProduct = (from x in c.Products select x.SellPrice).Min().ToString();
            var selectMinPriceProductName =
                (from x in c.Products orderby x.SellPrice select x.Name).FirstOrDefault();
            ViewBag.minPriceProduct = selectMinPriceProduct;
            ViewBag.minPriceProductNsme = selectMinPriceProductName;

            var selectMaxBrand = c.Products.GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.maxBrand = selectMaxBrand;

            var selectTodaySales = c.SaleActions.Count(x => x.Date == DateTime.Today).ToString();
            ViewBag.todaySales = selectTodaySales;

            decimal selectTodayTotalSale = 0;

            if (c.SaleActions.FirstOrDefault(x => x.Date == DateTime.Today) != null)
                {
                    selectTodayTotalSale = c.SaleActions.Where(x => x.Date == DateTime.Today).Sum(y => y.TotalPrice);
                    ViewBag.todayTotalSale = selectTodayTotalSale;
                }

            var selectMostSaleBrand = c.Products.Where(p => p.Id == (c.SaleActions.GroupBy(x => x.ProductID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(a => a.Name).FirstOrDefault();
            ViewBag.mostSaleBrand = selectMostSaleBrand;

            var selectTotalMoney = c.SaleActions.Sum(x => x.TotalPrice).ToString();
            ViewBag.totalMoney = selectTotalMoney;

            //Weather API
            string api = "6bed89df9bfee3c28db5d72f1ea76df3";
            string connectionXML = "https://api.openweathermap.org/data/2.5/weather?q=Bursa&&units=metric&mode=xml&lang=tr&appid=" + api;
            XDocument weather = XDocument.Load(connectionXML);

            var detail = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var city = weather.Descendants("city").ElementAt(0).Attribute("name").Value;
            var icon = weather.Descendants("weather").ElementAt(0).Attribute("icon").Value;

            ViewBag.detail = detail;
            ViewBag.temp = temp;
            ViewBag.city = city;
            ViewBag.iconUrl = $"http://openweathermap.org/img/wn/{icon}@2x.png";

            return View();
        }

        public ActionResult SimplesTables()
        {
            var query = from x in c.Customers
                group x by x.City
                into g
                select new CityGroup()
                {
                    City = g.Key,
                    Count = g.Count()*100/10
                };

            return View(query.ToList());
        }

        public PartialViewResult Partial1()
        {
            var query = from x in c.Employees
                group x by x.DepartmentID
                into g
                select new EmployeeGroup()
                {
                    Department = g.Key,
                    Count = g.Count()*100/10
                };
            return PartialView(query.ToList());
        }

        public PartialViewResult CategoryPartial()
        {
            var query = from x in c.Products
                group x by x.CategoryID
                into g
                select new CategoryGroup()
                {
                    Product = g.Key,
                    Count = g.Count()
                };
            return PartialView(query.ToList());
        }
    }
}