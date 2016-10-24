using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbShop
    {
        Shop GetShop(int id);
        void AddShop(Shop shop);
        List<Shop> GetAllShops();
        void UpdateShop(Shop shop);
        void DeleteShop(int id);
    }
}