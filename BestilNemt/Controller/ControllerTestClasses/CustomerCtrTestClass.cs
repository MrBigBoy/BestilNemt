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
        
        public Customer GetCustomer(int id)
        {
            return customers.FirstOrDefault(customer => customer.Id == id);
        }
        
        public int AddCustomerWithLogin(Customer customer, Login login)
        {
            return 1;
        }
    }
}
