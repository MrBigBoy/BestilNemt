using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract (IsReference = true)]
    public class Warehouse
    {
        [DataMember]
        public int Id  { get; set; }
        [DataMember]
        public  int Stock { get; set; }
        [DataMember]
        public int MinStock  { get; set; }
        [DataMember]
        public List< Product> Products { get; set; }
        [DataMember]
        public Shop Shop { get; set; }


        public Warehouse()
        {
            Products = new List<Product>();
        }
    }
}