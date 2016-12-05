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
        /// Return the id of the product from the identity on the database else 0
        /// </returns>
        public int AddProduct(Product product)
        {
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
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
                    i = (int)cmd.ExecuteScalar();
                    transaction.Commit();
                }
                catch (Exception ex)
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
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the product was deleted, else 0
        /// </returns>
        public int RemoveProduct(int id)
        {
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
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
        /// Return Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Product if found, else null
        /// </returns>
        public Product FindProduct(int id)
        {
            Product product = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product WHERE productId=@ProductId", conn);
                command.Parameters.AddWithValue("ProductId", id);
                var reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return null;
                while (reader.Read())
                {
                    product = ObjectBuilder.CreateProduct(reader);
                }
            }
            return product;
        }

        public List<Product> FindProductsByName(string input)
        {
            var products = new List<Product>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("Select * From Product Where productName Like @name", conn);
                command.Parameters.AddWithValue("name", input);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Return a List of all Products
        /// </summary>
        /// <returns>
        /// List of products
        /// </returns>
        public List<Product> FindAllProducts()
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product", conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Return a List of all Products
        /// </summary>
        /// <returns>
        /// List of products
        /// </returns>
        public List<Product> FindAllSoldProducts()
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Cart, PartOrder, Product WHERE cartId = partOrderCartId AND partOrderProductId = productId", conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Return a List of all Products
        /// </summary>
        /// <returns>
        /// List of products
        /// </returns>
        public List<Product> FindAllProductsWithSavings()
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product, Saving WHERE productSavingId = savingId", conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
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
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
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
                catch (Exception ex)
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
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Product is deleted, else 0
        /// </returns>
        public int DeleteProduct(int id)
        {
            int i = 0;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
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
