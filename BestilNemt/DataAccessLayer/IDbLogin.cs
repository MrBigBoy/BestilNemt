using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbLogin
    /// </summary>
    public interface IDbLogin
    {
        Login Login(Login login);
    }
}
