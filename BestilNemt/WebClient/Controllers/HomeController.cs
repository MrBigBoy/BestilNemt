using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var proxy = new BestilNemtServiceClient();
            using (proxy)
            {
                proxy.Open();
                var chains = proxy.GetAllChains();
                var products = proxy.GetAllProductsWithSavings();
                var soldProducts = proxy.GetAllSoldProducts();
                var tuple = new Tuple<List<Chain>, List<Product>, List<Product>>(chains, soldProducts, products);
                return View(tuple);
            }
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