using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class PersonCtrTestClass: IDbPerson
    {
        private List<Person> persons = new List<Person>();
        private int idCounter = 1;
        private int flag = 0;
        public int Create(Person person)
        {
            person.Id = idCounter;
            if (ValidatePersonInput(person))
                flag = 1;
            persons.Add(person);
            idCounter++;
            return flag;
        }

        public int Remove(Person person)
        {
            throw new NotImplementedException();
        }

        public Person Find(int id)
        {
            return persons.FirstOrDefault(person => person.Id == id);
        }

        public List<Person> FindAllPerson()
        {
            throw new NotImplementedException();
        }

        public int UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        private bool ValidatePersonInput(Person person)
        {
            if (person == null || person.Address.Equals("") || person.Name.Equals("")
                || person.Name == null || person.Address.Equals("")
                || person.Address == null || person.Email.Equals("") 
                || person.Email == null || person.PersonType.Equals("") 
                || person.PersonType == null || person.Login == null)
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
