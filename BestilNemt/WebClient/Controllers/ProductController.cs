using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int? id)
        {
            var proxy = new BestilNemtServiceClient();
            var allProducts = proxy.GetAllProducts();
            var cart = (Cart)Session["ShoppingCart"];
            ViewBag.Cart = cart;
            if (id == null)
                return View(allProducts);
            if (id.Value <= 0)
                return View(allProducts);
            var shop = proxy.GetShop(id.Value);
            shop.Warehouses = proxy.FindAllWarehousesByShopId(id.Value);
            Session["Shop"] = shop;
            return View(allProducts);
        }

        public ActionResult ProductPage(int? id)
        {
            // If no id is set redirect to frontpage
            if (id == null)
                return RedirectToAction("Index", "Home");
            var proxy = new BestilNemtServiceClient();
            var pvm = new ProductPartOrderViewModel { Product = proxy.GetProduct(id.Value) };
            return View(pvm);
        }

        public ActionResult SearchProduct(string input)
        {
            var proxy = new BestilNemtServiceClient();
            var productsByName = proxy.FindProductsByName(input);
            return View(productsByName);
        }

        [HttpPost]
        public ActionResult AddProductToCart(ProductPartOrderViewModel partOrder)
        {
            var proxy = new BestilNemtServiceClient();
            var cart = (Cart)Session["ShoppingCart"];
            var product = proxy.GetProduct(partOrder.Product.Id);
            var partOrders = cart.PartOrders;
            var po = new PartOrder
            {
                Product = product,
                Amount = partOrder.Amount,
                PartPrice = product.Price * partOrder.Amount,
                Cart = cart
            };
            if (partOrders.Count == 0)
            {
                partOrders.Add(po);
            }
            else
            {
                foreach (var partOrderLoop in partOrders)
                {
                    if (partOrderLoop.Product.Id == partOrder.Product.Id)
                    {
                        var i = partOrder.Amount + partOrderLoop.Amount;
                        var shop = (Shop)Session["Shop"];
                        var warehouses = proxy.FindAllWarehousesByShopId(shop.Id);

                        var maxAmount = 0;
                        foreach (var warehouse in warehouses)
                        {
                            if (warehouse.Product.Id == partOrderLoop.Product.Id)
                            {
                                maxAmount = warehouse.Stock;
                            }
                        }

                        //if (i > maxAmount)
                        //{
                        //    // pop up

                        //    return
                        //        Content(
                        //            "<script language='javascript' type='text/javascript'>alert('Det maksimale antal er allerede tilføjet!');</script>");
                        //}
                        partOrderLoop.Amount = i;
                    }
                    else
                    {
                        partOrders.Add(po);
                    }
                }
                cart.PartOrders = partOrders;
            }
            // Update the session
            Session["ShoppingCart"] = cart;
            return RedirectToAction("ProductPage", new { id = partOrder.Product.Id });
        }
    }
}