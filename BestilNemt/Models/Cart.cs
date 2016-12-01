using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public List<PartOrder> PartOrders { get; set; }

        [DataMember]
        public decimal TotalPrice { get; set; }

        [DataMember]
        public int PersonId { get; set; }

        [DataMember]
        public int ChainId { get; set; }

        public Cart(int id, List<PartOrder> partOrders, decimal totalprice, int personId, int chainId)
        {
            Id = id;
            PartOrders = partOrders;
            TotalPrice = totalprice;
            PersonId = personId;
            ChainId = chainId;
        }

        public Cart()
        {
            Id = Id;
            PartOrders = new List<PartOrder>();
            TotalPrice = TotalPrice;
        }

        public Cart(List<PartOrder> partOrders, decimal totalprice, int personId, int chainId)
        {
            PartOrders = partOrders;
            TotalPrice = totalprice;
            PersonId = personId;
            ChainId = chainId;
        }
    }
}
