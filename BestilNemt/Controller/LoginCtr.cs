using DataAccessLayer;
using Models;

namespace Controller
{
    public class LoginCtr
    {
        public IDbLogin DbLogin { get; set; }
        public LoginCtr(IDbLogin dbLogin)
        {
            DbLogin = dbLogin;
        }
        public Login Login(string username, string password)
        {
            return DbLogin.Login(username, password);
        }
    }
}
