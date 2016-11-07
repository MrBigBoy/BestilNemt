using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbProduct : IDbProduct
    {
        /// <summary>
        /// Add the product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Return the id of the product from the identity on the database else 0
        /// </returns>
        public int CreateProduct(Product product)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand(
                        "DECLARE @DataID int; INSERT INTO Product(name, price, description, category, saving)VALUES(@Name, @Price, @Description, @Category, @Saving); SELECT @DataID = scope_identity(); ", conn);
                cmd.Parameters.AddWithValue("Name", product.Name);
                cmd.Parameters.AddWithValue("Price", product.Price);
                cmd.Parameters.AddWithValue("Description", product.Description);
                cmd.Parameters.AddWithValue("Category", product.Category);
                cmd.Parameters.AddWithValue("Saving", product.Saving);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Remove the product from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// return 1 if the product was deleted, else 0
        /// </returns>
        public int RemoveProduct(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("DELETE FROM Product WHERE Id = @id", conn);
                command.Parameters.AddWithValue("Id", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Find a product in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The product found, else null
        /// </returns>
        public Product FindProduct(int id)
        {
            Product product = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM Product WHERE id=@Id", conn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Category = reader.GetString(reader.GetOrdinal("category")),
                        Saving = reader.GetDouble(reader.GetOrdinal("saving"))
                    };
                }
            }
            return product;
        }

        /// <summary>
        /// Find all products in the database
        /// </summary>
        /// <returns>
        /// A list of products
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
                    var product = new Product
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Category = reader.GetString(reader.GetOrdinal("category")),
                        Saving = reader.GetDouble(reader.GetOrdinal("saving"))
                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public int UpdateProduct(Product product)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("UPDATE Product SET name = @Name, price = @Price, description = @Description, category = @Category, saving = @saving WHERE id = @Id", conn);
                command.Parameters.AddWithValue("Id", product.Id);
                command.Parameters.AddWithValue("Name", product.Name);
                command.Parameters.AddWithValue("Price", product.Price);
                command.Parameters.AddWithValue("Description", product.Description);
                command.Parameters.AddWithValue("Category", product.Category);
                command.Parameters.AddWithValue("Saving", product.Saving);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        public int DeleteProduct(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var command = new SqlCommand("DELETE FROM Product WHERE Id = @id", conn);
                command.Parameters.AddWithValue("Id", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }
    }
}
