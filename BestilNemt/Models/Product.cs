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
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Category { get; set; }
        public Saving Saving { get; set; }
        [DataMember]
        public Warehouse Warehouse { get; set; }



        public Product()
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            
        }

    }
}
