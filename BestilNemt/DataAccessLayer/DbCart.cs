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
        /// <summary>
        /// Add a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// Return 1 if Cart is added, else 0
        /// </returns>
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

        /// <summary>
        /// Return a Cart by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Cart if found, else null
        /// </returns>
        public Cart FindCart(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a list of all Carts
        /// </summary>
        /// <returns>
        /// Return List of Cart 
        /// </returns>
        public List<Cart> GetAllCarts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// Return 1 if Cart is updated, else 0
        /// </returns>
        public int UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Cart is deleted, else 0
        /// </returns>
        public int DeleteCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}
