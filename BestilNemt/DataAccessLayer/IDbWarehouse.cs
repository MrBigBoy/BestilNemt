using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbWarehouse
    {
        int AddWarehouse(Warehouse warehouse);
        Warehouse GetWarehouse(int id);
        List<Warehouse> GetAllWarehouses();
        List<Warehouse> GetAllWarehousesByShopId(int shopId);
        int UpdateWarehouse(Warehouse warehouse);
        int DeleteWarehouse(int id);
    }
}