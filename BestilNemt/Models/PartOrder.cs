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
        public PartOrder()
        {

        }
    }
}
