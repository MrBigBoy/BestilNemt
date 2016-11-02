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

        /// <summary>
        /// The main constructor all contructors is depending on
        /// </summary>
        public Login()
        {

        }

        /// <summary>
        /// The Login contructor with use of constructor chaining
        /// </summary>
        /// <param name="id"></param>
        public Login(int id) : this()
        {
            Id = id;
        }

        /// <summary>
        /// The Login contructor with use of constructor chaining
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Login(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// The Login contructor with use of constructor chaining
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="personId"></param>
        public Login(string username, string password, int personId) : this(username, password)
        {
            PersonId = personId;
        }

        /// <summary>
        /// The Login contructor with use of constructor chaining
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="personId"></param>
        public Login(int id, string username, string password, int personId) : this(username, password, personId)
        {
            Id = id;
        }
    }
}
