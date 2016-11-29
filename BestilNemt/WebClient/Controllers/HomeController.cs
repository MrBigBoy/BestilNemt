using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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
                var productList = products.DistinctBy(product => product.Id).ToList();
                var soldProducts = proxy.GetAllSoldProducts();
                var soldProductsList = soldProducts.DistinctBy(product => product.Id).ToList();
                var tuple = new Tuple<List<Chain>, List<Product>, List<Product>>(chains, soldProductsList, productList);
                return View(tuple);
            }
        }
    }
}