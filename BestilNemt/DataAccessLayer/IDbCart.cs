using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbCart
    {
        int AddCart(Cart cart);
        Cart FindCart(int id);
        List<Cart> GetAllCarts();
        int UpdateCart(Cart cart);
        int DeleteCart(int id);
        int AddPartOrderToCart(Cart cart, PartOrder partOrder);
    }
}