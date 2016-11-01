using DataAccessLayer;
using Models;
using System.Collections.Generic;
using Controller.ControllerTestClasses;

namespace Controller
{
    public class CustomerCtr
    {
        public IDbCustomer DbCustomer { get; set; }

        public CustomerCtr(IDbCustomer dbCustomer)
        {
            DbCustomer = dbCustomer;
        }

        public void CreatePerson(Customer customer)
        {
            DbCustomer.Create(customer);
        }
        public Customer Find(int id)
        {
            return DbCustomer.FindCustomer(id);
        }

        public List<Customer> GetAllCustomer()
        {
            return DbCustomer.FindAllCustomer();
        }

        public int RemoveCustomer(int id)
        {
            return DbCustomer.RemoveCustomer(id);
        }

        public void updateCustomer(Customer customer)
        {
            DbCustomer.UpdateCustomer(customer); 
        }

    }
}
