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
            return ValidateShop(shop) ? DbShop.AddShop(shop) : 0;
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
            return ValidateShop(shop) ? DbShop.UpdateShop(shop) : 0;
        }

        private bool ValidateShop(Shop shop)
        {
            return shop?.Address != null && !shop.Address.Equals("") && shop.Name != null && !shop.Name.Equals("") &&
                shop.Cvr != null && !shop.Cvr.Equals("") && shop.Cvr.Length == 8 && shop.Chain != null &&
                shop.Warehouses != null;
        }
    }
}
