using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M },
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M }
        };
        private IValueCalculator calc;

        public HomeController(IValueCalculator calc)
        {
            this.calc = calc;
        }

        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}