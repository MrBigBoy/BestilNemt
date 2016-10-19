using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Saving
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxAmount { get; set; }
        public Product Product { get; set; }

        public Saving(int id, int percent, decimal discountPrice, DateTime satrtDate, DateTime endDate, int maxAmount )
        {
            this.Id = id;
            this.Percent = percent;
            this.DiscountPrice = discountPrice;
            this.StartDate = satrtDate;
            this.EndDate = endDate;
            this.MaxAmount = maxAmount;

        }
    }
}
