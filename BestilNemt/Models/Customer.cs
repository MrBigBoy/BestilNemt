using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Customer class inherit from Person
    /// </summary>
    [DataContract]
    public class Customer : Person
    {
        [DataMember]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Empty Customer
        /// </summary>
        public Customer()
        {

        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="birthday"></param>
        /// <param name="login"></param>
        /// <param name="chains"></param>
        /// <param name="personType"></param>
        public Customer(string name, string email, string address, DateTime birthday, Login login, List<Chain> chains, string personType) : base(name, email, address, login, chains, personType)
        {
            Birthday = birthday;
        }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="birthday"></param>
        /// <param name="login"></param>
        /// <param name="chains"></param>
        /// <param name="personType"></param>
        public Customer(int id, string name, string email, string address, DateTime birthday, Login login, List<Chain> chains, string personType) : base(id, name, email, address, login, chains, personType)
        {
            Birthday = birthday;
        }
    }
}
