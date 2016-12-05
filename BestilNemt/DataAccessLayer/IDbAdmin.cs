using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbAdmin
    {
        int Create(Admin admin);
        int RemoveAdmin(int id);
        Admin GetAdmin(int id);
        List<Admin> GetAllAdmins();
        int UpdateAdmin(Admin admin);
    }
}
