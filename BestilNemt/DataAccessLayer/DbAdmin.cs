using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.ServiceModel.Channels;
using Models;


namespace DataAccessLayer
{
    public class DbAdmin : IDbAdmin
    {
        /// <summary>
        /// Add a Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>
        /// Return 1 if Admin is added, else 0
        /// </returns>
        public int Create(Admin admin)
        {
            int i;
            using (
                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();

                var cmd =
                    new SqlCommand(
                        "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Administrator(administratorId) VALUES(@DataID);", conn);
                cmd.Parameters.AddWithValue("name", admin.Name);
                cmd.Parameters.AddWithValue("email", admin.Email);
                cmd.Parameters.AddWithValue("personType", admin.PersonType);
                cmd.Parameters.AddWithValue("address", admin.Address);
                i = cmd.ExecuteNonQuery();

            }
            return i;
        }

        /// <summary>
        /// Delete a Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Admin is removed, else 0
        /// </returns>
        public int RemoveAdmin(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Delete from Administrator where administratorId = @id;Delete from Person where personId = @id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a Admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Admin if found, else null
        /// </returns>
        public Admin FindAdmin(int id)
        {
            Admin admin = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT person.personId, personName, personEmail, personAddress, personType, administratorMemberNr FROM Person LEFT JOIN Administrator ON Person.personId = Administrator.administratorId WHERE Person.personId = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    admin = new Admin()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("personId")),
                        Name = reader.GetString(reader.GetOrdinal("personName")),
                        Email = reader.GetString(reader.GetOrdinal("personEmail")),
                        Address = reader.GetString(reader.GetOrdinal("personAddress")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        Membernr = reader.GetInt32(reader.GetOrdinal("administratorMemberNr"))

                    };
                }
            }
            return admin;
        }

        /// <summary>
        /// Return a list of Admins
        /// </summary>
        /// <returns>
        /// Return List of Admin
        /// </returns>
        public List<Admin> FindAllAdmins()
        {
            var admins = new List<Admin>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, administratorMemberNr FROM Person LEFT JOIN Administrator ON Person.personId = Administrator.administratorId WHERE Person.personType = 'Administrator'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var admin = new Admin
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("personId")),
                        Name = reader.GetString(reader.GetOrdinal("personName")),
                        Email = reader.GetString(reader.GetOrdinal("personEmail")),
                        Address = reader.GetString(reader.GetOrdinal("personAddress")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        Membernr = reader.GetInt32(reader.GetOrdinal("administratorMemberNr"))
                    };
                    admins.Add(admin);
                }
            }
            return admins;
        }

        /// <summary>
        /// Update a Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>
        /// Return 1 if Admin is updated, else 0
        /// </returns>
        public int UpdateAdmin(Admin admin)
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
                cmd.Parameters.AddWithValue("personId", admin.Id);
                cmd.Parameters.AddWithValue("personName", admin.Name);
                cmd.Parameters.AddWithValue("personEmail", admin.Email);
                cmd.Parameters.AddWithValue("personAddress", admin.Address);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
