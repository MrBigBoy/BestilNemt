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

        public int CreatePerson(Customer customer)
        {
            return ValidatePersonInput(customer) ? DbCustomer.Create(customer) : 0;
        }
        public Customer FindCustomer(int id)
        {
            return DbCustomer.FindCustomer(id);
        }

        public List<Customer> GetAllPerson()
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

        private bool ValidatePersonInput(Customer customer)
        {
            if (customer == null || customer.Address.Equals("") || customer.Name.Equals("")
                || customer.Name == null || customer.Address.Equals("")
                || customer.Address == null || customer.Email.Equals("")
                || customer.Email == null || customer.PersonType.Equals("")
                || !customer.PersonType.Equals("Customer")
                || customer.PersonType == null )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
