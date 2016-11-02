using System.Collections.Generic;

namespace Models
{
    public class Company : Person
    {
        public Company()
        {
        }

        public Company(int id, string name, string email, string address, Login login, List<Shop> shops, string personType) : base(id, name, email, address, login, shops, personType)
        {
        }

        public Company(string name, string email, string address, string personType)
        {
            Name = name;
            Email = email;
            Address = address;
            PersonType = personType; 

        }
    }
}
 