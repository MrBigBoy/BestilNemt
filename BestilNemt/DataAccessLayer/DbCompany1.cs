using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbCompany : IDbCompany
    {
        /// <summary>
        /// Add a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Return 1 if Company is added, else 0
        /// </returns>
        public int AddCompany(Company company)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();

                var cmd =
                    new SqlCommand(
                        "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Company(companyId, companyCVR, companyKontorNr) VALUES(@DataID,@CVR,@KontorNr);", conn);
                cmd.Parameters.AddWithValue("name", company.Name);
                cmd.Parameters.AddWithValue("email", company.Email);
                cmd.Parameters.AddWithValue("personType", company.PersonType);
                cmd.Parameters.AddWithValue("address", company.Address);
                cmd.Parameters.AddWithValue("CVR", company.CVR);
                cmd.Parameters.AddWithValue("KontorNr", company.Kontonr);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a list of Companys
        /// </summary>
        /// <returns>
        /// Return List of Company
        /// </returns>
        public List<Company> FindAllCompany()
        {
            var companys = new List<Company>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, companyCVR, companyKontorNr FROM Person LEFT JOIN Company ON Person.personId = Company.companyId WHERE Person.personType = 'Company'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var company = ObjectBuilder.CreateCompany(reader);
                    companys.Add(company);
                }
            }
            return companys;
        }

        /// <summary>
        /// Return a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Company if found, else null
        /// </returns>
        public Company FindCompany(int id)
        {
            Company company = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, companyCVR, companyKontorNr FROM Person LEFT JOIN Company ON Person.personId = Company.companyId WHERE Person.personId = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    company = ObjectBuilder.CreateCompany(reader);
                }
            }
            return company;
        }

        /// <summary>
        /// Delete a Company by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Company is removed, else 0
        /// </returns>
        public int RemoveCompany(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Delete from Company where companyId = @id;Delete from Person where personId = @id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Update a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Return 1 if Company is updated, else 0
        /// </returns>
        public int UpdateCompany(Company company)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand("UPDATE Person SET personName=@name, personEmail=@email, personAddress=@address WHERE personId=@id",
                        conn);
                cmd.Parameters.AddWithValue("id", company.Id);
                cmd.Parameters.AddWithValue("name", company.Name);
                cmd.Parameters.AddWithValue("email", company.Email);
                cmd.Parameters.AddWithValue("address", company.Address);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
