using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbShop
    {
        Shop GetShop(int id);
        int AddShop(Shop shop);
        List<Shop> GetAllShops();
        int UpdateShop(Shop shop);
        int DeleteShop(int id);
    }
}