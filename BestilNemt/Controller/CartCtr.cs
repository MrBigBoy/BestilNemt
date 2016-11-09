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
            return IDbCart.FindCart(id) ;
        }

        public int UpdateCart(Cart cart)
        {
            return CartIdb.UpdateCart(cart);
        }

        public int DeleteCart(int id)
        {
            return CartIdb.DeleteCart(id);
        }

        public List<Cart> GetAllCarts()
        {
            return CartIdb.GetAllCarts();
        }
    }
}
