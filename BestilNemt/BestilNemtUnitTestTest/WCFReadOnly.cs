using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class WCFReadOnly
    {
        private BestilNemtServiceRef.BestilNemtServiceClient Proxy = new BestilNemtServiceRef.BestilNemtServiceClient();

  
        [TestMethod]
        public void GetShopTestWCF()
        {

            Shop shop = Proxy.GetShop(1);
            Assert.AreEqual(1, shop.id); 
        }
        [TestMethod]
        public void GetWarehouseTestWCF()
        {
            Warehouse warehouse = Proxy.GetWarehouse(1);
            Assert.AreEqual(1,warehouse.Id);
            

        }
    }
}
