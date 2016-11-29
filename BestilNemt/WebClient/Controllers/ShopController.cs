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
                Session["Chain"] = proxy.GetChain(id.Value);
                return View(proxy.GetAllShopsByChainId(id.Value));
            }

        }
    }
}