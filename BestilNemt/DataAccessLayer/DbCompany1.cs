using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public class DbCompany1 : IDbCompany
    {
        public int CreateCompany(Company company)
        {
                int i;
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
                {
                    conn.Open();

                    var cmd =
                        new SqlCommand(
                            "DECLARE @DataID int; INSERT INTO Person(Name, Email, personType, Address)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Customer(id,birthday) VALUES(@DataID,@birthday);", conn);
                    cmd.Parameters.AddWithValue("name", company.Name);
                    cmd.Parameters.AddWithValue("email", company.Email);
                    cmd.Parameters.AddWithValue("personType", company.PersonType);
                    cmd.Parameters.AddWithValue("address", company.Address);
                    i = cmd.ExecuteNonQuery();

                }
                return i;
            }

        public List<Company> FindAllCompany()
        {
            throw new NotImplementedException();
        }

        public Company FindCompany(int id)
        {
            throw new NotImplementedException();
        }

        public int RemoveCompany(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
