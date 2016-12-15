using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class LoginCtrTestClass : IDbLogin
    {
        private List<Login> _logins = new List<Login>();
        private int _idCounter = 1;
        
        public Login Login(Login login)
        {
            foreach (var loginInDb in _logins)
            {
                if (loginInDb.Username.Equals(login.Username) && loginInDb.Password.Equals(login.Password))
                    login.PersonId = loginInDb.PersonId;
            }
            return login;
        }
        
        private int DownloadPersonId(string username)
        {
            var personId = 0;
            foreach (var login in _logins)
            {
                if (!login.Username.Equals(username))
                    continue;
                personId = login.PersonId;
                return personId;
            }
            return personId;
        }
    }
}
