using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbShop
    {
        int AddShop(Shop shop);
        int DeleteShop(int id);
        int UpdateShop(Shop shop);
        List<Shop> FindAllShops();
        Shop FindShop(int id);
    }
}