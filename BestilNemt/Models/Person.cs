using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// Person Class
    /// </summary>
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
        public string PersonType { get; set; }

        [DataMember]
        public Login Login { get; set; }

        [DataMember]
        public List<Chain> Chains { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Person()
        {
            Chains = new List<Chain>();
        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="login"></param>
        /// <param name="chains"></param>
        /// <param name="personType"></param>
        public Person(string name, string email, string address, Login login, List<Chain> chains, string personType)
        {
            Name = name;
            Email = email;
            Address = address;
            Login = login;
            Chains = chains;
            PersonType = personType;
        }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="login"></param>
        /// <param name="chains"></param>
        /// <param name="personType"></param>
        public Person(int id, string name, string email, string address, Login login, List<Chain> chains, string personType) : this(name, email, address, login, chains, personType)
        {
            Id = id;
        }
    }
}
