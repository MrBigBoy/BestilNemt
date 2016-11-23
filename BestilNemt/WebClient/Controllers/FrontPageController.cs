using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class FrontPageController : Controller
    {
        // GET: ChainFrontPage
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
    }
}