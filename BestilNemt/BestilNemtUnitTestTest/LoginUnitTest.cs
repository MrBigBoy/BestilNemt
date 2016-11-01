using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestilNemtUnitTestTest.BestilNemtServiceRef;
using Controller;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// Summary description for LoginUnitTest
    /// </summary>
    [TestClass]
    public class LoginUnitTest
    {
        BestilNemtServiceClient Client;

        public LoginUnitTest()
        {
            Client = new BestilNemtServiceClient();
        }

        [TestMethod]
        public void AddLogin()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var returnedValue = lCtr.AddLogin("Admin", "SuperAdmin", 1);
            Assert.AreEqual(1, returnedValue);
        }
        
        [TestMethod]
        public void LoginWithPassword()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = lCtr.Login("Admin", "SuperAdmin");
            Assert.IsNotNull(login);
        }
        
    }
}
