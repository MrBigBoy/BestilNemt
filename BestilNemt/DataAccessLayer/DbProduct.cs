using System.Collections.Generic;
using System.Configuration;
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
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand("INSERT INTO Product(productName, productPrice, productDescription, productCategory, productSaving) OUTPUT Inserted.productId VALUES(@Name, @Price, @Description, @Category, @Saving)", conn);
                cmd.Parameters.AddWithValue("Name", product.Name);
                cmd.Parameters.AddWithValue("Price", product.Price);
                cmd.Parameters.AddWithValue("Description", product.Description);
                cmd.Parameters.AddWithValue("Category", product.Category);
                cmd.Parameters.AddWithValue("Saving", product.Saving);
                i = (int)cmd.ExecuteScalar();
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
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("DELETE FROM Product WHERE productId = @ProductId", conn);
                command.Parameters.AddWithValue("ProductId", id);
                i = command.ExecuteNonQuery();
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

                if (!reader.HasRows) return null;
                while (reader.Read())
                {
                    product = ObjectBuilder.CreateProduct(reader);
                }
            }
            return product;
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
        /// Update a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Return 1 if Product is updated, else 0
        /// </returns>
        public int UpdateProduct(Product product)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("UPDATE Product SET productName = @ProductName, productPrice = @ProductPrice, productDescription = @ProductDescription, productCategory = @productCategory, productSaving = @ProductSaving WHERE productId = @ProductId", conn);
                command.Parameters.AddWithValue("ProductId", product.Id);
                command.Parameters.AddWithValue("ProductName", product.Name);
                command.Parameters.AddWithValue("ProductPrice", product.Price);
                command.Parameters.AddWithValue("ProductDescription", product.Description);
                command.Parameters.AddWithValue("ProductCategory", product.Category);
                command.Parameters.AddWithValue("ProductSaving", product.Saving);
                i = command.ExecuteNonQuery();
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
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("DELETE FROM Product WHERE productId = @ProductId", conn);
                command.Parameters.AddWithValue("ProductId", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }
    }
}
