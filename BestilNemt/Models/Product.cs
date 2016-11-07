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

        public Product()
        {

        }

        public Product(string name, decimal price, string description, string category, double saving) : this()
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Saving = saving;
        }

        public Product(int id, string name, decimal price, string description, string category, double saving) : this(name, price, description, category, saving)
        {
            Id = id;
        }
    }
}
