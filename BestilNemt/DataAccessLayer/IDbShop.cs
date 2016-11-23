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
        List<Shop> FindAllShopsByChainId(int chainId);
        Shop FindShop(int id);
    }
}