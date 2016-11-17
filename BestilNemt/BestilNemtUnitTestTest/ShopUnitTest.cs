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
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
            };
            var i = dbShop.AddShop(shop);
            dbShop.DeleteShop(i);
            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void FindShopDb()
        {
            var dbShop = new DbShop();
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
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
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
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
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
            };
            var i = dbShop.AddShop(shop);
            var j = dbShop.DeleteShop(i);
            Assert.AreEqual(1, j);
        }

        [TestMethod]
        public void AddShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailChain()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = null,
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddShopCtrFailProduct()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var chain = new Chain()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = null,
                Chain = chain,
                Stock = 2
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
                MinStock = 0,
                Product = null,
                Chain = null,
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            shopCtr.DeleteShop(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void FindShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailChain()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = null,
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailProduct()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var chain = new Chain()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = null,
                Chain = chain,
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindShopCtrFailBoth()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var shop = new Shop()
            {
                MinStock = 0,
                Product = new Product(1, "Product name", 2,"Product description", "Product category", 1),
               // Chain = new Chain(1, "Chain name", "Chain address", "Chain cvr", new List<Person>(), new List<Shop>()),
                Stock = 2
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.FindShop(i);
            shopCtr.DeleteShop(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindAllShopCtr()
        {
            var shopCtr = new ShopCtr(new ShopCtrTestClass());
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
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
            var chain = new Chain()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var shop = new Shop()
            {
                MinStock = 0,
                Product = product,
                Chain = chain,
                Stock = 2
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
