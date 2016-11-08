﻿using DataAccessLayer;
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

        /// <summary>
        /// Add a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return id of Login if added, else 0
        /// </returns>
        public int AddLogin(Login login)
        {
            return !ValidateLoginInput(login) ? 0 : DbLogin.AddLogin(login);
        }

        /// <summary>
        /// Return a Login object if validation is true, else null
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return a Login object if validation is true, else null
        /// </returns>
        public Login Login(Login login)
        {
            return ValidateLoginInput(login) ? DbLogin.Login(login) : null;
        }

        /// <summary>
        /// Delete a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return 1 if Login is deleted, else 0
        /// </returns>
        public int DeleteLogin(Login login)
        {
            return !ValidateLoginInput(login) ? 0 : DbLogin.DeleteLogin(login);
        }

        /// <summary>
        /// Update a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return 1 if Login is updated, else 0
        /// </returns>
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
            return login?.Username != null && !login.Username.Equals("") &&
                login.Username.Length >= 5 && login.Password != null &&
                !login.Password.Equals("") && login.Password.Length >= 6;
        }
    }
}
