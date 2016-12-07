using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

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

        /// <summary>
        /// Tests the AdminCtr
        /// The return value will be 1 if the test is a successfull
        /// </summary>
        [TestMethod]
        public void AddAdmin()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "Administrator", 1);
            var flag = adminCtr.AddAdmin(admin);
            Assert.AreEqual(1, flag);
        }
        /// <summary>
        /// Tests the AdminCtr
        /// The return value will be 0 if the admin has no name entered
        /// </summary>
        [TestMethod]
        public void AddAdminNoName()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("", "Bob@mail.com", "Long road 1", "Administrator", 1);
            var flag = adminCtr.AddAdmin(admin);
            Assert.AreEqual(0, flag);
        }
        /// <summary>
        /// Tests the AdminCtr
        /// The return value will be 0 if the admin has no email entered
        /// </summary>
        [TestMethod]
        public void AddAdminNoEmail()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "", "Long road 1", "Administrator", 1);
            var flag = adminCtr.AddAdmin(admin);
            Assert.AreEqual(0, flag);
        }
        /// <summary>
        /// Tests the AdminCtr
        /// The return value will be 0 if the admin has no address 
        /// </summary>
        [TestMethod]
        public void AddAdminNoAddress()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "", "Administrator", 1);
            var flag = adminCtr.AddAdmin(admin);
            Assert.AreEqual(0, flag);
        }
        /// <summary>
        /// Tests the AdminCtr
        /// The return value will be 0 if the person type is something else but Administrator
        /// </summary>
        [TestMethod]
        public void AddAdminWrongPersonType()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "Customer", 1);
            var flag = adminCtr.AddAdmin(admin);
            Assert.AreEqual(0, flag);
        }
        /// <summary>
        /// Tests the AdminCtr
        /// The return value will be 0 if there is no person type entered
        /// </summary>
        [TestMethod]
        public void AddAdminNoPersonType()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "", 1);
            var flag = adminCtr.AddAdmin(admin);
            Assert.AreEqual(0, flag);
        }
        /// <summary>
        /// Tests the AdminCtr
        /// Gets the admin with the id 1, and checks if it's no null
        /// </summary>
        [TestMethod]
        public void GetAdminById()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "Administrator", 1);
            adminCtr.AddAdmin(admin);
            Assert.IsNotNull(adminCtr.GetAdmin(1));
        }
        /// <summary>
        /// Tests the AdminCtr
        /// Tries to get a admin with the id 2, which is no existing
        /// </summary>
        [TestMethod]
        public void GetAdminByIdFail()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "Administrator", 1);
            adminCtr.AddAdmin(admin);
            Assert.IsNull(adminCtr.GetAdmin(2));
        }
        /// <summary>
        /// Tests the AdminCtr
        /// Gets the 2 exist admins and counts to see if there is 2 admins
        /// </summary>
        [TestMethod]
        public void GetAllAdmins()
        {
            var adminCtr = new AdminCtr(new AdminCtrTestClass());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "Administrator", 1);
            var admin2 = new Admin("Bill", "Bill@mail.com", "Long road 3", "Administrator", 2);
            adminCtr.AddAdmin(admin);
            adminCtr.AddAdmin(admin2);
            Assert.AreEqual(2, adminCtr.GetAllAdmins().Count);
        }
        [TestMethod]
        public void AddAdminCtrDb()
        {
            var adminCtr = new AdminCtr(new DbAdmin());
            var admin = new Admin("Bob", "Bob@mail.com", "Long road 1", "Administrator", 1);
            var id = adminCtr.AddAdmin(admin);
            Assert.AreNotEqual(0, id);
        }
    }
}
