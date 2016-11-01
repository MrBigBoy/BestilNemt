using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace Controller
{
    public class PersonCtr
    {
        public IDbPerson DbPerson { get; set; }

        public PersonCtr(IDbPerson dbPerson)
        {
            DbPerson = dbPerson;
        }

        public void CreatePerson(Customer customer)
        {
            DbPerson.Create(customer);
        }
        public Customer Find(int id)
        {
            return DbPerson.FindCustomer(id);
        }

        public List<Customer> GetAllPerson()
        {
            return DbPerson.FindAllCustomer();
        }

        public int RemoveCustomer(int id)
        {
            return DbPerson.RemoveCustomer(id);
        }

        public void updateCustomer(Customer customer)
        {
            DbPerson.UpdateCustomer(customer); 
        }

    }
}
