using System.Runtime.Serialization;

namespace Models
{
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
        public PartOrder(int id, Product product, int amount, decimal partPrice, Cart cart)
        {
            Id = id;
            Product = product;
            Amount = amount;
            PartPrice = partPrice;
            Cart = cart; 

        }

        public PartOrder()
        {
            Id = Id;
            Product = Product;
            Amount = Amount;
            PartPrice = PartPrice;
            Cart = Cart;
        }

        public PartOrder(Product product, int amount, decimal partPrice, Cart cart)
        {
            Product = product;
            Amount = amount;
            PartPrice = partPrice;
            Cart = cart;
        }
    }
}
