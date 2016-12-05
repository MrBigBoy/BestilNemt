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
        public void GetShopDb()
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
            var j = dbShop.GetShop(i);
            dbShop.DeleteShop(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void GetAllShopDb()
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
            var j = dbShop.GetAllShops();
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
        public void GetShopCtr()
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
        public void GetShopCtrFailName()
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
        public void GetShopCtrFailName2()
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
        public void GetShopCtrFailAddress()
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
        public void GetShopCtrFailAddress2()
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
        public void GetShopCtrFailCvr()
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
        public void GetShopCtrFailCvr2()
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
        public void GetShopCtrFailWarehouse()
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
        public void GetShopCtrFailAll()
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
        public void GetAllShopCtr()
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
            var j = shopCtr.GetAllShops();
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
        public void GetShopWcf()
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
        public void GetShopWcfFailName()
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
        public void GetShopWcfFailName2()
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
        public void GetShopWcfFailAddress()
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
        public void GetShopWcfFailAddress2()
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
        public void GetShopWcfFailCvr()
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
        public void GetShopWcfFailCvr2()
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
        public void GetShopWcfFailWarehouse()
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
        public void GetShopWcfFailAll()
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
        public void GetAllShopWcf()
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
