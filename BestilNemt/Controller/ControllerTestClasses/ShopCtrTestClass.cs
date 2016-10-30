using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class ShopCtrTestClass: IDbShop
    {

        private List<Shop> shops = new List<Shop>();
        private int idCounter = 0;
        private int flag = 0;

        public Shop GetShop(int id)
        {
            throw new NotImplementedException();
        }

        public int AddShop(Shop shop)
        {
            shop.Id = idCounter;
            if (shop.CVR.Length == 8)
            {
                flag = 1;
            }
            shops.Add(shop);
            idCounter++;
            return flag;
        }

        public List<Shop> GetAllShops()
        {
            throw new NotImplementedException();
        }

        public int UpdateShop(Shop shop)
        {
            throw new NotImplementedException();
        }

        public int DeleteShop(int id)
        {
            throw new NotImplementedException();
        }
    }
}
