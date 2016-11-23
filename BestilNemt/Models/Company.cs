using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    public class Company : Person
    {
        [DataMember]
        public int CVR { get; set; }
        [DataMember]
        public int  Kontonr { get; set; }
        public Company()
        {
        }

        public Company(int id, string name, string email, string address, Login login, List<Chain> chains, string personType, int cvr, int kontonr) : base(id, name, email, address, login, chains, personType)
        {
            CVR = cvr;
            Kontonr = kontonr; 
        }

        public Company(string name, string email, string address, string personType, int cvr, int kontonr)
        {
            Name = name;
            Email = email;
            Address = address;
            PersonType = personType;
            CVR = cvr;
            Kontonr = kontonr;

        }
    }
}
 