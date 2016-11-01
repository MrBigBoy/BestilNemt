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
}
