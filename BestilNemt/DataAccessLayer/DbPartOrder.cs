using System;
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
    }
}
