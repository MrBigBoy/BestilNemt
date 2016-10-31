﻿using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Customer : Person
    {
        [DataMember]
        public DateTime Birthday { get; set; }

        public Customer(int id, string name, string email, string address, DateTime birthday, Login login, Shop shop, string personType) : base(id, name, email, address, login, shop,personType)
        {
            Birthday = birthday;
        }
    }
}
