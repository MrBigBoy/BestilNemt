using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbCustomer : IDbCustomer
    {
        /// <summary>
        /// Get a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Customer if found, else null
        /// </returns>
        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, customerBirthday FROM Person LEFT JOIN Customer ON Person.personId = Customer.customerId WHERE Person.personId = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Customer object
                    customer = ObjectBuilder.CreateCustomer(reader);
                }
            }
            return customer;
        }

        /// <summary>
        /// Add a Customer with a login
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="login"></param>
        /// <returns>
        /// Id of Customer if added, else 0
        /// </returns>
        public int AddCustomerWithLogin(Customer customer, Login login)
        {
            var id = 0;
            // Check if a user with the Username already exist
            if (DbLogin.DownloadPersonId(login.Username) != 0)
                return id;
            // Generate the hash with the login
            var parts = DbLogin.CreateHash(login.Password);
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var cmd2 = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd2.Transaction = transaction;
                try
                {
                    // Add the Customer
                    cmd.CommandText = "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress) output inserted.personId VALUES(@name, @email, 'Customer', @address);" +
                                              " SELECT @DataID = scope_identity(); INSERT INTO Customer(customerId,customerBirthday) VALUES(@DataID,@birthday);";
                    cmd.Parameters.AddWithValue("name", customer.Name);
                    cmd.Parameters.AddWithValue("email", customer.Email);
                    cmd.Parameters.AddWithValue("address", customer.Address);
                    cmd.Parameters.AddWithValue("birthday", customer.Birthday);
                    // Get the id of the Customer
                    id = (int)cmd.ExecuteScalar();

                    // Add the Login
                    cmd2.CommandText = "INSERT into LoginTable values(@loginTableUsername,@loginTableParts,@loginTablePersonId)";
                    cmd2.Parameters.AddWithValue("loginTableUsername", login.Username);
                    cmd2.Parameters.AddWithValue("loginTableParts", parts);
                    cmd2.Parameters.AddWithValue("loginTablePersonId", id);
                    cmd2.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // The transaction failed
                    try
                    {
                        // Try rolling back
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        // Rolling back failed
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return id;
        }
    }
}
