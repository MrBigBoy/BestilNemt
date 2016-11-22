﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Chain
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CVR { get; set; }
        [DataMember]
        public List<Person> Persons { get; set; }
        [DataMember]
        public List<Shop> Shops { get; set; }

        public Chain()
        {
            Name = null;
            CVR = null;
            Persons = new List<Person>();
            Shops = new List<Shop>();
        }

        public Chain(int id, string name, string cvr, List<Person> persons, List<Shop> shops)
        {
            this.Id = id;
            Name = name;
            CVR = cvr;
            Persons = persons;
            Shops = shops;

        }

        public Chain(string name, string cvr)
        {
            Name = name;
            CVR = cvr;
        }


    }
}