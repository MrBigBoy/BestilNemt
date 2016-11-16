using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class ShopCtrTestClass : IDbShop
    {
        List<Shop> shops = new List<Shop>();
        private int idCounter = 1;

        public int AddShop(Shop shop)
        {
            shop.Id = idCounter;
            shops.Add(shop);
            idCounter++;
            return shop.Id;
        }

        public int DeleteShop(int id)
        {
            return shops.Remove(FindShop(id)) ? 1 : 0;
        } 

        public int UpdateShop(Shop shop)
        {
            var returnedShop = FindShop(shop.Id);
            returnedShop.MinStock = shop.MinStock;
            returnedShop.Stock = shop.Stock;
            returnedShop.Chain = shop.Chain;
            returnedShop.Product = shop.Product;
            return 1;
        }

        public List<Shop> FindAllShops()
        {
            return shops;
        }

        public Shop FindShop(int id)
        {
            return shops.FirstOrDefault(shop => shop.Id == id);
        }
    }
}
