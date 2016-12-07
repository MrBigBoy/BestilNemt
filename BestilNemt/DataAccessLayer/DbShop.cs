using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbShop : IDbShop
    {
        /// <summary>
        /// Add a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return id of Shop is added, else 0
        /// </returns>
        public int AddShop(Shop shop)
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
                    cmd.CommandText = "INSERT INTO Shop(shopName, shopAddress, shopOpeningTime, shopCVR, shopChainId) OUTPUT Inserted.shopId VALUES(@ShopName, @ShopAddress, @ShopOpeningTime, @ShopCvr, @ShopChainId)";
                    cmd.Parameters.AddWithValue("ShopName", shop.Name);
                    cmd.Parameters.AddWithValue("ShopAddress", shop.Address);
                    cmd.Parameters.AddWithValue("ShopOpeningTime", shop.OpeningTime);
                    cmd.Parameters.AddWithValue("ShopCvr", shop.Cvr);
                    cmd.Parameters.AddWithValue("ShopChainId", shop.Chain.Id);
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
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the Shop is deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DELETE FROM Shop Where shopId=@ShopId";
                    cmd.Parameters.AddWithValue("ShopId", id);
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
        /// Update a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if the Shop is updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
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
                    cmd.CommandText = "UPDATE Shop SET shopName=@ShopName, shopAddress=@ShopAddress, shopOpeningTime=@ShopOpeningTime, shopCvr=@ShopCvr WHERE shopId=@ShopId";
                    cmd.Parameters.AddWithValue("ShopName", shop.Name);
                    cmd.Parameters.AddWithValue("ShopAddress", shop.Address);
                    cmd.Parameters.AddWithValue("ShopOpeningTime", shop.OpeningTime);
                    cmd.Parameters.AddWithValue("ShopCvr", shop.Cvr);
                    cmd.Parameters.AddWithValue("ShopId", shop.Id);
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
        /// Get a Shop
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
                var cmd = new SqlCommand("SELECT * FROM Shop WHERE shopId = @ShopId", conn);
                cmd.Parameters.AddWithValue("ShopId", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Build the Shop object
                    shop = ObjectBuilder.CreateShop(reader);
                }
            }
            return shop;
        }

        /// <summary>
        /// get all Shops
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
                var cmd = new SqlCommand("SELECT * FROM Shop", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Build the Shop object
                    var shop = ObjectBuilder.CreateShop(reader);
                    // Add it the to list
                    shops.Add(shop);
                }
            }
            return shops;
        }

        /// <summary>
        /// Get all Shops by a Chain id
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShopsByChainId(int chainId)
        {
            var shops = new List<Shop>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Shop WHERE shopChainId=@ChainId", conn);
                cmd.Parameters.AddWithValue("ChainId", chainId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // build the Shop object
                    var shop = ObjectBuilder.CreateShop(reader);
                    // Add it to the list
                    shops.Add(shop);
                }
            }
            return shops;
        }
    }
}
