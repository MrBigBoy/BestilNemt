﻿using System;
using System.Collections.Generic;
using Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
            var id = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "INSERT INTO Cart(cartTotalPrice) output inserted.cartId VALUES(@totalPrice)";
                    cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                    id = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                    Console.WriteLine("Commit was succsesfull");

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
                var cmd = new SqlCommand("SELECT cartId, cartTotalPrice FROM Cart WHERE cartId = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cart = ObjectBuilder.CreateCart(reader);
                }
            }
            return cart;
        }

        /// <summary>
        /// Return a Cart by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Cart if found, else null
        /// </returns>
        public Cart FindCartWithPartOrders(int cartId)
        {
            Cart cart = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Cart, PartOrder, Product WHERE partOrderProductId = productId AND cartId = partOrderCartId AND cartId = @CartId", conn);
                cmd.Parameters.AddWithValue("CartId", cartId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cart = ObjectBuilder.CreateCartWithPartOrders(reader);
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
            var carts = new List<Cart>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Cart ", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cart = ObjectBuilder.CreateCart(reader);
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
                var cmd = new SqlCommand("UPDATE Cart SET cartTotalPrice=@totalPrice WHERE cartId=@id", conn);
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
                var cmd = new SqlCommand("Delete from Cart WHERE cartId=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        //public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        //{
        //    int i;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("Update PartOrder Set cartId = @cartId where id = @partOrderId", conn);
        //        cmd.Parameters.AddWithValue("cartId", cart.Id);
        //        cmd.Parameters.AddWithValue("partOrderId", partOrder.Id);
        //        i = cmd.ExecuteNonQuery();
        //    }
        //    return i;
        //}

        public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        {
            var i = 0;
            using (
               var conn =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Update PartOrder Set partOrderCartId = @cartId where partOrderId = @partOrderId";
                    cmd.Parameters.AddWithValue("cartId", cart.Id);
                    cmd.Parameters.AddWithValue("partOrderId", partOrder.Id);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Commit was succsesfull");

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
        public void SaveCart()
        {

        }
        public int AddCartWithPartOrders(Cart cart)
        {
            var id = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                try
                {
                    //save Cart in DB and get generated cartId
                    cmd.CommandText = "INSERT INTO Cart(cartTotalPrice) output inserted.cartId VALUES(@totalPrice)";

                    cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                    id = (int)cmd.ExecuteScalar();
                    foreach (var po in cart.PartOrders)
                    {
                        //Save all PartOrders from cart in DB
                        cmd.CommandText = "Insert Into PartOrder (partOrderProductId, partOrderAmount, partOrderPartPrice, partOrderCartId) values (@productId, @amount, @partPrice, @cartId)";
                        cmd.Parameters.AddWithValue("productId", po.Product.Id);
                        cmd.Parameters.AddWithValue("amount", po.Amount);
                        cmd.Parameters.AddWithValue("partPrice", po.PartPrice);
                        cmd.Parameters.AddWithValue("cartId", id);
                        cmd.ExecuteNonQuery();

                       //// Get warehouseStock form DB decrese it with partOrder Amount and save in a variable
                       // cmd.CommandText = "Select warehouseStock from Warehouse where warehouseProductId = @productId";
                       // cmd.Parameters.AddWithValue("productId", po.Product.Id);
                       // var newStock = 0;
                       // var reader = cmd.ExecuteReader();
                       // while (reader.Read())
                       // {
                       //     newStock = reader.GetInt32(reader.GetOrdinal("warehouseStock")) - po.Amount;
                       // }

                       // //update warehouseStock with new saved value
                       // cmd.CommandText = "Update Warehouse Set warehouseStock = @newStock where warehouseProductId = @productId";
                       // cmd.Parameters.AddWithValue("newStock", newStock);
                       // cmd.Parameters.AddWithValue("productId", po.Product.Id);
                       // cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    Console.WriteLine("Commit was succsesfull");

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
            return id;
        }

    }

}
