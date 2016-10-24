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
       public IDbPerson dbperson { get; set; }
        public PersonCtr(IDbPerson dbperson)
        {
            this.dbperson = dbperson; 
        }

        public void CreatePerson(Person person)
        {
            dbperson.Create(person); 
        }
        public Person find(int id)
        {
            return dbperson.Find(id);  
        }

        public List<Person> GetALlPerson()
        {
            return dbperson.FindAllPerson();
        }

    }
}
