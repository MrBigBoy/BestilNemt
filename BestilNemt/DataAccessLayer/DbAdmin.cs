using System.Configuration;
using System.Data.SqlClient;
using Models;


namespace DataAccessLayer
{
    public class DbAdmin : IDbAdmin
    {
        ///// <summary>
        ///// Add a Admin
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns>
        ///// Id of Admin if added, else 0
        ///// </returns>
        //public int AddAdmin(Admin admin)
        //{
        //    var i = 0;
        //    using (
        //        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        // Try to Insert the Admin
        //        try
        //        {
        //            cmd.CommandText = "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress) output inserted.personId VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Administrator(administratorId) VALUES(@DataID);";
        //            cmd.Parameters.AddWithValue("name", admin.Name);
        //            cmd.Parameters.AddWithValue("email", admin.Email);
        //            cmd.Parameters.AddWithValue("personType", admin.PersonType);
        //            cmd.Parameters.AddWithValue("address", admin.Address);
        //            // get the id
        //            i = (int)cmd.ExecuteScalar();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;
        //}

        ///// <summary>
        ///// Delete a Admin
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Admin is removed, else 0
        ///// </returns>
        //public int DeleteAdmin(int id)
        //{
        //    var i = 0;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set the isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "Delete from Administrator where administratorId = @id;Delete from Person where personId = @id";
        //            cmd.Parameters.AddWithValue("Id", id);
        //            i = cmd.ExecuteNonQuery();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;
        //}

        ///// <summary>
        ///// Return a Admin by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return Admin if found, else null
        ///// </returns>
        public Admin GetAdmin(int id)
        {
            Admin admin = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Person LEFT JOIN Administrator ON Person.personId = Administrator.administratorId WHERE Person.personId = @Id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    return null;
                while (reader.Read())
                {
                    // Build the admin object
                    admin = ObjectBuilder.CreateAdmin(reader);
                }
            }
            return admin;
        }

        ///// <summary>
        ///// Get all Admins
        ///// </summary>
        ///// <returns>
        ///// Return List of Admin
        ///// </returns>
        //public List<Admin> GetAllAdmins()
        //{
        //    var admins = new List<Admin>();
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, administratorMemberNr FROM Person LEFT JOIN Administrator ON Person.personId = Administrator.administratorId WHERE Person.personType = 'Administrator'", conn);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            // build the admin object
        //            var admin = ObjectBuilder.CreateAdmin(reader);
        //            admins.Add(admin);
        //        }
        //    }
        //    return admins;
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
        //    var i = 0;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set the transaction level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "UPDATE Person SET personName=@name, personEmail=@email, personAddress=@address WHERE personId=@id";
        //            cmd.Parameters.AddWithValue("personId", admin.Id);
        //            cmd.Parameters.AddWithValue("personName", admin.Name);
        //            cmd.Parameters.AddWithValue("personEmail", admin.Email);
        //            cmd.Parameters.AddWithValue("personAddress", admin.Address);
        //            i = cmd.ExecuteNonQuery();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;
        // }
    }
}
