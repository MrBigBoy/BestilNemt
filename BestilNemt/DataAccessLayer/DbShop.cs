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

        public DbShop()
        {

        }

        public Shop GetShop(int id)
        {
            Shop shop = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Select * from Shop where id = @id", conn);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    shop = new Shop
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("shopName")),
                        Address = reader.GetString(reader.GetOrdinal("shopAddress")),
                        CVR = reader.GetString(reader.GetOrdinal("shopCVR"))
                    };
                }
            }
            return shop;
        }

        public void AddShop(Shop shop)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command =
                    new SqlCommand("insert into Shop (shopName, shopAddress, shopCVR)values (@name, @address, @cvr)",
                        conn);
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                command.ExecuteNonQuery();
            }
        }

        public List<Shop> GetAllShops()
        {
            List<Shop> shops = new List<Shop>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Select * from Shop", conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Shop shop = new Shop
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("shopName")),
                        Address = reader.GetString(reader.GetOrdinal("shopAddress")),
                        CVR = reader.GetString(reader.GetOrdinal("shopCVR"))
                    };
                    shops.Add(shop);
                }
            }

            return shops;
        }


        public void UpdateShop(Shop shop)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))

            {
                conn.Open();
                var command = new SqlCommand("Update Shop Set shopName = @name, shopAddress = @address, shopCVR = @cvr where Id = @id", conn);
                command.Parameters.AddWithValue("Id", shop.Id);
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteShop(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Delete from Shop where Id = @id", conn);
                command.Parameters.AddWithValue("Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
