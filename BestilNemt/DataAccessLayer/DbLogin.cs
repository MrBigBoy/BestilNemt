using Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbLogin : IDbLogin
    {
        public Login Login(string username, string password)
        {
            var login = new Login();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
                {
                    conn.Open();
                    // Now the connection is open
                    var cmd = new SqlCommand("SELECT * FROM LoginTable where username=@username and password1=@password", conn);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    var loginReader = cmd.ExecuteReader();
                    if (loginReader.HasRows)
                    {
                        while (loginReader.Read())
                        {
                            login.Id = loginReader.GetInt32(loginReader.GetOrdinal("id"));
                            login.Username = loginReader.GetString(loginReader.GetOrdinal("username"));
                            login.Password = password;
                            login.PersonId = loginReader.GetInt32(loginReader.GetOrdinal("personId"));
                        }
                    }
                    else
                    {
                        // Error No Lines found
                    }
                }
                return login;
            }
            catch (Exception)
            {
                return login;
            }
        }
    }
}
