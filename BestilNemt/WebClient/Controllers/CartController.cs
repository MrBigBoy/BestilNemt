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

        public ActionResult AddtoCart(PartOrder partOrder)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            if (partOrder == null)
            {
                return View();
            }
            var addProductCart = proxy.AddPartOrder(partOrder);
            return View();
        }

        public ActionResult UpdateCart(int PartOrderId, int selAmount)
        {
            var cart = (Cart)Session["ShoppingCart"];
            if (cart != null)
            {
                var partOrders = cart.PartOrders;
                foreach (var partOrder in partOrders)
                {
                    if (partOrder.Id == PartOrderId)
                    {
                        partOrder.Amount = selAmount;
                        partOrder.PartPrice = selAmount * partOrder.Product.Price;
                    }
                }
                cart.PartOrders = partOrders;
                Session["ShoppingCart"] = cart;
            }
            return RedirectToAction("getCart", "Product", new { id = cart.Id });
        }
    }
}