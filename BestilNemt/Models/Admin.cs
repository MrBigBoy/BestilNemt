using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    public class Admin : Person
    {
        [DataMember]
        public int Membernr { get; set; }
        public Admin(int id, string name, string email, string address, Login login, List<Shop> shops , string personType,int membernr) : base(id, name, email, address, login, shops, personType)
        {
            Membernr = membernr;
        }

        public Admin()
        {
            
        }

        public Admin(string name, string email, string address, string personType, int membernr)
        {
            Name = name;
            Email = email;
            Address = address;
            PersonType = personType;
            Membernr = membernr;
        }
    }
}
