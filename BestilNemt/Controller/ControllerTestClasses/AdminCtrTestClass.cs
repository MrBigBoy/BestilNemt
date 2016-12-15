using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class AdminCtrTestClass : IDbAdmin
    {
        private List<Admin> Admins = new List<Admin>();

        public Admin GetAdmin(int id)
        {
            return Admins.FirstOrDefault(admins => admins.Id == id);
        }
    }
}
