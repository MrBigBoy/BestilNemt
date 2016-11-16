using System.Collections.Generic;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class WarehouseUnitTest
    {
        [TestMethod]
        public void WarehouseCtrInitialize()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Assert.IsNotNull(warehouseCtr);
        }

        [TestMethod]
        public void AddWarehouseDb()
        {
            var dbWarehouse = new DbWarehouse();
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = dbWarehouse.AddWarehouse(warehouse);
            dbWarehouse.DeleteWarehouse(i);
            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void FindWarehouseDb()
        {
            var dbWarehouse = new DbWarehouse();
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = dbWarehouse.AddWarehouse(warehouse);
            var j = dbWarehouse.FindWarehouse(i);
            dbWarehouse.DeleteWarehouse(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindAllWarehouseDb()
        {
            var dbWarehouse = new DbWarehouse();
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = dbWarehouse.AddWarehouse(warehouse);
            var i2 = dbWarehouse.AddWarehouse(warehouse);
            var j = dbWarehouse.FindAllWarehouses();
            dbWarehouse.DeleteWarehouse(i);
            dbWarehouse.DeleteWarehouse(i2);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void DeleteWarehouseDb()
        {
            var dbWarehouse = new DbWarehouse();
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = dbWarehouse.AddWarehouse(warehouse);
            var j = dbWarehouse.DeleteWarehouse(i);
            Assert.AreEqual(1, j);
        }

        [TestMethod]
        public void AddWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            warehouseCtr.DeleteWarehouse(i);
            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void AddWarehouseCtrFailShop()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = null,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            warehouseCtr.DeleteWarehouse(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddWarehouseCtrFailProduct()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var shop = new Shop()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = null,
                Shop = shop,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            warehouseCtr.DeleteWarehouse(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void AddWarehouseCtrFailBoth()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = null,
                Shop = null,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            warehouseCtr.DeleteWarehouse(i);
            Assert.AreEqual(0, i);
        }

        [TestMethod]
        public void FindWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            var j = warehouseCtr.FindWarehouse(i);
            warehouseCtr.DeleteWarehouse(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindWarehouseCtrFailShop()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = null,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            var j = warehouseCtr.FindWarehouse(i);
            warehouseCtr.DeleteWarehouse(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindWarehouseCtrFailProduct()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var shop = new Shop()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = null,
                Shop = shop,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            var j = warehouseCtr.FindWarehouse(i);
            warehouseCtr.DeleteWarehouse(i);
            Assert.IsNull(j);
        }

        [TestMethod]
        public void FindWarehouseCtrFailBoth()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = new Product(1, "Product name", 2,"Product description", "Product category", 1),
                Shop = new Shop(1, "Shop name", "Shop address", "Shop cvr", new List<Person>(), new List<Warehouse>()),
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            var j = warehouseCtr.FindWarehouse(i);
            warehouseCtr.DeleteWarehouse(i);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void FindAllWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            var i2 = warehouseCtr.AddWarehouse(warehouse);
            var j = warehouseCtr.FindAllWarehouses();
            warehouseCtr.DeleteWarehouse(i);
            warehouseCtr.DeleteWarehouse(i2);
            Assert.IsNotNull(j);
        }

        [TestMethod]
        public void DeleteWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var shop = new Shop()
            {
                Id = 1
            };
            var product = new Product()
            {
                Id = 1
            };
            var warehouse = new Warehouse()
            {
                MinStock = 0,
                Product = product,
                Shop = shop,
                Stock = 2
            };
            var i = warehouseCtr.AddWarehouse(warehouse);
            var j = warehouseCtr.DeleteWarehouse(i);
            Assert.AreEqual(1, j);
        }

        [TestMethod]
        public void DeleteWarehouseCtrFailId()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var j = warehouseCtr.DeleteWarehouse(0);
            Assert.AreEqual(0, j);
        }
    }
}
