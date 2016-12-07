using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Company class inherit from Person
    /// </summary>
    [DataContract]
    public class Company : Person
    {
        [DataMember]
        public int CVR { get; set; }

        [DataMember]
        public int Kontonr { get; set; }

        /// <summary>
        /// Empty Constructor for Company
        /// </summary>
        public Company()
        {
        }

        /// <summary>
        /// A full Company with all parameters, which used Person as base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="login"></param>
        /// <param name="chains"></param>
        /// <param name="personType"></param>
        /// <param name="cvr"></param>
        /// <param name="kontonr"></param>
        public Company(int id, string name, string email, string address, Login login, List<Chain> chains, string personType, int cvr, int kontonr) : base(id, name, email, address, login, chains, personType)
        {
            CVR = cvr;
            Kontonr = kontonr;
        }

        /// <summary>
        /// Constructor without id, Login object or List of Chain
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="personType"></param>
        /// <param name="cvr"></param>
        /// <param name="kontonr"></param>
        public Company(string name, string email, string address, string personType, int cvr, int kontonr) : base(name, address, email, new Login(), new List<Chain>(), personType)
        {
            CVR = cvr;
            Kontonr = kontonr;
        }
    }
}
