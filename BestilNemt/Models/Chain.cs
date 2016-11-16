using System.Collections.Generic;
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
        public string Address { get; set; }
        [DataMember]
        public string CVR { get; set; }
        [DataMember]
        public List<Person> Persons { get; set; }
        [DataMember]
        public List<Warehouse> Warehouses { get; set; }

        public Chain()
        {
            Name = null;
            Address = null;
            CVR = null;
            Persons = new List<Person>();
            Warehouses = new List<Warehouse>();
        }

        public Chain(int id, string name, string address, string cvr, List<Person> persons, List<Warehouse> warehouses)
        {
            this.Id = id;
            Name = name;
            Address = address;
            CVR = cvr;
            Persons = persons;
            Warehouses = warehouses;

        }

        public Chain(string name, string address, string cvr)
        {
            Name = name;
            Address = address;
            CVR = cvr;
        }


    }
}
