using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class CustomerUnitTest
    {
        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test is sucsessful if all customer input values are valid and returned value is not 0
        /// </summary>
        [TestMethod]
        public void AddCustomer()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer( 
                "Cust1", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), null, new List<Shop>(), "Customer");
            var flag = customerCtr.CreatePerson(customer);
            Assert.AreNotEqual(0, flag);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for invalid input name
        /// Test is sucsessful if validation of input failed and returned value is 0
        /// </summary>
        [TestMethod]
        public void AddCustomerFailNoName()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer(
                "", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), new Login(), new List<Shop>(), "Customer");
            var flag = customerCtr.CreatePerson(customer);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for invalid input Email
        /// Test is sucsessful if validation of input failed and returned value is 0
        /// </summary>
        [TestMethod]
        public void AddCustomerFailNoEmail()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer(
                "Cust1", "", "Addrerrsr", new DateTime(2000, 02, 01), new Login(), new List<Shop>(), "Customer");
            var flag = customerCtr.CreatePerson(customer);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for invalid input address
        /// Test is sucsessful if validation of input failed and returned value is 0
        /// </summary>
        [TestMethod]
        public void AddCustomerFailNoAddress()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer(
                "Cust1", "email", "", new DateTime(2000, 02, 01), new Login(), new List<Shop>(), "Customer");
            var flag = customerCtr.CreatePerson(customer);
            Assert.AreEqual(0, flag);
        }
        
        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for invalid input person type
        /// Test is sucsessful if validation of input failed and returned value is 0
        /// </summary>
        [TestMethod]
        public void AddCustomerFailPersonType()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "orm");
            var flag = customerCtr.CreatePerson(customer);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for 
        /// </summary>
        [TestMethod]
        public void FindCustomerById()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "Customer");
            customerCtr.CreatePerson(customer);
            Assert.IsNotNull(customerCtr.FindCustomer(1));
        }
    }
}
