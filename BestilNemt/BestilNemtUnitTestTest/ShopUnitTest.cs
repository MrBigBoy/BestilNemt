using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using Models;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ShopUnitTest
    {
        /// <summary>
        /// Test a ShopCtr
        /// </summary>
        [TestMethod]
        public void AddShop()
        {
            // The test is successfull if cvr.length(8 char) => flag ==1 
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            var flag = shopCtr.AddShop(shop);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void AddShopInvalidCvr()
        {
            // The test is successfull if cvr is not valid and !cvr.length(8 char) => flag == 0

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "323232");
            var flag = shopCtr.AddShop(shop);
            Assert.AreEqual(0, flag);
        }

        [TestMethod]
        public void GetShopById()
        {
            // The test is successfull if shop id is found

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);

            Assert.AreEqual(shop, shopCtr.GetShop(1));
        }
    }
}
