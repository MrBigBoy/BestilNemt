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
                            "DECLARE @DataID int; INSERT INTO Person(Name, Email, personType, Address)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Company(id) VALUES(@DataID);", conn);
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
            var companys = new List<Company>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType FROM Person LEFT JOIN Customer ON Person.ID = Company.ID WHERE Person.personType = 'Company'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var company = new Company()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                       
                    };
                    companys.Add(company);
                }
            }
            return companys;
        }

        public Company FindCompany(int id)
        {
            Company company = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType FROM Person LEFT JOIN Company ON Person.ID = Company.ID WHERE Person.ID = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    company = new Company()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        
                    };
                }
            }
            return company;
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
