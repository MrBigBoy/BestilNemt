using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var proxy = new BestilNemtServiceClient();
            using (proxy)
            {
                proxy.Open();
                return View(proxy.GetAllShops());
            }
        }

        public ActionResult ShopList(int? id)
        {
            if (id == null)
            {
                id = 0;
            }
            var proxy = new BestilNemtServiceClient();
            using (proxy)
            {
                proxy.Open();
                return View(proxy.GetAllShopsByChainId((int) id));
            }
        }
    }
}