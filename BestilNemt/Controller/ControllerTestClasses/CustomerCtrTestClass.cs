using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class CustomerCtrTestClass : IDbCustomer
    {
        private List<Customer> customers = new List<Customer>();
        private int idCounter = 1;
        public int AddCustomer(Customer customer)
        {
            customer.Id = idCounter;
            customers.Add(customer);
            idCounter++;
            return customer.Id;
        }

        public int DeleteCustomer(int id)
        {
            return customers.Remove(GetCustomer(id)) ? 1 : 0;
        }

        public Customer GetCustomer(int id)
        {
            return customers.FirstOrDefault(customer => customer.Id == id);
        }

        public List<Customer> GetAllCustomer()
        {
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            var returnedCust = GetCustomer(customer.Id);
            returnedCust.Name = customer.Name;
            returnedCust.Birthday = customer.Birthday;
            returnedCust.Address = customer.Address;
            returnedCust.Email = customer.Email;
            returnedCust.Login = customer.Login;
            returnedCust.Chains = customer.Chains;
            returnedCust.PersonType = customer.PersonType;

            return 1;
        }

        public int AddCustomerWithLogin(Customer customer, Login login)
        {
            throw new NotImplementedException();
        }
    }
}
