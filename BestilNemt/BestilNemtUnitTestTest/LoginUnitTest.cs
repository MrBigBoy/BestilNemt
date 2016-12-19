using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// Summary description for LoginUnitTest
    /// ERROR: Here will be described the error
    /// </summary>
    [TestClass]
    public class LoginUnitTest
    {
        /// <summary>
        /// Test a LoginCtr constructor
        /// The test is successfull if the instance is not null
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void LoginCtrInitialize()
        {
            var loginCtr = new LoginCtr(new LoginCtrTestClass());
            Assert.IsNotNull(loginCtr);
        }

        /// <summary>
        /// Test a Login in the db
        /// The test is successfull if the returned login object is not null
        /// ERROR: Non
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
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is not null
        /// ERROR: Non
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
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is null
        /// ERROR: Username is a empty string
        /// </summary>
        [TestMethod]
        public void LoginLoginCtrFailUsername()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("", "SuperAdmin");
            login = lCtr.Login(login);
            Assert.IsNull(login);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is null
        /// ERROR: Password is a empty string
        /// </summary>
        [TestMethod]
        public void LoginLoginCtrFailPassword()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("Admin", "");
            login = lCtr.Login(login);
            Assert.IsNull(login);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is null
        /// ERROR: Username and Password is a empty string
        /// </summary>
        [TestMethod]
        public void LoginLoginCtrFailBoth()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login("", "");
            login = lCtr.Login(login);
            Assert.IsNull(login);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is null
        /// ERROR: Username and Password is null
        /// </summary>
        [TestMethod]
        public void LoginLoginCtrFailBoth2()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = new Login(null, null);
            login = lCtr.Login(login);
            Assert.IsNull(login);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is null
        /// ERROR: Login object is null
        /// </summary>
        [TestMethod]
        public void LoginLoginCtrFailNull()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = lCtr.Login(null);
            Assert.IsNull(login);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db
        /// The test is successfull if the returned object is null
        /// ERROR: Login object is null
        /// </summary>
        [TestMethod]
        public void UpdateLoginCtrFailNull()
        {
            var lCtr = new LoginCtr(new DbLogin());
            var login = lCtr.Login(null);
            Assert.IsNull(login);
        }

        /// <summary>
        /// Test a Login in the Ctr through Db with WCF
        /// The test is successfull if the returned object is null
        /// ERROR: Login object is null
        /// </summary>
        [TestMethod]
        public void LoginLoginWcfFailNull()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var lCtr = new LoginCtr(new DbLogin());
                var login = lCtr.Login(null);
                Assert.IsNull(login);
            }
        }

        /// <summary>
        /// Test a Login in the Ctr through Db with WCF
        /// The test is successfull if the returned object is null
        /// ERROR: Login object is null
        /// </summary>
        [TestMethod]
        public void UpdateLoginWcfFailNull()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var lCtr = new LoginCtr(new DbLogin());
                var login = lCtr.Login(null);
                Assert.IsNull(login);
            }
        }
    }
}