using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class CartCtrTestClass : IDbCart
    {
        private List<Cart> carts = new List<Cart>();
        private int idCounter = 1;
        public int AddCart(Cart cart)
        {
            cart.Id = idCounter;
            carts.Add(cart);
            idCounter++;
            return cart.Id;
        }

        public List<Cart> GetAllCarts()
        {
            return carts;
        }

        public int AddCartWithPartOrders(Cart cart)
        {
            return 1;
        }

        public List<Cart> GetAllCartsByPersonId(int personId)
        {
            return  carts.FindAll(c => c.PersonId == personId);
        }
    }
}
