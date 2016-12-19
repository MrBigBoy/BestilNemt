using DataAccessLayer;
using Models;

namespace Controller
{
    public class AdminCtr
    {
        public IDbAdmin DbAdmin { get; set; }

        /// <summary>
        /// Constructor for DbAdmin
        /// </summary>
        /// <param name="dbAdmin"></param>
        public AdminCtr(IDbAdmin dbAdmin)
        {
            DbAdmin = dbAdmin;
        }

        ///// <summary>
        ///// Add a Admin
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns>
        ///// Return 1 if Admin is added, else 0
        ///// </returns>
        //public int AddAdmin(Admin admin)
        //{
        //   return ValidateAdminInput(admin) ? DbAdmin.AddAdmin(admin) : 0;
        //}

        /// <summary>
        /// Get a Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Admin object if found, else null
        /// </returns>
        public Admin GetAdmin(int id)
        {
            return DbAdmin.GetAdmin(id);
        }

        ///// <summary>
        ///// Delete a Admin
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Admin is deleted, else 0
        ///// </returns>
        //public int DeleteAdmin(int id)
        //{
        //    return DbAdmin.DeleteAdmin(id);
        //}

        ///// <summary>
        ///// Update a Admin
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns>
        ///// Return 1 if Admin is updated, else 0
        ///// </returns>
        //public int UpdateAdmin(Admin admin)
        //{
        //    return ValidateAdminInput(admin) ? DbAdmin.UpdateAdmin(admin) : 0;
        //}

        ///// <summary>
        ///// Validate input for Admin
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns>
        ///// true if Admin has correct fields, else false
        ///// </returns>
        //// ReSharper disable once SuggestBaseTypeForParameter
        //private static bool ValidateAdminInput(Admin admin)
        //{
        //    return !string.IsNullOrEmpty(admin?.Name) && !string.IsNullOrEmpty(admin.Address) && 
        //        !string.IsNullOrEmpty(admin.Email) && admin.PersonType == "Administrator";
        //}
    }
}
