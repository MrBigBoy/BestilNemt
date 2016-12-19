using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbCustomer : IDbCustomer
    {
        ///// <summary>
        ///// Add a Customer
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <returns>
        ///// Return 1 if Customer is added, else 0
        ///// </returns>
        //public int AddCustomer(Customer customer)
        //{
        //    var id = 0;
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
        //            cmd.CommandText = "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress) output inserted.personId VALUES(@name, @email, 'Customer', @address); SELECT @DataID = scope_identity(); INSERT INTO Customer(customerId,customerBirthday) VALUES(@DataID,@birthday);";
        //            cmd.Parameters.AddWithValue("name", customer.Name);
        //            cmd.Parameters.AddWithValue("email", customer.Email);
        //            cmd.Parameters.AddWithValue("address", customer.Address);
        //            cmd.Parameters.AddWithValue("birthday", customer.Birthday);
        //            // Get the id
        //            id = (int)cmd.ExecuteScalar();
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
        //    return id;
        //}

        ///// <summary>
        ///// Delete a Customer by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Customer is deleted, else 0
        ///// </returns>
        //public int DeleteCustomer(int id)
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
        //            cmd.CommandText = "Delete from Customer where customerId = @id;Delete from Person where personId = @id";
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

        ///// <summary>
        ///// Get all Customers
        ///// </summary>
        ///// <returns>
        ///// Return List of Customer
        ///// </returns>
        //public List<Customer> GetAllCustomer()
        //{
        //    var customers = new List<Customer>();
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("SELECT personId, personName, personEmail, personAddress, personType, customerBirthday FROM Person LEFT JOIN Customer ON Person.personId = Customer.customerId WHERE Person.personType = 'Customer'", conn);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            // Build the Customer object
        //            var customer = ObjectBuilder.CreateCustomer(reader);
        //            // Add the Customer to the list
        //            customers.Add(customer);
        //        }
        //    }
        //    return customers;
        //}

        ///// <summary>
        ///// Update a Customer
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <returns>
        ///// Return 1 if Customer is updated, else 0
        ///// </returns>
        //public int UpdateCustomer(Customer customer)
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
        //            cmd.CommandText = "UPDATE Person SET personName=@name, personEmail=@email, personAddress=@address WHERE personId=@id; " +
        //                                      "UPDATE Customer SET customerBirthday=@birthday WHERE customerId = @id";
        //            cmd.Parameters.AddWithValue("id", customer.Id);
        //            cmd.Parameters.AddWithValue("name", customer.Name);
        //            cmd.Parameters.AddWithValue("email", customer.Email);
        //            cmd.Parameters.AddWithValue("address", customer.Address);
        //            cmd.Parameters.AddWithValue("birthday", customer.Birthday);
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
