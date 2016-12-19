using System.Collections.Generic;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    public class ShopController : Controller
    {
        /// <summary>
        /// Return the ActionResult for all shops by a chain id
        /// The id is a Chain id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// List of Shops
        /// </returns>
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
                var chain_old = (Chain) Session["Chain"];
                var chainId_old = chain_old?.Id;
                var chain = proxy.GetChain(id.Value);
                // Set the new Chain
                Session["Chain"] = chain;
                // If the id is not different from the id there has been set before reset the id and clear the cart and the shop id
                if (chain?.Id == chainId_old) return View(proxy.GetAllShopsByChainId(id.Value));
                // Clear the cart
                Session["ShoppingCart"] = null;
                // Clear the shop
                Session["Shop"] = null;
                return View(proxy.GetAllShopsByChainId(id.Value));
            }
        }
    }
}