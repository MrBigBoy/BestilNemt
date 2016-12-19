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
    }
}
