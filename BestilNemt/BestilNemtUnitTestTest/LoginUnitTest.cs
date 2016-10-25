using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestilNemtUnitTestTest.BestilNemtServiceRef;
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
        public void TestMethod12()
        {
            string Username = "";
            string Password = "";

            //Controller.LoginCtr ctr = new LoginCtr(new LoginTestDb());
            //PersonCtr pCtr = new PersonCtr(new PersonTestDb());
            //ctr.Login("", "");

            Login login = Client.Login(Username, Password);
            Assert.IsTrue(login.Id == 0);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string Username = "";
            string Password = "";
            Login login = Client.Login(Username, Password);
            Assert.IsTrue(login.Id == 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string Username = "test@mail.dk";
            string Password = "testKode";
            Login login = Client.Login(Username, Password);
            Assert.IsTrue(login.Id == 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string Username = "test@mail.dk";
            string Password = "";
            Login login = Client.Login(Username, Password);
            Assert.IsFalse(login.Id == 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string Username = "";
            string Password = "testKode";
            Login login = Client.Login(Username, Password);
            Assert.IsFalse(login.Id == 1);
        }
    }
}
