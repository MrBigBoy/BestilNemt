using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
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
        public int ShopId { get; set; }

        [DataMember]
        public int ChainId { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Cart()
        {
            PartOrders = new List<PartOrder>();
        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="partOrders"></param>
        /// <param name="totalprice"></param>
        /// <param name="personId"></param>
        /// <param name="shopId"></param>
        public Cart(List<PartOrder> partOrders, decimal totalprice, int personId, int shopId)
        {
            PartOrders = partOrders;
            TotalPrice = totalprice;
            PersonId = personId;
            ShopId = shopId;
        }

        /// <summary>
        /// Constructor with id using the constructor without id with this
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partOrders"></param>
        /// <param name="totalprice"></param>
        /// <param name="personId"></param>
        /// <param name="shopId"></param>
        public Cart(int id, List<PartOrder> partOrders, decimal totalprice, int personId, int shopId) : this(partOrders, totalprice, personId, shopId)
        {
            Id = id;
        }
    }
}
