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
            var customer = new Customer(
                "Cust1", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), null, new List<Chain>(), "Customer");
            var flag = customerCtr.AddCustomer(customer);
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
            var customer = new Customer(
                "", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), new Login(), new List<Chain>(), "Customer");
            var flag = customerCtr.AddCustomer(customer);
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
            var customer = new Customer(
                "Cust1", "", "Addrerrsr", new DateTime(2000, 02, 01), new Login(), new List<Chain>(), "Customer");
            var flag = customerCtr.AddCustomer(customer);
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
            var customer = new Customer(
                "Cust1", "email", "", new DateTime(2000, 02, 01), new Login(), new List<Chain>(), "Customer");
            var flag = customerCtr.AddCustomer(customer);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the customer object with given id is found and returned value is not null
        /// </summary>
        [TestMethod]
        public void GetCustomerById()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            var customer = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer);
            Assert.IsNotNull(customerCtr.GetCustomer(1));
        }


        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the customer object with given id is found and returned value is not null
        /// </summary>
        [TestMethod]
        public void GetCustomerByIdFailed()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            var customer = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer);
            Assert.IsNull(customerCtr.GetCustomer(2));
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the returned list size is equal to expected
        /// </summary>
        [TestMethod]
        public void GetAllCustomers()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            var customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            var customer2 = new Customer(
               "Cust2", "email1", "Ddjkcgsf", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer1);
            customerCtr.AddCustomer(customer2);
            Assert.AreEqual(2, customerCtr.GetAllCustomer().Count);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test for the returned list size is equal to expected
        /// </summary>
        [TestMethod]
        public void GetAllCustomersFailed()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            var customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            var customer2 = new Customer(
               "Cust2", "email1", "Ddjkcgsf", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer1);
            customerCtr.AddCustomer(customer2);
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
            var customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer1);
            var customer2 = new Customer
            {
                Id = 1,
                Name = "NewCust",
                Address = "Ddjk",
                Email = "email",
                Birthday = new DateTime(),
                Login = new Login(),
                Chains = new List<Chain>(),
                PersonType = "Customer"
            };
            customerCtr.UpdateCustomer(customer2);
            var returnedCust = customerCtr.GetCustomer(1);
            Assert.AreEqual("NewCust", returnedCust.Name);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test is sucsessfull if returned value is 1, it means that a customer with id = 1 is  
        /// found and DeleteCustomer method was sucsessfull.
        /// </summary>
        [TestMethod]
        public void RemoveCustomer()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            var customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer1);
            var flag = customerCtr.DeleteCustomer(1);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test only CustomerCtr using CustomerCrtTestClass that simulates database
        /// Test is sucsessfull if returned value is 0, it means that a customer with id = 2 is not 
        /// found and DeleteCustomer method was failed. 
        /// </summary>
        [TestMethod]
        public void RemoveCustomerFaild()
        {
            var customerCtr = new CustomerCtr(new CustomerCtrTestClass());
            var customer1 = new Customer(
                "Cust1", "email", "Ddjk", new DateTime(), new Login(), new List<Chain>(), "Customer");
            customerCtr.AddCustomer(customer1);
            var flag = customerCtr.DeleteCustomer(2);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test only DbCustomer 
        /// Test is sucsessful if all customer input values are valid and returned value is not 0
        /// </summary>
        [TestMethod]
        public void AddCustomerDb()
        {
            var dbCust = new DbCustomer();
            var customer = new Customer(
                "Cust1", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), null, new List<Chain>(), "Customer");
            var flag = dbCust.AddCustomer(customer);
            Assert.AreNotEqual(0, flag);
        }

        /// <summary>
        /// Test only DbCustomer 
        /// Test is sucsessful if returned customer object is not null
        /// </summary>
        [TestMethod]
        public void GetCustomerFromDbById()
        {
            var dbCust = new DbCustomer();
          Assert.IsNotNull(dbCust.GetCustomer(1));
        }

        /// <summary>
        /// Test only DbCustomer 
        /// Test is sucsessful if returned value is 2
        /// </summary>
        [TestMethod]
        public void UpdateCustomerThrougDb()
        {
            var dbCust = new DbCustomer();
            var customer = dbCust.GetCustomer(1);
            if (customer != null)
            {
                customer.Name = "Thorkild Brun";
                customer.Address = "Dk";
                customer.Email = "thorkild@email.dk";
                customer.Birthday = new DateTime(2015, 02, 03);
            }
            var flag = dbCust.UpdateCustomer(customer);
            Assert.AreEqual(2, flag);
        }

        /// <summary>
        /// Test only DbCustomer 
        /// Test is sucsessful if returned value is 2
        /// </summary>
        [TestMethod]
        public void DeleteCustomerThrougDb()
        {
            var dbCust = new DbCustomer();
            var cust = new Customer("Ole Nielsen", "oel@mail.dk", "ahrtghjv", new DateTime(2009, 02, 13),
                new Login(), new List<Chain>(), "Customer");
            var id = dbCust.AddCustomer(cust);
            var flag = dbCust.DeleteCustomer(id);
            Assert.AreNotEqual(0, flag);

        }


        /// <summary>
        /// Test Create Customer from wcf  
        /// Test is sucsessful if all customer input values are valid and returned value is not 0
        /// </summary>
        [TestMethod]
        public void AddCustomerWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var customer = new Customer(
                    "Cust1", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), null, new List<Chain>(),
                    "Customer");
                var flag = proxy.AddCustomer(customer);
                Assert.AreNotEqual(0, flag);
            }
        }

        /// <summary>
        /// Test Create Customer from wcf  
        /// Test is sucsessful if customers input name are not valid and returned value is 0
        /// </summary>
        [TestMethod]
        public void AddCustomerWcfFailNoName()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var customer = new Customer(
                    "", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), null, new List<Chain>(),
                    "Customer");
                var flag = proxy.AddCustomer(customer);
                Assert.AreEqual(0, flag);
            }
        }
        /// <summary>
        /// Test Create Customer from wcf  
        /// Test is sucsessful if customers input type are not valid(not Customer) and returned value is 0
        /// </summary>
        [TestMethod]
        public void AddCustomerWcfFailInvalidType()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var customer = new Customer(
                    "", "cust1@mail.dk", "Addrerrsr", new DateTime(2000, 02, 01), null, new List<Chain>(),
                    "Admin");
                var flag = proxy.AddCustomer(customer);
                Assert.AreEqual(0, flag);
            }
        }

        /// <summary>
        /// Test GetCustomer Customer from wcf 
        /// Test is sucsessful if returned customer object is not null
        /// </summary>
        [TestMethod]
        public void GetCustomerFromWcfById()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.IsNotNull(proxy.GetCustomer(1));
            }
        }

        /// <summary>
        /// Test GetCustomer Customer from wcf 
        /// Test is sucsessful if returned customer object is null
        /// </summary>
        [TestMethod]
        public void GetCustomerFromWcfByIdFail()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                Assert.IsNull(proxy.GetCustomer(100));
            }
        }

        /// <summary>
        /// Test updateCustomer Customer from wcf 
        /// Test is sucsessful if returned value is 2
        /// </summary>
        [TestMethod]
        public void UpdateCustomerThrougWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var customer = proxy.GetCustomer(1);
                if (customer != null)
                {
                    customer.Name = "Thorkild Brun";
                    customer.Address = "Dk";
                    customer.Email = "thorkild@email.dk";
                    customer.Birthday = new DateTime(2015, 02, 03);
                }
                var flag = proxy.UpdateCustomer(customer);
                Assert.AreEqual(2, flag);
            }
        }

        /// <summary>
        /// Test updateCustomer Customer from wcf 
        /// Test is sucsessful if returned value is not 2, it is not possible to updete name with empty one
        /// </summary>
        [TestMethod]
        public void UpdateCustomerThrougWcfFail()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var customer = proxy.GetCustomer(1);
                if (customer != null)
                {
                    customer.Name = "";
                    customer.Address = "Dk";
                    customer.Email = "thorkild@email.dk";
                    customer.Birthday = new DateTime(2015, 02, 03);
                }
                var flag = proxy.UpdateCustomer(customer);
                Assert.AreEqual(0, flag);
            }
        }

        /// <summary>
        /// Test DeleteCustomer Customer from wcf  
        /// Test is sucsessful if returned value is 2
        /// </summary>
        [TestMethod]
        public void DeleteCustomerThrougWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var cust = new Customer("Ole Nielsen", "oel@mail.dk", "ahrtghjv", new DateTime(2009, 02, 13),
                    new Login(), new List<Chain>(), "Customer");
                var id = proxy.AddCustomer(cust);
                var flag = proxy.DeleteCustomer(id);
                Assert.AreNotEqual(0, flag);
            }

        }
        
    }
}
