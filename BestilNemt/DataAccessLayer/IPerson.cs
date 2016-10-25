using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public interface IDbPerson
    {
        void Create(Person person);
        void Remove(Person person);
        Person Find(int id);
        List<Person> FindAllPerson();
        void UpdatePerson(Person person);
    }

    public class PersonTestDb : IDbPerson
    {
        List<Person> testList = new List<Person>();

        public void Create(Person person)
        {
            throw new NotImplementedException();
        }

        public void Remove(Person person)
        {
            throw new NotImplementedException();
        }

        public Person Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAllPerson()
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
