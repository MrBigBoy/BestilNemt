using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract(IsReference = true)]

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<Saving> Savings { get; set; }
        public Warehouse Warehouse { get; set; }



        public Product()
        {
            Savings = new List<Saving>();
            
        }

    }
}
