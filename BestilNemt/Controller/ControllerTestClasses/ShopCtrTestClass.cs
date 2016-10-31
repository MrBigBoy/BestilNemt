using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class ShopCtrTestClass : IDbShop
    {

        private List<Shop> shops = new List<Shop>();
        private int idCounter = 1;
        private int flag = 0;

        public Shop GetShop(int id)
        {
            return shops.FirstOrDefault(shop => shop.Id == id);
        }

        public int AddShop(Shop shop)
        {
            shop.Id = idCounter;
            if (shop.CVR.Length != 8)
                return flag;
            flag = 1;
            shops.Add(shop);
            idCounter++;

            return flag;
        }

        public List<Shop> GetAllShops()
        {
            return shops;
        }

        public int UpdateShop(Shop shop)
        {
            var returnedShop = GetShop(shop.Id);
            returnedShop.Name = shop.Name;
            returnedShop.Address = shop.Address;
            returnedShop.CVR = shop.CVR;
            returnedShop.Persons = shop.Persons;
            returnedShop.Warehouses = shop.Warehouses;
            return 1;
        }

        /// <summary>
        /// if shop was removes return 1 else 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteShop(int id)
        {
            return shops.Remove(GetShop(id)) ? 1 : 0;
        }
    }
}
