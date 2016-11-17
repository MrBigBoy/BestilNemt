using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.ControllerTestClasses;
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
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Assert.IsNotNull(warehouseCtr);
        }

        [TestMethod]
        public void AddWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse = new Warehouse(10, 5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailMinStockCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse = new Warehouse(10, -5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseMinStockZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse = new Warehouse(10, 0, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailStockCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse = new Warehouse(-1, 5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseStockZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse = new Warehouse(0, 5, new Product(), new Shop());
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void AddWarehouseFailShopNullCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse = new Warehouse(10, 5, new Product(), null);
            int id = warehouseCtr.AddWarehouse(warehouse);
            Assert.AreEqual(0, id);
        }

        [TestMethod]
        public void FindWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            int id1 = warehouseCtr.AddWarehouse(warehouse1);
            int id2 = warehouseCtr.AddWarehouse(warehouse2);
            var rw = warehouseCtr.FindWarehouse(id1);
            Assert.IsNotNull(rw);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindWarehouseInvalidIdCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            int id1 = warehouseCtr.AddWarehouse(warehouse1);
            int id2 = warehouseCtr.AddWarehouse(warehouse2);
            var rw = warehouseCtr.FindWarehouse(0);
        }

        [TestMethod]
        public void FindAllWarehousesCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            warehouseCtr.AddWarehouse(warehouse1);
            warehouseCtr.AddWarehouse(warehouse2);
            var count = warehouseCtr.FindAllWarehouses().Count;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void FindAllWarehousesFailCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            warehouseCtr.AddWarehouse(warehouse1);
            var count = warehouseCtr.FindAllWarehouses().Count;
            Assert.AreNotEqual(2, count);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindAllWarehouseFail1Ctr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            Warehouse warehouse1 = new Warehouse(10, 5, new Product(), new Shop());
            Warehouse warehouse2 = new Warehouse(1, 3, new Product(), new Shop());
            var count = warehouseCtr.FindAllWarehouses().Count;
        }

        [TestMethod]
        public void FindAllWarehousesByShopIdCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
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
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
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
        [ExpectedException(typeof(NullReferenceException))]
        public void FindAllWarehousesByShopIdZeroCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            var warehouse1 = new Warehouse(10, 5, new Product(), new Shop(1, "bfvndcm", "bnfvs", "12312312", null, null));
            var warehouse2 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "12312312", null, null));
            var warehouse3 = new Warehouse(1, 3, new Product(), new Shop(2, "bfvndcm", "bnfvs", "12312312", null, null));
            var count = warehouseCtr.FindAllWarehousesByShopId(2).Count;
        }

        [TestMethod]
        public void UpdateWarehouseCtr()
        {
            var warehouseCtr = new WarehouseCtr(new WarehouseTestClass());
            var warehouseToUpdate = new Warehouse(10, 5, new Product(), new Shop());
            var id = warehouseCtr.AddWarehouse(warehouseToUpdate);
            var warehouseNew = new Warehouse(id, 1, 3, new Product(), new Shop());
            var flag = warehouseCtr.UpdateWarehouse(warehouseNew);
            var updatedWarehouse = warehouseCtr.FindWarehouse(id);
            Assert.AreEqual(warehouseNew.Stock, updatedWarehouse.Stock);
        }

    }
}
