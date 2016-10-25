using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract(IsReference = true)]
    public class Saving
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Percent { get; set; }

        [DataMember]
        public decimal DiscountPrice { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public int MaxAmount { get; set; }

        [DataMember]
        public Product Product { get; set; }

        public Saving(int id, int percent, decimal discountPrice, DateTime satrtDate, DateTime endDate, int maxAmount)
        {
            Id = id;
            Percent = percent;
            DiscountPrice = discountPrice;
            StartDate = satrtDate;
            EndDate = endDate;
            MaxAmount = maxAmount;
        }
    }
}
