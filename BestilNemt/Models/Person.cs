using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
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
        public Login Login { get; set; }
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
        }


    }
    

}
