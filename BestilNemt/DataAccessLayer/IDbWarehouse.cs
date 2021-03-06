﻿using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbWarehouse
    /// </summary>
    public interface IDbWarehouse
    {
        int AddWarehouse(Warehouse warehouse);
        Warehouse GetWarehouse(int id);
        List<Warehouse> GetAllWarehousesByShopId(int shopId);
        int UpdateWarehouse(Warehouse warehouse);
        int DeleteWarehouse(int id);
        Warehouse GetWarehouseByProductId(int productId, int shopId);
    }
}