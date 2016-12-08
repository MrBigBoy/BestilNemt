using System.Collections.Generic;
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
        List<Warehouse> GetAllWarehouses();
        List<Warehouse> GetAllWarehousesByShopId(int shopId);
        int UpdateWarehouse(Warehouse warehouse);
        int UpdateWarehouseAdmin(Warehouse warehouse);
        int DeleteWarehouse(int id);
    }
}