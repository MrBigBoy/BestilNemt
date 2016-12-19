using DataAccessLayer;
using Models;

namespace Controller
{
    public class LoginCtr
    {
        public IDbLogin DbLogin { get; set; }

        /// <summary>
        /// Constructor for Login controller
        /// </summary>
        /// <param name="dbLogin"></param>
        public LoginCtr(IDbLogin dbLogin)
        {
            DbLogin = dbLogin;
        }
        
        /// <summary>
        /// Method to login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return a Login object if validation is true with a PersonId, else null
        /// </returns>
        public Login Login(Login login)
        {
            return ValidateLoginInput(login) ? DbLogin.Login(login) : null;
        }
        
        /// <summary>
        /// The Username must be a string of minimum 5 char
        /// The Password must be a string of minimum 6 char
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// True if fields is correct, else false
        /// </returns>
        public bool ValidateLoginInput(Login login)
        {
            return !string.IsNullOrEmpty(login?.Username) && !string.IsNullOrEmpty(login.Password) &&
                login.Username.Length >= 5 && login.Password.Length >= 6;
        }
    }
}
