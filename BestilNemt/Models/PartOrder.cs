using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The PartOrder class
    /// </summary>
    [DataContract(IsReference = true)]
    public class PartOrder
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public int Amount { get; set; }

        [DataMember]
        public decimal PartPrice { get; set; }

        [DataMember]
        public Cart Cart { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public PartOrder()
        {
        }

        /// <summary>
        /// Constructor without cart or id
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <param name="partPrice"></param>
        public PartOrder(Product product, int amount, decimal partPrice)
        {
            Product = product;
            Amount = amount;
            PartPrice = partPrice;
        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <param name="partPrice"></param>
        /// <param name="cart"></param>
        public PartOrder(Product product, int amount, decimal partPrice, Cart cart) : this(product, amount, partPrice)
        {
            Cart = cart;
        }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        /// <param name="partPrice"></param>
        /// <param name="cart"></param>
        public PartOrder(int id, Product product, int amount, decimal partPrice, Cart cart) : this(product, amount, partPrice, cart)
        {
            Id = id;
        }
    }
}
