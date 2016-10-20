using Controller;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    public class BestilNemtService : IBestilNemtService
    {
        private SqlConnection Connection { get; set; }

        public SqlConnection GetConnection()
        {
            if(Connection == null)
            {
                Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString);
            }
            return Connection;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Login Login(string Username, string Password)
        {
            return LoginCtr.Login(Username, Password);
        }
    }
}
