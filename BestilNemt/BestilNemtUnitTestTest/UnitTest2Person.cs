using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Models;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// Summary description for UnitTest2Person
    /// </summary>
    [TestClass]
    public class UnitTest2Person
    {
        PersonCtr personctr = new PersonCtr();
       BestilNemtServiceRef.BestilNemtServiceClient proxy;
        

        public UnitTest2Person()
        {
            proxy = new BestilNemtServiceRef.BestilNemtServiceClient();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        public void TestMethod1()
        {
            personctr.find(1);

        }



        [TestMethod()]
        public void CreatePersonTest()
        {
            Person person = new Person();

           person.Name = "Thomas";
           person.Email = "Article 1";
            person.Address = "dslædlsædlsæ"; 

            //var actual = articleViewModel.LoadArticle(userName);

        }


        [TestMethod()]
        public void findTest()
        {
            //Person p = new Person();
           var p = proxy.findPerson(1);
            //  var p = personctr.find(1);
          
            Assert.IsTrue(p.Id==1);
                



          
        

        }
        [TestMethod()]
        public void findAllPerson()
        {
            var s = proxy.GetShop(1);
            Assert.IsTrue(s.Id == 1); 
        }
    }
}


