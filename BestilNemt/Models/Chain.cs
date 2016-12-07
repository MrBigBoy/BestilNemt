using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Chain class
    /// </summary>
    [DataContract]
    public class Chain
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Cvr { get; set; }
        [DataMember]
        public string ImgPath { get; set; }
        [DataMember]
        public List<Person> Persons { get; set; }
        [DataMember]
        public List<Shop> Shops { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Chain()
        {
            Persons = new List<Person>();
            Shops = new List<Shop>();
        }

        /// <summary>
        /// constructor without id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cvr"></param>
        /// <param name="imgPath"></param>
        public Chain(string name, string cvr, string imgPath)
        {
            Name = name;
            Cvr = cvr;
            ImgPath = imgPath;
        }

        /// <summary>
        /// Constructor with id, list of Persons and list of Shops
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="cvr"></param>
        /// <param name="imgPath"></param>
        /// <param name="persons"></param>
        /// <param name="shops"></param>
        public Chain(int id, string name, string cvr, string imgPath, List<Person> persons, List<Shop> shops) : this(name, cvr, imgPath)
        {
            Id = id;
            Persons = persons;
            Shops = shops;
        }
    }
}
