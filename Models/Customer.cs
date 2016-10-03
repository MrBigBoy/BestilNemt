using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Customer : Person
    {
        public DateTime Birthday { get; set; }
        public Customer(int id, string name, string email, string address, DateTime birthday) : base(id, name, email, address)
        {
            this.Birthday = birthday;

        }
    }
}
