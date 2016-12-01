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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public Login Login
        {
            get
            {
                if (Session["Login"] != null)
                    return (Login)Session["Login"];
                var login = new Login();
                Session["Login"] = login;
                return (Login)Session["Login"];
            }
        }

        public ActionResult Product(int? id)
        {
            var proxy = new BestilNemtServiceClient();
            var warehouses = proxy.FindAllWarehouses();
            var products = new List<Product>();
            foreach (var warehouse in warehouses)
            {
                products.Add(warehouse.Product);
            }
            var cart = (Cart)Session["ShoppingCart"];
            ViewBag.Cart = cart;
            if (id == null || id.Value <= 0)
                return View(products);
            var shop = proxy.GetShop(id.Value);
            shop.Warehouses = proxy.FindAllWarehousesByShopId(id.Value);
            Session["Shop"] = shop;
            // Get the products from the warehouses
            var listProduct = shop.Warehouses.Select(warehouse => warehouse.Product).ToList();
            return View(listProduct);
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
            var login = (Login)Session["Login"];
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
            if (login.PersonId == 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Du skal være logget ind får at tilføje til kurv :)');</script>");
            }
            if (partOrders.Count == 0)
            {
                partOrders.Add(po);
            }
            else
            {
                var isFound = false;
                foreach (var partOrderLoop in partOrders)
                {
                    if (partOrderLoop.Product.Id == partOrder.Product.Id)
                    {
                        partOrderLoop.Amount = partOrder.Amount + partOrderLoop.Amount;
                        isFound = true;
                    }
                }
                if (!isFound)
                {
                    partOrders.Add(po);
                }

            }
            cart.PartOrders = partOrders;
            // Update the session
            Session["ShoppingCart"] = cart;
            return RedirectToAction("ProductPage", new { id = partOrder.Product.Id });
        }
    }
}