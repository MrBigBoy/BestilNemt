using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace Controller
{
   public class CartCtr
    {
        public IDbCart CartIdb { get; set; }

        public CartCtr(IDbCart iDbCart)
        {
            CartIdb = iDbCart;
        }

        public int AddCart(Cart cart)
        {
           return CartIdb.AddCart(cart);
        }

        public Cart FindCart(int id)
        {
            return CartIdb.FindCart(id) ;
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
