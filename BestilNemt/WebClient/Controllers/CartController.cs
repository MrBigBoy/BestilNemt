using System.Collections.Generic;
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
            var proxy = new BestilNemtServiceClient();
            if (partOrder == null)
            {
                return View();
            }
            proxy.AddPartOrder(partOrder);
            return View();
        }

        public ActionResult UpdateCart(int PartOrderId, int selAmount)
        {
            if (ShoppingCart != null)
            {
                var partOrders = ShoppingCart.PartOrders;
                foreach (var partOrder in partOrders)
                {
                    if (partOrder.Id == PartOrderId)
                    {
                        partOrder.Amount = selAmount;
                        partOrder.PartPrice = selAmount * partOrder.Product.Price;
                    }
                }
                ShoppingCart.PartOrders = partOrders;
                Session["ShoppingCart"] = ShoppingCart;
                return RedirectToAction("GetCart", new { id = ShoppingCart.Id });
            }
            return RedirectToAction("GetCart", new { id = 0 });
        }

        public Cart ShoppingCart
        {
            get
            {
                if (Session["ShoppingCart"] != null)
                    return (Cart)Session["ShoppingCart"];
                var cart = new Cart { PartOrders = new List<PartOrder>() };
                Session["ShoppingCart"] = cart;
                return (Cart)Session["ShoppingCart"];
            }
        }

        //  [HttpPost]
        public ActionResult ClearCart()
        {
            ShoppingCart.PartOrders = new List<PartOrder>();
            return RedirectToAction("GetCart", new { id = ShoppingCart.Id });
        }

        public ActionResult CompleteCart()
        {
            ShoppingCart.PartOrders = new List<PartOrder>();
            return RedirectToAction("Index", ("Home"));
        }

        public ActionResult GetCart(int? id)
        {
            ViewBag.Cart = (Cart)Session["ShoppingCart"];
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
            var proxy = new BestilNemtServiceClient();
            proxy.AddCartWithPartOrders((Cart)Session["ShoppingCart"]);
            return View();
        }
    }
}