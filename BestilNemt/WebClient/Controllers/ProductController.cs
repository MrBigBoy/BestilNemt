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
            var product = proxy.GetAllProducts(); 
            return View(product); 
        }
    }
}