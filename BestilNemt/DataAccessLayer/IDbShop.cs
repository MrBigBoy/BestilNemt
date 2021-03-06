﻿using System.Collections.Generic;
using System.Data;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbShop
    /// </summary>
    public interface IDbShop
    {
        int AddShop(Shop shop);
        int DeleteShop(int id);
        int UpdateShop(Shop shop);
        List<Shop> GetAllShopsByChainId(int chainId);
        Shop GetShop(int id);
        DataTable GetDataGridShop();
    }
}