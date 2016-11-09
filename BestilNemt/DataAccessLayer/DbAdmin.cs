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
                        "DECLARE @DataID int; INSERT INTO Person(Name, Email, personType, Address)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Administrator(id) VALUES(@DataID);", conn);
                cmd.Parameters.AddWithValue("name", admin.Name);
                cmd.Parameters.AddWithValue("email", admin.Email);
                cmd.Parameters.AddWithValue("personType", admin.PersonType);
                cmd.Parameters.AddWithValue("address", admin.Address);
                i = cmd.ExecuteNonQuery();

            }
            return i;
        }

        /// <summary>
        /// Remove a Admin
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
                var cmd = new SqlCommand("Delete from Administrator where Id = @id;Delete from Person where Id = @id", conn);
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
                var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType, memberNr FROM Person LEFT JOIN Administrator ON Person.ID = Administrator.ID WHERE Person.ID = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    admin = new Admin()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        Membernr = reader.GetInt32(reader.GetOrdinal("memberNr"))

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
                var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType, memberNr FROM Person LEFT JOIN Administrator ON Person.ID = Administrator.ID WHERE Person.personType = 'Administrator'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var admin = new Admin
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        Membernr = reader.GetInt32(reader.GetOrdinal("memberNr"))
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
                    new SqlCommand("UPDATE Person SET name=@name, email=@email, address=@address WHERE id=@id",
                        conn);
                cmd.Parameters.AddWithValue("id", admin.Id);
                cmd.Parameters.AddWithValue("name", admin.Name);
                cmd.Parameters.AddWithValue("email", admin.Email);
                cmd.Parameters.AddWithValue("address", admin.Address);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
