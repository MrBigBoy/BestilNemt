using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace Controller
{
    public class AdminCtr
    {

        public IDbAdmin DbAdmin { get; set; }

        public AdminCtr(IDbAdmin dbAdmin)
        {
            DbAdmin = dbAdmin;
        }

        public void CreateAdmin(Admin admin)
        {
            DbAdmin.Create(admin);
        }
        public Admin FindAdmin(int id)
        {
            return DbAdmin.FindAdmin(id);
        }

        public List<Admin> GetAllAdmins()
        {
            return DbAdmin.FindAllAdmins();
        }

        public int RemoveAdmin(int id)
        {
            return DbAdmin.RemoveAdmin(id);
        }

        public void UpdateAdmin(Admin admin)
        {
            DbAdmin.UpdateAdmin(admin);
        }
    }
}
