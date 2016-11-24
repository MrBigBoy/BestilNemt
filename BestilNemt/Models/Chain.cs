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
        public string Cvr { get; set; }
        [DataMember]
        public string ImgPath { get; set; }
        [DataMember]
        public List<Person> Persons { get; set; }
        [DataMember]
        public List<Shop> Shops { get; set; }

        public Chain()
        {
            Persons = new List<Person>();
            Shops = new List<Shop>();
        }

        public Chain(int id, string name, string cvr, string imgPath, List<Person> persons, List<Shop> shops)
        {
            Id = id;
            Name = name;
            Cvr = cvr;
            ImgPath = imgPath;
            Persons = persons;
            Shops = shops;
        }

        public Chain(string name, string cvr, string imgPath)
        {
            Name = name;
            Cvr = cvr;
            ImgPath = imgPath;
        }
    }
}
