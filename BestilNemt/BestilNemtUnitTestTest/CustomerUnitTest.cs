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
        /// Test for the customer object with given id is found and returned value is not null
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


        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the customer object with given id is found and returned value is not null
        /// </summary>
        [TestMethod]
        public void FindCustomerByIdFailed()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "Customer");
            customerCtr.CreatePerson(customer);
            Assert.IsNull(customerCtr.FindCustomer(2));
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the returned list size is equal to expected
        /// </summary>
        [TestMethod]
        public void FindAllCustomers()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "Customer");
            Customer customer2 = new Customer(
               "Cust2", "email1", "Ddjkcgsf", new DateTime(), new Login(), new List<Shop>(), "Customer");
            customerCtr.CreatePerson(customer1);
            customerCtr.CreatePerson(customer2);
            Assert.AreEqual(2, customerCtr.GetAllCustomer().Count);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the returned list size is equal to expected
        /// </summary>
        [TestMethod]
        public void FindAllCustomersFailed()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "Customer");
            Customer customer2 = new Customer(
               "Cust2", "email1", "Ddjkcgsf", new DateTime(), new Login(), new List<Shop>(), "Customer");
            customerCtr.CreatePerson(customer1);
            customerCtr.CreatePerson(customer2);
            Assert.AreNotEqual(1, customerCtr.GetAllCustomer().Count);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the returned list size is equal to expected
        /// </summary>
        [TestMethod]
        public void UpdateCustomerName()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "Customer");
            customerCtr.CreatePerson(customer1);
            Customer customer2 = new Customer
            {
                Id = 1,
                Name = "NewCust",
                Address = "Ddjk",
                Email = "email",
                Birthday = new DateTime(),
                Login = new Login(),
                Shops = new List<Shop>(),
                PersonType = "Customer"
            };
            customerCtr.UpdateCustomer(customer2);
            var returnedCust = customerCtr.FindCustomer(1);
            Assert.AreEqual("NewCust", returnedCust.Name);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the returned list size is equal to expected
        /// </summary>
        [TestMethod]
        public void RemoveCustomer()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            Customer customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Shop>(), "Customer");
            customerCtr.CreatePerson(customer1);
            var flag = customerCtr.RemoveCustomer(1);
            Assert.AreEqual(1, flag);
        }
    }
}
