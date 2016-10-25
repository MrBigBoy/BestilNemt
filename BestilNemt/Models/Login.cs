using System.Runtime.Serialization;

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

        public Login(int id, string username, string password, int personId)
        {
            Id = id;
            Username = username;
            Password = password;
            PersonId = personId;
        }
    }
}
