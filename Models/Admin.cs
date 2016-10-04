using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin : Person
    {
        public Admin(int id, string name, string email, string address): base(id, name, email, address)
        {
            
        }

    }
}
