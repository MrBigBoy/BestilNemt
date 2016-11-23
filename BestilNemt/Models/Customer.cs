using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Customer : Person
    {
        [DataMember]
        public DateTime Birthday { get; set; }


        public Customer(int id, string name, string email, string address, DateTime birthday, Login login, List<Chain> chains, string personType) : base(id, name, email, address, login, chains, personType)
        {

            Birthday = birthday;

        }

        public Customer(string name, string email, string address, DateTime birthday, Login login, List<Chain> chains, string personType) : base(name, email, address, login, chains, personType)
        {

            Birthday = birthday;

        }

        public Customer()
        {

        }
    }
}
