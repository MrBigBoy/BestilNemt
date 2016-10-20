using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestilNemtUnitTestTest.BestilNemtServiceRef;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// Summary description for LoginUnitTest
    /// </summary>
    [TestClass]
    public class LoginUnitTest
    {
        BestilNemtServiceRef.BestilNemtServiceClient Client;
        public LoginUnitTest()
        {
            Client = new BestilNemtServiceRef.BestilNemtServiceClient();
        }

        private TestContext testContextInstance;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            string Username = "";
            string Password = "";
            Login login = Client.Login(Username, Password);
            //AssertFailedException(login.Id == 0);
        }
    }
}
