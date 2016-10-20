using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Warehouse
    {
        [DataMember]
        public int Id  { get; set; }
        [DataMember]
        public  int Stock { get; set; }
        [DataMember]
        public int MinStock  { get; set; }
        [DataMember]
        public List<Product> Products { get; set; }

        public Shop Shop { get; set; }


        public Warehouse()
        {
            this.Id = Id;
            this.Stock = Stock;
            this.MinStock = MinStock;
            Products = new List<Product>();
        }
    }
}