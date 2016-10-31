using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
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
        /// Test a ShopCtr for ShopCtrTestClass
        /// </summary>

        [TestMethod]
        public void ShopCtrInitializeFail()
        {
            // The test is successfull if cvr.length(8 char) => flag ==1 
            ShopCtr shopCtr = null;
            Assert.IsNull(shopCtr);
        }


        [TestMethod]
        public void ShopCtrInitialize()
        {
            // The test is successfull if cvr.length(8 char) => flag ==1 
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            Assert.IsNotNull(shopCtr);
        }

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

            Assert.IsNotNull(shopCtr.GetShop(1));
        }

        [TestMethod]
        public void GetShopByIdFail()
        {
            // The test is successfull if shop id is not found

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);

            Assert.IsNull(shopCtr.GetShop(2));
        }

        [TestMethod]
        public void GetAllShops()
        {
            // The test is successfull if the list of shops is two

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            var shop2 = new Shop("MiniShop", "Address", "21212121");
            shopCtr.AddShop(shop);
            shopCtr.AddShop(shop2);
            Assert.AreEqual(2, shopCtr.GetAllShops().Count);
        }

        [TestMethod]
        public void UpdateShopCheckFlag()
        {
            // The test is successfull if the name of the shop is "Hello World"

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            shop.Name = "Hello World";
            var flag = shopCtr.UpdateShop(shop);
            Assert.AreEqual(1, flag);
        }


        [TestMethod]
        public void UpdateShopCheckName()
        {
            // The test is successfull if the name of the shop is "Hello World"

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            var shop2 = new Shop(1, "Hello World", "Address", "12121212");
            shopCtr.UpdateShop(shop2);
            var returnedShop = shopCtr.GetShop(1);
            Assert.AreEqual("Hello World", returnedShop.Name);
        }

        [TestMethod]
        public void DeleteShopById()
        {
            // The test is successfull if the id was found and list.count == 0

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            var id = shopCtr.DeleteShop(shop.Id);
            Assert.AreEqual(1, id);
        }


        [TestMethod]
        public void DeleteShopByIdFail()
        {
            // The test is successfull if the id was found and list.count == 0

            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            var id = shopCtr.DeleteShop(shop.Id);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test a Connection to Database
        /// </summary>
        [TestMethod]
        public void TestConnectionToDb()
        {
            // The test is successfull if the id was found and list.count == 0
            var dbShop = new DbShop();
            Assert.IsTrue(dbShop.IsOpen());
        }

        /// <summary>
        /// Test a DbShop
        /// </summary>
        [TestMethod]
        public void AddDbShop()
        {
            // The test is successfull if the returned id is not 0

            var dbShop = new DbShop();
            var shop = new Shop("MiniShop", "Address", "12121212");
            var id = dbShop.AddShop(shop);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void GetDbShop()
        {
            // The test is successfull if the shop is not null
            var dbShop = new DbShop();
            var shop = dbShop.GetShop(1);
            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void UpdateDbShop()
        {
            // The test is successfull if the returned value is 1
            var dbShop = new DbShop();
            var shop = new Shop(1, "Test World", "Test Adress", "12121212");
            var returnedValue = dbShop.UpdateShop(shop);
            Assert.AreEqual(1, returnedValue);
        }

        [TestMethod]
        public void UpdateDbShopFail()
        {
            // The test is successfull if the returned value is not 1 because there is no shop with id = 0
            var dbShop = new DbShop();
            var shop = new Shop(0, "Test World", "Test Adress", "12121212");
            var returnedValue = dbShop.UpdateShop(shop);
            Assert.AreNotEqual(1, returnedValue);
        }

        [TestMethod]
        public void DelDbShop()
        {
            // The test is successfull if the returned value is 1
            // Requere testMethod AddDbShop
            var dbShop = new DbShop();
            var shop = new Shop("Test World", "Test Adress", "12121212");
            var id = dbShop.AddShop(shop);
            var returnedValue = dbShop.DeleteShop(id);
            Assert.AreEqual(1, returnedValue);
        }

        [TestMethod]
        public void GetAllDbShop()
        {
            // The test is successfull if the returned value is 1
            // Requere testMethod AddDbShop
            var dbShop = new DbShop();
            Assert.AreNotEqual(0, dbShop.GetAllShops().Count);
        }
    }
}
