using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbSaving : IDbSaving
    {
        /// <summary>
        /// Add a Saving
        /// </summary>
        /// <param name="saving"></param>
        /// <param name="product"></param>
        /// <returns>
        /// Id of Saving if added, else 0
        /// </returns>
        public int AddSaving(Saving saving, Product product)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DECLARE @DataID int; INSERT INTO Saving(savingStartDate,savingEndDate,savingPercent)VALUES(@startDate, @endDate, @percent); " +
                                             "SELECT @DataID = scope_identity(); UPDATE Product SET productSavingId = @DataID WHERE productId = @productId;";
                    cmd.Parameters.AddWithValue("startDate", saving.StartDate);
                    cmd.Parameters.AddWithValue("endDate", saving.EndDate);
                    cmd.Parameters.AddWithValue("percent", saving.SavingPercent);
                    cmd.Parameters.AddWithValue("productId", product.Id);
                    // Get the id
                    i = (int)cmd.ExecuteScalar();
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
        /// Get a Saving
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Saving if found, else null
        /// </returns>
        public Saving GetSaving(int id)
        {
            Saving saving = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * from Saving Where savingId = @savingId", conn);
                cmd.Parameters.AddWithValue("savingId", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Saving object
                    saving = ObjectBuilder.CreateSaving(reader);
                }
            }
            return saving;
        }

        /// <summary>
        /// Get all Savings
        /// </summary>
        /// <returns>
        /// List of Saving
        /// </returns>
        public List<Saving> GetAllSavings()
        {
            var savings = new List<Saving>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * from Saving", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Saving object
                    var saving = ObjectBuilder.CreateSaving(reader);
                    // Add to the list
                    savings.Add(saving);
                }
            }
            return savings;
        }

        /// <summary>
        /// Update a Saving
        /// </summary>
        /// <param name="saving"></param>
        /// <returns>
        /// 1 if updated, else 0
        /// </returns>
        public int UpdateSaving(Saving saving)
        {
            var i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Saving Set savingStartDate = @StartDate, savingEndDate = @EndDate, savingPercent = @SavingPercent " +
                                              "WHERE savingId = @ID;";
                    cmd.Parameters.AddWithValue("startdate", saving.StartDate);
                    cmd.Parameters.AddWithValue("EndDate", saving.EndDate);
                    cmd.Parameters.AddWithValue("SavingPercent", saving.SavingPercent);
                    cmd.Parameters.AddWithValue("ID", saving.Id);
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
        /// Delete a Saving
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if deleted, else 0
        /// </returns>
        public int DeleteSaving(int id)
        {
            var i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Product SET productSavingId = null WHERE productSavingId = @ID; DELETE FROM Saving WHERE savingId = @ID;";
                    cmd.Parameters.AddWithValue("ID", id);
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