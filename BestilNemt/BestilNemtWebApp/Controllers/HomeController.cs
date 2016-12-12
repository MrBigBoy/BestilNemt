using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BestilNemtWebApp.BestilNemtServiceRef;
using Microsoft.Ajax.Utilities;

namespace BestilNemtWebApp.Controllers
{
    /// <summary>
    /// This controller is used to all Chain related controls
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var proxy = new BestilNemtServiceClient();
            using (proxy)
            {
                proxy.Open();
                // Get all Chains
                var chains = proxy.GetAllChains();
                // Get all products with a saving
                var products = proxy.GetAllProductsWithSavings();
                // Only have the products one time, comparing by id
                var productList = products.DistinctBy(product => product.Id).ToList();
                // Get all sold products
                var soldProducts = proxy.GetAllSoldProducts();
                // Only have the products one time, comparing by id
                var soldProductsList = soldProducts.DistinctBy(product => product.Id).ToList();
                // Make a Tuple with the three lists, the tuple is used to get three list to the cshtml page
                var tuple = new Tuple<List<Chain>, List<Product>, List<Product>>(chains, soldProductsList, productList);
                // Return the Tuple
                return View(tuple);
            }
        }
    }
}