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

        [DataMember]
        public Shop Shop { get; set; }

        public Warehouse(int id, int stock, int minStock, Product product, Shop shop)
        {
            Id = Id;
            Stock = Stock;
            MinStock = MinStock;
            Products = new List<Product>();
            Shop = new Shop();
        }

        public Warehouse()
        {
            Id = Id;
            Stock = Stock;
            MinStock = MinStock;
        }

        //public Warehouse(int stock, int MinStock)
        //{
        //    Stock = Stock;
        //    MinStock = MinStock;
        //}

    }
}