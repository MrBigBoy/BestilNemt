using System;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbPerson
    {
        int Create(Person person);
        int Remove(Person person);
        Person Find(int id);
        List<Person> FindAllPerson();
        int UpdatePerson(Person person);
    }

    public class PersonTestDb : IDbPerson
    {
        List<Person> testList = new List<Person>();

        public int Create(Person person)
        {
            throw new NotImplementedException();
        }

        public int Remove(Person person)
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

        public int UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
