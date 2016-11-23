using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccessLayer
{
    public class DbWarehouse : IDbWarehouse
    {
        public int AddWarehouse(Warehouse warehouse)
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
                    cmd.CommandText = "INSERT INTO Warehouse(warehouseStock, warehouseMinStock, warehouseShopId, warehouseProductId) " +
                                      "output inserted.warehouseId VALUES(@warehouseStock, @warehouseMinStock, @warehouseShopId, @warehouseProductId )";
                    cmd.Parameters.AddWithValue("warehouseStock", warehouse.Stock);
                    cmd.Parameters.AddWithValue("warehouseMinStock", warehouse.MinStock);
                    cmd.Parameters.AddWithValue("warehouseShopId", warehouse.Shop.Id);
                    cmd.Parameters.AddWithValue("warehouseProductId", warehouse.Product.Id);
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

        public Warehouse FindWarehouse(int id)
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
                    var product = ObjectBuilder.CreateProduct(reader);
                    warehouse = ObjectBuilder.CreateWarehouse(reader, product);
                }
            }
            return warehouse;
        }

        public List<Warehouse> FindAllWarehouses()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse, Product WHERE Product.productId = warehouseProductId ", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
                    var warehouse = ObjectBuilder.CreateWarehouse(reader, product);
                    warehouses.Add(warehouse);
                }
            }
            return warehouses;
        }

        public List<Warehouse> FindAllWarehousesByShopId(int shopId)
        {
            List<Warehouse> warehouses = new List<Warehouse>();
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
                    var product = ObjectBuilder.CreateProduct(reader);
                    var warehouse = ObjectBuilder.CreateWarehouse(reader, product);
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
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "Update Warehouse Set warehouseStock = @stock, warehouseMinStock = @minStock, warehouseShopId = @shopId, warehouseProductId = @productId where warehouseId = @warehouseId";
                    cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                    cmd.Parameters.AddWithValue("minStock", warehouse.MinStock);
                    cmd.Parameters.AddWithValue("shopId", warehouse.Shop.Id);
                    cmd.Parameters.AddWithValue("productId", warehouse.Product.Id);
                    cmd.Parameters.AddWithValue("warehouseId", warehouse.Id);
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

        public int DeleteWarehouse(int id)
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
                    cmd.CommandText = "Delete from Warehouse where warehouseId = @warehouseId";
                    cmd.Parameters.AddWithValue("warehouseId", id);
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
    }
}
