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

        public Customer(int id, string name, string email, string address, DateTime birthday, Login login, List<Shop> shops, string personType) : base(id, name, email, address, login, shops, personType)
        {
            Birthday = birthday;
        }
    }
}
 