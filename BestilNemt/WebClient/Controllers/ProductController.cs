using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        /**
         * Get a list of all products by a shop id
         * The id is Shop id
         */
        public ActionResult Product(int? id)
        {
            var products = new List<Product>();
            // if the id is null or has a value lower than 0 return a empty list to the view
            if (id == null || id.Value <= 0)
                return View(products);
            // Get the cart from Session
            var cart = (Cart)Session["ShoppingCart"];
            ViewBag.Cart = cart;
            var proxy = new BestilNemtServiceClient();
            // Get the shop by the id 
            var shop = proxy.GetShop(id.Value);
            // Get all Warehouses with with the shop id
            shop.Warehouses = proxy.FindAllWarehousesByShopId(id.Value);
            // Get the shop from session
            var shopSes = (Shop)Session["Shop"];
            // If the ids is different reset the cart
            if (shopSes.Id != shop.Id)
            {
                // Clear the cart from Session
                Session["ShoppingCart"] = new Cart();
            }
            // Set the shop
            Session["Shop"] = shop;
            // Get all products from the warehouses
            var listProduct = shop.Warehouses.Select(warehouse => warehouse.Product).ToList();
            // Return the view with the list of products
            return View(listProduct);
        }

        /**
         * Return a view of a specific product with a product id
         * The id is a Product id
         */
        public ActionResult ProductPage(int? id)
        {
            // If no id is set redirect to frontpage
            if (id == null)
                return RedirectToAction("Index", "Home");
            var proxy = new BestilNemtServiceClient();
            // Get the PartOrder with a product by a product id
            var pvm = new ProductPartOrderViewModel { Product = proxy.GetProduct(id.Value) };
            // Return the view
            return View(pvm);
        }

        /**
         * Add a product to a cart by a ProductPartOrderViewModel
         */
        [HttpPost]
        public ActionResult AddProductToCart(ProductPartOrderViewModel partOrder)
        {
            // Get the login from session and check if a person is set, is not return a site with a javascript error
            var login = (Login)Session["Login"];
            if (login.PersonId == 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Du skal være logget ind får at tilføje til kurv :)');</script>");
            }
            // Get the cart from Session
            var cart = (Cart)Session["ShoppingCart"];
            var proxy = new BestilNemtServiceClient();
            // Get the product by a partOrder product id.
            var product = proxy.GetProduct(partOrder.Product.Id);
            // Make the PartOrder object
            var po = new PartOrder
            {
                Product = product,
                Amount = partOrder.Amount,
                PartPrice = product.Price * partOrder.Amount,
                Cart = cart
            };
            // Get all PartOrders from cart
            var partOrders = cart.PartOrders;
            // There is a partOrder
            // Use of isFound to check if the specific partOrder is allready added
            var isFound = false;
            // Loop for every partOrdeers
            foreach (var partOrderLoop in partOrders)
            {
                // If the product ids match 
                if (partOrderLoop.Product.Id == partOrder.Product.Id)
                {
                    // Update the amount
                    partOrderLoop.Amount = partOrder.Amount + partOrderLoop.Amount;
                    // Set the isFound to true meaning the product was allready added.
                    isFound = true;
                }

            }
            // Add the partOrder to the list
            partOrders.Add(po);
            // Save the list of PartOrders to the cart
            cart.PartOrders = partOrders;
            // Update the session of Cart
            Session["ShoppingCart"] = cart;
            // Get the shop from session
            var shop = (Shop)Session["Shop"];
            // Return the view to Product with the Shop id
            return RedirectToAction("Product", new { id = shop.Id });
        }
    }
}