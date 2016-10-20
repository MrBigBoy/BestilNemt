using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract (IsReference = true)]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public List<Login> Logins { get; set; }
        [DataMember]
        public List<Shop> Shops { get; set; }
        

        public Person()
        {
            
        }
        public Person(int id, string name, string email, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            Shops = new List<Shop>();
            Logins = new List<Login>();
        }


    }
    

}
