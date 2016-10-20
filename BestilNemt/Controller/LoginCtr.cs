using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LoginCtr
    {
        public static Login Login(string Username, string Password)
        {
            return DbLogin.Login(Username, Password);
        }
    }
}
