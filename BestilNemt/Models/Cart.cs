using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<PartOrder> PartOrders { get; set; }
        public decimal TotalPrice { get; set; }
       

        public Cart()
        {
            PartOrders = new List<PartOrder>();
        }
    }
}
