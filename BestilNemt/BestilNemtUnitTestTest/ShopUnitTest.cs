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
        /// Test a ShopCtr constructor
        /// The test is successfull if the instance is not null
        /// </summary>
        [TestMethod]
        public void ShopCtrInitialize()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            Assert.IsNotNull(shopCtr);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void AddShop()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            var flag = shopCtr.AddShop(shop);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned value is 0
        /// Cvr is not 8 char
        /// </summary>
        [TestMethod]
        public void AddShopInvalidCvr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "323232");
            var flag = shopCtr.AddShop(shop);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if shop is found (not null)
        /// </summary>
        [TestMethod]
        public void GetShopById()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            Assert.IsNotNull(shopCtr.GetShop(1));
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if shop is not found (null)
        /// </summary>
        [TestMethod]
        public void GetShopByIdFail()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            Assert.IsNull(shopCtr.GetShop(2));
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if the list of shops is two
        /// </summary>
        [TestMethod]
        public void GetAllShops()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            var shop2 = new Shop("MiniShop", "Address", "21212121");
            shopCtr.AddShop(shop);
            shopCtr.AddShop(shop2);
            Assert.AreEqual(2, shopCtr.GetAllShops().Count);
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned value = 1
        /// </summary>
        [TestMethod]
        public void UpdateShopCheckFlag()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            shop.Name = "Hello World";
            var flag = shopCtr.UpdateShop(shop);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned name equals "Hello World"
        /// </summary>
        [TestMethod]
        public void UpdateShopCheckName()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            var shop2 = new Shop
            {
                Id = 1,
                Name = "Hello World",
                Address = "Address",
                CVR = "12121212"
            };
            shopCtr.UpdateShop(shop2);
            var returnedShop = shopCtr.GetShop(1);
            Assert.AreEqual("Hello World", returnedShop.Name);
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned value is 1
        /// </summary>
        [TestMethod]
        public void DeleteShopById()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop("MiniShop", "Address", "12121212");
            shopCtr.AddShop(shop);
            var id = shopCtr.DeleteShop(shop.Id);
            Assert.AreEqual(1, id);
        }

        /// <summary>
        /// Test a ShopCtr with the ShopCtrTestClass (simulate Db) 
        /// The test is successfull if the reutrned value is 1
        /// </summary>
        [TestMethod]
        public void DeleteShopByIdFail()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop
            {
                Name = "MiniShop",
                Address = "Adress",
                CVR = "12121212"
            };
            shopCtr.AddShop(shop);
            var id = shopCtr.DeleteShop(shop.Id);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test a Connection to Database
        /// The test is successfull if the connection is open (==true)
        /// </summary>
        [TestMethod]
        public void TestConnectionToDb()
        {
            var dbShop = new DbShop();
            Assert.IsTrue(dbShop.IsOpen());
        }

        /// <summary>
        /// Test af DbShop
        /// The test is successfull if the returned id is not 0
        /// </summary>
        [TestMethod]
        public void AddDbShop()
        {
            var dbShop = new DbShop();
            var shop = new Shop("MiniShop", "Address", "12121212");
            var id = dbShop.AddShop(shop);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test af dbShop
        /// The test is successfull if the shop is not null
        /// </summary>
        [TestMethod]
        public void GetDbShop()
        {
            var dbShop = new DbShop();
            var shop = dbShop.GetShop(1);
            Assert.IsNotNull(shop);
        }

        /// <summary>
        /// Test af dbShop
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void UpdateDbShop()
        {
            var dbShop = new DbShop();
            var shop = new Shop
            {
                Id = 1,
                Name = "Test World",
                Address = "ADrerreth",
                CVR = "12121212"
            };
            var returnedValue = dbShop.UpdateShop(shop);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test af dbShop
        /// The test is successfull if the returned value is not 1
        /// because there is no shop with id = 0
        /// </summary>
        [TestMethod]
        public void UpdateDbShopFail()
        {
            var dbShop = new DbShop();
            var shop = new Shop
            {
                Id = 0,
                Name = "Test World",
                Address = "jksagdhfgujn",
                CVR = "12121212"
            };
            var returnedValue = dbShop.UpdateShop(shop);
            Assert.AreNotEqual(1, returnedValue);
        }

        /// <summary>
        /// Test af dbShop
        /// The test is successfull if the returned value is 1
        /// Require testMethod AddDbShop
        /// </summary>
        [TestMethod]
        public void DelDbShop()
        {
            var dbShop = new DbShop();
            var shop = new Shop("Test World", "Test Adress", "12121212");
            var id = dbShop.AddShop(shop);
            var returnedValue = dbShop.DeleteShop(id);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test af dbShop
        /// The test is successfull if the returned value is 1
        /// Require testMethod AddDbShop
        /// </summary>
        [TestMethod]
        public void GetAllDbShop()
        {
            var dbShop = new DbShop();
            Assert.AreNotEqual(0, dbShop.GetAllShops().Count);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned id is  not 0
        /// </summary>
        [TestMethod]
        public void AddCtrDbShop()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop("MiniShop", "Address", "12121212");
            var id = shopCtr.AddShop(shop);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned id is 0
        /// Name is empty
        /// </summary>
        [TestMethod]
        public void AddCtrDbShopFailName()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop("", "Address", "12121212");
            var id = shopCtr.AddShop(shop);
            Assert.AreEqual(0, id);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned id is 0
        /// Address is empty
        /// </summary>
        [TestMethod]
        public void AddCtrDbShopFailAddress()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop("MiniShop", "", "12121212");
            var id = shopCtr.AddShop(shop);
            Assert.AreEqual(0, id);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned id is 0
        /// Cvr is not 8 char
        /// </summary>
        [TestMethod]
        public void AddCtrDbShopFailCvr()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop("MiniShop", "Nyvej", "12");
            var id = shopCtr.AddShop(shop);
            Assert.AreEqual(0, id);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the shop is not null
        /// </summary>
        [TestMethod]
        public void GetCtrDbShop()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = shopCtr.GetShop(1);
            Assert.IsNotNull(shop);
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void UpdateCtrDbShop()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop
            {
                Id = 1,
                Address = "fkgshdjk",
                Name = "Test World",
                CVR = "12121212"
            };
            var returnedValue = shopCtr.UpdateShop(shop);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a ShopCtr
        ///  The test is successfull if the returned value is not 1 
        /// because there is no shop with id = 0
        /// </summary>
        [TestMethod]
        public void UpdateCtrDbShopFail()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop
            {
                Id = 0,
                Name = "Test World",
                Address = "jfjgljlksj",
                CVR = "12121212"
            };
            var returnedValue = shopCtr.UpdateShop(shop);
            Assert.AreNotEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a ShopCtr
        ///  The test is successfull if the returned value is 1
        ///  Require testMethod AddDbShop 
        /// </summary>
        [TestMethod]
        public void DelCtrDbShop()
        {
            var shopCtr = new ShopCtr(new DbShop());
            var shop = new Shop("Test World", "Test Adress", "12121212");
            var id = shopCtr.AddShop(shop);
            var returnedValue = shopCtr.DeleteShop(id);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a ShopCtr
        ///  The test is successfull if the returned value is 1
        ///  Require testMethod AddDbShop 
        /// </summary>
        [TestMethod]
        public void GetAllCtrDbShop()
        {
            var shopCtr = new ShopCtr(new DbShop());
            Assert.AreNotEqual(0, shopCtr.GetAllShops().Count);
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned id is not 0
        /// </summary>
        [TestMethod]
        public void AddShopWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var shop = new Shop("new shop", "new address", "15987533");
                var i = proxy.AddShop(shop);
                Assert.AreNotEqual(0, i);
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned id is 0
        /// Cvr is not 8 char
        /// </summary>
        [TestMethod]
        public void AddShopWcfFailCvr()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var shop = new Shop("new shop", "new address", "87533");
                var i = proxy.AddShop(shop);
                Assert.AreEqual(0, i);
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned id is 0
        /// Name is empty
        /// </summary>
        [TestMethod]
        public void AddShopWcfFailName()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var shop = new Shop("", "new address", "82227533");
                var i = proxy.AddShop(shop);
                Assert.AreEqual(0, i);
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned id is 0
        /// Address is empty
        /// </summary>
        [TestMethod]
        public void AddShopWcfFailAddress()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var shop = new Shop("Fine Name", "", "82227533");
                var i = proxy.AddShop(shop);
                Assert.AreEqual(0, i);
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned object is not null 
        /// </summary>
        [TestMethod]
        public void FindShopWcfById()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.IsNotNull(proxy.GetShop(1));
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned object is null 
        /// </summary>
        [TestMethod]
        public void FindShopWcfByIdFail()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.IsNull(proxy.GetShop(150));
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned list is not empty 
        /// </summary>
        [TestMethod]
        public void FindAllShopWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.AreNotEqual(0, proxy.GetAllShops().Length);
            }
        }

        /// <summary>
        /// Test a ShopCtr
        /// The test is successfull if the returned object name is the same given new name
        /// </summary>
        [TestMethod]
        public void UpdateShopWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var shop = new Shop("MiniShop", "Address", "12121212");
                var returnedId = proxy.AddShop(shop);
                var shop1 = new Shop
                {
                    Id = returnedId,
                    Name = "UpdatedName",
                    Address = "Address",
                    CVR = "12121212"
                };
                proxy.UpdateShop(shop1);
                var returnedShop = proxy.GetShop(returnedId);
                Assert.AreEqual("UpdatedName", returnedShop.Name);
            }
        }

        /// <summary>
        /// Test Shop through Wcf
        /// The test is successfull if the returned object is not null 
        /// </summary>
        [TestMethod]
        public void DeleteShopWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var shop = new Shop("ShopToDelete", "Address", "12121212");
                var returnedId = proxy.AddShop(shop);
                var flag = proxy.DeleteShop(returnedId);
                Assert.AreEqual(1, flag);
            }
        }
    }
}

