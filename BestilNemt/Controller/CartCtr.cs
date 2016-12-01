using System;
using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class CartCtr
    {
        public IDbCart IDbCart { get; set; }

        public CartCtr(IDbCart iDbCart)
        {
            IDbCart = iDbCart;
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
            return IDbCart.AddCart(cart);
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
            return IDbCart.FindCart(id);
        }

        /// <summary>
        /// Return a Cart by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Cart if found, else null
        /// </returns>
        public Cart FindCartWithPartOrders(int id)
        {
            return IDbCart.FindCartWithPartOrders(id);
        }

        public int UpdateCart(Cart cart)
        {
            return IDbCart.UpdateCart(cart);
        }

        public int DeleteCart(int id)
        {
            return IDbCart.DeleteCart(id);
        }

        public List<Cart> GetAllCarts()
        {
            return IDbCart.GetAllCarts();
        }

        public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        {
            if (cart != null && partOrder != null)
            {
                return IDbCart.AddPartOrderToCart(cart, partOrder);
            }
            return 0;
        }

        public int AddCartWithPartOrders(Cart cart)
        {
            return IDbCart.AddCartWithPartOrders(cart);
        }

        public List<Cart> GetAllCartsByPersonId(int personId)
        {
            return IDbCart.GetAllCartsByPersonId(personId);
        }
    }
}
