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
        [DataMember]
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
        public Product(int id,string name, decimal price, string description,string category, double saving, Warehouse Warehouse)
        {
            Id = Id;
            Name = Name;
            Price = Price;
            Description = Description;
            Category = category;
            Saving = saving; 
            Warehouse = new Warehouse();

        }
    }
}
