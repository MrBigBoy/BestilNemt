using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbAdmin
    /// </summary>
    public interface IDbAdmin
    {
        int AddAdmin(Admin admin);
        int DeleteAdmin(int id);
        Admin GetAdmin(int id);
        List<Admin> GetAllAdmins();
        int UpdateAdmin(Admin admin);
    }
}
