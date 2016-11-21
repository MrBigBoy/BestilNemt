using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //Controller test
        [TestMethod]
        public void WarehouseCtrInitialize()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Assert.IsNotNull(warehouseCtr);
        }

        [TestMethod]
        public void AddWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse = new Warehouse(10, 5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailMinStockCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse = new Warehouse(10, -5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseMinStockZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse = new Warehouse(10, 0, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailStockCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse = new Warehouse(-1, 5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseStockZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse = new Warehouse(0, 5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailShopNullCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse = new Warehouse(10, 5, new Product(), null);
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void FindWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            int id1 = warehouseCtr.AddWarehouse(warehouse1);
            int id2 = warehouseCtr.AddWarehouse(warehouse2);
            var rw = warehouseCtr.FindWarehouse(id1);
            Assert.IsNotNull(rw);
        }

        [TestMethod]
        public void FindWarehouseInvalidIdCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            int id1 = warehouseCtr.AddWarehouse(warehouse1);
            int id2 = warehouseCtr.AddWarehouse(warehouse2);
            var rw = warehouseCtr.FindWarehouse(0);
            Assert.IsNull(rw);
        }

        [TestMethod]
        public void FindAllWarehousesCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            var count = warehouseCtr.FindAllWarehouses().Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void FindAllWarehousesByShopIdCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop(1, "bfvndcm", "bnfvs", "12312312", null, null));
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "12312312", null, null));
            var warehouse3 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "12312312", null, null));
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            warehouseCtr.AddWarehouse(warehouse3);
            var count = warehouseCtr.FindAllWarehousesByShopId(2).Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void FindAllWarehousesByShopId1Ctr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop(1, "bfvndcm", "bnfvs", "12312312", null, null));
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "12312312", null, null));
            var warehouse3 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "12312312", null, null));
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            warehouseCtr.AddWarehouse(warehouse3);
            var count = warehouseCtr.FindAllWarehousesByShopId(1).Count;
            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void UpdateWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouseToUpdate = new Warehouse(10, 5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouseToUpdate);
            var warehouseNew = new Warehouse(id, 1, 3, new Product(), new Shop());
            var flag = warehouseCtr.UpdateWarehouse(warehouseNew);
            var updatedWarehouse = warehouseCtr.FindWarehouse(id);
            Assert.AreEqual(warehouseNew.Stock, updatedWarehouse.Stock);
        }

        //Db test

        [TestMethod]
        public void AddWarehouseDb()
        {
            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };
            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            Warehouse warehouse = new Warehouse(10, 5, prod, shop);
            var warehouseDb = new DbWarehouse();
            int id = warehouseDb.AddWarehouse(warehouse);
            warehouseDb.DeleteWarehouse(id);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void FindWarehouseDb()
        {
            var warehouseDb = new DbWarehouse();

            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };
            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            Warehouse warehouse = new Warehouse(10, 5, prod, shop);
            int id = warehouseDb.AddWarehouse(warehouse);
            var rw = warehouseDb.FindWarehouse(id);
            Assert.IsNotNull(rw);
        }

        [TestMethod]
        public void FindWarehouseFailDb()
        {
            var warehouseDb = new DbWarehouse();
            var rw = warehouseDb.FindWarehouse(0);
            Assert.IsNull(rw);
        }

        [TestMethod]
        public void FindAllWarehousesDb()
        {
            var warehouseDb = new DbWarehouse();
            var count = warehouseDb.FindAllWarehouses().Count;
            Assert.AreNotEqual(0, count);
        }


        [TestMethod]
        public void FindAllWarehousesByShopIdDb()
        {
            var warehouseDb = new DbWarehouse();
            var count = warehouseDb.FindAllWarehousesByShopId(1).Count;
            Assert.AreNotEqual(0, count);
        }

        [TestMethod]
        public void UpdateWarehouseDb()
        {
            var warehouseDb = new DbWarehouse();
            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };
            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            var warehouseToUpdate = new Warehouse(1, 1, prod, shop);
            var id = warehouseDb.AddWarehouse(warehouseToUpdate);
            var warehouseNew = new Warehouse(id, 100, 50, prod, shop);
            warehouseDb.UpdateWarehouse(warehouseNew);
            var updatedWarehouse = warehouseDb.FindWarehouse(id);
            Assert.AreEqual(warehouseNew.Stock, updatedWarehouse.Stock);
        }

        //Wcf test
        [TestMethod]
        public void AddWarehouseWcf()
        {
            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };
            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            Warehouse warehouse = new Warehouse(10, 5, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                int id = proxy.AddWarehouse(warehouse);
                proxy.DeleteWarehouse(id);
                Assert.AreNotEqual(0, id);
            }
        }

        [TestMethod]
        public void FindWarehouseWcf()
        {
            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };
            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            Warehouse warehouse1 = new Warehouse(10, 5, prod, shop);
            Warehouse warehouse2 = new Warehouse(10, 5, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                int id1 = proxy.AddWarehouse(warehouse1);
                int id2 = proxy.AddWarehouse(warehouse2);
                var rw = proxy.FindWarehouse(id1);
                proxy.DeleteWarehouse(id1);
                proxy.DeleteWarehouse(id2);
                Assert.IsNotNull(rw);
            }
        }

        [TestMethod]
        public void FindWarehouseFailWcf()
        {
            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };

            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };

            Warehouse warehouse1 = new Warehouse(10, 5, prod, shop);
            Warehouse warehouse2 = new Warehouse(10, 5, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                int id1 = proxy.AddWarehouse(warehouse1);
                int id2 = proxy.AddWarehouse(warehouse2);
                proxy.DeleteWarehouse(id1);
                var rw = proxy.FindWarehouse(id1);
                proxy.DeleteWarehouse(id2);
                Assert.IsNull(rw);
            }
        }

        [TestMethod]
        public void FindAllWarehousesWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var count = proxy.FindAllWarehouses().Count();
                Assert.AreNotEqual(0, count);
            }
        }

        [TestMethod]
        public void FindAllWarehousesByShopIdWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var count = proxy.FindAllWarehousesByShopId(1).Count();
                Assert.AreNotEqual(0, count);
            }
        }

        [TestMethod]
        public void UpdateWarehouseWcf()
        {
            var prod = new Product
            {
                Id = 1,
                Category = "category",
                Description = "ddeskr",
                Name = "banan",
                Price = 10,
                SavingId = 1
            };
            var shop = new Shop
            {
                Id = 1,
                Name = "ShopName",
                Address = "new addr",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            var warehouseToUpdate = new Warehouse(1, 1, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var id = proxy.AddWarehouse(warehouseToUpdate);
                var warehouseNew = new Warehouse(id, 100, 50, prod, shop);
                proxy.UpdateWarehouse(warehouseNew);
                var updatedWarehouse = proxy.FindWarehouse(id);
                proxy.DeleteWarehouse(id);
                Assert.AreEqual(warehouseNew.Stock, updatedWarehouse.Stock);
            }
        }
    }
}

