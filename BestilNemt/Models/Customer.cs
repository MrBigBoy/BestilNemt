using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Customer : Person
    {
        [DataMember]
        public DateTime Birthday { get; set; }

        public Customer(int id, string name, string email, string address, DateTime birthday) : base(id, name, email, address)
        {
            Birthday = birthday;
        }
    }
}
