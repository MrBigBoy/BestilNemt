using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbCustomer : IDbCustomer
    {
        /// <summary>
        /// Add a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return 1 if Customer is added, else 0
        /// </returns>
        public int Create(Customer customer)
        {
            int id;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();

                var cmd =
                    new SqlCommand(
                        "DECLARE @DataID int; INSERT INTO Person(personName, personEmail, personType, personAddress) output inserted.personId VALUES(@name, @email, @personType, @address); SELECT @DataID = scope_identity(); INSERT INTO Customer(customerId,customerBirthday) VALUES(@DataID,@birthday);", conn);
                cmd.Parameters.AddWithValue("name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("personType", customer.PersonType);
                cmd.Parameters.AddWithValue("address", customer.Address);
                cmd.Parameters.AddWithValue("birthday", customer.Birthday);
                id = (int)cmd.ExecuteScalar();

            }
            return id;
        }

        /// <summary>
        /// Delete a Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Customer is deleted, else 0
        /// </returns>
        public int RemoveCustomer(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Delete from Customer where customerId = @id;Delete from Person where personId = @id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Customer if found, else null
        /// </returns>
        public Customer FindCustomer(int id)
        {
            Customer customer = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Person.personId, personName, personEmail, personAddress, personType, customerBirthday FROM Person LEFT JOIN Customer ON Person.personId = Customer.customerId WHERE Person.personId = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer = ObjectBuilder.CreateCustomer(reader);
                }
            }
            return customer;
        }

        /// <summary>
        /// Return a list of all Customers
        /// </summary>
        /// <returns>
        /// Return List of Customer
        /// </returns>
        public List<Customer> FindAllCustomer()
        {
            var customers = new List<Customer>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT personId, personName, personEmail, personAddress, personType, customerBirthday FROM Person LEFT JOIN Customer ON Person.personId = Customer.customerId WHERE Person.personType = 'Customer'", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var customer = ObjectBuilder.CreateCustomer(reader);
                    customers.Add(customer);
                }
            }
            return customers;
        }

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return 1 if Customer is updated, else 0
        /// </returns>
        public int UpdateCustomer(Customer customer)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand("UPDATE Person SET personName=@name, personEmail=@email, personAddress=@address WHERE personId=@id; " +
                                   "UPDATE Customer SET customerBirthday=@birthday WHERE customerId = @id", conn);
                cmd.Parameters.AddWithValue("id", customer.Id);
                cmd.Parameters.AddWithValue("name", customer.Name);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("address", customer.Address);
                cmd.Parameters.AddWithValue("birthday", customer.Birthday);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
