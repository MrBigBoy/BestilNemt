using System.Collections.Generic;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class ShopUnitTest
    {
        [TestMethod]
        public void ShopCtrInitialize()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            Assert.IsNotNull(shopCtr);
        }

        [TestMethod]
        public void AddShopDb()
        {
            var dbShop = new DbShop();
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Address = "",
                    CVR = "",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = dbShop.AddShop(shop);
            dbShop.DeleteShop(i);
            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void FindShopDb()
        {
            var dbShop = new DbShop();
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain()
            };
            var i = dbShop.AddShop(shop);
            var j = dbShop.FindShop(i);
            dbShop.DeleteShop(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindAllShopDb()
        {
            var dbShop = new DbShop();
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Address = "",
                    CVR = "",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = dbShop.AddShop(shop);
            var i2 = dbShop.AddShop(shop);
            var j = dbShop.FindAllShops();
            dbShop.DeleteShop(i);
            dbShop.DeleteShop(i2);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void DeleteShopDb()
        {
            var dbShop = new DbShop();
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Address = "",
                    CVR = "",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = dbShop.AddShop(shop);
            var j = dbShop.DeleteShop(i);
            Assert.AreEqual(1, j);
        }

        [TestMethod]
        public void AddShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailName()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = null,
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailName2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailAddress()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = null,
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailAddress2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailCvr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = null,
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailCvr2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailBoth()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = null,
                Address = null,
                Cvr = null,
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailBoth2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "",
                Address = "",
                Cvr = "",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailWarehouse()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = null,
                Address = null,
                Cvr = null,
                Warehouses = null
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void FindShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailName()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = null,
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailName2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailAddress()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = null,
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailAddress2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailCvr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = null,
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailCvr2()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailWarehouse()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "12121212",
                Warehouses = null,
                Chain = null
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailAll()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = null,
                Address = null,
                Cvr = null,
                Warehouses = null
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindAllShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var i2 = shopCtr.AddShop(shop);
            var j = shopCtr.FindAllShops();
            shopCtr.DeleteShop(i);
            shopCtr.DeleteShop(i2);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void DeleteShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>()
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.DeleteShop(i);
            Assert.AreEqual(1, j);
        }

        [TestMethod]
        public void DeleteShopCtrFailId()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var j = shopCtr.DeleteShop(0);
            Assert.AreEqual(0, j);
        }
    }
}
