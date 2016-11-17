using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Shop
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Cvr { get; set; }

        [DataMember]
        public Chain Chain { get; set; }

        [DataMember]
        public List<Warehouse> Warehouses { get; set; }

        public Shop()
        {
            Warehouses = new List<Warehouse>();
        }

        public Shop(int id, string name, string address, string cvr, Chain chain, List<Warehouse> warehouses)
        {
            Id = id;
            Name = name;
            Address = address;
            Cvr = cvr;
            Chain = chain;
            Warehouses = warehouses;
        }
    }
}