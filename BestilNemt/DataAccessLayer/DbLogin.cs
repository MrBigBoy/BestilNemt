using DataAccessLayer.BestilNemtServiceRef;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbLogin
    {
        static IBestilNemtService proxy = new BestilNemtServiceClient();
        public static Login Login(string Username, string Password)
        {
            Login login = new Login();
            try
            {
                SqlCommand cmd;

                
                //using (SqlConnection conn = proxy.GetConnection())
                using (SqlConnection conn = new SqlConnection("Data Source=kraka.ucn.dk; Database=dmab0915_2Sem_3; User Id=dmab0915_2Sem_3; Password=IsAllowed;"))
                {
                    conn.Open();
                    // Now the connection is open
                    cmd = new SqlCommand("SELECT * FROM LoginTable where username=@username and password1=@password", conn);
                    //cmd = new SqlCommand("SELECT * FROM LoginTable where username='test@mail.dk' and password1='testKode'", conn);
                    cmd.Parameters.AddWithValue("username", Username);
                    cmd.Parameters.AddWithValue("password", Password);
                    SqlDataReader loginReader = cmd.ExecuteReader();
                    if (loginReader.HasRows)
                    {
                        while (loginReader.Read())
                        {
                            login.Id = loginReader.GetInt32(loginReader.GetOrdinal("id"));
                            login.Username = loginReader.GetString(loginReader.GetOrdinal("username"));
                            //login.Password = loginReader.GetString(loginReader.GetOrdinal("password1"));
                            login.PersonId = loginReader.GetInt32(loginReader.GetOrdinal("personId"));
                        }
                    }
                    else
                    {
                        //
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
