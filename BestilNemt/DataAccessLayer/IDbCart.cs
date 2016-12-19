using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbCart
    /// </summary>
    public interface IDbCart
    {
        int AddCart(Cart cart);
        List<Cart> GetAllCarts();
        int AddCartWithPartOrders(Cart cart);
        List<Cart> GetAllCartsByPersonId(int personId);
    }
}