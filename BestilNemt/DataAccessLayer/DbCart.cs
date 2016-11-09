﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Management.Instrumentation;

namespace DataAccessLayer
{
    public class DbCart : IDbCart
    {
        /// <summary>
        /// Add a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// Return 1 if Cart is added, else 0
        /// </returns>
        public int AddCart(Cart cart)
        {
            int id = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "INSERT INTO Cart(totalPrice) output inserted.id VALUES(@totalPrice)";
                    cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                    id = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                    Console.WriteLine("Commit was succsesfull");

                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Transaction rollback failed");
                    }
                }
                
            }
           return id;
        }

        /// <summary>
        /// Return a Cart by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Cart if found, else null
        /// </returns>
        public Cart FindCart(int id)
        {
            Cart cart = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, totalPrice FROM Cart WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cart = new Cart
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        TotalPrice = reader.GetDecimal(reader.GetOrdinal("totalPrice")),
                    };
                }
            }
            return cart;
        }

        /// <summary>
        /// Return a list of all Carts
        /// </summary>
        /// <returns>
        /// Return List of Cart 
        /// </returns>
        public List<Cart> GetAllCarts()
        {
            List<Cart> carts = new List<Cart>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Cart ", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cart = new Cart
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        TotalPrice = reader.GetDecimal(reader.GetOrdinal("totalPrice")),
                    };
                    carts.Add(cart);
                }
            }
            return carts;
        }

        /// <summary>
        /// Update a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// Return 1 if Cart is updated, else 0
        /// </returns>
        public int UpdateCart(Cart cart)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Cart SET totalPrice=@totalPrice WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", cart.Id);
                cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Delete a Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Cart is deleted, else 0
        /// </returns>
        public int DeleteCart(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Delete from Cart WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
