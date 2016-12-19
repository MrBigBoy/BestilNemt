using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbProduct : IDbProduct
    {
        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Id of Product if added, else 0
        /// </returns>
        public int AddProduct(Product product)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "INSERT INTO Product(productName, productPrice, productDescription, productCategory, productImgPath) OUTPUT Inserted.productId VALUES(@Name, @Price, @Description, @Category, @ImgPath)";
                    cmd.Parameters.AddWithValue("Name", product.Name);
                    cmd.Parameters.AddWithValue("Price", product.Price);
                    cmd.Parameters.AddWithValue("Description", product.Description);
                    cmd.Parameters.AddWithValue("Category", product.Category);
                    cmd.Parameters.AddWithValue("ImgPath", product.ImgPath);
                    // Get the id
                    i = (int)cmd.ExecuteScalar();
                    transaction.Commit();
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
        /// Get a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// product if found, else null
        /// </returns>
        public Product GetProduct(int id)
        {
            Product product = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product WHERE productId=@ProductId", conn);
                command.Parameters.AddWithValue("ProductId", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Build the object
                    product = ObjectBuilder.CreateProduct(reader);
                }
            }
            return product;
        }

        /// <summary>
        /// Get all Product similar to name
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllProductsByName(string input)
        {
            var products = new List<Product>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product WHERE productName LIKE @name", conn);
                command.Parameters.AddWithValue("name", input);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Product object
                    var product = ObjectBuilder.CreateProduct(reader);
                    // Add the Product to the list
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Get all Sold products
        /// </summary>
        /// <returns>
        /// List of products
        /// </returns>
        public List<Product> GetAllSoldProducts()
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Cart, PartOrder, Product WHERE cartId = partOrderCartId AND partOrderProductId = productId", conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Product object
                    var product = ObjectBuilder.CreateProduct(reader);
                    // Add to the list
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Get all Products with Saving
        /// </summary>
        /// <returns>
        /// List of products
        /// </returns>
        public List<Product> GetAllProductsWithSavings()
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product, Saving, Warehouse WHERE warehouseProductId = productId AND warehouseSavingId = savingId", conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Build the Product object
                    var product = ObjectBuilder.CreateProduct(reader);
                    // Add to the list
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Return 1 if Product is updated, else 0
        /// </returns>
        public int UpdateProduct(Product product)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Product SET productName = @ProductName, productPrice = @ProductPrice, productDescription = @ProductDescription, productCategory = @productCategory, productImgPath = @pImgPath WHERE productId = @ProductId";
                    cmd.Parameters.AddWithValue("ProductId", product.Id);
                    cmd.Parameters.AddWithValue("ProductName", product.Name);
                    cmd.Parameters.AddWithValue("ProductPrice", product.Price);
                    cmd.Parameters.AddWithValue("ProductDescription", product.Description);
                    cmd.Parameters.AddWithValue("ProductCategory", product.Category);
                    cmd.Parameters.AddWithValue("pImgPath", product.ImgPath);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
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
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Product is deleted, else 0
        /// </returns>
        public int DeleteProduct(int id)
        {
            var i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Set the isolation level to ReadCommitted
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DELETE FROM Warehouse WHERE warehouseProductId = @ProductId; DELETE FROM Product WHERE productId = @ProductId";
                    cmd.Parameters.AddWithValue("ProductId", id);
                    i = cmd.ExecuteNonQuery();
                    transaction.Commit();
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
            return i;
        }

        public DataTable GetDataGridProducts()
        {
            var cmdString = "Select productId, productName, productPrice, productDescription, productCategory, productImgPath from Product";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                //Open the connection and send the CmdString
                conn.Open();
                var cmd = new SqlCommand(cmdString, conn);
                //Take the returned SQL and adapt it to a datatable
                var sda = new SqlDataAdapter(cmd);
                var dt = new DataTable("Produkter");
                //Fill out the datatable 
                sda.Fill(dt);
                return dt;
            }
        }

        public DataTable GetProductWarehouse(int adminId)
        {
            var cmdString = "SELECT productId, warehouseId, productName, productPrice,(productPrice-productPrice*savingPercent/100) as savingPrice, warehouseStock," +
                            "wareHouseMinStock, administratorShopId, warehouseSavingId, savingPercent," +
                            "CONVERT(varchar, savingStartDate, 106) as savingStartDate, CONVERT(varchar, savingEndDate, 106) as savingEndDate " +
                            "FROM Warehouse " +
                            "LEFT JOIN Saving On savingId = warehouseSavingId " +
                            "LEFT JOIN Product On productId = warehouseproductId " +
                            "LEFT JOIN Administrator on administratorShopId = warehouseShopId " +
                            "WHERE administratorShopId = 1 and warehouseShopId = 1 and warehouseProductId = productId and(savingId = warehouseSavingId Or warehouseSavingId Is NULL);";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(cmdString, conn);
                cmd.Parameters.AddWithValue("adminShopId", adminId);
                //Takes what the SQL return and adapts it so it can be used in a datatabel
                var sda = new SqlDataAdapter(cmd);
                var dt = new DataTable("ProductWareHouse");
                //fills the datatabel
                sda.Fill(dt);
                return dt;
            }
        }
    }
}
