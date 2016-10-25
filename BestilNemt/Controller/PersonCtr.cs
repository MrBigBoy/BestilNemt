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

        public void CreatePerson(Person person)
        {
            DbPerson.Create(person);
        }
        public Person Find(int id)
        {
            return DbPerson.Find(id);
        }

        public List<Person> GetAllPerson()
        {
            return DbPerson.FindAllPerson();
        }

    }
}
