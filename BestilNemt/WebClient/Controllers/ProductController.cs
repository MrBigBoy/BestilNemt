using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Product()
        {
            
     //    var id = (Int32.Parse(UrlParameter.Optional));
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var AllProducts = proxy.GetAllProducts();
          //  var shop = (Shop)Session["Shop"];
           //  var WarehouseStock = proxy.FindAllWarehousesByShopId(shop.Id);
            ViewBag.Cart = ShoppingCart;
            return View(AllProducts);
        }

        public ActionResult ProductPage(int id)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();

            ProductPartOrderViewModel pvm = new ProductPartOrderViewModel();
            pvm.Product = proxy.GetProduct(id);
            return View(pvm);
        }

        public ActionResult SearchProduct(string input)
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var ProductsByName = proxy.FindProductsByName(input);
            return View(ProductsByName);
        }


        public Cart ShoppingCart
        {
            get
            {
                if (Session["ShoppingCart"] == null)
                {
                    var cart = new Cart();
                    cart.PartOrders = new List<PartOrder>();
                    Session["ShoppingCart"] = cart;
                }
                return (Cart)Session["ShoppingCart"];
            }
        }

        [HttpPost]
        public ActionResult AddProductToCart(ProductPartOrderViewModel partOrder)
        {

            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();

            PartOrder po = new PartOrder();
            po.Product = proxy.GetProduct(partOrder.Product.Id);
            po.Amount = partOrder.Amount;
            po.PartPrice = po.Product.Price * po.Amount;
            po.Cart = ShoppingCart;
            ShoppingCart.PartOrders.Add(po);
            //var addProductCart = proxy.AddPartOrder(po);
            return RedirectToAction("ProductPage", new { id = partOrder.Product.Id });
        }

        public ActionResult getCart(int id)
        {
            ViewBag.Cart = ShoppingCart;
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
            BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            proxy.AddCartWithPartOrders(ShoppingCart);
            return View();
        }
      //  [HttpPost]
        public ActionResult ClearCart()
        {
         
            ShoppingCart.PartOrders= new List<PartOrder>();
            return RedirectToAction("getCart", new { id = ShoppingCart.Id });


        }
        public ActionResult CompleteCart()
        {

            ShoppingCart.PartOrders = new List<PartOrder>();
            return RedirectToAction("Index",("Home") );


        }
    }
}