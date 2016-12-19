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
        //Cart GetCart(int id);
        //Cart GetCartWithPartOrders(int id);
        List<Cart> GetAllCarts();
        //int UpdateCart(Cart cart);
        //int DeleteCart(int id);
        //int AddPartOrderToCart(Cart cart, PartOrder partOrder);
        int AddCartWithPartOrders(Cart cart);
        List<Cart> GetAllCartsByPersonId(int personId);
    }
}