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

        public ActionResult UpdateCart(int ProductId, int selAmount)
        {
            if (ShoppingCart != null)
            {
                var partOrders = ShoppingCart.PartOrders;
                foreach (var partOrder in partOrders)
                {
                    if (partOrder.Product.Id == ProductId)
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
        //Making a session for cart, with a list of partorders. 
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

       //This metoed empty your cart for partorders. 
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
            try
            {
                //Checks for partorder is empty in cart
                if (ShoppingCart.PartOrders.Capacity == 0)
                {

                    return Content("<script language='javascript' type='text/javascript'>alert('Du mangler at tilføje vare til din kurv'); window.location.replace('http://localhost:50483/Cart/GetCart/0');</script>");

                }
               //If there is partorder on cart, you will contuine to checkout 
                else if (ShoppingCart.PartOrders.Capacity != 0)
                {
                    var fl = proxy.AddCartWithPartOrders((Cart) Session["ShoppingCart"]);
                    if (fl == 1)
                    {

                        return View();
                    }
                    else
                    // if product is already is taken, before you checkout, and the wanted amount is not abliable 
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Du er for langsomt. Varen er blevet købt. Øv-Øv'); window.location.replace('http://localhost:50483/Cart/GetCart/0');</script>");
                    }
                    
                }
                else
                {
                    return null;
                }
            }
            // if product is already is taken, before you checkout, and the wanted amount is not abliable
            catch (System.Exception ex)
            {

                return Content("<script language='javascript' type='text/javascript'>alert('Ønsket antal varer ikke på lager'); window.location.replace('http://localhost:50483/Cart/GetCart/0');</script>");
            }
        

        }
        //This metoed show, show your receipt with a person. 
        public ActionResult Receipt()
        {
            var login = (Login)Session["Login"];
            var personId = login?.PersonId ?? 0;
            var proxy = new BestilNemtServiceClient();
            var carts = proxy.GetAllCartsByPersonId(personId);
            return View(carts);
        }
    }
}