﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class PartOrderUnitTest
    {
        [TestMethod]
        public void PartOrderInitialize()
        {
            var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
            Assert.IsNotNull(partOrderCtr);
        }

        [TestMethod]
        public void AddPartOrder()
        {
            var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
            var partOrder = new PartOrder(1, new Product(), 2, 10, new Cart());
            var flag = partOrderCtr.AddPartOrder(partOrder);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void GetPartOrderById()
        {
            var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
            var partOrder1 = new PartOrder(new Product(), 2, 10, new Cart());
            var partOrder2 = new PartOrder(new Product(), 10, 10, new Cart());
            var id1 = partOrderCtr.AddPartOrder(partOrder1);
            var id2 = partOrderCtr.AddPartOrder(partOrder2);
            Assert.IsNotNull(partOrderCtr.FindPartOrder(id1));
        }

        [TestMethod]
        public void GetPartOrderByIdFail()
        {
            var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
            var partOrder1 = new PartOrder(new Product(), 2, 10, new Cart());
            var partOrder2 = new PartOrder(new Product(), 2, 10, new Cart());
            var id1 = partOrderCtr.AddPartOrder(partOrder1);
            var id2 = partOrderCtr.AddPartOrder(partOrder2);
            Assert.IsNull(partOrderCtr.FindPartOrder(10));
        }

        [TestMethod]
        public void GetAllPartOrders()
        {
            var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        }

        public void AddPartOrderCtrDb()
        {
            var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        }
    }
}