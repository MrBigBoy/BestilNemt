using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DbCart : IDbCart
    {
        public int AddCart(Cart cart)
        {
            int id;
            using (
                var conn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();

                var cmd =
                    new SqlCommand(
                        "INSERT INTO Cart(totalPrice) output inserted.id VALUES(@totalPrice)", conn);
                cmd.Parameters.AddWithValue("totalPrice", cart.TotalPrice);
                id = (int)cmd.ExecuteScalar();

            }
            return id;
        }

        public Cart FindCart(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAllCarts()
        {
            throw new NotImplementedException();
        }

        public int UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public int DeleteCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}
