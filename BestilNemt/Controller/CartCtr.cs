using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class CartCtr
    {
        public IDbCart DbCart { get; set; }

        /// <summary>
        /// Constructor for Cart Controller
        /// </summary>
        /// <param name="iDbCart"></param>
        public CartCtr(IDbCart iDbCart)
        {
            DbCart = iDbCart;
        }

        /// <summary>
        /// Add a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// Return id of Cart if added, else 0
        /// </returns>
        public int AddCart(Cart cart)
        {
            return DbCart.AddCart(cart);
        }
        
        /// <summary>
        /// Get all Carts
        /// </summary>
        /// <returns>
        /// List of Cart
        /// </returns>
        public List<Cart> GetAllCarts()
        {
            return DbCart.GetAllCarts();
        }
        
        /// <summary>
        /// Add a Cart with PartOrders to the database
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// List of Cart
        /// </returns>
        public int AddCartWithPartOrders(Cart cart)
        {
            return ValidateCart(cart) ? DbCart.AddCartWithPartOrders(cart) : 0;
        }

        /// <summary>
        /// Get all Cart by a Person Id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>
        /// List of cart
        /// </returns>
        public List<Cart> GetAllCartsByPersonId(int personId)
        {
            return DbCart.GetAllCartsByPersonId(personId);
        }

        /// <summary>
        /// This method validate Cart fields
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// True if fields is correct, else false
        /// </returns>
        public bool ValidateCart(Cart cart)
        {
            return cart.PersonId != 0 && cart.PartOrders.Count > 0;
        }
    }
}
