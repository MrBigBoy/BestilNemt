using System.Collections.Generic;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class ShopController : Controller
    {
        /**
         * Return the ActionResult for all shops by a chain id
         *  The id is a Chain id
         */
        public ActionResult ShopList(int? id)
        {
            // If the id is null return a empty list of shops
            if (id == null)
            {
                return View(new List<Shop>());
            }
            var proxy = new BestilNemtServiceClient();
            using (proxy)
            {
                proxy.Open();
                // Get the chain from session
                var chain = (Chain)Session["Chain"];
                // If the chain has been set before
                if (chain != null)
                {
                    // If the id is different from the id there has been set before reset the id and clear the cart and the shop id
                    if (chain.Id != id.Value)
                    {
                        Session["Chain"] = proxy.GetChain(id.Value);
                        Session["ShoppingCart"] = new Cart();
                        Session["Shop"] = new Shop();
                    }
                }
                return View(proxy.GetAllShopsByChainId(id.Value));
            }
        }
    }
}