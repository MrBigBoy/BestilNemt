using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class AdminUnitTest
    {
        /// <summary>
        /// Tests the AdminCtr constructor
        /// The test will be successfull if the instance is not null
        /// </summary>
        [TestMethod]
        public void AdminCtrInitialize()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            Assert.IsNotNull(adminCtr);
        }
    }
}
