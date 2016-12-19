using Controller;
using Controller.ControllerTestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// Summary description for SavingUnitTest
    /// </summary>
    [TestClass]
    public class SavingUnitTest
    {
        [TestMethod]
        public void SavingCtrInitialize()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            Assert.IsNotNull(savingCtr);
        }
    }
}

