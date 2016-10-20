using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using Controller;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BestilNemtService : IBestilNemtService
    {
        public ShopCtr ShopCtr { get; set; }

        public BestilNemtService()
        {
            ShopCtr = new ShopCtr();
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Shop GetShop(int id)
        {
            return ShopCtr.GetShop(id);
        }

        public List<Shop> GetAllShops()
        {
            return ShopCtr.GetAllShops();
        }

        public void DeleteShop(int id)
        {
            ShopCtr.DeleteShop(id);
        }

        public void AddShop(Shop shop)
        {
            ShopCtr.AddShop(shop);
        }

        public void UpdateShop(Shop shop)
        {
            ShopCtr.UpdateShop(shop);
        }
    }
}
