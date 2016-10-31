using Models;

namespace DataAccessLayer
{
    public interface IDbLogin
    {
        Login Login(string username, string password);
        int AddLogin(string username, string password, int personId);
    }
}
