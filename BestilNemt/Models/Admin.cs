using System.Collections.Generic;

namespace Models
{
    public class Admin : Person
    {
        public Admin(int id, string name, string email, string address, Login login, List<Shop> shops , string personType) : base(id, name, email, address, login, shops, personType)
        {

        }

        public Admin()
        {
            
        }

        public Admin(string name, string email, string address, string personType)
        {
            Name = name;
            Email = email;
            Address = address;
            PersonType = personType;
        }
    }
}
