using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            //create a new Product object
            Product product = new Product();

            //set the propert value
            product.Name = "Kayak";

            //get the property
            string productName = product.Name;

            //generate the view
            return View("Result", $"Product name: {productName}");
        }

        public ViewResult CreateProduct()
        {
            //create a new Product object
            Product product = new Product();

            //set the property values
            product.ProductID = 100;
            product.Name = "Kayak";
            product.Description = "A boat for one person";
            product.Price = 275M;
            product.Category = "Watersports";

            return View("Result", $"Category: {product.Category}");
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int> { { "apple", 10 }, { "orange", 20 }, { "plum", 30 } };

            return View("Result", stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            //create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M },
                    new Product {Name = "Lifejacket", Price = 48.95M },
                    new Product {Name = "Soccer ball", Price = 19.50M },
                    new Product {Name = "Corner flag", Price = 34.95M }
                }
            };

            //get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result", $"Total: {cartTotal.ToString("N2")}");
        }
    }
}