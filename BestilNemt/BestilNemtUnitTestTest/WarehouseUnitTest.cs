using System.Collections.Generic;
using System.Linq;
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
            var warehouse = new Warehouse(10, 5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailMinStockCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse(10, -5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseMinStockZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse(10, 0, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailStockCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse(-1, 5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseStockZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse(0, 5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailShopNullCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse = new Warehouse(10, 5, new Product(), null);
            var id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void GetWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            var id1 = warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            var rw = warehouseCtr.GetWarehouse(id1);
            Assert.IsNotNull(rw);
        }

        [TestMethod]
        public void GetWarehouseInvalidIdCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            var rw = warehouseCtr.GetWarehouse(0);
            Assert.IsNull(rw);
        }

        [TestMethod]
        public void GetAllWarehousesCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            var count = warehouseCtr.GetAllWarehouses().Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetAllWarehousesByShopIdCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop(1, "bfvndcm", "bnfvs", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "12312312", null, null));
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "12312312", null, null));
            var warehouse3 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "12312312", null, null));
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            warehouseCtr.AddWarehouse(warehouse3);
            var count = warehouseCtr.GetAllWarehousesByShopId(2).Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetAllWarehousesByShopId1Ctr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop(1, "bfvndcm", "bnfvs", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "12312312", null, null));
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "12312312", null, null));
            var warehouse3 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "12312312", null, null));
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            warehouseCtr.AddWarehouse(warehouse3);
            var count = warehouseCtr.GetAllWarehousesByShopId(1).Count;
            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void UpdateWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseCtrTestClass());
            var warehouseToUpdate = new Warehouse(10, 5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouseToUpdate);
            var warehouseNew = new Warehouse(id, 1, 3, new Product(), new Shop());
            warehouseCtr.UpdateWarehouse(warehouseNew);
            var updatedWarehouse = warehouseCtr.GetWarehouse(id);
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
                OpeningTime = "Manday Never",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            var warehouse = new Warehouse(10, 5, prod, shop);
            var warehouseDb = new DbWarehouse();
            var id = warehouseDb.AddWarehouse(warehouse);
            warehouseDb.DeleteWarehouse(id);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void GetWarehouseDb()
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
                OpeningTime = "Manday Never",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            var warehouse = new Warehouse(10, 5, prod, shop);
            var id = warehouseDb.AddWarehouse(warehouse);
            var rw = warehouseDb.GetWarehouse(id);
            Assert.IsNotNull(rw);
        }

        [TestMethod]
        public void GetWarehouseFailDb()
        {
            var warehouseDb = new DbWarehouse();
            var rw = warehouseDb.GetWarehouse(0);
            Assert.IsNull(rw);
        }

        [TestMethod]
        public void GetAllWarehousesDb()
        {
            var warehouseDb = new DbWarehouse();
            var count = warehouseDb.GetAllWarehouses().Count;
            Assert.AreNotEqual(0, count);
        }


        [TestMethod]
        public void GetAllWarehousesByShopIdDb()
        {
            var warehouseDb = new DbWarehouse();
            var count = warehouseDb.GetAllWarehousesByShopId(1).Count;
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
                OpeningTime = "Manday Never",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            var warehouseToUpdate = new Warehouse(1, 1, prod, shop);
            var id = warehouseDb.AddWarehouse(warehouseToUpdate);
            var warehouseNew = new Warehouse(id, 100, 50, prod, shop);
            warehouseDb.UpdateWarehouse(warehouseNew);
            var updatedWarehouse = warehouseDb.GetWarehouse(id);
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
                OpeningTime = "Manday Never",
                Chain = new Chain(),
                Cvr = "12121212",
                Warehouses = new List<Warehouse>()
            };
            var warehouse = new Warehouse(10, 5, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var id = proxy.AddWarehouse(warehouse);
                proxy.DeleteWarehouse(id);
                Assert.AreNotEqual(0, id);
            }
        }

        [TestMethod]
        public void GetWarehouseWcf()
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
            var warehouse1 = new Warehouse(10, 5, prod, shop);
            var warehouse2 = new Warehouse(10, 5, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var id1 = proxy.AddWarehouse(warehouse1);
                var id2 = proxy.AddWarehouse(warehouse2);
                var rw = proxy.GetWarehouse(id1);
                proxy.DeleteWarehouse(id1);
                proxy.DeleteWarehouse(id2);
                Assert.IsNotNull(rw);
            }
        }

        [TestMethod]
        public void GetWarehouseFailWcf()
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

            var warehouse1 = new Warehouse(10, 5, prod, shop);
            var warehouse2 = new Warehouse(10, 5, prod, shop);
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var id1 = proxy.AddWarehouse(warehouse1);
                var id2 = proxy.AddWarehouse(warehouse2);
                proxy.DeleteWarehouse(id1);
                var rw = proxy.GetWarehouse(id1);
                proxy.DeleteWarehouse(id2);
                Assert.IsNull(rw);
            }
        }

        [TestMethod]
        public void GetAllWarehousesWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var count = proxy.GetAllWarehouses().Count();
                Assert.AreNotEqual(0, count);
            }
        }

        [TestMethod]
        public void GetAllWarehousesByShopIdWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var count = proxy.GetAllWarehousesByShopId(1).Count();
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
                var updatedWarehouse = proxy.GetWarehouse(id);
                proxy.DeleteWarehouse(id);
                Assert.AreEqual(warehouseNew.Stock, updatedWarehouse.Stock);
            }
        }
    }
}

