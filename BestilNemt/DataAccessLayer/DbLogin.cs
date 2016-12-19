using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class DbLogin : IDbLogin
    {
        // These constants may be changed without breaking existing hashes.
        public const int SaltBytes = 24;
        public const int HashBytes = 18;
        public const int Pbkdf2Iterations = 64000;

        // These constants define the encoding and may not be changed.
        public const int HashAlgorithmIndex = 0;
        public const int IterationIndex = 1;
        public const int HashSizeIndex = 2;
        public const int SaltIndex = 3;
        public const int Pbkdf2Index = 4;
        public const int HashSections = 5;

        ///// <summary>
        ///// Add a Login
        ///// </summary>
        ///// <param name="login"></param>
        ///// <returns>
        ///// Id of Login if added, else 0
        ///// </returns>
        //public int AddLogin(Login login)
        //{
        //    var returnedValue = 0;
        //    // Check if a person with the Username is already in the system
        //    if (DownloadPersonId(login.Username) != 0)
        //        return returnedValue;
        //    // Create the parts for the password, containing all the information about a password to login
        //    var parts = CreateHash(login.Password);
        //    using (
        //        var conn =
        //            new SqlConnection(
        //                ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        // Open the connection
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "INSERT into LoginTable output inserted.loginTableId values(@loginTableUsername,@loginTableParts,@loginTablePersonId)";
        //            cmd.Parameters.AddWithValue("loginTableUsername", login.Username);
        //            cmd.Parameters.AddWithValue("loginTableParts", parts);
        //            cmd.Parameters.AddWithValue("loginTablePersonId", login.PersonId);
        //            returnedValue = (int)cmd.ExecuteScalar();
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
        //    return returnedValue;
        //}

        /// <summary>
        /// Login with a Login object
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return Login if validated = true, else null
        /// </returns>
        public Login Login(Login login)
        {
            // Get the parts mathing the Username. The parts holds information about algoritm, number of iterations, salt and other stuff to try to login
            var parts = DownloadHash(login.Username);
            // Verify the password
            if (string.IsNullOrEmpty(parts) || !VerifyPassword(login.Password, parts))
            {
                // The password did not match the username, return a null
                return null;
            }
            // The password did match, return the personId related to the username
            login.PersonId = DownloadPersonId(login.Username);
            // return the Login object with the username, password and a personId
            return login;
        }

        ///// <summary>
        ///// Update a Login
        ///// </summary>
        ///// <param name="login"></param>
        ///// <returns>
        ///// Return 1 if Login is updated, else 0
        ///// </returns>
        //public int UpdateLogin(Login login)
        //{
        //    // Create the Hash called parts holding all information to check for new passwords
        //    var parts = CreateHash(login.Password);
        //    var i = 0;
        //    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "UPDATE LoginTable SET loginTableUsername=@LoginTableUsername, loginTableParts=@LoginTableParts WHERE loginTablePersonId=@LoginTablePersonId";
        //            cmd.Parameters.AddWithValue("LoginTableUsername", login.Username);
        //            cmd.Parameters.AddWithValue("LoginTableParts", parts);
        //            cmd.Parameters.AddWithValue("LoginTablePersonId", login.PersonId);
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
        ///// Delete a Login
        ///// </summary>
        ///// <param name="login"></param>
        ///// <returns>
        ///// Return 1 if Login is deleted, else 0
        ///// </returns>
        //public int DeleteLogin(Login login)
        //{
        //    var i = 0;
        //    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "DELETE FROM LoginTable WHERE loginTablePersonId = @LoginTablePersonId";
        //            cmd.Parameters.AddWithValue("LoginTablePersonId", login.PersonId);
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
        /// Return the Hash from a username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// String of Hash
        /// </returns>
        private static string DownloadHash(string username)
        {
            string parts = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                // Now the connection is open
                var cmd = new SqlCommand("SELECT * FROM LoginTable where loginTableUsername=@LoginTableUsername", conn);
                cmd.Parameters.AddWithValue("LoginTableUsername", username);
                var loginReader = cmd.ExecuteReader();
                if (!loginReader.HasRows)
                    return null;
                while (loginReader.Read())
                {
                    parts = loginReader.GetString(loginReader.GetOrdinal("loginTableParts"));
                }
            }
            return parts;
        }

        /// <summary>
        /// Return a Person id by a username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// Int Person id
        /// </returns>
        public static int DownloadPersonId(string username)
        {
            var personId = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                // Now the connection is open
                var cmd = new SqlCommand("SELECT * FROM LoginTable where loginTableUsername=@LoginTableUsername", conn);
                cmd.Parameters.AddWithValue("LoginTableUsername", username);
                var loginReader = cmd.ExecuteReader();
                if (!loginReader.HasRows)
                    return 0;
                while (loginReader.Read())
                {
                    personId = loginReader.GetInt32(loginReader.GetOrdinal("loginTablePersonId"));
                }
            }
            return personId;
        }

        /// <summary>
        /// Return a generated Hash from a password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>
        /// String of Hash
        /// </returns>
        public static string CreateHash(string password)
        {
            // Generate a random salt
            var salt = new byte[SaltBytes];
            try
            {
                // Use a cryto service
                using (var csprng = new RNGCryptoServiceProvider())
                {
                    // Fils the salt array with random values
                    csprng.GetBytes(salt);
                }
            }
            catch (CryptographicException ex)
            {
                throw new CannotPerformOperationException(
                    "Random number generator not available.",
                    ex
                );
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to random number generator.",
                    ex
                );
            }

            // Create the hash string with the salted password, the salt, the number of iterations and the Hash bytes
            var hash = Pbkdf2(password, salt, Pbkdf2Iterations, HashBytes);

            // format: algorithm:iterations:hashSize:salt:hash
            var parts = "sha1:" +
                Pbkdf2Iterations +
                ":" +
                hash.Length +
                ":" +
                Convert.ToBase64String(salt) +
                ":" +
                Convert.ToBase64String(hash);
            // Return the parts
            return parts;
        }

        /// <summary>
        /// Verify the password with the parts in the database
        /// </summary>
        /// <param name="password"></param>
        /// <param name="goodHash"></param>
        /// <returns>
        /// Return true if password is correct, else false
        /// </returns>
        public static bool VerifyPassword(string password, string goodHash)
        {
            // Set the splitter
            char[] delimiter = { ':' };
            // split by the delimiter
            var split = goodHash.Split(delimiter);

            // Check if the length match
            if (split.Length != HashSections)
            {
                throw new InvalidHashException(
                    "Fields are missing from the password hash."
                );
            }

            // Check if the algoritm match
            if (split[HashAlgorithmIndex] != "sha1")
            {
                throw new CannotPerformOperationException(
                    "Unsupported hash type."
                );
            }

            int iterations;
            // Try to get the number of iterations
            try
            {
                iterations = int.Parse(split[IterationIndex]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Int32.Parse",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Could not parse the iteration count as an integer.",
                    ex
                );
            }
            catch (OverflowException ex)
            {
                throw new InvalidHashException(
                    "The iteration count is too large to be represented.",
                    ex
                );
            }

            if (iterations < 1)
            {
                throw new InvalidHashException(
                    "Invalid number of iterations. Must be >= 1."
                );
            }

            byte[] salt;
            // Get the salt as a byte array
            try
            {
                salt = Convert.FromBase64String(split[SaltIndex]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Convert.FromBase64String",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Base64 decoding of salt failed.",
                    ex
                );
            }

            byte[] hash;
            // Get the hash as a byte array
            try
            {
                hash = Convert.FromBase64String(split[Pbkdf2Index]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Convert.FromBase64String",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Base64 decoding of pbkdf2 output failed.",
                    ex
                );
            }

            int storedHashSize;
            // Get the size of the hash
            try
            {
                storedHashSize = int.Parse(split[HashSizeIndex]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException(
                    "Invalid argument given to Int32.Parse",
                    ex
                );
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException(
                    "Could not parse the hash size as an integer.",
                    ex
                );
            }
            catch (OverflowException ex)
            {
                throw new InvalidHashException(
                    "The hash size is too large to be represented.",
                    ex
                );
            }

            // If the length of the hash does not match
            if (storedHashSize != hash.Length)
            {
                throw new InvalidHashException(
                    "Hash length doesn't match stored hash length."
                );
            }

            // Save the hash as a string
            var testHash = Pbkdf2(password, salt, iterations, hash.Length);
            // Slow test the testhash matching the hash from the database
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// This function is slow to compare to make it to hard to force a password compare
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// Return True if the two byte list is equal, else false
        /// </returns>
        private static bool SlowEquals(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            return StructuralComparisons.StructuralEqualityComparer.Equals(a, b);
        }

        /// <summary>
        /// Return a Byte array after the iterations has passed
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="iterations"></param>
        /// <param name="outputBytes"></param>
        /// <returns>
        /// Return Byte[]
        /// </returns>
        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            // Salt and hash the raw password
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                // Return the byte array of the hashed password
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }

    /// <summary>
    /// Exceptions catched from Hash function
    /// </summary>
    internal class InvalidHashException : Exception
    {
        public InvalidHashException() { }
        public InvalidHashException(string message)
            : base(message) { }
        public InvalidHashException(string message, Exception inner)
            : base(message, inner) { }
    }

    /// <summary>
    /// Exceptions cathced from Validation of Hash string
    /// </summary>
    internal class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException() { }
        public CannotPerformOperationException(string message)
            : base(message) { }
        public CannotPerformOperationException(string message, Exception inner)
            : base(message, inner) { }
    }
}
