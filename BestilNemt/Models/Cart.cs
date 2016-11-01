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

        public Cart(int id, List<PartOrder> partOrders, decimal totalprice)
        {
            Id = id;
            PartOrders = partOrders;
            TotalPrice = totalprice; 
        }

        public Cart()
        {
            Id = Id;
            PartOrders = new List<PartOrder>();
            TotalPrice = TotalPrice;
        }
    }
}
