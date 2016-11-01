using System;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbPerson
    {
        int Create(Customer customer);
        int RemoveCustomer(int id);
        Customer FindCustomer(int id);
        List<Customer> FindAllCustomer();
        int UpdateCustomer(Customer customer);
    }

    public class PersonTestDb : IDbPerson
    {
        List<Person> testList = new List<Person>();

        public int Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int RemoveCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer FindCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> FindAllCustomer()
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
