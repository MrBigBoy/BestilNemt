using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbPartOrder : IDbPartOrder
    {
        /// <summary>
        /// Add a PartOrder
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// Id of PartOrder if added, else 0
        /// </returns>
        public int AddPartOrder(PartOrder partOrder)
        {
            var id = 0;
            using (
                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Insert into PartOrder(partOrderProductId,partOrderAmount,partOrderPartPrice,partOrderCartId) values(@productId, @amount, @partPrice, @cartId)";
                    cmd.Parameters.AddWithValue("productId", partOrder.Product.Id);
                    cmd.Parameters.AddWithValue("amount", partOrder.Amount);
                    cmd.Parameters.AddWithValue("partPrice", partOrder.PartPrice);
                    cmd.Parameters.AddWithValue("cartId", partOrder.Cart.Id);
                    // Get the Id
                    id = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // The transaction failed
                    try
                    {
                        // Try rolling back
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        // Rolling back failed
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return id;
        }

        /// <summary>
        /// Delete a PartOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if PartOrder is deleted, else 0
        /// </returns>
        public int DeletePartOrder(int id)
        {
            var i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Delete From PartOrder Where partOrderId = @id";
                    cmd.Parameters.AddWithValue("Id", id);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // The transaction failed
                    try
                    {
                        // Try rolling back
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        // Rolling back failed
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return i;
        }

        /// <summary>
        /// Get a PartOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// PartOrder if found, else null
        /// </returns>
        public PartOrder GetPartOrder(int id)
        {
            PartOrder partOrder = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Product, PartOrder where partOrderId = @id and productId = partOrderProductId", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the PartOrder
                    partOrder = ObjectBuilder.CreatePartOrder(reader);
                }
            }
            return partOrder;
        }


        /// <summary>
        /// Get all PartOrders
        /// </summary>
        /// <returns>
        /// List of PartOrder
        /// </returns>
        public List<PartOrder> GetAllPartOrders()
        {
            var partOrders = new List<PartOrder>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Select * from PartOrder, Product WHERE PartOrder.partOrderProductId = Product.productId", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the PartOrder object
                    var partOrder = ObjectBuilder.CreatePartOrder(reader);
                    // Add the PartOrder
                    partOrders.Add(partOrder);
                }
            }
            return partOrders;
        }

        /// <summary>
        /// Update a PartOrder
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// 1 if partOrder is updated, else 0
        /// </returns>
        public int UpdatePartOrder(PartOrder partOrder)
        {
            var i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE PartOrder SET partOrderAmount=@amount, partOrderPartPrice=@partprice WHERE partOrderId=@id";
                    cmd.Parameters.AddWithValue("id", partOrder.Id);
                    cmd.Parameters.AddWithValue("amount", partOrder.Amount);
                    cmd.Parameters.AddWithValue("partprice", partOrder.PartPrice);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // The transaction failed
                    try
                    {
                        // Try rolling back
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        // Rolling back failed
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return i;
        }
    }
}
