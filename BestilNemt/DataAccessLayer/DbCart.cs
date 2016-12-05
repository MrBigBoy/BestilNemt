using System;
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
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "INSERT INTO Cart(cartTotalPrice, cartPersonId) output inserted.cartId VALUES(@totalPrice, @personId)";
                    cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                    cmd.Parameters.AddWithValue("personId", cart.PersonId);
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
                var cmd = new SqlCommand("SELECT * FROM Cart WHERE cartId = @id", conn);
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
        /// Return a list of all Carts
        /// </summary>
        /// <returns>
        /// Return List of Cart 
        /// </returns>
        public List<Cart> GetAllCartsByPersonId(int personId)
        {
            var carts = new List<Cart>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Cart, PartOrder, Product, Person_Chain WHERE partOrderProductId = productId AND cartId = partOrderCartId AND cartPersonId = @PersonId AND personChainPersonId = @PersonId", conn);
                cmd.Parameters.AddWithValue("PersonId", personId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cart = ObjectBuilder.CreateCartWithPartOrders(reader);
                    cart.ChainId = reader.GetInt32(reader.GetOrdinal("personChainChainId"));
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
            int i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Cart SET cartTotalPrice=@totalPrice AND cartPersonId=@PersonId WHERE cartId=@id";
                    cmd.Parameters.AddWithValue("id", cart.Id);
                    cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                    cmd.Parameters.AddWithValue("PersonId", cart.PersonId);
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
        /// Delete a Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Cart is deleted, else 0
        /// </returns>
        public int DeleteCart(int id)
        {
            int i = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Delete from Cart WHERE cartId=@id";
                    cmd.Parameters.AddWithValue("id", id);
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

        public int AddCartWithPartOrders(Cart cart)
        {
            var id = 0;
            var flag = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                decimal cartTotalPrice = 0;
                foreach (var partOrder in cart.PartOrders)
                {

                    cartTotalPrice = partOrder.PartPrice + cartTotalPrice;
                }
                try
                {
                    //save Cart in DB and get generated cartId
                    cmd.CommandText = "INSERT INTO Cart(cartTotalPrice, cartPersonId, cartShopId) output inserted.cartId VALUES(@totalPrice, @PersonId, @ShopId)";

                    cmd.Parameters.AddWithValue("totalPrice", cartTotalPrice);
                    cmd.Parameters.AddWithValue("PersonId", cart.PersonId);
                    cmd.Parameters.AddWithValue("ShopId", cart.ShopId);
                    id = (int)cmd.ExecuteScalar();

                    foreach (var po in cart.PartOrders)
                    {
                        var cmdPartOrder = conn.CreateCommand();
                        cmdPartOrder.Transaction = transaction;
                        //Save all PartOrders from cart in DB
                        cmdPartOrder.CommandText = "Insert Into PartOrder (partOrderProductId, partOrderAmount, partOrderPartPrice, partOrderCartId) values (@productId, @amount, @partPrice, @cartId)";
                        cmdPartOrder.Parameters.AddWithValue("productId", po.Product.Id);
                        cmdPartOrder.Parameters.AddWithValue("amount", po.Amount);
                        cmdPartOrder.Parameters.AddWithValue("partPrice", po.PartPrice);
                        cmdPartOrder.Parameters.AddWithValue("cartId", id);
                        cmdPartOrder.ExecuteNonQuery();

                        // Get warehouseStock form DB decrese it with partOrder Amount and save in a variable
                        var cmdDecreseStock = conn.CreateCommand();
                        cmdDecreseStock.CommandText = "Select warehouseStock from Warehouse where warehouseProductId = @productId AND warehouseShopId = @shopId";
                        cmdDecreseStock.Parameters.AddWithValue("productId", po.Product.Id);
                        cmdDecreseStock.Parameters.AddWithValue("shopId", cart.ShopId);
                        cmdDecreseStock.Transaction = transaction;
                        var reader = cmdDecreseStock.ExecuteReader();
                        var newStock = 0;
                        while (reader.Read())
                        {
                            newStock = reader.GetInt32(reader.GetOrdinal("warehouseStock")) - po.Amount;
                        }
                        reader.Close();

                        //update warehouseStock with new saved value
                        var cmdUpdateWarehouse = conn.CreateCommand();
                        cmdUpdateWarehouse.CommandText = "Update Warehouse Set warehouseStock = @newStock where warehouseProductId = @productId AND warehouseShopId = @shopId";
                        cmdUpdateWarehouse.Parameters.AddWithValue("newStock", newStock);
                        cmdUpdateWarehouse.Parameters.AddWithValue("productId", po.Product.Id);
                        cmdUpdateWarehouse.Parameters.AddWithValue("shopId", cart.ShopId);
                        cmdUpdateWarehouse.Transaction = transaction;
                        cmdUpdateWarehouse.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    flag = 1;
                    Console.WriteLine("Commit was succsesfull");

                }
                catch (Exception)
                {
                    flag = 0;
                    try
                    {
                        transaction.Rollback();
                        System.Diagnostics.Debug.WriteLine("Transaction was rolled back");
                    }
                    catch (SqlException)
                    {
                        System.Diagnostics.Debug.WriteLine("Transaction rollback failed");
                    }
                }
            }
            return flag;
        }
    }
}
