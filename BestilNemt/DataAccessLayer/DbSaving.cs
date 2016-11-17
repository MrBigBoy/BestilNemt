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
                var cmd = new SqlCommand("DECLARE @DataID int; INSERT INTO Saving(savingStartDate,savingEndDate,savingPercent)VALUES(@startDate, @endDate, @percent); SELECT @DataID = scope_identity(); UPDATE Product SET productSavingId = @DataID WHERE productId = @productId;", conn);
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
            throw new NotImplementedException();
        }

        public List<Saving> FindAllSavings()
        {
            throw new NotImplementedException();
        }

        public int UpdateSaving(Saving saving)
        {
            throw new NotImplementedException();
        }

        public int DeleteSaving(int id)
        {
            throw new NotImplementedException();
        }
    }
}
