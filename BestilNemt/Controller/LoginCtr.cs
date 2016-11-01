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

        public int AddLogin(string username, string password, int personId)
        {
            return DbLogin.AddLogin(username, password, personId);
        }

        public Login Login(string username, string password)
        {
            return DbLogin.Login(username, password);
        }
    }
}
