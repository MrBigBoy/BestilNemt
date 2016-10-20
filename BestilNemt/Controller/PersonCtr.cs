using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PersonCtr
    {
       public DbPerson dbperson { get; set; }
        public PersonCtr()
        {
            dbperson = new DbPerson(); 
        }

        public void CreatePerson(Person person)
        {
            dbperson.Create(person); 
        }
        public Person find(int id)
        {
            return dbperson.find(id);  
        }

        public List<Person> GetALlPerson()
        {
            return dbperson.FindAllPerson();
        }

    }
}
