using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class ShopCRUDTest
    {
        ShopCtr shopCtr = new ShopCtr();
        //BestilNemtServiceRef.BestilNemtServiceClient Client;

        public ShopCRUDTest()
        {
            shopCtr = new ShopCtr();
            //Client = new BestilNemtServiceRef.BestilNemtServiceClient();
        }


        [TestMethod]
        public void FindShopTest()
        {
           // int id = 1;
           
            Shop shop = shopCtr.GetShop(1);
            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void AddShopTest()
        {
            Shop curShop = new Shop();
            curShop.Name = "Netto";
            curShop.Address = "Nyvej";
            curShop.CVR = "12121212";
            int i = 0;
            i = shopCtr.AddShop(curShop);


            // Shop shop = shopCtr.GetShop(curShop.Id);

            Assert.IsTrue(i == 1);
        }

    }
}
