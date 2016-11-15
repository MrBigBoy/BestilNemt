using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbWarehouse : IDbWarehouse
    {
        /// <summary>
        /// AddWarehouse a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Return id of Warehouse is added, else 0
        /// </returns>
        public int AddWarehouse(Warehouse warehouse)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Warehouse(warehouseStock, warehouseMinStock, warehouseShopId, warehouseProductId) OUTPUT Inserted.warehouseId VALUES(@WarehouseStock, @WarehouseMinStock, @WarehouseShopId, @WarehouseProductId)", conn);
                cmd.Parameters.AddWithValue("WarehouseStock", warehouse.Stock);
                cmd.Parameters.AddWithValue("WarehouseMinStock", warehouse.MinStock);
                cmd.Parameters.AddWithValue("WarehouseShopId", warehouse.Shop.Id);
                cmd.Parameters.AddWithValue("WarehouseProductId", warehouse.Product.Id);
                i = (int)cmd.ExecuteScalar();
            }
            return i;
        }

        /// <summary>
        /// Delete a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the Warehouse is deleted, else 0
        /// </returns>
        public int DeleteWarehouse(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Warehouse Where warehouseId=@WarehouseId", conn);
                cmd.Parameters.AddWithValue("WarehouseId", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// UpdateWarehouse a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Return 1 if the Warehouse is updated, else 0
        /// </returns>
        public int UpdateWarehouse(Warehouse warehouse)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Warehouse SET warehouseStock=@WarehouseStock, warehouseMinStock=@WarehouseMinStock, warehouseShopId=@WarehouseShopId, warehouseProductId=ProductId WHERE id=@WarehouseId", conn);
                cmd.Parameters.AddWithValue("WarehouseStock", warehouse.Stock);
                cmd.Parameters.AddWithValue("WarehouseMinStock", warehouse.MinStock);
                cmd.Parameters.AddWithValue("WarehouseShopId", warehouse.Shop.Id);
                cmd.Parameters.AddWithValue("WarehouseProductId", warehouse.Product.Id);
                cmd.Parameters.AddWithValue("WarehouseId", warehouse.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Warehouse if found, else null
        /// </returns>
        public Warehouse FindWarehouse(int id)
        {
            Warehouse warehouse = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse, Shop, Product WHERE warehouseId = @WarehouseId and shopId = Shop.shopId and productId = Product.productId", conn);
                cmd.Parameters.AddWithValue("WarehouseId", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var shop = ObjectBuilder.CreateShop(reader);
                    var product = ObjectBuilder.CreateProduct(reader);
                    warehouse = ObjectBuilder.CreateWarehouse(reader, shop, product);
                }
            }
            return warehouse;
        }

        /// <summary>
        /// Return a list of all Warehouses
        /// </summary>
        /// <returns>
        /// List of Warehouse
        /// </returns>
        public List<Warehouse> FindAllWarehouses()
        {
            var warehouses = new List<Warehouse>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse, Shop, Product WHERE warehouseShopId = shopId and warehouseProductId = productId", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var shop = ObjectBuilder.CreateShop(reader);
                    var product = ObjectBuilder.CreateProduct(reader);
                    var warehouse = ObjectBuilder.CreateWarehouse(reader, shop, product);
                    warehouses.Add(warehouse);
                }
            }
            return warehouses;
        }
    }
}
