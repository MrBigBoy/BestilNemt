using Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbShop : IDbShop
    {
        /// <summary>
        /// Return a Shop by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Shop if found, else null
        /// </returns>
        public Shop GetShop(int id)
        {
            Shop shop = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Select * from Shop where shopId = @id", conn);
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    shop = ObjectBuilder.CreateShop(reader);
                }
            }
            return shop;
        }

        /// <summary>
        /// Add a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if Shop is added, else 0
        /// </returns>
        public int AddShop(Shop shop)
        {
            int id;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("insert into Shop (shopName, shopAddress, shopCVR) OUTPUT Inserted.shopId values (@name, @address, @cvr)", conn);
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                id = (int)command.ExecuteScalar();
            }
            return id;
        }

        /// <summary>
        /// Return a list of all shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShops()
        {
            var shops = new List<Shop>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Select * from Shop", conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var shop = ObjectBuilder.CreateShop(reader);
                    shops.Add(shop);
                }
            }
            return shops;
        }

        /// <summary>
        /// Update a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if Shop is updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Update Shop Set shopName = @name, shopAddress = @address, shopCVR = @cvr where shopId = @id", conn);
                command.Parameters.AddWithValue("shopId", shop.Id);
                command.Parameters.AddWithValue("shopName", shop.Name);
                command.Parameters.AddWithValue("shopAddress", shop.Address);
                command.Parameters.AddWithValue("shopCVR", shop.CVR);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Shop is deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Delete from Shop where shopId = @id", conn);
                command.Parameters.AddWithValue("Id", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return true if the connection if open, else false
        /// </summary>
        /// <returns>
        /// Return true if the connection if open, else false
        /// </returns>
        public bool IsOpen()
        {
            bool con;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                con = true;
            }
            return con;
        }
    }
}
