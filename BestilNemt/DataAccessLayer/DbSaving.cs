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
        public int AddSaving(Saving saving, Product product)
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
                    cmd.CommandText = "DECLARE @DataID int; INSERT INTO Saving(savingStartDate,savingEndDate,savingPercent)VALUES(@startDate, @endDate, @percent); " +
                                             "SELECT @DataID = scope_identity(); UPDATE Product SET productSavingId = @DataID WHERE productId = @productId;";
                    cmd.Parameters.AddWithValue("startDate", saving.StartDate);
                    cmd.Parameters.AddWithValue("endDate", saving.EndDate);
                    cmd.Parameters.AddWithValue("percent", saving.SavingPercent);
                    cmd.Parameters.AddWithValue("productId", product.Id);
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
                if (!reader.HasRows)
                    return null;
                while (reader.Read())
                {
                    saving = ObjectBuilder.CreateSaving(reader);
                }
            }
            return saving;
        }

        public List<Saving> GetAllSavings()
        {
            List<Saving> savings = new List<Saving>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * from Saving", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var saving = ObjectBuilder.CreateSaving(reader);
                    savings.Add(saving);
                }
            }
            return savings;
        }

        public int UpdateSaving(Saving saving)
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

        public int DeleteSaving(int id)
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
                    cmd.CommandText = "UPDATE Product SET productSavingId = null WHERE productSavingId = @ID; DELETE FROM Saving WHERE savingId = @ID;";
                    cmd.Parameters.AddWithValue("ID", id);
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