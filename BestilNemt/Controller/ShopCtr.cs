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

        public void DeleteShop(int id)
        {
            DbShop.DeleteShop(id);
        }

        public void AddShop(Shop shop)
        {
            DbShop.AddShop(shop);
            
        }

        public void UpdateShop(Shop shop)
        {
            DbShop.UpdateShop(shop);
        }
    }
}
