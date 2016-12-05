using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class AdminCtrTestClass : IDbAdmin
    {
        private List<Admin> Admins = new List<Admin>();
        private int IdCounter = 1;
        private int Flag = 0;
        public int Create(Admin admin)
        {
            admin.Id = IdCounter;
            if (ValidateAdminInput(admin))
                Flag = 1;

            Admins.Add(admin);
            IdCounter++;
            return Flag;
        }

        public int RemoveAdmin(int id)
        {
            return Admins.Remove(GetAdmin(id)) ? 1 : 0;
        }

        public Admin GetAdmin(int id)
        {
            return Admins.FirstOrDefault(admins => admins.Id == id);
        }

        public List<Admin> GetAllAdmins()
        {
            return Admins;
        }

        public int UpdateAdmin(Admin admin)
        {
            var returnedAdmin = GetAdmin(admin.Id);
            returnedAdmin.Name = admin.Name;
            returnedAdmin.Address = admin.Address;
            returnedAdmin.Email = admin.Email;

            return 1;
        }

        private bool ValidateAdminInput(Admin admin)
        {
            if (admin == null || admin.Name.Equals("") || admin.Name == null || admin.Address.Equals("") ||
                admin.Address == null || admin.Email == null || admin.Email.Equals("") || admin.PersonType != "Administrator")
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
