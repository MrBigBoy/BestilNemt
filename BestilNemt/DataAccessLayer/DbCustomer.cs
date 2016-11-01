using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.ServiceModel.Channels;
using Models;

namespace DataAccessLayer
{
    public class DbCustomer : IDbPerson
    {
        public int Create(Customer customer)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();

                var cmd =
                    new SqlCommand(
                        "DECLARE @DataID int; INSERT INTO Person(Name, Email, personType, Address)VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Customer(id,birthday) VALUES(@DataID,@birthday);", conn);
                cmd.Parameters.AddWithValue("name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("personType", customer.PersonType);
                cmd.Parameters.AddWithValue("address", customer.Address);
                cmd.Parameters.AddWithValue("birthday", customer.Birthday);
                i = cmd.ExecuteNonQuery();

            }
            return i;
        }

        public int RemoveCustomer(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Delete from Customer where Id = @id;Delete from Person where Id = @id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                //cmd.Parameters.AddWithValue("name", customer.Name);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public Customer FindCustomer(int id)
        {
            Customer customer = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType, birthday FROM Person LEFT JOIN Customer ON Person.ID = Customer.ID WHERE Person.ID = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer = new Customer()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        Birthday = reader.GetDateTime(reader.GetOrdinal("birthday")),
                        



                    };
                }
            }
            return customer;
        }

        public List<Customer> FindAllCustomer()
        {
            var customers = new List<Customer>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.id, name, email, address, personType, birthday FROM Person LEFT JOIN Customer ON Person.ID = Customer.ID WHERE Person.personType = 'Customer'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address")),
                        PersonType = reader.GetString(reader.GetOrdinal("personType")),
                        Birthday = reader.GetDateTime(reader.GetOrdinal("birthday")),
                    };
                    customers.Add(customer);
                }
            }
            return customers;
        }

        public int UpdateCustomer(Customer customer)
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
                cmd.Parameters.AddWithValue("id", customer.Id);
                cmd.Parameters.AddWithValue("name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("address", customer.Address);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }




    }
}
