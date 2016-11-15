using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                        "Insert into PartOrder(partOrderProductId,partOrderAmount,partOrderPartPrice,partOrderCartId) values(@productId, @amount, @partPrice, @cartId)", conn);
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
                var cmd = new SqlCommand("Delete From PartOrder Where partOrderId = @id", conn);
                cmd.Parameters.AddWithValue("Id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public PartOrder FindPartOrder(int id)
        {
            PartOrder partOrder = null;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Product, PartOrder where partOrderId = @id and product.productId = partOrderProductId", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
                    partOrder = ObjectBuilder.CreatePartOrder(reader, product);
                }
            }
            return partOrder;
        }

        public List<PartOrder> GetAllPartOrders()
        {
            var partOrders = new List<PartOrder>();
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("Select * from PartOrder, Product WHERE PartOrder.partOrderProductId = Product.productId", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = ObjectBuilder.CreateProduct(reader);
                    var partOrder = ObjectBuilder.CreatePartOrder(reader, product);
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
                    new SqlCommand("UPDATE PartOrder SET partOrderAmount=@amount, partOrderPartPrice=@partprice WHERE partOrderId=@id",
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
