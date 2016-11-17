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
            return ValidateShop(shop) ?
            DbShop.AddShop(shop) : 0;
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

        private bool ValidateShop(Shop shop)
        {
            return true;
        }
    }
}
