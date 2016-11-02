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
   public class CustomerCtrTestClass: IDbCustomer
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
            throw new NotImplementedException();
        }

        public Customer FindCustomer(int id)
        {
            return customers.FirstOrDefault(customer => customer.Id == id);
        }

        public List<Customer> FindAllCustomer()
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        private bool ValidatePersonInput(Customer customer)
        {
            if (customer == null || customer.Address.Equals("") || customer.Name.Equals("")
                || customer.Name == null || customer.Address.Equals("")
                || customer.Address == null || customer.Email.Equals("")
                || customer.Email == null || customer.PersonType.Equals("") 
                || !customer.PersonType.Equals("Customer")
                || customer.PersonType == null || customer.Login == null)
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
