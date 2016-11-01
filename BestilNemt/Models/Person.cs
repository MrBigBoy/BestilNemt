using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PersonType { get; set; }

        [DataMember]
        public Login Login { get; set; }
        [DataMember]
        public List<Shop> Shops { get; set; }

        public Person()
        {
            Name = null;
            Email = null;
            Address = null;
            PersonType = null;
            Login = new Login();
            Shops = new List<Shop>();
        }
        public Person(int id, string name, string email, string address, Login login, List<Shop> shops, string personType)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Login = new Login();
            Shops = shops;
            PersonType = personType;
        }
    }
}
