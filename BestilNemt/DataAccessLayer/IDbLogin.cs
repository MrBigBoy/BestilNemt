using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbLogin
    /// </summary>
    public interface IDbLogin
    {
        Login Login(Login login);
        int AddLogin(Login login);
        int UpdateLogin(Login login);
        int DeleteLogin(Login login);
    }
}
