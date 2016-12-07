using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    public class Admin : Person
    {
        [DataMember]
        public int Membernr { get; set; }
        [DataMember]
        public int ShopId { get; set; }
        public Admin(int id, string name, string email, string address, Login login, List<Chain> chains , string personType,int membernr, int shopId) : base(id, name, email, address, login, chains, personType)
        {
            Membernr = membernr;
            ShopId = shopId;
        }

        public Admin()
        {
            
        }

        public Admin(string name, string email, string address, string personType, int membernr)
        {
            Name = name;
            Email = email;
            Address = address;
            PersonType = personType;
            Membernr = membernr;
        }
    }
}
