using System.Collections.Generic;
using Models;
using DataAccessLayer;

namespace Controller
{
    public class ShopCtr
    {
        public IDbShop DbShop { get; set; }

        public ShopCtr(IDbShop dbShop)
        {
            DbShop = dbShop;
        }

        public int AddShop(Shop shop)
        {
            return shop.Chain != null && shop.Chain.Id != 0 && shop.Product != null &&
                   shop.Product.Id != 0
                ? DbShop.AddShop(shop)
                : 0;
        }
        public Shop FindShop(int id)
        {
            return DbShop.FindShop(id);
        }

        public List<Shop> FindAllShops()
        {
            return DbShop.FindAllShops();
        }

        public int DeleteShop(int id)
        {
            return DbShop.DeleteShop(id);
        }

        public int UpdateShop(Shop shop)
        {
            return DbShop.UpdateShop(shop);
        }
    }
}
