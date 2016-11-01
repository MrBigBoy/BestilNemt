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

            return ValidateShopInput(shop) ? DbShop.AddShop(shop) : 0;
        }

        public int UpdateShop(Shop shop)
        {
            return ValidateShopInput(shop) ? DbShop.UpdateShop(shop) : 0;
        }

        private bool ValidateShopInput(Shop shop)
        {
            if (shop == null || shop.CVR.Length != 8 || shop.Name.Equals("")
                || shop.Name == null || shop.Address.Equals("")
                || shop.Address == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
