using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.ServiceModel.Channels;
using Models;

namespace DataAccessLayer
{
    public class DbPartOrder : IDbPartOrder
    {
        public int AddPartOrder(PartOrder partOrder)
        {
            int i;
            using (
                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();

                var cmd =
                    new SqlCommand(
                        "Insert into PartOrder(productId,amount,partPrice,cartId) values(@productId, @amount, @partPrice, @cartId)", conn);
                cmd.Parameters.AddWithValue("productId", partOrder.Product.Id);
                cmd.Parameters.AddWithValue("amount", partOrder.Amount);
                cmd.Parameters.AddWithValue("partPrice", partOrder.PartPrice);
                cmd.Parameters.AddWithValue("cartId", partOrder.Cart.Id);
                i = cmd.ExecuteNonQuery();

            }
            return i;
        }

        public int RemovePartOrder(int id)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Delete From PartOrder Where id = @id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public PartOrder FindPartOrder(int id)
        {
            Product product = null;
            PartOrder partOrder = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Product, PartOrder where partOrderId = @id and product.id = productId", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    product = new Product()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Category = reader.GetString(reader.GetOrdinal("category"))
                    };

                    partOrder = new PartOrder()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("partOrderId")),
                        Product = product,
                        Amount = reader.GetInt32(reader.GetOrdinal("amount")),
                        PartPrice = reader.GetDecimal(reader.GetOrdinal("partPrice"))
                    };
                }
            }
            return partOrder;
        }

        public List<PartOrder> GetAllPartOrders()
        {
            Product product = null;
            var partOrders = new List<PartOrder>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Select * from PartOrder, Product WHERE PartOrder.productId = Product.id", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product = new Product()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("price")),
                        Description = reader.GetString(reader.GetOrdinal("description")),
                        Category = reader.GetString(reader.GetOrdinal("category"))
                    };

                    var partOrder = new PartOrder()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("partOrderId")),
                        Product = product,
                        Amount = reader.GetInt32(reader.GetOrdinal("amount")),
                        PartPrice = reader.GetDecimal(reader.GetOrdinal("partPrice"))
                    };
                    partOrders.Add(partOrder);
                }
            }
            return partOrders;
        }

        public int UpdatePartOrder(PartOrder partOrder)
        {
            int i;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd =
                    new SqlCommand("UPDATE PartOrder SET amount=@amount, partprice=@partprice WHERE id=@id",
                        conn);
                
                cmd.Parameters.AddWithValue("id", partOrder.Id);
                cmd.Parameters.AddWithValue("amount", partOrder.Amount);
                cmd.Parameters.AddWithValue("partprice", partOrder.PartPrice);
               
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
