using System.Collections.Generic;

namespace Models
{
    public class Warehouse
    {
        public int Id  { get; set; }
        public  int Stock { get; set; }
        public int MinStock  { get; set; }
        public List< Product> Products { get; set; }
        public Shop Shop { get; set; }


        public Warehouse()
        {
            Products = new List<Product>();
        }
    }
}