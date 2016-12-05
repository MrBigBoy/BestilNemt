using System.Collections.Generic;
using Models;
using DataAccessLayer;

namespace Controller
{
    public class ShopCtr
    {
        public IDbShop DbShop { get; set; }

        /// <summary>
        /// Constructor for Shop controller
        /// </summary>
        /// <param name="dbShop"></param>
        public ShopCtr(IDbShop dbShop)
        {
            DbShop = dbShop;
        }

        /// <summary>
        /// Add a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// id of shop if added, else 0
        /// </returns>
        public int AddShop(Shop shop)
        {
            return ValidateShop(shop) ? DbShop.AddShop(shop) : 0;
        }

        /// <summary>
        /// Get a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Shop if found, else null
        /// </returns>
        public Shop GetShop(int id)
        {
            return DbShop.GetShop(id);
        }

        /// <summary>
        /// Get all shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShops()
        {
            return DbShop.GetAllShops();
        }

        /// <summary>
        /// Get all Shops by a Chain Id
        /// </summary>
        /// <param name="chainId"></param>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShopsByChainId(int chainId)
        {
            return DbShop.GetAllShopsByChainId(chainId);
        }

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            return DbShop.DeleteShop(id);
        }

        /// <summary>
        /// Update a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// 1 if updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
        {
            return ValidateShop(shop) ? DbShop.UpdateShop(shop) : 0;
        }

        /// <summary>
        /// Validate Shop fields
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// true if fields is correct, else false
        /// </returns>
        private static bool ValidateShop(Shop shop)
        {
            return !string.IsNullOrEmpty(shop?.Address) && !string.IsNullOrEmpty(shop.Name) &&
                !string.IsNullOrEmpty(shop.Cvr) && shop.Cvr.Length == 8 && shop.Chain != null &&
                shop.Warehouses != null;
        }
    }
}
