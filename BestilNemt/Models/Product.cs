using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Product Class
    /// </summary>
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
        public int? SavingId { get; set; }

        [DataMember]
        public string ImgPath { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="savingId"></param>
        /// <param name="imgPath"></param>
        public Product(string name, decimal price, string description, string category, int? savingId, string imgPath) : this()
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            SavingId = savingId;
            ImgPath = imgPath;
        }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="savingId"></param>
        /// <param name="imgPath"></param>
        public Product(int id, string name, decimal price, string description, string category, int? savingId, string imgPath) : this(name, price, description, category, savingId, imgPath)
        {
            Id = id;
        }
    }
}
