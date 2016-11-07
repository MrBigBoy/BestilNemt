using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Cart FindCart(int id)
        {
            return carts.FirstOrDefault(c => c.Id == id);

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
