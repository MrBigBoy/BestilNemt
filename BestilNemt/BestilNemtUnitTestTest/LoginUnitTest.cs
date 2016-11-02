using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
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
        /// <summary>
        /// Test a LoginCtr constructor
        /// The test is successfull if the instance is not null
        /// </summary>
        [TestMethod]
        public void LoginCtrInitialize()
        {
            var loginCtr = new LoginCtr(new LoginCtrTestClass());
            Assert.IsNotNull(loginCtr);
        }

        /// <summary>
        /// Test a AddLogin in the db
        /// The test is successfull if the returned value is 1
        /// </summary>
        [TestMethod]
        public void AddLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("AdminDb", "SuperAdmin", 1);
            var returnedValue = dbLogin.AddLogin(login);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a Login in the db
        /// The test is successfull if the returned login object is not null
        /// </summary>
        [TestMethod]
        public void LoginLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("Admin", "SuperAdmin");
            login = dbLogin.Login(login);
            Assert.IsNotNull(login);
        }

        /// <summary>
        /// Test a UpdateLogin in the db
        /// The test is successfull if the returned value is not 0
        /// </summary>
        [TestMethod]
        public void UpdateLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("Admin", "SuperAdmin", 3);
            var returnedValue = dbLogin.UpdateLogin(login);
            Assert.AreNotEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a DelLogin in the db
        /// The test is successfull if the returned value is not 0
        /// </summary>
        [TestMethod]
        public void DelLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("Username", "Password", 1);
            dbLogin.AddLogin(login);
            var returnedValue = dbLogin.DelLogin(login);
            Assert.AreNotEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is not 0
        /// </summary>
        [TestMethod]
        public void AddLoginCtr()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("AdminCtrsdf", "SuperAdmingfh", 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreNotEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is 0 because the Username and Password is a empty string
        /// </summary>
        [TestMethod]
        public void AddLoginCtrFail()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("", "", 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is 0 because the Username and Password is a empty string
        /// </summary>
        [TestMethod]
        public void AddLoginCtrFail2()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login(null, null, 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is 0 because the Username is a empty string
        /// </summary>
        [TestMethod]
        public void AddLoginCtrFailUsername()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("", "SuperAdmingfh", 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is 0 because the Username is a empty string
        /// </summary>
        [TestMethod]
        public void AddLoginCtrFailUsername2()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login(null, "SuperAdmingfh", 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is 0 because the Password is a empty string
        /// </summary>
        [TestMethod]
        public void AddLoginCtrFailPassword()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("AdminCtrsdf", "", 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a AddLogin in the Ctr through Db
        /// The test is successfull if the returned value is 0 because the Password is a empty string
        /// </summary>
        [TestMethod]
        public void AddLoginCtrFailPassword2()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("AdminCtrsdf", null, 1);
            lCtr.DelLogin(login);
            var returnedValue = lCtr.AddLogin(login);
            Assert.AreEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is not null
        /// </summary>
        [TestMethod]
        public void LoginLoginCtr()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("Admin", "SuperAdmin");
            login = lCtr.Login(login);
            Assert.IsNotNull(login);
        }

        /// <summary>
        /// Test a UpdateLogin in the Ctr through Db
        /// The test is successfull if the returned value is not 0
        /// </summary>
        [TestMethod]
        public void UpdateLoginCtr()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("AdminCtr", "SuperAdmin", 3);
            var returnedValue = lCtr.UpdateLogin(login);
            Assert.AreEqual(1, returnedValue);
        }

        /// <summary>
        /// Test a DelLogin in the Ctr through Db
        /// The test is successfull if the returned value is not 0
        /// </summary>
        [TestMethod]
        public void DelLoginCtr()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("Username", "Password", 1);
            lCtr.AddLogin(login);
            var returnedValue = lCtr.DelLogin(login);
            Assert.AreNotEqual(0, returnedValue);
        }
    }
}
