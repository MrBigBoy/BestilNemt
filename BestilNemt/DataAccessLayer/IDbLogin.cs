namespace DataAccessLayer
{
    public interface IDbLogin
    {
        Models.Login Login(string username, string password);
    }
}
