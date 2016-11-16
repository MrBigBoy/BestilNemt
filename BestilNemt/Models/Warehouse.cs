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
        public Product Product { get; set; }

        [DataMember]
        public Chain Chain { get; set; }

        public Warehouse()
        {
            
        }

        public Warehouse(int id, int stock, int minStock, Product product, Chain chain) : this()
        {
            Id = id;
            Stock = stock;
            MinStock = minStock;
            Product = product; 
            Chain = chain;
        }

    }
}