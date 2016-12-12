using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
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

        //[TestMethod]
        //public void GetPartOrderById()
        //{
        //    var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        //    var partOrder1 = new PartOrder(new Product(), 2, 10, new Cart());
        //    var partOrder2 = new PartOrder(new Product(), 10, 10, new Cart());
        //    var id1 = partOrderCtr.AddPartOrder(partOrder1);
        //    var id2 = partOrderCtr.AddPartOrder(partOrder2);
        //    Assert.IsNotNull(partOrderCtr.GetPartOrder(id1));
        //}

        //[TestMethod]
        //public void GetPartOrderByIdFail()
        //{
        //    var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        //    var partOrder1 = new PartOrder(new Product(), 2, 10, new Cart());
        //    var partOrder2 = new PartOrder(new Product(), 2, 10, new Cart());
        //    var id1 = partOrderCtr.AddPartOrder(partOrder1);
        //    var id2 = partOrderCtr.AddPartOrder(partOrder2);
        //    Assert.IsNull(partOrderCtr.GetPartOrder(10));
        //}

        //[TestMethod]
        //public void GetAllPartOrders()
        //{
        //    var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        //    var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", "Img path");
        //    var cart = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
        //    var partOrder1 = new PartOrder(product, 2, 10, cart);
        //    var partOrder2 = new PartOrder(product, 2, 10, cart);
        //    partOrderCtr.AddPartOrder(partOrder1);
        //    partOrderCtr.AddPartOrder(partOrder2);
        //    var partOrders = partOrderCtr.GetAllPartOrders();
        //    Assert.AreEqual(2, partOrders.Count);
        //}

        //[TestMethod]
        //public void UpdatePartOrderCtr()
        //{
        //    var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        //    var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", "Img path");
        //    var cart = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
        //    var partOrder = new PartOrder(product, 2, 10, cart);
        //    partOrderCtr.AddPartOrder(partOrder);
        //    partOrder = new PartOrder(product, 2, 20, cart);
        //    partOrderCtr.AddPartOrder(partOrder);
        //    var flag = partOrderCtr.UpdatePartOrder(partOrder);
        //    Assert.AreEqual(1, flag);
        //}

        //[TestMethod]
        //public void UpdatePartOrderCtrFailAmount()
        //{
        //    var partOrderCtr = new PartOrderCtr(new PartOrderTestClass());
        //    var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", "Img path");
        //    var cart = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
        //    var partOrder = new PartOrder(product, 2, 10, cart);
        //    partOrderCtr.AddPartOrder(partOrder);
        //    partOrder = new PartOrder(product, -2, 20, cart);
        //    partOrderCtr.AddPartOrder(partOrder);
        //    var flag = partOrderCtr.UpdatePartOrder(partOrder);
        //    Assert.AreEqual(0, flag);
        //}
    }
}
