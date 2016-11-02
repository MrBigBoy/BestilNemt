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

        public int CreateAdmin(Admin admin)
        {
           return ValidateAdminInput(admin) ? DbAdmin.Create(admin) : 0;
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

        public int UpdateAdmin(Admin admin)
        {
            return ValidateAdminInput(admin) ? DbAdmin.UpdateAdmin(admin) : 0;
        }

        private bool ValidateAdminInput(Admin admin)
        {
            if (admin == null || admin.Name.Equals("") || admin.Name == null || admin.Address.Equals("") ||
                admin.Address == null || admin.Email == null || admin.Email.Equals("") || admin.PersonType != "Administator")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
