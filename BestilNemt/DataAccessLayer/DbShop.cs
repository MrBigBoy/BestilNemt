﻿using Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DbShop : IDbShop
    {
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

        public int AddShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("insert into Shop (shopName, shopAddress, shopCVR)values (@name, @address, @cvr)", conn);
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

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
                    var shop = new Shop
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

        public int UpdateShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Update Shop Set shopName = @name, shopAddress = @address, shopCVR = @cvr where Id = @id", conn);
                command.Parameters.AddWithValue("Id", shop.Id);
                command.Parameters.AddWithValue("name", shop.Name);
                command.Parameters.AddWithValue("address", shop.Address);
                command.Parameters.AddWithValue("cvr", shop.CVR);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        public int DeleteShop(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Delete from Shop where Id = @id", conn);
                command.Parameters.AddWithValue("Id", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }
    }
}