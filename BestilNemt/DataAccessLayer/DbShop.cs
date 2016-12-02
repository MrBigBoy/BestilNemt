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
        /// AddShop a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return id of Shop is added, else 0
        /// </returns>
        public int AddShop(Shop shop)
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
                    cmd.CommandText = "INSERT INTO Shop(shopName, shopAddress, shopOpeningTime, shopCVR, shopChainId) OUTPUT Inserted.shopId VALUES(@ShopName, @ShopAddress, @ShopOpeningTime, @ShopCvr, @ShopChainId)";
                    cmd.Parameters.AddWithValue("ShopName", shop.Name);
                    cmd.Parameters.AddWithValue("ShopAddress", shop.Address);
                    cmd.Parameters.AddWithValue("ShopOpeningTime", shop.OpeningTime);
                    cmd.Parameters.AddWithValue("ShopCvr", shop.Cvr);
                    cmd.Parameters.AddWithValue("ShopChainId", shop.Chain.Id);
                    i = (int)cmd.ExecuteScalar();
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

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the Shop is deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
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
                    cmd.CommandText = "DELETE FROM Shop Where shopId=@ShopId";
                    cmd.Parameters.AddWithValue("ShopId", id);
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

        /// <summary>
        /// UpdateShop a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if the Shop is updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
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

        /// <summary>
        /// Return a list of all Shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> FindAllShopsByChainId(int chainId)
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
                    var shop = ObjectBuilder.CreateShop(reader);
                    shops.Add(shop);
                }
            }
            return shops;
        }
    }
}
