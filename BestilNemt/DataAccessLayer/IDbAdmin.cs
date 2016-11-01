using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    interface IDbAdmin
    {
        int Create(Admin admin);
        int RemoveAdmin(int id);
        Admin FindAdmin(int id);
        List<Admin> FindAllAdmins();
        int UpdateAdmin(Admin admin);
    }
}
