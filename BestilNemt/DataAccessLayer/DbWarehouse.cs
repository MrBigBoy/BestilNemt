using System;
using System.Collections.Generic;
using Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public class DbWarehouse : IDbWarehouse
    {
        /// <summary>
        /// Add a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// id of Warehouse if added, else 0
        /// </returns>
       
        public int AddWarehouse(Warehouse warehouse)
        {
            var id = 0;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText =
                        "If not Exists (Select * from Warehouse where warehouseShopId = @warehouseShopId and warehouseProductId = @warehouseProductId)" +
                        " INSERT INTO Warehouse(warehouseStock, warehouseMinStock, warehouseShopId, warehouseProductId, warehouseSavingId) output inserted.warehouseId " +
                        "VALUES(@warehouseStock, @warehouseMinStock, @warehouseShopId, @warehouseProductId, @WarehouseSavingId)";
                    
                    cmd.Parameters.AddWithValue("warehouseStock", warehouse.Stock);
                    cmd.Parameters.AddWithValue("warehouseMinStock", warehouse.MinStock);
                    cmd.Parameters.AddWithValue("warehouseShopId", warehouse.Shop.Id);
                    cmd.Parameters.AddWithValue("warehouseProductId", warehouse.Product.Id);
                    if (warehouse.SavingId == null)
                        cmd.Parameters.AddWithValue("WarehouseSavingId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("WarehouseSavingId", warehouse.SavingId);

                    // get the id
                    id = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                    Console.WriteLine("Commit was successfull");

                }
                catch (Exception ex)
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

        /// <summary>
        /// Get a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Warehouse if found, else null
        /// </returns>
        public Warehouse GetWarehouse(int id)
        {
            Warehouse warehouse = null;

            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse, Product WHERE warehouseId = @id and Product.productId = warehouseProductId ", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the product
                    var product = ObjectBuilder.CreateProduct(reader);
                    // Build the Warehouse with a product
                    warehouse = ObjectBuilder.CreateWarehouse(reader, product);
                }
            }
            return warehouse;
        }

        /// <summary>
        /// Get all warehouses
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> GetAllWarehouses()
        {
            var warehouses = new List<Warehouse>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse, Product WHERE Product.productId = warehouseProductId", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the product object
                    var product = ObjectBuilder.CreateProduct(reader);
                    // Build the warehouse with a product
                    var warehouse = ObjectBuilder.CreateWarehouse(reader, product);
                    // Add the warehouse to the list
                    warehouses.Add(warehouse);
                }
            }
            return warehouses;
        }

        /// <summary>
        /// Get all Warehouse by a shop id
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns>
        /// List of Warehouse
        /// </returns>
        public List<Warehouse> GetAllWarehousesByShopId(int shopId)
        {
            var warehouses = new List<Warehouse>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse, Product WHERE Product.productId = warehouseProductId and warehouseShopId = @ShopId", conn);
                cmd.Parameters.AddWithValue("ShopId", shopId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Build the product object
                    var product = ObjectBuilder.CreateProduct(reader);
                    // Build the warehouse with a product
                    var warehouse = ObjectBuilder.CreateWarehouse(reader, product);
                    // Add the warehouse to the list
                    warehouses.Add(warehouse);
                }
            }
            return warehouses;
        }

        public int UpdateWarehouse(Warehouse warehouse)
        {
            var i = 0;
            using (
               var conn =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Update Warehouse Set warehouseStock = @stock, warehouseMinStock = @minStock, warehouseShopId = @shopId, warehouseProductId = @productId, warehouseSavingId = @SavingId where warehouseId = @warehouseId";
                    cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                    cmd.Parameters.AddWithValue("minStock", warehouse.MinStock);
                    cmd.Parameters.AddWithValue("shopId", warehouse.Shop.Id);
                    cmd.Parameters.AddWithValue("productId", warehouse.Product.Id);
                    cmd.Parameters.AddWithValue("warehouseId", warehouse.Id);
                    if (warehouse.SavingId == null)
                        cmd.Parameters.AddWithValue("SavingId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("SavingId", warehouse.SavingId);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Commit was successfull");

                }
                catch (Exception ex)
                {
                    // The transaction failed
                    try
                    {
                        // Try rolling back
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
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
        /// Delete a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if warehouse was deleted, else 0
        /// </returns>
        public int DeleteWarehouse(int id)
        {
            var i = 0;
            using (
               var conn =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the transaction level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Delete from Warehouse where warehouseId = @warehouseId";
                    cmd.Parameters.AddWithValue("warehouseId", id);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Commit was successfull");
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
        /// Get a Warehouse by a Product id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="shopId"></param>
        /// <returns>
        /// Warehouse if found, else null
        /// </returns>
        public Warehouse GetWarehouseByProductId(int productId, int shopId)
        {
            Warehouse warehouse = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Warehouse, Product WHERE warehouseProductId=@ProductId And warehouseProductId = productId AND warehouseShopId = @ShopId", conn);
                command.Parameters.AddWithValue("ProductId", productId);
                command.Parameters.AddWithValue("ShopId", shopId);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Build the object
                    var product = ObjectBuilder.CreateProduct(reader);
                    warehouse = ObjectBuilder.CreateWarehouse(reader, product);
                }
            }
            return warehouse;
        }
    }
}
