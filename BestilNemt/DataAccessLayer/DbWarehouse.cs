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
                var cmd = new SqlCommand("INSERT INTO Warehouse(stock, minStock, shopId, productid) OUTPUT Inserted.ID VALUES(@Stock, @MinStock, @ShopId, @ProductId)", conn);
                cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                cmd.Parameters.AddWithValue("MinStock", warehouse.MinStock);
                cmd.Parameters.AddWithValue("ShopId", warehouse.Shop.Id);
                cmd.Parameters.AddWithValue("ProductId", warehouse.Product.Id);
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
                var cmd = new SqlCommand("DELETE FROM Warehouse Where id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
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
                var cmd = new SqlCommand("UPDATE Warehouse SET stock=@Stock, minStock=@MinStock, shopId=@ShopId, productId=ProductId WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("Stock", warehouse.Stock);
                cmd.Parameters.AddWithValue("MinStock", warehouse.MinStock);
                cmd.Parameters.AddWithValue("ShopId", warehouse.Shop.Id);
                cmd.Parameters.AddWithValue("ProductId", warehouse.Product.Id);
                cmd.Parameters.AddWithValue("id", warehouse.Id);
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
                var cmd = new SqlCommand("select * from Warehouse, Shop, Product WHERE Warehouse.id = @id and shopId = Shop.Id and productId = Product.id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var shop = new Shop
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Shop.id")),
                        Name = reader.GetString(reader.GetOrdinal("shopName")),
                        Address = reader.GetString(reader.GetOrdinal("shopAddress")),
                        CVR = reader.GetString(reader.GetOrdinal("shopCVR"))
                    };
                    var product = new Product
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Product.id")),
                        Category = reader.GetString(reader.GetOrdinal("category")),
                        Name = reader.GetString(reader.GetOrdinal("Product.name")),
                        Saving = reader.GetDouble(reader.GetOrdinal("Saving")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                    };
                    warehouse = new Warehouse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Warehouse.id")),
                        Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                        MinStock = reader.GetInt32(reader.GetOrdinal("minStock")),
                        Shop = shop,
                        Product = product
                    };
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
                var cmd = new SqlCommand("select * from Warehouse, Shop, Product WHERE shopId = Shop.Id and productId = Product.id", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var shop = new Shop
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Shop.id")),
                        Name = reader.GetString(reader.GetOrdinal("shopName")),
                        Address = reader.GetString(reader.GetOrdinal("shopAddress")),
                        CVR = reader.GetString(reader.GetOrdinal("shopCVR"))
                    };
                    var product = new Product
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Product.id")),
                        Category = reader.GetString(reader.GetOrdinal("category")),
                        Name = reader.GetString(reader.GetOrdinal("Product.name")),
                        Saving = reader.GetDouble(reader.GetOrdinal("Saving")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                    };
                    var warehouse = new Warehouse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                        MinStock = reader.GetInt32(reader.GetOrdinal("minStock")),
                        Shop = shop,
                        Product = product
                    };
                    warehouses.Add(warehouse);
                }
            }
            return warehouses;
        }
    }
}
