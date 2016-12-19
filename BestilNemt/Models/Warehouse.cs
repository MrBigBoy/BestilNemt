using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Warehouse class
    /// </summary>
    [DataContract]
    public class Warehouse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public int MinStock { get; set; }

        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public Shop Shop { get; set; }

        [DataMember]
        public int? SavingId { get; set; }


        /// <summary>
        /// Empty constructor
        /// </summary>
        public Warehouse()
        {

        }

        /// <summary>
        /// Constructor with stock, minStock and product
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="minStock"></param>
        /// <param name="product"></param>
        public Warehouse(int stock, int minStock, Product product) : this()
        {
            Stock = stock;
            MinStock = minStock;
            Product = product;
        }

        /// <summary>
        /// Constructor with stock, minStock, product and shop
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="minStock"></param>
        /// <param name="product"></param>
        /// <param name="shop"></param>
        /// <param name="savingId"></param>
        public Warehouse(int stock, int minStock, Product product, Shop shop, int? savingId) : this(stock, minStock, product)
        {
            Shop = shop;
            SavingId = savingId;
        }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stock"></param>
        /// <param name="minStock"></param>
        /// <param name="product"></param>
        /// <param name="shop"></param>
        /// <param name="savingId"></param>
        public Warehouse(int id, int stock, int minStock, Product product, Shop shop, int? savingId) : this(stock, minStock, product, shop, savingId)
        {
            Id = id;
        }

        /// <summary>
        /// Constructor for SerializationTest
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stock"></param>
        /// <param name="minStock"></param>
        public Warehouse(int id, int stock, int minStock)
        {
            Id = id;
            Stock = stock;
            MinStock = minStock;
        }
    }
}
