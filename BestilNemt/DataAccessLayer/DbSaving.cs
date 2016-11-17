using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public class DbSaving : IDbSaving
    {
        public int AddSaving(Saving saving, Product product)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand(
                        "DECLARE @DataID int; INSERT INTO Saving(savingStartDate,savingEndDate,savingPercent)VALUES(@startDate, @endDate, @percent); SELECT @DataID = scope_identity(); UPDATE Product SET productSavingId = @DataID WHERE productId = @productId;",
                        conn);
                cmd.Parameters.AddWithValue("startDate", saving.StartDate);
                cmd.Parameters.AddWithValue("endDate", saving.EndDate);
                cmd.Parameters.AddWithValue("percent", saving.SavingPercent);
                cmd.Parameters.AddWithValue("productId", product.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public Saving FindSaving(int id)
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

        public List<Saving> FindAllSavings()
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
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand(
                        "UPDATE Saving Set savingStartDate = @StartDate, savingEndDate = @EndDate, savingPercent = @SavingPercent WHERE savingId = @ID;",
                        conn);
                cmd.Parameters.AddWithValue("startdate", saving.StartDate);
                cmd.Parameters.AddWithValue("EndDate", saving.EndDate);
                cmd.Parameters.AddWithValue("SavingPercent", saving.SavingPercent);
                cmd.Parameters.AddWithValue("ID", saving.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public int DeleteSaving(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand("UPDATE Product SET productSavingId = null WHERE productSavingId = @ID; DELETE FROM Saving WHERE savingId = @ID", conn);
                cmd.Parameters.AddWithValue("ID", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}