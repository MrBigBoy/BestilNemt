using Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ShopCtr
    {
        public DbShop dbShop { get; set; }

        public ShopCtr()
        {
            dbShop = new DbShop();
        }

        public Shop GetShop(int id)
        {
            return dbShop.GetShop(id);

        }

        public List<Shop> GetAllShops()
        {
            return dbShop.GetAllShops();
        }

        public void DeleteShop(int id)
        {
            dbShop.DeleteShop(id);
        }

        public int AddShop(Shop shop)
        {
            return dbShop.AddShop(shop);
        }

        public void UpdateShop(Shop shop)
        {
            dbShop.UpdateShop(shop);
        }
    }
}
