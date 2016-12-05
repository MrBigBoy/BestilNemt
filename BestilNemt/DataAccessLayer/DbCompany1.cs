using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Company(companyId, companyCVR, companyKontoNr) VALUES(@DataID,@CVR,@KontoNr);";
                    cmd.Parameters.AddWithValue("name", company.Name);
                    cmd.Parameters.AddWithValue("email", company.Email);
                    cmd.Parameters.AddWithValue("personType", company.PersonType);
                    cmd.Parameters.AddWithValue("address", company.Address);
                    cmd.Parameters.AddWithValue("CVR", company.CVR);
                    cmd.Parameters.AddWithValue("KontoNr", company.Kontonr);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return i;
        }

        /// <summary>
        /// Return a list of Companys
        /// </summary>
        /// <returns>
        /// Return List of Company
        /// </returns>
        public List<Company> GetAllCompany()
        {
            var companys = new List<Company>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Person, Company WHERE Person.personType = 'Company' AND companyId = personId", conn);
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
        public Company GetCompany(int id)
        {
            Company company = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, companyCVR, companyKontoNr FROM Person LEFT JOIN Company ON Person.personId = Company.companyId WHERE Person.personId = @id", conn);
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
            int i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Delete from Company where companyId = @id;Delete from Person where personId = @id";
                    cmd.Parameters.AddWithValue("Id", id);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
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
            int i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Person SET personName=@name, personEmail=@email, personAddress=@address WHERE personId=@id";
                    cmd.Parameters.AddWithValue("personId", company.Id);
                    cmd.Parameters.AddWithValue("personName", company.Name);
                    cmd.Parameters.AddWithValue("personEmail", company.Email);
                    cmd.Parameters.AddWithValue("personAddress", company.Address);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return i;
        }
    }
}
