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

        //this test method connects to the WCF, by using the service reference and then returns a chain with the id 1
        //this method is also used to see if we can connect to the WCF service

        [TestMethod]
        public void GetChainTestWCF()
        {
            var chain = Proxy.GetChain(1);
            Assert.AreEqual(1, chain.Id);
        }
        [TestMethod]
        public void GetShopTestWCF()
        {
            var shop = Proxy.GetShop(1);
            Assert.AreEqual(1, shop.Id);
        }
    }
}
