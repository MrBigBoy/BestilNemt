using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class DbLogin : IDbLogin
    {
        public int AddLogin(Login login)
        {
            var returnedValue = 0;
            if (DownloadPersonId(login.Username) != 0)
                return returnedValue;
            var parts = PasswordStorage.CreateHash(login.Password);
            using (
                var conn =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                // Now the connection is open
                var cmd = new SqlCommand("INSERT into LoginTable values(@username,@parts,@personId)", conn);
                cmd.Parameters.AddWithValue("username", login.Username);
                cmd.Parameters.AddWithValue("parts", parts);
                cmd.Parameters.AddWithValue("personId", login.PersonId);
                returnedValue = cmd.ExecuteNonQuery();
            }
            return returnedValue;
        }

        public Login Login(Login login)
        {
            var parts = DownloadHash(login.Username);
            if (!PasswordStorage.VerifyPassword(login.Password, parts))
                return null;
            login.PersonId = DownloadPersonId(login.Username);
            return login;
        }

        public int UpdateLogin(Login login)
        {
            var parts = PasswordStorage.CreateHash(login.Password);
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE LoginTable SET username=@username, parts=@parts WHERE personId=@personId", conn);
                cmd.Parameters.AddWithValue("username", login.Username);
                cmd.Parameters.AddWithValue("parts", parts);
                cmd.Parameters.AddWithValue("personId", login.PersonId);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public int DelLogin(Login login)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM LoginTable WHERE personId = @personId", conn);
                cmd.Parameters.AddWithValue("personId", login.PersonId);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        private static string DownloadHash(string username)
        {
            string parts = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                // Now the connection is open
                var cmd = new SqlCommand("SELECT * FROM LoginTable where username=@username", conn);
                cmd.Parameters.AddWithValue("username", username);
                var loginReader = cmd.ExecuteReader();
                if (!loginReader.HasRows)
                    return null;
                while (loginReader.Read())
                {
                    parts = loginReader.GetString(loginReader.GetOrdinal("parts"));
                }
            }
            return parts;
        }

        private static int DownloadPersonId(string username)
        {
            var personId = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                // Now the connection is open
                var cmd = new SqlCommand("SELECT personId FROM LoginTable where username=@username", conn);
                cmd.Parameters.AddWithValue("username", username);
                var loginReader = cmd.ExecuteReader();
                if (!loginReader.HasRows)
                    return 0;
                while (loginReader.Read())
                {
                    personId = loginReader.GetInt32(loginReader.GetOrdinal("personId"));
                }
            }
            return personId;
        }
    }

    internal class InvalidHashException : Exception
    {
        public InvalidHashException() { }
        public InvalidHashException(string message)
            : base(message) { }
        public InvalidHashException(string message, Exception inner)
            : base(message, inner) { }
    }

    internal class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException() { }
        public CannotPerformOperationException(string message)
            : base(message) { }
        public CannotPerformOperationException(string message, Exception inner)
            : base(message, inner) { }
    }

    internal class PasswordStorage
    {
        // These constants may be changed without breaking existing hashes.
        public const int SALT_BYTES = 24;
        public const int HASH_BYTES = 18;
        public const int PBKDF2_ITERATIONS = 64000;

        // These constants define the encoding and may not be changed.
        public const int HASH_SECTIONS = 5;
        public const int HASH_ALGORITHM_INDEX = 0;
        public const int ITERATION_INDEX = 1;
        public const int HASH_SIZE_INDEX = 2;
        public const int SALT_INDEX = 3;
        public const int PBKDF2_INDEX = 4;

        public static string CreateHash(string password)
        {
            // Generate a random salt
            var salt = new byte[SALT_BYTES];
            try
            {
                using (var csprng = new RNGCryptoServiceProvider())
                {
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

            var hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);

            // format: algorithm:iterations:hashSize:salt:hash
            var parts = "sha1:" +
                PBKDF2_ITERATIONS +
                ":" +
                hash.Length +
                ":" +
                Convert.ToBase64String(salt) +
                ":" +
                Convert.ToBase64String(hash);
            return parts;
        }

        public static bool VerifyPassword(string password, string goodHash)
        {
            char[] delimiter = { ':' };
            var split = goodHash.Split(delimiter);

            if (split.Length != HASH_SECTIONS)
            {
                throw new InvalidHashException(
                    "Fields are missing from the password hash."
                );
            }

            // We only support SHA1 with C#.
            if (split[HASH_ALGORITHM_INDEX] != "sha1")
            {
                throw new CannotPerformOperationException(
                    "Unsupported hash type."
                );
            }

            int iterations;
            try
            {
                iterations = int.Parse(split[ITERATION_INDEX]);
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
            try
            {
                salt = Convert.FromBase64String(split[SALT_INDEX]);
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
            try
            {
                hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
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
            try
            {
                storedHashSize = int.Parse(split[HASH_SIZE_INDEX]);
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

            if (storedHashSize != hash.Length)
            {
                throw new InvalidHashException(
                    "Hash length doesn't match stored hash length."
                );
            }

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            var diff = (uint)a.Count ^ (uint)b.Count;
            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt))
            {
                pbkdf2.IterationCount = iterations;
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }
}
