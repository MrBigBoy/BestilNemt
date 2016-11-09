using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbAdmin
    {
        int Create(Admin admin);
        int RemoveAdmin(int id);
        Admin FindAdmin(int id);
        List<Admin> FindAllAdmins();
        int UpdateAdmin(Admin admin);
    }
}
