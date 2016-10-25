using Models;
using DataAccessLayer;
using System.Collections.Generic;

namespace Controller
{
    public class ShopCtr
    {
        public IDbShop DbShop { get; set; }

        public ShopCtr(IDbShop dbShop)
        {
            DbShop = dbShop;
        }

        public Shop GetShop(int id)
        {
            return DbShop.GetShop(id);
        }

        public List<Shop> GetAllShops()
        {
            return DbShop.GetAllShops();
        }

        public int DeleteShop(int id)
        {
            return DbShop.DeleteShop(id);
        }

        public int AddShop(Shop shop)
        {
            return DbShop.AddShop(shop);
        }

        public int UpdateShop(Shop shop)
        {
            return DbShop.UpdateShop(shop);
        }
    }
}
