using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract(IsReference = true)]
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }

        public Login()
        {
            Id = 0;
            Username = null;
            Password = null;
            PersonId = 0;
        }

        public Login(int Id, string Username, string Password, int PersonId)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.PersonId = PersonId;
        }
    }
}
