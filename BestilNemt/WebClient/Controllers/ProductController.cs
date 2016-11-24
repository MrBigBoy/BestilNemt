using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var AllProducts = proxy.GetAllProducts(); 
            return View(AllProducts); 
        }

        public ActionResult ProductPage(int id)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var ProductInformation = proxy.GetProduct(id);
            return View(ProductInformation);
        }

        public ActionResult SearchProduct(string input)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var ProductsByName = proxy.FindProductsByName(input);
            return View(ProductsByName);
        }

        public ActionResult AddProductToCart(PartOrder partOrder)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var addProductCart = proxy.AddPartOrder(partOrder);
            return View(addProductCart);
        }
    }
}