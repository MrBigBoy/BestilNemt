using Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbLogin
    {
        public Login Login(string Username, string Password)
        {
            Login login = new Login();
            try
            {
                SqlCommand cmd;
 
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
                {
                    conn.Open();
                    // Now the connection is open
                    cmd = new SqlCommand("SELECT * FROM LoginTable where username=@username and password1=@password", conn);
                    cmd.Parameters.AddWithValue("username", Username);
                    cmd.Parameters.AddWithValue("password", Password);
                    SqlDataReader loginReader = cmd.ExecuteReader();
                    if (loginReader.HasRows)
                    {
                        while (loginReader.Read())
                        {
                            login.Id = loginReader.GetInt32(loginReader.GetOrdinal("id"));
                            login.Username = loginReader.GetString(loginReader.GetOrdinal("username"));
                            login.Password = Password;
                            login.PersonId = loginReader.GetInt32(loginReader.GetOrdinal("personId"));
                        }
                    }
                    else
                    {
                        // Error No Lines found
                    }
                }
                return login;
            } catch (Exception ex)
            {
                return login;
            }
        }
    }
}
