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
        public int AddPartOrder(PartOrder partOrder)
        {
            int i = 0;
            using (
                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                cmd.CommandText = "Insert into PartOrder(partOrderProductId,partOrderAmount,partOrderPartPrice,partOrderCartId) values(@productId, @amount, @partPrice, @cartId)";
                cmd.Parameters.AddWithValue("productId", partOrder.Product.Id);
                cmd.Parameters.AddWithValue("amount", partOrder.Amount);
                cmd.Parameters.AddWithValue("partPrice", partOrder.PartPrice);
                cmd.Parameters.AddWithValue("cartId", partOrder.Cart.Id);
                i = cmd.ExecuteNonQuery();
                transaction.Commit();
                try
                {

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

        public int DeletePartOrder(int id)
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
                    cmd.CommandText = "Delete From PartOrder Where partOrderId = @id";
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
                    partOrder = ObjectBuilder.CreatePartOrder(reader);
                }
            }
            return partOrder;
        }

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
                    var partOrder = ObjectBuilder.CreatePartOrder(reader);
                    partOrders.Add(partOrder);
                }
            }
            return partOrders;
        }
        public List<PartOrder> GetAllPartOrdersFromCart()
        {
            var partOrders = new List<PartOrder>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Cart, PartOrder, Product WHERE partOrderProductId = productId AND cartId = partOrderCartId", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var partOrder = ObjectBuilder.CreatePartOrder(reader);
                    partOrders.Add(partOrder);
                }
            }
            return partOrders;
        }

        public int UpdatePartOrder(PartOrder partOrder)
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
                    cmd.CommandText = "UPDATE PartOrder SET partOrderAmount=@amount, partOrderPartPrice=@partprice WHERE partOrderId=@id";
                    cmd.Parameters.AddWithValue("id", partOrder.Id);
                    cmd.Parameters.AddWithValue("amount", partOrder.Amount);
                    cmd.Parameters.AddWithValue("partprice", partOrder.PartPrice);
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
