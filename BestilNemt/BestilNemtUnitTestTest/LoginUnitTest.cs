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
        /// Test a AddLogin in the db
        /// The test is successfull if the returned value is 1
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void AddLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("AdminTestDb", "SuperAdmin", 1);
            var returnedValue = dbLogin.AddLogin(login);
            login.Id = returnedValue;
            dbLogin.DeleteLogin(login);
            Assert.AreNotEqual(0, returnedValue);
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
        /// Test a UpdateLogin in the db
        /// The test is successfull if the returned value is not 0
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void UpdateLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("Admin", "SuperAdmin", 2);
            var returnedValue = dbLogin.UpdateLogin(login);
            Assert.AreNotEqual(0, returnedValue);
        }

        /// <summary>
        /// Test a DeleteLogin in the db
        /// The test is successfull if the returned value is not 0
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void DelLoginDb()
        {
            var dbLogin = new DbLogin();
            var login = new Login("Username", "Password", 1);
            dbLogin.AddLogin(login);
            var returnedValue = dbLogin.DeleteLogin(login);
            Assert.AreNotEqual(0, returnedValue);
        }

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is not 0
        ///// ERROR: non
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtr()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("AdminCtrsdf", "SuperAdmingfh", 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreNotEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username and Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFail()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("", "", 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username and Password is null
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFail2()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login(null, null, 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username is a empty string
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFailUsername()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("", "SuperAdmingfh", 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username is null
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFailUsername2()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login(null, "SuperAdmingfh", 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFailPassword()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("AdminCtrsdf", "", 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Password is null
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFailPassword2()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("AdminCtrsdf", null, 1);
        //    lCtr.DeleteLogin(login);
        //    var returnedValue = lCtr.AddLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a AddLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Login object is null
        ///// </summary>
        //[TestMethod]
        //public void AddLoginCtrFailNull()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var returnedValue = lCtr.AddLogin(null);
        //    Assert.AreEqual(0, returnedValue);
        //}

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

        ///// <summary>
        ///// Test a UpdateLogin in the Ctr through Db
        ///// The test is successfull if the returned value is not 0
        ///// ERROR: Non
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginCtr()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("AdminCtr", "SuperAdmin", 3);
        //    var returnedValue = lCtr.UpdateLogin(login);
        //    Assert.AreEqual(1, returnedValue);
        //}

        ///// <summary>
        ///// Test a UpdateLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username is a empty string
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginCtrFailUsername()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("", "SuperAdmin");
        //    var returnedValue = lCtr.UpdateLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a UpdateLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginCtrFailPassword()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("Admin", "");
        //    var returnedValue = lCtr.UpdateLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a Login in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username and Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginCtrFailBoth()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("", "");
        //    var returnedValue = lCtr.UpdateLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a Login in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username and Password is null
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginCtrFailBoth2()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login(null, null);
        //    var returnedValue = lCtr.UpdateLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a Login in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username should be Admin instead of admin
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginCtrFailSmallLetters()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("admin", "SuperAdmin");
        //    var returnedValue = lCtr.UpdateLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

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

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db
        ///// The test is successfull if the returned value is not 0
        ///// ERROR: Non
        ///// </summary>
        //[TestMethod]
        //public void DelLoginCtr()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("Username", "Password", 1);
        //    lCtr.AddLogin(login);
        //    var returnedValue = lCtr.DeleteLogin(login);
        //    Assert.AreNotEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username is a empty string
        ///// </summary>
        //[TestMethod]
        //public void DelLoginCtrFailUsername()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("", "Password", 1);
        //    lCtr.AddLogin(login);
        //    var returnedValue = lCtr.DeleteLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void DelLoginCtrFailPassword()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("Admin", "", 1);
        //    lCtr.AddLogin(login);
        //    var returnedValue = lCtr.DeleteLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username and Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void DelLoginCtrFailBoth()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login("", "", 1);
        //    lCtr.AddLogin(login);
        //    var returnedValue = lCtr.DeleteLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username and Password is null
        ///// </summary>
        //[TestMethod]
        //public void DelLoginCtrFailBoth2()
        //{
        //    var lCtr = new LoginCtr(new DbLogin());
        //    var login = new Login(null, null, 1);
        //    lCtr.AddLogin(login);
        //    var returnedValue = lCtr.DeleteLogin(login);
        //    Assert.AreEqual(0, returnedValue);
        //}

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

        ///// <summary>
        ///// Test a UpdateLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is not 0
        ///// ERROR: Non
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginWcf()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("AdminCtr", "SuperAdmin", 3);
        //        var returnedValue = lCtr.UpdateLogin(login);
        //        Assert.AreEqual(1, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a UpdateLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username is a empty string
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginWcfFailUsername()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("", "SuperAdmin");
        //        var returnedValue = lCtr.UpdateLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a UpdateLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginWcfFailPassword()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("Admin", "");
        //        var returnedValue = lCtr.UpdateLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a Login in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username and Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginWcfFailBoth()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("", "");
        //        var returnedValue = lCtr.UpdateLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a Login in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username and Password is null
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginWcfFailBoth2()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login(null, null);
        //        var returnedValue = lCtr.UpdateLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a Login in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: The Username should be Admin instead of admin
        ///// </summary>
        //[TestMethod]
        //public void UpdateLoginWcfFailSmallLetters()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("admin", "SuperAdmin");
        //        var returnedValue = lCtr.UpdateLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

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

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is not 0
        ///// ERROR: Non
        ///// </summary>
        //[TestMethod]
        //public void DelLoginWcf()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("Username", "Password", 1);
        //        lCtr.AddLogin(login);
        //        var returnedValue = lCtr.DeleteLogin(login);
        //        Assert.AreNotEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username is a empty string
        ///// </summary>
        //[TestMethod]
        //public void DelLoginWcfFailUsername()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("", "Password", 1);
        //        lCtr.AddLogin(login);
        //        var returnedValue = lCtr.DeleteLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void DelLoginWcfFailPassword()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("Admin", "", 1);
        //        lCtr.AddLogin(login);
        //        var returnedValue = lCtr.DeleteLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username and Password is a empty string
        ///// </summary>
        //[TestMethod]
        //public void DelLoginWcfFailBoth()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login("", "", 1);
        //        lCtr.AddLogin(login);
        //        var returnedValue = lCtr.DeleteLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}

        ///// <summary>
        ///// Test a DeleteLogin in the Ctr through Db with WCF
        ///// The test is successfull if the returned value is 0
        ///// ERROR: Username and Password is null
        ///// </summary>
        //[TestMethod]
        //public void DelLoginWcfFailBoth2()
        //{
        //    using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
        //    {
        //        proxy.Open();
        //        var lCtr = new LoginCtr(new DbLogin());
        //        var login = new Login(null, null, 1);
        //        lCtr.AddLogin(login);
        //        var returnedValue = lCtr.DeleteLogin(login);
        //        Assert.AreEqual(0, returnedValue);
        //    }
        //}
    }
}