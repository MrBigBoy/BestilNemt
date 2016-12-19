using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Admin class inherit from Person
    /// </summary>
    [DataContract]
    public class Admin : Person
    {
        [DataMember]
        public int Membernr { get; set; }

        [DataMember]
        public int ShopId { get; set; }

        /// <summary>
        /// Empty Constructor for Admin
        /// </summary>
        public Admin()
        {

        }

        /// <summary>
        /// Constructor for Admin, use of Person class to build
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="login"></param>
        /// <param name="chains"></param>
        /// <param name="personType"></param>
        /// <param name="membernr"></param>
        /// <param name="shopId"></param>
        public Admin(int id, string name, string email, string address, Login login, List<Chain> chains, string personType, int membernr, int shopId) : base(id, name, email, address, login, chains, personType)
        {
            Membernr = membernr;
            ShopId = shopId;
        }

        /// <summary>
        /// Constructor for Admin, used in Test classes
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="personType"></param>
        /// <param name="membernr"></param>
        public Admin(string name, string email, string address, string personType, int membernr) : base(name, email, address, new Login(), new List<Chain>(), personType)
        {
            Membernr = membernr;
        }
    }
}
