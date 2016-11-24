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
                OpeningTime = "Manday Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
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
                OpeningTime = "Manday Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
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
                OpeningTime = "Manday Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
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
                OpeningTime = "Manday Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = null,
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
                Cvr = "",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                OpeningTime = "Manday Never",
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
                OpeningTime = "Manday Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
                OpeningTime = "Manday Never",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
                OpeningTime = "Manday Never",
                Cvr = null,
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
                OpeningTime = "Manday Never",
                Cvr = "",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            var i = shopCtr.AddShop(shop);
            var j = shopCtr.GetShop(i);
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
            var j = shopCtr.GetShop(i);
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
            var j = shopCtr.GetShop(i);
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
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
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

        [TestMethod]
        public void AddShopWcf()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                OpeningTime = "Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreNotEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailName()
        {
            var shop = new Shop()
            {
                Name = null,
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailName2()
        {
            var shop = new Shop()
            {
                Name = "",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailAddress()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = null,
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailAddress2()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailCvr()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = null,
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailCvr2()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailBoth()
        {
            var shop = new Shop()
            {
                Name = null,
                Address = null,
                Cvr = null,
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailBoth2()
        {
            var shop = new Shop()
            {
                Name = "",
                Address = "",
                Cvr = "",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void AddShopWcfFailWarehouse()
        {
            var shop = new Shop()
            {
                Name = null,
                Address = null,
                Cvr = null,
                Warehouses = null
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                proxy.DeleteShop(i);
                Assert.AreEqual(0, i);
            }
        }

        [TestMethod]
        public void FindShopWcf()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                OpeningTime = "Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNotNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailName()
        {
            var shop = new Shop()
            {
                Name = null,
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailName2()
        {
            var shop = new Shop()
            {
                Name = "",
                Address = "Hello address",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailAddress()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = null,
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailAddress2()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "",
                Cvr = "Hello Cvr",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailCvr()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = null,
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailCvr2()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailWarehouse()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                Cvr = "12121212",
                Warehouses = null,
                Chain = null
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindShopWcfFailAll()
        {
            var shop = new Shop()
            {
                Name = null,
                Address = null,
                Cvr = null,
                Warehouses = null
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                Assert.IsNull(j);
            }
        }

        [TestMethod]
        public void FindAllShopWcf()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                OpeningTime = "Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var i2 = proxy.AddShop(shop);
                var j = proxy.GetShop(i);
                proxy.DeleteShop(i);
                proxy.DeleteShop(i2);
                Assert.IsNotNull(j);
            }
        }

        [TestMethod]
        public void DeleteShopWcf()
        {
            var shop = new Shop()
            {
                Name = "hello world",
                Address = "Hello address",
                OpeningTime = "Never",
                Cvr = "12121212",
                Warehouses = new List<Warehouse>(),
                Chain = new Chain
                {
                    Id = 1,
                    Cvr = "12121212",
                    Name = "",
                    Persons = new List<Person>(),
                    Shops = new List<Shop>()
                }
            };
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.AddShop(shop);
                var j = proxy.DeleteShop(i);
                Assert.AreEqual(1, j);
            }
        }

        [TestMethod]
        public void DeleteShopWcfFailId()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var j = proxy.DeleteShop(0);
                Assert.AreEqual(0, j);
            }
        }
    }
}
