using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbAdmin
    /// </summary>
    public interface IDbAdmin
    {
        //int AddAdmin(Admin admin);
        //int DeleteAdmin(int id);
        Admin GetAdmin(int id);
        //int UpdateAdmin(Admin admin);
    }
}
