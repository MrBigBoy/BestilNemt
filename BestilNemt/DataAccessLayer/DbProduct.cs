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
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the product was deleted, else 0
        /// </returns>
        public int RemoveProduct(int id)
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
                    cmd.CommandText = "DELETE FROM Product WHERE productId = @ProductId";
                    cmd.Parameters.AddWithValue("ProductId", id);
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
        public List<Product> GetProductsByName(string input)
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
        /// Get all products
        /// </summary>
        /// <returns>
        /// List of products
        /// </returns>
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product", conn);
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
                var transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "UPDATE Product SET productName = @ProductName, productPrice = @ProductPrice, productDescription = @ProductDescription, productCategory = @productCategory WHERE productId = @ProductId";
                    cmd.Parameters.AddWithValue("ProductId", product.Id);
                    cmd.Parameters.AddWithValue("ProductName", product.Name);
                    cmd.Parameters.AddWithValue("ProductPrice", product.Price);
                    cmd.Parameters.AddWithValue("ProductDescription", product.Description);
                    cmd.Parameters.AddWithValue("ProductCategory", product.Category);
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
                    cmd.CommandText = "DELETE FROM Product WHERE productId = @ProductId";
                    cmd.Parameters.AddWithValue("ProductId", id);
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
