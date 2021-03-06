﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;
using WebClient.Models;

namespace WebClient.Controllers
{
    /// <summary>
    /// This controller is used to all Product related controls
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// Get a list of all products by a shop id
        /// The id is Shop id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// View of all Products
        /// </returns>
        public ActionResult Product(int? id)
        {
            // Create a empty list of Products to return if something is not right, else fill it
            var products = new List<Product>();
            // Get the shop from session
            var shopSes = (Shop)Session["Shop"];
            // Get the cart from Session
            var cart = (Cart)Session["ShoppingCart"];
            ViewBag.Cart = cart;
            var proxy = new BestilNemtServiceClient();

            // If the id is null check if shop from session is also null, then return the view
            if (id == null)
            {
                // Check if shop from session is null
                if (shopSes == null)
                {
                    // Return a view of empty list
                    return View(products);
                }
                // Set the id to the id from the shop from session
                id = shopSes.Id;
            }

            // if the value of id is lower than or equal 0 return the empty list 
            if (id.Value <= 0)
                return View(products);
            // Get the shop by the id 
            var shop = proxy.GetShop(id.Value);
            // If the shop is null return the empty list 
            if (shop == null)
                return View(products);
            // Get all Warehouses with with the shop id
            shop.Warehouses = proxy.GetAllWarehousesByShopId(id.Value);

            // If the shop from session is set
            if (shopSes != null)
            {
                // If the ids is different reset the cart
                if (shopSes.Id != shop.Id)
                {
                    // Clear the cart from Session
                    Session["ShoppingCart"] = null;
                }
            }

            // Save the shop to session
            Session["Shop"] = shop;
            // Get all products from the warehouses
            products = shop.Warehouses.Select(warehouse => warehouse.Product).ToList();
            // Return the view with the list of products
            return View(products);
        }

        /// <summary>
        /// Return a view of a specific product with a product id
        /// The id is a Product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            // Get the login from session and check if a person is set, is not return a site with a javascript 

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
            // isFound is used to check if a partOrder is allready added
            var isFound = false;
            // Loop for every partOrdeers
            foreach (var partOrderLoop in partOrders)
            {
                // If the product ids not match 
                if (partOrderLoop.Product.Id != partOrder.Product.Id)
                    continue;
                // Update the amount
                partOrderLoop.Amount = partOrder.Amount + partOrderLoop.Amount;
                // The PartOrder is found
                isFound = true;
            }
            // If the partOrder is not allready added, add it
            if (!isFound)
            {
                // Add the partOrder to the list
                partOrders.Add(po);
            }
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