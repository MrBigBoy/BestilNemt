using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class ShopCtrTestClass : IDbShop
    {
        private List<Shop> shops = new List<Shop>();
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
            returnedShop.Name = shop.Name;
            returnedShop.Address = shop.Address;
            returnedShop.Cvr = shop.Cvr;
            returnedShop.Warehouses = shop.Warehouses;
            return 1;
        }

        public List<Shop> FindAllShops()
        {
            return shops;
        }

        public List<Shop> FindAllShopsByChainId(int chainId)
        {
            return shops.Where(shop => shop.Chain.Id == chainId).ToList();
        }

        public Shop FindShop(int id)
        {
            return shops.FirstOrDefault(shop => shop.Id == id);
        }
    }
}
