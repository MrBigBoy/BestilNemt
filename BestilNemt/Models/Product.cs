using System.Runtime.Serialization;

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
        public double Saving { get; set; }
        [DataMember]
        public Warehouse Warehouse { get; set; }

        public Product()
        {
            Id = Id;
            Name = Name;
            Price = Price;
            Description = Description;
        }
    }
}
