using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class LoginCtrTestClass : IDbLogin
    {
        private List<Login> _logins = new List<Login>();
        private int _idCounter = 1;

        public int AddLogin(Login login)
        {
            var personId = DownloadPersonId(login.Username);
            if (personId != 0)
                return 0;
            login.Id = _idCounter;
            login.PersonId = personId;
            _logins.Add(login);
            _idCounter++;
            return 1;
        }

        public Login Login(Login login)
        {
            foreach (var loginInDb in _logins)
            {
                if (loginInDb.Username.Equals(login.Username) && loginInDb.Password.Equals(login.Password))
                    login.PersonId = loginInDb.PersonId;
            }
            return login;
        }


        public int UpdateLogin(Login login)
        {
            var returnedLogin = login;
            returnedLogin.Username = login.Username;
            returnedLogin.Password = login.Password;
            returnedLogin.PersonId = login.PersonId;
            return 1;
        }

        public int DelLogin(Login login)
        {
            var i = 0;
            foreach (var var in _logins)
            {
                if (var.PersonId != login.PersonId)
                    continue;
                _logins.Remove(var);
                i = 1;
            }
            return i;
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
