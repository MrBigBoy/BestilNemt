using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Login
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Password { get; set; }

        public Login(int id, int personId, string password)
        {
            this.Id = id;
            this.PersonId = personId;
            this.Password = password;
          
        }
    }
}
