using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PartOrder
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal PartPrice { get; set; }

        public PartOrder()
        {
                
        }
    }
}
