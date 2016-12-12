using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    /// <summary>
    /// This controller is used to all Cart related controls
    /// </summary>
    public class CartController : Controller
    {
        /// <summary>
        /// Add a PartOrder to a Cart
        /// Use of PartOrders Cart object
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// The View
        /// </returns>
        public ActionResult AddtoCart(PartOrder partOrder)
        {
            var proxy = new BestilNemtServiceClient();
            // Check for partOrder != null and partOrder.Cart != null
            if (partOrder?.Cart != null)
            {
                // Call the Service provider
                proxy.AddPartOrder(partOrder);
            }
            // Return the View
            return View();
        }

        /// <summary>
        /// Update a Cart
        /// Requres a Product Id and a amount of the product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="selAmount"></param>
        /// <returns>
        /// To the ShoppingCart View
        /// </returns>
        public ActionResult UpdateCart(int ProductId, int selAmount)
        {
            // If the Cart is null, just get a empty cart with id 0
            if (ShoppingCart == null) return RedirectToAction("GetCart", new {id = 0});
            // Get the PartOrders from the Cart
            var partOrders = ShoppingCart.PartOrders;
            // Loop for every PartOrder
            foreach (var partOrder in partOrders)
            {
                // If the partOrders Product match the product we want to change, proceed
                if (partOrder.Product.Id != ProductId) continue;
                // Set the new Amount wanted
                partOrder.Amount = selAmount;
                // Calculate the new PartPrice
                partOrder.PartPrice = selAmount * partOrder.Product.Price;
            }
            // Update all the PartOrders in the cart
            ShoppingCart.PartOrders = partOrders;
            // Update the cart in the Session
            Session["ShoppingCart"] = ShoppingCart;
            // Get the View of the Cart
            return RedirectToAction("GetCart", new { id = ShoppingCart.Id });
        }

        /// <summary>
        /// Method to hold the ShoppingCart
        /// The method return a cart from Session
        /// </summary>
        public Cart ShoppingCart
        {
            get
            {
                var cart = (Cart)Session["ShoppingCart"] ?? new Cart();
                var shop = (Shop)Session["Shop"];
                cart.ShopId = shop.Id;
                Session["ShoppingCart"] = cart;
                return cart;
            }
        }

        /// <summary>
        /// Clears the cart for partorders. 
        /// </summary>
        /// <returns>
        /// The View of the Cart
        /// </returns>
        public ActionResult ClearCart()
        {
            // Set a empty list of PartOrders to the ShoppingCarts list of PartOrder
            ShoppingCart.PartOrders = new List<PartOrder>();
            // Return the View of the Cart
            return RedirectToAction("GetCart", new { id = ShoppingCart.Id });
        }

        /// <summary>
        /// Remove a single PartOrder by id from the cart in Session
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The View of the Cart
        /// </returns>
        public ActionResult RemovePartOrder(int id)
        {
            // Get the list of PartOrders from cart
            var partOrders = ShoppingCart.PartOrders;
            // Remove all partOrders there match the id of the PartOrder
            ShoppingCart.PartOrders = partOrders.Where(partOrder => partOrder.Product.Id != id).ToList();
            // The View of the Cart
            return RedirectToAction("GetCart", new { id = ShoppingCart.Id });
        }

        /// <summary>
        /// This method clears the list of PartOrders and redirecting to the frontpage
        /// </summary>
        /// <returns>
        /// Return to the frontpage
        /// </returns>
        public ActionResult CompleteCart()
        {
            // Clear the list of PartOrders
            ShoppingCart.PartOrders = new List<PartOrder>();
            // The frontpage
            return RedirectToAction("Index", ("Home"));
        }

        /// <summary>
        /// Get a Cart by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The View of the Cart
        /// </returns>
        public ActionResult GetCart(int? id)
        {
            // get the cart from session
            ViewBag.Cart = (Cart)Session["ShoppingCart"];
            // Return the view of the cart
            return View();
        }

        /// <summary>
        /// This method is used to checkout a Order
        /// Check for no partOrders
        /// Check for PartOrder amount not can be negative
        /// </summary>
        /// <returns>
        /// script check for no partOrders and return view of Cart
        /// script check for amount not getting negative and return view of Cart
        /// </returns>
        [HttpPost]
        public ActionResult CheckOut()
        {

            var proxy = new BestilNemtServiceClient();
            try
            {
                // Checks for partorder is empty in cart
                if (ShoppingCart.PartOrders.Capacity == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Du mangler at tilføje vare til din kurv'); window.location.replace('http://localhost:50483/Cart/GetCart/0');</script>");
                }
                // If there is partorder on cart, you will continue to checkout 
                var fl = proxy.AddCartWithPartOrders((Cart)Session["ShoppingCart"]);
                if (fl == 1)
                {
                    return View();
                }
                // if product is already taken, before you checkout, and the wanted amount is not abliable 
                return Content("<script language='javascript' type='text/javascript'>alert('Du er for langsomt. Varen er blevet købt. Øv-Øv'); window.location.replace('http://localhost:50483/Cart/GetCart/0');</script>");
            }
            // if product is already is taken, before you checkout, and the wanted amount is not abliable
            catch (System.Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Ønsket antal varer ikke på lager'); window.location.replace('http://localhost:50483/Cart/GetCart/0');</script>");
            }


        }

        /// <summary>
        /// This method show all receipts to the person logged in 
        /// </summary>
        /// <returns>
        /// View list of Carts
        /// </returns>
        public ActionResult Receipt()
        {
            // Get the login from Session
            var login = (Login)Session["Login"];
            // If the login has a PersonId use it, else set it to 0
            var personId = login?.PersonId ?? 0;
            var proxy = new BestilNemtServiceClient();
            // Get a list of all Carts related to the person
            var carts = proxy.GetAllCartsByPersonId(personId);
            return View(carts);
        }
    }
}