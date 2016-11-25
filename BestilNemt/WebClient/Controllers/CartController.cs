using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddtoCart( PartOrder partOrder)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            if (partOrder == null)
            {
                return View();
            }
            var addProductCart = proxy.AddPartOrder(partOrder);
            return View();
        }

 
    }
}