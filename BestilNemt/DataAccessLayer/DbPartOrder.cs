using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.ServiceModel.Channels;
using Models;

namespace DataAccessLayer
{
    public class DbPartOrder : IDbPartOrder
    {
        //public int Create(PartOrder partOrder)
        //{
        //    int i;
        //    using (
        //        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();

        //        var cmd =
        //            new SqlCommand(
        //                "DECLARE @DataID int; INSERT INTO Person(Name, Email, personType, Address)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Administrator(id) VALUES(@DataID);", conn);
        //        cmd.Parameters.AddWithValue("name", admin.Name);
        //        cmd.Parameters.AddWithValue("email", admin.Email);
        //        cmd.Parameters.AddWithValue("personType", admin.PersonType);
        //        cmd.Parameters.AddWithValue("address", admin.Address);
        //        i = cmd.ExecuteNonQuery();

        //    }
        //    return i;
        //}

        //public int RemovePartOrder(int id)
        //{
        //    int i;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("Delete from Administrator where Id = @id;Delete from Person where Id = @id", conn);
        //        cmd.Parameters.AddWithValue("Id", id);
        //        i = cmd.ExecuteNonQuery();
        //    }
        //    return i;
        //}

        public PartOrder FindPartOrder(int id)
        {
            Product product = null;
            PartOrder partOrder = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Product, PartOrder where PartOrder.id = @id and product.id = productId", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    product = new Product()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Category = reader.GetString(reader.GetOrdinal("category"))
                    };

                    partOrder = new PartOrder()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Product = product,
                        Amount = reader.GetInt32(reader.GetOrdinal("amount")),
                        PartPrice = reader.GetDecimal(reader.GetOrdinal("partPrice"))
                    };
                }
            }
            return partOrder;
        }

        //public List<PartOrder> FindAllPartOrders()
        //{
        //    var admins = new List<Admin>();
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType, memberNr FROM Person LEFT JOIN Administrator ON Person.ID = Administrator.ID WHERE Person.personType = 'Administrator'", conn);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var admin = new Admin
        //            {
        //                Id = reader.GetInt32(reader.GetOrdinal("id")),
        //                Name = reader.GetString(reader.GetOrdinal("name")),
        //                Email = reader.GetString(reader.GetOrdinal("email")),
        //                Address = reader.GetString(reader.GetOrdinal("address")),
        //                PersonType = reader.GetString(reader.GetOrdinal("personType")),
        //                Membernr = reader.GetInt32(reader.GetOrdinal("memberNr"))
        //            };
        //            admins.Add(admin);
        //        }
        //    }
        //    return admins;
        //}

        //public int UpdatePartOrder(PartOrder partOrder)
        //{
        //    int i;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd =
        //            new SqlCommand("UPDATE Person SET name=@name, email=@email, address=@address WHERE id=@id",
        //                conn);
        //        cmd.Parameters.AddWithValue("id", admin.Id);
        //        cmd.Parameters.AddWithValue("name", admin.Name);
        //        cmd.Parameters.AddWithValue("email", admin.Email);
        //        cmd.Parameters.AddWithValue("address", admin.Address);
        //        i = cmd.ExecuteNonQuery();
        //    }
        //    return i;
        //}
    }
}
