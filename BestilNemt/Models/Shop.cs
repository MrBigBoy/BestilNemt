using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Shop class
    /// </summary>
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
        public string OpeningTime { get; set; }

        [DataMember]
        public string Cvr { get; set; }

        [DataMember]
        public Chain Chain { get; set; }

        [DataMember]
        public List<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Shop()
        {
            Warehouses = new List<Warehouse>();
        }

        /// <summary>
        /// The shop constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="cvr"></param>
        /// <param name="openingTime"></param>
        /// <param name="chain"></param>
        /// <param name="warehouses"></param>
        public Shop(int id, string name, string address, string cvr, string openingTime, Chain chain, List<Warehouse> warehouses)
        {
            Id = id;
            Name = name;
            Address = address;
            OpeningTime = openingTime;
            Cvr = cvr;
            Chain = chain;
            Warehouses = warehouses;
        }
    }
}