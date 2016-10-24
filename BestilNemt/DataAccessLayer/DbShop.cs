using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbShop : IDbShop
    {
        private string conString = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString;
        private SqlConnection Connection { get; set; }

        public DbShop()
        {
            Connection = new SqlConnection(conString);
        }

        public Shop GetShop(int id)
        {
            Shop shop = null;
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "Select * from Shop where id = @id";
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    shop = new Shop();
                    shop.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    shop.Name = reader.GetString(reader.GetOrdinal("shopName"));
                    shop.Address = reader.GetString(reader.GetOrdinal("shopAddress"));
                    shop.CVR = reader.GetString(reader.GetOrdinal("shopCVR"));

                }
            }

            Connection.Close();
            return shop;

        }

        public void AddShop(Shop shop)
        {
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "insert into Shop (shopName, shopAddress, shopCVR)values (@name, @address, @cvr)";
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                command.ExecuteNonQuery();
            }

            Connection.Close();
        }

        public List<Shop> GetAllShops()
        {
            List<Shop> shops = new List<Shop>();
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "Select * from Shop";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Shop shop = new Shop();
                    shop.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    shop.Name = reader.GetString(reader.GetOrdinal("shopName"));
                    shop.Address = reader.GetString(reader.GetOrdinal("shopAddress"));
                    shop.CVR = reader.GetString(reader.GetOrdinal("shopCVR"));
                    shops.Add(shop);
                }
            }

            Connection.Close();
            return shops;
        }


        public void UpdateShop(Shop shop)
        {
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "Update Shop Set shopName = @name, shopAddress = @address, shopCVR = @cvr where Id = @id";
                command.Parameters.AddWithValue("Id", shop.Id);
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                command.ExecuteNonQuery();
            }

            Connection.Close();
        }

        public void DeleteShop(int id)
        {
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "Delete from Shop where Id = @id";
                command.Parameters.AddWithValue("Id", id);
                command.ExecuteNonQuery();
            }

            Connection.Close();
        }
    }
}
