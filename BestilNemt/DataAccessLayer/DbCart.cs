using System;
using System.Collections.Generic;
using Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;

namespace DataAccessLayer
{
    public class DbCart : IDbCart
    {
        /// <summary>
        /// Add a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// Id of Cart if added, else 0
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
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "INSERT INTO Cart(cartTotalPrice, cartPersonId, cartShopId) output inserted.cartId VALUES(@totalPrice, @personId, @ShopId)";
                    cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                    cmd.Parameters.AddWithValue("personId", cart.PersonId);
                    cmd.Parameters.AddWithValue("ShopId", cart.ShopId);
                    // Get the Id
                    id = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                    Console.WriteLine("Commit was succsesfull");
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
            return id;
        }

        ///// <summary>
        ///// Return a Cart by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return Cart if found, else null
        ///// </returns>
        //public Cart GetCart(int id)
        //{
        //    Cart cart = null;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("SELECT * FROM Cart WHERE cartId = @id", conn);
        //        cmd.Parameters.AddWithValue("id", id);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            // Build the Cart object
        //            cart = ObjectBuilder.CreateCart(reader);
        //        }
        //    }
        //    return cart;
        //}

        ///// <summary>
        ///// Return a Cart by id
        ///// </summary>
        ///// <returns>
        ///// Return Cart if found, else null
        ///// </returns>
        //public Cart GetCartWithPartOrders(int cartId)
        //{
        //    Cart cart = null;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = new SqlCommand("SELECT * FROM Cart, PartOrder, Product WHERE partOrderProductId = productId AND cartId = partOrderCartId AND cartId = @CartId", conn);
        //        cmd.Parameters.AddWithValue("CartId", cartId);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            // Build the Cart object with a list of PartOrders
        //            cart = ObjectBuilder.CreateCartWithPartOrders(reader);
        //        }
        //    }
        //    return cart;
        //}

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
                    // Build the Cart Object
                    var cart = ObjectBuilder.CreateCart(reader);
                    // Add the cart to the list
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
                var cmd = new SqlCommand("SELECT * FROM Cart, PartOrder, Product, Shop, Chain WHERE partOrderProductId = productId AND cartId = partOrderCartId AND shopId = cartShopId AND shopChainId = chainId AND cartPersonId = @PersonId", conn);
                cmd.Parameters.AddWithValue("PersonId", personId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Cart object with a list of PartOrders
                    var cart = ObjectBuilder.CreateCartWithPartOrders(reader);
                    // Add the cart to the list
                    carts.Add(cart);
                }
            }
            return carts;
        }

        ///// <summary>
        ///// Update a Cart
        ///// </summary>
        ///// <param name="cart"></param>
        ///// <returns>
        ///// Return 1 if Cart is updated, else 0
        ///// </returns>
        //public int UpdateCart(Cart cart)
        //{
        //    var i = 0;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set the isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "UPDATE Cart SET cartTotalPrice=@totalPrice AND cartPersonId=@PersonId AND chainId = @ChainId WHERE cartId=@id";
        //            cmd.Parameters.AddWithValue("id", cart.Id);
        //            cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
        //            cmd.Parameters.AddWithValue("PersonId", cart.PersonId);
        //            i = cmd.ExecuteNonQuery();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;
        //}

        ///// <summary>
        ///// Delete a Cart
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Cart is deleted, else 0
        ///// </returns>
        //public int DeleteCart(int id)
        //{
        //    var i = 0;
        //    using (
        //        var conn =
        //            new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set the isolation level to readCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "Delete from Cart WHERE cartId=@id";
        //            cmd.Parameters.AddWithValue("id", id);
        //            i = cmd.ExecuteNonQuery();
        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;
        //}

        ///// <summary>
        ///// Add a PartOrder to a Cart
        ///// </summary>
        ///// <param name="cart"></param>
        ///// <param name="partOrder"></param>
        ///// <returns>
        ///// Return 1 if the PartOrder was added, else 0
        ///// </returns>
        //public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        //{
        //    var i = 0;
        //    using (
        //       var conn =
        //           new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
        //    {
        //        conn.Open();
        //        var cmd = conn.CreateCommand();
        //        // Set the isolation level to ReadCommitted
        //        var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        //        cmd.Connection = conn;
        //        cmd.Transaction = transaction;
        //        try
        //        {
        //            cmd.CommandText = "Update PartOrder Set partOrderCartId = @cartId where partOrderId = @partOrderId";
        //            cmd.Parameters.AddWithValue("cartId", cart.Id);
        //            cmd.Parameters.AddWithValue("partOrderId", partOrder.Id);
        //            i = cmd.ExecuteNonQuery();
        //            transaction.Commit();
        //            Console.WriteLine("Commit was succsesfull");

        //        }
        //        catch (Exception)
        //        {
        //            // The transaction failed
        //            try
        //            {
        //                // Try rolling back
        //                transaction.Rollback();
        //                Console.WriteLine("Transaction was rolled back");
        //            }
        //            catch (SqlException)
        //            {
        //                // Rolling back failed
        //                Console.WriteLine("Transaction rollback failed");
        //            }
        //        }
        //    }
        //    return i;

        //}

        /// <summary>
        /// Add a Cart with a list of PartOrders to the database
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// 1 if all PartOrders and the Cart was added, else 0
        /// </returns>
        public int AddCartWithPartOrders(Cart cart)
        {
            var flag = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the Isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                // Calculate the total price from all partOrders
                var cartTotalPrice = cart.PartOrders.Aggregate<PartOrder, decimal>(0, (current, partOrder) => partOrder.PartPrice + current);
                try
                {
                    //save Cart in DB and get generated cartId
                    cmd.CommandText = "INSERT INTO Cart(cartTotalPrice, cartPersonId, cartShopId) output inserted.cartId VALUES(@totalPrice, @PersonId, @ShopId)";

                    cmd.Parameters.AddWithValue("totalPrice", cartTotalPrice);
                    cmd.Parameters.AddWithValue("PersonId", cart.PersonId);
                    cmd.Parameters.AddWithValue("ShopId", cart.ShopId);
                    // Get cartId
                    var id = (int)cmd.ExecuteScalar();

                    // For each PartOrder
                    foreach (var po in cart.PartOrders)
                    {
                        var cmdPartOrder = conn.CreateCommand();
                        // Set the transaction level to ReadCommitted
                        cmdPartOrder.Transaction = transaction;
                        cmdPartOrder.CommandText = "Insert Into PartOrder (partOrderProductId, partOrderAmount, partOrderPartPrice, partOrderCartId) values (@productId, @amount, @partPrice, @cartId)";
                        cmdPartOrder.Parameters.AddWithValue("productId", po.Product.Id);
                        cmdPartOrder.Parameters.AddWithValue("amount", po.Amount);
                        cmdPartOrder.Parameters.AddWithValue("partPrice", po.PartPrice);
                        cmdPartOrder.Parameters.AddWithValue("cartId", id);
                        cmdPartOrder.ExecuteNonQuery();

                        // Get warehouseStock from DB decrease it with partOrder Amount and save in a variable
                        var cmdDecreseStock = conn.CreateCommand();
                        cmdDecreseStock.CommandText = "Select warehouseStock from Warehouse where warehouseProductId = @productId AND warehouseShopId = @shopId";
                        cmdDecreseStock.Parameters.AddWithValue("productId", po.Product.Id);
                        cmdDecreseStock.Parameters.AddWithValue("shopId", cart.ShopId);
                        // Set the isolation level to ReadCommitted
                        cmdDecreseStock.Transaction = transaction;
                        var reader = cmdDecreseStock.ExecuteReader();
                        var newStock = 0;
                        while (reader.Read())
                        {
                            // Calculate the new stock amount
                            newStock = reader.GetInt32(reader.GetOrdinal("warehouseStock")) - po.Amount;
                        }
                        reader.Close();

                        // Update warehouseStock with new saved value
                        var cmdUpdateWarehouse = conn.CreateCommand();
                        cmdUpdateWarehouse.CommandText = "Update Warehouse Set warehouseStock = @newStock where warehouseProductId = @productId AND warehouseShopId = @shopId";
                        cmdUpdateWarehouse.Parameters.AddWithValue("newStock", newStock);
                        cmdUpdateWarehouse.Parameters.AddWithValue("productId", po.Product.Id);
                        cmdUpdateWarehouse.Parameters.AddWithValue("shopId", cart.ShopId);
                        // Set the isolation level to ReadCommitted
                        cmdUpdateWarehouse.Transaction = transaction;
                        cmdUpdateWarehouse.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    // Everything went well, set flag to 1
                    flag = 1;
                    Console.WriteLine("Commit was succsesfull");

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
            return flag;
        }
    }
}
