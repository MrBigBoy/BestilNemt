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

        public int AddLogin(Login login)
        {
            return !ValidateLoginInput(login) ? 0 : DbLogin.AddLogin(login);
        }

        public Login Login(Login login)
        {
            return ValidateLoginInput(login) ? DbLogin.Login(login) : null;
        }

        public int DelLogin(Login login)
        {
            return !ValidateLoginInput(login) ? 0 : DbLogin.DelLogin(login);
        }

        public int UpdateLogin(Login login)
        {
            return !ValidateLoginInput(login) ? 0 : DbLogin.UpdateLogin(login);
        }

        /// <summary>
        /// The Username must be a string of minimum 5 char
        /// The Password must be a string of minimum 6 char
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool ValidateLoginInput(Login login)
        {
            return login?.Username != null && !login.Username.Equals("") && login.Username.Length >= 5 && login.Password != null && !login.Password.Equals("") && login.Password.Length >= 6;
        }
    }
}
