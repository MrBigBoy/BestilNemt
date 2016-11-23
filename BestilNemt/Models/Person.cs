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
        public List<Chain> Chains { get; set; }

        public Person()
        {
            Name = null;
            Email = null;
            Address = null;
            PersonType = null;
            Login = new Login();
            Chains = new List<Chain>();
        }
        public Person(int id, string name, string email, string address, Login login, List<Chain> chains, string personType)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Login = login;
            Chains = chains;
            PersonType = personType;
        }

        public Person(string name, string email, string address, Login login, List<Chain> chains, string personType)
        {
            Name = name;
            Email = email;
            Address = address;
            Login = login;
            Chains = chains;
            PersonType = personType;
        }
    }
}
