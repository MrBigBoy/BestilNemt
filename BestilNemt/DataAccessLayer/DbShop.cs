using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbShop : IDbShop
    {
        /// <summary>
        /// AddShop a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return id of Shop is added, else 0
        /// </returns>
        public int AddShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Shop(shopName, shopAddress, shopCVR, shopChainId) OUTPUT Inserted.shopId VALUES(@ShopName, @ShopAddress, @ShopCvr, @ShopChainId)", conn);
                cmd.Parameters.AddWithValue("ShopName", shop.Name);
                cmd.Parameters.AddWithValue("ShopAddress", shop.Address);
                cmd.Parameters.AddWithValue("ShopCvr", shop.Cvr);
                cmd.Parameters.AddWithValue("ShopChainId", shop.Chain.Id);
                i = (int)cmd.ExecuteScalar();
            }
            return i;
        }

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the Shop is deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Shop Where shopId=@ShopId", conn);
                cmd.Parameters.AddWithValue("ShopId", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// UpdateShop a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if the Shop is updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Shop SET shopName=@ShopName, shopAddress=@ShopAddress, shopCvr=@ShopCvr WHERE shopId=@ShopId", conn);
                cmd.Parameters.AddWithValue("ShopName", shop.Name);
                cmd.Parameters.AddWithValue("ShopAddress", shop.Address);
                cmd.Parameters.AddWithValue("ShopCvr", shop.Cvr);
                cmd.Parameters.AddWithValue("ShopId", shop.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Shop if found, else null
        /// </returns>
        public Shop FindShop(int id)
        {
            Shop shop = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Shop WHERE shopId = @ShopId", conn);
                cmd.Parameters.AddWithValue("ShopId", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    shop = ObjectBuilder.CreateShop(reader);
                }
            }
            return shop;
        }

        /// <summary>
        /// Return a list of all Shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> FindAllShops()
        {
            var shops = new List<Shop>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Shop", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var shop = ObjectBuilder.CreateShop(reader);
                    shops.Add(shop);
                }
            }
            return shops;
        }
    }
}
