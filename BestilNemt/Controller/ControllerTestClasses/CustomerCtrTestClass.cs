using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class CustomerCtrTestClass : IDbCustomer
    {
        private List<Customer> customers = new List<Customer>();
        private int idCounter = 1;
        //private int flag = 0;
        public int Create(Customer customer)
        {
            customer.Id = idCounter;
            //if (ValidatePersonInput(customer))
            //    flag = 1;
            customers.Add(customer);
            idCounter++;
            // return flag;
            return customer.Id;
        }

        public int RemoveCustomer(int id)
        {
            return customers.Remove(FindCustomer(id)) ? 1 : 0;
        }

        public Customer FindCustomer(int id)
        {
            return customers.FirstOrDefault(customer => customer.Id == id);
        }

        public List<Customer> FindAllCustomer()
        {
            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {
            var returnedCust = FindCustomer(customer.Id);
            returnedCust.Name = customer.Name;
            returnedCust.Birthday = customer.Birthday;
            returnedCust.Address = customer.Address;
            returnedCust.Email = customer.Email;
            returnedCust.Login = customer.Login;
            returnedCust.Shops = customer.Shops;
            returnedCust.PersonType = customer.PersonType;

            return 1;
        }

    }
}
