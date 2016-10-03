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
        public List< PartOrder> PartOrders = new List<PartOrder>();
        public decimal TotalPrice { get; set; }
        public Person Person { get; set; }

        public Cart()
        {
            //hallo
        }
    }
}
