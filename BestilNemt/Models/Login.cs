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
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int PersonId { get; set; }

        public Login()
        {

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
