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
            return carts;
        }

        public int UpdateCart(Cart cart)
        {
            var cartToUpdate = FindCart(cart.Id);
            if (cartToUpdate == null) return 0;
            cartToUpdate.TotalPrice = cart.TotalPrice;
            cartToUpdate.PartOrders = cart.PartOrders;
            return 1;
        }

        public int DeleteCart(int id)
        {
            return carts.Remove(FindCart(id)) ? 1 : 0;
        }

        public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        {
            return 1;
        }

        public int AddCartWithPartOrders(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
